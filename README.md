# InventoryManagement

A full-stack inventory, purchase, and sales management system I built using ASP.NET Core 10, Entity Framework Core, and MySQL, combining a server-rendered MVC UI with a parallel JWT-secured REST API, backed by a custom role/permission-based authorization system.

## About this project

InventoryFlow is designed to handle the full inventory lifecycle for a small business: managing a product catalog, tracking vendors and customers, recording purchases and sales, and keeping stock levels up to date — all behind a permission-controlled login system so different users can be given access to only the features they need.

I built this to practice and demonstrate a clean, layered .NET architecture end to end: domain modeling, EF Core migrations, a service/repository-based business layer, JWT authentication with refresh tokens, and a custom authorization policy system — not just CRUD screens.

## Features

- **Product catalog** — products, product groups/categories, and units of measure
- **Vendor & customer management**
- **Purchases** — record stock-in transactions with line items and computed totals
- **Sales** — record stock-out transactions with line items and computed totals
- **Live stock tracking** — current stock levels derived from purchase/sale history
- **Dashboard** — summary view across the system
- **User management** — create, update, activate, and deactivate users
- **Custom permission system (RBAC)** — fine-grained, database-backed permissions (e.g. `Product.Create`, `User.Deactivate`) enforced through a custom ASP.NET Core authorization policy provider
- **Dual interface** — the same functionality exposed through server-rendered MVC pages and a JWT-secured REST API

## Tech stack

| Layer | Technology |
|---|---|
| Backend framework | ASP.NET Core 10 (MVC + Web API) |
| Database / ORM | MySQL + Entity Framework Core 10 |
| Auth | JWT Bearer + refresh tokens (API), session auth (MVC) |
| Security | BCrypt.Net-Next password hashing, custom RBAC policy provider |
| Logging | Serilog (console + rolling file sinks) |
| API docs | Swagger / OpenAPI via Swashbuckle |
| Frontend | Razor Views, Bootstrap 5, jQuery |

## Architecture

The solution follows a clean, layered architecture, separating concerns across four projects:

```
InventoryByawAstha.sln(x)
├── InventoryByawAstha.Domain   Entities (core domain model)
├── InventoryByawAstha.DAL      DbContext, EF configurations, migrations, repositories, seeding
├── InventoryByawAstha.BLL      DTOs, service interfaces and implementations (business logic)
└── InventoryByawAstha.Web      MVC + Web API controllers, auth, ACL, middleware, views

Dependency flow: Web -> BLL -> DAL -> Domain
```

- **Domain** — plain entity classes: `User`, `UserPermission`, `RefreshToken`, `Customer`, `Vendor`, `Product`, `ProductGroup`, `UnitofMeasure`, `Purchase`/`PurchaseDetail`, `Sale`/`SaleDetail`
- **DAL** — `InventoryByawAsthaDbContext`, fluent entity configurations, a `UnitOfWork`, a repository per entity, and a `DbSeeder` that creates a default admin account on first run
- **BLL** — one service and DTO set per feature (Auth, User, Product, ProductGroup, UnitOfMeasure, Vendor, Customer, Purchase, Sale, Dashboard), keeping business rules out of the controllers
- **Web** — MVC controllers/views for the UI, mirrored API controllers, a custom `PermissionHandler` + `PermissionPolicyProvider` implementing the RBAC system, global exception middleware, and Serilog logging

## Running it locally

**Prerequisites:** .NET 10 SDK, a running MySQL server

```bash
git clone <repo-url>
cd InventoryFlow
dotnet restore
dotnet tool restore
```

Create `InventoryByawAstha.Web/appsettings.Development.json` (it's git-ignored, so it won't come with the clone):

```json
{
  "ConnectionStrings": {
    "constr": "Server=localhost;Database=inventoryDB;Uid=root;Pwd=<your-password>;"
  },
  "Jwt": {
    "Issuer": "InventoryByawAstha",
    "Audience": "InventoryByawAsthaClient",
    "Key": "<a-long-random-secret>",
    "ExpirationMinutes": 30
  }
}
```

Apply migrations and run:

```bash
dotnet ef database update --project InventoryByawAstha.DAL --startup-project InventoryByawAstha.Web
dotnet run --project InventoryByawAstha.Web
```

The app opens on the login page, and a default admin user is seeded automatically on first run.

## What this project demonstrates

- Designing a multi-project, layered .NET solution (Domain / DAL / BLL / Web) instead of a single monolithic project
- Repository + Unit of Work patterns over EF Core
- Building a **custom** authorization system (policy provider + handler) rather than relying on static `[Authorize(Roles = ...)]` checks
- Supporting two auth models side by side — session-based for a traditional web UI and JWT + refresh tokens for an API
- Structured logging with Serilog, including a dedicated error log stream
- Managing schema evolution through 25+ incremental EF Core migrations

## Possible next steps

- Add a unit/integration test suite
- Set up a CI pipeline (build, migration check, tests) on push/PR
- Containerize with Docker + docker-compose (app + MySQL)
- Add API versioning and expand Swagger documentation

