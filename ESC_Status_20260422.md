# ESC Eligibility — Daily Status Report
**Run 4938800 | Processing Date: 2026-04-22 | Report Date: 2026-04-23**

---

## SECTION 1 — Solution Architect: Daily Status Call

### Run Health

| Metric | Value |
|---|---|
| Records Processed | 1,029 |
| Records with Errors | 8 |
| Success Rate | **99.2%** |
| New Issues This Run | **1 (code bug — high impact)** |
| Recurring Issues | 3 |

---

### Issue Summary

| # | Error Code(s) | Count | New / Recurring | Type | One-Line Root Cause |
|---|---|---|---|---|---|
| 1 | L771, L772, L957, L958 | 2,508 instances on **627 records** | 🔴 **NEW** | Code Bug | ETL writes transaction flag `U` into ESC Proc Code and Processing Mode fields on COB Patient Exception records — first triggered by CobUpdate events in this run |
| 2 | L932 | 5 records | 🟡 Recurring (34/38 runs) | Data Issue | GSAS plan code is blank for 2 policies — tier combination has no entry in ESC lookup table |
| 3 | L925 | 7 records | 🟡 Recurring (4 runs) | Data Issue | Pharmacy term date is computed as policy start date minus 1 day when COB has no end date, making it earlier than the effective date |
| 4 | L924 + E924 | 4 records (2+2) | 🟡 Recurring (6 runs) | Data Issue | Two dependent members are being submitted with a cardholder-type ID that ESC already has registered under a different role |

---

### Totals by Type

| Type | Issue Count | Record Count |
|---|---|---|
| Code Bug | 1 | 627 |
| Data Issue | 3 | 16 |
| **Total** | **4** | **643** |

---

### Issues Resolved vs Prior Run

| Resolved | Error | Last seen |
|---|---|---|
| ✅ | L916 (Unknown record rejection) | Runs 4938500, 4938600 — gone in this run |

---

## SECTION 2 — Developer: Precise Action Plan

> Actions are ordered by impact. A single fix under each action resolves **all** records listed beneath it.

---

### ACTION 1 — Fix Patient Exception record type YAML config
**Resolves:** L771 (×627), L772 (×627), L957 (×627), L958 (×627) — **2,508 error instances eliminated with one config change**
**Priority:** Immediate — this is a new regression affecting all policies with COB data

**What is broken:**
The ESC record type `2449310138` (Patient Exception / COB Patient) has field definitions that incorrectly place the transaction action code `U` into three positions the ESC spec defines differently:
- The **Proc Code** field (~position 41) — receives `U` → L771
- The **Proc Code Source** field (adjacent) — receives `U` → L772
- The **Dental/Pharmacy Processing Mode** field (~position 219) — receives `U`; must be `B` or `R` → L957 + L958

**Exact fix:**
1. Open the `2449310138` record type YAML file in the config bucket at:
   `esc-eligibility/config/Base/Mapping/` (or `Extensions/GMS/Mapping/`)
2. Find the field mapped to the Proc Code position — change its `path` or `default_value` so it is either space-filled or populated with a valid drug procedure code from the COB data, **not** the action code
3. Find the Proc Code Source field — same: space-fill or valid source identifier
4. Find the Dental Processing Mode and Pharmacy Processing Mode fields — set `default_value: "B"` (Basic — submit and receive) unless COB coverage type dictates `R` (Receive only)
5. Verify the action code (`U`) is only written to the correct action code position for the `2449` record layout (it differs from the `2049`/`2249` layout offsets)

**Verify by:** Re-running the eligibility file generation for any of these 4 policies and checking the fixed-width output at the relevant byte positions. Then resubmit to ESC and confirm no L771/L772/L957/L958 in the next hbm_er file.

**Affected policies (all fixed by the one config change):**

| Policy | ESC ID | Policyholder | Event | COB Insurer |
|---|---|---|---|---|
| P02441 | 2005449 | Elijah Foster | CobUpdate | FaithLife Financial |
| P02444 | 2005460 | Lily Stewart | CobUpdate | BMO Insurance |
| P02449 | 2005478 | Harper Mitchell | CobUpdate | BMO Insurance |
| P02465 | 2005529 | Jane Austen | NewPolicy | Personal plan |

**Code entry point:**
`src/CoverGo.ETL.Application/EscEligibility/Processing/Config/ConfigLoader.cs` — loads the YAML; no C# change needed, config bucket update only.

---

### ACTION 2 — Fix null COB end-date defaulting to startDate−1
**Resolves:** L925 (×7) — **all 7 records on policy P02457 eliminated with one logic fix**
**Priority:** High — recurring across 4 runs; will affect any CobUpdate with no termination date

**What is broken:**
When a policy has a COB with `effectiveDateTo: null`, the ETL computes the pharmacy termination date as `policy.startDate - 1 day`. For policy P02457 (start date 2026-04-21), this produces term date `20260420`, which is before the pharmacy effective date `20260421` → L925.

**Exact fix:**
In the field rule for the pharmacy termination date on record type `2049310138` (and `2249310138` for patient records):
- When the COB `effectiveDateTo` is null, default the pharmacy term date to `99999999` (ESC's open-ended sentinel) instead of computing `startDate - 1`
- Likely location: YAML config field rule for `pharm_term_date` using a conditional expression, or in `GetDentalEffectiveDateFunction.cs` if an analogous pharmacy date function exists
- Check `src/CoverGo.ETL.Application/EscEligibility/Processing/Expression/Functions/GetDentalEffectiveDateFunction.cs` for the pattern and apply the same null-guard to the pharmacy equivalent

**Affected policy:**

| Policy | ESC ID | Policyholder | Members Affected | Source File |
|---|---|---|---|---|
| P02457 | 2005497 | Layla2 Petersons | Layla2 + 3 dependents (D1, D2, D3 Petersons) | `CobUpdate_20260420_010510.jsonl` |

---

### ACTION 3 — Expand GSAS lookup table for missing tier combinations
**Resolves:** L932 (×5 this run) — **eliminates recurring errors across all future runs for unmatched tiers**
**Priority:** High — most persistent error (34/38 runs); low per-run count but never zero

**What is broken:**
Two policies have no GSAS code in their ESC output because their product/tier combination has no entry in the GSAS composite lookup table. The lookup returns empty → L932 (Invalid SAS).

**Exact fix:**
1. Identify the lookup table file: `Extensions/GMS/Lookups/gsas_lookup.yml` (or equivalent composite key lookup in the config bucket)
2. For each policy below, find the health/drug/dental tier combination from the JSONL source and add the missing row to the lookup table with the correct GSAS code
3. Coordinate with ESC to confirm the correct GSAS value for each tier combination before adding

**Affected policies:**

| Policy | ESC ID | Policyholder | Event | Source File | Missing Tier Info |
|---|---|---|---|---|---|
| P02399 | 2005343 | Caleb Davis | CancelledPolicy | `CancelledPolicy_20260421_060559.jsonl` | Tier combination not in GSAS lookup → blank GSAS |
| P02445 | 2005473 | James Johnson | CobUpdate | `CobUpdate_20260420_000603.jsonl` | Tier combination not in GSAS lookup → blank GSAS |

**Code entry point:**
`src/CoverGo.ETL.Application/EscEligibility/Processing/Expression/Functions/AutoCompositeKeyLookupFunction.cs` — drives GSAS resolution; if no key match returns empty. No C# change needed — add rows to the lookup YAML.

> **Note:** After fixing the lookup table, run a one-time audit of all active policies to identify any others with blank GSAS before their next update event triggers L932.

---

### ACTION 4 — Investigate ESC DB role conflict for two member IDs
**Resolves:** L924 (×2) + E924 (×2) — **4 records; requires ESC-side investigation first**
**Priority:** Medium — recurring (6 runs) but requires external coordination with ESC

**What is broken:**
Two CoverGo member `internalCode` values are already registered in ESC's database under a dependent role. When the ETL submits a record using the same ID as a cardholder, ESC rejects it.

**Exact fix (two-step):**
1. **Raise with ESC support:** Request ESC to query their database for member IDs `2005540` and `2005547` and confirm the current role (cardholder vs dependent). Provide ESC with the policy context below.
2. **After ESC confirms:** If ESC can re-register the ID under the correct role, request them to do so and resubmit. If the `internalCode` in CoverGo is wrong (recycled or mis-assigned), correct it in CoverGo and regenerate the eligibility records.

**Affected policies:**

| Policy | ESC ID | Policyholder | Conflicting Member | DOB | Event | Source File |
|---|---|---|---|---|---|---|
| P02470 | 2005540 | Daniel Wood | Ainhoa Wood (dependent, DOB 2001-02-15) | 2001-02-15 | CobUpdate | `CobUpdate_20260421_003605.jsonl` |
| P02473 | 2005547 | Gabriel Hall | Bella Hall (dependent, DOB 2003-09-03) | 2003-09-03 | NewPolicy | `NewPolicy_20260421_000601.jsonl` |

**Code entry point (if CoverGo-side fix needed):**
`src/CoverGo.ETL.Application/EscEligibility/Processing/Expression/Functions/GetPatientCodeFunction.cs` — verify the cardholder/dependent ordinal code assignment logic.

---

### Fix Impact Summary

| Action | Fix Type | Records Fixed This Run | Recurring Runs Fixed | Effort |
|---|---|---|---|---|
| 1 — 2449 YAML config | Config bucket update | 627 | Prevents recurrence on all future COB runs | Low (config only) |
| 2 — Null COB term date | Config/code fix | 7 | Prevents recurrence on CobUpdate with no end date | Low–Medium |
| 3 — GSAS lookup expansion | Config bucket update | 5 | Reduces L932 across all future runs | Medium (audit needed) |
| 4 — ESC DB role conflict | External (ESC) + data | 4 | Resolves these 2 policies permanently | Medium (coordination) |

---

*Generated: 2026-04-23 | Based on HBM run 4938800 and analysis of 38 historical runs*
