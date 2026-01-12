# Field Comparison: Record Type 29

This document provides a complete field listing for Record Type 29 (Client Address Record), maintaining the exact field sequence and names as defined in the configuration file.

## Record Type 29 Overview

- **Record Type:** 29
- **Description:** Client address record with identification and general information
- **Total Fields:** 13 fields
- **Notes:**
  - Not a mandatory Record Type
  - Multiple type 29 records may be sent once the client record has first been sent

## Field Listing

| # | Field Key | Field Name | Length | Required | Position |
|---|-----------|------------|--------|----------|----------|
| **IDENTIFICATION SECTION** |
| 1 | `record_type` | Record Type | 2 | Y | 001-002 |
| 2 | `carrier_id` | Carrier ID | 2 | Y | 003-004 |
| 3 | `group_number` | Group Number | 10 | Y | 005-014 |
| 4 | `client_id` | Client ID | 15 | Y | 015-029 |
| **GENERAL SECTION** |
| 5 | `client_last_name` | Client Last name | 30 | Y | 030-059 |
| 6 | `client_first_name` | Client first name | 30 | Y | 060-089 |
| 7 | `address1` | Address1 | 35 | Y | 090-124 |
| 8 | `address2` | Address2 | 35 | N | 125-159 |
| 9 | `city` | City | 35 | Y | 160-194 |
| 10 | `province` | Province | 2 | Y | 195-196 |
| 11 | `country` | Country | 15 | N | 197-211 |
| 12 | `postal_code` | Postal Code | 6 | N | 212-217 |
| 13 | `filler` | Filler | 140 | Y | 218-357 |

## Field Sequence Summary

### Identification Section (4 fields)
Fields 1-4: Basic identification fields including record type, carrier ID, group number, and client ID.

**Note:** Record 29 does not include the `sas` field that is present in other record types.

### General Section (9 fields)
Fields 5-13: Client address and contact information including:
- Client name (fields 5-6)
- Address lines (fields 7-8)
- City, province, country, and postal code (fields 9-12)
- Filler field (field 13)

## Field Details

### Required Fields (9 fields)
1. `record_type` - Record Type
2. `carrier_id` - Carrier ID
3. `group_number` - Group Number
4. `client_id` - Client ID
5. `client_last_name` - Client Last name
6. `client_first_name` - Client first name
7. `address1` - Address1
9. `city` - City
10. `province` - Province
13. `filler` - Filler

### Optional Fields (4 fields)
8. `address2` - Address2
11. `country` - Country
12. `postal_code` - Postal Code

## Field Validation Rules

### Province Field (Field 10)
- Must be a valid province code
- OC is a valid province code for this field
- Uses province code lookup transformation

### Country Field (Field 11)
- **If Province is OC:** Country Code is optional and can be blank or any value (no edit check performed)
- **If Province is anything other than OC:** Country Code must be "CANADA"
- Transformation logic: `province != "OC" ? "CANADA" : value`

### Postal Code Field (Field 12)
- Format: X(6)
- As per Customer specification

## Key Characteristics

1. **Simplest Record Type:** Record 29 has the fewest fields (13) compared to other record types
2. **No SAS Field:** Unlike other record types (20, 22, 30, 32), Record 29 does not include the SAS field
3. **Address-Only Record:** This record type is dedicated solely to client address information
4. **Multiple Records Allowed:** Multiple type 29 records can be sent for the same client
5. **Not Mandatory:** This record type is optional and not required for client setup

## Total Record Length
357 characters (positions 001-357)

