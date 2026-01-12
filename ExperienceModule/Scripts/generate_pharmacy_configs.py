#!/usr/bin/env python3
"""Utility script to generate Pharmacy record YAML configs from the ESC spec PDF."""

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
SPEC_PATH = ROOT / "Specs" / "Claim Pharmacy.pdf"
OUTPUT_DIR = ROOT / "Config" / "Records" / "Pharmacy"

RECORD_PAGE_MAP = {
    "0": [4],
    "2": [5],
    "3": [6, 7],
    "4": list(range(8, 19)),
    "6": [19],
    "7": [20],
    "8": [21],
}

DESCRIPTIONS = {
    "0": "File Header Record",
    "2": "Pharmacy Header Record",
    "3": "Payee Address Record",
    "4": "Claim Record (Paid)",
    "5": "Claim Record (Reversal)",
    "6": "Pharmacy Batch Control Record",
    "7": "Payee Batch Control Record",
    "8": "File Batch Control Record",
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
            for table in page.extract_tables():
                for raw in table:
                    field_number = (raw[0] or "").strip()
                    if not re.fullmatch(r"\d{3}[A-Z]?", field_number):
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
    text = value.replace("\n", " ").strip()
    return unicodedata.normalize("NFKC", text)


def parse_position(value: str) -> tuple[int, int]:
    value = value.replace("–", "-")
    start_str, end_str = [part.strip() for part in value.split("-")]
    return int(start_str), int(end_str)


def slugify(name: str, existing: dict[str, int]) -> str:
    normalized = unicodedata.normalize("NFKD", name)
    ascii_only = normalized.encode("ascii", "ignore").decode()
    cleaned = re.sub(r"[^a-zA-Z0-9]+", "_", ascii_only).strip("_").lower()
    if not cleaned:
        cleaned = "field"
    count = existing[cleaned]
    existing[cleaned] += 1
    if count:
        cleaned = f"{cleaned}_{count+1}"
    return cleaned


def parse_value_format(fmt: str) -> dict[str, int] | None:
    if "V" not in fmt:
        return None
    decimals = fmt.split("V", 1)[1]
    scale = 0
    for match in re.finditer(r"9(?:\((\d+)\))?", decimals):
        count = match.group(1)
        scale += int(count) if count else 1
    if scale == 0:
        return None
    return {"type": "implied_decimal", "scale": scale}


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
    cache: dict[str, list[FieldRow]] = {}
    for record_type, pages in RECORD_PAGE_MAP.items():
        print(f"Generating record {record_type} from pages {pages}")
        rows = parse_tables(pages)
        cache[record_type] = rows
        (OUTPUT_DIR / f"record_{record_type}.yml").write_text(
            build_yaml(record_type, rows)
        )
    if "4" in cache:
        (OUTPUT_DIR / "record_5.yml").write_text(build_yaml("5", cache["4"]))


if __name__ == "__main__":
    if not SPEC_PATH.exists():
        raise SystemExit(f"Spec not found at {SPEC_PATH}")
    main()
