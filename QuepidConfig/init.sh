#!/bin/sh

set -e

EMAIL=$1
HOST=$2

wait() {
    until [ $(curl -LI $HOST -o /dev/null -w '%{http_code}\n' -s) != "000" ]; do
        printf '...'
        sleep 2
    done
    echo "Quepid is up!!"
}

apply() {
    if [ $(curl -LI $HOST -o /dev/null -w '%{http_code}\n' -s) = "500" ]; then
        echo "Applying quepid configuration"
        bin/rake db:setup && thor user:create -a $EMAIL Administrator password
     else
        echo "Quepid responded with $RESPONSE"
    fi
}

echo "Waiting for Quepid ($HOST) to be up"

wait && apply

echo "Config applied, log in with $EMAIL"