## Docker Deployment

The application is containerized using Docker Compose and consists of:

- ASP.NET Core API (.NET 10)
- Blazor Server frontend (.NET 10)
- SQLite database with persistent Docker volume

### Prerequisites

- Docker Desktop with Linux containers enabled
- Docker Compose

### Build and start

From the solution root:

```bash
docker compose up -d --build
```

### Access

- Frontend: http://localhost:8081
- API: http://localhost:8080

The API root endpoint may return HTTP 404 because no root route is defined.

### Stop the application

```bash
docker compose down
```

The SQLite database is stored in a named Docker volume, allowing data to persist across container restarts and recreation.

### View logs

```bash
docker compose logs --tail=100
```

This configuration is intended for local demonstration and is not production-hardened.