# Dental Feed Parser – Iteration 1 POC

| Item | Value |
|------|-------|
| Run date (UTC) | 2025-11-21 |
| Command | `dotnet run --project ExperienceModule -- --feed Config/dental_feed.yml --input Input/dental_sample.txt --output Output/dental_batches.jsonl` |
| Input sample | `docs/samples/dent_49161_cexp.txt` |
| File length | 4561-character fixed-width |
| Parsed records | 704 |
| Provider batches | 137 |
| Client batches | 68 |
| Output | `Output/dental_batches.jsonl` |
| Schema | `schemas/dental_batch.schema.json` (enforced per JSON line) |

Each JSON line in the output represents a complete record set (header + detail records + trailer) for either a provider batch, client batch, or the file-level header/trailer. Validation failures block the run.

