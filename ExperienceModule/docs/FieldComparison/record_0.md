# Record Type 0 – File Header Record

## Module Coverage
- **Health**: File Header Record
- **Pharmacy**: File Header Record
- **Dental**: File Header Record
- **DentalPreD**: Processor Header Record

| S.No | Field Name | Health Applicable | Health Field # | Health Format | Pharmacy Applicable | Pharmacy Field # | Pharmacy Format | Dental Applicable | Dental Field # | Dental Format | DentalPreD Applicable | DentalPreD Field # | DentalPreD Format |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 1 | Record Identifier | ✓ | 001 | 9(1) |  |  |  | ✓ | 001 | 9(1) | ✓ | 001 | 9(1) |
| 2 | Issuer Identifier Number | ✓ | 002 | 9(6) | ✓ | 002 | 9(6) | ✓ | 002 | 9(6) | ✓ | 002 | 9(6) |
| 3 | Issuer Identifier Name | ✓ | 003 | X(20) | ✓ | 003 | X(20) | ✓ | 003 | X(20) | ✓ | 003 | X(20) |
| 4 | Destination Name | ✓ | 004 | X(20) | ✓ | 004 | X(20) | ✓ | 004 | X(20) | ✓ | 004 | X(20) |
| 5 | Destination Address | ✓ | 005 | X(30) | ✓ | 005 | X(30) | ✓ | 005 | X(30) | ✓ | 005 | X(30) |
| 6 | Destination City | ✓ | 006 | X(15) | ✓ | 006 | X(15) | ✓ | 006 | X(15) | ✓ | 006 | X(15) |
| 7 | Destination Province | ✓ | 007 | X(2) | ✓ | 007 | X(2) | ✓ | 007 | X(2) | ✓ | 007 | X(2) |
| 8 | Destination Postal Code | ✓ | 008 | X(6) | ✓ | 008 | X(6) | ✓ | 008 | X(6) | ✓ | 008 | X(6) |
| 9 | Destination Telephone Number | ✓ | 009 | 9(10) | ✓ | 009 | 9(10) | ✓ | 009 | 9(10) | ✓ | 009 | 9(10) |
| 10 | Run Date | ✓ | 010 | 9(8) | ✓ | 010 | 9(8) | ✓ | 010 | 9(8) | ✓ | 010 | 9(8) |
| 11 | Transmittal Sequence No. | ✓ | 011 | 9(3) | ✓ | 012 | 9(3) | ✓ | 011 | 9(3) | ✓ | 011 | 9(3) |
| 12 | Cut-off Date | ✓ | 012 | 9(8) | ✓ | 011 | 9(8) | ✓ | 012 | 9(8) | ✓ | 012 | 9(8) |
| 13 | Filler | ✓ | 015 | X(4248) | ✓ | 014 | X(619) | ✓ | 015 | X(4248) | ✓ | 015 | X(934) |
| 14 | Program Version | ✓ | 014 | X(128) |  |  |  | ✓ | 014 | X(128) | ✓ | 014 | X(128) |
| 15 | Record Type |  |  |  | ✓ | 001 | 9(1) |  |  |  |  |  |  |
| 16 | Version Number |  |  |  | ✓ | 013 | 9(2) |  |  |  |  |  |  |
