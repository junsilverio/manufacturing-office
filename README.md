# Manufacturing Office

Concept designs for a **Manufacturing Web App** with a modern **Microsoft Office-inspired** look and feel.

## 1) Product Vision

Manufacturing Office is a browser-based operations workspace that helps planners, supervisors, and operators manage:
- Production schedules
- Work orders
- Inventory and material movement
- Quality events
- Shop-floor KPIs

The interface follows MS Office design principles:
- Clean whitespace and clear hierarchy
- Ribbon-style command area
- Left app navigation + contextual workspace
- Neutral surfaces with blue accent actions
- Data-first views (tables, cards, charts, status badges)

## 2) Design Language (Office-Inspired)

### Color Tokens
- `Primary`: `#2563EB` (action blue)
- `Primary Hover`: `#1D4ED8`
- `Background`: `#F5F7FA`
- `Surface`: `#FFFFFF`
- `Border`: `#D1D5DB`
- `Text Primary`: `#111827`
- `Text Secondary`: `#6B7280`
- `Success`: `#16A34A`
- `Warning`: `#D97706`
- `Danger`: `#DC2626`

### Typography
- Font: `"Segoe UI", "Inter", Arial, sans-serif`
- Heading: 600 weight
- Body: 400 weight
- Dense data/table text: 13–14px

### UI Patterns
- Top command bar (Ribbon) with grouped actions
- Tabs for workspace context (Production / Inventory / Quality / Reports)
- Cards for KPI summaries
- Dense sortable/filterable tables for orders and inventory
- Right-side contextual detail panel

## 3) Key Screens (Concept)

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

## 4) Interaction & UX Notes

- Fast keyboard navigation for table-heavy screens
- Sticky headers for command bar and table columns
- Save views (personal/team) for common filters
- Contextual empty states with call-to-action buttons
- Progressive disclosure: advanced controls in side panel, not default clutter

## 5) Responsive Behavior

- Desktop-first (primary ops usage)
- Tablet mode for floor supervisors:
  - Collapsible left nav
  - Reduced ribbon to icon groups
  - KPI cards stack from 4-up to 2-up