### StackOverflow Tag API Service

This project aims to develop a REST API using .NET 8 and C#, internally based on a list of tags provided by the StackOverflow API.

#### Project Objectives:

- Fetch at least 1000 tags from the StackOverflow API to a local database or cache.
- Calculate the percentage share of tags in the retrieved population.
- Provide paginated tags with sorting options.
- Expose an API method to force re-retrieval of tags from StackOverflow.
- Implement logging, error handling, and runtime configuration.
- Prepare unit tests for services and integration tests for API.
- Utilize Docker for repeatable builds and runs.
- Publish the solution on GitHub.

### Setup and Installation

1. Clone this repository.
2. Ensure Docker is installed.
3. Navigate to the project directory.
4. Run `docker-compose up`.

### API Endpoints

- `GET /api/tags`: Retrieves paginated tags with sorting options.
- `POST /api/tags/retrieve`: Forces re-retrieval of tags from StackOverflow.

### OpenAPI Specification

The OpenAPI specification is included in the project.

### Testing

The project includes unit tests for services and integration tests for API.

### Running Tests
Ensure .NET 8 SDK is installed. In the project's root directory, compile the solution:
```
dotnet build
```
To run unit tests:
```
dotnet test --filter Category=UnitTest
```
For integration tests:
```
dotnet test --filter Category=IntegrationTest
```
Run all tests without filtering:
```
dotnet test
```
Generate a detailed test report with:
```
dotnet test --logger "trx;LogFileName=TestResults.trx"
```

| Area | Technology |
|---|---|
| Environment | `.NET 8.0` |
| Contenerization | `Docker` |
| Testing | `xUnit.net` |
| Logger | `Serilog` |

