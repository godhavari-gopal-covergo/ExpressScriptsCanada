#!/usr/bin/env python3
"""Generate markdown docs comparing record field applicability across modules."""

from __future__ import annotations

import argparse
import json
import sys
from collections import defaultdict
from pathlib import Path
from typing import Any, Dict, List

try:
    import yaml
except ImportError as exc:  # pragma: no cover - dependency guard
    raise SystemExit(
        "PyYAML is required to run this script. Install it with `pip install PyYAML`."
    ) from exc


MODULE_DIR_MAP = {
    "Health": "Health",
    "Pharmacy": "Pharmacy",
    "Dental": "Dental",
    "DentalPreD": "DentalPreDetermination",
}

MODULE_ORDER = ["Health", "Pharmacy", "Dental", "DentalPreD"]
APPLICABLE_MARK = "✓"
HIGHLIGHT_STYLE = "background-color:#ffe6e6;color:#a30000;"


def parse_args() -> argparse.Namespace:
    parser = argparse.ArgumentParser(
        description=(
            "Generate markdown files under Docs/FieldComparison that compare "
            "record fields across Health, Pharmacy, Dental, and DentalPreD modules."
        )
    )
    parser.add_argument(
        "--root",
        type=Path,
        default=Path(__file__).resolve().parents[1],
        help="Path to the ExperienceModule root (defaults to script/../..).",
    )
    parser.add_argument(
        "--output",
        type=Path,
        help="Optional override for the output directory (defaults to ROOT/Docs/FieldComparison).",
    )
    return parser.parse_args()


def load_record_files(records_dir: Path) -> Dict[str, Dict[str, Any]]:
    """Load all record YAML files within a module directory keyed by record_type."""
    record_data: Dict[str, Dict[str, Any]] = {}

    for file_path in sorted(records_dir.glob("record_*.yml")):
        with file_path.open("r", encoding="utf-8") as handle:
            payload = yaml.safe_load(handle) or {}

        record_type = str(payload.get("record_type") or file_path.stem.split("_", 1)[-1])
        record_data[record_type] = {
            "description": (payload.get("description") or "").strip(),
            "fields": payload.get("fields") or [],
        }

    return record_data


def collect_records(root: Path) -> Dict[str, Dict[str, Any]]:
    """Aggregate record definitions across modules keyed by record type."""
    records_by_type: Dict[str, Dict[str, Any]] = defaultdict(lambda: {"modules": {}})
    records_root = root / "Config" / "Records"

    for module_key, dirname in MODULE_DIR_MAP.items():
        module_dir = records_root / dirname
        if not module_dir.exists():
            continue

        module_records = load_record_files(module_dir)
        for record_type, payload in module_records.items():
            records_by_type[record_type]["modules"][module_key] = payload

    return records_by_type


def format_field_details(field: Dict[str, Any]) -> str:
    """Build a concise format description for a field."""
    if not field:
        return "-"

    fmt = field.get("format")
    return str(fmt) if fmt else "-"


def format_field_number(field: Dict[str, Any]) -> str:
    if not field:
        return ""

    field_number = field.get("field_number")
    if field_number is None:
        return ""

    value = str(field_number).strip()
    if not value:
        return ""

    return value.zfill(3) if value.isdigit() else value


def normalize_whitespace(value: str) -> str:
    text = str(value)
    return " ".join(text.split())


def field_display_name(field: Dict[str, Any]) -> str:
    raw_value = (
        field.get("name")
        or field.get("key")
        or field.get("description")
        or "Field"
    )
    return normalize_whitespace(raw_value)


def normalize_field_name(name: str) -> str:
    return normalize_whitespace(name).lower()


def is_filler_name(name: str) -> bool:
    normalized = normalize_field_name(name)
    return "filler" in normalized


def build_rows(record_payload: Dict[str, Any]) -> List[Dict[str, Any]]:
    """Create a list of field rows keyed by field name."""
    row_map: Dict[str, Dict[str, Any]] = {}
    appearance_order: List[str] = []
    modules = record_payload["modules"]

    for module_key, module_data in modules.items():
        for field in module_data.get("fields", []):
            field_name = field_display_name(field)
            key = normalize_field_name(field_name)

            if key not in row_map:
                row_map[key] = {
                    "field_name": field_name,
                    "per_module": {},
                    "order": len(appearance_order),
                }
                appearance_order.append(key)

            row_map[key]["per_module"][module_key] = field

    return sorted(row_map.values(), key=lambda row: row["order"])


def row_has_format_discrepancy(row: Dict[str, Any]) -> bool:
    if is_filler_name(row["field_name"]):
        return False

    formats = set()
    for module_key in MODULE_ORDER:
        field = row["per_module"].get(module_key)
        fmt = field.get("format") if field else None
        if fmt:
            formats.add(str(fmt))
    return len(formats) > 1


def highlight_cells(cells: List[str]) -> List[str]:
    return [
        f'<span style="{HIGHLIGHT_STYLE}">{cell or "&nbsp;"}</span>' for cell in cells
    ]


def render_markdown(record_type: str, payload: Dict[str, Any]) -> str:
    """Build the markdown content for a single record type."""
    lines: List[str] = []
    modules = payload["modules"]
    primary_description = next(
        (data.get("description") for _, data in sorted(modules.items()) if data.get("description")),
        "",
    )

    title = f"# Record Type {record_type}"
    if primary_description:
        title += f" – {primary_description}"
    lines.append(title)
    lines.append("")

    lines.append("## Module Coverage")
    for module_key in MODULE_ORDER:
        if module_key in modules:
            description = modules[module_key].get("description") or "-"
            lines.append(f"- **{module_key}**: {description}")
        else:
            lines.append(f"- **{module_key}**: _Not defined_")
    lines.append("")

    header_cells = ["S.No", "Field Name"]
    for module_key in MODULE_ORDER:
        header_cells.extend(
            [
                f"{module_key} Applicable",
                f"{module_key} Field #",
                f"{module_key} Format",
            ]
        )

    lines.append("| " + " | ".join(header_cells) + " |")
    lines.append("| " + " | ".join(["---"] * len(header_cells)) + " |")

    for idx, row in enumerate(build_rows(payload), start=1):
        row_cells = [str(idx), row["field_name"]]
        for module_key in MODULE_ORDER:
            field_details = row["per_module"].get(module_key)
            applicable = APPLICABLE_MARK if field_details else ""
            row_cells.append(applicable)
            row_cells.append(format_field_number(field_details))
            row_cells.append(format_field_details(field_details) if field_details else "")
        if row_has_format_discrepancy(row):
            row_cells = highlight_cells(row_cells)
        lines.append("| " + " | ".join(row_cells) + " |")

    if len(lines) == 2:
        lines.append("_No fields defined for this record type._")

    return "\n".join(lines) + "\n"


def write_markdown_files(records_by_type: Dict[str, Dict[str, Any]], output_dir: Path) -> List[Path]:
    output_dir.mkdir(parents=True, exist_ok=True)
    written_files: List[Path] = []

    for record_type in sorted(records_by_type.keys(), key=lambda x: int(x) if x.isdigit() else x):
        content = render_markdown(record_type, records_by_type[record_type])
        output_path = output_dir / f"record_{record_type}.md"
        output_path.write_text(content, encoding="utf-8")
        written_files.append(output_path)

    return written_files


def main() -> None:
    args = parse_args()
    root = args.root
    output_dir = args.output or root / "Docs" / "FieldComparison"

    records_by_type = collect_records(root)
    if not records_by_type:
        raise SystemExit("No record definitions found.")

    written_files = write_markdown_files(records_by_type, output_dir)
    summary = {
        "record_count": len(records_by_type),
        "files_written": len(written_files),
        "output_dir": str(output_dir),
    }
    print(json.dumps(summary, indent=2))


if __name__ == "__main__":
    main()

