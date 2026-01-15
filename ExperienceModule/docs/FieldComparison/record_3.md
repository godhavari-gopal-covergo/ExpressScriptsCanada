# Record Type 3 – Client Address Record

## Module Coverage
- **Health**: Client Address Record
- **Pharmacy**: Payee Address Record
- **Dental**: Client Address Record
- **DentalPreD**: Client Address Record

| S.No | Field Name | Health Applicable | Health Field # | Health Format | Pharmacy Applicable | Pharmacy Field # | Pharmacy Format | Dental Applicable | Dental Field # | Dental Format | DentalPreD Applicable | DentalPreD Field # | DentalPreD Format |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 1 | Record Identifier | ✓ | 001 | 9(1) |  |  |  | ✓ | 001 | 9(1) | ✓ | 001 | 9(1) |
| 2 | Client ID | ✓ | 002 | X(15) | ✓ | 002 | X(15) | ✓ | 002 | X(15) | ✓ | 002 | X(15) |
| 3 | Client Last Name | ✓ | 003 | X(30) |  |  |  | ✓ | 003 | X(30) | ✓ | 003 | X(30) |
| 4 | Client First Name | ✓ | 004 | X(30) |  |  |  | ✓ | 004 | X(30) | ✓ | 004 | X(30) |
| 5 | Client Address Line 1 | ✓ | 005 | X(35) |  |  |  | ✓ | 005 | X(35) | ✓ | 005 | X(35) |
| 6 | Client Address Line 2 | ✓ | 006 | X(35) |  |  |  | ✓ | 006 | X(35) | ✓ | 006 | X(35) |
| 7 | Client City | ✓ | 007 | X(35) |  |  |  | ✓ | 007 | X(35) | ✓ | 007 | X(35) |
| 8 | Client Province | ✓ | 008 | X(2) |  |  |  | ✓ | 008 | X(2) | ✓ | 008 | X(2) |
| 9 | Client Country | ✓ | 009 | X(15) |  |  |  | ✓ | 009 | X(15) | ✓ | 009 | X(15) |
| 10 | Client Postal Code | ✓ | 010 | X(9) |  |  |  | ✓ | 010 | X(9) | ✓ | 010 | X(9) |
| 11 | Client EFT Route Code | ✓ | 011 | X(9) |  |  |  | ✓ | 011 | X(9) |  |  |  |
| 12 | Client EFT Account Number | ✓ | 012 | X(12) |  |  |  | ✓ | 012 | X(12) |  |  |  |
| 13 | Client Address Change Flag | ✓ | 013 | X(1) | ✓ | 011 | X(1) | ✓ | 013 | X(1) |  |  |  |
| 14 | GSAS | ✓ | 014 | X(19) | ✓ | 012 | X(19) | ✓ | 014 | X(19) | ✓ | 011 | X(19) |
| <span style="background-color:#ffe6e6;color:#a30000;">15</span> | <span style="background-color:#ffe6e6;color:#a30000;">Payee Last Name</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">015</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(30)</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">003</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(15)</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">015</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(30)</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> |
| <span style="background-color:#ffe6e6;color:#a30000;">16</span> | <span style="background-color:#ffe6e6;color:#a30000;">Payee First Name</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">016</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(30)</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">004</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(12)</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">016</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(30)</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> |
| <span style="background-color:#ffe6e6;color:#a30000;">17</span> | <span style="background-color:#ffe6e6;color:#a30000;">Payee Address Line 1</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">017</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(35)</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">005</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(30)</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">017</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(35)</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> |
| <span style="background-color:#ffe6e6;color:#a30000;">18</span> | <span style="background-color:#ffe6e6;color:#a30000;">Payee Address Line 2</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">018</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(35)</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">006</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(30)</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">018</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(35)</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> |
| <span style="background-color:#ffe6e6;color:#a30000;">19</span> | <span style="background-color:#ffe6e6;color:#a30000;">Payee City</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">019</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(35)</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">007</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(15)</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">019</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(35)</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> |
| 20 | Payee Province | ✓ | 020 | X(2) |  |  |  | ✓ | 020 | X(2) |  |  |  |
| 21 | Payee Country | ✓ | 021 | X(15) | ✓ | 009 | X(15) | ✓ | 021 | X(15) |  |  |  |
| 22 | Payee Postal Code | ✓ | 022 | X(9) | ✓ | 010 | X(9) | ✓ | 022 | X(9) |  |  |  |
| 23 | Filler | ✓ | 023 | X(4122) | ✓ | 015 | X(405) | ✓ | 023 | X(4122) | ✓ | 012 | X(1021) |
| 24 | Record Type |  |  |  | ✓ | 001 | 9(1) |  |  |  |  |  |  |
| 25 | Payee Province (USState) |  |  |  | ✓ | 008 | X(2) |  |  |  |  |  |  |
| 26 | Alternate Identification |  |  |  | ✓ | 014 | X(16) |  |  |  |  |  |  |
