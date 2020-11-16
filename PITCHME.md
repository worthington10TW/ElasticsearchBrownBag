# Introduction to Elasticsearch

[https://github.com/worthington10TW/ElasticsearchBrownBag](https://github.com/worthington10TW/ElasticsearchBrownBag)
Matthew Worthington
Developer @ ThoughtWorks

Note:

- Twitter: worthington10

---

# What we will cover

- Overview of Elasticsearch
- Useful terminology 
- How to get up and running
- Ingesting data
- What is Kibana and why do I care?
- How to improve search results
- How our queries can impact performance
    - And how to test it

---

# This session

- Overview of Elasticsearch
- Useful terminology 
- How to get up and running
- Ingesting data

---

# Prerequisites

(If you want to code along)

- Docker 
- Bash (For windows machines see [git bash](https://gitforwindows.org/))
- Python (Maybe)

---

# What is Elasticsearch?

Elasticsearch is a distributed, RESTful search and analytics engine capable of addressing a growing number of use cases. As the heart of the Elastic Stack, it centrally stores your data for lightning fast search, fine‑tuned relevancy, and powerful analytics that scale with ease.

---

# What is Elasticsearch?

Stores data
Organises data
Retrieves data

> You know, for Search-
> *Elasticsearch tagline*

---

# What is Elasticsearch?

[home](http://localhost:9200)

![](https://i.imgur.com/Mu7cttv.png)

---

# Glossary

- Documents
- Indexes
- (Types of) Nodes
- Shards
- Clusters

---

# Documents

- Stored as JSON
- Contains fields (Key value pairs)
- They have a `type` and an `id`
- Original document is stored in the `_source` field
- Stored in an `index`

---

# Document

- //TODO Example image

---

# Type

- A noun
- Represent the `type` of the document
- e.g. Property, Person, Fruit

---

# ID

- Identifier of our document
- ES will generate these when omitted

---

# Field

- How your data is stored 
- Some examples
    - lists
    - dates
    - numbers
    - true/ false
    - ranges

---

# Field

- What if my data is complex?
    - JSON object
    - flat JSON (All the data in a single field)
    - Nested object (preserves the relationship)
    - Join (Parent child)

---

# Field

- What about locations?
    - Geo
        - long / lat
        - polygons
    - Cartesian
        - points
        - geometries (shapes)

---


# Indexes

- Place to keep your documents
- 