# Falcata.BillPlanner

ASP.NET Core Web API for personal financial management.

## Overview
- **Monthly Billing Plans**: Allows users to plan monthly income allocation across spending categories and budgets.
- **Expense Logging**: Logs and categorizes actual user spending.
- **Budget Tracking**: Compares actual expenses against planned budgets to provide insights.

## Falcata Ecosystem & Related Repositories
The Falcata financial suite spans multiple repositories:
- **Bill Planner (This Repo)**: [project.falcata.bill_planer](https://github.com/fercho1592/project.falcata.bill_planer) - Monthly budget planning and expense tracking API.
- **Database Migrations**: [project.falcata.db_relational](https://github.com/fercho1592/project.falcata.db_relational) - Relational database schema migrations (targets SQL Server).
- **Pay Restaurant**: [project.falcata.pay_restaurant](https://github.com/fercho1592/project.falcata.pay_restaurant) - Bill-splitting application for groups calculating individual shares and payment settlements.

## Documentation
Comprehensive project specifications, architecture documents, domain models, and business requirements are maintained under [docs/](docs/).

## Getting Started

### Prerequisites
- .NET 6 SDK
- Docker & Docker Compose (for SQL Server container)

### Running Infrastructure
```bash
docker-compose up -d
```

### Build & Run API
```bash
dotnet build Falcata.BillPlanner.sln
dotnet run --project src/Falcata.BillPlanner.API/Falcata.BillPlanner.API.csproj
```

### Running Tests
```bash
dotnet test Falcata.BillPlanner.sln
```

## Agent Guidelines
For AI coding agent instructions, architectural boundaries, and conventions, see [AGENTS.md](AGENTS.md).