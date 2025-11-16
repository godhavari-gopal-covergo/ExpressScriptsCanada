# Pull Request: Partner-Specific Configuration System

## Overview

This PR implements a multi-tenant partner configuration system that allows different partners to customize field defaults and skip optional fields without modifying base ESC configuration files.

## Changes

### New Features
- **Partner Configuration Models**: Added `PartnerConfiguration.cs` with `PartnerFieldOverride` and `PartnerRecordConfiguration` classes
- **Partner Config Loading**: Enhanced `Program.cs` to load and merge partner-specific configurations
- **Command-Line Support**: Added `--partner` argument for partner selection
- **Configuration Merging**: Implemented merge logic that overlays partner overrides on base config

### New Files
- `Models/PartnerConfiguration.cs` - Partner configuration models
- `Config/Partners/GMS/` - Sample GMS partner configurations
- `Config/Partners/README.md` - Comprehensive partner configuration documentation
- `PARTNER_CONFIG_IMPLEMENTATION.md` - Implementation guide
- Test input files for validation

### Modified Files
- `Program.cs` - Added partner config loading and merging logic

## Key Features

✅ **Non-Intrusive**: Base configurations remain completely unchanged  
✅ **Minimal Partner Configs**: Partner files only contain differences  
✅ **Format Enforcement**: All field lengths, padding, transforms enforced by base  
✅ **Backward Compatible**: System works without partner configs  
✅ **Scalable**: Add new partners without code changes  

## Usage

```bash
# Without partner (uses base config only)
dotnet run

# With GMS partner configuration
dotnet run --partner GMS
```

## Configuration Merge Strategy

- Partners can override field default values
- Partners can mark fields as `skip: true` (uses base config as-is)
- All format specifications (length, padding, transforms) come from base config
- Input JSON values always take precedence over partner defaults

## Testing

- ✅ Tested without partner configuration (backward compatible)
- ✅ Tested with GMS partner configuration
- ✅ Verified partner defaults are applied correctly
- ✅ Verified skipped fields use base configuration

## Documentation

Comprehensive documentation included:
- Partner configuration guide (`Config/Partners/README.md`)
- Implementation summary (`PARTNER_CONFIG_IMPLEMENTATION.md`)
- Sample GMS partner configurations

## Next Steps

To add a new partner:
1. Create directory: `Config/Partners/{PartnerName}/`
2. Create override YAML files for each record type
3. Run with: `dotnet run --partner {PartnerName}`

No code changes required!

## Files Changed

- `Program.cs` (modified)
- `Models/PartnerConfiguration.cs` (new)
- `Config/Partners/GMS/record_00_header.yml` (new)
- `Config/Partners/GMS/record_20_client.yml` (new)
- `Config/Partners/README.md` (new)
- `PARTNER_CONFIG_IMPLEMENTATION.md` (new)
- Test input files (new)

