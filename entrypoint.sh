#!/bin/bash
set -e

# Run database migrations
dotnet ef migrations add "Init_DB" --project Infrastructure --startup-project API --output-dir Persistence/Migrations 
dotnet ef database update --project Infrastructure --startup-project API

# Start the application
exec dotnet API.dll
