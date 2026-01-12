# EHC Health Claims Experience Implementation

## Overview
Extend ExperienceModule to process EHC Health claims using the same architecture as the completed Dental implementation. Health claims use identical record type structure (0,2,3,4,5,6,7,8) but with different field definitions.

## 1. GitHub Branch Setup
- Create new branch: `feature/ehc-health-claims`

## 2. Copy Sample File
- Copy `ehc_49588_cexp` from Sample Files directory to `ExperienceModule/Input/health_sample.txt`
- This provides test data for the Health claims feed (1591 lines, same 4561-byte record structure)

## 3. Create Health Feed Configuration
Create `Config/health_feed.yml` following the dental pattern:
- Feed name: `health_ehc`
- Record length: 4561 bytes
- Map record types 0,2,3,4,5,6,7,8 to their respective YAML definitions
- Batching structure:
  - Provider: header=2, details=[4,5], trailer=6
  - Client: header=3, details=[4,5], trailer=7
  - File: header=0, trailer=8
- Output schema: `schemas/health_batch.schema.json`
- Output pattern: `Output/health_batches_{timestamp}.jsonl`

## 4. Create Health Record Definitions
Create YAML files in `Config/Records/Health/` for each record type:

### record_0.yml (File Header)
- Fields: record_identifier, issuer_identifier_number, issuer_identifier_name, destination_name, destination_address, destination_city, destination_province, destination_postal_code, destination_telephone_number, run_date, transmittal_sequence_no, cut_off_date, program_version
- Same structure as dental record 0

### record_2.yml (Provider Header)
- Key fields: provider_number, provider_office, provider_surname, provider_first_name, provider_name, address fields, city, province, country, postal_code, telephone_number
- Similar to dental but generic provider terminology

### record_3.yml (Client Address Record)
- Fields for client address, city, province, country, postal_code
- Used before client-payable claim groups

### record_4.yml (Claim Record - Paid)
- Record identifier: '4' (Paid claim)
- Key claim fields: trans_reference, date_claim_received, date_processed, claim_status, provider info, patient info, carrier_id, gsas, client_id, payee_code, payment_method
- Service line details (repeating): service_code, date_of_service, professional_fee_claimed, professional_fee_eligible, professional_fee_benefit, expense fields
- Amount fields use implied_decimal format with scale: 2
- Number of service codes field indicates repetitions

### record_5.yml (Claim Record - Reversal)
- Same structure as record_4 but identifier '5'
- Includes trans_cross_reference to original claim

### record_6.yml (Provider Batch Control/Trailer)
- Fields: record_identifier, record_count, claim_amount, reversal_amount, adjustment_amount, total_amount_payable

### record_7.yml (Client Batch Control/Trailer)
- Same structure as record_6 but for client batches

### record_8.yml (File Batch Control/Trailer)
- File-level control totals similar to provider/client trailers

## 5. Create Health Batch Schema
Create `schemas/health_batch.schema.json`:
- Copy from `dental_batch.schema.json`
- Update `$id` to reference health-batch
- Update title to "ESC Health Feed Batch"
- Same structure: feedName, batchType (file_header, provider, client, file_trailer), header, details, trailer, metadata

## 6. Test Execution
Run the parser with health feed config:
```bash
dotnet run --project ExperienceModule -- --feed Config/health_feed.yml --input Input/health_sample.txt --output Output/health_batches_test.jsonl
```
Expected output:
- Parse ~1591 records from sample file
- Generate JSONL with provider and client batches
- Validate against health_batch.schema.json

## 7. Output Validation
- Verify output file `Output/health_batches_test.jsonl` is created
- Check batch structure matches schema
- Validate provider batches contain header (type 2), details (types 4,5), trailer (type 6)
- Validate client batches contain header (type 3), details (types 4,5), trailer (type 7)
- Confirm file_header and file_trailer batches present

## 8. Documentation
- Save this plan content to `DevPlan/HealthFeedImplementation.md` alongside existing Dental documentation

## Implementation Notes
- Program.cs is already generic and doesn't require changes
- Health terminology: "provider" not "dentist", "service" not "procedure"
- Record length and format identical to dental (4561 bytes, fixed-width ASCII)
- Amount fields consistently use 2-decimal implied format
- Field names should match Health spec terminology (provider vs dentist, service vs procedure)
