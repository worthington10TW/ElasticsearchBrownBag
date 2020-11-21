#!/bin/sh

set -e

if [ $# -eq 0 ]
then
  EMAIL=$(git config user.email)
else
  EMAIL=$1
fi

echo "Creating username $EMAIL"

echo "Spinning up redis and database"
docker-compose up -d qredis qdb

echo "Sleeping for 15 seconds until database is warm"
sleep 15

echo "Running database setup script"
docker-compose run --rm quepid bin/rake db:setup || echo "DB is already ready."

echo "Creating admin username $EMAIL"
docker-compose run quepid thor user:create -a $EMAIL Administrator superpassword || echo "DB user already setup"

docker-compose down
echo "Quepid is good to go!"

docker-compose up

