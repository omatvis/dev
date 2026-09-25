# Additional Materials for Later

These topics are valuable, but intentionally postponed so the first 2 months stay realistic and focused.

## What to learn after the main plan

### 1. Snowflake fundamentals

Learn just enough to understand where Snowflake fits in the modern data stack:
- architecture and compute/storage separation
- virtual warehouses
- stages, loading, and basic security concepts

**Why later:** useful market knowledge, but not necessary for your first 8-week transition.

**Resources**
- Snowflake key concepts: <https://docs.snowflake.com/en/user-guide/intro-key-concepts>
- Snowflake getting started: <https://docs.snowflake.com/en/user-guide/getting-started>
- Snowflake documentation home: <https://docs.snowflake.com/en/>

---

### 2. Data modeling beyond the basics

Deepen warehouse design knowledge with:
- star schema refinement
- slowly changing dimensions
- fact table grain decisions
- semantic layer thinking

**Why later:** you already have DB design experience, so basic modeling is enough for the first 2 months.

**Resources**
- Microsoft dimensional modeling guidance: <https://learn.microsoft.com/power-bi/guidance/star-schema>
- dbt analytics engineering intro: <https://docs.getdbt.com/docs/introduction>
- Kimball Group articles: <https://www.kimballgroup.com/data-warehouse-business-intelligence-resources/>

---

### 3. dbt and analytics engineering

Add dbt when you want stronger transformation workflow discipline:
- modular SQL transformations
- tests and documentation
- lineage and environment practices

**Why later:** first master Python/PySpark/Databricks; then dbt becomes easier to place correctly.

**Resources**
- dbt docs: <https://docs.getdbt.com/docs/introduction>
- dbt guides: <https://docs.getdbt.com/guides>
- dbt best practices: <https://docs.getdbt.com/best-practices>

---

### 4. Orchestration beyond ADF

Expand from ADF into broader orchestration patterns:
- Apache Airflow basics
- retries, backfills, SLAs, and dependency management
- production-style scheduling patterns

**Why later:** ADF is enough for your current target stack; Airflow is great as a broader market skill.

**Resources**
- Airflow docs: <https://airflow.apache.org/docs/>
- Airflow tutorial: <https://airflow.apache.org/docs/apache-airflow/stable/tutorial/index.html>
- Astronomer Airflow guides: <https://www.astronomer.io/docs/learn/>

---

### 5. Streaming and event-driven data

Once batch feels comfortable, add:
- Kafka fundamentals
- Spark Structured Streaming basics
- event-time vs processing-time concepts
- idempotency and late-arriving data

**Why later:** streaming adds complexity and is not needed for a first transition portfolio.

**Resources**
- Kafka docs: <https://kafka.apache.org/documentation/>
- Spark Structured Streaming guide: <https://spark.apache.org/docs/latest/structured-streaming-programming-guide.html>
- Databricks streaming docs: <https://docs.databricks.com/en/structured-streaming/index.html>

---

### 6. CI/CD, testing, and production maturity

Deepen engineering quality with:
- unit/integration testing for pipelines
- deployment workflows
- environment promotion
- observability and cost awareness

**Why later:** valuable, but more effective after you already have a working pipeline worth productionizing.

**Resources**
- Azure DevOps documentation: <https://learn.microsoft.com/azure/devops/>
- GitHub Actions docs: <https://docs.github.com/actions>
- Great Expectations docs: <https://docs.greatexpectations.io/docs/>
- Microsoft Well-Architected Framework: <https://learn.microsoft.com/azure/well-architected/>

---

### 7. Performance tuning and platform depth

After you gain hands-on time, go deeper into:
- Spark shuffles and partitioning strategy
- file sizing and small-file problems
- Delta optimization concepts
- warehouse and cluster cost/performance tradeoffs

**Why later:** these topics matter more after you have a few working pipelines to optimize.

**Resources**
- Spark tuning guide: <https://spark.apache.org/docs/latest/tuning.html>
- Delta best practices: <https://docs.delta.io/latest/best-practices.html>
- Databricks performance docs: <https://docs.databricks.com/en/optimizations/index.html>

---

## Suggested post-2-month learning order

1. Databricks Associate certification prep
2. Snowflake fundamentals
3. dbt and analytics engineering
4. Airflow / broader orchestration
5. Streaming
6. CI/CD and observability
7. Optional AI Data Engineer track

## Concise resource list

- Databricks training: <https://www.databricks.com/learn/training/home>
- Snowflake docs: <https://docs.snowflake.com/en/>
- dbt docs: <https://docs.getdbt.com/docs/introduction>
- Airflow docs: <https://airflow.apache.org/docs/>
- Kafka docs: <https://kafka.apache.org/documentation/>
- Great Expectations docs: <https://docs.greatexpectations.io/docs/>

## Final advice

Your strongest strategy is to go **deep enough to build and explain one solid pipeline first**, then broaden into adjacent tools. That creates better interview stories and a faster transition than trying to touch every tool at once.
