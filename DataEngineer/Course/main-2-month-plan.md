# Main 2-Month Plan

This plan is optimized for your background:

- **Already strong**: SQL/T-SQL, relational thinking, DB design, software engineering habits
- **Main gaps to close**: Python for data work, Spark execution model, Databricks workflows, ADF orchestration, and modern lakehouse patterns
- **Pace**: **8-10 hours/week**

## Weekly time split

- **2-3 hrs** reading / videos / docs
- **4-5 hrs** hands-on coding
- **1-2 hrs** recap, notes, and small review tasks

> The links placed directly on each **Topics** line are the primary learning links for that exact topic.

---

## Week 1 - Python foundations for Data Engineering

### Goals
- Become productive in Python without re-learning general programming from scratch
- Translate your software engineering skills into data engineering workflows

### Topics
- Python setup, virtual environments, package basics — [venv](https://docs.python.org/3/tutorial/venv.html), [packaging guide](https://packaging.python.org/en/latest/tutorials/installing-packages/)
- Core syntax, functions, modules, exceptions — [Python tutorial](https://docs.python.org/3/tutorial/), [errors and exceptions](https://docs.python.org/3/tutorial/errors.html), [modules](https://docs.python.org/3/tutorial/modules.html)
- File I/O, JSON, CSV, HTTP requests — [input and output](https://docs.python.org/3/tutorial/inputoutput.html), [json](https://docs.python.org/3/library/json.html), [csv](https://docs.python.org/3/library/csv.html), [Requests quickstart](https://requests.readthedocs.io/en/latest/user/quickstart/)
- Quick SQL refresh: CTEs, window functions, aggregations — [CTEs](https://learn.microsoft.com/sql/t-sql/queries/with-common-table-expression-transact-sql), [window functions / OVER clause](https://learn.microsoft.com/sql/t-sql/queries/select-over-clause-transact-sql), [aggregate functions](https://learn.microsoft.com/sql/t-sql/functions/aggregate-functions-transact-sql)

### Practical exercises
- Read CSV and JSON files with Python
- Call a small public API and save the response locally
- Build a Python script that loads data, validates basic schema assumptions, and logs row counts
- Solve 5-10 SQL exercises focused on windows and CTEs

### Expected outcomes
- You can write small Python scripts confidently
- You can move data between files/APIs and structured tables
- You have a solid baseline for PySpark later

### Resources
- Microsoft Learn Python path: <https://learn.microsoft.com/training/paths/beginner-python/>
- Python tutorial: <https://docs.python.org/3/tutorial/>
- Requests quickstart: <https://requests.readthedocs.io/en/latest/user/quickstart/>
- SQL window functions reference: <https://learn.microsoft.com/sql/t-sql/queries/select-over-clause-transact-sql>

---

## Week 2 - Python data tooling and DE coding habits

### Goals
- Use Python for practical ingestion and transformation tasks
- Add basic engineering discipline: logging, structure, repeatability

### Topics
- Pandas basics for local inspection and cleanup — [pandas getting started](https://pandas.pydata.org/docs/getting_started/index.html)
- Working with Parquet vs CSV at a high level — [Parquet overview](https://parquet.apache.org/docs/overview/), [pandas I/O tools](https://pandas.pydata.org/docs/user_guide/io.html)
- Logging, configuration, reusable functions — [logging HOWTO](https://docs.python.org/3/howto/logging.html), [Python modules](https://docs.python.org/3/tutorial/modules.html)
- Intro to data quality checks — [Great Expectations overview](https://docs.greatexpectations.io/docs/core/introduction/introduction/), [Expectation concepts](https://docs.greatexpectations.io/docs/core/define_expectations/learn_expectations/expectation_overview/)

### Practical exercises
- Load a CSV dataset with pandas and clean nulls / data types
- Write a script that reads from one format and writes another
- Add logging and a simple config file or constants module
- Validate uniqueness / null rules for a few columns

### Expected outcomes
- You can build small local ETL scripts cleanly
- You understand where pandas helps and where Spark will be needed
- You can explain basic data quality checks

### Resources
- pandas getting started: <https://pandas.pydata.org/docs/getting_started/index.html>
- Python logging HOWTO: <https://docs.python.org/3/howto/logging.html>
- Apache Parquet overview: <https://parquet.apache.org/docs/overview/>
- Microsoft Learn data fundamentals modules: <https://learn.microsoft.com/training/browse/?terms=data%20engineering>

---

## Week 3 - Spark and PySpark fundamentals

### Goals
- Understand the Spark mental model before going deep into Databricks
- Start using PySpark DataFrames for transformations

### Topics
- Spark architecture, driver/executors, partitions — [Spark overview](https://spark.apache.org/docs/latest/cluster-overview.html), [RDD programming guide](https://spark.apache.org/docs/latest/rdd-programming-guide.html)
- Lazy evaluation, transformations vs actions — [RDD programming guide](https://spark.apache.org/docs/latest/rdd-programming-guide.html), [Spark SQL guide](https://spark.apache.org/docs/latest/sql-programming-guide.html)
- PySpark DataFrames, schema, filtering, joins, aggregations — [PySpark getting started](https://spark.apache.org/docs/latest/api/python/getting_started/index.html), [DataFrame quickstart](https://spark.apache.org/docs/latest/api/python/getting_started/quickstart_df.html)
- Read/write CSV and Parquet — [Spark SQL data sources](https://spark.apache.org/docs/latest/sql-data-sources.html), [Parquet files](https://spark.apache.org/docs/latest/sql-data-sources-parquet.html)

### Practical exercises
- Create a local or notebook-based PySpark job
- Read source files, apply filters and joins, and write Parquet output
- Compare a pandas workflow vs a PySpark workflow on the same dataset
- Practice simple explain-plan reading at a conceptual level

### Expected outcomes
- You understand why Spark is different from pandas
- You can perform common ETL-style transformations in PySpark
- You can explain partitions, shuffles, and lazy execution in simple terms

### Resources
- PySpark getting started: <https://spark.apache.org/docs/latest/api/python/getting_started/index.html>
- PySpark DataFrame quickstart: <https://spark.apache.org/docs/latest/api/python/getting_started/quickstart_df.html>
- Spark SQL guide: <https://spark.apache.org/docs/latest/sql-programming-guide.html>
- Databricks Lakehouse architecture: <https://docs.databricks.com/en/lakehouse-architecture/index.html>

---

## Week 4 - Databricks basics and Delta Lake

### Goals
- Become comfortable with the Databricks workspace and notebook/job model
- Learn the core lakehouse concepts used in data engineering roles

### Topics
- Databricks workspace, notebooks, clusters, jobs — [Databricks getting started](https://docs.databricks.com/en/getting-started/index.html), [Databricks jobs](https://docs.databricks.com/en/jobs/index.html)
- Delta Lake basics: ACID tables, schema enforcement, versioning — [Delta Lake docs](https://docs.delta.io/latest/index.html), [Delta batch](https://docs.delta.io/latest/delta-batch.html)
- Bronze / Silver / Gold architecture — [medallion architecture](https://docs.databricks.com/en/lakehouse/medallion.html)
- Basic notebook organization and parameterization — [Databricks notebooks](https://docs.databricks.com/en/notebooks/index.html), [Databricks widgets](https://docs.databricks.com/en/notebooks/widgets.html)

### Practical exercises
- Create a notebook that ingests raw data into a Bronze layer
- Transform Bronze to Silver with cleanup and type fixes
- Create a small Gold summary table for reporting
- Document what each layer is responsible for

### Expected outcomes
- You can navigate Databricks confidently at a beginner level
- You understand the purpose of Delta Lake and medallion architecture
- You have the skeleton of your capstone pipeline

### Resources
- Databricks getting started: <https://docs.databricks.com/en/getting-started/index.html>
- Databricks Lakehouse architecture: <https://docs.databricks.com/en/lakehouse-architecture/index.html>
- Delta Lake docs: <https://docs.delta.io/latest/index.html>
- Delta Lake quick start: <https://docs.delta.io/latest/quick-start.html>

---

## Week 5 - Azure Data Factory for orchestration and migration

### Goals
- Learn the ADF basics most useful for a transition role
- Use ADF as a practical movement/orchestration tool, not as your only transformation engine

### Topics
- ADF concepts: linked services, datasets, pipelines, activities, triggers — [ADF introduction](https://learn.microsoft.com/azure/data-factory/introduction), [pipelines and activities concepts](https://learn.microsoft.com/azure/data-factory/concepts-pipelines-activities)
- Copy activity and basic parameterization — [copy activity overview](https://learn.microsoft.com/azure/data-factory/copy-activity-overview), [parameters and variables](https://learn.microsoft.com/azure/data-factory/concepts-parameters-variables)
- Monitoring runs and debugging failures — [monitor visually](https://learn.microsoft.com/azure/data-factory/monitor-visually), [troubleshoot ADF](https://learn.microsoft.com/azure/data-factory/data-factory-troubleshoot-guide)
- Positioning ADF alongside Databricks — [Azure Data Factory module](https://learn.microsoft.com/training/modules/introduction-to-azure-data-factory/), [Azure Databricks documentation](https://learn.microsoft.com/azure/databricks/)

### Practical exercises
- Design a simple ADF pipeline to move source data into a landing zone
- Parameterize source/target paths
- Trigger or manually run the pipeline and inspect monitoring output
- Draw a simple architecture diagram: source -> landing -> Databricks -> curated layer

### Expected outcomes
- You can explain where ADF fits in an Azure data stack
- You can create basic pipelines and monitor them
- You understand orchestration vs transformation responsibilities

### Resources
- Azure Data Factory introduction: <https://learn.microsoft.com/azure/data-factory/introduction>
- ADF copy activity overview: <https://learn.microsoft.com/azure/data-factory/copy-activity-overview>
- ADF concepts and terminology: <https://learn.microsoft.com/azure/data-factory/concepts-pipelines-activities>
- Microsoft Learn Azure Data Factory training: <https://learn.microsoft.com/training/modules/introduction-to-azure-data-factory/>

---

## Week 6 - Pipeline hardening and Databricks certification prep

### Goals
- Strengthen your pipeline with better structure and incremental thinking
- Start explicit preparation for Databricks Data Engineer Associate

### Topics
- Incremental loads and idempotent pipeline design — [Delta batch](https://docs.delta.io/latest/delta-batch.html), [Databricks medallion architecture](https://docs.databricks.com/en/lakehouse/medallion.html)
- Basic data validation and error handling — [Great Expectations overview](https://docs.greatexpectations.io/docs/core/introduction/introduction/), [Python errors and exceptions](https://docs.python.org/3/tutorial/errors.html)
- Delta Lake concepts most relevant to the associate exam — [Delta Lake docs](https://docs.delta.io/latest/index.html), [Databricks certification page](https://www.databricks.com/learn/certification/data-engineer-associate)
- Databricks jobs, workflows, and common platform terminology — [Databricks jobs](https://docs.databricks.com/en/jobs/index.html), [Databricks training catalog](https://www.databricks.com/learn/training/home)

### Practical exercises
- Add an incremental or append-only pattern to one pipeline step
- Add checks for duplicates, nulls, or unexpected values
- Summarize key certification concepts in your own notes
- Review Databricks exam guide and map weak areas

### Expected outcomes
- Your project is closer to production-style thinking
- You can speak about reliability, reruns, and data quality
- You have a concrete certification study list

### Resources
- Databricks certification page: <https://www.databricks.com/learn/certification/data-engineer-associate>
- Delta Lake batch docs: <https://docs.delta.io/latest/delta-batch.html>
- Databricks workflows docs: <https://docs.databricks.com/en/jobs/index.html>
- Databricks SQL/Data Engineer learning catalog: <https://www.databricks.com/learn/training/home>

---

## Week 7 - Capstone build

### Goals
- Build one end-to-end portfolio project that demonstrates transition-ready skills
- Focus on clarity and explanation, not complexity for its own sake

### Suggested capstone
Build a small **lakehouse pipeline**:
- **Source**: CSV files plus one API or second file source — [csv](https://docs.python.org/3/library/csv.html), [Requests quickstart](https://requests.readthedocs.io/en/latest/user/quickstart/)
- **Landing/Bronze**: raw ingestion — [medallion architecture](https://docs.databricks.com/en/lakehouse/medallion.html)
- **Silver**: cleaned, typed, deduplicated data — [PySpark DataFrame quickstart](https://spark.apache.org/docs/latest/api/python/getting_started/quickstart_df.html)
- **Gold**: simple analytics-friendly output such as customer/order summaries or sales KPIs — [star schema guidance](https://learn.microsoft.com/power-bi/guidance/star-schema)
- **Orchestration**: ADF triggers ingest, Databricks performs transformations — [ADF introduction](https://learn.microsoft.com/azure/data-factory/introduction), [Databricks jobs](https://docs.databricks.com/en/jobs/index.html)

### Practical exercises
- Finalize the architecture and folder/table naming
- Implement Bronze/Silver/Gold transformations
- Add a short README section or notes describing assumptions and design decisions
- Capture screenshots or commands that prove the pipeline runs

### Expected outcomes
- You have a portfolio-ready project story
- You can explain design tradeoffs, tool choices, and pipeline stages
- You are ready to polish, present, and review gaps in week 8

### Resources
- Databricks medallion architecture: <https://docs.databricks.com/en/lakehouse/medallion.html>
- Azure Well-Architected data guidance: <https://learn.microsoft.com/azure/well-architected/service-guides/data-analytics>
- Microsoft Learn data architecture content: <https://learn.microsoft.com/training/paths/azure-data-fundamentals-explore-core-data-concepts/>

---

## Week 8 - Polish, review, and job-readiness

### Goals
- Consolidate what you learned and make the project presentation-ready
- Finish a realistic first-pass Databricks Associate prep cycle

### Topics
- Review weak spots in Python, PySpark, Delta Lake, and ADF — [Python tutorial](https://docs.python.org/3/tutorial/), [PySpark getting started](https://spark.apache.org/docs/latest/api/python/getting_started/index.html), [Delta Lake docs](https://docs.delta.io/latest/index.html), [Azure Data Factory docs](https://learn.microsoft.com/azure/data-factory/)
- Portfolio polish and concise documentation — [about READMEs](https://docs.github.com/en/repositories/managing-your-repositorys-settings-and-features/customizing-your-repository/about-readmes), [writing on GitHub](https://docs.github.com/en/get-started/writing-on-github)
- Interview storytelling: project, tradeoffs, and debugging examples — [STAR interview method](https://www.indeed.com/career-advice/interviewing/star-interview-method), [Azure Well-Architected data analytics guidance](https://learn.microsoft.com/azure/well-architected/service-guides/data-analytics)
- Certification prep strategy for the next 2-4 weeks after the course — [Databricks certification page](https://www.databricks.com/learn/certification/data-engineer-associate), [Databricks training catalog](https://www.databricks.com/learn/training/home)

### Practical exercises
- Write a concise project summary: business goal, architecture, pipeline flow, and outputs
- Prepare answers to 10 common DE interview questions
- Review Databricks documentation sections tied to your weak areas
- Create a next-step checklist for post-course learning

### Expected outcomes
- You can demo and explain one complete project confidently
- You know what to study next for certification and interviews
- You have a realistic path from learner to applying for DE roles

### Resources
- Databricks certification page: <https://www.databricks.com/learn/certification/data-engineer-associate>
- Databricks documentation home: <https://docs.databricks.com/en/index.html>
- Microsoft Learn training catalog: <https://learn.microsoft.com/training/>
- Azure Data Factory documentation home: <https://learn.microsoft.com/azure/data-factory/>

---

## Databricks Data Engineer Associate prep path

Keep certification prep lightweight during the 8 weeks, then intensify after week 8.

### During the 8-week plan
- Weeks 4-6: learn core platform, Delta Lake, jobs, and medallion architecture
- Weeks 6-8: review the published exam page and create a topic checklist
- Use your capstone as revision for ingestion, transformation, and reliability topics

### After the 8-week plan
- Revisit Databricks docs systematically
- Practice terminology: Delta, job orchestration, tables, notebooks, performance basics
- Fill gaps with hands-on notebook repetition, not just reading

## Minimal tool stack for this plan

Prioritize these first:
1. **Python**
2. **PySpark**
3. **Databricks**
4. **Azure Data Factory**
5. **Basic data modeling**
6. **Basic Snowflake awareness only**

## Concise resource list

- Microsoft Learn Python: <https://learn.microsoft.com/training/paths/beginner-python/>
- Azure Data Factory docs: <https://learn.microsoft.com/azure/data-factory/>
- Databricks getting started: <https://docs.databricks.com/en/getting-started/index.html>
- Databricks Data Engineer Associate: <https://www.databricks.com/learn/certification/data-engineer-associate>
- PySpark getting started: <https://spark.apache.org/docs/latest/api/python/getting_started/index.html>
- Delta Lake docs: <https://docs.delta.io/latest/index.html>
- Snowflake key concepts: <https://docs.snowflake.com/en/user-guide/intro-key-concepts>

## Keep in mind

You do **not** need to master everything in 2 months. The real goal is to become able to build, explain, and improve a modern batch pipeline with confidence.
