# MauiECharts

A .NET MAUI control that wraps the JavaScript ECharts library, providing beautiful, interactive charts for cross-platform applications.

## Features

- Full ECharts functionality in MAUI applications
- Support for all major chart types (Line, Bar, Pie, Scatter, Radar, Gauge, etc.)
- Multiple built-in themes
- Easy-to-use API with fluent chart builder
- Cross-platform support (iOS, Android, Windows, macOS)
- Option to use local or CDN-hosted ECharts library

## Installation

Install the NuGet package:

```bash
dotnet add package MauiECharts
```

## Quick Start

### 1. Add namespace to your XAML

```xml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:echarts="clr-namespace:MauiECharts;assembly=MauiECharts"
             x:Class="YourApp.MainPage">
```

### 2. Add the EChartsView control

```xml
<echarts:EChartsView x:Name="ChartView" 
                     HeightRequest="400"
                     Theme="Default" />
```

### 3. Set chart options in code-behind

```csharp
// Using the fluent builder
var options = ChartOptionsBuilder.Create()
    .SetTitle("Sales Data")
    .SetTooltip(true, "axis")
    .SetLegend("Product A", "Product B")
    .SetXAxis("category", "Jan", "Feb", "Mar", "Apr", "May")
    .SetYAxis("value")
    .AddLineSeries("Product A", 120, 200, 150, 80, 70)
    .AddLineSeries("Product B", 80, 100, 120, 140, 160)
    .Build();

ChartView.Options = options;
```

Or use raw JavaScript options:

```csharp
ChartView.Options = new
{
    title = new { text = "My Chart" },
    xAxis = new { type = "category", data = new[] { "Mon", "Tue", "Wed" } },
    yAxis = new { type = "value" },
    series = new[]
    {
        new { name = "Sales", type = "bar", data = new[] { 120, 200, 150 } }
    }
};
```

## Available Themes

- Default
- Dark
- Vintage
- Westeros
- Essos
- Wonderland
- Walden
- Chalk
- Infographic
- Macarons
- Roma
- Shine
- Purple
- Halloween

## Advanced Usage

### Async Operations

```csharp
// Update chart dynamically
await ChartView.SetOptionAsync(newOptions);

// Clear the chart
await ChartView.ClearAsync();

// Resize the chart
await ChartView.ResizeAsync();

// Dispose the chart
await ChartView.DisposeAsync();
```

### Using Local Assets

To use a local copy of ECharts instead of CDN:

```xml
<echarts:EChartsView UseLocalAssets="True" />
```

## Chart Types Examples

### Pie Chart

```csharp
var options = ChartOptionsBuilder.Create()
    .SetTitle("Market Share")
    .AddPieSeries("Share", new List<PieDataItem>
    {
        new PieDataItem(1048, "Search Engine"),
        new PieDataItem(735, "Direct"),
        new PieDataItem(580, "Email"),
        new PieDataItem(484, "Union Ads")
    })
    .Build();
```

### Radar Chart

```csharp
var options = ChartOptionsBuilder.Create()
    .SetTitle("Skills Assessment")
    .AddRadarSeries("Developer", 
        new List<double> { 4200, 3000, 20000, 35000, 50000 },
        new List<RadarIndicator>
        {
            new RadarIndicator("Coding", 5000),
            new RadarIndicator("Design", 5000),
            new RadarIndicator("Testing", 25000),
            new RadarIndicator("Documentation", 40000),
            new RadarIndicator("Communication", 50000)
        })
    .Build();
```

### Gauge Chart

```csharp
var options = ChartOptionsBuilder.Create()
    .SetTitle("Performance Meter")
    .AddGaugeSeries("Score", 75, "%")
    .Build();
```

## License

MIT

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## Support

For issues and feature requests, please use the GitHub issues page.