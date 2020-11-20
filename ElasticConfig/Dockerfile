FROM curlimages/curl

COPY . .

ENV ELASTICSEARCH_HOSTS="http://localhost:9200"
LABEL org.opencontainers.image.source https://github.com/worthington10TW/ElasticsearchBrownBag

CMD ["sh", "-c", "./wait-for.sh ${ELASTICSEARCH_HOSTS#*//} -t 600 -- ./apply-configuration.sh $ELASTICSEARCH_HOSTS"]