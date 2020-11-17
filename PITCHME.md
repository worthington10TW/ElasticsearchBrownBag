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

[home (port 9200)](http://localhost:9200)

![](https://i.imgur.com/Mu7cttv.png)

---

# Glossary

- Documents
- Indexes
- (Types of) Nodes
- Shards
- Clusters

*https://www.elastic.co/*
*guide/en/elasticsearch/*
*reference/current/glossary.html*

---

# Documents

Stored as JSON
Contains fields (Key value pairs)
They have a `type` and an `id`
Original document is stored in the `_source` field
Stored in an `index`

---

# Document

![](https://i.imgur.com/zXmMn68.png)

---

# Type

A noun
Represent the `type` of the document
e.g. Property, Person, Fruit

Or using dynamic mapping with a type of `_doc`

---

# ID

Identifier of our document
ES will generate these when omitted

---

# Field

How your data is stored 
Some examples
- lists
- dates
- numbers
- true/ false
- ranges

---

# Field

What if my data is complex?
- flat JSON (All the data in a single field)
- Nested object (preserves the relationship)
- Join (Parent child)

---

# Field

What about locations?
- Geo
    - long / lat
    - polygons
- coordinate system (Cartesian)
    - points
    - geometries (shapes)

---

# Document from ES

![](https://i.imgur.com/2JthbTq.png)

---

# Indexes

Place to keep your documents
The logical name which maps to one or more `shards`

---

# Indexes

![](https://i.imgur.com/V0i11Wl.png)

---

# Index alias

Rename your index
Group many indexes 

---

# Index alias example

In a school

We may have an index of all the **teachers**
We may have another index of all the **pupils**

We may want to search across **people**
An index alias of people containing teachers and pupils to the rescue! 

---

# Index alias

![](https://i.imgur.com/GDQpWnm.png)

---

# Node

Data nodes
Master nodes
Client nodes
Tribe nodes
Ingestion nodes
Machine learning nodes

Note: 
Data nodes
    stores data and executes data-related operations such as search and aggregation
Master nodes
    in charge of cluster-wide management and configuration actions such as adding and removing nodes
Client nodes
    forwards cluster requests to the master node and data-related requests to data nodes
Tribe nodes
    act as a client node, performing read and write operations against all of the nodes in the cluster
Ingestion nodes
    for pre-processing documents before indexing
Machine Learning nodes
    These are nodes available under Elastic’s Basic License that enable machine learning tasks. Machine learning nodes have xpack.ml.enabled and node.ml set to true.
    
---

# Nodes

Contains indexes
Data nodes host the shards

![](https://i.imgur.com/a9VLeMD.png)

---

# Shards

Single lucene index
Automatically managed by Elasticsearch
We can configure primary and replica count
Placed in random nodes across the cluster
The rest should just work itself out

---

# Lucene

Open source
Core search library
Written in Java

---

# Replica shards

Used when primary fails
Never on the same node as the primary shard
Increased search performance


---

# Cluster

One of more nodes
Master node controllers cluster management


One node in the cluster is the “master” node, which is in charge of cluster-wide management and configurations actions

---

![](https://i.imgur.com/14UspX3.png)


---