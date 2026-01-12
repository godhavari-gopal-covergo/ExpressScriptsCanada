# Field Comparison: Record Type 24

This document provides a complete field listing for Record Type 24 (Patient Exception Record), maintaining the exact field sequence and names as defined in the configuration file.

## Record Type 24 Overview

- **Record Type:** 24
- **Description:** Patient Exception record with identification, pharmacy exception, and dental exception information
- **Total Fields:** 57 fields
- **Notes:**
  - Not a mandatory Record Type
  - Multiple type 24 records may be sent once the patient record has been sent
  - Any number of patient exception records is allowed
  - This record includes both Pharmacy and Dental sections

## Field Listing

| # | Field Key | Field Name | Length | Required | Position |
|---|-----------|------------|--------|----------|----------|
| **IDENTIFICATION SECTION** |
| 1 | `record_type` | Record Type | 2 | Y | 001-002 |
| 2 | `carrier_id` | Carrier ID | 2 | Y | 003-004 |
| 3 | `group_number` | Group Number | 10 | Y | 005-014 |
| 4 | `sas` | SAS | 9 | Y | 015-023 |
| 5 | `client_id` | Client ID | 15 | Y | 024-038 |
| 6 | `patient_code` | Patient Code | 3 | Y | 039-041 |
| **PHARMACY SECTION** |
| 7 | `pharmacy_processing_mode` | Pharmacy Processing Mode | 1 | Y | 042-042 |
| 8 | `pharmacy_effective_date` | Effective Date | 8 | Y | 043-050 |
| 9 | `pharmacy_expiry_date` | Expiry Date | 8 | N | 051-058 |
| 10 | `drug_level` | Drug Level (DL) | 2 | Y | 059-060 |
| 11 | `din` | DIN (if DL = 70) | 8 | N | 061-068 |
| 12 | `ramq_exception_code` | RAMQ Exception Code (if DL=65) | 4 | N | 069-072 |
| 13 | `filler_pharmacy_1` | Filler | 2 | N | 073-074 |
| 14 | `gp_indicator` | GP Indicator (if DL=60) | 1 | N | 075-075 |
| 15 | `eclipse_code` | Eclipse Code (if DL=50) | 2 | N | 076-077 |
| 16 | `therapeutic_class` | Therapeutic Class (If DL=40) | 6 | N | 078-083 |
| 17 | `seniors_flag` | Seniors Flag (If DL=30) | 1 | N | 084-084 |
| 18 | `provincial_schedule_code` | Provincial Schedule Code (IF DL=20) | 2 | N | 085-086 |
| 19 | `filler_pharmacy_2` | Filler | 1 | N | 087-087 |
| 20 | `include_exclude_flag` | Include/Exclude Flag | 1 | Y | 088-088 |
| 21 | `exception_days_supply_reg` | Exception Days Supply Reg | 4 | N | 089-092 |
| 22 | `exception_days_supply_maint` | Exception Days Supply Maint | 4 | N | 093-096 |
| 23 | `except_override_code` | Except Override Code | 5 | N | 097-101 |
| 24 | `accum_id` | Accum Id | 5 | N | 102-106 |
| 25 | `aqpp_code` | AQPP Code (IF DL=55) | 3 | N | 107-109 |
| 26 | `filler_pharmacy_3` | Filler | 5 | N | 110-114 |
| 27 | `cutback_override_indicator` | Cutback override indicator | 1 | N | 115-115 |
| 28 | `mandatory_generic_override_indicator` | Mandatory Generic override indicator | 1 | N | 116-116 |
| 29 | `therapeutic_reference_number_override` | Therapeutic reference number override | 4 | N | 117-120 |
| 30 | `ramq_flag` | RAMQ Flag | 1 | N | 121-121 |
| 31 | `disease_code` | Disease Code (if DL = 67) | 6 | N | 122-127 |
| 32 | `gpi_code` | GPI Code (if DL = 68) | 14 | N | 128-141 |
| 33 | `limit_dispensing_fee` | Limit Dispensing Fee | 1 | N | 142-142 |
| 34 | `warning_msg_period` | Warning Msg Period | 2 | N | 143-144 |
| 35 | `pla_indicator` | PLA Indicator | 1 | N | 145-145 |
| 36 | `therapy_indication_code` | Therapy Indication Code | 3 | N | 146-148 |
| 37 | `exception_reason` | Exception Reason | 2 | N | 149-150 |
| 38 | `bypass_suppl_itc_process` | Bypass Suppl. ITC Process | 1 | N | 151-151 |
| 39 | `bypass_biosimilar` | Bypass Biosimilar | 1 | N | 152-152 |
| 40 | `bypass_sdc_ed` | Bypass SDC/ED | 1 | N | 153-153 |
| 41 | `default_benefit_code` | Default Benefit Code | 2 | N | 154-155 |
| 42 | `filler_pharmacy_4` | Filler | 64 | Y | 156-219 |
| **DENTAL SECTION** |
| 43 | `dental_processing_mode` | Dental Processing Mode | 1 | Y | 220-220 |
| 44 | `dental_effective_date` | Effective Date | 8 | Y | 221-228 |
| 45 | `dental_expiry_date` | Expiry Date | 8 | N | 229-236 |
| 46 | `proc_code` | Proc code | 5 | Y | 237-241 |
| 47 | `proc_code_source` | Proc code Source | 4 | Y | 242-245 |
| 48 | `lab_limit` | Lab limit | 6 | N | 246-251 |
| 49 | `expense_limit` | Expense limit | 6 | N | 252-257 |
| 50 | `category_code` | Category code | 2 | Y | 258-259 |
| 51 | `freq_id1` | Freq id1 | 5 | N | 260-264 |
| 52 | `freq_id2` | Freq id2 | 5 | N | 265-269 |
| 53 | `freq_id3` | Freq id3 | 5 | N | 270-274 |
| 54 | `freq_id4` | Freq id4 | 5 | N | 275-279 |
| 55 | `material_intervention` | Material intervention | 2 | N | 280-281 |
| 56 | `dental_include_exclude` | Include/Exclude | 1 | Y | 282-282 |
| 57 | `filler_dental` | Filler | 75 | N | 283-357 |

## Field Sequence Summary

### Identification Section (6 fields)
Fields 1-6: Basic identification fields including record type, carrier ID, group number, SAS, client ID, and patient code.

### Pharmacy Section (36 fields)
Fields 7-42: Pharmacy exception fields including:
- Processing mode and dates (fields 7-9)
- Drug level identification (field 10)
- Drug identification fields based on drug level (fields 11-18, 25, 31-32)
- Exception configuration (fields 20-24, 27-30, 33-41)
- Filler fields (fields 13, 19, 26, 42)

**Drug Level (DL) Field Values:**
- **70** - DIN (field 11)
- **68** - GPI Code (field 32)
- **67** - Disease Code (field 31)
- **65** - RAMQ Exception Code (field 12)
- **60** - GP Indicator (field 14)
- **55** - AQPP Code (field 25)
- **50** - Eclipse Code (field 15)
- **40** - Therapeutic Class (field 16)
- **30** - Seniors Flag (field 17)
- **20** - Provincial Schedule Code (field 18)

### Dental Section (15 fields)
Fields 43-57: Dental exception fields including:
- Processing mode and dates (fields 43-45)
- Procedure code and source (fields 46-47)
- Limits and frequencies (fields 48-54)
- Material intervention and include/exclude flag (fields 55-56)
- Filler field (field 57)

**Note:** The dental section is not currently used as there are no patient exceptions for dental, but the fields are still required in the record structure.

## Field Details

### Required Fields (15 fields)
1. `record_type` - Record Type
2. `carrier_id` - Carrier ID
3. `group_number` - Group Number
4. `sas` - SAS
5. `client_id` - Client ID
6. `patient_code` - Patient Code
7. `pharmacy_processing_mode` - Pharmacy Processing Mode
8. `pharmacy_effective_date` - Effective Date
10. `drug_level` - Drug Level (DL)
20. `include_exclude_flag` - Include/Exclude Flag
42. `filler_pharmacy_4` - Filler
43. `dental_processing_mode` - Dental Processing Mode
44. `dental_effective_date` - Effective Date
46. `proc_code` - Proc code
47. `proc_code_source` - Proc code Source
50. `category_code` - Category code
56. `dental_include_exclude` - Include/Exclude

### Optional Fields (42 fields)
All other fields are optional.

## Key Field Relationships

### Drug Level Dependencies
The `drug_level` field (field 10) determines which identification fields are used:
- When DL = 70: `din` (field 11) must be valid
- When DL = 68: `gpi_code` (field 32) must be valid
- When DL = 67: `disease_code` (field 31) must be valid
- When DL = 65: `ramq_exception_code` (field 12) must be valid
- When DL = 60: `gp_indicator` (field 14) must be Y or N
- When DL = 55: `aqpp_code` (field 25) must be valid
- When DL = 50: `eclipse_code` (field 15) must be valid
- When DL = 40: `therapeutic_class` (field 16) must be valid
- When DL = 30: `seniors_flag` (field 17) must be Y, N, or E
- When DL = 20: `provincial_schedule_code` (field 18) must be valid

### Therapy Indication Code
The `therapy_indication_code` (field 36) is only validated when:
- Drug Level = 70 (DIN) or 68 (GPI)
- Must be a valid code associated with the DIN (field 11) or GPI (field 32)

## Total Record Length
357 characters (positions 001-357)

