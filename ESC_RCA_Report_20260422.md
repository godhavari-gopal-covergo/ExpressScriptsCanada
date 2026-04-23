# ESC Eligibility Root Cause Analysis — Run 4938800 (2026-04-22)

> **Scope:** HBM run 4938800, processing date 2026-04-22. 8 error types, 9 policies affected.
> Cross-referenced with JSONL source data and ETL code in `etl-code/src/CoverGo.ETL.Application/EscEligibility/`.

---

## Error Group 1: L771 + L772 + L957 + L958 — Patient Exception Record (2449310138) Format Errors

### Error Codes

| Code | Description | Count |
|---|---|---|
| `L771` | Invalid Proc Code value | 627 |
| `L772` | Invalid Proc Code Source value | 627 |
| `L957` | Dental processing mode must be B or R | 627 |
| `L958` | Pharmacy processing mode must be B or R | 627 |

> All 4 error codes fire simultaneously on **each of the same 627 records**. Total error instances: 2,508 across 627 physical records.

### Root Cause: CODE BUG

**Record type involved:** `2449310138` (ESC Patient Exception / COB Patient Record)

**What is happening:**

The ETL is generating records of type `2449310138` for CobUpdate events. These records have a different fixed-width field layout than the standard `2049310138` (Client Cover) and `2249310138` (Patient/Member) record types. The current ETL configuration is incorrectly populating the `2449` record fields, placing the transaction action code `U` in field positions that ESC expects to contain:

- A valid **Proc Code** (drug identification/procedure code) — ESC rejects `U` → L771
- A valid **Proc Code Source** (source authority for the proc code) — ESC rejects `U` → L772
- A dental **processing mode** of `B` or `R` — ESC rejects `U` → L957
- A pharmacy **processing mode** of `B` or `R` — ESC rejects `U` → L958

**Evidence from output file** (`esc_eligibility_20260421_230608.txt`):

```
2449310138             2005449        102U202604219999999940        0000     483600    N0000000000000...
                                                              ^                                     ^
                                                              pos 41: 'U' (Proc Code field)        pos 219: 'U' (Processing Mode field)
```

The `U` at position 41 is the transaction action code being written into what the `2449` record spec defines as the Proc Code field. The `U` at position 219 lands in the dental/pharmacy processing mode field.

**Comparison:** The `2049` (Client Cover) record correctly places `U` at position 38 as the action code, with the proc code and processing mode fields in different positions (the `2449` format shifts or redefines these offsets).

**First occurrence:** This is the **first time** `2449` records appeared in the output (run 4938800). Prior runs had no CobUpdate events that required Patient Exception records, so this bug was not previously triggered.

**Where the bug lives:**

The field layout for `2449310138` records is defined in the YAML config loaded by:
```
src/CoverGo.ETL.Application/EscEligibility/Processing/Config/ConfigLoader.cs
```
Config path: `Base/Mapping/` (individual `.yml` files per record type, stored in the config bucket at `esc-eligibility/config/Base/Mapping/`).

The `EventRecordTypeMapping` config (loaded from `Base/Rules/event_record_type_mapping.yml` or `Extensions/{partnerId}/Rules/event_record_type_mapping.yml`) controls which record rules fire for `CobUpdate` events, including whether `2449` records are generated.

**Proposed Fix:**

1. **Identify the `2449310138` record type YAML definition** in the config bucket and review each field's `path`, `default_value`, and `transform`.
2. **Correct the Proc Code field** (approx. position 40-43 in the 360-char record): it should contain a valid drug/procedure code from the COB data, not the action code `U`. If this field is not applicable for this record type, it should be space-filled.
3. **Correct the Dental Processing Mode field** (approx. position 219): this must be `B` (Basic — submit and receive) or `R` (Receive only) depending on the plan configuration. The action code `U` must not populate this field. Add a `default_value: "B"` or derive from COB coverage type.
4. **Correct the Pharmacy Processing Mode field**: same fix as dental processing mode.
5. **Verify the Proc Code Source field** (adjacent to Proc Code): must contain a valid source identifier, not `U`.

**Impact:**

- 627 records rejected across 4 ESC customer IDs in this run
- All COB-bearing policies generating Patient Exception records will continue to fail until fixed
- First appeared in run 4938800 (2026-04-22); **no prior runs affected**
- 4 policies: P02441 (Elijah Foster), P02444 (Lily Stewart), P02449 (Harper Mitchell), P02465 (Jane Austen)

**Affected Policies (from JSONL source):**

| Policy | ESC ID | Client Name | Event Type | COB Insurer | COB Coverage Types |
|---|---|---|---|---|---|
| P02441 | 2005449 | Elijah Foster | CobUpdate | FaithLife Financial | health, vision, drug, dental |
| P02444 | 2005460 | Lily Stewart | CobUpdate | BMO Insurance | health, drug |
| P02449 | 2005478 | Harper Mitchell | CobUpdate | BMO Insurance | dental, vision, travel |
| P02465 | 2005529 | Jane Austen | NewPolicy | (personal plan) | health, dental, drug, travel, vision, HSA |

---

## Error Group 2: L925 — Pharmacy Effective Date Greater Than Pharmacy Termination Date

### Error Code

| Code | Description | Count |
|---|---|---|
| `L925` | Pharm eff date greater than pharm term date | 7 |

### Root Cause: DATA ISSUE

**What is happening:**

For ESC Customer 2005497 (Policy P02457, Policyholder: Layla2 Petersons), the ETL wrote a pharmacy effective date of `20260421` that is **one day after** the pharmacy termination date `20260420`. ESC's validation rule L925 rejects any record where the pharmacy effective date > term date.

**Records affected (from HBM run 4938800):**

- Record 9: Client Cover (type 2049), rec 9 and 30 — the group-level records
- Records 123–127: Patient records for family members (PETERSONS LAYLA2, D3, D2, D1)

**Source data analysis (JSONL):**

Policy P02457 is a CobUpdate event. The policy itself has `startDate: 2026-04-21`. The COB on this policy has `effectiveDateFrom: 2026-01-01` (Assumption Life, Master COB). The policyholder (internalCode 2005497, Layla2 Petersons, DOB 1954-05-15) and three dependents (D1, D2, D3) are all included.

The dates written to ESC:
- Pharmacy effective date: `20260421` (policy start date)
- Pharmacy term date: `20260420` (one day before — likely computed from the COB `effectiveDateFrom` minus one day, or from a prior period end date)

**Root Cause:**

The pharmacy termination date is being generated from a formula or lookup that is producing a date **one day before** the pharmacy effective date. This suggests one of:

1. The pharmacy term date is being set to `policy.startDate - 1 day` (the day before the policy started) when it should be `policy.endDate` or a far-future date like `99999999`
2. The COB `effectiveDateTo` is null (no end date set), and the ETL's fallback for a null term date is computing `effectiveDate - 1 day` rather than defaulting to `99999999`
3. A date ordering issue where eff and term dates are swapped in the field mapping

**Evidence:** In the JSONL, the COB has `effectiveDateTo: null` — no termination date. The policy `startDate` is `2026-04-21`. The `20260420` term date appears to be `startDate - 1`, suggesting the ETL is using the policy start date minus 1 as the "prior coverage end" date for the pharmacy term field.

**Data Fix Required:**

| Field | Policy | ESC ID | CoverGo Policy | Client Name | Issue | Current Value | Expected Value |
|---|---|---|---|---|---|---|---|
| Pharmacy eff date / term date | P02457 | 2005497 | P02457 | Layla2 Petersons | Pharm eff > term | eff=20260421, term=20260420 | eff=20260421, term=99999999 (or policy end date) |

**Affected Records:** 7 records — 2 Client Cover (recs 9, 30) + 5 patient records (recs 123, 124, 125, 126, 127) for members: Layla2 Petersons (ESC 2005497), D3 Petersons (ESC 2005502), D2 Petersons (ESC 2005503), D1 Petersons (ESC 2005504), and one additional.

**Source JSONL:** `run_20260422_144002_20260422/s3-esc-jsonl-files/20260422/CobUpdate_20260420_010510.jsonl`

**To resolve:** Correct the pharmacy term date logic. For policies with no COB end date, the pharmacy term date field in the ESC output should default to `99999999` (far-future). Review the date field mapping in the `2049` record type YAML definition for the pharmacy termination date field.

**ETL Code to Review:**

- `src/CoverGo.ETL.Application/EscEligibility/Processing/Records/RecordProcessor.cs` — `ApplyCommonFieldRules` (DateFormat rule application)
- Config YAML for record type `2049310138`, field: pharmacy_term_date
- `GetDentalEffectiveDateFunction.cs` may be analogous — check if a similar function exists for pharmacy dates

**Impact:** 7 records in run 4938800; same error pattern appeared in run 4937700 (2 records) and runs 4938100/4938200 (1 record each). This is a recurring data-driven issue on CobUpdate events for policies with active COBs starting on or near the policy start date.

---

## Error Group 3: L932 — Invalid SAS

### Error Code

| Code | Description | Count |
|---|---|---|
| `L932` | Invalid SAS | 5 |

### Root Cause: DATA ISSUE

**What is happening:**

ESC error L932 fires when a record's Group SAS (GSAS) code is empty or does not match any recognized SAS code in ESC's reference table. Two policies triggered this error:

**Policy P02399 / ESC 2005343 — Caleb Davis:**
- Event type: CancelledPolicy (`CancelledPolicy_20260421_060559.jsonl`)
- The GSAS field in the generated record (HBM rec 32) shows no GSAS (the field area at positions 10-24 is blank)
- Policy P02399 has `startDate: 2026-04-20` and was subsequently cancelled
- ESC customer ID: 2005343

**Policy P02445 / ESC 2005473 — James Johnson:**
- Event type: CobUpdate (`CobUpdate_20260420_000603.jsonl`)
- HBM records 44, 92, 93, 94 — no GSAS in the output records
- Policy P02445 has `startDate: 2026-04-21`, COB present (personal plan, from 2026-02-02, coverageTypes: health/dental/drug/travel/vision/HSA)
- ESC customer IDs: 2005473 (James Johnson, employee) and 2005476 (Dep1 KId, dependent)

**Root Cause:**

The GSAS (Group SAS) code is required by ESC to identify the plan division/subgroup. When the policy's tier or division code cannot be mapped to a valid GSAS value, the ETL either:
1. Leaves the GSAS field blank (empty string / spaces), or
2. Generates a GSAS code not in ESC's lookup table

L932 is the **most persistent error** in the system — present in 34 of 38 parsed runs. The underlying cause is that some policies either:
- Are created in CoverGo without a matching product/tier combination that maps to a recognized ESC GSAS code
- Have a GSAS lookup that falls back to empty when the `healthCoverage`/`drugCoverage`/`dentalCoverage` tier combination has no entry in the GSAS lookup table

**Data Fix Required:**

| Policy | ESC ID | CoverGo Policy | Client Name | Event Type | Source File | Issue | Fix |
|---|---|---|---|---|---|---|---|
| P02399 | 2005343 | P02399 | Caleb Davis | CancelledPolicy | `CancelledPolicy_20260421_060559.jsonl` | No GSAS code | Assign valid GSAS in CoverGo tier config |
| P02445 | 2005473 | P02445 | James Johnson | CobUpdate | `CobUpdate_20260420_000603.jsonl` | No GSAS code | Assign valid GSAS in CoverGo tier config |

**ETL Code to Review:**

- Config lookup YAML: `Extensions/{partnerId}/Lookups/gsas_lookup.yml` (or equivalent) — verify that all tier combinations (healthCoverage × drugCoverage × dentalCoverage) have valid GSAS entries
- `src/CoverGo.ETL.Application/EscEligibility/Processing/Expression/Functions/AutoCompositeKeyLookupFunction.cs` — this likely drives GSAS resolution; if no key match, returns empty
- `src/CoverGo.ETL.Application/EscEligibility/Processing/Lookups/EscLookupResolver.cs` — `ResolveComposite` fallback behavior

**Impact:** 5 records in run 4938800; L932 is the **most persistent error across all runs** (34/38 runs affected). The count per run ranges from 1 to 46. This indicates a structural gap in the GSAS lookup table coverage for all possible tier combinations.

---

## Error Group 4: L924 + E924 — Cannot Insert Cardholder with Non-Cardholder Dependent ID

### Error Codes

| Code | Description | Count |
|---|---|---|
| `L924` | Cannot insert cardholder with non-cardholder dependent ID | 2 |
| `E924` | Missing / unknown health error code | 2 |

### Root Cause: DATA ISSUE

**What is happening:**

ESC error L924 fires on the pharmacy/dental file when a record attempts to insert a primary cardholder using an ID that ESC's database already associates with a dependent. ESC error E924 fires on the health (EHC) file for the same conflict — the health record for the same individual cannot be inserted because the cardholder ID is already used by a dependent.

Both errors fire in pairs: L924 on the dental/pharma record (rec type `2049310138`) and E924 on the health record (rec types `3049310138` / `3249310138`).

**Affected records:**

**ESC 2005540 — Ainhoa Wood (Policy P02470, Daniel Wood):**
- HBM rec 168: `L924` — Client Cover record (2049310138), GSAS D1P1, Customer 2005540
- HBM rec 347: `E924` — Health record (3049310138/HEALTH3), Customer 2005540
- From JSONL: Ainhoa Wood, DOB 2001-02-15, gender=male, memberType=dependent, startDate=2026-04-22
- The policy P02470 also has members: Daniel Wood (employee, internalCode 2005540 is Ainhoa's code — **the employee has internalCode 2005540 but Daniel Wood himself is the policyholder**)

Wait — reviewing more carefully: Daniel Wood is the policyholder with `internalCode 2005540` as the **employee member**. Ainhoa Wood is a dependent. The L924 fires on a record with customer ID `2005540` — this is the employee's internal code. If ESC already has a dependent record for this ID (from a prior run or another policy), attempting to insert a new cardholder record with the same ID fails.

**ESC 2005547 — Gabriel Hall / Bella Hall (Policy P02473):**
- HBM rec 176: `L924` — Client Cover record, GSAS D1P1, Customer 2005547, member HALL BELLA (DOB 20030903F, eff 20260403)
- HBM rec 355: `E924` — Health record, Customer 2005547, HALL BELLA
- From JSONL: Gabriel Hall is the policyholder (internalCode 2005547, DOB 2001-01-13, female, employee, startDate 2026-04-03); Bella Hall is a dependent (internalCode 2005548, DOB 2003-09-03, female)
- **Note:** The HBM error says "HALL BELLA" at ESC customer 2005547. This suggests the ETL is writing Bella Hall's record with Gabriel Hall's customer ID (2005547 = cardholder) when Bella is a dependent — OR Gabriel Hall's record was previously loaded as a dependent of another policy, and now attempting to create her as a cardholder fails.

**Data Fix Required:**

| Policy | ESC ID | CoverGo Policy | Client Name | Event Type | Source File | Issue |
|---|---|---|---|---|---|---|
| P02470 | 2005540 | P02470 | Daniel Wood / Ainhoa Wood | CobUpdate | `CobUpdate_20260421_003605.jsonl` | Member ID conflict: cardholder ID 2005540 already registered as dependent in ESC |
| P02473 | 2005547 | P02473 | Gabriel Hall / Bella Hall | NewPolicy | `NewPolicy_20260421_000601.jsonl` | Member ID conflict: cardholder ID 2005547 already registered as dependent in ESC |

**Recommended Investigation:**

1. Query ESC's database (or request ESC to confirm): what role does ID `2005540` currently hold in their system? Is it a cardholder or dependent?
2. Same for `2005547`: query ESC for current role.
3. Check if these internal codes were previously used in a different policy context (e.g., a prior cancelled policy where the same individual was a dependent).
4. The ETL assigns `internalCode` from CoverGo as the ESC customer ID. If a CoverGo `internalCode` was recycled or previously appeared under a different membership type, ESC will reject the conflicting insert.

**ETL Code to Review:**

- `src/CoverGo.ETL.Application/EscEligibility/Processing/Expression/Functions/GetPatientCodeFunction.cs` — determines how patient/cardholder codes are assigned in the output records
- Config YAML for record type `2049310138`, field: `customer_id` or `patient_id` — verify the correct `internalCode` is being used as the ESC customer identifier

**Impact:** 2 records (L924) + 2 records (E924) in run 4938800. Same pattern in run 4937700 (L924×2, E924×2) and runs 4937200, 4937300, 4938100, 4938200 (E924×3, L924×1 each). This is a recurring issue on new policies or COB updates where CoverGo `internalCode` values conflict with ESC's existing dependent/cardholder role assignments.

---

## Summary: Prioritised Action List

| Priority | Error | Type | Action | Owner |
|---|---|---|---|---|
| 1 — IMMEDIATE | L771/L772/L957/L958 | Code Bug | Fix `2449310138` record type YAML config: correct Proc Code, Proc Code Source, Dental Mode, Pharmacy Mode fields | ETL Dev |
| 2 — HIGH | L932 | Data Issue (systemic) | Expand GSAS lookup table to cover all tier combinations; audit policies with empty GSAS | Operations + ETL Config |
| 3 — MEDIUM | L925 | Data Issue | Fix pharmacy term date logic for CobUpdate: default to `99999999` when COB has no end date | ETL Dev / Config |
| 4 — MEDIUM | L924 / E924 | Data Issue | Investigate ESC database for conflicting member role IDs (2005540, 2005547); coordinate with ESC to correct | Operations + ESC Support |

---

## Appendix: ESC ID to CoverGo Policy Mapping (Run 4938800)

| ESC Customer ID | CoverGo Policy | Policyholder | Event Type |
|---|---|---|---|
| 2005497 | P02457 | Layla2 Petersons | CobUpdate |
| 2005343 | P02399 | Caleb Davis | CancelledPolicy |
| 2005473 | P02445 | James Johnson | CobUpdate |
| 2005540 | P02470 | Daniel Wood | CobUpdate |
| 2005547 | P02473 | Gabriel Hall | NewPolicy |
| 2005449 | P02441 | Elijah Foster | CobUpdate |
| 2005460 | P02444 | Lily Stewart | CobUpdate |
| 2005478 | P02449 | Harper Mitchell | CobUpdate |
| 2005529 | P02465 | Jane Austen | NewPolicy |

> **ID Mapping Pattern:** ESC Customer ID `200XXXX` maps to CoverGo issuerNumber `P0YYYY` where the last digits correspond (e.g., ESC 2005449 → P02441, ESC 2005460 → P02444). The ESC `internalCode` field in CoverGo stores the exact ESC numeric ID (e.g., `"internalCode": "2005449"`).

---

## Appendix: Key ETL Code File Paths

| File | Relevance |
|---|---|
| `src/CoverGo.ETL.Application/EscEligibility/Processing/Config/ConfigLoader.cs` | Loads all record type YAML configs from bucket; config path: `esc-eligibility/config/Base/Mapping/` |
| `src/CoverGo.ETL.Application/EscEligibility/Processing/Config/Models/RecordTypeDefinition.cs` | Model for individual record type YAML (contains `record_type`, `fields`, `lookups`) |
| `src/CoverGo.ETL.Application/EscEligibility/Processing/Config/Models/EventRecordTypeMapping.cs` | Defines which record rules fire per event type (CobUpdate, NewPolicy, etc.) |
| `src/CoverGo.ETL.Application/EscEligibility/Processing/Records/RecordProcessor.cs` | Core record processing engine; applies field rules, transforms, lookups |
| `src/CoverGo.ETL.Application/EscEligibility/Processing/Expression/Functions/GetPatientCodeFunction.cs` | Generates patient ordinal codes (may affect L924) |
| `src/CoverGo.ETL.Application/EscEligibility/Processing/Expression/Functions/GetCobStatusCodeFunction.cs` | Resolves COB status codes from member COB data |
| `src/CoverGo.ETL.Application/EscEligibility/Processing/Expression/Functions/GetDentalEffectiveDateFunction.cs` | Computes dental effective date; analogous logic needed for pharmacy dates |
| `src/CoverGo.ETL.Application/EscEligibility/Intake/DataFetching/MemberMovement/CobUpdateDataFetcher.cs` | Fetches COB update data and builds the JSONL records that feed the 2449 processing |
| `src/CoverGo.ETL.Application/EscEligibility/Processing/Lookups/EscLookupResolver.cs` | Resolves composite lookups including GSAS (L932 root) |

---

*RCA Report generated: 2026-04-23 | Based on HBM run 4938800, JSONL source data, and ETL code analysis*
