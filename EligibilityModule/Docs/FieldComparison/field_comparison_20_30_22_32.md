# Field Comparison: Record Types 20, 30, 22, and 32

This report compares fields across record types 20, 30, 22, and 32, maintaining the exact field sequence as defined in each record type's configuration file.

| # | Field Key | Field Name | 20 | 30 | 22 | 32 |
|---|-----------|------------|----|----|----|----|
| **IDENTIFICATION FIELDS** |
| 1 | `record_type` | Record Type | ✓ | ✓ | ✓ | ✓ |
| 2 | `carrier_id` | Carrier ID | ✓ | ✓ | ✓ | ✓ |
| 3 | `group_number` | Group Number | ✓ | ✓ | ✓ | ✓ |
| 4 | `sas` | SAS | ✓ | ✓ | ✓ | ✓ |
| 5 | `client_id` | Client ID | ✓ | ✓ | ✓ | ✓ |
| 6 | `current_patient_code` | Current Patient Code | | | ✓ | ✓ |
| **GENERAL SECTION FIELDS** |
| 7 | `general_processing_mode` | General Processing Mode | ✓ | ✓ | ✓ | ✓ |
| 8 | `alternate_identification` | Alternate Identification | ✓ | ✓ | | |
| 9 | `client_language_code` | Client Language Flag/Code | ✓ | ✓ | | |
| 10 | `client_province_code` | Client Province Code | ✓ | ✓ | | |
| 11 | `eft_account_number` | EFT Account # | ✓ | ✓ | | |
| 12 | `eft_route_code` | EFT Route code | ✓ | ✓ | | |
| 13 | `eft_effective_date` | EFT Effective Dt | ✓ | ✓ | | |
| 14 | `eft_termination_date` | EFT Termination date | ✓ | ✓ | | |
| 15 | `lookup_override_code` | Lookup override code | ✓ | ✓ | | |
| 16 | `employment_enrolment_date` | Employment enrolment date | ✓ | ✓ | | |
| 17 | `relationship_code` | Relationship Code | | | ✓ | ✓ |
| 18 | `patient_last_name` | Full Patient Last Name | | | ✓ | ✓ |
| 19 | `patient_first_name` | Full Patient First Name/Initial | | | ✓ | ✓ |
| 20 | `patient_middle_initial` | Patient Middle Initial | | | ✓ | ✓ |
| 21 | `patient_date_of_birth` | Patient Date of Birth | | | ✓ | ✓ |
| 22 | `patient_sex` | Patient Sex | | | ✓ | ✓ |
| 23 | `new_patient_code` | New Patient Code | | | ✓ | ✓ |
| 24 | `dental_enrolment_date` | Dental enrolment date | | | ✓ | |
| 25 | `ehc_enrolment_date` | EHC enrolment date | | | | ✓ |
| 26 | `filler_general` | Filler | ✓ | ✓ | ✓ | ✓ |
| **PHARMACY SECTION FIELDS** |
| 27 | `pharmacy_processing_mode` | Pharmacy Processing Mode | ✓ | | ✓ | |
| 28 | `carrier_pharmacy_field` | Carrier Pharmacy Field | ✓ | | | |
| 29 | `drug_effective_date` | Drug Effective Date | ✓ | | ✓ | |
| 30 | `drug_termination_date` | Drug Termination Date | ✓ | | ✓ | |
| 31 | `pharmacy_plan_number` | Plan Number | ✓ | | ✓ | |
| 32 | `pharmacy_client_benefit_override_code` | Client Benefit Override Code | ✓ | | | |
| 33 | `pharmacy_patient_benefit_override_code` | Patient Benefit Override Code | | | ✓ | |
| 34 | `dur_flag` | DUR Flag | ✓ | | | |
| 35 | `provincial_cob_rule_number` | Provincial COB Rule Number | ✓ | | | |
| 36 | `ramq_override_flag` | RAMQ Override Flag | ✓ | | | |
| 37 | `cutback_override_indicator` | Cutback override indicator | ✓ | | | |
| 38 | `mandatory_generic_override_indicator` | Mandatory Generic override indicator | ✓ | | | |
| 39 | `mandatory_generic_indicator` | Mandatory Generic Indicator | | | ✓ | |
| 40 | `therapeutic_reference_number_override` | Therapeutic reference number override | ✓ | | | |
| 41 | `max_dependant_age` | Max Dependant Age | ✓ | | | |
| 42 | `max_student_age` | Max Student Age | ✓ | | | |
| 43 | `pharmacy_general_code` | General Code | ✓ | | | |
| 44 | `pharmacy_suspend_flag` | Suspend Flag | ✓ | | ✓ | |
| 45 | `pharmacy_coverage_code` | Coverage Code | ✓ | | | |
| 46 | `pharmacy_cob_status_code` | COB Status Code | ✓ | | | |
| 47 | `pharmacy_cob_status` | COB Status | | | ✓ | |
| 48 | `prov_enrolment_date` | Prov Enrolment Date | ✓ | | | |
| 49 | `hsa_pharmacy_indicator` | HSA Pharmacy indicator | ✓ | | | |
| 50 | `sdc_program_ind` | SDC Program Ind. | ✓ | | ✓ | |
| 51 | `max_age_coverage` | Max Age Coverage | ✓ | | | |
| 52 | `max_age_spouse` | Max Age Spouse | ✓ | | | |
| 53 | `max_age_disabled` | Max Age Disabled | ✓ | | | |
| 54 | `max_age_cardholder` | Max Age Cardholder | ✓ | | | |
| 55 | `exception_flag` | Exception flag | | | ✓ | |
| 56 | `enrolment_date` | Enrolment date | | | ✓ | |
| 57 | `cob_rule` | COB Rule | | | ✓ | |
| 58 | `bypass_ldf_logic` | Bypass LDF Logic | | | ✓ | |
| 59 | `bypass_methadone_ldf_logic` | Bypass Methadone LDF logic | | | ✓ | |
| 60 | `filler_pharmacy_1` | Filler | | | ✓ | |
| 61 | `bypass_oms_logic` | Bypass OMS Logic | | | ✓ | |
| 62 | `disease_program_grace_period` | Disease Program Grace Period | | | ✓ | |
| 63 | `filler_pharmacy` | Filler | ✓ | | | |
| 64 | `filler_pharmacy_2` | Filler | | | ✓ | |
| **DENTAL SECTION FIELDS** |
| 65 | `dental_processing_mode` | Dental Processing Mode | ✓ | | ✓ | |
| 66 | `carrier_dental_field` | Carrier Dental Field | ✓ | | | |
| 67 | `dental_record_effective_date` | Dental Record Effective Date | ✓ | | ✓ | |
| 68 | `dental_record_expiry_date` | Dental Record Expiry Date | ✓ | | ✓ | |
| 69 | `dental_plan_number` | Plan Number | ✓ | | ✓ | |
| 70 | `dental_client_benefit_override_code` | Client Benefit Override Code | ✓ | | | |
| 71 | `dental_patient_benefit_override_code` | Patient Benefit Override Code | | | ✓ | |
| 72 | `dental_private_cob_rule_number` | Private COB Rule Number | ✓ | | | |
| 73 | `dental_private_cob_rule_code` | Private COB Rule Code | | | ✓ | |
| 74 | `dental_max_dependant_age` | Max Dependant Age | ✓ | | | |
| 75 | `dental_max_student_age` | Max Student Age | ✓ | | | |
| 76 | `dental_general_code` | General Code | ✓ | | | |
| 77 | `dental_suspend_flag` | Suspend Flag | ✓ | | ✓ | |
| 78 | `dental_coverage_code` | Coverage Code | ✓ | | | |
| 79 | `dental_cob_status_code` | COB Status Code | ✓ | | | |
| 80 | `dental_cob_status` | COB Status | | | ✓ | |
| 81 | `dental_cost_plus` | Cost Plus | ✓ | | ✓ | |
| 82 | `dental_edi_threshold_amount` | EDI Threshold Amount | ✓ | | ✓ | |
| 83 | `late_entrant_indicator` | Late entrant indicator | | | ✓ | |
| 84 | `filler_dental` | Filler | ✓ | | ✓ | |
| **EHC SECTION FIELDS** |
| 85 | `ehc_processing_mode` | EHC Processing Mode | | ✓ | | ✓ |
| 86 | `carrier_ehc_field` | Carrier EHC Field | | ✓ | | |
| 87 | `ehc_record_effective_date` | EHC Record Effective Date | | ✓ | | ✓ |
| 88 | `ehc_record_expiry_date` | EHC Record Expiry Date | | ✓ | | ✓ |
| 89 | `ehc_plan_number` | Plan Number | | ✓ | | ✓ |
| 90 | `ehc_client_benefit_override_code` | Client Benefit Override Code | | ✓ | | |
| 91 | `ehc_patient_benefit_override_code` | Patient Benefit Override Code | | | | ✓ |
| 92 | `ehc_private_cob_rule_number` | Private COB Rule Number | | ✓ | | |
| 93 | `ehc_private_cob_rule_code` | Private COB Rule Code | | | | ✓ |
| 94 | `ehc_max_dependant_age` | Max Dependant Age | | ✓ | | |
| 95 | `ehc_max_student_age` | Max Student Age | | ✓ | | |
| 96 | `ehc_general_code` | General Code | | ✓ | | |
| 97 | `ehc_suspend_flag` | Suspend Flag | | ✓ | | ✓ |
| 98 | `ehc_coverage_code` | Coverage Code | | ✓ | | |
| 99 | `ehc_cob_status_code` | COB Status Code | | ✓ | | |
| 100 | `ehc_cob_status` | COB Status | | | | ✓ |
| 101 | `ehc_cost_plus` | Cost Plus | | ✓ | | ✓ |
| 102 | `ehc_edi_threshold_amount` | EDI Threshold Amount | | ✓ | | ✓ |
| 103 | `late_entrant_indicator` | Late entrant indicator | | | | ✓ |
| 104 | `filler_ehc` | Filler | | ✓ | | ✓ |

## Field Sequence by Record Type

### Record 20 Field Sequence (58 fields)
Fields appear in this exact order:
1-5: Identification (record_type, carrier_id, group_number, sas, client_id)
6-16: General Section (general_processing_mode, alternate_identification, client_language_code, client_province_code, eft_account_number, eft_route_code, eft_effective_date, eft_termination_date, lookup_override_code, employment_enrolment_date, filler_general)
17-42: Pharmacy Section (pharmacy_processing_mode, carrier_pharmacy_field, drug_effective_date, drug_termination_date, pharmacy_plan_number, pharmacy_client_benefit_override_code, dur_flag, provincial_cob_rule_number, ramq_override_flag, cutback_override_indicator, mandatory_generic_override_indicator, therapeutic_reference_number_override, max_dependant_age, max_student_age, pharmacy_general_code, pharmacy_suspend_flag, pharmacy_coverage_code, pharmacy_cob_status_code, prov_enrolment_date, hsa_pharmacy_indicator, sdc_program_ind, max_age_coverage, max_age_spouse, max_age_disabled, max_age_cardholder, filler_pharmacy)
43-58: Dental Section (dental_processing_mode, carrier_dental_field, dental_record_effective_date, dental_record_expiry_date, dental_plan_number, dental_client_benefit_override_code, dental_private_cob_rule_number, dental_max_dependant_age, dental_max_student_age, dental_general_code, dental_suspend_flag, dental_coverage_code, dental_cob_status_code, dental_cost_plus, dental_edi_threshold_amount, filler_dental)

### Record 30 Field Sequence (32 fields)
Fields appear in this exact order:
1-5: Identification (record_type, carrier_id, group_number, sas, client_id)
6-16: General Section (general_processing_mode, alternate_identification, client_language_code, client_province_code, eft_account_number, eft_route_code, eft_effective_date, eft_termination_date, lookup_override_code, employment_enrolment_date, filler_general)
17-32: EHC Section (ehc_processing_mode, carrier_ehc_field, ehc_record_effective_date, ehc_record_expiry_date, ehc_plan_number, ehc_client_benefit_override_code, ehc_private_cob_rule_number, ehc_max_dependant_age, ehc_max_student_age, ehc_general_code, ehc_suspend_flag, ehc_coverage_code, ehc_cob_status_code, ehc_cost_plus, ehc_edi_threshold_amount, filler_ehc)

### Record 22 Field Sequence (46 fields)
Fields appear in this exact order:
1-6: Identification (record_type, carrier_id, group_number, sas, client_id, current_patient_code)
7-16: General Section (general_processing_mode, relationship_code, patient_last_name, patient_first_name, patient_middle_initial, patient_date_of_birth, patient_sex, new_patient_code, dental_enrolment_date, filler_general)
17-34: Pharmacy Section (pharmacy_processing_mode, drug_effective_date, drug_termination_date, pharmacy_plan_number, pharmacy_patient_benefit_override_code, pharmacy_cob_status, pharmacy_suspend_flag, exception_flag, enrolment_date, cob_rule, bypass_ldf_logic, bypass_methadone_ldf_logic, filler_pharmacy_1, sdc_program_ind, bypass_oms_logic, disease_program_grace_period, mandatory_generic_indicator, filler_pharmacy_2)
35-46: Dental Section (dental_processing_mode, dental_record_effective_date, dental_record_expiry_date, dental_plan_number, dental_patient_benefit_override_code, dental_cob_status, dental_suspend_flag, late_entrant_indicator, dental_cost_plus, dental_private_cob_rule_code, dental_edi_threshold_amount, filler_dental)

### Record 32 Field Sequence (28 fields)
Fields appear in this exact order:
1-6: Identification (record_type, carrier_id, group_number, sas, client_id, current_patient_code)
7-16: General Section (general_processing_mode, relationship_code, patient_last_name, patient_first_name, patient_middle_initial, patient_date_of_birth, patient_sex, new_patient_code, ehc_enrolment_date, filler_general)
17-28: EHC Section (ehc_processing_mode, ehc_record_effective_date, ehc_record_expiry_date, ehc_plan_number, ehc_patient_benefit_override_code, ehc_cob_status, ehc_suspend_flag, late_entrant_indicator, ehc_cost_plus, ehc_private_cob_rule_code, ehc_edi_threshold_amount, filler_ehc)

## Summary

### Field Counts by Record Type
- **Record 20 (Client - Pharmacy & Dental):** 58 fields
- **Record 30 (EHC Client):** 32 fields
- **Record 22 (Patient - Pharmacy & Dental):** 46 fields
- **Record 32 (EHC Patient):** 28 fields

### Common Fields Across All Records
**5 fields** are present in all 4 record types:
1. `record_type` - Record Type
2. `carrier_id` - Carrier ID
3. `group_number` - Group Number
4. `sas` - SAS
5. `client_id` - Client ID

### Fields Common to Client Records (20, 30)
**16 fields** are shared by Records 20 and 30:
1. `record_type` - Record Type
2. `carrier_id` - Carrier ID
3. `group_number` - Group Number
4. `sas` - SAS
5. `client_id` - Client ID
6. `general_processing_mode` - General Processing Mode
7. `alternate_identification` - Alternate Identification
8. `client_language_code` - Client Language Flag/Code
9. `client_province_code` - Client Province Code
10. `eft_account_number` - EFT Account #
11. `eft_route_code` - EFT Route code
12. `eft_effective_date` - EFT Effective Dt
13. `eft_termination_date` - EFT Termination date
14. `lookup_override_code` - Lookup override code
15. `employment_enrolment_date` - Employment enrolment date
16. `filler_general` - Filler

### Fields Common to Patient Records (22, 32)
**17 fields** are shared by Records 22 and 32:
1. `record_type` - Record Type
2. `carrier_id` - Carrier ID
3. `group_number` - Group Number
4. `sas` - SAS
5. `client_id` - Client ID
6. `current_patient_code` - Current Patient Code
7. `general_processing_mode` - General Processing Mode
8. `relationship_code` - Relationship Code
9. `patient_last_name` - Full Patient Last Name
10. `patient_first_name` - Full Patient First Name/Initial
11. `patient_middle_initial` - Patient Middle Initial
12. `patient_date_of_birth` - Patient Date of Birth
13. `patient_sex` - Patient Sex
14. `new_patient_code` - New Patient Code
15. `filler_general` - Filler
16. `late_entrant_indicator` - Late entrant indicator (appears in different sections)

**Note:** Record 22 has `dental_enrolment_date` while Record 32 has `ehc_enrolment_date` - these are similar but different fields.

### Record-Specific Field Groups

#### Record 20 Specific Fields (42 fields)
Record 20 includes Pharmacy and Dental sections with 42 additional fields:
- **Pharmacy Section (26 fields):** `pharmacy_processing_mode`, `carrier_pharmacy_field`, `drug_effective_date`, `drug_termination_date`, `pharmacy_plan_number`, `pharmacy_client_benefit_override_code`, `dur_flag`, `provincial_cob_rule_number`, `ramq_override_flag`, `cutback_override_indicator`, `mandatory_generic_override_indicator`, `therapeutic_reference_number_override`, `max_dependant_age`, `max_student_age`, `pharmacy_general_code`, `pharmacy_suspend_flag`, `pharmacy_coverage_code`, `pharmacy_cob_status_code`, `prov_enrolment_date`, `hsa_pharmacy_indicator`, `sdc_program_ind`, `max_age_coverage`, `max_age_spouse`, `max_age_disabled`, `max_age_cardholder`, `filler_pharmacy`
- **Dental Section (16 fields):** `dental_processing_mode`, `carrier_dental_field`, `dental_record_effective_date`, `dental_record_expiry_date`, `dental_plan_number`, `dental_client_benefit_override_code`, `dental_private_cob_rule_number`, `dental_max_dependant_age`, `dental_max_student_age`, `dental_general_code`, `dental_suspend_flag`, `dental_coverage_code`, `dental_cob_status_code`, `dental_cost_plus`, `dental_edi_threshold_amount`, `filler_dental`

#### Record 30 Specific Fields (16 fields)
Record 30 includes EHC (Extended Health Care) section with 16 additional fields:
- `ehc_processing_mode`, `carrier_ehc_field`, `ehc_record_effective_date`, `ehc_record_expiry_date`, `ehc_plan_number`, `ehc_client_benefit_override_code`, `ehc_private_cob_rule_number`, `ehc_max_dependant_age`, `ehc_max_student_age`, `ehc_general_code`, `ehc_suspend_flag`, `ehc_coverage_code`, `ehc_cob_status_code`, `ehc_cost_plus`, `ehc_edi_threshold_amount`, `filler_ehc`

#### Record 22 Specific Fields (30 fields)
Record 22 includes Pharmacy and Dental sections with 30 additional fields:
- **Pharmacy Section (18 fields):** `pharmacy_processing_mode`, `drug_effective_date`, `drug_termination_date`, `pharmacy_plan_number`, `pharmacy_patient_benefit_override_code`, `pharmacy_cob_status`, `pharmacy_suspend_flag`, `exception_flag`, `enrolment_date`, `cob_rule`, `bypass_ldf_logic`, `bypass_methadone_ldf_logic`, `filler_pharmacy_1`, `sdc_program_ind`, `bypass_oms_logic`, `disease_program_grace_period`, `mandatory_generic_indicator`, `filler_pharmacy_2`
- **Dental Section (12 fields):** `dental_processing_mode`, `dental_record_effective_date`, `dental_record_expiry_date`, `dental_plan_number`, `dental_patient_benefit_override_code`, `dental_cob_status`, `dental_suspend_flag`, `late_entrant_indicator`, `dental_cost_plus`, `dental_private_cob_rule_code`, `dental_edi_threshold_amount`, `filler_dental`

#### Record 32 Specific Fields (11 fields)
Record 32 includes EHC (Extended Health Care) section with 11 additional fields:
- `ehc_enrolment_date`, `ehc_processing_mode`, `ehc_record_effective_date`, `ehc_record_expiry_date`, `ehc_plan_number`, `ehc_patient_benefit_override_code`, `ehc_cob_status`, `ehc_suspend_flag`, `late_entrant_indicator`, `ehc_cost_plus`, `ehc_private_cob_rule_code`, `ehc_edi_threshold_amount`, `filler_ehc`

## Key Observations

1. **Client vs Patient Records:**
   - **Records 20 and 30** are client-level records that share 16 common fields including EFT fields and general processing modes
   - **Records 22 and 32** are patient-level records that share 17 common fields including patient identification information

2. **Benefit Section Distribution:**
   - **Record 20** contains Pharmacy and Dental sections (42 fields)
   - **Record 30** contains EHC section only (16 fields)
   - **Record 22** contains Pharmacy and Dental sections (30 fields)
   - **Record 32** contains EHC section only (11 fields)

3. **Field Naming Conventions:**
   - Client records (20, 30) use `client_benefit_override_code` and `private_cob_rule_number`
   - Patient records (22, 32) use `patient_benefit_override_code` and `private_cob_rule_code`
   - Client records use `cob_status_code` while patient records use `cob_status`

4. **Common Patterns:**
   - All records share the same identification fields (record type, carrier ID, group number, SAS, client ID)
   - Client records include EFT and general processing fields
   - Patient records include patient demographic information
   - Pharmacy/Dental sections appear together in Records 20 and 22
   - EHC sections appear separately in Records 30 and 32

5. **Total Unique Fields:** 104 fields across all 4 record types
