# Field Comparison: Record Type 22 vs Record Type 27

| # | Field Key | Field Name | Record 22 | Record 27 |
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
| 15 | `dental_enrolment_date` | Dental enrolment date | ✓ | ✓ |
| 16 | `filler_general` | Filler | ✓ | ✓ |
| 17 | `pharmacy_processing_mode` | Pharmacy Processing Mode | ✓ | ✓ |
| 18 | `drug_effective_date` | Drug Effective Date | ✓ | ✓ |
| 19 | `drug_termination_date` | Drug Termination Date | ✓ | ✓ |
| 20 | `pharmacy_plan_number` | Plan Number | ✓ | ✓ |
| 21 | `pharmacy_patient_benefit_override_code` | Patient Benefit Override Code | ✓ | ✓ |
| 22 | `pharmacy_cob_status` | COB Status | ✓ | ✓ |
| 23 | `pharmacy_suspend_flag` | Suspend Flag | ✓ | ✓ |
| 24 | `exception_flag` | Exception flag | ✓ | ✓ |
| 25 | `enrolment_date` | Enrolment date | ✓ | ✓ |
| 26 | `cob_rule` | COB Rule | ✓ | ✓ |
| 27 | `bypass_ldf_logic` | Bypass LDF Logic | ✓ | ✓ |
| 28 | `bypass_methadone_ldf_logic` | Bypass Methadone LDF logic | ✓ | ✓ |
| 29 | `filler_pharmacy_1` | Filler | ✓ | ✓ |
| 30 | `sdc_program_ind` | SDC Program Ind. | ✓ | ✓ |
| 31 | `bypass_oms_logic` | Bypass OMS Logic | ✓ | ✓ |
| 32 | `disease_program_grace_period` | Disease Program Grace Period | ✓ | ✓ |
| 33 | `mandatory_generic_indicator` | Mandatory Generic Indicator | ✓ | ✓ |
| 34 | `filler_pharmacy_2` | Filler | ✓ | ✓ |
| 35 | `dental_processing_mode` | Dental Processing Mode | ✓ | ✓ |
| 36 | `dental_record_effective_date` | Dental Record Effective Date | ✓ | ✓ |
| 37 | `dental_record_expiry_date` | Dental Record Expiry Date | ✓ | ✓ |
| 38 | `dental_plan_number` | Plan Number | ✓ | ✓ |
| 39 | `dental_patient_benefit_override_code` | Patient Benefit Override Code | ✓ | ✓ |
| 40 | `dental_cob_status` | COB Status | ✓ | ✓ |
| 41 | `dental_suspend_flag` | Suspend Flag | ✓ | ✓ |
| 42 | `late_entrant_indicator` | Late entrant indicator | ✓ | ✓ |
| 43 | `dental_cost_plus` | Cost Plus | ✓ | ✓ |
| 44 | `dental_private_cob_rule_code` | Private COB Rule Code | ✓ | ✓ |
| 45 | `dental_edi_threshold_amount` | EDI Threshold Amount | ✓ | ✓ |
| 46 | `filler_dental` | Filler | ✓ | ✓ |

## Summary

- **Fields in both Record 22 and Record 27:** 46 fields (all fields are identical)
- **Fields only in Record 22:** 0 fields
- **Fields only in Record 27:** 0 fields
- **Total unique fields:** 46 fields

## Key Finding

**Record Types 22 and 27 have identical field structures.** All 46 fields are present in both record types.

## Difference Between Record Types 22 and 27

The only difference between these record types is the **`record_type` field value** and their **processing behavior**:

### Record Type 22
- **Record Type Value:** "22"
- **Usage:** Sent alone as part of the regular Update/Load Process
- **Processing:** Standard update/load processing

### Record Type 27
- **Record Type Value:** "27"
- **Usage:** Acts like a delete and add (used when patient's complete history is re-sent)
- **Processing:** Complete replacement - deletes existing patient record and adds new one

## Field Structure

Both record types contain the same sections:

### Identification Section (6 fields)
1. Record Type
2. Carrier ID
3. Group Number
4. SAS
5. Client ID
6. Current Patient Code

### General Section (9 fields)
7. General Processing Mode
8. Relationship Code
9. Full Patient Last Name
10. Full Patient First Name/Initial
11. Patient Middle Initial
12. Patient Date of Birth
13. Patient Sex
14. New Patient Code
15. Dental enrolment date
16. Filler (general section)

### Pharmacy Section (18 fields)
17. Pharmacy Processing Mode
18. Drug Effective Date
19. Drug Termination Date
20. Plan Number
21. Patient Benefit Override Code
22. COB Status
23. Suspend Flag
24. Exception flag
25. Enrolment date
26. COB Rule
27. Bypass LDF Logic
28. Bypass Methadone LDF logic
29. Filler (pharmacy section 1)
30. SDC Program Ind.
31. Bypass OMS Logic
32. Disease Program Grace Period
33. Mandatory Generic Indicator
34. Filler (pharmacy section 2)

### Dental Section (12 fields)
35. Dental Processing Mode
36. Dental Record Effective Date
37. Dental Record Expiry Date
38. Plan Number
39. Patient Benefit Override Code
40. COB Status
41. Suspend Flag
42. Late entrant indicator
43. Cost Plus
44. Private COB Rule Code
45. EDI Threshold Amount
46. Filler (dental section)

## Conclusion

Record Types 22 and 27 are structurally identical. The choice between them depends on the processing requirement:
- Use **Record Type 22** for regular updates and incremental changes
- Use **Record Type 27** when you need to completely replace a patient's record (delete and add operation)

