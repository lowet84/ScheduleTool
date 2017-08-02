#!/bin/bash

rm -r out
docker build -t lowet84/schedule-tool-build -f Dockerfile.build .
mkdir -p out
docker run --rm -v $PWD/out:/app lowet84/schedule-tool-build
docker build -t lowet84/schedule-tool .
rm -r out
