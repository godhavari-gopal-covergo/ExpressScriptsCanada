# Field Comparison: Record Type 32 vs Record Type 37

| # | Field Key | Field Name | Record 32 | Record 37 |
|---|-----------|------------|-----------|-----------|
| 1 | `record_type` | Record Type | ✓ | ✓ |
| 2 | `carrier_id` | Carrier ID | ✓ | ✓ |
| 3 | `group_number` | Group Number | ✓ | ✓ |
| 4 | `sas` | SAS | ✓ | ✓ |
| 5 | `client_id` | Client ID | ✓ | ✓ |
| 6 | `current_patient_code` | Current Patient Code | ✓ | ✓ |
| 7 | `general_processing_mode` | General Processing Mode | ✓ | ✓ |
| 8 | `relationship_code` | Relationship Code | ✓ | ✓ |
| 9 | `patient_last_name` | Full Patient Last Name | ✓ | ✓ |
| 10 | `patient_first_name` | Full Patient First Name/Initial | ✓ | ✓ |
| 11 | `patient_middle_initial` | Patient Middle Initial | ✓ | ✓ |
| 12 | `patient_date_of_birth` | Patient Date of Birth | ✓ | ✓ |
| 13 | `patient_sex` | Patient Sex | ✓ | ✓ |
| 14 | `new_patient_code` | New Patient Code | ✓ | ✓ |
| 15 | `ehc_enrolment_date` | EHC enrolment date | ✓ | ✓ |
| 16 | `filler_general` | Filler | ✓ | ✓ |
| 17 | `ehc_processing_mode` | EHC Processing Mode | ✓ | ✓ |
| 18 | `ehc_record_effective_date` | EHC Record Effective Date | ✓ | ✓ |
| 19 | `ehc_record_expiry_date` | EHC Record Expiry Date | ✓ | ✓ |
| 20 | `ehc_plan_number` | Plan Number | ✓ | ✓ |
| 21 | `ehc_patient_benefit_override_code` | Patient Benefit Override Code | ✓ | ✓ |
| 22 | `ehc_cob_status` | COB Status | ✓ | ✓ |
| 23 | `ehc_suspend_flag` | Suspend Flag | ✓ | ✓ |
| 24 | `late_entrant_indicator` | Late entrant indicator | ✓ | ✓ |
| 25 | `ehc_cost_plus` | Cost Plus | ✓ | ✓ |
| 26 | `ehc_private_cob_rule_code` | Private COB Rule Code | ✓ | ✓ |
| 27 | `ehc_edi_threshold_amount` | EDI Threshold Amount | ✓ | ✓ |
| 28 | `filler_ehc` | Filler | ✓ | ✓ |

## Summary

- **Fields in both Record 32 and Record 37:** 28 fields (all fields are identical)
- **Fields only in Record 32:** 0 fields
- **Fields only in Record 37:** 0 fields
- **Total unique fields:** 28 fields

## Key Finding

**Record Types 32 and 37 have identical field structures.** All 28 fields are present in both record types.

## Difference Between Record Types 32 and 37

The only difference between these record types is the **`record_type` field value** and their **processing behavior**:

### Record Type 32
- **Record Type Value:** "32"
- **Usage:** Sent alone as part of the regular Update/Load Process
- **Processing:** Standard update/load processing

### Record Type 37
- **Record Type Value:** "37"
- **Usage:** Acts like a delete and add (used when patient's complete history is re-sent)
- **Processing:** Complete replacement - deletes existing EHC patient record and adds new one

## Field Structure

Both record types contain the same sections:

### Identification Section (6 fields)
1. Record Type
2. Carrier ID
3. Group Number
4. SAS
5. Client ID
6. Current Patient Code

### General Section (10 fields)
7. General Processing Mode
8. Relationship Code
9. Full Patient Last Name
10. Full Patient First Name/Initial
11. Patient Middle Initial
12. Patient Date of Birth
13. Patient Sex
14. New Patient Code
15. EHC enrolment date
16. Filler (general section)

### EHC Section (12 fields)
17. EHC Processing Mode
18. EHC Record Effective Date
19. EHC Record Expiry Date
20. Plan Number
21. Patient Benefit Override Code
22. COB Status
23. Suspend Flag
24. Late entrant indicator
25. Cost Plus
26. Private COB Rule Code
27. EDI Threshold Amount
28. Filler (EHC section)

## Conclusion

Record Types 32 and 37 are structurally identical. The choice between them depends on the processing requirement:
- Use **Record Type 32** for regular updates and incremental changes to EHC patient records
- Use **Record Type 37** when you need to completely replace an EHC patient's record (delete and add operation)

