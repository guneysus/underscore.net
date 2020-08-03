#!/bin/bash

set -ex

echo $MYGET_SECRET
echo $MYGET_SOURCE

nuget push underscore.net/bin/Debug/underscore.net.0.2.0-alpha.1.nupkg $MYGET_SECRET -Source $MYGET_SOURCE