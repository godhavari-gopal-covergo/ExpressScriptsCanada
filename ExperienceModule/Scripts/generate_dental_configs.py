import re
from pathlib import Path

import pdfplumber
import yaml

ROOT = Path(__file__).resolve().parents[1]
PDF_PATH = ROOT / "Specs" / "Claim - Dental.docx.pdf"
OUTPUT_DIR = ROOT / "Config" / "Records" / "Dental"
OUTPUT_DIR.mkdir(parents=True, exist_ok=True)

DESC_MAP = {
    "0": "File Header Record",
    "2": "Provider Header Record",
    "3": "Client Address Record",
    "4": "Claim Record (Paid)",
    "5": "Claim Record (Reversal)",
    "6": "Provider Batch Control Record",
    "7": "Client Batch Control Record",
    "8": "File Batch Control Record",
}


def slugify(name: str) -> str:
    slug = re.sub(r"[^a-z0-9]+", "_", name.lower()).strip("_")
    if not slug:
        slug = "field"
    return slug


def parse_tables():
    record_rows = {}
    current_records = None
    with pdfplumber.open(PDF_PATH) as pdf:
        for page in pdf.pages:
            tables = page.extract_tables() or []
            for table in tables:
                if not table or table[0][0] != "Field #":
                    continue
                rows = []
                for row in table[1:]:
                    if not row or not row[0] or not row[0].strip().isdigit():
                        continue
                    rows.append(row)
                if not rows:
                    continue
                first_field = rows[0][0].strip()
                record_types = None
                if first_field == "001":
                    record_hint = (rows[0][3] or "").strip()
                    if "4 = Paid Claim" in record_hint and "5 = Reversal" in record_hint:
                        record_types = ["4", "5"]
                    else:
                        match = re.search(r'"?(\d+)"?', record_hint)
                        if match:
                            record_types = [match.group(1)]
                    current_records = record_types
                else:
                    record_types = current_records
                if not record_types:
                    continue
                for record_type in record_types:
                    record_rows.setdefault(record_type, []).extend(rows)
    return record_rows


def build_field(node, existing_keys):
    field_number = node[0].strip()
    name = (node[1] or "").strip() or f"Field {field_number}"
    fmt = (node[2] or "").strip()
    description = " ".join((node[3] or "").split())
    position = (node[4] or "").strip()
    start = end = length = None
    match = re.match(r"(\d+)-(\d+)", position)
    if match:
        start = int(match.group(1))
        end = int(match.group(2))
        length = end - start + 1
    key_base = slugify(name)
    key = key_base
    suffix = 2
    while key in existing_keys:
        key = f"{key_base}_{suffix}"
        suffix += 1
    existing_keys.add(key)
    return {
        "field_number": field_number,
        "name": name,
        "key": key,
        "start": start,
        "end": end,
        "length": length,
        "format": fmt,
        "description": description or None,
    }


def write_yaml(record_type, rows):
    existing_keys = set()
    fields = [build_field(row, existing_keys) for row in rows]
    payload = {
        "record_type": record_type,
        "description": DESC_MAP.get(record_type, f"Record Type {record_type}"),
        "fields": fields,
    }
    target = OUTPUT_DIR / f"record_{record_type}.yml"
    with target.open("w", encoding="utf-8") as fh:
        yaml.safe_dump(payload, fh, sort_keys=False, allow_unicode=True)
    print(f"Wrote {target} ({len(fields)} fields)")


def main():
    records = parse_tables()
    for record_type, rows in records.items():
        write_yaml(record_type, rows)


if __name__ == "__main__":
    main()

