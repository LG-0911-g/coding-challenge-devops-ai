
# Build stage: compile the application
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /source

# Copy project files
COPY src/CodingChallenge.Api/ src/CodingChallenge.Api/

# Restore dependencies
RUN dotnet restore src/CodingChallenge.Api/CodingChallenge.Api.csproj

# Publish the API
RUN dotnet publish src/CodingChallenge.Api/CodingChallenge.Api.csproj \
    -c Release \
    -o /app/publish \
    --no-restore

# Runtime stage: smaller production image
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime

WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080

EXPOSE 8080

ENTRYPOINT ["dotnet", "CodingChallenge.Api.dll"]
