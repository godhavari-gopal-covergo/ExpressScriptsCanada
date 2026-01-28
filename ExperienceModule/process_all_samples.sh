#!/bin/bash

# Script to process all ESC Claim File Samples
# Generates one output file for each input file

set -e  # Exit on error

PROJECT_ROOT="/Users/godhavarigopal-covergo/Documents/CoverGo/Cursor/Godhavari/ExpressScriptsCanada/ExperienceModule"
SAMPLES_DIR="$PROJECT_ROOT/Input/ESC Claim File Samples"
OUTPUT_DIR="$PROJECT_ROOT/Output/BatchProcessing"
DLL_PATH="$PROJECT_ROOT/bin/Debug/net8.0/ExperienceModule.dll"

# Create output directory structure
mkdir -p "$OUTPUT_DIR/DENTAL"
mkdir -p "$OUTPUT_DIR/EHC"
mkdir -p "$OUTPUT_DIR/PHARMACY"
mkdir -p "$OUTPUT_DIR/PREDETERMINATIONS"

echo "=========================================="
echo "Processing ESC Claim File Samples"
echo "=========================================="
echo ""

# Process DENTAL files
echo "Processing DENTAL files..."
for file in "$SAMPLES_DIR/DENTAL"/*; do
    if [ -f "$file" ]; then
        filename=$(basename "$file")
        echo "  - Processing: $filename"
        dotnet "$DLL_PATH" \
            --feed "$PROJECT_ROOT/Config/dental_feed.yml" \
            --input "$file" \
            --output "$OUTPUT_DIR/DENTAL/${filename}_output.jsonl"
        echo "    ✓ Output: $OUTPUT_DIR/DENTAL/${filename}_output.jsonl"
    fi
done
echo ""

# Process EHC files
echo "Processing EHC files..."
for file in "$SAMPLES_DIR/EHC"/*; do
    if [ -f "$file" ]; then
        filename=$(basename "$file")
        echo "  - Processing: $filename"
        dotnet "$DLL_PATH" \
            --feed "$PROJECT_ROOT/Config/health_feed.yml" \
            --input "$file" \
            --output "$OUTPUT_DIR/EHC/${filename}_output.jsonl"
        echo "    ✓ Output: $OUTPUT_DIR/EHC/${filename}_output.jsonl"
    fi
done
echo ""

# Process PHARMACY files
echo "Processing PHARMACY files..."
for file in "$SAMPLES_DIR/PHARMACY"/*; do
    if [ -f "$file" ]; then
        filename=$(basename "$file")
        echo "  - Processing: $filename"
        dotnet "$DLL_PATH" \
            --feed "$PROJECT_ROOT/Config/pharmacy_feed.yml" \
            --input "$file" \
            --output "$OUTPUT_DIR/PHARMACY/${filename}_output.jsonl"
        echo "    ✓ Output: $OUTPUT_DIR/PHARMACY/${filename}_output.jsonl"
    fi
done
echo ""

# Process PREDETERMINATIONS files
echo "Processing PREDETERMINATIONS files..."
for file in "$SAMPLES_DIR/PREDETERMINATIONS"/*; do
    if [ -f "$file" ]; then
        filename=$(basename "$file")
        echo "  - Processing: $filename"
        dotnet "$DLL_PATH" \
            --feed "$PROJECT_ROOT/Config/dental_pred_feed.yml" \
            --input "$file" \
            --output "$OUTPUT_DIR/PREDETERMINATIONS/${filename}_output.jsonl"
        echo "    ✓ Output: $OUTPUT_DIR/PREDETERMINATIONS/${filename}_output.jsonl"
    fi
done
echo ""

echo "=========================================="
echo "Processing Complete!"
echo "=========================================="
echo "Output files are located in: $OUTPUT_DIR"
