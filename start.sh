#!/bin/bash
# Exit immediately if a command fails
set -e

# Restore dependencies
dotnet restore "SuperMarket Management.sln"

# Build the project in Release mode
dotnet build "SuperMarket Management.sln" --configuration Release

# Run the app using the Railway-assigned PORT
dotnet run --project "SuperMarket Management" --urls http://0.0.0.0:$PORT
