## Repo-wide conventions (from the EhcPatientEtl POC)

### Data hygiene
- Missing values stay `null`; never coerce to `"N/A"` or whitespace so YAML defaults and padding logic work.
- Normalize/trim inbound strings via YAML rules (common field rules or transforms) instead of bespoke code.
- Keep `Input/` examples tiny but realistic; bulk scenario data and experiments remain outside this repo.

### Configuration-first ETL
- Any record or field change belongs in `Config/record_*.yml`. The runtime must not branch by record type.
- Lookup data lives under `Config/Lookups/` and is surfaced through `CommonRules.Lookup_Files`. Do not inline dictionaries in C#.
- Prefer DynamicExpresso expressions (`transform`, `transform_lookup`) for business logic so non-devs can iterate without recompiles.
- Put padding, truncation, allowed-values, and formatting instructions in YAML so the pipeline stays generic.
- If Dapr subscribers are ever added, register them in Dapr config files rather than branching in code.

### Runtime posture
- Validation problems log warnings and keep processing; a single bad record must not abort the batch.
- Use common field rules to inject defaults/formatting before concatenating output, ensuring deterministic fixed-width strings.

### Repository hygiene
- Production repo only: no markdown decks, HTML prototypes, utils, or notebooks from the POC.
- Every module keeps `Config/` and `Input/` marked `CopyToOutputDirectory=PreserveNewest` so build artifacts include YAML + fixtures.

### Module-specific rules
- Each module adds its own guidance under `MODULE/.cursor/rules/`.
- Eligibility-specific rules live in `EligibilityModule/.cursor/rules/eligibility.md`.
- Future modules (e.g., `ExperienceModule`) should author their `.cursor` rule files before dev work begins.

