using System.Text.Json.Serialization;
using Flynk.Apps.Maui.ECharts.Options.Series;

namespace Flynk.Apps.Maui.ECharts.Options
{
    public class ChartOptions
    {
        [JsonPropertyName("title")]
        public Title? Title { get; set; }

        [JsonPropertyName("legend")]
        public Legend? Legend { get; set; }

        [JsonPropertyName("grid")]
        public Grid? Grid { get; set; }

        [JsonPropertyName("xAxis")]
        public Axis? XAxis { get; set; }

        [JsonPropertyName("yAxis")]
        public Axis? YAxis { get; set; }

        [JsonPropertyName("polar")]
        public Polar? Polar { get; set; }

        [JsonPropertyName("radiusAxis")]
        public RadiusAxis? RadiusAxis { get; set; }

        [JsonPropertyName("angleAxis")]
        public AngleAxis? AngleAxis { get; set; }

        [JsonPropertyName("radar")]
        public Radar? Radar { get; set; }

        [JsonPropertyName("dataZoom")]
        public List<DataZoom>? DataZoom { get; set; }

        [JsonPropertyName("visualMap")]
        public VisualMap? VisualMap { get; set; }

        [JsonPropertyName("tooltip")]
        public Tooltip? Tooltip { get; set; }

        [JsonPropertyName("axisPointer")]
        public AxisPointer? AxisPointer { get; set; }

        [JsonPropertyName("toolbox")]
        public Toolbox? Toolbox { get; set; }

        [JsonPropertyName("brush")]
        public Brush? Brush { get; set; }

        [JsonPropertyName("geo")]
        public Geo? Geo { get; set; }

        [JsonPropertyName("parallel")]
        public Parallel? Parallel { get; set; }

        [JsonPropertyName("parallelAxis")]
        public List<ParallelAxis>? ParallelAxis { get; set; }

        [JsonPropertyName("singleAxis")]
        public SingleAxis? SingleAxis { get; set; }

        [JsonPropertyName("timeline")]
        public Timeline? Timeline { get; set; }

        [JsonPropertyName("graphic")]
        public Graphic? Graphic { get; set; }

        [JsonPropertyName("calendar")]
        public Calendar? Calendar { get; set; }

        [JsonPropertyName("dataset")]
        public Dataset? Dataset { get; set; }

        [JsonPropertyName("series")]
        public List<SeriesBase>? Series { get; set; }

        [JsonPropertyName("backgroundColor")]
        public string? BackgroundColor { get; set; }

        [JsonPropertyName("textStyle")]
        public TextStyle? TextStyle { get; set; }

        [JsonPropertyName("animation")]
        public bool? Animation { get; set; }

        [JsonPropertyName("animationThreshold")]
        public int? AnimationThreshold { get; set; }

        [JsonPropertyName("animationDuration")]
        public int? AnimationDuration { get; set; }

        [JsonPropertyName("animationEasing")]
        public string? AnimationEasing { get; set; }

        [JsonPropertyName("animationDelay")]
        public int? AnimationDelay { get; set; }

        [JsonPropertyName("animationDurationUpdate")]
        public int? AnimationDurationUpdate { get; set; }

        [JsonPropertyName("animationEasingUpdate")]
        public string? AnimationEasingUpdate { get; set; }

        [JsonPropertyName("animationDelayUpdate")]
        public int? AnimationDelayUpdate { get; set; }

        [JsonPropertyName("blendMode")]
        public string? BlendMode { get; set; }

        [JsonPropertyName("hoverLayerThreshold")]
        public int? HoverLayerThreshold { get; set; }

        [JsonPropertyName("useUTC")]
        public bool? UseUTC { get; set; }

        // 3D properties for ECharts GL
        [JsonPropertyName("globe")]
        public Globe? Globe { get; set; }

        [JsonPropertyName("geo3D")]
        public Geo3D? Geo3D { get; set; }

        [JsonPropertyName("grid3D")]
        public Grid3D? Grid3D { get; set; }

        [JsonPropertyName("xAxis3D")]
        public Axis3D? XAxis3D { get; set; }

        [JsonPropertyName("yAxis3D")]
        public Axis3D? YAxis3D { get; set; }

        [JsonPropertyName("zAxis3D")]
        public Axis3D? ZAxis3D { get; set; }

        // Helper methods for fluent configuration
        public ChartOptions SetTitle(string text, string? subtext = null)
        {
            Title = new Title { Text = text, Subtext = subtext };
            return this;
        }

        public ChartOptions SetTooltip(string trigger = "item")
        {
            Tooltip = new Tooltip { Trigger = trigger };
            return this;
        }

        public ChartOptions SetLegend(params string[] data)
        {
            Legend = new Legend { Data = data.Cast<object>().ToList() };
            return this;
        }

        public ChartOptions SetGrid(Grid grid)
        {
            Grid = grid;
            return this;
        }

        public ChartOptions SetAxes(Axis? xAxis = null, Axis? yAxis = null)
        {
            if (xAxis != null) XAxis = xAxis;
            if (yAxis != null) YAxis = yAxis;
            return this;
        }

        public ChartOptions AddSeries(params SeriesBase[] series)
        {
            Series ??= new List<SeriesBase>();
            Series.AddRange(series);
            return this;
        }

        public ChartOptions AddDataZoom(params DataZoom[] dataZooms)
        {
            DataZoom ??= new List<DataZoom>();
            DataZoom.AddRange(dataZooms);
            return this;
        }

        public ChartOptions SetToolbox(Toolbox toolbox)
        {
            Toolbox = toolbox;
            return this;
        }

        public ChartOptions SetVisualMap(VisualMap visualMap)
        {
            VisualMap = visualMap;
            return this;
        }

        public ChartOptions SetBackgroundColor(string color)
        {
            BackgroundColor = color;
            return this;
        }

        public ChartOptions SetAnimation(bool enabled = true, int? duration = null, string? easing = null)
        {
            Animation = enabled;
            if (duration.HasValue) AnimationDuration = duration.Value;
            if (!string.IsNullOrEmpty(easing)) AnimationEasing = easing;
            return this;
        }

        // Quick creation methods
        public static ChartOptions Empty() => new ChartOptions();

        public static ChartOptions CreateLineChart(string title, string[] categories, params (string name, double[] data)[] series)
        {
            var options = new ChartOptions()
                .SetTitle(title)
                .SetTooltip("axis")
                .SetLegend(series.Select(s => s.name).ToArray())
                .SetAxes(
                    new Axis { Type = "category", Data = categories.Cast<object>().ToList() },
                    new Axis { Type = "value" }
                );

            foreach (var (name, data) in series)
            {
                options.AddSeries(LineSeries.Create(name, data));
            }

            return options;
        }

        public static ChartOptions CreateBarChart(string title, string[] categories, params (string name, double[] data)[] series)
        {
            var options = new ChartOptions()
                .SetTitle(title)
                .SetTooltip("axis")
                .SetLegend(series.Select(s => s.name).ToArray())
                .SetAxes(
                    new Axis { Type = "category", Data = categories.Cast<object>().ToList() },
                    new Axis { Type = "value" }
                );

            foreach (var (name, data) in series)
            {
                options.AddSeries(BarSeries.Create(name, data));
            }

            return options;
        }

        public static ChartOptions CreatePieChart(string title, params (string name, double value)[] data)
        {
            var pieData = data.Select(d => new Flynk.Apps.Maui.ECharts.Options.Series.PieDataItem(d.name, d.value)).ToArray();
            return new ChartOptions()
                .SetTitle(title)
                .SetTooltip("item")
                .SetLegend(data.Select(d => d.name).ToArray())
                .AddSeries(PieSeries.Create("Data", pieData));
        }

        public static ChartOptions CreateScatterChart(string title, params (string name, (double x, double y)[] points)[] series)
        {
            var options = new ChartOptions()
                .SetTitle(title)
                .SetTooltip("item")
                .SetLegend(series.Select(s => s.name).ToArray())
                .SetAxes(
                    new Axis { Type = "value" },
                    new Axis { Type = "value" }
                );

            foreach (var (name, points) in series)
            {
                var scatterData = points.Select(p => new CoordinateDataItem(p.x, p.y)).ToArray();
                options.AddSeries(ScatterSeries.Create(name, scatterData));
            }

            return options;
        }

        public static ChartOptions CreateRadarChart(string title, RadarIndicator[] indicators, params (string name, double[] values)[] series)
        {
            var options = new ChartOptions()
                .SetTitle(title)
                .SetTooltip("item")
                .SetLegend(series.Select(s => s.name).ToArray());

            options.Radar = Radar.Create(indicators);

            foreach (var (name, values) in series)
            {
                options.AddSeries(RadarSeries.Create(name, values.ToList()));
            }

            return options;
        }
    }
}