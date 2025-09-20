# MAUI ECharts - Comprehensive C# Wrapper for Apache ECharts

A complete, production-ready .NET MAUI control that wraps the JavaScript ECharts library, providing strongly-typed C# configuration, fluent APIs, and support for all ECharts features including 3D visualizations.

## 🚀 Features

### Complete Chart Type Support
- **2D Charts**: Line, Bar, Pie, Scatter, Radar, Candlestick, Heatmap, Funnel, Gauge, Tree, Sankey
- **3D Charts**: 3D Bar, 3D Scatter, 3D Line, Surface, Globe, Map3D
- **Graph/Network**: Force-directed graphs, tree layouts, Sankey diagrams
- **Advanced**: GL-accelerated charts for large datasets (ScatterGL, GraphGL, FlowGL, LinesGL)

### Strongly-Typed C# Configuration
- ✅ **Type Safety**: All properties are strongly typed with proper C# conventions
- ✅ **Null Safety**: Full nullable reference type support
- ✅ **IntelliSense**: Complete IDE support with XML documentation
- ✅ **Compile-time Validation**: Catch configuration errors before runtime
- ✅ **No JavaScript Required**: Configure everything in pure C#

### Fluent Builder Pattern
- 🔹 **Readable Code**: Clean, fluent API for chart creation
- 🔹 **Method Chaining**: Build complex charts with readable method chains
- 🔹 **Preset Configurations**: Quick chart creation with sensible defaults
- 🔹 **Advanced Customization**: Full access to all ECharts features

### Production-Ready Features
- 📊 **Performance**: Optimized for large datasets and complex visualizations
- 🎨 **14 Built-in Themes**: Default, Dark, Vintage, Westeros, Essos, Wonderland, Walden, Chalk, Infographic, Macarons, Roma, Shine, Purple, Halloween
- 🔄 **Interactivity**: Full support for zoom, brush, toolbox, and custom interactions
- 📱 **Responsive**: Automatic resizing and mobile-friendly
- 💾 **Export**: Save charts as images with customizable options
- 🌐 **Cross-platform**: iOS, Android, Windows, macOS support
- 📦 **CDN or Local**: Option to use CDN-hosted or local ECharts library

## 📋 Installation

Install the NuGet package:

```bash
dotnet add package MauiECharts
```

## 🎯 Quick Start

### 1. Add namespace to your XAML

```xml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:echarts="clr-namespace:Flynk.Apps.Maui.ECharts;assembly=MauiECharts"
             x:Class="YourApp.MainPage">
```

### 2. Add the EChartsView control

```xml
<echarts:EChartsView x:Name="ChartView"
                     HeightRequest="400"
                     Theme="Dark" />
```

### 3. Set chart options in code-behind

#### Simple One-Liner
```csharp
// Create a line chart in one line
var options = ChartOptions.CreateLineChart("Sales Data",
    new[] { "Jan", "Feb", "Mar", "Apr", "May" },
    ("Product A", new[] { 120.0, 200.0, 150.0, 80.0, 170.0 }),
    ("Product B", new[] { 220.0, 180.0, 250.0, 190.0, 210.0 })
);

ChartView.Options = options;
```

#### Fluent Builder Pattern
```csharp
var options = ChartBuilder
    .LineChart("Revenue Analysis", categories, ("Revenue", data))
    .WithAnimation(true, 1000, "cubicOut")
    .WithToolbox("saveAsImage", "restore", "dataZoom")
    .WithDataZoom(inside: true, slider: true)
    .Build();

ChartView.Options = options;
```

#### Advanced Configuration
```csharp
var options = ChartBuilder.Create()
    .WithTitle("Business Dashboard", "Q4 Performance")
    .WithTooltip("axis")
    .WithLegend(true, "horizontal", "Revenue", "Costs", "Profit")
    .WithGrid("10%", "20%", "10%", "15%")
    .AddBarSeries("Revenue", revenueData, barWidth: "30%")
    .AddLineSeries("Profit", profitData, smooth: true)
    .WithVisualMap(0, 100000, "#50a3ba", "#eac736", "#d94e5d")
    .WithAnimation(true, 1500, "elasticOut")
    .Configure(opt => {
        // Custom configuration for advanced scenarios
        opt.Grid!.BackgroundColor = "rgba(255,255,255,0.1)";
        opt.Tooltip!.BackgroundColor = "rgba(0,0,0,0.8)";
    })
    .Build();

ChartView.Options = options;
```

#### Direct C# Object Configuration
```csharp
var options = new ChartOptions()
    .SetTitle("Dashboard")
    .SetTooltip("item")
    .AddSeries(
        LineSeries.Create("Revenue", revenueData).WithSmooth(true),
        BarSeries.Create("Profit", profitData).WithBarWidth("40%")
    )
    .SetAnimation(true, 2000, "cubicOut");

ChartView.Options = options;
```

## 📊 Chart Type Examples

### Line Chart with Area
```csharp
var options = ChartBuilder
    .LineChart("Temperature", hours, ("Temperature", temperatures))
    .Configure(opt => {
        var series = opt.Series![0] as LineSeries;
        series!.SetSmooth(true).SetArea(new AreaStyle { Opacity = 0.5 });
    })
    .Build();
```

### Stacked Bar Chart
```csharp
var options = ChartBuilder.Create()
    .WithTitle("Sales Comparison")
    .AddBarSeries("Product A", dataA, stack: "total")
    .AddBarSeries("Product B", dataB, stack: "total")
    .AddBarSeries("Product C", dataC, stack: "total")
    .Build();
```

### Pie Chart with Donut
```csharp
var options = ChartOptions.CreatePieChart("Market Share",
    ("Search Engine", 1048),
    ("Direct", 735),
    ("Email", 580),
    ("Union Ads", 484)
);

// Convert to donut
(options.Series![0] as PieSeries)?.SetDonut();
```

### Radar Chart
```csharp
var indicators = new[] {
    new RadarIndicator("Coding", 100),
    new RadarIndicator("Design", 100),
    new RadarIndicator("Testing", 100),
    new RadarIndicator("Documentation", 100),
    new RadarIndicator("Communication", 100)
};

var options = ChartOptions.CreateRadarChart("Skills Assessment", indicators,
    ("Developer A", new[] { 85.0, 70.0, 90.0, 60.0, 75.0 }),
    ("Developer B", new[] { 90.0, 85.0, 80.0, 70.0, 95.0 })
);
```

### Scatter Plot
```csharp
var options = ChartOptions.CreateScatterChart("Data Distribution",
    ("Group A", new[] { (1.0, 2.3), (2.1, 3.5), (3.2, 4.1) }),
    ("Group B", new[] { (1.5, 3.2), (2.5, 4.1), (3.5, 5.2) })
);
```

### 3D Bar Chart
```csharp
var options = ChartBuilder.Create()
    .WithTitle("3D Sales Data")
    .WithGrid3D(true)
    .AddBar3DSeries("Sales", data3D)
    .WithVisualMap(0, 100, "#50a3ba", "#eac736")
    .Build();
```

### Gauge Chart
```csharp
var options = ChartBuilder.Create()
    .WithTitle("Performance Meter")
    .AddGaugeSeries("Score", 75, "%", 0, 100)
    .Configure(opt => {
        var gauge = opt.Series![0] as GaugeSeries;
        gauge!.Detail = new { formatter = "{value}%" };
    })
    .Build();
```

## 🛠️ Advanced Usage

### Async Operations
```csharp
// Update chart dynamically
await ChartView.SetOptionAsync(newOptions);

// Clear the chart
await ChartView.ClearAsync();

// Resize the chart
await ChartView.ResizeAsync();

// Dispose the chart when done
await ChartView.DisposeAsync();
```

### Using Local Assets
To use a local copy of ECharts instead of CDN:

```xml
<echarts:EChartsView UseLocalAssets="True" />
```

### Dynamic Data Updates
```csharp
// Real-time data update
var timer = new Timer(_ => {
    MainThread.BeginInvokeOnMainThread(async () => {
        var newData = GetLatestData();
        var options = ChartBuilder
            .LineChart("Real-time Data", timestamps, ("Value", newData))
            .Build();
        await ChartView.SetOptionAsync(options);
    });
}, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
```

### Custom Themes
```csharp
// Use built-in themes
ChartView.Theme = EChartsTheme.Dark;

// Or set in XAML
<echarts:EChartsView Theme="Vintage" />
```

### Interactive Features
```csharp
var options = ChartBuilder.Create()
    .WithTitle("Interactive Chart")
    .WithToolbox(new Toolbox {
        Show = true,
        Feature = new ToolboxFeature {
            SaveAsImage = new SaveAsImage { Title = "Save" },
            Restore = new Restore { Title = "Reset" },
            DataView = new DataView { Title = "Data", ReadOnly = false },
            DataZoom = new ToolboxDataZoom { Title = new { zoom = "Zoom", back = "Reset" } },
            MagicType = new MagicType {
                Type = new[] { "line", "bar", "stack" },
                Title = new { line = "Line", bar = "Bar", stack = "Stack" }
            }
        }
    })
    .AddLineSeries("Data", values)
    .Build();
```

## 🎨 Complete C# API Structure

### Core Components
- **ChartOptions**: Main configuration class
- **ChartBuilder**: Fluent API builder
- **Title, Legend, Tooltip**: Basic components
- **Grid, Axis, DataZoom**: Layout and navigation
- **VisualMap, Toolbox**: Interactive features

### Series Types (30+)
- **Basic**: LineSeries, BarSeries, PieSeries, ScatterSeries
- **Statistical**: BoxplotSeries, CandlestickSeries, HeatmapSeries
- **Relational**: GraphSeries, TreeSeries, SankeySeries
- **3D**: Bar3DSeries, Line3DSeries, Scatter3DSeries, Surface3DSeries
- **GL**: ScatterGLSeries, GraphGLSeries, FlowGLSeries
- **Special**: GaugeSeries, FunnelSeries, RadarSeries

### 3D Support
- **Globe**: Earth visualization with atmosphere
- **Grid3D**: 3D coordinate system
- **Geo3D**: 3D geographic visualization
- **Light**: Ambient, directional, and point lights
- **Post Effects**: SSAO, DOF, Bloom, Color Correction

## 📝 Architecture

### Namespace Structure
```
Flynk.Apps.Maui.ECharts/
├── EChartsView.cs              // Main WebView control
├── EChartsTheme.cs             // Theme enumeration
├── Options/
│   ├── ChartOptions.cs         // Main options class
│   ├── Common/
│   │   └── BaseTypes.cs        // Core types (Color, Position, etc.)
│   ├── Components/
│   │   ├── Title.cs
│   │   ├── Legend.cs
│   │   ├── Tooltip.cs
│   │   ├── Grid.cs
│   │   ├── Axis.cs
│   │   ├── DataZoom.cs
│   │   ├── VisualMap.cs
│   │   ├── Toolbox.cs
│   │   └── Chart3DComponents.cs
│   ├── Series/
│   │   ├── SeriesBase.cs
│   │   ├── ChartSeries.cs      // All 2D series
│   │   └── Chart3DSeries.cs    // All 3D series
│   └── Builders/
│       └── ChartBuilder.cs     // Fluent API
```

## 🔧 Configuration Options

### Enable Development Tools
```xml
<!-- In your .csproj file -->
<PropertyGroup>
    <EnableWebViewCoreDevTools>true</EnableWebViewCoreDevTools>
</PropertyGroup>
```

### Custom JavaScript Integration
```csharp
// Execute custom JavaScript
await ChartView.EvaluateJavaScriptAsync(@"
    chart.on('click', function (params) {
        console.log('Chart clicked:', params);
    });
");
```

## 📚 Documentation

- [Full API Reference](https://github.com/yourusername/maui-echarts/wiki/API-Reference)
- [Chart Gallery](https://github.com/yourusername/maui-echarts/wiki/Chart-Gallery)
- [Migration Guide](https://github.com/yourusername/maui-echarts/wiki/Migration-Guide)
- [Performance Tips](https://github.com/yourusername/maui-echarts/wiki/Performance)

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

### Development Setup
1. Clone the repository
2. Open the solution in Visual Studio 2022 or later
3. Ensure you have the .NET MAUI workload installed
4. Build and run the demo project

### Guidelines
- Follow the existing code style
- Add unit tests for new features
- Update documentation as needed
- Submit PR against the `develop` branch

## 📄 License

MIT License - see [LICENSE](LICENSE) file for details

## 🆘 Support

- **Issues**: [GitHub Issues](https://github.com/yourusername/maui-echarts/issues)
- **Discussions**: [GitHub Discussions](https://github.com/yourusername/maui-echarts/discussions)
- **Stack Overflow**: Tag with `maui-echarts`

## 🙏 Acknowledgments

- [Apache ECharts](https://echarts.apache.org/) - The amazing charting library
- [.NET MAUI Team](https://github.com/dotnet/maui) - For the cross-platform framework
- All contributors who have helped improve this wrapper

---

**Made with ❤️ for the .NET MAUI Community**