---
name: dental-pre-d
overview: Extend ExperienceModule with Dental Pre-Determination parsing by adding configs, sample data, schema wiring, and producing output batches on a new branch.
todos:
  - id: prep-branch
    content: Create feature branch & save plan in DevPlan
    status: in_progress
  - id: spec-review
    content: Review dental pred spec + dental/pharm configs
    status: pending
    dependencies:
      - prep-branch
  - id: sample-copy
    content: Copy dent_49910_pred into Input
    status: pending
    dependencies:
      - spec-review
  - id: config-yaml
    content: Add dental pred record YAMLs + feed/schema
    status: pending
    dependencies:
      - sample-copy
  - id: readme-update
    content: Document new feed usage/assets
    status: pending
    dependencies:
      - config-yaml
  - id: run-generator
    content: Produce dental pred output jsonl
    status: pending
    dependencies:
      - config-yaml
  - id: wrap-up
    content: Summaries/tests & final checks
    status: pending
    dependencies:
      - run-generator
      - readme-update
---

# Dental Pre-Determination Implementation Plan

1. **Workspace & Branch**  

- Ensure we are at `ExperienceModule` root, confirm clean status, and create a feature branch `feature/dental-pre-d`.  
- Capture the scope in `DevPlan/DentalPreDeterminationPlan.md` alongside the other DevPlan docs.

2. **Reference Analysis**  

- Review specs under `Specs/Claim - Dental Pre Determination*.pdf|txt` plus existing Dental/Pharmacy YAMLs to understand shared vs new fields.  
- Inspect the approved Dental/Pharmacy configs (`Config/Records/Dental/*`, `Config/Records/Pharmacy/*`) to mirror naming and batching conventions.

3. **Sample Assets**  

- Copy `dent_49910_pred` from `ETL/.../Sample Files` into `ExperienceModule/Input/dental_pred_sample.txt`.  
- If the runner/scripts reference sample paths, adjust accordingly.

4. **Config & Schema Updates**  

- Generate YAML record definitions for Dental Pre-D (records 0/2/3/4/5/6/7/8 or as per spec) under `Config/Records/DentalPreDetermination/`.  
- Introduce a new feed config `Config/dental_pred_feed.yml` mirroring dental/pharmacy feed structure (record map, batching rules, schema reference).  
- Add `schemas/dental_pred_batch.schema.json` (copy dental schema, adjust `$id`/title).  
- Update/extend scripts if needed to regenerate the new YAMLs (or create a new generator script similar to `generate_pharmacy_configs.py`).

5. **Pipeline Wiring**  

- No change expected in `Program.cs`, but verify CLI invocation works with the new feed config (default paths if needed).  
- Document CLI usage in README (new feed instructions) and note the sample location.

6. **Execution & Validation**  

- Run `dotnet` parser with the new feed and sample to produce `Output/dental_pred_batches.jsonl`.  
- Validate output count and check for schema validation success.

7. **Wrap-up**  

- Update README assets/run instructions, add the new plan entry in DevPlan, and summarize testing results.  
- Ensure branch status is clean minus intentional changes, ready for PR.