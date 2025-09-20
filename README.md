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

### Using as Project Reference

1. Clone this repository
2. Add project reference to your .NET MAUI project:
```xml
<ProjectReference Include="..\Flynk.Apps.Maui.ECharts\Flynk.Apps.Maui.ECharts.csproj" />
```

### NuGet Package (Coming Soon)

```bash
dotnet add package Flynk.Apps.Maui.ECharts
```

## 🎯 Quick Start

### 1. Add namespace to your XAML

```xml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:echarts="clr-namespace:Flynk.Apps.Maui.ECharts;assembly=Flynk.Apps.Maui.ECharts"
             x:Class="YourApp.ChartPage">

    <echarts:EChartsView x:Name="ChartView"
                        Theme="Default"
                        HeightRequest="400" />
</ContentPage>
```

### 2. Set chart options in code-behind

```csharp
// Using JSON string
ChartView.Options = @"{
    title: { text: 'Sales Overview' },
    xAxis: { type: 'category', data: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri'] },
    yAxis: { type: 'value' },
    series: [{
        data: [120, 200, 150, 80, 70],
        type: 'bar'
    }]
}";

// Or using the fluent builder
var builder = new ChartOptionsBuilder()
    .SetTitle("Sales Overview")
    .SetXAxis("category", "Mon", "Tue", "Wed", "Thu", "Fri")
    .SetYAxis("value")
    .AddBarSeries("Sales", 120, 200, 150, 80, 70);

ChartView.Options = builder.Build();
```

## 📊 Chart Examples

### Line Chart
```csharp
var options = new ChartOptionsBuilder()
    .SetTitle("Temperature Trends")
    .SetTooltip(trigger: "axis")
    .SetLegend("Temperature", "Humidity")
    .SetXAxis("category", "Jan", "Feb", "Mar", "Apr", "May")
    .SetYAxis("value")
    .AddLineSeries("Temperature", 5, 10, 15, 18, 22)
    .AddLineSeries("Humidity", 60, 65, 70, 75, 80)
    .Build();
```

### Pie Chart
```csharp
var options = @"{
    title: { text: 'Market Share', left: 'center' },
    series: [{
        type: 'pie',
        radius: '50%',
        data: [
            { value: 35, name: 'Product A' },
            { value: 30, name: 'Product B' },
            { value: 20, name: 'Product C' },
            { value: 15, name: 'Others' }
        ]
    }]
}";
```

### 3D Bar Chart
```csharp
var options = @"{
    grid3D: { boxWidth: 200, boxDepth: 80 },
    xAxis3D: { type: 'category', data: ['Q1', 'Q2', 'Q3', 'Q4'] },
    yAxis3D: { type: 'value' },
    zAxis3D: { type: 'category', data: ['2023', '2024'] },
    series: [{
        type: 'bar3D',
        data: [[0,0,5],[0,1,1],[0,2,0],[1,0,7],[1,1,0],[1,2,0],[2,0,1],[2,1,1]]
    }]
}";
```

## 🎨 Themes

Apply built-in themes to your charts:

```csharp
ChartView.Theme = EChartsTheme.Dark;        // Dark theme
ChartView.Theme = EChartsTheme.Vintage;     // Vintage theme
ChartView.Theme = EChartsTheme.Macarons;    // Colorful theme
```

## ⚙️ Advanced Configuration

### Using Local Assets
```csharp
// Use local ECharts files instead of CDN
ChartView.UseLocalAssets = true;
```

### Interactive Features
The library automatically adds interactive features:
- **Data Zoom**: Mouse wheel zoom and drag to pan
- **Toolbox**: Save as image, data view, restore
- **Tooltips**: Hover to see data details
- **Legend Toggle**: Click legend items to show/hide series

### Custom Interactions
```csharp
// Execute JavaScript for advanced interactions
await ChartView.EvaluateJavaScriptAsync(@"
    chart.on('click', function(params) {
        console.log('Clicked:', params.name, params.value);
    });
");
```

## 📁 Project Structure

```
Flynk.Apps.Maui.ECharts/
├── EChartsView.cs              # Main control implementation
├── ChartOptionsBuilder.cs      # Fluent API builder
├── Options/                    # Strongly-typed options
│   ├── ChartOptions.cs
│   ├── Builders/              # Builder patterns
│   ├── Common/                # Common types
│   ├── Components/            # Chart components
│   └── Series/                # Series definitions
└── Resources/
    └── Raw/
        ├── echarts.min.js     # ECharts library
        └── echarts-gl.min.js  # 3D support
```

## 🧪 Demo Application

Check out the `Maui-ECharts Demo` folder for a complete demonstration application with examples of all chart types.

To run the demo:
```bash
cd "Maui-ECharts"
dotnet build -t:Run -f net9.0-windows10.0.19041.0
```

## 📝 Requirements

- .NET 9.0 or later
- Visual Studio 2022 17.14+ or VS Code
- Target platforms:
  - Windows 10.0.17763.0+
  - Android 21+
  - iOS 15.0+
  - macOS 15.0+

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## 📄 License

This project is licensed under the MIT License. Apache ECharts is licensed under the Apache License 2.0.

## 🔗 Links

- [Apache ECharts Documentation](https://echarts.apache.org/en/option.html)
- [.NET MAUI Documentation](https://docs.microsoft.com/dotnet/maui/)

## 📞 Support

For issues, questions, or suggestions, please open an issue in the GitHub repository.