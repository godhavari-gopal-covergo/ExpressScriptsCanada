# Field Comparison: Record Type 30 vs Record Type 35

| # | Field Key | Field Name | Record 30 | Record 35 |
|---|-----------|------------|-----------|-----------|
| 1 | `record_type` | Record Type | ✓ | ✓ |
| 2 | `carrier_id` | Carrier ID | ✓ | ✓ |
| 3 | `group_number` | Group Number | ✓ | ✓ |
| 4 | `sas` | SAS | ✓ | ✓ |
| 5 | `client_id` | Client ID | ✓ | ✓ |
| 6 | `general_processing_mode` | General Processing Mode | ✓ | ✓ |
| 7 | `alternate_identification` | Alternate Identification | ✓ | ✓ |
| 8 | `client_language_code` | Client Language Flag/Code | ✓ | ✓ |
| 9 | `client_province_code` | Client Province Code | ✓ | ✓ |
| 10 | `eft_account_number` | EFT Account # | ✓ | ✓ |
| 11 | `eft_route_code` | EFT Route code | ✓ | ✓ |
| 12 | `eft_effective_date` | EFT Effective Dt | ✓ | ✓ |
| 13 | `eft_termination_date` | EFT Termination date | ✓ | ✓ |
| 14 | `lookup_override_code` | Lookup override code | ✓ | ✓ |
| 15 | `employment_enrolment_date` | Employment enrolment date | ✓ | ✓ |
| 16 | `filler_general` | Filler | ✓ | ✓ |
| 17 | `ehc_processing_mode` | EHC Processing Mode | ✓ | ✓ |
| 18 | `carrier_ehc_field` | Carrier EHC Field | ✓ | ✓ |
| 19 | `ehc_record_effective_date` | EHC Record Effective Date | ✓ | ✓ |
| 20 | `ehc_record_expiry_date` | EHC Record Expiry Date | ✓ | ✓ |
| 21 | `ehc_plan_number` | Plan Number | ✓ | ✓ |
| 22 | `ehc_client_benefit_override_code` | Client Benefit Override Code | ✓ | ✓ |
| 23 | `ehc_private_cob_rule_number` | Private COB Rule Number | ✓ | ✓ |
| 24 | `ehc_max_dependant_age` | Max Dependant Age | ✓ | ✓ |
| 25 | `ehc_max_student_age` | Max Student Age | ✓ | ✓ |
| 26 | `ehc_general_code` | General Code | ✓ | ✓ |
| 27 | `ehc_suspend_flag` | Suspend Flag | ✓ | ✓ |
| 28 | `ehc_coverage_code` | Coverage Code | ✓ | ✓ |
| 29 | `ehc_cob_status_code` | COB Status Code | ✓ | ✓ |
| 30 | `ehc_cost_plus` | Cost Plus | ✓ | ✓ |
| 31 | `ehc_edi_threshold_amount` | EDI Threshold Amount | ✓ | ✓ |
| 32 | `filler_ehc` | Filler | ✓ | ✓ |

## Summary

- **Fields in both Record 30 and Record 35:** 32 fields (all fields are identical)
- **Fields only in Record 30:** 0 fields
- **Fields only in Record 35:** 0 fields
- **Total unique fields:** 32 fields

## Key Finding

**Record Types 30 and 35 have identical field structures.** All 32 fields are present in both record types.

## Difference Between Record Types 30 and 35

The only difference between these record types is the **`record_type` field value** and their **processing behavior**:

### Record Type 30
- **Record Type Value:** "30"
- **Usage:** Sent alone as part of the regular Update/Load Process
- **Processing:** Standard update/load processing

### Record Type 35
- **Record Type Value:** "35"
- **Usage:** Acts like a delete and add (used when client's complete history is re-sent)
- **Processing:** Complete replacement - deletes existing EHC client record and adds new one

## Field Structure

Both record types contain the same sections:

### Identification Section (5 fields)
1. Record Type
2. Carrier ID
3. Group Number
4. SAS
5. Client ID

### General Section (11 fields)
6. General Processing Mode
7. Alternate Identification
8. Client Language Flag/Code
9. Client Province Code
10. EFT Account #
11. EFT Route code
12. EFT Effective Dt
13. EFT Termination date
14. Lookup override code
15. Employment enrolment date
16. Filler (general section)

### EHC Section (16 fields)
17. EHC Processing Mode
18. Carrier EHC Field
19. EHC Record Effective Date
20. EHC Record Expiry Date
21. Plan Number
22. Client Benefit Override Code
23. Private COB Rule Number
24. Max Dependant Age
25. Max Student Age
26. General Code
27. Suspend Flag
28. Coverage Code
29. COB Status Code
30. Cost Plus
31. EDI Threshold Amount
32. Filler (EHC section)

## Conclusion

Record Types 30 and 35 are structurally identical. The choice between them depends on the processing requirement:
- Use **Record Type 30** for regular updates and incremental changes to EHC client records
- Use **Record Type 35** when you need to completely replace an EHC client's record (delete and add operation)

