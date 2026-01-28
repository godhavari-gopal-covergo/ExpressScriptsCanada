# ESC Claim File Samples - Batch Processing Summary

**Processing Date:** January 27, 2026  
**Total Input Files Processed:** 20  
**Total Output Files Generated:** 20  
**Status:** ✅ All files processed successfully

---

## Processing Overview

All input files from the `Input/ESC Claim File Samples` directory have been successfully processed through the Experience Module. Each input file generated one corresponding output file in JSONL (JSON Lines) format.

---

## Detailed Results by Category

### 1. DENTAL Claims (5 files)

| Input File | Records Parsed | Provider Batches | Client Batches | Output File Size |
|------------|----------------|------------------|----------------|------------------|
| dent_49211_cexp | 580 | 124 | 54 | 826 KB |
| dent_49212_cexp | 414 | 89 | 34 | 608 KB |
| dent_49213_cexp | 560 | 120 | 49 | 811 KB |
| dent_49214_cexp | 687 | 124 | 79 | 1.0 MB |
| dent_49215_cexp | 623 | 124 | 58 | 934 KB |
| **TOTAL** | **2,864** | **581** | **274** | **4.2 MB** |

**Configuration Used:** `Config/dental_feed.yml`  
**Output Directory:** `Output/BatchProcessing/DENTAL/`

---

### 2. EHC (Extended Health Care) Claims (5 files)

| Input File | Records Parsed | Provider Batches | Client Batches | Output File Size |
|------------|----------------|------------------|----------------|------------------|
| ehc_49638_cexp | 1,232 | 178 | 178 | 1.8 MB |
| ehc_49639_cexp | 1,285 | 166 | 193 | 1.9 MB |
| ehc_49640_cexp | 1,028 | 153 | 116 | 1.6 MB |
| ehc_49641_cexp | 1,015 | 179 | 102 | 1.5 MB |
| ehc_49642_cexp | 1,313 | 158 | 220 | 1.9 MB |
| **TOTAL** | **5,873** | **834** | **809** | **8.7 MB** |

**Configuration Used:** `Config/health_feed.yml`  
**Output Directory:** `Output/BatchProcessing/EHC/`

---

### 3. PHARMACY Claims (5 files)

| Input File | Records Parsed | Provider Batches | Client Batches | Output File Size |
|------------|----------------|------------------|----------------|------------------|
| R49285 | 4,504 | 381 | 28 | 14 MB |
| R49286 | 7,633 | 423 | 45 | 25 MB |
| R49287 | 5,494 | 416 | 7 | 17 MB |
| R49288 | 4,815 | 382 | 35 | 15 MB |
| R49289 | 4,222 | 373 | 8 | 13 MB |
| **TOTAL** | **26,668** | **1,975** | **123** | **84 MB** |

**Configuration Used:** `Config/pharmacy_feed.yml`  
**Output Directory:** `Output/BatchProcessing/PHARMACY/`

---

### 4. PREDETERMINATIONS (5 files)

| Input File | Records Parsed | Provider Batches | Client Batches | Output File Size |
|------------|----------------|------------------|----------------|------------------|
| dent_49960_pred | 259 | 36 | 0 | 278 KB |
| dent_49961_pred | 160 | 20 | 1 | 175 KB |
| dent_49962_pred | 326 | 46 | 1 | 350 KB |
| dent_49963_pred | 536 | 82 | 0 | 566 KB |
| dent_49964_pred | 290 | 49 | 0 | 296 KB |
| **TOTAL** | **1,571** | **233** | **2** | **1.6 MB** |

**Configuration Used:** `Config/dental_pred_feed.yml`  
**Output Directory:** `Output/BatchProcessing/PREDETERMINATIONS/`

---

## Grand Totals

| Metric | Count |
|--------|-------|
| **Total Records Parsed** | **36,976** |
| **Total Provider Batches** | **3,623** |
| **Total Client Batches** | **1,208** |
| **Total Output Size** | **~98.5 MB** |

---

## Output Format

All output files are in **JSONL (JSON Lines)** format, where:
- Each line is a valid JSON object representing a batch
- Batches are validated against their respective JSON schemas
- Each batch contains:
  - `FeedName`: The feed type (dental, health, pharmacy, dental_predetermination)
  - `BatchType`: The batch category (file_header, provider, client, file_trailer)
  - `Header`: Batch header record with metadata
  - `Details`: Array of detail records within the batch
  - `Trailer`: Batch trailer record with totals/counts
  - `Metadata`: Additional metadata (provider number, client ID, detail count)

---

## Schema Validation

All output files have been validated against their respective JSON schemas:
- ✅ `schemas/dental_batch.schema.json` - DENTAL files
- ✅ `schemas/health_batch.schema.json` - EHC files
- ✅ `schemas/pharmacy_batch.schema.json` - PHARMACY files
- ✅ `schemas/dental_pred_batch.schema.json` - PREDETERMINATIONS files

---

## Processing Script

The batch processing was automated using: `process_all_samples.sh`

This script:
1. Iterates through all input files in each category
2. Applies the appropriate feed configuration
3. Generates one output file per input file
4. Validates all output against JSON schemas
5. Organizes outputs in category-specific subdirectories

---

## Notes

- **Pharmacy files** contain the highest volume of records (26,668 total)
- **EHC files** have a balanced distribution of provider and client batches
- **Predetermination files** have minimal client batches (only 2 total)
- All files processed without errors
- Output files maintain the original input filename with `_output.jsonl` suffix

---

## Next Steps

The generated JSONL files are ready for:
1. Downstream processing and ingestion
2. Data validation and quality checks
3. Integration with experience estimation pipelines
4. Analytics and reporting

---

**Generated by:** Experience Module Batch Processor  
**Module Version:** .NET 8.0  
**Processing Time:** ~16 seconds
