# Experience Module

Config-driven parser utilities for ESC experience feeds (Dental, EHC, Pharmacy, Dental Predetermination).

## Current Iteration

**Iteration 1** focuses on a Dental feed POC. The same tooling now powers Health/EHC and Pharmacy feeds:

- Parse fixed-width files using YAML configs per claim type.
- Group records into provider/payee batches and emit newline-delimited JSON.
- Validate each JSON object against the feed-specific schema for downstream processing.

## Project Layout

```
ExperienceModule/
├── Config/          # YAML definitions for record layouts & feed orchestration
├── docs/            # ESC specs, sample files, design notes
├── Input/           # Source feed files for local runs
├── Output/          # Generated JSON Lines batches
├── Models/          # POCOs shared across parsers
├── schemas/         # JSON Schema definitions for emitted batches
├── Specs/           # Raw specification PDFs/text (kept for reference)
├── Tests/           # Future unit/integration tests
├── DevPlan/         # Approved development plans (see DentalFeedPOC.md)
└── Program.cs       # Entry point wiring configs + parser pipeline
```

## Running the Parser

```
# Dental feed
dotnet run --project ExperienceModule -- \
  --feed Config/dental_feed.yml \
  --input Input/dental_sample.txt \
  --output Output/dental_batches.jsonl

# Pharmacy feed
dotnet run --project ExperienceModule -- \
  --feed Config/pharmacy_feed.yml \
  --input Input/pharmacy_sample.txt \
  --output Output/pharmacy_batches.jsonl
```

Inputs/outputs can be overridden via CLI flags. Each JSON line in the output file is validated against the schema referenced in the selected feed config (e.g., `schemas/dental_batch.schema.json`, `schemas/pharmacy_batch.schema.json`).

### Assets

- `Specs/` – original ESC PDF specs (Dental, EHC, Pharmacy, DPD)
- `docs/samples/` – raw sample feeds copied from legacy ETL folders
- `Scripts/generate_dental_configs.py` – regenerates Dental YAML layouts from the spec
- `Scripts/generate_pharmacy_configs.py` – regenerates Pharmacy YAML layouts from the spec
- `Input/pharmacy_sample.txt` – local copy of ESC sample feed `R49235`

