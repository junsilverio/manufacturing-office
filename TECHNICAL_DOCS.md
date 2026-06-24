# Manufacturing Office - Technical Documentation

## Overview

Manufacturing Office is a modern web application built with **Blazor**, **.NET Aspire**, and **OpenTelemetry** following **Clean Architecture** principles. The application provides manufacturing operations management with an **MS Office-inspired** UI.

## Technology Stack

- **.NET 10.0**
- **Blazor Web App** (Interactive Server)
- **.NET Aspire** - Cloud-native orchestration
- **OpenTelemetry** - Observability and telemetry
- **Clean Architecture** - Domain-driven design

## Project Structure

```
ManufacturingOffice/
├── src/
│   ├── ManufacturingOffice.Domain/           # Core business entities
│   │   ├── Entities/                          # Domain models
│   │   │   ├── WorkOrder.cs
│   │   │   ├── InventoryItem.cs
│   │   │   ├── QualityEvent.cs
│   │   │   └── WorkCenter.cs
│   │   ├── Enums/                             # Domain enumerations
│   │   └── Common/                            # Base classes
│   │
│   ├── ManufacturingOffice.Application/       # Business logic layer
│   │   ├── Interfaces/                        # Repository interfaces
│   │   ├── Services/                          # Application services
│   │   └── DTOs/                              # Data transfer objects
│   │
│   ├── ManufacturingOffice.Infrastructure/    # Data access layer
│   │   ├── Repositories/                      # Repository implementations
│   │   │   ├── InMemoryWorkOrderRepository.cs
│   │   │   └── InMemoryInventoryRepository.cs
│   │   └── DependencyInjection.cs
│   │
│   ├── ManufacturingOffice.Web/               # Blazor UI layer
│   │   ├── Components/
│   │   │   ├── Pages/                         # Razor pages
│   │   │   │   ├── Home.razor                 # Dashboard
│   │   │   │   ├── WorkOrders.razor
│   │   │   │   ├── Inventory.razor
│   │   │   │   └── Quality.razor
│   │   │   └── Layout/                        # Layout components
│   │   │       └── MainLayout.razor
│   │   └── wwwroot/                           # Static assets
│   │       └── app.css                        # MS Office-inspired theme
│   │
│   ├── ManufacturingOffice.ServiceDefaults/   # Aspire service defaults
│   │   └── Extensions.cs                      # OpenTelemetry configuration
│   │
│   └── ManufacturingOffice.AppHost/           # Aspire orchestration host
│       └── Program.cs                         # Application startup
│
└── ManufacturingOffice.sln                    # Solution file
```

## Clean Architecture Layers

### 1. Domain Layer (`ManufacturingOffice.Domain`)
- Contains core business entities and value objects
- No dependencies on other layers
- Entities:
  - **WorkOrder** - Production orders with status, priority, quantities
  - **InventoryItem** - Material tracking with stock levels
  - **QualityEvent** - Quality control and inspection records
  - **WorkCenter** - Production equipment and capacity

### 2. Application Layer (`ManufacturingOffice.Application`)
- Defines interfaces (contracts) for repositories
- Contains business logic and use cases
- Depends only on Domain layer

### 3. Infrastructure Layer (`ManufacturingOffice.Infrastructure`)
- Implements data access (currently in-memory repositories)
- Depends on Application and Domain layers
- Can be extended to use Entity Framework, SQL, etc.

### 4. Presentation Layer (`ManufacturingOffice.Web`)
- Blazor UI components and pages
- Depends on Application and Infrastructure layers
- Implements MS Office-inspired design system

## MS Office-Inspired Design System

The application features a design language inspired by Microsoft Office:

### Color Palette
```css
--primary: #2563EB          /* Action blue */
--primary-hover: #1D4ED8    /* Darker blue on hover */
--background: #F5F7FA       /* Light gray background */
--surface: #FFFFFF          /* White surface */
--border: #D1D5DB           /* Light gray border */
--text-primary: #111827     /* Dark gray text */
--text-secondary: #6B7280   /* Medium gray text */
--success: #16A34A          /* Green */
--warning: #D97706          /* Orange */
--danger: #DC2626           /* Red */
```

### Typography
- **Font**: Segoe UI, Inter, Arial (sans-serif)
- **Heading weight**: 600 (semi-bold)
- **Body weight**: 400 (normal)
- **Dense data/table text**: 13-14px

### UI Patterns
- **Ribbon** - Top command bar with grouped actions and tabs
- **Sidebar** - Left navigation panel
- **Workspace** - Main content area with cards and tables
- **KPI Cards** - Dashboard metrics with trends
- **Data Tables** - Dense, sortable tables for orders and inventory
- **Status Badges** - Color-coded status indicators

## Application Features

### 1. Dashboard
- KPI metrics (Active Orders, OEE, Throughput, Low Stock Items)
- Active work orders table
- Alerts and notifications
- Real-time status updates

### 2. Work Orders Module
- Create and manage production orders
- Track order status (Draft, Scheduled, Released, In Progress, Completed)
- Priority management (Low, Normal, High, Critical)
- Progress tracking and completion status
- Material readiness indicators
- Batch actions (Assign, Split, Pause, Close)

### 3. Inventory & Materials Module
- Stock overview with KPI cards
- Material tracking by SKU and location
- Available vs. Reserved quantities
- In-transit tracking
- Reorder recommendations
- Low stock alerts

### 4. Quality Management Module
- Non-conformance report (NCR) tracking
- Inspection queue management
- Defect categorization
- Pass/fail rate monitoring
- CAPA (Corrective Action/Preventive Action) tracking

## OpenTelemetry Integration

The application includes comprehensive observability through OpenTelemetry:

### Configured Instrumentation
- **ASP.NET Core** - HTTP request/response telemetry
- **HTTP Client** - Outgoing HTTP call tracing
- **Runtime** - .NET runtime metrics (GC, memory, threads)

### Telemetry Types
- **Metrics** - Performance counters and KPIs
- **Traces** - Distributed tracing across services
- **Logs** - Structured logging with context

### Configuration
OpenTelemetry is configured in `ServiceDefaults/Extensions.cs`:
- OTLP exporter for telemetry data
- Automatic instrumentation of ASP.NET Core
- Metrics collection for runtime and HTTP

## .NET Aspire Integration

Aspire provides cloud-native application orchestration:

### Components
- **AppHost** - Orchestrates application resources
- **ServiceDefaults** - Shared configuration for all services
- **Service Discovery** - Automatic service registration
- **Resilience** - Built-in retry and circuit breaker patterns

### Health Checks
- `/health` - Overall application health
- `/alive` - Liveness probe for containers

## Building and Running

### Prerequisites
- .NET 10.0 SDK or later
- Visual Studio 2026 (recommended) or VS Code

### Build
```bash
dotnet restore
dotnet build
```

### Run Web Application
```bash
cd src/ManufacturingOffice.Web
dotnet run
```

The application will be available at `https://localhost:5001` or `http://localhost:5000`

### Run with Aspire AppHost (Optional)
```bash
cd src/ManufacturingOffice.AppHost
dotnet run
```

This starts the Aspire orchestration host which provides:
- Automatic service discovery
- Telemetry dashboard
- Distributed tracing visualization

## Data Storage

Currently, the application uses **in-memory repositories** for development and demonstration:
- `InMemoryWorkOrderRepository` - Seeded with 4 sample work orders
- `InMemoryInventoryRepository` - Seeded with 4 sample inventory items

### Future Enhancements
To add persistent storage:
1. Install Entity Framework Core packages
2. Create DbContext in Infrastructure layer
3. Implement EF-based repositories
4. Update DependencyInjection to use EF repositories

Example:
```csharp
services.AddDbContext<ManufacturingContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

services.AddScoped<IWorkOrderRepository, EfWorkOrderRepository>();
```

## Extending the Application

### Adding New Entities
1. Define entity in `Domain/Entities/`
2. Create repository interface in `Application/Interfaces/`
3. Implement repository in `Infrastructure/Repositories/`
4. Register in `Infrastructure/DependencyInjection.cs`
5. Create Blazor page in `Web/Components/Pages/`

### Adding New Pages
1. Create `.razor` file in `Web/Components/Pages/`
2. Add `@page "/your-route"` directive
3. Update `MainLayout.razor` navigation
4. Inject required services with `@inject`
5. Use MS Office CSS classes for consistent styling

## Known Issues

### Package Vulnerabilities
The build shows warnings for OpenTelemetry package vulnerabilities:
- `OpenTelemetry.Api 1.11.1` - Moderate severity
- `OpenTelemetry.Exporter.OpenTelemetryProtocol 1.11.0` - Moderate severity
- `MessagePack 2.5.192` - High severity (via Aspire.Hosting)

**Resolution**: These are transitive dependencies from .NET Aspire. Updates will be applied when new versions of Aspire packages are released. The vulnerabilities do not affect the application's core functionality in development environments.

## Security Considerations

### Current Implementation
- In-memory data (no persistent storage)
- No authentication/authorization
- Development-only health check endpoints

### Production Recommendations
1. **Add Authentication** - Use ASP.NET Core Identity or Azure AD
2. **Add Authorization** - Implement role-based access control
3. **Secure Health Checks** - Restrict access in production
4. **Use HTTPS** - Enforce HTTPS redirection
5. **Add Input Validation** - Validate all user inputs
6. **Implement Logging** - Add structured logging with Serilog
7. **Database Security** - Use parameterized queries, encrypted connections

## Performance Optimization

### Current Performance Features
- Server-side Blazor with SignalR for real-time updates
- Singleton repositories for fast in-memory access
- CSS bundling and minification
- Asynchronous data loading

### Future Optimizations
- Implement caching (Redis, Memory Cache)
- Add pagination for large datasets
- Use Blazor WebAssembly for client-side rendering
- Implement lazy loading for heavy components
- Add database query optimization with indexes

## Testing Strategy

### Recommended Test Structure
```
tests/
├── ManufacturingOffice.Domain.Tests/      # Unit tests for entities
├── ManufacturingOffice.Application.Tests/ # Business logic tests
├── ManufacturingOffice.Infrastructure.Tests/ # Repository tests
└── ManufacturingOffice.Web.Tests/         # Component tests (bUnit)
```

### Testing Frameworks
- **xUnit** - Unit testing framework
- **FluentAssertions** - Assertion library
- **Moq** - Mocking framework
- **bUnit** - Blazor component testing

## Contributing

### Code Style
- Follow C# coding conventions
- Use meaningful variable names
- Add XML documentation for public APIs
- Keep methods small and focused

### Commit Guidelines
- Use conventional commit messages
- Include issue/task references
- Write descriptive commit bodies

## License

[Specify your license here]

## Contact

[Specify contact information]
