# Record Type 5 – Claim Record (Reversal)

## Module Coverage
- **Health**: Claim Record (Reversal)
- **Pharmacy**: Claim Record (Reversal)
- **Dental**: Claim Record (Reversal)
- **DentalPreD**: Predetermination Detail Record

| S.No | Field Name | Health Applicable | Health Field # | Health Format | Pharmacy Applicable | Pharmacy Field # | Pharmacy Format | Dental Applicable | Dental Field # | Dental Format | DentalPreD Applicable | DentalPreD Field # | DentalPreD Format |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 1 | Record Identifier | ✓ | 001 | 9(1) |  |  |  | ✓ | 001 | 9(1) | ✓ | 001 | 9(1) |
| 2 | Trans Reference # | ✓ | 002 | X(14) |  |  |  | ✓ | 002 | X(14) |  |  |  |
| 3 | Trans Cross reference # | ✓ | 003 | X(14) |  |  |  | ✓ | 003 | X(14) |  |  |  |
| 4 | Office Sequence # | ✓ | 004 | X(6) |  |  |  | ✓ | 004 | X(6) |  |  |  |
| 5 | Date Claim Received | ✓ | 005 | 9(8) |  |  |  | ✓ | 005 | 9(8) |  |  |  |
| 6 | Date Processed/Adjudicated | ✓ | 006 | 9(8) | ✓ | 005 | 9(8) | ✓ | 006 | 9(8) |  |  |  |
| <span style="background-color:#ffe6e6;color:#a30000;">7</span> | <span style="background-color:#ffe6e6;color:#a30000;">Claim Status</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">007</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(1)</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">006</span> | <span style="background-color:#ffe6e6;color:#a30000;">9(1)</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">007</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(1)</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> |
| 8 | Client Language Flag | ✓ | 008 | X(1) | ✓ | 008 | X(1) | ✓ | 008 | X(1) |  |  |  |
| 9 | Provider Number | ✓ | 009 | X(9) |  |  |  | ✓ | 009 | X(9) |  |  |  |
| 10 | Provider Surname | ✓ | 010 | X(30) |  |  |  | ✓ | 010 | X(30) |  |  |  |
| 11 | Provider First Name | ✓ | 011 | X(30) |  |  |  | ✓ | 011 | X(30) |  |  |  |
| 12 | Filler | ✓ | 113 | X(200) | ✓ | 123 | X(3) | ✓ | 113 | X(200) | ✓ | 047 | X(878) |
| 13 | Provider office location # | ✓ | 013 | X(4) |  |  |  | ✓ | 013 | X(4) |  |  |  |
| 14 | Provider Province | ✓ | 014 | X(2) |  |  |  | ✓ | 014 | X(2) |  |  |  |
| 15 | Provider software vendor code | ✓ | 015 | X(3) |  |  |  | ✓ | 015 | X(3) |  |  |  |
| 16 | Provider Specialty | ✓ | 016 | X(2) |  |  |  | ✓ | 016 | X(2) |  |  |  |
| 17 | Pend Date | ✓ | 018 | 9(8) |  |  |  | ✓ | 018 | 9(8) |  |  |  |
| 18 | Pending reason | ✓ | 019 | X(2) |  |  |  | ✓ | 019 | X(2) |  |  |  |
| <span style="background-color:#ffe6e6;color:#a30000;">19</span> | <span style="background-color:#ffe6e6;color:#a30000;">Client Last Name</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">020</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(30)</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">020</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(15)</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">020</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(30)</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> |
| <span style="background-color:#ffe6e6;color:#a30000;">20</span> | <span style="background-color:#ffe6e6;color:#a30000;">Client First Name</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">021</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(30)</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">021</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(12)</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">021</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(30)</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> |
| <span style="background-color:#ffe6e6;color:#a30000;">21</span> | <span style="background-color:#ffe6e6;color:#a30000;">Patient Last Name</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">022</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(30)</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">022</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(15)</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">022</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(30)</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> |
| <span style="background-color:#ffe6e6;color:#a30000;">22</span> | <span style="background-color:#ffe6e6;color:#a30000;">Patient First Name</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">023</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(30)</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">023</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(12)</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">023</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(30)</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> |
| 23 | Patient Date of Birth | ✓ | 024 | 9(8) | ✓ | 024 | 9(8) | ✓ | 024 | 9(8) |  |  |  |
| 24 | Sex of Patient | ✓ | 025 | X(1) | ✓ | 025 | X(1) | ✓ | 025 | X(1) |  |  |  |
| 25 | Carrier ID | ✓ | 026 | 9(2) |  |  |  | ✓ | 026 | 9(2) |  |  |  |
| 26 | GSAS | ✓ | 027 | X(19) | ✓ | 027 | X(19) | ✓ | 027 | X(19) |  |  |  |
| 27 | Client ID | ✓ | 028 | X(15) | ✓ | 028 | X(15) | ✓ | 028 | X(15) |  |  |  |
| 28 | Patient Code | ✓ | 029 | X(3) | ✓ | 029 | X(3) | ✓ | 029 | X(3) |  |  |  |
| 29 | Patient Relationship Code | ✓ | 030 | 9(1) | ✓ | 030 | 9(1) | ✓ | 030 | 9(1) |  |  |  |
| 30 | Operator id | ✓ | 031 | X(8) |  |  |  | ✓ | 031 | X(8) |  |  |  |
| 31 | Operator Code | ✓ | 032 | X(5) |  |  |  | ✓ | 032 | X(5) |  |  |  |
| 32 | Claim submission method | ✓ | 033 | X(1) |  |  |  | ✓ | 033 | X(1) |  |  |  |
| 33 | Payee Code | ✓ | 034 | 9(1) | ✓ | 073 | 9(1) | ✓ | 034 | 9(1) |  |  |  |
| 34 | Payment Method | ✓ | 035 | 9(1) | ✓ | 074 | 9(1) | ✓ | 035 | 9(1) |  |  |  |
| 35 | Total amt claimed | ✓ | 036 | 9(7,2) |  |  |  | ✓ | 036 | 9(7,2) |  |  |  |
| 36 | Adjustment amount | ✓ | 037 | S(6,2) |  |  |  | ✓ | 037 | S(6,2) |  |  |  |
| 37 | Adjustment reason | ✓ | 038 | X(2) |  |  |  | ✓ | 038 | X(2) |  |  |  |
| 38 | Total amt paid | ✓ | 039 | 9(7,2) |  |  |  | ✓ | 039 | 9(7,2) |  |  |  |
| 39 | CDA/ACDQ error codes | ✓ | 040 | X(12) |  |  |  | ✓ | 040 | X(12) |  |  |  |
| 40 | ESI Messages | ✓ | 092 | X(12) |  |  |  | ✓ | 092 | X(12) | ✓ | 026 | X(12) |
| 41 | Material forwarded | ✓ | 042 | X(1) |  |  |  | ✓ | 042 | X(1) |  |  |  |
| 42 | School name | ✓ | 043 | X(25) |  |  |  | ✓ | 043 | X(25) |  |  |  |
| 43 | Secondary coverage | ✓ | 044 | X(1) |  |  |  | ✓ | 044 | X(1) |  |  |  |
| 44 | Accident date | ✓ | 045 | 9(8) |  |  |  | ✓ | 045 | 9(8) |  |  |  |
| 45 | Predetermination Number | ✓ | 046 | X(14) |  |  |  | ✓ | 046 | X(14) |  |  |  |
| 46 | Line of business code | ✓ | 047 | X(3) |  |  |  | ✓ | 047 | X(3) |  |  |  |
| <span style="background-color:#ffe6e6;color:#a30000;">47</span> | <span style="background-color:#ffe6e6;color:#a30000;">Attachment code</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">048</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(1)</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">111</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(3)</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">048</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(1)</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> |
| 48 | Letter code | ✓ | 049 | X(3) |  |  |  | ✓ | 049 | X(3) |  |  |  |
| 49 | General Code GSAS | ✓ | 050 | X(10) |  |  |  | ✓ | 050 | X(10) |  |  |  |
| 50 | General Code Client | ✓ | 051 | X(1) |  |  |  | ✓ | 051 | X(1) |  |  |  |
| 51 | Distribution Code | ✓ | 052 | X(1) |  |  |  | ✓ | 052 | X(1) |  |  |  |
| 52 | Free Form Message | ✓ | 053 | X(480) |  |  |  | ✓ | 053 | X(480) |  |  |  |
| 53 | Number of service codes on this record | ✓ | 054 | X(2) |  |  |  |  |  |  |  |  |  |
| 54 | Client Address Line 1 | ✓ | 055 | X(35) |  |  |  | ✓ | 055 | X(35) |  |  |  |
| 55 | Client Address Line 2 | ✓ | 056 | X(35) |  |  |  | ✓ | 056 | X(35) |  |  |  |
| 56 | Client City | ✓ | 057 | X(35) |  |  |  | ✓ | 057 | X(35) |  |  |  |
| 57 | Client Province | ✓ | 058 | X(2) |  |  |  | ✓ | 058 | X(2) |  |  |  |
| 58 | Client Country | ✓ | 059 | X(15) |  |  |  | ✓ | 059 | X(15) |  |  |  |
| 59 | Client Postal Code | ✓ | 060 | X(9) |  |  |  | ✓ | 060 | X(9) |  |  |  |
| 60 | Override Indicator | ✓ | 061 | X(1) |  |  |  | ✓ | 061 | X(1) |  |  |  |
| 61 | Supress EOB | ✓ | 062 | X(1) |  |  |  | ✓ | 062 | X(1) |  |  |  |
| 62 | Submitted line # | ✓ | 064 | X(6) |  |  |  | ✓ | 064 | X(6) |  |  |  |
| 63 | Paid line # | ✓ | 065 | 9(2) |  |  |  | ✓ | 065 | 9(2) |  |  |  |
| 64 | Service status | ✓ | 066 | X(1) |  |  |  |  |  |  |  |  |  |
| 65 | Adjudication Rule number applied | ✓ | 067 | 9(5) |  |  |  | ✓ | 067 | 9(5) | ✓ | 005 | 9(5) |
| 66 | Frequency Rule number applied | ✓ | 068 | 9(5) |  |  |  | ✓ | 068 | 9(5) | ✓ | 006 | 9(5) |
| 67 | Date of service | ✓ | 069 | 9(8) | ✓ | 012 | 9(8) | ✓ | 069 | 9(8) |  |  |  |
| 68 | Service code | ✓ | 070 | X(5) |  |  |  |  |  |  |  |  |  |
| 69 | Service name Eng | ✓ | 072 | X(35) |  |  |  |  |  |  |  |  |  |
| 70 | Service name Fre | ✓ | 073 | X(35) |  |  |  |  |  |  |  |  |  |
| 71 | Tooth code | ✓ | 074 | 9(2) |  |  |  | ✓ | 074 | 9(2) | ✓ | 010 | 9(2) |
| 72 | Tooth surface | ✓ | 075 | X(5) |  |  |  | ✓ | 075 | X(5) | ✓ | 011 | X(5) |
| 73 | Professional fee claimed | ✓ | 076 | 9(6,2) |  |  |  | ✓ | 076 | 9(6,2) | ✓ | 012 | 9(6,2) |
| 74 | Previously paid amount | ✓ | 077 | 9(6,2) |  |  |  | ✓ | 077 | 9(6,2) |  |  |  |
| 75 | Professional fee eligible amount | ✓ | 078 | 9(6,2) |  |  |  | ✓ | 078 | 9(6,2) | ✓ | 013 | 9(6,2) |
| 76 | Deductible amount professional fee | ✓ | 079 | 9(6,2) |  |  |  | ✓ | 079 | 9(6,2) | ✓ | 014 | 9(6,2) |
| 77 | Professional Fee Benefit amount | ✓ | 080 | 9(6,2) |  |  |  | ✓ | 080 | 9(6,2) | ✓ | 015 | 9(6,2) |
| 78 | Lab service code | ✓ | 081 | X(5) |  |  |  |  |  |  |  |  |  |
| 79 | Lab fee claimed | ✓ | 082 | 9(6,2) |  |  |  | ✓ | 082 | 9(6,2) | ✓ | 017 | 9(6,2) |
| 80 | Eligible amount lab | ✓ | 083 | 9(6,2) |  |  |  | ✓ | 083 | 9(6,2) | ✓ | 018 | 9(6,2) |
| 81 | Lab Deductible amount | ✓ | 084 | 9(6.2) |  |  |  | ✓ | 084 | 9(6.2) | ✓ | 019 | 9(6.2) |
| 82 | Lab Benefit amount | ✓ | 085 | 9(6,2) |  |  |  | ✓ | 085 | 9(6,2) | ✓ | 020 | 9(6,2) |
| 83 | Expense service code | ✓ | 086 | X(5) |  |  |  |  |  |  |  |  |  |
| 84 | Expense claimed | ✓ | 087 | 9(6,2) |  |  |  | ✓ | 087 | 9(6,2) | ✓ | 022 | 9(6,2) |
| 85 | Expense Eligible amount | ✓ | 088 | 9(6,2) |  |  |  | ✓ | 088 | 9(6,2) | ✓ | 023 | 9(6,2) |
| 86 | Expense Deductible amount | ✓ | 089 | 9(6.2) |  |  |  | ✓ | 089 | 9(6.2) | ✓ | 024 | 9(6.2) |
| 87 | Expense Benefit amount | ✓ | 090 | 9(6,2) |  |  |  | ✓ | 090 | 9(6,2) | ✓ | 025 | 9(6,2) |
| 88 | CDA/ACDQ error code | ✓ | 091 | X(12) |  |  |  | ✓ | 091 | X(12) |  |  |  |
| 89 | Total fees claimed | ✓ | 093 | 9(7,2) |  |  |  | ✓ | 093 | 9(7,2) | ✓ | 027 | 9(7,2) |
| 90 | Coinsurance amount | ✓ | 094 | 9(6,2) |  |  |  | ✓ | 094 | 9(6,2) | ✓ | 028 | 9(6,2) |
| 91 | Coinsurance percentage | ✓ | 095 | 9(3) |  |  |  | ✓ | 095 | 9(3) | ✓ | 029 | 9(3) |
| 92 | Total fees paid | ✓ | 096 | 9(6,2) |  |  |  | ✓ | 096 | 9(6,2) | ✓ | 030 | 9(6,2) |
| 93 | Paid service code 1 | ✓ | 097 | X(5) |  |  |  |  |  |  |  |  |  |
| 94 | Paid service code 2 | ✓ | 098 | X(5) |  |  |  |  |  |  |  |  |  |
| 95 | Plan number | ✓ | 100 | X(5) |  |  |  | ✓ | 100 | X(5) | ✓ | 034 | X(5) |
| <span style="background-color:#ffe6e6;color:#a30000;">96</span> | <span style="background-color:#ffe6e6;color:#a30000;">Benefit code</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">101</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(5)</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> | <span style="background-color:#ffe6e6;color:#a30000;">&nbsp;</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">101</span> | <span style="background-color:#ffe6e6;color:#a30000;">X(5)</span> | <span style="background-color:#ffe6e6;color:#a30000;">✓</span> | <span style="background-color:#ffe6e6;color:#a30000;">035</span> | <span style="background-color:#ffe6e6;color:#a30000;">9(5)</span> |
| 97 | Category code | ✓ | 102 | X(2) |  |  |  | ✓ | 102 | X(2) | ✓ | 036 | X(2) |
| 98 | Category label Eng | ✓ | 103 | X(40) |  |  |  | ✓ | 103 | X(40) | ✓ | 038 | X(40) |
| 99 | Category label Fre | ✓ | 104 | X(40) |  |  |  | ✓ | 104 | X(40) |  |  |  |
| 100 | Coverage code from eligibility | ✓ | 105 | X(2) |  |  |  | ✓ | 105 | X(2) | ✓ | 039 | X(2) |
| 101 | Carrier dental field | ✓ | 106 | X(10) |  |  |  | ✓ | 106 | X(10) | ✓ | 040 | X(10) |
| 102 | Service code source | ✓ | 107 | X(4) |  |  |  |  |  |  |  |  |  |
| 103 | Maximum cutback amount | ✓ | 108 | 9(6,2) |  |  |  | ✓ | 108 | 9(6,2) | ✓ | 042 | 9(6,2) |
| 104 | Rule Cutback amount | ✓ | 109 | 9(6.2) |  |  |  | ✓ | 109 | 9(6.2) | ✓ | 043 | 9(6.2) |
| 105 | Fee guide amount | ✓ | 110 | 9(6,2) |  |  |  | ✓ | 110 | 9(6,2) | ✓ | 044 | 9(6,2) |
| 106 | End of occurs | ✓ | 112 | - |  |  |  | ✓ | 112 | - |  |  |  |
| 107 | Record Type |  |  |  | ✓ | 001 | 9(1) |  |  |  |  |  |  |
| 108 | VCS Assigned Claim Reference # |  |  |  | ✓ | 002 | X(10) |  |  |  |  |  |  |
| 109 | Pharmacy Trace # |  |  |  | ✓ | 003 | X(6) |  |  |  |  |  |  |
| 110 | Date Claim Received at ESC Canada |  |  |  | ✓ | 004 | 9(8) |  |  |  |  |  |  |
| 111 | Communications Flag |  |  |  | ✓ | 007 | 9(1) |  |  |  |  |  |  |
| 112 | Pharmacy Number |  |  |  | ✓ | 009 | X(10) |  |  |  |  |  |  |
| 113 | Prescription Number |  |  |  | ✓ | 010 | X(7) |  |  |  |  |  |  |
| 114 | Current Rx # |  |  |  | ✓ | 011 | X(7) |  |  |  |  |  |  |
| 115 | Drug Code (DIN#)/GP#/Compound Code |  |  |  | ✓ | 013 | X(8) |  |  |  |  |  |  |
| 116 | Drug Description(English) |  |  |  | ✓ | 014 | X(30) |  |  |  |  |  |  |
| 117 | Drug Description(French) |  |  |  | ✓ | 015 | X(30) |  |  |  |  |  |  |
| 118 | New/Refill Code (CPhA Version 2) |  |  |  | ✓ | 016 | 9(2) |  |  |  |  |  |  |
| 119 | Major Compound Ingredient |  |  |  | ✓ | 017 | 9(8) |  |  |  |  |  |  |
| 120 | Metric Quantity |  |  |  | ✓ | 018 | 9(5) |  |  |  |  |  |  |
| 121 | Days Supply |  |  |  | ✓ | 019 | 9(3) |  |  |  |  |  |  |
| 122 | Customer ID/Major Account ID |  |  |  | ✓ | 026 | 9(2) |  |  |  |  |  |  |
| 123 | Product Selection Code |  |  |  | ✓ | 031 | X(1) |  |  |  |  |  |  |
| 124 | Submitted Ingredient Cost |  |  |  | ✓ | 032 | 9(4)V99 |  |  |  |  |  |  |
| 125 | Submitted Cost Up Charge |  |  |  | ✓ | 033 | 9(4)V99 |  |  |  |  |  |  |
| 126 | Submitted Provincial Tax |  |  |  | ✓ | 034 | 9(4)V99 |  |  |  |  |  |  |
| 127 | Submitted GST |  |  |  | ✓ | 035 | 9(4)V99 |  |  |  |  |  |  |
| 128 | Submitted Professional Fee |  |  |  | ✓ | 036 | 9(4)V99 |  |  |  |  |  |  |
| 129 | Submitted Generic Incentive |  |  |  | ✓ | 037 | 9(4)V99 |  |  |  |  |  |  |
| 130 | Submitted Special Services Fee |  |  |  | ✓ | 038 | 9(4)V99 |  |  |  |  |  |  |
| 131 | Submitted Compounding Fee |  |  |  | ✓ | 039 | 9(4)V99 |  |  |  |  |  |  |
| 132 | Submitted Copay |  |  |  | ✓ | 040 | 9(4)V99 |  |  |  |  |  |  |
| 133 | Submitted Coinsurance |  |  |  | ✓ | 041 | 9(4)V99 |  |  |  |  |  |  |
| 134 | Submitted Total Amount Claimed |  |  |  | ✓ | 042 | 9(4)V99 |  |  |  |  |  |  |
| 135 | Payable Ingredient Cost |  |  |  | ✓ | 043 | 9(4)V99 |  |  |  |  |  |  |
| 136 | Payable Cost Up Charge |  |  |  | ✓ | 044 | 9(4)V99 |  |  |  |  |  |  |
| 137 | Payable Provincial Sales Tax |  |  |  | ✓ | 045 | 9(4)V99 |  |  |  |  |  |  |
| 138 | Payable GST Tax |  |  |  | ✓ | 046 | 9(4)V99 |  |  |  |  |  |  |
| 139 | Payable Professional Fee |  |  |  | ✓ | 047 | 9(4)V99 |  |  |  |  |  |  |
| 140 | Payable Generic Incentive |  |  |  | ✓ | 048 | 9(4)V99 |  |  |  |  |  |  |
| 141 | Payable Special Services Fee |  |  |  | ✓ | 049 | 9(4)V99 |  |  |  |  |  |  |
| 142 | Payable Compounding Fee |  |  |  | ✓ | 050 | 9(4)V99 |  |  |  |  |  |  |
| 143 | Payable Copay Amount |  |  |  | ✓ | 051 | 9(4)V99 |  |  |  |  |  |  |
| 144 | Payable Coinsurance |  |  |  | ✓ | 052 | 9(4)V99 |  |  |  |  |  |  |
| 145 | Payable Total Amount |  |  |  | ✓ | 053 | 9(4)V99 |  |  |  |  |  |  |
| 146 | Amount Toward Cost Plus |  |  |  | ✓ | 054 | 9(4)V99 |  |  |  |  |  |  |
| 147 | Amount Toward Annual Deductible - Family |  |  |  | ✓ | 055 | 9(4)V99 |  |  |  |  |  |  |
| 148 | Amount Toward Annual Deductible - Individual/Family |  |  |  | ✓ | 056 | 9(4)V99 |  |  |  |  |  |  |
| 149 | Amount Toward Annual Deductible – Single |  |  |  | ✓ | 057 | 9(4)V99 |  |  |  |  |  |  |
| 150 | Annual Deductible Amount Satisfied – Family |  |  |  | ✓ | 058 | 9(4)V99 |  |  |  |  |  |  |
| 151 | Annual Deductible Amount Satisfied-Individual/Family |  |  |  | ✓ | 059 | 9(4)V99 |  |  |  |  |  |  |
| 152 | Annual Deductible Amount Satisfied – Single |  |  |  | ✓ | 060 | 9(4)V99 |  |  |  |  |  |  |
| 153 | Test Indicator |  |  |  | ✓ | 061 | X(1) |  |  |  |  |  |  |
| 154 | Error Codes |  |  |  | ✓ | 062 | X(12) |  |  |  |  |  |  |
| 155 | Cost Basis |  |  |  | ✓ | 063 | X(2) |  |  |  |  |  |  |
| 156 | Unit Price |  |  |  | ✓ | 064 | 9(4)V9(5) |  |  |  |  |  |  |
| 157 | Maximum Allowable Cost |  |  |  | ✓ | 065 | 9(4)V9(5) |  |  |  |  |  |  |
| 158 | Cost Difference |  |  |  | ✓ | 066 | 9(4)V9(2) |  |  |  |  |  |  |
| 159 | Therapeutic Class |  |  |  | ✓ | 067 | 9(6) |  |  |  |  |  |  |
| 160 | Class |  |  |  | ✓ | 068 | X(1) |  |  |  |  |  |  |
| 161 | Provincial Schedule |  |  |  | ✓ | 069 | X(2) |  |  |  |  |  |  |
| 162 | Dosage Form |  |  |  | ✓ | 070 | X(2) |  |  |  |  |  |  |
| 163 | Route of Administration |  |  |  | ✓ | 071 | X(1) |  |  |  |  |  |  |
| 164 | Submission Method Code |  |  |  | ✓ | 072 | 9(1) |  |  |  |  |  |  |
| 165 | Authorization Code |  |  |  | ✓ | 075 | 9(7) |  |  |  |  |  |  |
| 166 | Authorization # |  |  |  | ✓ | 076 | 9(6) |  |  |  |  |  |  |
| 167 | EFT Number |  |  |  | ✓ | 077 | X(19) |  |  |  |  |  |  |
| 168 | Deductible Satisfied Flag |  |  |  | ✓ | 078 | X(1) |  |  |  |  |  |  |
| 169 | Next Rollover Date |  |  |  | ✓ | 079 | 9(8) |  |  |  |  |  |  |
| 170 | Payment Status |  |  |  | ✓ | 080 | X(1) |  |  |  |  |  |  |
| 171 | Original Claim Reference Number |  |  |  | ✓ | 081 | X(10) |  |  |  |  |  |  |
| 172 | Original Claim Trace Number |  |  |  | ✓ | 082 | X(6) |  |  |  |  |  |  |
| 173 | Client Location |  |  |  | ✓ | 083 | X(6) |  |  |  |  |  |  |
| 174 | Reimbursement Flag |  |  |  | ✓ | 084 | X(1) |  |  |  |  |  |  |
| 175 | Prescriber Number |  |  |  | ✓ | 085 | X(10) |  |  |  |  |  |  |
| 176 | Provider Code |  |  |  | ✓ | 086 | 9(2) |  |  |  |  |  |  |
| 177 | Provider Zone |  |  |  | ✓ | 087 | 9(2) |  |  |  |  |  |  |
| 178 | Refills Authorized (CPhA Version 3) |  |  |  | ✓ | 088 | 9(2) |  |  |  |  |  |  |
| 179 | DIN Product Name |  |  |  | ✓ | 089 | X(10) |  |  |  |  |  |  |
| 180 | Refill/Repeat Authorizations |  |  |  | ✓ | 090 | 9(2) |  |  |  |  |  |  |
| 181 | Provincial Health Care ID |  |  |  | ✓ | 091 | X(13) |  |  |  |  |  |  |
| 182 | Unlisted Compound |  |  |  | ✓ | 092 | X(1) |  |  |  |  |  |  |
| 183 | Intervention Codes |  |  |  | ✓ | 093 | X(4) |  |  |  |  |  |  |
| 184 | Previously Paid |  |  |  | ✓ | 094 | 9(4)V99 |  |  |  |  |  |  |
| 185 | Pharmacist ID |  |  |  | ✓ | 095 | X(6) |  |  |  |  |  |  |
| 186 | CPhA Version Number |  |  |  | ✓ | 096 | 9(2) |  |  |  |  |  |  |
| 187 | ESC (Eclipse) Code |  |  |  | ✓ | 097 | X(2) |  |  |  |  |  |  |
| 188 | AQPPCode |  |  |  | ✓ | 097A | X(3) |  |  |  |  |  |  |
| 189 | Original Rx Number (CPhA Version 3) |  |  |  | ✓ | 098 | X(9) |  |  |  |  |  |  |
| 190 | Current Rx Number (CPhA Version 3) |  |  |  | ✓ | 099 | X(9) |  |  |  |  |  |  |
| 191 | New/Refill Code (CPhA Version 3) |  |  |  | ✓ | 100 | X(1) |  |  |  |  |  |  |
| 192 | Metric Quantity Claimed (CPhA Version 3) |  |  |  | ✓ | 101 | 9(5)V9 |  |  |  |  |  |  |
| 193 | Metric Quantity Paid (CPhA Version 3) |  |  |  | ✓ | 102 | 9(5)V9 |  |  |  |  |  |  |
| 194 | Medical Reason Reference |  |  |  | ✓ | 103 | X(1) |  |  |  |  |  |  |
| 195 | Medical Condition |  |  |  | ✓ | 104 | X(6) |  |  |  |  |  |  |
| 196 | Provider Software ID |  |  |  | ✓ | 105 | X(3) |  |  |  |  |  |  |
| 197 | POS Device ID |  |  |  | ✓ | 106 | X(8) |  |  |  |  |  |  |
| 198 | Prescriber ID Reference |  |  |  | ✓ | 107 | X(2) |  |  |  |  |  |  |
| 199 | CPhA Response Codes |  |  |  | ✓ | 108 | X(10) |  |  |  |  |  |  |
| 200 | Dosage |  |  |  | ✓ | 109 | X(8) |  |  |  |  |  |  |
| 201 | Formulary Drug Indicator |  |  |  | ✓ | 110 | X(1) |  |  |  |  |  |  |
| 202 | Disease Code |  |  |  | ✓ | 112 | 9(6) |  |  |  |  |  |  |
| 203 | COB Rule Number |  |  |  | ✓ | 113 | C(1) |  |  |  |  |  |  |
| 204 | General Code |  |  |  | ✓ | 114 | X(1) |  |  |  |  |  |  |
| 205 | Gen Prod Indicator |  |  |  | ✓ | 115 | X(1) |  |  |  |  |  |  |
| 206 | Prescriber ID |  |  |  | ✓ | 116 | X(15) |  |  |  |  |  |  |
| 207 | Prescriber Reference Code |  |  |  | ✓ | 117 | X(2) |  |  |  |  |  |  |
| 208 | Deduct Paid |  |  |  | ✓ | 118 | 9(4)V99 |  |  |  |  |  |  |
| 209 | Accum ID |  |  |  | ✓ | 119 | X(5) |  |  |  |  |  |  |
| 210 | Deferred Cd |  |  |  | ✓ | 120 | X(1) |  |  |  |  |  |  |
| 211 | Alternate Identification |  |  |  | ✓ | 121 | X(16) |  |  |  |  |  |  |
| 212 | Line of Business |  |  |  | ✓ | 122 | X(3) |  |  |  |  |  |  |
| 213 | Number of procedure codes on this record |  |  |  |  |  |  | ✓ | 054 | X(2) |  |  |  |
| 214 | Procedure status |  |  |  |  |  |  | ✓ | 066 | X(1) |  |  |  |
| 215 | Procedure code |  |  |  |  |  |  | ✓ | 070 | X(5) | ✓ | 007 | X(5) |
| 216 | Procedure name Eng |  |  |  |  |  |  | ✓ | 072 | X(35) | ✓ | 008 | X(35) |
| 217 | Procedure name Fre |  |  |  |  |  |  | ✓ | 073 | X(35) | ✓ | 009 | X(35) |
| 218 | Lab procedure code |  |  |  |  |  |  | ✓ | 081 | X(5) | ✓ | 016 | X(5) |
| 219 | Expense procedure code |  |  |  |  |  |  | ✓ | 086 | X(5) | ✓ | 021 | X(5) |
| 220 | Paid procedure code 1 |  |  |  |  |  |  | ✓ | 097 | X(5) | ✓ | 031 | X(5) |
| 221 | Paid procedure code 2 |  |  |  |  |  |  | ✓ | 098 | X(5) | ✓ | 032 | X(5) |
| 222 | Procedure code source |  |  |  |  |  |  | ✓ | 107 | X(4) | ✓ | 041 | X(4) |
| 223 | PD Line Number |  |  |  |  |  |  |  |  |  | ✓ | 002 | 9(2) |
| 224 | Date Processed |  |  |  |  |  |  |  |  |  | ✓ | 003 | 9(8) |
| 225 | Adjudication Code |  |  |  |  |  |  |  |  |  | ✓ | 004 | X(1) |
| 226 | Alternate procedure code |  |  |  |  |  |  |  |  |  | ✓ | 045 | X(5) |
| 227 | Equivalent procedure code |  |  |  |  |  |  |  |  |  | ✓ | 046 | X(5) |
