# Visual Studio 2026 Setup Guide

## Opening the Project

1. **Open Visual Studio 2026**

2. **Open the Solution**
   - Click `File` → `Open` → `Project/Solution`
   - Navigate to the cloned repository
   - Select `ManufacturingOffice.sln`

3. **Restore NuGet Packages**
   - Visual Studio will automatically restore packages
   - Or manually: Right-click solution → `Restore NuGet Packages`

## Running the Application

### Option 1: Run the Web Project Directly

1. **Set Startup Project**
   - Right-click `ManufacturingOffice.Web` in Solution Explorer
   - Select `Set as Startup Project`

2. **Run the Application**
   - Press `F5` (Run with debugging)
   - Or `Ctrl+F5` (Run without debugging)
   - Or click the green play button in the toolbar

3. **View in Browser**
   - The application will open automatically in your default browser
   - Navigate to `https://localhost:5001` or `http://localhost:5000`

### Option 2: Run with Aspire AppHost

1. **Set Startup Project**
   - Right-click `ManufacturingOffice.AppHost` in Solution Explorer
   - Select `Set as Startup Project`

2. **Run the Application**
   - Press `F5` or click the green play button
   - This starts the Aspire orchestration host

3. **View Aspire Dashboard**
   - The Aspire dashboard will open automatically
   - Shows telemetry, traces, and service health
   - Click on the `web` service to access the application

## Project Configuration

### Configure Multiple Startup Projects

To run multiple projects simultaneously:

1. Right-click the solution in Solution Explorer
2. Select `Properties`
3. Select `Multiple startup projects`
4. Set `ManufacturingOffice.Web` and `ManufacturingOffice.AppHost` to `Start`
5. Click `OK`

### Configure HTTPS Development Certificate

If you encounter SSL/HTTPS issues:

1. Open **Developer Command Prompt** (Tools → Command Line)
2. Run: `dotnet dev-certs https --trust`
3. Accept the security prompt
4. Restart Visual Studio

## Debugging

### Blazor Server Debugging

1. **Set Breakpoints**
   - Click in the left margin of code editor
   - Or press `F9` on the desired line

2. **Debug Razor Components**
   - Place breakpoints in `.razor.cs` code-behind files
   - Or in `@code` blocks in `.razor` files

3. **View Variables**
   - Hover over variables while debugging
   - Use `Locals`, `Autos`, and `Watch` windows

### Browser DevTools

- **F12** - Open browser developer tools
- **Console** - View JavaScript errors and Blazor logs
- **Network** - Inspect SignalR connections
- **Application** - View local storage and session data

## Solution Explorer Structure

```
ManufacturingOffice (Solution)
├── 📁 src
│   ├── 📦 ManufacturingOffice.Domain
│   │   ├── 📁 Common
│   │   ├── 📁 Entities
│   │   └── 📁 Enums
│   │
│   ├── 📦 ManufacturingOffice.Application
│   │   ├── 📁 Interfaces
│   │   ├── 📁 Services
│   │   └── 📁 DTOs
│   │
│   ├── 📦 ManufacturingOffice.Infrastructure
│   │   ├── 📁 Repositories
│   │   └── DependencyInjection.cs
│   │
│   ├── 🌐 ManufacturingOffice.Web (Blazor Server)
│   │   ├── 📁 Components
│   │   │   ├── 📁 Layout
│   │   │   │   └── MainLayout.razor
│   │   │   └── 📁 Pages
│   │   │       ├── Home.razor (Dashboard)
│   │   │       ├── WorkOrders.razor
│   │   │       ├── Inventory.razor
│   │   │       └── Quality.razor
│   │   ├── 📁 wwwroot
│   │   │   └── app.css
│   │   └── Program.cs
│   │
│   ├── 📦 ManufacturingOffice.ServiceDefaults
│   │   └── Extensions.cs
│   │
│   └── 🚀 ManufacturingOffice.AppHost
│       └── Program.cs
│
└── 📄 ManufacturingOffice.sln
```

## Building the Solution

### Build All Projects

- **Menu**: `Build` → `Build Solution`
- **Shortcut**: `Ctrl+Shift+B`
- **CLI**: Open Developer Command Prompt and run `dotnet build`

### Rebuild Solution

- **Menu**: `Build` → `Rebuild Solution`
- Cleans and builds all projects from scratch

### Build Single Project

- Right-click project in Solution Explorer
- Select `Build`

## NuGet Package Management

### View Installed Packages

- Right-click project → `Manage NuGet Packages`
- Click `Installed` tab

### Update Packages

- `Updates` tab shows available updates
- Select packages and click `Update`

### Package Manager Console

- `Tools` → `NuGet Package Manager` → `Package Manager Console`
- Run commands like:
  ```powershell
  Install-Package PackageName
  Update-Package PackageName
  ```

## Useful Visual Studio Features

### Code Navigation

- **F12** - Go to Definition
- **Ctrl+F12** - Go to Implementation
- **Ctrl+,** - Navigate To (search files, types, members)
- **Ctrl+T** - Go to All (quick search)

### Code Editing

- **Ctrl+K, Ctrl+D** - Format Document
- **Ctrl+K, Ctrl+C** - Comment Selection
- **Ctrl+K, Ctrl+U** - Uncomment Selection
- **Ctrl+.** - Quick Actions and Refactorings

### Window Management

- **Ctrl+Alt+L** - Solution Explorer
- **Ctrl+Alt+O** - Output Window
- **Ctrl+\, E** - Error List
- **Ctrl+\, Ctrl+M** - Team Explorer

## Troubleshooting

### Build Errors

**Problem**: Cannot find type or namespace

**Solution**:
1. Check `using` statements
2. Rebuild solution (`Ctrl+Shift+B`)
3. Clean solution: `Build` → `Clean Solution`, then rebuild

**Problem**: NuGet package restore failed

**Solution**:
1. Delete `bin` and `obj` folders from all projects
2. Close Visual Studio
3. Delete `%USERPROFILE%\.nuget\packages` cache
4. Reopen solution and restore packages

### Runtime Errors

**Problem**: "Connection failed" error in Blazor

**Solution**:
1. Check that the application is running
2. Clear browser cache
3. Restart the browser
4. Check browser console for JavaScript errors

**Problem**: OpenTelemetry warnings

**Solution**:
- These are known transitive dependency warnings
- Safe to ignore in development
- Will be resolved with future Aspire updates

## Performance Tips

1. **Use Release Configuration**
   - Switch from `Debug` to `Release` for better performance
   - Top toolbar: Debug → Release

2. **Disable Browser Link**
   - `Debug` → `Options` → `Web Projects`
   - Uncheck `Enable Browser Link`

3. **Close Unused Windows**
   - Reduce memory usage by closing unused tool windows
   - `Window` → `Close All Documents`

## Hot Reload

Visual Studio 2026 supports Hot Reload for Blazor:

1. **Enable Hot Reload**
   - Enabled by default
   - Toggle with the fire icon in the toolbar

2. **Make Changes**
   - Edit `.razor`, `.cs`, or `.css` files
   - Changes apply automatically without restarting

3. **Limitations**
   - Some structural changes require restart
   - Changes to `Program.cs` require restart

## Testing in Different Browsers

1. **Set Browser**
   - Click dropdown next to the Run button
   - Select browser (Edge, Chrome, Firefox)

2. **Browser with Debugging**
   - `Browse With...` → Select browser
   - Check `Set as Default`

## Additional Resources

- **View** → **Terminal** - Integrated terminal
- **View** → **Git Changes** - Source control
- **Tools** → **Extensions** - Install additional tools

## Keyboard Shortcuts Cheat Sheet

| Action | Shortcut |
|--------|----------|
| Build Solution | `Ctrl+Shift+B` |
| Run with Debugging | `F5` |
| Run without Debugging | `Ctrl+F5` |
| Stop Debugging | `Shift+F5` |
| Go to Definition | `F12` |
| Navigate To | `Ctrl+,` |
| Format Document | `Ctrl+K, Ctrl+D` |
| Quick Actions | `Ctrl+.` |
| Solution Explorer | `Ctrl+Alt+L` |
| Output Window | `Ctrl+Alt+O` |

## Known Issues

### Aspire Workload Deprecation Warning

When building `ManufacturingOffice.AppHost`, you may see:
```
warning NETSDK1228: This project depends on the Aspire Workload which has been deprecated
```

**Resolution**: This is expected. .NET Aspire now ships via NuGet packages instead of workloads. The application still works correctly.

---

**For additional help, see:**
- [TECHNICAL_DOCS.md](TECHNICAL_DOCS.md) - Detailed architecture documentation
- [README.md](README.md) - Project overview and features
