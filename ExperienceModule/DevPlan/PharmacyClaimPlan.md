# Pharmacy Claim Implementation Plan

1. **Prepare workspace & documentation**  
   - Switch to `ExperienceModule` repo root and verify clean status.  
   - Create feature branch `feature/pharmacy-claim`.  
   - Save this implementation plan into `DevPlan/PharmacyClaimPlan.md` (side-by-side with other DevPlan docs).

2. **Study reference assets**  
   - Review `DevPlan/DentalFeedPOC.md` and `DevPlan/HealthFeedImplementation.md` to mirror conventions.  
   - Inspect pharmacy specs under `Specs/Claim Pharmacy*` plus pharmacy sample(s) in `ETL/.../Sample Files`.  
   - Note any deltas from dental/EHC (record lengths, optional fields, terminology).

3. **Move sample artifacts into repo**  
   - Copy the required pharmacy sample file(s) from `ETL/.../Sample Files` into `ExperienceModule/Input/pharmacy_sample.txt` (or similar).  
   - Ensure `.csproj` or scripts reference the new local sample path.

4. **Author pharmacy configs & models**  
   - Create YAML record definitions under `Config/Records/Pharmacy/` (records 0,2,3,4,5,6,7,8) using the dental configs as templates but with pharmacy-specific fields.  
   - Update any shared config files (e.g., feed YAML) to describe batching/grouping rules and schema references.  
   - Add new model/enums under `Models/` only if pharmacy requires additional strongly typed fields.  
   - Keep null defaults instead of `"N/A"`.

5. **Extend processing pipeline**  
   - Update `Program.cs`, config loaders, or helper scripts so the pharmacy feed can be invoked via CLI (feed YAML + input path + output file).  
   - Reuse dental/EHC logic where possible; introduce pharmacy-specific helpers if necessary.  
   - Update unit/integration tests (under `Tests/`) to cover pharmacy parsing.

6. **Generate & validate pharmacy output**  
   - Run the parser using the new sample file and config to produce `Output/pharmacy_batches.jsonl`.  
   - Validate against the appropriate JSON schema (create one if needed).  
   - Spot-check a few batches to confirm headers/details/trailers align with specs.

7. **Finalize & document**  
   - Update relevant docs (README, DevPlan entry) summarizing pharmacy support and usage instructions.  
   - Confirm lint/tests pass.  
   - Prepare branch for PR and note remaining risks or follow-ups.
