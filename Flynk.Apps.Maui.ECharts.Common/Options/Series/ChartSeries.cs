using System.Text.Json.Serialization;

namespace Flynk.Apps.Maui.ECharts.Options.Series
{
    /// <summary>
    /// Line chart series
    /// </summary>
    public class LineSeries : SymbolSeriesBase
    {
        public override string Type => "line";

        [JsonPropertyName("smooth")]
        public object? Smooth { get; set; } // bool or number

        [JsonPropertyName("smoothMonotone")]
        public string? SmoothMonotone { get; set; } // 'x', 'y'

        [JsonPropertyName("endLabel")]
        public Label? EndLabel { get; set; }

        public static LineSeries Create(string name, params double[] data)
        {
            return new LineSeries { Name = name, Data = data.Cast<object>().ToList() };
        }

        public static LineSeries Create(string name, params object[] data)
        {
            return new LineSeries { Name = name, Data = data.ToList() };
        }

        public LineSeries SetSmooth(bool smooth = true)
        {
            Smooth = smooth;
            return this;
        }

        public LineSeries SetArea(AreaStyle? areaStyle = null)
        {
            AreaStyle = areaStyle ?? new AreaStyle();
            return this;
        }
    }

    /// <summary>
    /// Bar chart series
    /// </summary>
    public class BarSeries : CartesianSeriesBase
    {
        public override string Type => "bar";

        [JsonPropertyName("barWidth")]
        public object? BarWidth { get; set; } // number, percentage, or 'auto'

        [JsonPropertyName("barMaxWidth")]
        public object? BarMaxWidth { get; set; }

        [JsonPropertyName("barMinWidth")]
        public object? BarMinWidth { get; set; }

        [JsonPropertyName("barMinHeight")]
        public int? BarMinHeight { get; set; }

        [JsonPropertyName("barGap")]
        public object? BarGap { get; set; } // percentage or '-100%'

        [JsonPropertyName("barCategoryGap")]
        public object? BarCategoryGap { get; set; } // percentage

        [JsonPropertyName("large")]
        public bool? Large { get; set; }

        [JsonPropertyName("largeThreshold")]
        public int? LargeThreshold { get; set; }

        [JsonPropertyName("progressive")]
        public int? Progressive { get; set; }

        [JsonPropertyName("progressiveThreshold")]
        public int? ProgressiveThreshold { get; set; }

        [JsonPropertyName("progressiveChunkMode")]
        public string? ProgressiveChunkMode { get; set; } // 'sequential', 'mod'

        [JsonPropertyName("roundCap")]
        public bool? RoundCap { get; set; }

        [JsonPropertyName("realtimeSort")]
        public bool? RealtimeSort { get; set; }

        [JsonPropertyName("showBackground")]
        public bool? ShowBackground { get; set; }

        [JsonPropertyName("backgroundStyle")]
        public ItemStyle? BackgroundStyle { get; set; }

        public static BarSeries Create(string name, params double[] data)
        {
            return new BarSeries { Name = name, Data = data.Cast<object>().ToList() };
        }

        public static BarSeries Create(string name, params object[] data)
        {
            return new BarSeries { Name = name, Data = data.ToList() };
        }

        public BarSeries SetWidth(object width)
        {
            BarWidth = width;
            return this;
        }

        public BarSeries SetStack(string stackName)
        {
            Stack = stackName;
            return this;
        }
    }

    /// <summary>
    /// Pie chart series
    /// </summary>
    public class PieSeries : SeriesBase
    {
        public override string Type => "pie";

        [JsonPropertyName("center")]
        public object? Center { get; set; } // array ['50%', '50%']

        [JsonPropertyName("radius")]
        public object? Radius { get; set; } // number, percentage, or array [inner, outer]

        [JsonPropertyName("clockwise")]
        public bool? Clockwise { get; set; }

        [JsonPropertyName("startAngle")]
        public int? StartAngle { get; set; }

        [JsonPropertyName("minAngle")]
        public int? MinAngle { get; set; }

        [JsonPropertyName("minShowLabelAngle")]
        public int? MinShowLabelAngle { get; set; }

        [JsonPropertyName("roseType")]
        public object? RoseType { get; set; } // false, 'radius', 'area'

        [JsonPropertyName("avoidLabelOverlap")]
        public bool? AvoidLabelOverlap { get; set; }

        [JsonPropertyName("stillShowZeroSum")]
        public bool? StillShowZeroSum { get; set; }

        [JsonPropertyName("percentPrecision")]
        public int? PercentPrecision { get; set; }

        [JsonPropertyName("cursor")]
        public string? Cursor { get; set; }

        public static PieSeries Create(string name, params PieDataItem[] data)
        {
            return new PieSeries { Name = name, Data = data.Cast<object>().ToList() };
        }

        public static PieSeries Create(string name, Dictionary<string, double> data)
        {
            var items = data.Select(kvp => new PieDataItem(kvp.Key, kvp.Value)).Cast<object>().ToList();
            return new PieSeries { Name = name, Data = items };
        }

        public PieSeries SetRadius(object radius)
        {
            Radius = radius;
            return this;
        }

        public PieSeries SetCenter(object center)
        {
            Center = center;
            return this;
        }

        public PieSeries SetDonut(object? innerRadius = null, object? outerRadius = null)
        {
            Radius = new[] { innerRadius ?? "50%", outerRadius ?? "70%" };
            return this;
        }
    }

    /// <summary>
    /// Scatter chart series
    /// </summary>
    public class ScatterSeries : SymbolSeriesBase
    {
        public override string Type => "scatter";

        [JsonPropertyName("large")]
        public bool? Large { get; set; }

        [JsonPropertyName("largeThreshold")]
        public int? LargeThreshold { get; set; }

        [JsonPropertyName("progressive")]
        public int? Progressive { get; set; }

        [JsonPropertyName("progressiveThreshold")]
        public int? ProgressiveThreshold { get; set; }

        [JsonPropertyName("progressiveChunkMode")]
        public string? ProgressiveChunkMode { get; set; }

        public static ScatterSeries Create(string name, params CoordinateDataItem[] data)
        {
            return new ScatterSeries { Name = name, Data = data.Cast<object>().ToList() };
        }

        public static ScatterSeries Create(string name, params double[][] data)
        {
            var items = data.Select(d => d.Cast<object>().ToList()).Cast<object>().ToList();
            return new ScatterSeries { Name = name, Data = items };
        }
    }

    /// <summary>
    /// Radar chart series
    /// </summary>
    public class RadarSeries : SeriesBase
    {
        public override string Type => "radar";

        [JsonPropertyName("radarIndex")]
        public int? RadarIndex { get; set; }

        [JsonPropertyName("symbol")]
        public object? Symbol { get; set; }

        [JsonPropertyName("symbolSize")]
        public object? SymbolSize { get; set; }

        [JsonPropertyName("symbolRotate")]
        public object? SymbolRotate { get; set; }

        [JsonPropertyName("symbolKeepAspect")]
        public bool? SymbolKeepAspect { get; set; }

        [JsonPropertyName("symbolOffset")]
        public object? SymbolOffset { get; set; }

        public static RadarSeries Create(string name, params RadarDataItem[] data)
        {
            return new RadarSeries { Name = name, Data = data.Cast<object>().ToList() };
        }

        public static RadarSeries Create(string name, List<double> values)
        {
            var dataItem = new RadarDataItem(name, values);
            return new RadarSeries { Name = name, Data = new List<object> { dataItem } };
        }
    }

    /// <summary>
    /// Candlestick/K-line chart series
    /// </summary>
    public class CandlestickSeries : CartesianSeriesBase
    {
        public override string Type => "candlestick";

        [JsonPropertyName("barWidth")]
        public object? BarWidth { get; set; }

        [JsonPropertyName("barMaxWidth")]
        public object? BarMaxWidth { get; set; }

        [JsonPropertyName("barMinWidth")]
        public object? BarMinWidth { get; set; }

        [JsonPropertyName("large")]
        public bool? Large { get; set; }

        [JsonPropertyName("largeThreshold")]
        public int? LargeThreshold { get; set; }

        [JsonPropertyName("progressive")]
        public int? Progressive { get; set; }

        [JsonPropertyName("progressiveThreshold")]
        public int? ProgressiveThreshold { get; set; }

        [JsonPropertyName("progressiveChunkMode")]
        public string? ProgressiveChunkMode { get; set; }

        public static CandlestickSeries Create(string name, params double[][] data)
        {
            var items = data.Select(d => d.Cast<object>().ToList()).Cast<object>().ToList();
            return new CandlestickSeries { Name = name, Data = items };
        }
    }

    /// <summary>
    /// Heatmap chart series
    /// </summary>
    public class HeatmapSeries : SeriesBase
    {
        public override string Type => "heatmap";

        [JsonPropertyName("pointSize")]
        public int? PointSize { get; set; }

        [JsonPropertyName("blurSize")]
        public int? BlurSize { get; set; }

        [JsonPropertyName("minOpacity")]
        public double? MinOpacity { get; set; }

        [JsonPropertyName("maxOpacity")]
        public double? MaxOpacity { get; set; }

        [JsonPropertyName("progressive")]
        public int? Progressive { get; set; }

        [JsonPropertyName("progressiveThreshold")]
        public int? ProgressiveThreshold { get; set; }

        public static HeatmapSeries Create(string name, params double[][] data)
        {
            var items = data.Select(d => d.Cast<object>().ToList()).Cast<object>().ToList();
            return new HeatmapSeries { Name = name, Data = items };
        }
    }

    /// <summary>
    /// Graph/Network chart series
    /// </summary>
    public class GraphSeries : SeriesBase
    {
        public override string Type => "graph";

        [JsonPropertyName("layout")]
        public string? Layout { get; set; } // 'none', 'circular', 'force'

        [JsonPropertyName("circular")]
        public object? Circular { get; set; }

        [JsonPropertyName("force")]
        public object? Force { get; set; }

        [JsonPropertyName("nodeScaleRatio")]
        public double? NodeScaleRatio { get; set; }

        [JsonPropertyName("draggable")]
        public bool? Draggable { get; set; }

        [JsonPropertyName("focusNodeAdjacency")]
        public bool? FocusNodeAdjacency { get; set; }

        [JsonPropertyName("symbol")]
        public object? Symbol { get; set; }

        [JsonPropertyName("symbolSize")]
        public object? SymbolSize { get; set; }

        [JsonPropertyName("symbolRotate")]
        public object? SymbolRotate { get; set; }

        [JsonPropertyName("symbolKeepAspect")]
        public bool? SymbolKeepAspect { get; set; }

        [JsonPropertyName("symbolOffset")]
        public object? SymbolOffset { get; set; }

        [JsonPropertyName("edgeSymbol")]
        public object? EdgeSymbol { get; set; }

        [JsonPropertyName("edgeSymbolSize")]
        public object? EdgeSymbolSize { get; set; }

        [JsonPropertyName("cursor")]
        public string? Cursor { get; set; }

        [JsonPropertyName("roam")]
        public object? Roam { get; set; } // bool, 'scale', 'move'

        [JsonPropertyName("expandAndCollapse")]
        public bool? ExpandAndCollapse { get; set; }

        [JsonPropertyName("initialTreeDepth")]
        public int? InitialTreeDepth { get; set; }

        [JsonPropertyName("links")]
        public List<GraphLinkItem>? Links { get; set; }

        [JsonPropertyName("edges")]
        public List<GraphLinkItem>? Edges { get; set; }

        [JsonPropertyName("nodes")]
        public List<GraphDataItem>? Nodes { get; set; }

        [JsonPropertyName("categories")]
        public List<object>? Categories { get; set; }

        public static GraphSeries Create(string name, List<GraphDataItem> nodes, List<GraphLinkItem> links)
        {
            return new GraphSeries
            {
                Name = name,
                Data = nodes.Cast<object>().ToList(),
                Links = links
            };
        }
    }

    /// <summary>
    /// Gauge chart series
    /// </summary>
    public class GaugeSeries : SeriesBase
    {
        public override string Type => "gauge";

        [JsonPropertyName("radius")]
        public object? Radius { get; set; }

        [JsonPropertyName("startAngle")]
        public int? StartAngle { get; set; }

        [JsonPropertyName("endAngle")]
        public int? EndAngle { get; set; }

        [JsonPropertyName("clockwise")]
        public bool? Clockwise { get; set; }

        [JsonPropertyName("min")]
        public double? Min { get; set; }

        [JsonPropertyName("max")]
        public double? Max { get; set; }

        [JsonPropertyName("splitNumber")]
        public int? SplitNumber { get; set; }

        [JsonPropertyName("axisLine")]
        public object? AxisLine { get; set; }

        [JsonPropertyName("splitLine")]
        public object? SplitLine { get; set; }

        [JsonPropertyName("axisTick")]
        public object? AxisTick { get; set; }

        [JsonPropertyName("axisLabel")]
        public object? AxisLabel { get; set; }

        [JsonPropertyName("pointer")]
        public object? Pointer { get; set; }

        [JsonPropertyName("anchor")]
        public object? Anchor { get; set; }

        [JsonPropertyName("progress")]
        public object? Progress { get; set; }

        [JsonPropertyName("detail")]
        public object? Detail { get; set; }

        [JsonPropertyName("title")]
        public object? Title { get; set; }

        public static GaugeSeries Create(string name, double value, double min = 0, double max = 100)
        {
            var dataItem = new DataItem(name, value);
            return new GaugeSeries
            {
                Name = name,
                Min = min,
                Max = max,
                Data = new List<object> { dataItem }
            };
        }
    }

    /// <summary>
    /// Funnel chart series
    /// </summary>
    public class FunnelSeries : SeriesBase
    {
        public override string Type => "funnel";

        [JsonPropertyName("min")]
        public double? Min { get; set; }

        [JsonPropertyName("max")]
        public double? Max { get; set; }

        [JsonPropertyName("minSize")]
        public object? MinSize { get; set; }

        [JsonPropertyName("maxSize")]
        public object? MaxSize { get; set; }

        [JsonPropertyName("orient")]
        public string? Orient { get; set; } // 'vertical', 'horizontal'

        [JsonPropertyName("sort")]
        public object? Sort { get; set; } // 'descending', 'ascending', 'none', function

        [JsonPropertyName("gap")]
        public int? Gap { get; set; }

        [JsonPropertyName("funnelAlign")]
        public string? FunnelAlign { get; set; } // 'left', 'center', 'right'

        public static FunnelSeries Create(string name, params PieDataItem[] data)
        {
            return new FunnelSeries { Name = name, Data = data.Cast<object>().ToList() };
        }
    }

    /// <summary>
    /// Sankey diagram series
    /// </summary>
    public class SankeySeries : SeriesBase
    {
        public override string Type => "sankey";

        [JsonPropertyName("nodeWidth")]
        public int? NodeWidth { get; set; }

        [JsonPropertyName("nodeGap")]
        public int? NodeGap { get; set; }

        [JsonPropertyName("nodeAlign")]
        public string? NodeAlign { get; set; } // 'justify', 'left', 'right'

        [JsonPropertyName("layoutIterations")]
        public int? LayoutIterations { get; set; }

        [JsonPropertyName("orient")]
        public string? Orient { get; set; } // 'horizontal', 'vertical'

        [JsonPropertyName("draggable")]
        public bool? Draggable { get; set; }

        [JsonPropertyName("levels")]
        public List<object>? Levels { get; set; }

        [JsonPropertyName("nodes")]
        public List<object>? Nodes { get; set; }

        [JsonPropertyName("links")]
        public List<object>? Links { get; set; }

        [JsonPropertyName("edges")]
        public List<object>? Edges { get; set; }

        public static SankeySeries Create(string name, List<object> nodes, List<object> links)
        {
            return new SankeySeries
            {
                Name = name,
                Nodes = nodes,
                Links = links
            };
        }
    }

    /// <summary>
    /// Tree chart series
    /// </summary>
    public class TreeSeries : SeriesBase
    {
        public override string Type => "tree";

        [JsonPropertyName("layout")]
        public string? Layout { get; set; } // 'orthogonal', 'radial'

        [JsonPropertyName("orient")]
        public string? Orient { get; set; } // 'LR', 'RL', 'TB', 'BT'

        [JsonPropertyName("symbol")]
        public object? Symbol { get; set; }

        [JsonPropertyName("symbolSize")]
        public object? SymbolSize { get; set; }

        [JsonPropertyName("symbolRotate")]
        public object? SymbolRotate { get; set; }

        [JsonPropertyName("symbolKeepAspect")]
        public bool? SymbolKeepAspect { get; set; }

        [JsonPropertyName("symbolOffset")]
        public object? SymbolOffset { get; set; }

        [JsonPropertyName("edgeShape")]
        public string? EdgeShape { get; set; } // 'curve', 'polyline'

        [JsonPropertyName("edgeForkPosition")]
        public object? EdgeForkPosition { get; set; }

        [JsonPropertyName("roam")]
        public object? Roam { get; set; }

        [JsonPropertyName("expandAndCollapse")]
        public bool? ExpandAndCollapse { get; set; }

        [JsonPropertyName("initialTreeDepth")]
        public int? InitialTreeDepth { get; set; }

        [JsonPropertyName("leaves")]
        public object? Leaves { get; set; }

        public static TreeSeries Create(string name, object data)
        {
            return new TreeSeries { Name = name, Data = new List<object> { data } };
        }
    }
}