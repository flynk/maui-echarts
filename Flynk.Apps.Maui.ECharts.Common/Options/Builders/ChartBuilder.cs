using Flynk.Apps.Maui.ECharts.Options.Series;

namespace Flynk.Apps.Maui.ECharts.Options.Builders
{
    /// <summary>
    /// Fluent builder for creating ECharts configurations
    /// </summary>
    public class ChartBuilder
    {
        private readonly ChartOptions _options;

        private ChartBuilder()
        {
            _options = new ChartOptions();
        }

        public static ChartBuilder Create() => new ChartBuilder();

        public ChartBuilder WithTitle(string text, string? subtext = null)
        {
            _options.SetTitle(text, subtext);
            return this;
        }

        public ChartBuilder WithTooltip(string trigger = "item", bool? show = true)
        {
            _options.Tooltip = new Tooltip { Trigger = trigger, Show = show };
            return this;
        }

        public ChartBuilder WithLegend(bool show = true, string orient = "horizontal", params string[] data)
        {
            _options.Legend = new Legend
            {
                Show = show,
                Orient = orient,
                Data = data.Cast<object>().ToList()
            };
            return this;
        }

        public ChartBuilder WithGrid(string left = "10%", string top = "15%", string right = "10%", string bottom = "10%", bool containLabel = true)
        {
            _options.Grid = new Grid
            {
                Left = left,
                Top = top,
                Right = right,
                Bottom = bottom,
                ContainLabel = containLabel
            };
            return this;
        }

        public ChartBuilder WithXAxis(string type = "category", object[]? data = null, string? name = null)
        {
            _options.XAxis = new Axis
            {
                Type = type,
                Data = data?.ToList(),
                Name = name
            };
            return this;
        }

        public ChartBuilder WithYAxis(string type = "value", string? name = null, double? min = null, double? max = null)
        {
            _options.YAxis = new Axis
            {
                Type = type,
                Name = name,
                Min = min,
                Max = max
            };
            return this;
        }

        public ChartBuilder WithAnimation(bool enabled = true, int duration = 1000, string easing = "cubicOut")
        {
            _options.SetAnimation(enabled, duration, easing);
            return this;
        }

        public ChartBuilder WithToolbox(params string[] features)
        {
            _options.SetToolbox(Toolbox.WithFeatures(features));
            return this;
        }

        public ChartBuilder WithDataZoom(bool inside = true, bool slider = false)
        {
            var dataZooms = new List<DataZoom>();

            if (inside) dataZooms.Add(InsideDataZoom.Default());
            if (slider) dataZooms.Add(SliderDataZoom.Default());

            _options.DataZoom = dataZooms;
            return this;
        }

        public ChartBuilder WithVisualMap(double min, double max, params string[] colors)
        {
            _options.VisualMap = ContinuousVisualMap.Create(min, max, colors);
            return this;
        }

        public ChartBuilder WithBackgroundColor(string color)
        {
            _options.SetBackgroundColor(color);
            return this;
        }

        public ChartBuilder WithPolar(string[]? center = null, object? radius = null)
        {
            _options.Polar = new Polar
            {
                Center = center ?? new[] { "50%", "50%" },
                Radius = radius ?? "75%"
            };
            return this;
        }

        public ChartBuilder WithRadar(params RadarIndicator[] indicators)
        {
            _options.Radar = Radar.Create(indicators);
            return this;
        }

        public ChartBuilder With3DGrid(double width = 100, double height = 100, double depth = 100)
        {
            _options.Grid3D = new Grid3D
            {
                BoxWidth = width,
                BoxHeight = height,
                BoxDepth = depth
            };
            return this;
        }

        public ChartBuilder With3DAxes(string xType = "value", string yType = "value", string zType = "value")
        {
            _options.XAxis3D = new Axis3D { Type = xType };
            _options.YAxis3D = new Axis3D { Type = yType };
            _options.ZAxis3D = new Axis3D { Type = zType };
            return this;
        }

        // Series builders
        public ChartBuilder AddLineSeries(string name, double[] data, bool smooth = false, bool showSymbol = true)
        {
            var series = LineSeries.Create(name, data);
            if (smooth) series.SetSmooth();
            series.ShowSymbol = showSymbol;
            _options.AddSeries(series);
            return this;
        }

        public ChartBuilder AddBarSeries(string name, double[] data, string? stack = null, object? barWidth = null)
        {
            var series = BarSeries.Create(name, data);
            if (!string.IsNullOrEmpty(stack)) series.SetStack(stack);
            if (barWidth != null) series.SetWidth(barWidth);
            _options.AddSeries(series);
            return this;
        }

        public ChartBuilder AddPieSeries(string name, (string name, double value)[] data, object? radius = null, object? center = null)
        {
            var pieData = data.Select(d => new Flynk.Apps.Maui.ECharts.Options.Series.PieDataItem(d.name, d.value)).ToArray();
            var series = PieSeries.Create(name, pieData);
            if (radius != null) series.SetRadius(radius);
            if (center != null) series.SetCenter(center);
            _options.AddSeries(series);
            return this;
        }

        public ChartBuilder AddScatterSeries(string name, (double x, double y)[] points, int symbolSize = 10)
        {
            var scatterData = points.Select(p => new CoordinateDataItem(p.x, p.y)).ToArray();
            var series = ScatterSeries.Create(name, scatterData);
            series.SymbolSize = symbolSize;
            _options.AddSeries(series);
            return this;
        }

        public ChartBuilder AddRadarSeries(string name, double[] values)
        {
            var series = RadarSeries.Create(name, values.ToList());
            _options.AddSeries(series);
            return this;
        }

        public ChartBuilder AddCandlestickSeries(string name, (double open, double close, double low, double high)[] data)
        {
            var candleData = data.Select(d => new[] { d.open, d.close, d.low, d.high }).ToArray();
            var series = CandlestickSeries.Create(name, candleData);
            _options.AddSeries(series);
            return this;
        }

        public ChartBuilder AddHeatmapSeries(string name, (int x, int y, double value)[] data)
        {
            var heatData = data.Select(d => new[] { (double)d.x, (double)d.y, d.value }).ToArray();
            var series = HeatmapSeries.Create(name, heatData);
            _options.AddSeries(series);
            return this;
        }

        public ChartBuilder AddGaugeSeries(string name, double value, double min = 0, double max = 100)
        {
            var series = GaugeSeries.Create(name, value, min, max);
            _options.AddSeries(series);
            return this;
        }

        public ChartBuilder AddFunnelSeries(string name, (string name, double value)[] data)
        {
            var funnelData = data.Select(d => new Flynk.Apps.Maui.ECharts.Options.Series.PieDataItem(d.name, d.value)).ToArray();
            var series = FunnelSeries.Create(name, funnelData);
            _options.AddSeries(series);
            return this;
        }

        public ChartBuilder AddGraphSeries(string name, GraphDataItem[] nodes, GraphLinkItem[] links, string layout = "force", bool roam = true)
        {
            var series = GraphSeries.Create(name, nodes.ToList(), links.ToList());
            series.Layout = layout;
            series.Roam = roam;
            _options.AddSeries(series);
            return this;
        }

        // 3D series
        public ChartBuilder Add3DBarSeries(string name, (double x, double y, double value)[] data)
        {
            var bar3DData = data.Select(d => new[] { d.x, d.y, d.value }).ToArray();
            var series = Bar3DSeries.Create(name, bar3DData);
            _options.AddSeries(series);
            return this;
        }

        public ChartBuilder Add3DScatterSeries(string name, (double x, double y, double z)[] points, int symbolSize = 10)
        {
            var scatter3DData = points.Select(p => new[] { p.x, p.y, p.z }).ToArray();
            var series = Scatter3DSeries.Create(name, scatter3DData);
            series.SymbolSize = symbolSize;
            _options.AddSeries(series);
            return this;
        }

        public ChartBuilder Add3DLineSeries(string name, (double x, double y, double z)[] points)
        {
            var line3DData = points.Select(p => new[] { p.x, p.y, p.z }).ToArray();
            var series = Line3DSeries.Create(name, line3DData);
            _options.AddSeries(series);
            return this;
        }

        public ChartBuilder AddSurfaceSeries(string name, double[][] data)
        {
            var series = SurfaceSeries.Create(name, data);
            _options.AddSeries(series);
            return this;
        }

        // Advanced configuration
        public ChartBuilder Configure(Action<ChartOptions> configAction)
        {
            configAction(_options);
            return this;
        }

        public ChartOptions Build() => _options;

        // Quick preset builders
        public static ChartBuilder LineChart(string title, string[] categories, params (string name, double[] data)[] seriesData)
        {
            var builder = Create()
                .WithTitle(title)
                .WithTooltip("axis")
                .WithXAxis("category", categories.Cast<object>().ToArray())
                .WithYAxis("value")
                .WithLegend(true, "horizontal", seriesData.Select(s => s.name).ToArray());

            foreach (var (name, data) in seriesData)
            {
                builder.AddLineSeries(name, data);
            }

            return builder;
        }

        public static ChartBuilder BarChart(string title, string[] categories, params (string name, double[] data)[] seriesData)
        {
            var builder = Create()
                .WithTitle(title)
                .WithTooltip("axis")
                .WithXAxis("category", categories.Cast<object>().ToArray())
                .WithYAxis("value")
                .WithLegend(true, "horizontal", seriesData.Select(s => s.name).ToArray());

            foreach (var (name, data) in seriesData)
            {
                builder.AddBarSeries(name, data);
            }

            return builder;
        }

        public static ChartBuilder PieChart(string title, params (string name, double value)[] data)
        {
            return Create()
                .WithTitle(title)
                .WithTooltip("item")
                .WithLegend(true, "horizontal", data.Select(d => d.name).ToArray())
                .AddPieSeries("Data", data);
        }

        public static ChartBuilder ScatterChart(string title, params (string name, (double x, double y)[] points)[] seriesData)
        {
            var builder = Create()
                .WithTitle(title)
                .WithTooltip("item")
                .WithXAxis("value")
                .WithYAxis("value")
                .WithLegend(true, "horizontal", seriesData.Select(s => s.name).ToArray());

            foreach (var (name, points) in seriesData)
            {
                builder.AddScatterSeries(name, points);
            }

            return builder;
        }

        public static ChartBuilder RadarChart(string title, RadarIndicator[] indicators, params (string name, double[] values)[] seriesData)
        {
            var builder = Create()
                .WithTitle(title)
                .WithTooltip("item")
                .WithRadar(indicators)
                .WithLegend(true, "horizontal", seriesData.Select(s => s.name).ToArray());

            foreach (var (name, values) in seriesData)
            {
                builder.AddRadarSeries(name, values);
            }

            return builder;
        }

        public static ChartBuilder Chart3D(string title)
        {
            return Create()
                .WithTitle(title)
                .WithTooltip("item")
                .With3DGrid()
                .With3DAxes();
        }
    }
}