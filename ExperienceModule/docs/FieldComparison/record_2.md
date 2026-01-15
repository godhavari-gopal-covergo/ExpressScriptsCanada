# Record Type 2 – Provider Header Record

## Module Coverage
- **Health**: Provider Header Record
- **Pharmacy**: Pharmacy Header Record
- **Dental**: Provider Header Record
- **DentalPreD**: Provider Header Record

| S.No | Field Name | Health Applicable | Health Field # | Health Format | Pharmacy Applicable | Pharmacy Field # | Pharmacy Format | Dental Applicable | Dental Field # | Dental Format | DentalPreD Applicable | DentalPreD Field # | DentalPreD Format |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 1 | Record Identifier | ✓ | 001 | 9(1) |  |  |  | ✓ | 001 | 9(1) | ✓ | 001 | 9(1) |
| 2 | Provider Number | ✓ | 002 | X(9) |  |  |  | ✓ | 002 | X(9) | ✓ | 002 | X(9) |
| 3 | Provider Office | ✓ | 003 | X(4) |  |  |  | ✓ | 003 | X(4) | ✓ | 003 | X(4) |
| 4 | Provider Surname | ✓ | 004 | X(30) |  |  |  |  |  |  |  |  |  |
| 5 | Provider First Name | ✓ | 005 | X(30) |  |  |  |  |  |  |  |  |  |
| 6 | Provider Name | ✓ | 006 | X(30) |  |  |  | ✓ | 006 | X(30) | ✓ | 006 | X(30) |
| 7 | Provider Address Line 1 | ✓ | 007 | X(40) |  |  |  | ✓ | 007 | X(40) | ✓ | 007 | X(40) |
| 8 | Provider Address Line 2 | ✓ | 008 | X(40) |  |  |  | ✓ | 008 | X(40) | ✓ | 008 | X(40) |
| 9 | Provider Address Line 3 | ✓ | 009 | X(40) |  |  |  | ✓ | 009 | X(40) | ✓ | 009 | X(40) |
| 10 | Provider City | ✓ | 010 | X(35) |  |  |  | ✓ | 010 | X(35) | ✓ | 010 | X(35) |
| 11 | Provider Province | ✓ | 011 | X(2) |  |  |  | ✓ | 011 | X(2) | ✓ | 011 | X(2) |
| 12 | Provider Country | ✓ | 012 | X(15) |  |  |  | ✓ | 012 | X(15) | ✓ | 012 | X(15) |
| 13 | Provider Postal Code | ✓ | 013 | X(6) |  |  |  | ✓ | 013 | X(6) | ✓ | 013 | X(6) |
| 14 | Provider Telephone Number | ✓ | 014 | 9(10) |  |  |  | ✓ | 014 | 9(10) | ✓ | 014 | 9(10) |
| 15 | Provider Language Flag | ✓ | 015 | X(1) |  |  |  | ✓ | 015 | X(1) | ✓ | 015 | X(1) |
| 16 | Provider EFT Route Code | ✓ | 016 | X(9) |  |  |  | ✓ | 016 | X(9) |  |  |  |
| 17 | Provider EFT Account Number | ✓ | 017 | X(12) |  |  |  | ✓ | 017 | X(12) |  |  |  |
| 18 | Filler | ✓ | 018 | X(4247) | ✓ | 016 | X(552) | ✓ | 018 | X(4247) | ✓ | 016 | X(954) |
| 19 | Record Type |  |  |  | ✓ | 001 | 9(1) |  |  |  |  |  |  |
| 20 | Pharmacy Number |  |  |  | ✓ | 002 | X(10) |  |  |  |  |  |  |
| 21 | Pharmacy Name |  |  |  | ✓ | 003 | X(30) |  |  |  |  |  |  |
| 22 | Pharmacy Address Line 1 |  |  |  | ✓ | 004 | X(35) |  |  |  |  |  |  |
| 23 | Pharmacy Address Line 2 |  |  |  | ✓ | 005 | X(35) |  |  |  |  |  |  |
| 24 | Pharmacy Address Line 3 |  |  |  | ✓ | 006 | X(35) |  |  |  |  |  |  |
| 25 | Pharmacy Province |  |  |  | ✓ | 007 | X(2) |  |  |  |  |  |  |
| 26 | Pharmacy Postal Code |  |  |  | ✓ | 008 | X(6) |  |  |  |  |  |  |
| 27 | Pharmacy Telephone Number |  |  |  | ✓ | 009 | 9(10) |  |  |  |  |  |  |
| 28 | Pharmacy Language Flag |  |  |  | ✓ | 010 | X(1) |  |  |  |  |  |  |
| 29 | Pharmacy Pay Direction Flag |  |  |  | ✓ | 011 | X(1) |  |  |  |  |  |  |
| 30 | Pharmacy Chain Number |  |  |  | ✓ | 012 | X(10) |  |  |  |  |  |  |
| 31 | ESC Canada Pharmacy Flag |  |  |  | ✓ | 013 | X(1) |  |  |  |  |  |  |
| 32 | Pharmacy EFT Route Code |  |  |  | ✓ | 014 | X(9) |  |  |  |  |  |  |
| 33 | Pharmacy EFT Account Number |  |  |  | ✓ | 015 | X(12) |  |  |  |  |  |  |
| 34 | Dentist Surname |  |  |  |  |  |  | ✓ | 004 | X(30) | ✓ | 004 | X(30) |
| 35 | Dentist First Name |  |  |  |  |  |  | ✓ | 005 | X(30) | ✓ | 005 | X(30) |
