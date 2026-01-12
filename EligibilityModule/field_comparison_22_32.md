# Field Comparison: Record Type 22 vs Record Type 32

| # | Field Key | Field Name | Record 22 | Record 32 |
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
| 15 | `dental_enrolment_date` | Dental enrolment date | ✓ | |
| 16 | `ehc_enrolment_date` | EHC enrolment date | | ✓ |
| 17 | `filler_general` | Filler | ✓ | ✓ |
| 18 | `pharmacy_processing_mode` | Pharmacy Processing Mode | ✓ | |
| 19 | `drug_effective_date` | Drug Effective Date | ✓ | |
| 20 | `drug_termination_date` | Drug Termination Date | ✓ | |
| 21 | `pharmacy_plan_number` | Plan Number | ✓ | |
| 22 | `pharmacy_patient_benefit_override_code` | Patient Benefit Override Code | ✓ | |
| 23 | `pharmacy_cob_status` | COB Status | ✓ | |
| 24 | `pharmacy_suspend_flag` | Suspend Flag | ✓ | |
| 25 | `exception_flag` | Exception flag | ✓ | |
| 26 | `enrolment_date` | Enrolment date | ✓ | |
| 27 | `cob_rule` | COB Rule | ✓ | |
| 28 | `bypass_ldf_logic` | Bypass LDF Logic | ✓ | |
| 29 | `bypass_methadone_ldf_logic` | Bypass Methadone LDF logic | ✓ | |
| 30 | `filler_pharmacy_1` | Filler | ✓ | |
| 31 | `sdc_program_ind` | SDC Program Ind. | ✓ | |
| 32 | `bypass_oms_logic` | Bypass OMS Logic | ✓ | |
| 33 | `disease_program_grace_period` | Disease Program Grace Period | ✓ | |
| 34 | `mandatory_generic_indicator` | Mandatory Generic Indicator | ✓ | |
| 35 | `filler_pharmacy_2` | Filler | ✓ | |
| 36 | `dental_processing_mode` | Dental Processing Mode | ✓ | |
| 37 | `dental_record_effective_date` | Dental Record Effective Date | ✓ | |
| 38 | `dental_record_expiry_date` | Dental Record Expiry Date | ✓ | |
| 39 | `dental_plan_number` | Plan Number | ✓ | |
| 40 | `dental_patient_benefit_override_code` | Patient Benefit Override Code | ✓ | |
| 41 | `dental_cob_status` | COB Status | ✓ | |
| 42 | `dental_suspend_flag` | Suspend Flag | ✓ | |
| 43 | `late_entrant_indicator` | Late entrant indicator | ✓ | ✓ |
| 44 | `dental_cost_plus` | Cost Plus | ✓ | |
| 45 | `dental_private_cob_rule_code` | Private COB Rule Code | ✓ | |
| 46 | `dental_edi_threshold_amount` | EDI Threshold Amount | ✓ | |
| 47 | `filler_dental` | Filler | ✓ | |
| 48 | `ehc_processing_mode` | EHC Processing Mode | | ✓ |
| 49 | `ehc_record_effective_date` | EHC Record Effective Date | | ✓ |
| 50 | `ehc_record_expiry_date` | EHC Record Expiry Date | | ✓ |
| 51 | `ehc_plan_number` | Plan Number | | ✓ |
| 52 | `ehc_patient_benefit_override_code` | Patient Benefit Override Code | | ✓ |
| 53 | `ehc_cob_status` | COB Status | | ✓ |
| 54 | `ehc_suspend_flag` | Suspend Flag | | ✓ |
| 55 | `ehc_cost_plus` | Cost Plus | | ✓ |
| 56 | `ehc_private_cob_rule_code` | Private COB Rule Code | | ✓ |
| 57 | `ehc_edi_threshold_amount` | EDI Threshold Amount | | ✓ |
| 58 | `filler_ehc` | Filler | | ✓ |

## Summary

- **Fields in both Record 22 and Record 32:** 17 fields (common identification and general section fields)
- **Fields only in Record 22:** 30 fields (pharmacy and dental sections)
- **Fields only in Record 32:** 11 fields (EHC section)
- **Total unique fields:** 58 fields

## Common Fields (17)
Both record types share the following identification and general fields:
1. Record Type
2. Carrier ID
3. Group Number
4. SAS
5. Client ID
6. Current Patient Code
7. General Processing Mode
8. Relationship Code
9. Full Patient Last Name
10. Full Patient First Name/Initial
11. Patient Middle Initial
12. Patient Date of Birth
13. Patient Sex
14. New Patient Code
15. Filler (general section)
16. Late entrant indicator (present in both, but in different sections)

**Note:** Record 22 has `dental_enrolment_date` while Record 32 has `ehc_enrolment_date` - these are similar but different fields.

## Record 22 Specific Fields (30)
Record 22 includes Pharmacy and Dental sections with 30 additional fields:
- **Pharmacy Section (18 fields):** Processing mode, effective dates, plan number, benefit override, COB status, suspend flag, exception flag, enrolment date, COB rule, bypass flags, SDC program, disease program grace period, mandatory generic indicator, and filler fields
- **Dental Section (12 fields):** Processing mode, effective/expiry dates, plan number, benefit override, COB status, suspend flag, late entrant indicator, cost plus, private COB rule code, EDI threshold amount, and filler

## Record 32 Specific Fields (11)
Record 32 includes EHC (Extended Health Care) section with 11 additional fields:
- EHC enrolment date
- EHC processing mode
- EHC record effective date
- EHC record expiry date
- EHC plan number
- EHC patient benefit override code
- EHC COB status
- EHC suspend flag
- EHC cost plus
- EHC private COB rule code
- EHC EDI threshold amount
- EHC filler

