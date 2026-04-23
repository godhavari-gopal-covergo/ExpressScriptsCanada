# ESC Eligibility Error Dashboard — Run Date 2026-04-22

> **Run Reference:** HBM Run ID 4938800 | ESC Processing Date 2026-04-22 | Run Time 19:46:03
> Program: `/prod/bin/elig` Version 6.03 | FeedLib Ver. 1.29 | Input: `hbm_elig` | Mode: Normal

---

## Header: Run Summary

| Field | Value |
|---|---|
| HBM File | `hbm_er4938800_20260422_2205_388` |
| Run Date | 2026-04-22 |
| Run Time | 19:46:03 |
| Program Version | Version 6.03 |
| FeedLib Version | FeedLib Ver. 1.29 |
| Total Records Processed | 1,029 |
| Total Records with Errors | **8** (unique error records) |
| Total Error Instances | **2,897** (L771×627 + L772×627 + L957×627 + L958×627 + L925×7 + L932×5 + L924×2 + E924×2) |
| **Overall Success Rate** | **99.2%** (1,021 / 1,029 records clean) |

---

## Section 1 — Error Summary by Code

| Error Code | Description | Count | Affected ESC IDs | Affected Policies | Severity | Status |
|---|---|---|---|---|---|---|
| `L771` | Invalid Proc Code value | 627 | 2005449, 2005460, 2005478, 2005529 | P02441, P02444, P02449, P02465 | **HIGH** | Code Bug |
| `L772` | Invalid Proc Code Source value | 627 | 2005449, 2005460, 2005478, 2005529 | P02441, P02444, P02449, P02465 | **HIGH** | Code Bug |
| `L957` | Dental processing mode must be B or R | 627 | 2005449, 2005460, 2005478, 2005529 | P02441, P02444, P02449, P02465 | **HIGH** | Code Bug |
| `L958` | Pharmacy processing mode must be B or R | 627 | 2005449, 2005460, 2005478, 2005529 | P02441, P02444, P02449, P02465 | **HIGH** | Code Bug |
| `L925` | Pharm eff date > pharm term date | 7 | 2005497 | P02457 | MEDIUM | Data Issue |
| `L932` | Invalid SAS | 5 | 2005343, 2005473 | P02399, P02445 | MEDIUM | Data Issue |
| `L924` | Cannot insert cardholder with non-cardholder dependent ID | 2 | 2005540, 2005547 | P02470, P02473 | MEDIUM | Data Issue |
| `E924` | Missing/unknown health error code | 2 | 2005540, 2005547 | P02470, P02473 | MEDIUM | Data Issue |

> Note: L771, L772, L957, L958 all fire on the **same 627 records** (record type `2449310138` — Patient Exception). These are 4 error codes on each of the 627 records, not 4 separate sets of records.

---

## Section 2 — Error Trend (Last 8 Runs)

| Run ID | Run Date | Records | Error Recs | L932 | L925 | L924 | E924 | L819/L821 | L870/L871 | L771-L958 (COB) | Other |
|---|---|---|---|---|---|---|---|---|---|---|---|
| 4938800 | 2026-04-22 | 1,029 | 8 | 5 | 7 | 2 | 2 | 0 | 0 | **627×4** | 0 |
| 4938600 | 2026-04-21 | 350 | 2 | 12 | 0 | 0 | 0 | 0 | 0 | 0 | L916×1 |
| 4938500 | 2026-04-21 | 141 | 2 | 6 | 0 | 0 | 0 | 0 | 0 | 0 | L916×1 |
| 4938200 | 2026-04-18 | 92 | 4 | 8 | 1 | 1 | 3 | 0 | 0 | 0 | 0 |
| 4938100 | 2026-04-17 | 92 | 4 | 8 | 1 | 1 | 3 | 0 | 0 | 0 | 0 |
| 4938000 | 2026-04-16 | 216 | 4 | 10 | 0 | 0 | 0 | 0 | L871×1 | 0 | E426, L426 |
| 4937900 | 2026-04-16 | 30 | 1 | 3 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| 4937800 | 2026-04-15 | 190 | 5 | 26 | 0 | 0 | 0 | L819×1, L821×1 | L870×1, L871×1 | 0 | 0 |

> **Key Insight:** L771/L772/L957/L958 errors **first appeared** in run 4938800 (2026-04-22). This is a new code bug introduced when COB (coordination of benefits) data was present in policies generating Patient Exception records. All prior runs had zero occurrences of these error codes.

> **L932 trend:** Persistent across all runs — reflects ongoing new policies with missing or unrecognized GSAS codes. Count varies with policy volume.

---

## Section 3 — Affected Policies Summary

| Policy (CoverGo) | ESC Customer ID | Policyholder Name | Error Code(s) | Event Type | Source JSONL | Status |
|---|---|---|---|---|---|---|
| P02457 | 2005497 | Layla2 Petersons | `L925` | CobUpdate | `CobUpdate_20260420_*.jsonl` | **Pharmacy date issue — data correction required** |
| P02399 | 2005343 | Caleb Davis | `L932` | CancelledPolicy | `CancelledPolicy_20260421_060559.jsonl` | **Missing GSAS code on cancellation record** |
| P02445 | 2005473 | James Johnson | `L932` | CobUpdate | `CobUpdate_20260420_000603.jsonl` | **Missing GSAS code — COB update record** |
| P02470 | 2005540 | Daniel Wood | `L924`, `E924` | CobUpdate | `CobUpdate_20260421_003605.jsonl` | **Dependent ID conflict — member Ainhoa Wood** |
| P02473 | 2005547 | Gabriel Hall | `L924`, `E924` | NewPolicy | `NewPolicy_20260421_000601.jsonl` | **Dependent ID conflict — member Bella Hall** |
| P02441 | 2005449 | Elijah Foster | `L771`, `L772`, `L957`, `L958` | CobUpdate | `CobUpdate_20260420_000603.jsonl` | **Code bug: 2449 Patient Exception record format error** |
| P02444 | 2005460 | Lily Stewart | `L771`, `L772`, `L957`, `L958` | CobUpdate | `CobUpdate_20260420_003509.jsonl` | **Code bug: 2449 Patient Exception record format error** |
| P02449 | 2005478 | Harper Mitchell | `L771`, `L772`, `L957`, `L958` | CobUpdate | `CobUpdate_20260420_003509.jsonl` | **Code bug: 2449 Patient Exception record format error** |
| P02465 | 2005529 | Jane Austen | `L771`, `L772`, `L957`, `L958` | NewPolicy | `NewPolicy_20260421_000601.jsonl` | **Code bug: 2449 Patient Exception record format error** |

---

## Section 4 — Overall Health Metrics

| Metric | Value |
|---|---|
| Records Processed (run 4938800) | 1,029 |
| Records with Errors | 8 |
| **Overall Success Rate** | **99.2%** |
| Unique Policies Affected | 9 |
| Error Types | 8 distinct error codes |
| **Most Impactful Error** | L771/L772/L957/L958 (627 instances each — code bug in 2449 Patient Exception record generation) |
| New Error Types This Run | L771, L772, L957, L958 (first occurrence across all 38 parsed runs) |
| Persistent Error Types | L932 (present in 34 of 38 runs) |
| Error Codes Resolved vs Prior Run | L916 (was in runs 4938500, 4938600; gone in 4938800) |

### Historical Error Volume Trend

```
Run    Date        Records  Error Recs
4938800 2026-04-22   1,029       8   ← L771/L772/L957/L958 NEW (code bug)
4938600 2026-04-21     350       2
4938500 2026-04-21     141       2
4938200 2026-04-18      92       4
4938100 2026-04-17      92       4
4938000 2026-04-16     216       4
4937900 2026-04-16      30       1
4937800 2026-04-15     190       5
```

### Action Required

1. **IMMEDIATE — Code Fix:** The 2449 (Patient Exception) record type is generating invalid `U` characters in the Proc Code and processing mode fields. The ETL YAML config for record type `2449310138` needs to be corrected (see RCA Report). This affects **all COB update records** going forward until fixed.
2. **DATA — L925:** Policy P02457 (Layla2 Petersons) has pharmacy effective date 2026-04-21 > term date 2026-04-20. Verify and correct dates in CoverGo.
3. **DATA — L932:** Policies P02399 (Caleb Davis) and P02445 (James Johnson) have no GSAS code on their records. Assign correct GSAS/SAS code in CoverGo.
4. **DATA — L924/E924:** Policies P02470 (Daniel Wood) and P02473 (Gabriel Hall) have dependent members (Ainhoa Wood, Bella Hall) being inserted with cardholder-type IDs. Investigate member relationship mapping.

---

*Dashboard generated: 2026-04-23 | Parse script ran across 38 HBM runs (20260401–20260422)*
