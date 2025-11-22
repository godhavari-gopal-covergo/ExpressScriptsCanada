# Test Evidence - `total_amt_paid` formatting

## Scenario
Verify that `total_amt_paid` is emitted as a monetary amount with two decimal places, per the Claim Record field 039 definition in `Specs/Claim - Dental.docx`.

## Commands
```shell
dotnet run -- --input Input/dental_sample.txt --output Output/test_total_amt_paid.jsonl
python - <<'PY'
import json
from pathlib import Path
path = Path('Output/test_total_amt_paid.jsonl')
with path.open() as fh:
    for line in fh:
        obj = json.loads(line)
        if obj.get('batchType') == 'provider':
            detail = obj['details'][0]
            print('Example total_amt_paid:', detail['fields']['total_amt_paid'])
            break
PY
```

## Evidence
```
Parsed 704 records
   Provider batches: 137
   Client batches:   68
Output written to .../Output/test_total_amt_paid.jsonl
Example total_amt_paid: 960.00
```

The sample provider detail now shows `total_amt_paid: 960.00` instead of the raw `0096000`, demonstrating the implied-decimal formatting.

