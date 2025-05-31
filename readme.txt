# E-Commerce Order Management System

## Project Overview
A domain-driven design (DDD) implementation for managing customer orders with:
- State machine-based order lifecycle
- Clean architecture separation
- CQRS pattern for commands/queries
- Entity Framework Core persistence

## Key Features
✔ Order state management (Pending → Confirmed → Shipped → Delivered)
✔ Domain events for state changes
✔ Proper aggregate boundaries
✔ Value objects for Email, Money, Address
✔ Unit & integration tests

## Project Structure
/src
  /Domain        - Core business logic
    /Aggregates  - Order root aggregate
    /Entities    - Customer, OrderItem
    /ValueObjects- Email, Money, Address
    /Exceptions  - Domain exceptions
    /Events      - Domain events

  /Application   - Use cases/services
    /Commands    - PlaceOrder, CancelOrder, etc.
    /Queries     - GetOrder, etc.
    /DTOs        - Data transfer objects
    /Mappings    - AutoMapper profiles

  /Infrastructure- Implementation details
    /Repositories- EF Core repositories
    /Data        - DbContext, migrations

  /API           - Web API endpoints
    /Controllers - RESTful controllers
    /DI          - Dependency injection

/tests          - Unit & integration tests

## Getting Started

### Prerequisites
- .NET 8 SDK

- IDE (VS/Rider/VSCode)

### Setup
1. Clone the repository
2. Change database name in AppSettings if you want
3. Run the API:
   dotnet run --project src/API

### Testing
Run unit tests:
dotnet test tests/UnitTests

Run integration tests:
dotnet test tests/IntegrationTests

## Key Patterns Used
- Domain-Driven Design
- CQRS
- Repository Pattern
- State Machine
- Clean Architecture

## License
MIT License - Free for educational and commercial use