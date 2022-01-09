#!/bin/bash

# Check if kubectl is installed
if ! [ -x "$(command -v kubectl)" ]; then
    echo 'Error: kubectl is not installed.' >&2
    exit 1
fi

kubectl apply -f k8s/
