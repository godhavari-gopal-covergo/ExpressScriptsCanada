# Field Comparison: Record Type 22 vs Record Type 32 vs Record Type 24

| # | Field Key | Field Name | Record 22 | Record 32 | Record 24 |
|---|-----------|------------|-----------|-----------|-----------|
| 1 | `record_type` | Record Type | ✓ | ✓ | ✓ |
| 2 | `carrier_id` | Carrier ID | ✓ | ✓ | ✓ |
| 3 | `group_number` | Group Number | ✓ | ✓ | ✓ |
| 4 | `sas` | SAS | ✓ | ✓ | ✓ |
| 5 | `client_id` | Client ID | ✓ | ✓ | ✓ |
| 6 | `current_patient_code` | Current Patient Code | ✓ | ✓ | |
| 7 | `patient_code` | Patient Code | | | ✓ |
| 8 | `general_processing_mode` | General Processing Mode | ✓ | ✓ | |
| 9 | `relationship_code` | Relationship Code | ✓ | ✓ | |
| 10 | `patient_last_name` | Full Patient Last Name | ✓ | ✓ | |
| 11 | `patient_first_name` | Full Patient First Name/Initial | ✓ | ✓ | |
| 12 | `patient_middle_initial` | Patient Middle Initial | ✓ | ✓ | |
| 13 | `patient_date_of_birth` | Patient Date of Birth | ✓ | ✓ | |
| 14 | `patient_sex` | Patient Sex | ✓ | ✓ | |
| 15 | `new_patient_code` | New Patient Code | ✓ | ✓ | |
| 16 | `dental_enrolment_date` | Dental enrolment date | ✓ | | |
| 17 | `ehc_enrolment_date` | EHC enrolment date | | ✓ | |
| 18 | `filler_general` | Filler | ✓ | ✓ | |
| 19 | `pharmacy_processing_mode` | Pharmacy Processing Mode | ✓ | | ✓ |
| 20 | `drug_effective_date` | Drug Effective Date | ✓ | | |
| 21 | `drug_termination_date` | Drug Termination Date | ✓ | | |
| 22 | `pharmacy_effective_date` | Pharmacy Effective Date | | | ✓ |
| 23 | `pharmacy_expiry_date` | Pharmacy Expiry Date | | | ✓ |
| 24 | `pharmacy_plan_number` | Plan Number | ✓ | | |
| 25 | `pharmacy_patient_benefit_override_code` | Patient Benefit Override Code | ✓ | | |
| 26 | `pharmacy_cob_status` | COB Status | ✓ | | |
| 27 | `pharmacy_suspend_flag` | Suspend Flag | ✓ | | |
| 28 | `exception_flag` | Exception flag | ✓ | | |
| 29 | `enrolment_date` | Enrolment date | ✓ | | |
| 30 | `cob_rule` | COB Rule | ✓ | | |
| 31 | `bypass_ldf_logic` | Bypass LDF Logic | ✓ | | |
| 32 | `bypass_methadone_ldf_logic` | Bypass Methadone LDF logic | ✓ | | |
| 33 | `filler_pharmacy_1` | Filler | ✓ | | ✓ |
| 34 | `sdc_program_ind` | SDC Program Ind. | ✓ | | |
| 35 | `bypass_oms_logic` | Bypass OMS Logic | ✓ | | |
| 36 | `disease_program_grace_period` | Disease Program Grace Period | ✓ | | |
| 37 | `mandatory_generic_indicator` | Mandatory Generic Indicator | ✓ | | |
| 38 | `filler_pharmacy_2` | Filler | ✓ | | ✓ |
| 39 | `drug_level` | Drug Level (DL) | | | ✓ |
| 40 | `din` | DIN (if DL = 70) | | | ✓ |
| 41 | `ramq_exception_code` | RAMQ Exception Code (if DL=65) | | | ✓ |
| 42 | `gp_indicator` | GP Indicator (if DL=60) | | | ✓ |
| 43 | `eclipse_code` | Eclipse Code (if DL=50) | | | ✓ |
| 44 | `therapeutic_class` | Therapeutic Class (If DL=40) | | | ✓ |
| 45 | `seniors_flag` | Seniors Flag (If DL=30) | | | ✓ |
| 46 | `provincial_schedule_code` | Provincial Schedule Code (IF DL=20) | | | ✓ |
| 47 | `include_exclude_flag` | Include/Exclude Flag | | | ✓ |
| 48 | `exception_days_supply_reg` | Exception Days Supply Reg | | | ✓ |
| 49 | `exception_days_supply_maint` | Exception Days Supply Maint | | | ✓ |
| 50 | `except_override_code` | Except Override Code | | | ✓ |
| 51 | `accum_id` | Accum Id | | | ✓ |
| 52 | `aqpp_code` | AQPP Code (IF DL=55) | | | ✓ |
| 53 | `filler_pharmacy_3` | Filler | | | ✓ |
| 54 | `cutback_override_indicator` | Cutback override indicator | | | ✓ |
| 55 | `mandatory_generic_override_indicator` | Mandatory Generic override indicator | | | ✓ |
| 56 | `therapeutic_reference_number_override` | Therapeutic reference number override | | | ✓ |
| 57 | `ramq_flag` | RAMQ Flag | | | ✓ |
| 58 | `disease_code` | Disease Code (if DL = 67) | | | ✓ |
| 59 | `gpi_code` | GPI Code (if DL = 68) | | | ✓ |
| 60 | `limit_dispensing_fee` | Limit Dispensing Fee | | | ✓ |
| 61 | `warning_msg_period` | Warning Msg Period | | | ✓ |
| 62 | `pla_indicator` | PLA Indicator | | | ✓ |
| 63 | `therapy_indication_code` | Therapy Indication Code | | | ✓ |
| 64 | `exception_reason` | Exception Reason | | | ✓ |
| 65 | `bypass_suppl_itc_process` | Bypass Suppl. ITC Process | | | ✓ |
| 66 | `bypass_biosimilar` | Bypass Biosimilar | | | ✓ |
| 67 | `bypass_sdc_ed` | Bypass SDC/ED | | | ✓ |
| 68 | `default_benefit_code` | Default Benefit Code | | | ✓ |
| 69 | `filler_pharmacy_4` | Filler | | | ✓ |
| 70 | `dental_processing_mode` | Dental Processing Mode | ✓ | | ✓ |
| 71 | `dental_record_effective_date` | Dental Record Effective Date | ✓ | | |
| 72 | `dental_record_expiry_date` | Dental Record Expiry Date | ✓ | | |
| 73 | `dental_effective_date` | Dental Effective Date | | | ✓ |
| 74 | `dental_expiry_date` | Dental Expiry Date | | | ✓ |
| 75 | `dental_plan_number` | Plan Number | ✓ | | |
| 76 | `dental_patient_benefit_override_code` | Patient Benefit Override Code | ✓ | | |
| 77 | `dental_cob_status` | COB Status | ✓ | | |
| 78 | `dental_suspend_flag` | Suspend Flag | ✓ | | |
| 79 | `late_entrant_indicator` | Late entrant indicator | ✓ | ✓ | |
| 80 | `dental_cost_plus` | Cost Plus | ✓ | | |
| 81 | `dental_private_cob_rule_code` | Private COB Rule Code | ✓ | | |
| 82 | `dental_edi_threshold_amount` | EDI Threshold Amount | ✓ | | |
| 83 | `filler_dental` | Filler | ✓ | | ✓ |
| 84 | `proc_code` | Proc code | | | ✓ |
| 85 | `proc_code_source` | Proc code Source | | | ✓ |
| 86 | `lab_limit` | Lab limit | | | ✓ |
| 87 | `expense_limit` | Expense limit | | | ✓ |
| 88 | `category_code` | Category code | | | ✓ |
| 89 | `freq_id1` | Freq id1 | | | ✓ |
| 90 | `freq_id2` | Freq id2 | | | ✓ |
| 91 | `freq_id3` | Freq id3 | | | ✓ |
| 92 | `freq_id4` | Freq id4 | | | ✓ |
| 93 | `material_intervention` | Material intervention | | | ✓ |
| 94 | `dental_include_exclude` | Include/Exclude | | | ✓ |
| 95 | `ehc_processing_mode` | EHC Processing Mode | | ✓ | |
| 96 | `ehc_record_effective_date` | EHC Record Effective Date | | ✓ | |
| 97 | `ehc_record_expiry_date` | EHC Record Expiry Date | | ✓ | |
| 98 | `ehc_plan_number` | Plan Number | | ✓ | |
| 99 | `ehc_patient_benefit_override_code` | Patient Benefit Override Code | | ✓ | |
| 100 | `ehc_cob_status` | COB Status | | ✓ | |
| 101 | `ehc_suspend_flag` | Suspend Flag | | ✓ | |
| 102 | `ehc_cost_plus` | Cost Plus | | ✓ | |
| 103 | `ehc_private_cob_rule_code` | Private COB Rule Code | | ✓ | |
| 104 | `ehc_edi_threshold_amount` | EDI Threshold Amount | | ✓ | |
| 105 | `filler_ehc` | Filler | | ✓ | |

## Summary

- **Fields in all three records (22, 32, 24):** 5 fields (basic identification fields)
- **Fields in Record 22 and Record 32 only:** 12 fields (common patient identification fields)
- **Fields in Record 22 and Record 24 only:** 3 fields (pharmacy and dental processing modes, filler fields)
- **Fields only in Record 22:** 25 fields (pharmacy and dental sections)
- **Fields only in Record 32:** 12 fields (EHC section)
- **Fields only in Record 24:** 48 fields (pharmacy exception and dental exception sections)
- **Total unique fields:** 105 fields

## Common Fields Across All Three Records (5)
All three record types share these basic identification fields:
1. Record Type
2. Carrier ID
3. Group Number
4. SAS
5. Client ID

## Fields in Record 22 and Record 32 Only (12)
These patient records share common patient identification and general fields:
1. Current Patient Code (Note: Record 24 uses `patient_code` instead)
2. General Processing Mode
3. Relationship Code
4. Full Patient Last Name
5. Full Patient First Name/Initial
6. Patient Middle Initial
7. Patient Date of Birth
8. Patient Sex
9. New Patient Code
10. Filler (general section)
11. Late entrant indicator (present in both, but in different sections)

## Fields in Record 22 and Record 24 Only (3)
These records share some pharmacy and dental processing fields:
1. Pharmacy Processing Mode
2. Dental Processing Mode
3. Filler fields (pharmacy_1, pharmacy_2, dental)

## Record 22 Specific Fields (25)
Record 22 includes comprehensive Pharmacy and Dental sections:
- **Pharmacy Section (18 fields):** Processing mode, effective/termination dates, plan number, benefit override, COB status, suspend flag, exception flag, enrolment date, COB rule, bypass logic flags, SDC program, disease program grace period, mandatory generic indicator, and filler fields
- **Dental Section (7 fields):** Record effective/expiry dates, plan number, patient benefit override code, COB status, suspend flag, cost plus, private COB rule code, EDI threshold amount

## Record 32 Specific Fields (12)
Record 32 includes EHC (Extended Health Care) section:
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

## Record 24 Specific Fields (48)
Record 24 is a Patient Exception record with detailed pharmacy and dental exception fields:
- **Pharmacy Exception Section (35 fields):** Processing mode, effective/expiry dates, drug level (DL) and conditional fields based on DL value (DIN, RAMQ exception code, GP indicator, Eclipse code, therapeutic class, seniors flag, provincial schedule code), include/exclude flag, exception days supply, override codes, accumulator ID, AQPP code, cutback override, mandatory generic override, therapeutic reference number override, RAMQ flag, disease code, GPI code, limit dispensing fee, warning message period, PLA indicator, therapy indication code, exception reason, bypass flags (suppl ITC, biosimilar, SDC/ED), default benefit code, and multiple filler fields
- **Dental Exception Section (13 fields):** Processing mode, effective/expiry dates, procedure code, procedure code source, lab limit, expense limit, category code, frequency IDs (1-4), material intervention, include/exclude flag, and filler

## Key Differences

1. **Patient Identification:**
   - Record 22 & 32: Use `current_patient_code` and include full patient demographics
   - Record 24: Uses `patient_code` (simpler) and focuses on exception data

2. **Processing Modes:**
   - Record 22: Has `general_processing_mode` for overall record processing
   - Record 24: Has separate `pharmacy_processing_mode` and `dental_processing_mode` for exception-specific processing
   - Record 32: Has `general_processing_mode` and `ehc_processing_mode`

3. **Date Fields:**
   - Record 22: Uses `drug_effective_date` and `drug_termination_date` for pharmacy
   - Record 24: Uses `pharmacy_effective_date` and `pharmacy_expiry_date` for pharmacy exceptions
   - Record 22: Uses `dental_record_effective_date` and `dental_record_expiry_date`
   - Record 24: Uses `dental_effective_date` and `dental_expiry_date`

4. **Exception-Specific Fields:**
   - Record 24 has extensive exception-specific fields based on Drug Level (DL) values, including conditional fields for DIN, RAMQ codes, therapeutic classes, etc.
   - Record 24 includes dental exception fields like procedure codes, frequency IDs, and material intervention

5. **Coverage Types:**
   - Record 22: Pharmacy + Dental coverage
   - Record 32: EHC (Extended Health Care) coverage
   - Record 24: Pharmacy exceptions + Dental exceptions

