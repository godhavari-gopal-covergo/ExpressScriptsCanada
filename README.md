## ExpressScriptsCanada Modules

This repo hosts production-ready ETL modules for Express Scripts Canada. Each module lives in its own project folder so it can keep dedicated configuration, rules, and release cadence.

### Current layout

```
ExpressScriptsCanada/
├── EligibilityModule/          # JSON → fixed-width eligibility feed (today)
│   ├── Config/
│   ├── Input/
│   ├── Models/
│   ├── Program.cs
│   └── EligibilityModule.csproj
├── ExperienceModule/           # (reserved for future claims feed)
├── .cursor/                    # repo-wide Cursor rules
└── ExpressScriptsCanada.sln    # references each module project
```

### Running the eligibility module

```
cd ExpressScriptsCanada
dotnet run --project EligibilityModule/EligibilityModule.csproj
```

Outputs land in `EligibilityModule/Output` with timestamped filenames.

### Modifying a module

- Eligibility-specific logic lives entirely inside `EligibilityModule/Config/` (YAML definitions, lookup tables) and `EligibilityModule/Input/` (sample fixtures).
- Each module can define its own Cursor rules under `MODULE/.cursor/` for team guidance.
- Shared conventions (null handling, config-first approach) are documented under `/.cursor/rules/`.

Only assets needed to produce the feeds live here—prototype docs, utilities, or research files stay in the original POC folder.

