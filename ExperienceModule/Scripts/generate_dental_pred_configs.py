#!/usr/bin/env python3
"""Generate Dental Pre-Determination record YAMLs from the ESC spec."""

from __future__ import annotations

import re
import unicodedata
from collections import defaultdict
from dataclasses import dataclass
from pathlib import Path
from typing import Iterable

import pdfplumber  # type: ignore
import yaml

ROOT = Path(__file__).resolve().parents[1]
SPEC_PATH = ROOT / "Specs" / "Claim - Dental Pre Determination.docx.pdf"
OUTPUT_DIR = ROOT / "Config" / "Records" / "DentalPreDetermination"

RECORD_PAGE_MAP = {
    "0": [3],
    "2": [4],
    "3": [5],
    "4": [6, 7, 8],
    "5": [9, 10, 11, 12],
    "6": [13],
    "7": [14],
    "8": [15],
}

DESCRIPTIONS = {
    "0": "Processor Header Record",
    "2": "Provider Header Record",
    "3": "Client Address Record",
    "4": "Predetermination General Record",
    "5": "Predetermination Detail Record",
    "6": "Provider Batch Control Record",
    "7": "Client Batch Control Record",
    "8": "Tape Batch Control Record",
}


@dataclass
class FieldRow:
    field_number: str
    name: str
    fmt: str
    description: str | None
    start: int
    end: int

    @property
    def length(self) -> int:
        return self.end - self.start + 1


def parse_tables(pages: Iterable[int]) -> list[FieldRow]:
    rows: list[FieldRow] = []
    with pdfplumber.open(SPEC_PATH) as pdf:
        for page_index in pages:
            page = pdf.pages[page_index]
            for table in page.extract_tables() or []:
                for raw in table:
                    field_number = (raw[0] or "").strip()
                    if not re.fullmatch(r"\d{3}", field_number):
                        continue
                    name = clean_text(raw[1])
                    fmt = clean_text(raw[2])
                    description = clean_text(raw[3]) or None
                    position_raw = clean_text(raw[4])
                    if not name or not fmt or not position_raw:
                        continue
                    start, end = parse_position(position_raw)
                    rows.append(
                        FieldRow(
                            field_number=field_number,
                            name=name,
                            fmt=fmt,
                            description=description,
                            start=start,
                            end=end,
                        )
                    )
    return rows


def clean_text(value: str | None) -> str:
    if not value:
        return ""
    text = value.replace("\n", " ").replace("\u2013", "-").strip()
    return unicodedata.normalize("NFKC", text)


def parse_position(value: str) -> tuple[int, int]:
    value = value.replace("\u2013", "-")
    start_str, end_str = [part.strip() for part in value.split("-")]
    return int(start_str), int(end_str)


def slugify(name: str, existing: dict[str, int]) -> str:
    normalized = unicodedata.normalize("NFKD", name)
    ascii_only = normalized.encode("ascii", "ignore").decode()
    cleaned = re.sub(r"[^a-zA-Z0-9]+", "_", ascii_only).strip("_").lower() or "field"
    count = existing[cleaned]
    existing[cleaned] += 1
    if count:
        cleaned = f"{cleaned}_{count+1}"
    return cleaned


def parse_value_format(fmt: str) -> dict[str, int] | None:
    if "V" in fmt:
        decimals = fmt.split("V", 1)[1]
        scale = 0
        for match in re.finditer(r"9(?:\((\d+)\))?", decimals):
            digits = match.group(1)
            scale += int(digits) if digits else 1
        if scale:
            return {"type": "implied_decimal", "scale": scale}
        return None
    comma_match = re.search(r"9\(\s*\d+\s*,\s*(\d+)\s*\)", fmt)
    if comma_match:
        return {"type": "implied_decimal", "scale": int(comma_match.group(1))}
    return None


def build_yaml(record_type: str, rows: list[FieldRow]) -> str:
    key_counts: defaultdict[str, int] = defaultdict(int)
    fields = []
    for row in rows:
        field = {
            "field_number": row.field_number,
            "name": row.name,
            "key": slugify(row.name, key_counts),
            "start": row.start,
            "end": row.end,
            "length": row.length,
            "format": row.fmt,
        }
        if row.description:
            field["description"] = row.description
        value_format = parse_value_format(row.fmt)
        if value_format:
            field["value_format"] = value_format
        fields.append(field)

    payload = {
        "record_type": record_type,
        "description": DESCRIPTIONS.get(record_type, ""),
        "fields": fields,
    }
    return yaml.safe_dump(payload, sort_keys=False, allow_unicode=True)


def main() -> None:
    OUTPUT_DIR.mkdir(parents=True, exist_ok=True)
    for record_type, pages in RECORD_PAGE_MAP.items():
        rows = parse_tables(pages)
        yaml_str = build_yaml(record_type, rows)
        target = OUTPUT_DIR / f"record_{record_type}.yml"
        target.write_text(yaml_str)
        print(f"Wrote record {record_type} with {len(rows)} fields -> {target}")


if __name__ == "__main__":
    if not SPEC_PATH.exists():
        raise SystemExit(f"Spec not found at {SPEC_PATH}")
    main()
