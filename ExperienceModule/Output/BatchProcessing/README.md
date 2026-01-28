# ESC Claim File Samples - Output Files

This directory contains the processed output files from the Express Scripts Canada (ESC) Experience Module batch processing.

## Directory Structure

```
BatchProcessing/
├── DENTAL/                    # Dental claim outputs (5 files)
├── EHC/                       # Extended Health Care outputs (5 files)
├── PHARMACY/                  # Pharmacy claim outputs (5 files)
├── PREDETERMINATIONS/         # Dental predetermination outputs (5 files)
├── PROCESSING_SUMMARY.md      # Detailed processing statistics
└── README.md                  # This file
```

## Output File Format

All output files are in **JSONL (JSON Lines)** format:
- One JSON object per line
- Each line represents a batch (file_header, provider, client, or file_trailer)
- Files can be processed line-by-line for streaming applications

### Batch Structure

Each JSON line contains:

```json
{
  "feedName": "dental_thbm",           // Feed identifier
  "batchType": "provider",              // Batch type: file_header, provider, client, file_trailer
  "header": {                           // Batch header record
    "recordType": "2",
    "description": "Provider Header Record",
    "fields": { ... }                   // Parsed field values
  },
  "details": [                          // Array of detail records
    {
      "recordType": "3",
      "description": "Claim Detail Record",
      "fields": { ... }
    }
  ],
  "trailer": {                          // Batch trailer record (if applicable)
    "recordType": "4",
    "description": "Provider Trailer Record",
    "fields": { ... }
  },
  "metadata": {                         // Additional metadata
    "providerNumber": "12345",
    "detailCount": "15"
  }
}
```

## File Naming Convention

Output files follow this pattern:
- **Input:** `dent_49211_cexp`
- **Output:** `dent_49211_cexp_output.jsonl`

The original filename is preserved with `_output.jsonl` appended.

## Processing Details

### DENTAL Files
- **Config:** `Config/dental_feed.yml`
- **Schema:** `schemas/dental_batch.schema.json`
- **Total Records:** 2,864
- **Total Size:** ~4.2 MB

### EHC Files
- **Config:** `Config/health_feed.yml`
- **Schema:** `schemas/health_batch.schema.json`
- **Total Records:** 5,873
- **Total Size:** ~8.7 MB

### PHARMACY Files
- **Config:** `Config/pharmacy_feed.yml`
- **Schema:** `schemas/pharmacy_batch.schema.json`
- **Total Records:** 26,668
- **Total Size:** ~84 MB

### PREDETERMINATIONS Files
- **Config:** `Config/dental_pred_feed.yml`
- **Schema:** `schemas/dental_pred_batch.schema.json`
- **Total Records:** 1,571
- **Total Size:** ~1.6 MB

## Usage Examples

### Read a file line-by-line (Python)
```python
import json

with open('DENTAL/dent_49211_cexp_output.jsonl', 'r') as f:
    for line in f:
        batch = json.loads(line)
        print(f"Batch Type: {batch['batchType']}")
        print(f"Details Count: {len(batch['details'])}")
```

### Count batches by type (bash)
```bash
cat DENTAL/dent_49211_cexp_output.jsonl | \
  python3 -c "import sys, json; \
  batches = [json.loads(line)['batchType'] for line in sys.stdin]; \
  print({t: batches.count(t) for t in set(batches)})"
```

### View specific batch (bash)
```bash
# View the file header
head -n 1 DENTAL/dent_49211_cexp_output.jsonl | python3 -m json.tool

# View a provider batch
sed -n '2p' DENTAL/dent_49211_cexp_output.jsonl | python3 -m json.tool
```

## Validation

All output files have been validated against their respective JSON schemas:
- ✅ Schema validation passed for all batches
- ✅ All required fields present
- ✅ Data types match schema definitions
- ✅ No parsing errors

## Reprocessing

To reprocess any input file, use:

```bash
dotnet /path/to/ExperienceModule.dll \
  --feed Config/[feed_type]_feed.yml \
  --input "Input/ESC Claim File Samples/[CATEGORY]/[filename]" \
  --output "Output/BatchProcessing/[CATEGORY]/[filename]_output.jsonl"
```

Or use the automated script:
```bash
./process_all_samples.sh
```

## Notes

- Files are ready for downstream processing
- Each batch is self-contained with header, details, and trailer
- Metadata includes provider/client identifiers for easy filtering
- All monetary amounts are formatted with implied decimal places
- Date fields are in YYYYMMDD format

## Support

For questions about the output format or processing, refer to:
- `PROCESSING_SUMMARY.md` - Detailed statistics
- `../README.md` - Module documentation
- `../Config/` - Feed configurations
- `../schemas/` - JSON schema definitions
