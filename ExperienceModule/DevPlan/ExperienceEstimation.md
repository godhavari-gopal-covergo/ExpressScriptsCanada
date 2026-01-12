# ESC Experience Module – Dental, Health, Pharmacy, Dental PD Estimates

Derived from the Dental parser POC (`DevPlan/DentalFeedPOC.md`), ESC specification dumps under `Specs/`, and the shared estimation workbook in `ETL/ESCExperienceCGLogic/ESC_CLAIM_FEEDS_ESTIMATION.md`. Field counts come directly from the specs (docx/pdfminer exports); rules count reflects explicit constraints plus narrative requirements in each section. Dental rows reflect the baseline POC delivered this iteration (used as reference for the other feeds).

| Spec | Record Type / Work Item | # Fields | # Rules | Complexity | Hours | Key considerations |
| --- | --- | --- | --- | --- | --- | --- |
| Dental | Record 0 – File Header | 15 | 10 | Medium | 10 | Run-date/sequence validation, cut-off date comparison, destination metadata normalization. |
| Dental | Record 2 – Provider Header | 18 | 20+ | High | 14 | Multi-line address normalization, payee routing, EFT routing segmentation. |
| Dental | Record 3 – Client Address | 23 | 18+ | High | 16 | Client vs third-party payee selection, fallback defaults, suppressions when provider paid. |
| Dental | Record 4 – Claim Detail (Paid) | 113 | 60+ | Very High | 60 | Service aggregation, allowed/paid splits, mapping to ClaimData dental/drug sections. |
| Dental | Record 5 – Claim Detail (Reversal) | 113 | 45+ | High | 60 | Reversal sequencing, financial negation, linkage back to originating claim lines. |
| Dental | Record 6 – Provider Batch Control | 8 | 8 | Medium | 8 | Batch totals, amount balancing, rejection reason capture. |
| Dental | Record 7 – Client Batch Control | 8 | 8 | Medium | 8 | Client-level totals, payee confirmation, rejection reason capture. |
| Dental | Record 8 – File Batch Control | 9 | 9 | Medium | 8 | Global totals vs header, record count reconciliation, timestamp confirmation. |
| Dental | Cross-record orchestration | - | 25+ | High | 40 | Enforce ordering (0, providers, clients, trailer, file), streaming grouping, error isolation. |
| Health (EHC) | Record 0 – File Header | 15 | 10 | Medium | 6 | Reuse dental header; add tenant destination overrides. |
| Health (EHC) | Record 2 – Provider Header | 18 | 18+ | Medium | 8 | Discipline/license fields, provider category validations. |
| Health (EHC) | Record 3 – Client Address | 23 | 18+ | Medium | 10 | Client vs third-party payee defaults + enrolment flags. |
| Health (EHC) | Record 4 – Claim Detail (Paid) | 113 | 70+ | Very High | 50 | DIN + benefit math, COB sequencing, coordination of benefits. |
| Health (EHC) | Record 5 – Claim Detail (Reversal) | 113 | 45+ | High | 40 | Reverse-flow adjudication, prior claim linkage, aggregate limit adjustments. |
| Health (EHC) | Record 6 – Provider Batch Control | 8 | 8 | Medium | 6 | Batch totals + provider error propagation. |
| Health (EHC) | Record 7 – Client Batch Control | 8 | 8 | Medium | 6 | Client totals, payee confirmation flows. |
| Health (EHC) | Record 8 – File Batch Control | 9 | 9 | Medium | 6 | Global totals & acknowledgement hooks. |
| Health (EHC) | Cross-record orchestration (reuse) | - | 25+ | Medium | 8 | Configure record-order rules + regression tests over EHC sample files. |
| Health (EHC) | Benefit normalization orchestration | - | 25+ | High | 36 | Map parsed drug/paramedical claims into canonical JSON + tests. |
| Pharmacy | Record 0 – File Header | 14 | 6 | Medium | 6 | Multi-destination metadata, same parser hooks as dental POC. |
| Pharmacy | Record 2 – Pharmacy Header | 16 | 9 | High | 12 | Chain routing, EFT fields, bilingual flags per spec. |
| Pharmacy | Record 3 – Payee Address | 15 | 7 | Medium | 10 | Pay direction + payee chain fallback rules. |
| Pharmacy | Record 4 – Claim Detail (Paid) | 123 | 105 | Very High | 65 | DIN/formulary lookups, compound logic, provincial pricing policies. |
| Pharmacy | Record 5 – Claim Detail (Reversal) | 123 | 60+ | High | 45 | Reverse adjudication, inventory impact, COB rebalancing per spec. |
| Pharmacy | Record 6 – Pharmacy Batch Control | 5 | 3 | Medium | 6 | Batch totals per pharmacy, error messaging to state machine. |
| Pharmacy | Record 7 – Payee Batch Control | 5 | 3 | Medium | 6 | Payee-level balancing vs remittance feed. |
| Pharmacy | Record 8 – File Batch Control | 5 | 6 | Medium | 6 | Daily balancing + SFTP ack, same as dental once fields wired. |
| Pharmacy | Cross-record orchestration (reuse) | - | 25+ | Medium | 10 | Apply pharmacy-specific grouping (payee record 3) + DIN reversal scenarios in streaming engine. |
| Pharmacy | DIN/formulary + pricing orchestration | - | 30+ | High | 40 | Load DIN catalog, link ESC pricing policies, emit drug JSON. |
| Dental PD | Processor Header Record | 15 | 10 | Medium | 10 | Schedule metadata + carrier routing. |
| Dental PD | Provider Header Record | 16 | 15+ | Medium | 12 | Treating vs billing provider alignment and province lookups. |
| Dental PD | Client Address Record | 12 | 12 | Medium | 10 | Claimant vs third-party mapping + payee type enforcement. |
| Dental PD | Predetermination General Record | 43 | 35+ | High | 60 | Plan/authorization context, tooth range parsing. |
| Dental PD | Predetermination Detail Record | 47 | 40+ | Very High | 72 | Line-level lab/surface data, frequency qualifiers, amount math. |
| Dental PD | Provider Batch Control Record | 6 | 6 | Medium | 6 | Totals per provider block. |
| Dental PD | Client Batch Control Record | 6 | 6 | Medium | 6 | Per-client counts + rejection reasons. |
| Dental PD | Tape Batch Control Record | 7 | 7 | Medium | 6 | Global totals & verification vs headers. |
| Dental PD | Cross-record orchestration (reuse) | - | 25+ | Medium | 8 | Configure PD-specific grouping (general/detail per provider/client) and verify trailers. |
| Dental PD | PD→Claim transformation orchestration | - | 20+ | High | 32 | Translate PD payload into ClaimData pre-adjudication graph. |
| Common | Analysis of ESC Specification Documents | - | - | Medium | 20 | Cross-feed spec deep dives to extract field/rule metadata and identify deltas vs Dental POC. |
| Common | Solution Design and Architecture | - | - | Medium | 16 | Update ExperienceModule architecture to plug additional feeds, config schema docs, and dependency wiring. |
| Common | Documentation | - | - | Medium | 20 | Expand README/DevPlan with runbooks, config guidance, and estimation notes for new feeds. |

### Dental Record Field Counts

| Record type | Description | Field count |
| --- | --- | --- |
| 0 | File Header Record | 15 |
| 2 | Provider Header Record | 18 |
| 3 | Client Address Record | 23 |
| 4 | Claim Record (Paid) | 113 |
| 5 | Claim Record (Reversal) | 113 |
| 6 | Provider Batch Control Record | 8 |
| 7 | Client Batch Control Record | 8 |
| 8 | File Batch Control Record | 9 |
| **Total** | — | **307** |

## Assumptions & Notes
- Hours reflect parser + mapper engineering effort only; infra shared with dental POC is already in place.
- Rule counts shown with `+` indicate additional narrative constraints in the spec that will be codified during implementation.
- Records 4 and 5 are itemized separately per ESC spec; hours are split from the original combined estimate so overall totals remain unchanged.
- Even when logic is reused (e.g., cross-record orchestration), each feed includes explicit effort for configuration/mapping/test work needed to enable that reuse.
- Dental rows serve as the validated baseline from the POC; other feeds inherit parser components and effort savings relative to those figures.
- For Pharmacy, DIN/formulary orchestration includes ingesting the DIN catalog and ESC pricing policy references that are separate from the fixed-width feed.

