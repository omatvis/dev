# Optional AI Data Engineer Track

This section is intentionally optional. Finish the main 8-week plan first, then use this track if you want to work on AI-ready data platforms, RAG pipelines, or data products that support LLM applications.

## Why this comes later

For your transition, classic data engineering skills create the fastest return:
- Python
- PySpark
- Databricks
- ADF orchestration
- Lakehouse/data quality basics

AI data engineering becomes much easier once those are solid.

## Suggested 4-week optional track

### Week A1 - AI data pipeline foundations

#### Goals
- Understand how AI data pipelines differ from standard BI/reporting pipelines
- Learn the vocabulary: embeddings, chunks, metadata, retrieval, vector indexes

#### Topics
- RAG architecture basics
- Structured vs unstructured data pipelines
- Document chunking and metadata enrichment
- Data quality dimensions for AI retrieval

#### Practical exercises
- Take 10-20 small documents and design a chunking strategy
- Define metadata fields that would help filtering and retrieval
- Write a short note comparing BI marts vs RAG-ready document stores

#### Expected outcomes
- You can explain the data engineer role in AI systems
- You understand why chunking, metadata, and freshness matter

#### Resources
- Azure AI Search RAG overview: <https://learn.microsoft.com/azure/search/retrieval-augmented-generation-overview>
- Azure architecture for RAG: <https://learn.microsoft.com/azure/architecture/ai-ml/guide/rag/rag-solution-design-and-evaluation-guide>
- Databricks Mosaic AI docs: <https://docs.databricks.com/en/generative-ai/index.html>
- LangChain concepts: <https://python.langchain.com/docs/concepts/>

---

### Week A2 - Vector search and unstructured ingestion

#### Goals
- Learn the storage and retrieval side of AI-oriented data systems
- Build intuition for vector search without getting lost in model internals

#### Topics
- Embeddings at a conceptual level
- Vector databases / vector search services
- Parsing PDFs, web pages, and text corpora
- Metadata and filtering patterns

#### Practical exercises
- Ingest a small document corpus
- Produce chunks and attach metadata such as source, title, date, and section
- Compare what good vs poor chunking would look like

#### Expected outcomes
- You understand the upstream data preparation needed for AI apps
- You can discuss vector search in practical DE terms

#### Resources
- Azure AI Search vector search overview: <https://learn.microsoft.com/azure/search/vector-search-overview>
- OpenAI embeddings guide: <https://platform.openai.com/docs/guides/embeddings>
- Databricks vector search docs: <https://docs.databricks.com/en/generative-ai/vector-search.html>
- Unstructured docs: <https://docs.unstructured.io/>

---

### Week A3 - Quality, governance, and evaluation for AI data

#### Goals
- Focus on trust, traceability, and governance
- Learn how AI data quality differs from standard tabular quality checks

#### Topics
- Freshness, duplication, provenance, and permission boundaries
- PII and sensitive data handling
- Hallucination risk from poor retrieval data
- Evaluation basics for retrieval quality

#### Practical exercises
- Define quality checks for an internal document ingestion pipeline
- Create a simple evaluation checklist for retrieval relevance
- Identify where PII or confidential content could enter the pipeline

#### Expected outcomes
- You can talk about AI data governance responsibly
- You can design safer ingestion and retrieval pipelines

#### Resources
- Azure AI/ML architecture guidance: <https://learn.microsoft.com/azure/architecture/ai-ml/>
- Microsoft Responsible AI resources: <https://www.microsoft.com/ai/responsible-ai>
- NIST AI Risk Management Framework: <https://www.nist.gov/itl/ai-risk-management-framework>
- Databricks governance and Unity Catalog docs: <https://docs.databricks.com/en/data-governance/unity-catalog/index.html>

---

### Week A4 - Mini AI DE project

#### Goals
- Build a small, explainable AI-oriented data pipeline
- Reuse your main-plan DE skills in a new context

#### Project idea
Build a **document ingestion pipeline** that:
- collects files or pages
- extracts text
- chunks content
- adds metadata
- stores output in a structured format for later embedding/indexing

#### Practical exercises
- Create Bronze/Silver-style stages for raw and cleaned documents
- Add metadata fields for ownership, source, timestamp, and tags
- Document how the dataset would later connect to vector search or RAG

#### Expected outcomes
- You have a credible bridge from data engineering into AI data platforms
- You can explain AI DE work without needing to be an ML engineer first

#### Resources
- Azure Data Factory docs: <https://learn.microsoft.com/azure/data-factory/>
- Databricks workflows docs: <https://docs.databricks.com/en/jobs/index.html>
- Delta Lake docs: <https://docs.delta.io/latest/index.html>
- Azure AI Search documentation: <https://learn.microsoft.com/azure/search/>

## Concise resource list

- Databricks generative AI docs: <https://docs.databricks.com/en/generative-ai/index.html>
- Azure AI Search docs: <https://learn.microsoft.com/azure/search/>
- Azure RAG guidance: <https://learn.microsoft.com/azure/architecture/ai-ml/guide/rag/>
- Unity Catalog docs: <https://docs.databricks.com/en/data-governance/unity-catalog/index.html>
- NIST AI RMF: <https://www.nist.gov/itl/ai-risk-management-framework>

## Recommendation

Treat this as a **phase 2 specialization**, not a replacement for core data engineering. Strong AI data engineers usually stand on strong classic DE fundamentals first.
