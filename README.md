# ElasticsearchBrownBag

A set of interactive workshops exploring Elasticsearch

## Week 1- Elasticsearch introduction 

### [Deck](https://hackmd.io/@worthington10tw/S16Ds3ycv#/)

- What is Elasticsearch
- Glossary
- Get some data into your own instance
- How to view your data with Kibana

## The code

### Docker-compose

- `docker-compose up` to create elasticsearch, kibana and load test data
  - Elasticsearch: [http://localhost:9200](http://localhost:5601)
  - Kibana: [http://localhost:5601](http://localhost:5601)
- `docker-compose down` to close down

*By default the docker-compose file will use an already built DataLoader image.*
*See `docker-compose.yml` to build from source*

### DataLoader

The DataLoader is a dotnet core console application.

#### Behvaiour

1. First argument is the elasticSearch URI
    - When this is not present it will default to `http://localhost:9200`
2. Attempt to connect to elasticsearch
    - On failure sleep for 10 seconds and retry
3. Generate 500 fake trainers
4. Bulk index trainers into `trainer` index
5. Close

#### ToDo

- Generate student test data