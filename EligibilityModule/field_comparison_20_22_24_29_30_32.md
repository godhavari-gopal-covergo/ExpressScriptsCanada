# Field Comparison: Record Types 20, 22, 24, 29, 30, and 32

| # | Field Key | Field Name | 20 | 22 | 24 | 29 | 30 | 32 |
|---|-----------|------------|----|----|----|----|----|----|
| **IDENTIFICATION FIELDS** |
| 1 | `record_type` | Record Type | ✓ | ✓ | ✓ | ✓ | ✓ | ✓ |
| 2 | `carrier_id` | Carrier ID | ✓ | ✓ | ✓ | ✓ | ✓ | ✓ |
| 3 | `group_number` | Group Number | ✓ | ✓ | ✓ | ✓ | ✓ | ✓ |
| 4 | `sas` | SAS | ✓ | ✓ | ✓ | | ✓ | ✓ |
| 5 | `client_id` | Client ID | ✓ | ✓ | ✓ | ✓ | ✓ | ✓ |
| 6 | `current_patient_code` | Current Patient Code | | ✓ | ✓ | | | ✓ |
| 7 | `patient_code` | Patient Code | | | ✓ | | | |
| **GENERAL SECTION FIELDS** |
| 8 | `general_processing_mode` | General Processing Mode | ✓ | ✓ | | | ✓ | ✓ |
| 9 | `alternate_identification` | Alternate Identification | ✓ | | | | ✓ | |
| 10 | `client_language_code` | Client Language Flag/Code | ✓ | | | | ✓ | |
| 11 | `client_province_code` | Client Province Code | ✓ | | | | ✓ | |
| 12 | `eft_account_number` | EFT Account # | ✓ | | | | ✓ | |
| 13 | `eft_route_code` | EFT Route code | ✓ | | | | ✓ | |
| 14 | `eft_effective_date` | EFT Effective Dt | ✓ | | | | ✓ | |
| 15 | `eft_termination_date` | EFT Termination date | ✓ | | | | ✓ | |
| 16 | `lookup_override_code` | Lookup override code | ✓ | | | | ✓ | |
| 17 | `employment_enrolment_date` | Employment enrolment date | ✓ | | | | ✓ | |
| 18 | `relationship_code` | Relationship Code | | ✓ | | | | ✓ |
| 19 | `patient_last_name` | Full Patient Last Name | | ✓ | | | | ✓ |
| 20 | `patient_first_name` | Full Patient First Name/Initial | | ✓ | | | | ✓ |
| 21 | `patient_middle_initial` | Patient Middle Initial | | ✓ | | | | ✓ |
| 22 | `patient_date_of_birth` | Patient Date of Birth | | ✓ | | | | ✓ |
| 23 | `patient_sex` | Patient Sex | | ✓ | | | | ✓ |
| 24 | `new_patient_code` | New Patient Code | | ✓ | | | | ✓ |
| 25 | `dental_enrolment_date` | Dental enrolment date | | ✓ | | | | |
| 26 | `ehc_enrolment_date` | EHC enrolment date | | | | | | ✓ |
| 27 | `filler_general` | Filler | ✓ | ✓ | | | ✓ | ✓ |
| **CLIENT ADDRESS FIELDS (Record 29)** |
| 28 | `client_last_name` | Client Last name | | | | ✓ | | |
| 29 | `client_first_name` | Client first name | | | | ✓ | | |
| 30 | `address1` | Address1 | | | | ✓ | | |
| 31 | `address2` | Address2 | | | | ✓ | | |
| 32 | `city` | City | | | | ✓ | | |
| 33 | `province` | Province | | | | ✓ | | |
| 34 | `country` | Country | | | | ✓ | | |
| 35 | `postal_code` | Postal Code | | | | ✓ | | |
| 36 | `filler` | Filler | | | | ✓ | | |
| **PHARMACY SECTION FIELDS** |
| 37 | `pharmacy_processing_mode` | Pharmacy Processing Mode | ✓ | ✓ | ✓ | | | |
| 38 | `carrier_pharmacy_field` | Carrier Pharmacy Field | ✓ | | | | | |
| 39 | `drug_effective_date` | Drug Effective Date | ✓ | ✓ | | | | |
| 40 | `drug_termination_date` | Drug Termination Date | ✓ | ✓ | | | | |
| 41 | `pharmacy_plan_number` | Plan Number (Pharmacy) | ✓ | ✓ | | | | |
| 42 | `pharmacy_client_benefit_override_code` | Client Benefit Override Code (Pharmacy) | ✓ | | | | | |
| 43 | `pharmacy_patient_benefit_override_code` | Patient Benefit Override Code (Pharmacy) | | ✓ | | | | |
| 44 | `dur_flag` | DUR Flag | ✓ | | | | | |
| 45 | `provincial_cob_rule_number` | Provincial COB Rule Number | ✓ | | | | | |
| 46 | `ramq_override_flag` | RAMQ Override Flag | ✓ | | | | | |
| 47 | `cutback_override_indicator` | Cutback override indicator | ✓ | | ✓ | | | |
| 48 | `mandatory_generic_override_indicator` | Mandatory Generic override indicator | ✓ | | ✓ | | | |
| 49 | `mandatory_generic_indicator` | Mandatory Generic Indicator | | ✓ | | | | |
| 50 | `therapeutic_reference_number_override` | Therapeutic reference number override | ✓ | | ✓ | | | |
| 51 | `max_dependant_age` | Max Dependant Age (Pharmacy) | ✓ | | | | | |
| 52 | `max_student_age` | Max Student Age (Pharmacy) | ✓ | | | | | |
| 53 | `pharmacy_general_code` | General Code (Pharmacy) | ✓ | | | | | |
| 54 | `pharmacy_suspend_flag` | Suspend Flag (Pharmacy) | ✓ | ✓ | | | | |
| 55 | `pharmacy_coverage_code` | Coverage Code (Pharmacy) | ✓ | | | | | |
| 56 | `pharmacy_cob_status_code` | COB Status Code (Pharmacy) | ✓ | | | | | |
| 57 | `pharmacy_cob_status` | COB Status (Pharmacy) | | ✓ | | | | |
| 58 | `prov_enrolment_date` | Prov Enrolment Date | ✓ | | | | | |
| 59 | `hsa_pharmacy_indicator` | HSA Pharmacy indicator | ✓ | | | | | |
| 60 | `sdc_program_ind` | SDC Program Ind | ✓ | ✓ | | | | |
| 61 | `max_age_coverage` | Max Age Coverage | ✓ | | | | | |
| 62 | `max_age_spouse` | Max Age Spouse | ✓ | | | | | |
| 63 | `max_age_disabled` | Max Age Disabled | ✓ | | | | | |
| 64 | `max_age_cardholder` | Max Age Cardholder | ✓ | | | | | |
| 65 | `exception_flag` | Exception flag | | ✓ | | | | |
| 66 | `enrolment_date` | Enrolment date | | ✓ | | | | |
| 67 | `cob_rule` | COB Rule | | ✓ | | | | |
| 68 | `bypass_ldf_logic` | Bypass LDF Logic | | ✓ | | | | |
| 69 | `bypass_methadone_ldf_logic` | Bypass Methadone LDF logic | | ✓ | | | | |
| 70 | `bypass_oms_logic` | Bypass OMS Logic | | ✓ | | | | |
| 71 | `disease_program_grace_period` | Disease Program Grace Period | | ✓ | | | | |
| 72 | `filler_pharmacy` | Filler (Pharmacy) | ✓ | | | | | |
| 73 | `filler_pharmacy_1` | Filler (Pharmacy 1) | | ✓ | ✓ | | | |
| 74 | `filler_pharmacy_2` | Filler (Pharmacy 2) | | ✓ | ✓ | | | |
| 75 | `filler_pharmacy_3` | Filler (Pharmacy 3) | | | ✓ | | | |
| 76 | `filler_pharmacy_4` | Filler (Pharmacy 4) | | | ✓ | | | |
| **PHARMACY EXCEPTION FIELDS (Record 24)** |
| 77 | `pharmacy_effective_date` | Effective Date (Pharmacy Exception) | | | ✓ | | | |
| 78 | `pharmacy_expiry_date` | Expiry Date (Pharmacy Exception) | | | ✓ | | | |
| 79 | `drug_level` | Drug Level (DL) | | | ✓ | | | |
| 80 | `din` | DIN (if DL = 70) | | | ✓ | | | |
| 81 | `ramq_exception_code` | RAMQ Exception Code (if DL=65) | | | ✓ | | | |
| 82 | `gp_indicator` | GP Indicator (if DL=60) | | | ✓ | | | |
| 83 | `eclipse_code` | Eclipse Code (if DL=50) | | | ✓ | | | |
| 84 | `therapeutic_class` | Therapeutic Class (If DL=40) | | | ✓ | | | |
| 85 | `seniors_flag` | Seniors Flag (If DL=30) | | | ✓ | | | |
| 86 | `provincial_schedule_code` | Provincial Schedule Code (IF DL=20) | | | ✓ | | | |
| 87 | `include_exclude_flag` | Include/Exclude Flag | | | ✓ | | | |
| 88 | `exception_days_supply_reg` | Exception Days Supply Reg | | | ✓ | | | |
| 89 | `exception_days_supply_maint` | Exception Days Supply Maint | | | ✓ | | | |
| 90 | `except_override_code` | Except Override Code | | | ✓ | | | |
| 91 | `accum_id` | Accum Id | | | ✓ | | | |
| 92 | `aqpp_code` | AQPP Code (IF DL=55) | | | ✓ | | | |
| 93 | `ramq_flag` | RAMQ Flag | | | ✓ | | | |
| 94 | `disease_code` | Disease Code (if DL = 67) | | | ✓ | | | |
| 95 | `gpi_code` | GPI Code (if DL = 68) | | | ✓ | | | |
| 96 | `limit_dispensing_fee` | Limit Dispensing Fee | | | ✓ | | | |
| 97 | `warning_msg_period` | Warning Msg Period | | | ✓ | | | |
| 98 | `pla_indicator` | PLA Indicator | | | ✓ | | | |
| 99 | `therapy_indication_code` | Therapy Indication Code | | | ✓ | | | |
| 100 | `exception_reason` | Exception Reason | | | ✓ | | | |
| 101 | `bypass_suppl_itc_process` | Bypass Suppl. ITC Process | | | ✓ | | | |
| 102 | `bypass_biosimilar` | Bypass Biosimilar | | | ✓ | | | |
| 103 | `bypass_sdc_ed` | Bypass SDC/ED | | | ✓ | | | |
| 104 | `default_benefit_code` | Default Benefit Code | | | ✓ | | | |
| **DENTAL SECTION FIELDS** |
| 105 | `dental_processing_mode` | Dental Processing Mode | ✓ | ✓ | ✓ | | | |
| 106 | `carrier_dental_field` | Carrier Dental Field | ✓ | | | | | |
| 107 | `dental_record_effective_date` | Dental Record Effective Date | ✓ | ✓ | | | | |
| 108 | `dental_record_expiry_date` | Dental Record Expiry Date | ✓ | ✓ | | | | |
| 109 | `dental_plan_number` | Plan Number (Dental) | ✓ | ✓ | | | | |
| 110 | `dental_client_benefit_override_code` | Client Benefit Override Code (Dental) | ✓ | | | | | |
| 111 | `dental_patient_benefit_override_code` | Patient Benefit Override Code (Dental) | | ✓ | | | | |
| 112 | `dental_private_cob_rule_number` | Private COB Rule Number (Dental) | ✓ | | | | | |
| 113 | `dental_private_cob_rule_code` | Private COB Rule Code (Dental) | | ✓ | | | | |
| 114 | `dental_max_dependant_age` | Max Dependant Age (Dental) | ✓ | | | | | |
| 115 | `dental_max_student_age` | Max Student Age (Dental) | ✓ | | | | | |
| 116 | `dental_general_code` | General Code (Dental) | ✓ | | | | | |
| 117 | `dental_suspend_flag` | Suspend Flag (Dental) | ✓ | ✓ | | | | |
| 118 | `dental_coverage_code` | Coverage Code (Dental) | ✓ | | | | | |
| 119 | `dental_cob_status_code` | COB Status Code (Dental) | ✓ | | | | | |
| 120 | `dental_cob_status` | COB Status (Dental) | | ✓ | | | | |
| 121 | `dental_cost_plus` | Cost Plus (Dental) | ✓ | ✓ | | | | |
| 122 | `dental_edi_threshold_amount` | EDI Threshold Amount (Dental) | ✓ | ✓ | | | | |
| 123 | `late_entrant_indicator` | Late entrant indicator (Dental) | | ✓ | | | | |
| 124 | `filler_dental` | Filler (Dental) | ✓ | ✓ | ✓ | | | |
| **DENTAL EXCEPTION FIELDS (Record 24)** |
| 125 | `dental_effective_date` | Effective Date (Dental Exception) | | | ✓ | | | |
| 126 | `dental_expiry_date` | Expiry Date (Dental Exception) | | | ✓ | | | |
| 127 | `proc_code` | Proc code | | | ✓ | | | |
| 128 | `proc_code_source` | Proc code Source | | | ✓ | | | |
| 129 | `lab_limit` | Lab limit | | | ✓ | | | |
| 130 | `expense_limit` | Expense limit | | | ✓ | | | |
| 131 | `category_code` | Category code | | | ✓ | | | |
| 132 | `freq_id1` | Freq id1 | | | ✓ | | | |
| 133 | `freq_id2` | Freq id2 | | | ✓ | | | |
| 134 | `freq_id3` | Freq id3 | | | ✓ | | | |
| 135 | `freq_id4` | Freq id4 | | | ✓ | | | |
| 136 | `material_intervention` | Material intervention | | | ✓ | | | |
| 137 | `dental_include_exclude` | Include/Exclude (Dental) | | | ✓ | | | |
| **EHC SECTION FIELDS** |
| 138 | `ehc_processing_mode` | EHC Processing Mode | | | | | ✓ | ✓ |
| 139 | `carrier_ehc_field` | Carrier EHC Field | | | | | ✓ | |
| 140 | `ehc_record_effective_date` | EHC Record Effective Date | | | | | ✓ | ✓ |
| 141 | `ehc_record_expiry_date` | EHC Record Expiry Date | | | | | ✓ | ✓ |
| 142 | `ehc_plan_number` | Plan Number (EHC) | | | | | ✓ | ✓ |
| 143 | `ehc_client_benefit_override_code` | Client Benefit Override Code (EHC) | | | | | ✓ | |
| 144 | `ehc_patient_benefit_override_code` | Patient Benefit Override Code (EHC) | | | | | | ✓ |
| 145 | `ehc_private_cob_rule_number` | Private COB Rule Number (EHC) | | | | | ✓ | |
| 146 | `ehc_private_cob_rule_code` | Private COB Rule Code (EHC) | | | | | | ✓ |
| 147 | `ehc_max_dependant_age` | Max Dependant Age (EHC) | | | | | ✓ | |
| 148 | `ehc_max_student_age` | Max Student Age (EHC) | | | | | ✓ | |
| 149 | `ehc_general_code` | General Code (EHC) | | | | | ✓ | |
| 150 | `ehc_suspend_flag` | Suspend Flag (EHC) | | | | | ✓ | ✓ |
| 151 | `ehc_coverage_code` | Coverage Code (EHC) | | | | | ✓ | |
| 152 | `ehc_cob_status_code` | COB Status Code (EHC) | | | | | ✓ | |
| 153 | `ehc_cob_status` | COB Status (EHC) | | | | | | ✓ |
| 154 | `ehc_cost_plus` | Cost Plus (EHC) | | | | | ✓ | ✓ |
| 155 | `ehc_edi_threshold_amount` | EDI Threshold Amount (EHC) | | | | | ✓ | ✓ |
| 156 | `late_entrant_indicator` | Late entrant indicator (EHC) | | | | | | ✓ |
| 157 | `filler_ehc` | Filler (EHC) | | | | | ✓ | ✓ |

## Summary

### Field Counts by Record Type
- **Record 20 (Client - Pharmacy & Dental):** 58 fields
- **Record 22 (Patient - Pharmacy & Dental):** 46 fields
- **Record 24 (Patient Exception - Pharmacy & Dental):** 57 fields
- **Record 29 (Client Address):** 13 fields
- **Record 30 (EHC Client):** 32 fields
- **Record 32 (EHC Patient):** 28 fields

### Common Fields Across All Records
**4 fields** are present in all 6 record types:
1. `record_type` - Record Type
2. `carrier_id` - Carrier ID
3. `group_number` - Group Number
4. `client_id` - Client ID

### Fields Common to Client Records (20, 29, 30)
**4 fields** are shared by all client records:
1. `record_type` - Record Type
2. `carrier_id` - Carrier ID
3. `group_number` - Group Number
4. `client_id` - Client ID

**12 fields** are shared by Records 20 and 30 (but not 29):
1. `sas` - SAS
2. `general_processing_mode` - General Processing Mode
3. `alternate_identification` - Alternate Identification
4. `client_language_code` - Client Language Flag/Code
5. `client_province_code` - Client Province Code
6. `eft_account_number` - EFT Account #
7. `eft_route_code` - EFT Route code
8. `eft_effective_date` - EFT Effective Dt
9. `eft_termination_date` - EFT Termination date
10. `lookup_override_code` - Lookup override code
11. `employment_enrolment_date` - Employment enrolment date
12. `filler_general` - Filler

### Fields Common to Patient Records (22, 24, 32)
**7 fields** are shared by all patient records:
1. `record_type` - Record Type
2. `carrier_id` - Carrier ID
3. `group_number` - Group Number
4. `client_id` - Client ID
5. `sas` - SAS
6. `general_processing_mode` - General Processing Mode
7. `filler_general` - Filler

**10 fields** are shared by Records 22 and 32 (but not 24):
1. `current_patient_code` - Current Patient Code
2. `relationship_code` - Relationship Code
3. `patient_last_name` - Full Patient Last Name
4. `patient_first_name` - Full Patient First Name/Initial
5. `patient_middle_initial` - Patient Middle Initial
6. `patient_date_of_birth` - Patient Date of Birth
7. `patient_sex` - Patient Sex
8. `new_patient_code` - New Patient Code
9. `filler_general` - Filler
10. `ehc_processing_mode` / `pharmacy_processing_mode` - Processing Mode

### Record-Specific Field Groups

#### Record 20 Specific Fields (42 fields)
- Pharmacy section: 26 fields (processing mode, dates, plan numbers, flags, overrides, age limits, etc.)
- Dental section: 16 fields (processing mode, dates, plan numbers, COB rules, coverage codes, etc.)

#### Record 22 Specific Fields (30 fields)
- Patient identification: 10 fields (patient code, relationship, name, DOB, sex, etc.)
- Pharmacy section: 20 fields (processing mode, dates, plan numbers, flags, overrides, etc.)
- Dental section: 10 fields (processing mode, dates, plan numbers, COB status, etc.)

#### Record 24 Specific Fields (57 fields)
- Patient exception identification: 6 fields
- Pharmacy exception section: 42 fields (drug level, DIN, GPI, exception codes, overrides, etc.)
- Dental exception section: 9 fields (procedure codes, limits, frequencies, etc.)

#### Record 29 Specific Fields (9 fields)
- Address information: 9 fields (client name, address lines, city, province, country, postal code)

#### Record 30 Specific Fields (16 fields)
- EHC section: 16 fields (processing mode, dates, plan numbers, COB rules, coverage codes, age limits, etc.)

#### Record 32 Specific Fields (12 fields)
- Patient identification: 7 fields (patient code, relationship, name, DOB, sex, etc.)
- EHC section: 5 fields (dates, plan numbers, COB status, suspend flag, etc.)

## Key Observations

1. **Record 29** is unique - it's the only address-only record with minimal identification fields and no benefit sections.

2. **Records 20 and 30** share the most common fields (16 fields) as both are client-level records with general processing capabilities.

3. **Records 22 and 32** share patient identification fields but differ in benefit sections (22 has Pharmacy/Dental, 32 has EHC).

4. **Record 24** is an exception record that requires a patient code and includes both pharmacy and dental exception sections.

5. **Pharmacy and Dental sections** appear together in Records 20 and 22, while **EHC sections** appear separately in Records 30 and 32.

6. **Client records (20, 30)** include EFT fields and general processing modes, while **Patient records (22, 32)** focus on patient-specific information and benefit configurations.

