# Extension Configuration System

## Overview

The extension configuration system allows different partners to customize field defaults and skip optional fields without modifying the Base ESC configuration files. This enables a multi-tenant architecture where each partner can have their own data processing rules while maintaining a single codebase.

## Architecture

### Layered Configuration Approach

1. **Base Configuration**:
   - **Mapping** (`Config/Base/Mapping/*.yml`): Defines all format specifications (field lengths, padding rules, transforms, validations)
   - **Rules** (`Config/Base/Rules/global_rules.yml`): Global transformation rules and field rules
   - **Lookups** (`Config/Base/Lookups/*.yml`): Base lookup tables used by Base mapping configurations
2. **Extension Configuration**:
   - **Mapping** (`Config/Extensions/{PartnerID}/Mapping/*.yml`): Contains only field-specific overrides
   - **Lookups** (`Config/Extensions/{PartnerID}/Lookups/*.yml`): Extension-specific lookup tables (optional)
3. **Runtime Merging**: Extension overrides are applied on top of Base configuration at runtime

### Key Principles

- **Base configurations remain untouched**: All format specifications come from Base
- **Extension configs are minimal**: Only include fields that differ from Base
- **Type-safe**: All format specifications enforced by Base config
- **Backward compatible**: System works without extension configs (uses Base only)

## Directory Structure

```
Config/
├── Base/
│   ├── Mapping/
│   │   ├── record_00_header.yml      # Base record configurations
│   │   ├── record_20_client.yml
│   │   ├── record_22_patient.yml
│   │   └── ...
│   ├── Rules/
│   │   └── global_rules.yml          # Global transformation rules
│   └── Lookups/
│       ├── language_codes.yml         # Base lookup tables
│       ├── province_codes.yml
│       ├── relationship_codes.yml
│       └── yes_no_codes.yml
└── Extensions/
    ├── GMS/                           # Partner-specific configs
    │   └── Mapping/
    │       ├── record_00_header.yml
    │       ├── record_20_client.yml
    │       └── ...
    └── [other-partners]/
        └── Mapping/
            └── ...
```

## Extension Configuration Format

Extension YAML files contain **only overrides**:

```yaml
# Config/Extensions/GMS/Mapping/record_00_header.yml
partner_id: "GMS"
record_type: "00"

field_overrides:
  # Override default value for a field
  - key: "source_name"
    default_value: "GMS"
  
  # Skip an optional field (uses Base config as-is)
  - key: "comment"
    skip: true
```

### Field Override Options

1. **`default_value`**: Overrides the Base default value
   - Used when the field is missing or null in input JSON
   - Input JSON values always take precedence over extension defaults

2. **`skip: true`**: Marks field to use Base configuration as-is
   - No extension changes applied
   - Useful for documentation or explicit opt-out

## Usage

### Running with Extension Configuration

Use the `--partner` command-line argument:

```bash
# Without partner (uses Base config only)
dotnet run

# With GMS extension configuration
dotnet run --partner GMS

# With another partner
dotnet run --partner ABC
```

### Value Resolution Priority

For each field, values are resolved in this order:

1. **Input JSON value** (highest priority)
2. **Extension default value** (if specified and input is missing/null)
3. **Base default value** (if no extension override)
4. **Empty/padding** (if no defaults defined)

## Example: GMS Extension

### Scenario

GMS partner requirements:
- Default source name to "GMS"
- Default language to English ("E")
- Skip certain optional fields (EFT fields)

### Configuration

**Base**: `Config/Base/Mapping/record_00_header.yml`
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

**Extension**: `Config/Extensions/GMS/Mapping/record_00_header.yml`
```yaml
partner_id: "GMS"
record_type: "00"

field_overrides:
  - key: "source_name"
    default_value: "GMS"
```

### Result

- If input JSON has `"source_name": "CUSTOM"` → Output: `"CUSTOM              "` (input takes precedence)
- If input JSON has no `source_name` field → Output: `"GMS                 "` (extension default used)
- Format specs from Base: length=20, right-padded with spaces

## Adding a New Extension

1. **Create extension directory**:
   ```bash
   mkdir -p Config/Extensions/NewPartner/Mapping
   ```

2. **Create override files** for each record type that needs customization:
   ```yaml
   # Config/Extensions/NewPartner/Mapping/record_00_header.yml
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

### Test without Extension
```bash
dotnet run
```
Output will use Base configuration defaults.

### Test with Extension
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

1. **Clean Separation**: Base configs remain untouched, extension configs are minimal
2. **Maintainable**: Extension files only show differences, easy to understand
3. **Scalable**: Add new extensions without code changes
4. **Type-Safe**: All format specifications enforced by Base config
5. **Flexible**: Each partner can have different defaults and skip patterns

## Limitations

Extension configurations can only:
- Override field default values
- Mark fields to skip (use Base as-is)

Extension configurations **cannot**:
- Change field lengths
- Change padding rules
- Change validation rules
- Change transforms or lookups
- Change required/optional status

All format specifications must be defined in Base configuration.

