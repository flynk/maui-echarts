using System.Text.Json.Serialization;

namespace Flynk.Apps.Maui.ECharts.Options.Series
{
    /// <summary>
    /// Base class for all series types
    /// </summary>
    public abstract class SeriesBase
    {
        [JsonPropertyName("type")]
        public abstract string Type { get; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("colorBy")]
        public string? ColorBy { get; set; } // 'series', 'data'

        [JsonPropertyName("legendHoverLink")]
        public bool? LegendHoverLink { get; set; }

        [JsonPropertyName("coordinateSystem")]
        public virtual string? CoordinateSystem { get; set; }

        [JsonPropertyName("xAxisIndex")]
        public int? XAxisIndex { get; set; }

        [JsonPropertyName("yAxisIndex")]
        public int? YAxisIndex { get; set; }

        [JsonPropertyName("polarIndex")]
        public int? PolarIndex { get; set; }

        [JsonPropertyName("geoIndex")]
        public int? GeoIndex { get; set; }

        [JsonPropertyName("calendarIndex")]
        public int? CalendarIndex { get; set; }

        [JsonPropertyName("hoverAnimation")]
        public bool? HoverAnimation { get; set; }

        [JsonPropertyName("label")]
        public Label? Label { get; set; }

        [JsonPropertyName("labelLine")]
        public LabelLine? LabelLine { get; set; }

        [JsonPropertyName("labelLayout")]
        public object? LabelLayout { get; set; }

        [JsonPropertyName("itemStyle")]
        public ItemStyle? ItemStyle { get; set; }

        [JsonPropertyName("lineStyle")]
        public LineStyle? LineStyle { get; set; }

        [JsonPropertyName("areaStyle")]
        public AreaStyle? AreaStyle { get; set; }

        [JsonPropertyName("emphasis")]
        public Emphasis? Emphasis { get; set; }

        [JsonPropertyName("blur")]
        public Blur? Blur { get; set; }

        [JsonPropertyName("select")]
        public Select? Select { get; set; }

        [JsonPropertyName("selectedMode")]
        public object? SelectedMode { get; set; } // bool, 'single', 'multiple', 'series'

        [JsonPropertyName("data")]
        public List<object>? Data { get; set; }

        [JsonPropertyName("datasetIndex")]
        public int? DatasetIndex { get; set; }

        [JsonPropertyName("datasetId")]
        public string? DatasetId { get; set; }

        [JsonPropertyName("seriesLayoutBy")]
        public string? SeriesLayoutBy { get; set; } // 'column', 'row'

        [JsonPropertyName("dataGroupId")]
        public string? DataGroupId { get; set; }

        [JsonPropertyName("dimensions")]
        public List<object>? Dimensions { get; set; }

        [JsonPropertyName("encode")]
        public Dictionary<string, object>? Encode { get; set; }

        [JsonPropertyName("markPoint")]
        public MarkPoint? MarkPoint { get; set; }

        [JsonPropertyName("markLine")]
        public MarkLine? MarkLine { get; set; }

        [JsonPropertyName("markArea")]
        public MarkArea? MarkArea { get; set; }

        [JsonPropertyName("zlevel")]
        public int? ZLevel { get; set; }

        [JsonPropertyName("z")]
        public int? Z { get; set; }

        [JsonPropertyName("silent")]
        public bool? Silent { get; set; }

        [JsonPropertyName("animation")]
        public bool? Animation { get; set; }

        [JsonPropertyName("animationThreshold")]
        public int? AnimationThreshold { get; set; }

        [JsonPropertyName("animationDuration")]
        public object? AnimationDuration { get; set; }

        [JsonPropertyName("animationEasing")]
        public string? AnimationEasing { get; set; }

        [JsonPropertyName("animationDelay")]
        public object? AnimationDelay { get; set; }

        [JsonPropertyName("animationDurationUpdate")]
        public object? AnimationDurationUpdate { get; set; }

        [JsonPropertyName("animationEasingUpdate")]
        public string? AnimationEasingUpdate { get; set; }

        [JsonPropertyName("animationDelayUpdate")]
        public object? AnimationDelayUpdate { get; set; }

        [JsonPropertyName("universalTransition")]
        public object? UniversalTransition { get; set; }

        [JsonPropertyName("tooltip")]
        public object? Tooltip { get; set; }
    }

    /// <summary>
    /// Base class for cartesian coordinate system series (line, bar, scatter, etc.)
    /// </summary>
    public abstract class CartesianSeriesBase : SeriesBase
    {
        [JsonPropertyName("stack")]
        public string? Stack { get; set; }

        [JsonPropertyName("stackStrategy")]
        public string? StackStrategy { get; set; } // 'samesign', 'all', 'positive', 'negative'

        [JsonPropertyName("sampling")]
        public string? Sampling { get; set; } // 'lttb', 'average', 'max', 'min', 'sum'

        [JsonPropertyName("cursor")]
        public string? Cursor { get; set; }

        [JsonPropertyName("connectNulls")]
        public bool? ConnectNulls { get; set; }

        [JsonPropertyName("clipOverflow")]
        public bool? ClipOverflow { get; set; }

        [JsonPropertyName("step")]
        public object? Step { get; set; } // bool, 'start', 'middle', 'end'

        public override string CoordinateSystem { get; set; } = "cartesian2d";
    }

    /// <summary>
    /// Base class for series that support symbols (line, scatter, etc.)
    /// </summary>
    public abstract class SymbolSeriesBase : CartesianSeriesBase
    {
        [JsonPropertyName("symbol")]
        public object? Symbol { get; set; } // string or function

        [JsonPropertyName("symbolSize")]
        public object? SymbolSize { get; set; } // number, array, or function

        [JsonPropertyName("symbolRotate")]
        public object? SymbolRotate { get; set; } // number or function

        [JsonPropertyName("symbolKeepAspect")]
        public bool? SymbolKeepAspect { get; set; }

        [JsonPropertyName("symbolOffset")]
        public object? SymbolOffset { get; set; } // array or function

        [JsonPropertyName("showSymbol")]
        public bool? ShowSymbol { get; set; }

        [JsonPropertyName("showAllSymbol")]
        public object? ShowAllSymbol { get; set; } // bool or 'auto'
    }

    /// <summary>
    /// Data item for series that support coordinates
    /// </summary>
    public class CoordinateDataItem : DataItem
    {
        [JsonPropertyName("coord")]
        public List<object>? Coord
        {
            get => this.ContainsKey("coord") ? this["coord"] as List<object> : null;
            set => this["coord"] = value;
        }

        [JsonPropertyName("x")]
        public object? X
        {
            get => this.ContainsKey("x") ? this["x"] : null;
            set => this["x"] = value;
        }

        [JsonPropertyName("y")]
        public object? Y
        {
            get => this.ContainsKey("y") ? this["y"] : null;
            set => this["y"] = value;
        }

        public CoordinateDataItem() { }

        public CoordinateDataItem(object x, object y, string? name = null) : base(name ?? "", new[] { x, y })
        {
            X = x;
            Y = y;
        }

        public CoordinateDataItem(List<object> coord, string? name = null) : base(name ?? "", coord)
        {
            Coord = coord;
        }
    }

    /// <summary>
    /// Data item for pie charts
    /// </summary>
    public class PieDataItem : DataItem
    {
        [JsonPropertyName("selected")]
        public bool? Selected
        {
            get => this.ContainsKey("selected") ? this["selected"] as bool? : null;
            set => this["selected"] = value;
        }

        public PieDataItem() { }

        public PieDataItem(string name, double value, bool selected = false) : base(name, value)
        {
            Selected = selected;
        }
    }

    /// <summary>
    /// Data item for radar charts
    /// </summary>
    public class RadarDataItem : DataItem
    {
        [JsonPropertyName("symbol")]
        public string? Symbol
        {
            get => this.ContainsKey("symbol") ? this["symbol"] as string : null;
            set => this["symbol"] = value;
        }

        [JsonPropertyName("symbolSize")]
        public object? SymbolSize
        {
            get => this.ContainsKey("symbolSize") ? this["symbolSize"] : null;
            set => this["symbolSize"] = value;
        }

        public RadarDataItem() { }

        public RadarDataItem(string name, List<double> values) : base(name, values) { }
    }

    /// <summary>
    /// Data item for graph/network charts
    /// </summary>
    public class GraphDataItem : DataItem
    {
        [JsonPropertyName("id")]
        public string? Id
        {
            get => this.ContainsKey("id") ? this["id"] as string : null;
            set => this["id"] = value;
        }

        [JsonPropertyName("x")]
        public double? X
        {
            get => this.ContainsKey("x") ? this["x"] as double? : null;
            set => this["x"] = value;
        }

        [JsonPropertyName("y")]
        public double? Y
        {
            get => this.ContainsKey("y") ? this["y"] as double? : null;
            set => this["y"] = value;
        }

        [JsonPropertyName("fixed")]
        public bool? Fixed
        {
            get => this.ContainsKey("fixed") ? this["fixed"] as bool? : null;
            set => this["fixed"] = value;
        }

        [JsonPropertyName("category")]
        public object? Category
        {
            get => this.ContainsKey("category") ? this["category"] : null;
            set => this["category"] = value;
        }

        [JsonPropertyName("symbol")]
        public string? Symbol
        {
            get => this.ContainsKey("symbol") ? this["symbol"] as string : null;
            set => this["symbol"] = value;
        }

        [JsonPropertyName("symbolSize")]
        public object? SymbolSize
        {
            get => this.ContainsKey("symbolSize") ? this["symbolSize"] : null;
            set => this["symbolSize"] = value;
        }

        public GraphDataItem() { }

        public GraphDataItem(string id, string name, double? x = null, double? y = null) : base(name, null)
        {
            Id = id;
            X = x;
            Y = y;
        }
    }

    /// <summary>
    /// Link data for graph/network charts
    /// </summary>
    public class GraphLinkItem : Dictionary<string, object?>
    {
        [JsonPropertyName("source")]
        public object? Source
        {
            get => this.ContainsKey("source") ? this["source"] : null;
            set => this["source"] = value;
        }

        [JsonPropertyName("target")]
        public object? Target
        {
            get => this.ContainsKey("target") ? this["target"] : null;
            set => this["target"] = value;
        }

        [JsonPropertyName("value")]
        public object? Value
        {
            get => this.ContainsKey("value") ? this["value"] : null;
            set => this["value"] = value;
        }

        [JsonPropertyName("lineStyle")]
        public LineStyle? LineStyle
        {
            get => this.ContainsKey("lineStyle") ? this["lineStyle"] as LineStyle : null;
            set => this["lineStyle"] = value;
        }

        [JsonPropertyName("label")]
        public Label? Label
        {
            get => this.ContainsKey("label") ? this["label"] as Label : null;
            set => this["label"] = value;
        }

        [JsonPropertyName("emphasis")]
        public Emphasis? Emphasis
        {
            get => this.ContainsKey("emphasis") ? this["emphasis"] as Emphasis : null;
            set => this["emphasis"] = value;
        }

        public GraphLinkItem() { }

        public GraphLinkItem(object source, object target, object? value = null)
        {
            Source = source;
            Target = target;
            Value = value;
        }
    }
}