# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is a Blazor WebAssembly application with ASP.NET Core hosting that uses Telerik UI for Blazor components. The solution uses .NET 9.0 and implements a hybrid rendering approach with both Interactive Server and WebAssembly render modes.

## Architecture

The solution consists of two projects:

1. **TelerikWebApp** (Server project) - ASP.NET Core host application
   - Location: `TelerikWebApp/TelerikWebApp/`
   - Main entry point: `Program.cs`
   - Hosts the Blazor WebAssembly client and provides server-side rendering capabilities
   - Configured for both HTTP (port 5149) and HTTPS (port 7211) in development

2. **TelerikWebApp.Client** (Client project) - Blazor WebAssembly application
   - Location: `TelerikWebApp/TelerikWebApp.Client/`
   - Main entry point: `Program.cs`
   - Contains the client-side Blazor components and pages
   - Uses Interactive WebAssembly render mode

## Key Components

- **App.razor** - Root application component with HTML shell and Telerik styling
- **Routes.razor** - Client-side routing configuration
- **_Imports.razor** - Global using statements for both server and client projects
- **MainLayout.razor** - Main application layout
- **NavMenu.razor** - Navigation component

## Development Commands

### Build and Run
```bash
dotnet build                    # Build the entire solution
dotnet run --project TelerikWebApp/TelerikWebApp/TelerikWebApp.csproj    # Run the application
```

### Development URLs
- HTTPS: https://localhost:7211
- HTTP: http://localhost:5149

## Telerik Configuration

The application uses Telerik UI for Blazor v11.1.1 with the Material Dark theme. Telerik services are registered in both projects:
- Server: `builder.Services.AddTelerikBlazor()`
- Client: `builder.Services.AddTelerikBlazor()`

Theme is loaded via CDN: `https://blazor.cdn.telerik.com/blazor/11.1.1/kendo-theme-material/swatches/material-main-dark.css`

## Render Modes

The application is configured for hybrid rendering:
- Interactive Auto render mode (`@rendermode="InteractiveAuto"`)
- Supports both Server and WebAssembly rendering
- Additional assemblies from the Client project are mapped for server-side rendering

## Project Structure

```
TelerikWebApp/
├── TelerikWebApp/              # Server project
│   ├── Components/
│   │   ├── App.razor          # Root component
│   │   ├── _Imports.razor     # Server imports
│   │   └── Pages/
│   │       └── Error.razor    # Error page
│   ├── Properties/
│   │   └── launchSettings.json
│   └── Program.cs             # Server startup
├── TelerikWebApp.Client/       # Client project
│   ├── Layout/
│   │   ├── MainLayout.razor   # Main layout
│   │   └── NavMenu.razor      # Navigation
│   ├── Pages/
│   │   ├── Home.razor         # Home page
│   │   ├── Counter.razor      # Counter demo
│   │   └── Weather.razor      # Weather demo
│   ├── _Imports.razor         # Client imports
│   ├── Routes.razor           # Routing config
│   └── Program.cs             # Client startup
└── TelerikWebApp.sln          # Solution file
```

## Important Notes

- Both projects target .NET 9.0
- Nullable reference types are enabled
- Implicit usings are enabled
- The client project has `NoDefaultLaunchSettingsFile` set to true
- Telerik license information is auto-generated during build