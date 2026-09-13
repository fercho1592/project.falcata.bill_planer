# AI Agent Guidelines for Falcata.BillPlanner

## Project Overview
Falcata.BillPlanner is a .NET 6 Web API for personal financial management. The core objectives are:
- Enabling users to create and manage monthly billing/budget plans allocating income across spending categories.
- Logging and tracking user expenses.
- Comparing actual expenses against planned budgets to provide budget tracking and insights.

## Project Documentation
Detailed specifications, domain models, business logic requirements, and design documentation for this project are maintained under [docs/](docs/). AI agents should consult the documents in [docs/](docs/) as the primary source of truth before implementing new features, creating domain models, or adjusting business rules.

## Multi-Repo Ecosystem & Related Services
The Falcata suite is distributed across multiple repositories:
- **Bill Planner (Current Repository)**:
  - **Repo**: `https://github.com/fercho1592/project.falcata.bill_planer`
  - **Local path**: `Source/project.falcata.bill_planer`
  - **Role**: Core Web API for creating monthly billing plans, recording user expenses, and tracking budget vs. actuals.
- **Database Migrations (`project.falcata.db_relational`)**:
  - **Repo**: `https://github.com/fercho1592/project.falcata.db_relational`
  - **Local path**: `Source/project.falcata.db_relational`
  - **Role**: Manages relational database schemas and migrations (targeting SQL Server infrastructure specified in [docker-compose.yml](docker-compose.yml)). Schema changes needed by BillPlanner entities/tables must be coordinated here.
- **Pay Restaurant (`project.falcata.pay_restaurant`)**:
  - **Repo**: `https://github.com/fercho1592/project.falcata.pay_restaurant`
  - **Local path**: `Source/project.falcata.pay_restaurant`
  - **Role**: Group bill splitting application that enables users to split bills, calculate individual shares, and determine payment settlements between users. Expense outcomes/settlements from this service can feed or reconcile into BillPlanner expenses.

## Project Structure & Architecture
The solution follows Clean Architecture / CQRS patterns:
- [src/Falcata.BillPlanner.API](src/Falcata.BillPlanner.API): ASP.NET Core Web API presentation layer with controllers, OpenAPI/Swagger configuration in [src/Falcata.BillPlanner.API/Program.cs](src/Falcata.BillPlanner.API/Program.cs), and base controller abstractions in [src/Falcata.BillPlanner.API/Controllers/BaseController.cs](src/Falcata.BillPlanner.API/Controllers/BaseController.cs).
- [src/Falcata.BillPlanner.Application](src/Falcata.BillPlanner.Application): Application layer containing business use cases structured by feature folders under `Feature/<FeatureName>/` (Commands, Queries, Handlers, Validators). Uses MediatR.
- [src/Falcata.BillPlanner.Application.Interfaces](src/Falcata.BillPlanner.Application.Interfaces): Abstractions, service contracts, and repository interfaces.
- [src/Falcata.BillPlanner.Domain](src/Falcata.BillPlanner.Domain): Core domain entities (Plans, Categories, Expenses, Budgets), value objects, and business rules.
- [src/Falcata.BillPlanner.DI](src/Falcata.BillPlanner.DI): Dependency injection container modules and service registrations in [src/Falcata.BillPlanner.DI/ContainerModules.cs](src/Falcata.BillPlanner.DI/ContainerModules.cs) and [src/Falcata.BillPlanner.DI/MeditatRContainer.cs](src/Falcata.BillPlanner.DI/MeditatRContainer.cs).
- [src/Falcata.BillPlanner.Application.Test](src/Falcata.BillPlanner.Application.Test): Unit and integration tests for application features (xUnit).
- [src/Falcata.BillPlanner.Domain.Test](src/Falcata.BillPlanner.Domain.Test): Unit tests for domain models and rules (xUnit).
- [docker-compose.yml](docker-compose.yml): Local infrastructure configuration including Microsoft SQL Server container.

## Development & Build Commands
- Build solution: `dotnet build Falcata.BillPlanner.sln`
- Run API: `dotnet run --project src/Falcata.BillPlanner.API/Falcata.BillPlanner.API.csproj`
- Run all tests: `dotnet test Falcata.BillPlanner.sln`
- Run application tests: `dotnet test src/Falcata.BillPlanner.Application.Test/Falcata.BillPlanner.Application.Test.csproj`
- Run domain tests: `dotnet test src/Falcata.BillPlanner.Domain.Test/Falcata.BillPlanner.Domain.Test.csproj`

## Key Conventions & Best Practices
1. **Requirements & Domain Specs**:
   - Always reference [docs/](docs/) for domain models, calculation rules, schema requirements, and endpoint contracts before writing code.
2. **CQRS with MediatR**:
   - Place feature handlers, queries, and commands in `src/Falcata.BillPlanner.Application/Feature/<FeatureName>/` (see [src/Falcata.BillPlanner.Application/Feature/MediatorTest/MediatorTestQuery.cs](src/Falcata.BillPlanner.Application/Feature/MediatorTest/MediatorTestQuery.cs) and [src/Falcata.BillPlanner.Application/Feature/MediatorTest/MediatorTestQueryHandler.cs](src/Falcata.BillPlanner.Application/Feature/MediatorTest/MediatorTestQueryHandler.cs)).
   - Implement `IRequest<TResponse>` and `IRequestHandler<TRequest, TResponse>`.
3. **Dependency Injection**:
   - Register new services and dependencies through modular extension methods in [src/Falcata.BillPlanner.DI](src/Falcata.BillPlanner.DI) orchestrated via [src/Falcata.BillPlanner.DI/ContainerModules.cs](src/Falcata.BillPlanner.DI/ContainerModules.cs).
4. **Domain-Driven Design**:
   - Keep business invariants and domain validation inside [src/Falcata.BillPlanner.Domain](src/Falcata.BillPlanner.Domain).
   - Application layer orchestrates operations without leaking infrastructure concerns into domain.
5. **Testing**:
   - Write corresponding xUnit tests in [src/Falcata.BillPlanner.Domain.Test](src/Falcata.BillPlanner.Domain.Test) for business logic and in [src/Falcata.BillPlanner.Application.Test](src/Falcata.BillPlanner.Application.Test) for handlers and use cases.
