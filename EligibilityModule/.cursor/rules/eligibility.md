## Eligibility module rules

### Data intake
- Keep sample fixtures in `Input/` minimal and representative; large scenario packs stay outside the repo.
- All missing values remain `null`. Do not swap `"N/A"` or whitespace for absent data because YAML defaults need to kick in.
- Normalize casing and trim values through YAML rules (`field_rules`, `transform`) instead of hand-coded helpers.

### Configuration-first behavior
- Record layouts must be defined under `Config/record_*.yml`. Do not branch `Program.cs` per record type.
- Lookup data sits in `Config/Lookups/` and is referenced via `CommonRules.Lookup_Files`. Never inline lookup dictionaries.
- Prefer DynamicExpresso expressions (`transform`, `transform_lookup`) over imperative C# logic so config owners can adjust rules.
- Padding, truncation, and allowed-value enforcement belong in YAML to keep the runtime generic.

### Runtime posture
- Validation problems log warnings and continue processing; batches must not fail due to a single record.
- Use common field rules to inject defaults or reformat values before concatenating into fixed-width strings.
- Keep console output chatty (load steps, warnings, counts) for production observability.

### Delivery
- `Config/` and `Input/` entries keep `CopyToOutputDirectory=PreserveNewest` so every published build includes the YAML + fixtures.
- Output filenames stay timestamped (`ehc_output_{yyyyMMdd_HHmmss}.txt`) and land under `EligibilityModule/Output/`.
- No documentation/prototype assets in this module folder; those remain in the original POC workspace.

