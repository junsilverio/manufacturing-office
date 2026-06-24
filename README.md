# Manufacturing Office

A modern **Manufacturing Web Application** built with **.NET 10**, **Blazor**, **.NET Aspire**, and **OpenTelemetry**, featuring a clean **Microsoft Office-inspired** UI.

![Manufacturing Office](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet)
![Blazor](https://img.shields.io/badge/Blazor-Server-512BD4?logo=blazor)
![Clean Architecture](https://img.shields.io/badge/Architecture-Clean-blue)

## 🎯 Overview

Manufacturing Office is a browser-based operations workspace that helps planners, supervisors, and operators manage:
- **Production schedules** and work orders
- **Inventory** and material movement
- **Quality events** and inspections
- **Shop-floor KPIs** and metrics

## ✨ Key Features

### 🏭 Manufacturing Modules

**Dashboard**
- Real-time KPI metrics (OEE, Throughput, Active Orders)
- Active work orders overview
- Alerts and notifications
- Low stock warnings

**Work Orders**
- Create and track production orders
- Priority management (Low, Normal, High, Critical)
- Status tracking (Draft → Scheduled → Released → In Progress → Completed)
- Material readiness indicators
- Progress visualization

**Inventory & Materials**
- Stock level monitoring
- Available vs. Reserved quantities
- In-transit tracking
- Reorder point recommendations
- Location and bin management

**Quality Management**
- Non-conformance report (NCR) tracking
- Inspection queue
- Defect categorization
- Pass/fail rate monitoring

### 🎨 MS Office-Inspired Design

The interface follows Microsoft Office design principles:
- **Clean whitespace** and clear hierarchy
- **Ribbon-style** command area
- **Left app navigation** + contextual workspace
- **Neutral surfaces** with blue accent actions (#2563EB)
- **Data-first views** (tables, cards, charts, status badges)

### 🏗️ Clean Architecture

Organized in distinct layers following SOLID principles:
- **Domain Layer** - Core business entities (WorkOrder, InventoryItem, QualityEvent)
- **Application Layer** - Business logic and repository interfaces
- **Infrastructure Layer** - Data access implementations
- **Presentation Layer** - Blazor UI components

### 📊 OpenTelemetry Integration

Built-in observability with:
- **Distributed tracing** across services
- **Metrics collection** (runtime, HTTP, custom KPIs)
- **Structured logging** with context
- **OTLP exporter** for telemetry data

### ☁️ .NET Aspire Support

Cloud-native orchestration features:
- **Service discovery** and registration
- **Health checks** (`/health`, `/alive`)
- **Resilience patterns** (retry, circuit breaker)
- **Telemetry dashboard**

## 🚀 Quick Start

### Prerequisites
- .NET 10.0 SDK or later
- Visual Studio 2026 (recommended) or VS Code

### Run the Application

1. **Clone the repository**
```bash
git clone <repository-url>
cd manufacturing-office
```

2. **Restore packages**
```bash
dotnet restore
```

3. **Run the web application**
```bash
cd src/ManufacturingOffice.Web
dotnet run
```

4. **Open in browser**
- Navigate to `https://localhost:5001` or `http://localhost:5000`
- Explore the Dashboard, Work Orders, Inventory, and Quality modules

### Run with Aspire (Optional)

For enhanced telemetry and orchestration:
```bash
cd src/ManufacturingOffice.AppHost
dotnet run
```

This provides:
- Centralized telemetry dashboard
- Service discovery
- Distributed tracing visualization

## 📁 Project Structure

```
ManufacturingOffice/
├── src/
│   ├── ManufacturingOffice.Domain/           # Business entities
│   ├── ManufacturingOffice.Application/       # Business logic
│   ├── ManufacturingOffice.Infrastructure/    # Data access
│   ├── ManufacturingOffice.Web/               # Blazor UI
│   ├── ManufacturingOffice.ServiceDefaults/   # Aspire defaults
│   └── ManufacturingOffice.AppHost/           # Aspire host
├── README.md                                   # This file
├── TECHNICAL_DOCS.md                           # Detailed documentation
└── ManufacturingOffice.sln                     # Solution file
```

## 🎨 Design Tokens

### Color Palette
- **Primary**: `#2563EB` (action blue)
- **Primary Hover**: `#1D4ED8`
- **Background**: `#F5F7FA`
- **Surface**: `#FFFFFF`
- **Border**: `#D1D5DB`
- **Text Primary**: `#111827`
- **Text Secondary**: `#6B7280`
- **Success**: `#16A34A`
- **Warning**: `#D97706`
- **Danger**: `#DC2626`

### Typography
- **Font**: `"Segoe UI", "Inter", Arial, sans-serif`
- **Heading**: 600 weight
- **Body**: 400 weight
- **Dense data/table text**: 13–14px

## 🔧 Technology Stack

- **.NET 10.0** - Modern, high-performance runtime
- **Blazor Server** - Real-time interactive web UI
- **Clean Architecture** - Domain-driven design
- **.NET Aspire** - Cloud-native orchestration
- **OpenTelemetry** - Comprehensive observability
- **C# 13** - Latest language features

## 📚 Documentation

For detailed technical information, see:
- **[TECHNICAL_DOCS.md](TECHNICAL_DOCS.md)** - Architecture, extending the app, deployment

## 🗂️ Key Screens (Concept)

### A. Dashboard
Purpose: daily operations snapshot for supervisors.

Core modules:
- KPI strip: OEE, Throughput, Downtime, Scrap Rate
- Production trend chart (hourly/day)
- Alerts panel (late orders, low stock, quality holds)
- Work-center status board (Running / Idle / Blocked)

### B. Production Planning
Purpose: build and adjust schedules quickly.

Core modules:
- Ribbon actions: `New Plan`, `Auto-Schedule`, `Freeze`, `Publish`
- Gantt-like schedule timeline
- Work order table with priority, due date, status, material readiness
- Constraint warning badges (capacity/material/tooling)

### C. Work Orders
Purpose: execution and tracking of active jobs.

Core modules:
- Search + filters (status, line, shift, part family)
- Grid/table view with inline status changes
- Batch actions (`Assign`, `Split`, `Pause`, `Close`)
- Right detail panel with operation steps and operator notes

### D. Inventory & Materials
Purpose: ensure material availability for production.

Core modules:
- Stock overview cards (On-hand, Reserved, In-Transit)
- Material table by SKU/location/bin
- Reorder recommendations
- Material movement timeline

### E. Quality
Purpose: monitor non-conformance and inspection outcomes.

Core modules:
- NCR list and defect categories
- Inspection queue and pass/fail trend
- CAPA tracking board
- Risk heatmap by line/product

## 🔄 Interaction & UX Notes

- Fast keyboard navigation for table-heavy screens
- Sticky headers for command bar and table columns
- Save views (personal/team) for common filters
- Contextual empty states with call-to-action buttons
- Progressive disclosure: advanced controls in side panel, not default clutter

## 📱 Responsive Behavior

- Desktop-first (primary ops usage)
- Tablet mode for floor supervisors:
  - Collapsible left nav
  - Reduced ribbon to icon groups
  - KPI cards stack from 4-up to 2-up

## 🚧 Current Status

**Implemented:**
- ✅ Clean Architecture structure
- ✅ Blazor Server UI
- ✅ MS Office-inspired design system
- ✅ Dashboard with KPI cards
- ✅ Work Orders module
- ✅ Inventory module
- ✅ Quality module
- ✅ OpenTelemetry integration
- ✅ .NET Aspire support

**Data Storage:**
- 📦 Currently using in-memory repositories (demo data)
- 🔄 Can be extended to Entity Framework, SQL Server, PostgreSQL, etc.

**Future Enhancements:**
- 🔜 Production Planning module with Gantt chart
- 🔜 Authentication and authorization
- 🔜 Real-time updates with SignalR
- 🔜 Persistent database storage
- 🔜 Advanced reporting and analytics
- 🔜 Mobile responsive design improvements

## 🤝 Contributing

Contributions are welcome! Please:
1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Submit a pull request

## 📄 License

[Specify your license here]

## 📧 Contact

[Specify contact information here]

---

**Built with ❤️ using .NET 10 and Blazor**
