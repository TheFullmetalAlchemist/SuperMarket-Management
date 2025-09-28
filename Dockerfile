# Stage 1: Build the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy solution and project files
COPY ["SuperMarket Management.sln", "./"]
COPY ["SuperMarket Management/", "SuperMarket Management/"]

# Restore dependencies
RUN dotnet restore "SuperMarket Management.sln"

# Build the project in Release mode
RUN dotnet build "SuperMarket Management.sln" --configuration Release

# Publish the project
RUN dotnet publish "SuperMarket Management.sln" --configuration Release --output /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy published files from build stage
COPY --from=build /app/publish .

# Expose Railway-assigned PORT
ENV ASPNETCORE_URLS=http://*:$PORT
EXPOSE $PORT

# Start the app
ENTRYPOINT ["dotnet", "SuperMarket Management.dll"]
