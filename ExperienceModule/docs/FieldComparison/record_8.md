# Record Type 8 – File Batch Control Record

## Module Coverage
- **Health**: File Batch Control Record
- **Pharmacy**: File Batch Control Record
- **Dental**: File Batch Control Record
- **DentalPreD**: Tape Batch Control Record

| S.No | Field Name | Health Applicable | Health Field # | Health Format | Pharmacy Applicable | Pharmacy Field # | Pharmacy Format | Dental Applicable | Dental Field # | Dental Format | DentalPreD Applicable | DentalPreD Field # | DentalPreD Format |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 1 | Record Identifier | ✓ | 001 | 9(1) |  |  |  | ✓ | 001 | 9(1) | ✓ | 001 | 9(1) |
| 2 | Issuer Identifier Number | ✓ | 002 | 9(6) | ✓ | 002 | 9(6) | ✓ | 002 | 9(6) | ✓ | 002 | 9(6) |
| 3 | Record Count | ✓ | 003 | 9(8) | ✓ | 003 | 9(8) | ✓ | 003 | 9(8) | ✓ | 003 | 9(8) |
| 4 | Filler | ✓ | 009 | X(4438) | ✓ | 005 | X(726) | ✓ | 009 | X(4438) | ✓ | 007 | X(1148) |
| 5 | Claim Amount | ✓ | 005 | 9(10,2) |  |  |  | ✓ | 005 | 9(10,2) | ✓ | 005 | 9(10,2) |
| 6 | Reversal Amount | ✓ | 006 | 9(10,2) |  |  |  | ✓ | 006 | 9(10,2) |  |  |  |
| 7 | Adjustment Amount | ✓ | 007 | s9(10,2) |  |  |  | ✓ | 007 | s9(10,2) |  |  |  |
| 8 | Total Amount Payable | ✓ | 008 | s9(12,2) |  |  |  | ✓ | 008 | s9(12,2) |  |  |  |
| 9 | Record Type |  |  |  | ✓ | 001 | 9(1) |  |  |  |  |  |  |
| 10 | Grand Total |  |  |  | ✓ | 004 | 9(8)V99 |  |  |  |  |  |  |
| 11 | Paid Amount |  |  |  |  |  |  |  |  |  | ✓ | 006 | 9(10,2) |
