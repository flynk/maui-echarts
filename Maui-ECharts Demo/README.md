# MAUI ECharts Demo Application

A comprehensive demonstration application showcasing the MAUI ECharts wrapper library features and capabilities.

## Overview

This demo application provides interactive examples of various chart types supported by the MAUI ECharts library. It features a clean, user-friendly interface with a sidebar for chart selection and real-time chart rendering.

## Features

### Chart Types Demonstrated
- **Line Chart** - Time series with multiple data sets
- **Bar Chart** - Quarterly comparison data
- **Pie Chart** - Distribution visualization
- **Scatter Chart** - Correlation analysis
- **Area Chart** - Stacked area visualization
- **Radar Chart** - Multi-dimensional comparison
- **Gauge Chart** - Performance metrics
- **Funnel Chart** - Process flow visualization
- **Heatmap** - Matrix data representation
- **Candlestick Chart** - Financial data display

## Running the Demo

### Prerequisites
- .NET 9.0 SDK or later
- Visual Studio 2022 17.14+ or VS Code with .NET MAUI extension

### Quick Start

1. **Open the solution**
   ```bash
   cd "Maui-ECharts"
   start "Maui-ECharts Demo.sln"
   ```

2. **Build and Run**
   - Select your target platform (Windows/Android/iOS/macOS)
   - Press F5 or click Run in Visual Studio

3. **Command Line**
   ```bash
   # Windows
   dotnet build -t:Run -f net9.0-windows10.0.19041.0

   # Android
   dotnet build -t:Run -f net9.0-android
   ```

## Demo Structure

```
Maui-ECharts Demo/
├── MainPage.xaml         # UI layout with chart viewer
├── MainPage.xaml.cs      # Chart examples and data
├── App.xaml             # Application resources
├── MauiProgram.cs       # MAUI app configuration
└── Platforms/           # Platform-specific implementations
```

## How It Works

1. **Chart Selection**: Left sidebar displays available chart types
2. **Interactive Display**: Select any chart to see it rendered instantly
3. **Auto-Enhancement**: Charts include zoom, toolbox, and interaction features
4. **Responsive Design**: Charts automatically resize with the window

## Customization Guide

### Adding New Chart Types

In `MainPage.xaml.cs`, add to the `GetChartOptions` method:

```csharp
"newchart" => @"{
    title: { text: 'New Chart Example' },
    // Your ECharts configuration here
}",
```

### Changing Themes

Modify the theme in `MainPage.xaml`:
```xml
<echarts:EChartsView Theme="Dark" />
```

## Tips

- Charts support mouse wheel zoom and drag interaction
- Use the toolbox buttons for data view and image export
- Resize the window to see responsive behavior
- All chart configurations use standard ECharts JSON format

## Troubleshooting

- **Build errors**: Ensure .NET 9.0 SDK is installed
- **Charts not displaying**: Check internet connection (CDN mode)
- **Platform issues**: Verify platform-specific workloads are installed

## Learn More

- [Apache ECharts Documentation](https://echarts.apache.org/en/option.html)
- [.NET MAUI Documentation](https://docs.microsoft.com/dotnet/maui/)