# Partner Configuration System

## Overview

The partner configuration system allows different partners to customize field defaults and skip optional fields without modifying the base ESC configuration files. This enables a multi-tenant architecture where each partner can have their own data processing rules while maintaining a single codebase.

## Architecture

### Layered Configuration Approach

1. **Base Configuration** (`Config/*.yml`): Defines all format specifications (field lengths, padding rules, transforms, validations)
2. **Partner Configuration** (`Config/Partners/{PartnerID}/*.yml`): Contains only field-specific overrides
3. **Runtime Merging**: Partner overrides are applied on top of base configuration at runtime

### Key Principles

- **Base configurations remain untouched**: All format specifications come from base
- **Partner configs are minimal**: Only include fields that differ from base
- **Type-safe**: All format specifications enforced by base config
- **Backward compatible**: System works without partner configs (uses base only)

## Directory Structure

```
Config/
├── record_00_header.yml              # Base configurations
├── record_20_client.yml
├── record_22_patient.yml
├── ...
└── Partners/
    ├── GMS/                           # Partner-specific configs
    │   ├── record_00_header.yml
    │   ├── record_20_client.yml
    │   └── ...
    └── [other-partners]/
        └── ...
```

## Partner Configuration Format

Partner YAML files contain **only overrides**:

```yaml
# Config/Partners/GMS/record_00_header.yml
partner_id: "GMS"
record_type: "00"

field_overrides:
  # Override default value for a field
  - key: "source_name"
    default_value: "GMS"
  
  # Skip an optional field (uses base config as-is)
  - key: "comment"
    skip: true
```

### Field Override Options

1. **`default_value`**: Overrides the base default value
   - Used when the field is missing or null in input JSON
   - Input JSON values always take precedence over partner defaults

2. **`skip: true`**: Marks field to use base configuration as-is
   - No partner changes applied
   - Useful for documentation or explicit opt-out

## Usage

### Running with Partner Configuration

Use the `--partner` command-line argument:

```bash
# Without partner (uses base config only)
dotnet run

# With GMS partner configuration
dotnet run --partner GMS

# With another partner
dotnet run --partner ABC
```

### Value Resolution Priority

For each field, values are resolved in this order:

1. **Input JSON value** (highest priority)
2. **Partner default value** (if specified and input is missing/null)
3. **Base default value** (if no partner override)
4. **Empty/padding** (if no defaults defined)

## Example: GMS Partner

### Scenario

GMS partner requirements:
- Default source name to "GMS"
- Default language to English ("E")
- Skip certain optional fields (EFT fields)

### Configuration

**Base**: `Config/record_00_header.yml`
```yaml
fields:
  - name: "Source Name"
    key: "source_name"
    length: 20
    padding: "right"
    pad_char: " "
    required: true
    # No default - expects from input
```

**Partner**: `Config/Partners/GMS/record_00_header.yml`
```yaml
partner_id: "GMS"
record_type: "00"

field_overrides:
  - key: "source_name"
    default_value: "GMS"
```

### Result

- If input JSON has `"source_name": "CUSTOM"` → Output: `"CUSTOM              "` (input takes precedence)
- If input JSON has no `source_name` field → Output: `"GMS                 "` (partner default used)
- Format specs from base: length=20, right-padded with spaces

## Adding a New Partner

1. **Create partner directory**:
   ```bash
   mkdir Config/Partners/NewPartner
   ```

2. **Create override files** for each record type that needs customization:
   ```yaml
   # Config/Partners/NewPartner/record_00_header.yml
   partner_id: "NewPartner"
   record_type: "00"
   
   field_overrides:
     - key: "source_name"
       default_value: "NEWPARTNER"
   ```

3. **Run with partner**:
   ```bash
   dotnet run --partner NewPartner
   ```

## Testing

### Test without Partner
```bash
dotnet run
```
Output will use base configuration defaults.

### Test with Partner
```bash
dotnet run --partner GMS
```
Output will show:
```
Using partner configuration: GMS
Applying partner overrides for GMS...
  ✓ Record 00: 'Source Name' default = 'GMS'
  ✓ Record 20: 'Client Language Flag/Code' default = 'E'
  Applied 2 field override(s)
✓ Partner overrides applied
```

## Benefits

1. **Clean Separation**: Base configs remain untouched, partner configs are minimal
2. **Maintainable**: Partner files only show differences, easy to understand
3. **Scalable**: Add new partners without code changes
4. **Type-Safe**: All format specifications enforced by base config
5. **Flexible**: Each partner can have different defaults and skip patterns

## Limitations

Partner configurations can only:
- Override field default values
- Mark fields to skip (use base as-is)

Partner configurations **cannot**:
- Change field lengths
- Change padding rules
- Change validation rules
- Change transforms or lookups
- Change required/optional status

All format specifications must be defined in base configuration.

