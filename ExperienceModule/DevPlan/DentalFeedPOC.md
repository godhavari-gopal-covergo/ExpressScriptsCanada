# Dental Feed Parser POC (Iteration 1)

## Goals
- Parse THBM Dental experience files (record types 0/2/3/4/5/6/7/8) using configuration, not hand-coded field maps.
- Emit newline-delimited JSON, each JSON representing a full provider/client batch (header + detail + trailer) ready for downstream Claim sync logic.
- Mirror the `EligibilityModule` structure so that other feed types can plug in later with mostly config changes.

## Plan
1. **Study Reference Implementation**  
   - Review `ExpressScriptsCanada/EligibilityModule` structure (`Config`, `Input`, `Output`, `Models`, `Program.cs`) to mirror naming, dependency injection, and CLI pattern.  
   - Inspect existing YAML configs under `EligibilityModule/Config` to understand how field metadata is captured today.

2. **Define ExperienceModule Project Skeleton**  
   - Create/adjust the console project under `ExpressScriptsCanada/ExperienceModule`, aligning folder layout (`Config`, `Input`, `Output`, `docs`, `Specs`, `Models`, `Tests`).  
   - Add shared libraries (e.g., `Core`) if needed so future feed types reuse parsers, field readers, and schema definitions.

3. **Design Config-Driven Parsing Schema**  
   - Introduce YAML definitions per record type (0,2,3,4,5,6,7,8) capturing field numbers, lengths, types, lookups, and grouping metadata (record order, nesting, batch boundaries).  
   - Add a higher-level config describing feed ordering rules (global header/footer, provider batches, client batches) and specify which record types compose a “set” for JSON output.

4. **Implement Streaming Fixed-Width Parser**  
   - Build a reusable reader that consumes the feed line by line, loads the correct record definition from YAML, and produces typed dictionaries/objects without loading the entire file.  
   - Validate field lengths/formats according to config; surface errors with record numbers (reusable for other feeds).

5. **Batch Assembly & JSON Writer**  
   - Implement a state machine that groups records into logical batches (provider: 2 + many 4/5 + 6, client: 3 + many 4/5 + 7).  
   - Combine grouped records (including metadata from record 0 and file trailer 8) into a canonical intermediate structure compatible with `GmsClaimDataSyncHandler`.  
   - Serialize each batch to newline-delimited JSON in `ExperienceModule/Output/*.jsonl`.

6. **Configuration-First Extensibility**  
   - Abstract parser settings (field mappings, grouping rules, output schema) so adding EHC/Pharmacy/Predetermination requires only new YAMLs plus minimal wiring.  
   - Document the config schema and runner usage in `ExperienceModule/README.md`.

7. **JSON Schema Definition & Validation**  
   - Produce a JSON Schema document that describes the output structure (batch-level metadata + per-record payloads for types 0/2/3/4/5/6/7/8).  
   - Validate generated JSONL rows against the schema to ensure alignment with ESC spec.

8. **Documentation & Assets Migration**  
   - Copy required ESC specs and representative sample files from `ETL/EhcPatientEtl/...` into `ExperienceModule/docs` so the project is self-contained.  
   - Update README references to point to the local docs.

9. **POC Validation**  
   - Use a sample Dental file from `docs/samples` as input, run the parser, and verify emitted JSON sets match expected grouping + schema validation.  
   - Capture open gaps (e.g., missing lookup tables) for iteration 2 when integrating with claim sync logic.

## Todos
- **study-eligibility**: Review EligibilityModule structure & configs
- **setup-project**: Create ExperienceModule scaffolding mirroring EligibilityModule (depends on study-eligibility)
- **config-schema**: Define YAML schema for Dental record parsing (depends on setup-project)
- **docs-migration**: Copy needed ESC docs/samples into ExperienceModule (depends on config-schema)
- **parser-core**: Implement config-driven fixed-width parser (depends on config-schema)
- **batch-writer**: Assemble batches & emit jsonl output (depends on parser-core)
- **json-schema**: Produce JSON Schema & hook validation (depends on batch-writer)
- **poc-validation**: Run parser on sample dental file & document results (depends on json-schema and docs-migration)
