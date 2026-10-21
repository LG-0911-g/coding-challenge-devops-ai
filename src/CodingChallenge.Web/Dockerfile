
# Stage 1: Build the Blazor frontend
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /source

# Copy the frontend project
COPY src/CodingChallenge.Web/ src/CodingChallenge.Web/

# Restore NuGet dependencies
RUN dotnet restore src/CodingChallenge.Web/CodingChallenge.Web.csproj

# Publish the frontend
RUN dotnet publish src/CodingChallenge.Web/CodingChallenge.Web.csproj \
    -c Release \
    -o /app/publish \
    --no-restore

# Stage 2: Run the application
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime

WORKDIR /app

COPY --from=build /app/publish .

# Listen on port 8080 inside the container
ENV ASPNETCORE_URLS=http://+:8080

EXPOSE 8080

ENTRYPOINT ["dotnet", "CodingChallenge.Web.dll"]
