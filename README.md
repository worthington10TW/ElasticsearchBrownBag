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
5. Generate 10,000 fake stwudents
6. Batch and Bulk index students into `student` index
7. Close

### Quepid

The first time using Quepid you will need to setup the database and your credentials.

This is handled in the `init.sh` script.

The script has an optional single argument from setting the email address.

If this is not passed it will use your git credentials.

The password is hardcoded to `superpassword`

```sh
./init.sh
#Will create a user using $(git config user.email)

./init.sh your@email.com
#Will create a user using your@email.com
```
