# Record Type 6 – Provider Batch Control Record

## Module Coverage
- **Health**: Provider Batch Control Record
- **Pharmacy**: Pharmacy Batch Control Record
- **Dental**: Provider Batch Control Record
- **DentalPreD**: Provider Batch Control Record

| S.No | Field Name | Health Applicable | Health Field # | Health Format | Pharmacy Applicable | Pharmacy Field # | Pharmacy Format | Dental Applicable | Dental Field # | Dental Format | DentalPreD Applicable | DentalPreD Field # | DentalPreD Format |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 1 | Record Identifier | ✓ | 001 | 9(1) |  |  |  | ✓ | 001 | 9(1) | ✓ | 001 | 9(1) |
| 2 | Record Count | ✓ | 002 | 9(6) | ✓ | 002 | 9(6) | ✓ | 002 | 9(6) | ✓ | 002 | 9(6) |
| 3 | Filler | ✓ | 008 | X(4455) | ✓ | 005 | X(722) | ✓ | 008 | X(4455) | ✓ | 006 | X(1160) |
| 4 | Claim Amount | ✓ | 004 | 9(8,2) |  |  |  | ✓ | 004 | 9(8,2) | ✓ | 004 | 9(8,2) |
| 5 | Reversal Amount | ✓ | 005 | 9(8,2) |  |  |  | ✓ | 005 | 9(8,2) |  |  |  |
| 6 | Adjustment Amount | ✓ | 006 | s9(8,2) |  |  |  | ✓ | 006 | s9(8,2) |  |  |  |
| 7 | Total Amount Payable | ✓ | 007 | s9(9,2) |  |  |  | ✓ | 007 | s9(9,2) |  |  |  |
| 8 | Record Type |  |  |  | ✓ | 001 | 9(1) |  |  |  |  |  |  |
| 9 | Sum of Total Amount |  |  |  | ✓ | 003 | 9(6)V99 |  |  |  |  |  |  |
| 10 | Hash Total |  |  |  | ✓ | 004 | 9(6)V99 |  |  |  |  |  |  |
| 11 | Paid Amount |  |  |  |  |  |  |  |  |  | ✓ | 005 | 9(8,2) |
