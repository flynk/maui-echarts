using System.Text.Json.Serialization;

namespace Flynk.Apps.Maui.ECharts.Options
{
    /// <summary>
    /// Polar coordinate system
    /// </summary>
    public class Polar
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("zlevel")]
        public int? ZLevel { get; set; }

        [JsonPropertyName("z")]
        public int? Z { get; set; }

        [JsonPropertyName("center")]
        public object? Center { get; set; } // array ['50%', '50%']

        [JsonPropertyName("radius")]
        public object? Radius { get; set; } // number, percentage, or array

        [JsonPropertyName("tooltip")]
        public object? Tooltip { get; set; }

        public static Polar Default() => new Polar
        {
            Center = new[] { "50%", "50%" },
            Radius = "75%"
        };
    }

    /// <summary>
    /// Radar component
    /// </summary>
    public class Radar
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("zlevel")]
        public int? ZLevel { get; set; }

        [JsonPropertyName("z")]
        public int? Z { get; set; }

        [JsonPropertyName("center")]
        public object? Center { get; set; }

        [JsonPropertyName("radius")]
        public object? Radius { get; set; }

        [JsonPropertyName("startAngle")]
        public int? StartAngle { get; set; }

        [JsonPropertyName("axisName")]
        public object? AxisName { get; set; }

        [JsonPropertyName("nameGap")]
        public int? NameGap { get; set; }

        [JsonPropertyName("splitNumber")]
        public int? SplitNumber { get; set; }

        [JsonPropertyName("shape")]
        public string? Shape { get; set; } // 'polygon', 'circle'

        [JsonPropertyName("scale")]
        public bool? Scale { get; set; }

        [JsonPropertyName("silent")]
        public bool? Silent { get; set; }

        [JsonPropertyName("triggerEvent")]
        public bool? TriggerEvent { get; set; }

        [JsonPropertyName("axisLine")]
        public AxisLine? AxisLine { get; set; }

        [JsonPropertyName("axisTick")]
        public AxisTick? AxisTick { get; set; }

        [JsonPropertyName("axisLabel")]
        public AxisLabel? AxisLabel { get; set; }

        [JsonPropertyName("splitLine")]
        public SplitLine? SplitLine { get; set; }

        [JsonPropertyName("splitArea")]
        public SplitArea? SplitArea { get; set; }

        [JsonPropertyName("indicator")]
        public List<RadarIndicator>? Indicator { get; set; }

        public static Radar Create(params RadarIndicator[] indicators) => new Radar
        {
            Center = new[] { "50%", "50%" },
            Radius = "75%",
            Indicator = indicators.ToList()
        };
    }

    /// <summary>
    /// Radar indicator definition
    /// </summary>
    public class RadarIndicator
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("max")]
        public double? Max { get; set; }

        [JsonPropertyName("min")]
        public double? Min { get; set; }

        [JsonPropertyName("color")]
        public string? Color { get; set; }

        public RadarIndicator() { }

        public RadarIndicator(string name, double max, double min = 0)
        {
            Name = name;
            Max = max;
            Min = min;
        }
    }

    /// <summary>
    /// Geographic coordinate system
    /// </summary>
    public class Geo
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("show")]
        public bool? Show { get; set; } = true;

        [JsonPropertyName("map")]
        public string? Map { get; set; }

        [JsonPropertyName("roam")]
        public object? Roam { get; set; } // bool, 'scale', 'move'

        [JsonPropertyName("projection")]
        public object? Projection { get; set; }

        [JsonPropertyName("center")]
        public List<double>? Center { get; set; }

        [JsonPropertyName("aspectScale")]
        public double? AspectScale { get; set; }

        [JsonPropertyName("boundingCoords")]
        public List<List<double>>? BoundingCoords { get; set; }

        [JsonPropertyName("zoom")]
        public double? Zoom { get; set; }

        [JsonPropertyName("scaleLimit")]
        public object? ScaleLimit { get; set; }

        [JsonPropertyName("nameMap")]
        public Dictionary<string, string>? NameMap { get; set; }

        [JsonPropertyName("nameProperty")]
        public string? NameProperty { get; set; }

        [JsonPropertyName("selectedMode")]
        public object? SelectedMode { get; set; }

        [JsonPropertyName("label")]
        public Label? Label { get; set; }

        [JsonPropertyName("itemStyle")]
        public ItemStyle? ItemStyle { get; set; }

        [JsonPropertyName("emphasis")]
        public Emphasis? Emphasis { get; set; }

        [JsonPropertyName("select")]
        public Select? Select { get; set; }

        [JsonPropertyName("zlevel")]
        public int? ZLevel { get; set; }

        [JsonPropertyName("z")]
        public int? Z { get; set; }

        [JsonPropertyName("left")]
        public object? Left { get; set; }

        [JsonPropertyName("top")]
        public object? Top { get; set; }

        [JsonPropertyName("right")]
        public object? Right { get; set; }

        [JsonPropertyName("bottom")]
        public object? Bottom { get; set; }

        [JsonPropertyName("layoutCenter")]
        public List<object>? LayoutCenter { get; set; }

        [JsonPropertyName("layoutSize")]
        public object? LayoutSize { get; set; }

        [JsonPropertyName("regions")]
        public List<object>? Regions { get; set; }

        [JsonPropertyName("silent")]
        public bool? Silent { get; set; }

        [JsonPropertyName("tooltip")]
        public object? Tooltip { get; set; }

        public static Geo World() => new Geo { Map = "world" };
        public static Geo Create(string mapName) => new Geo { Map = mapName };
    }

    /// <summary>
    /// Parallel coordinate system
    /// </summary>
    public class Parallel
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("zlevel")]
        public int? ZLevel { get; set; }

        [JsonPropertyName("z")]
        public int? Z { get; set; }

        [JsonPropertyName("left")]
        public object? Left { get; set; }

        [JsonPropertyName("top")]
        public object? Top { get; set; }

        [JsonPropertyName("right")]
        public object? Right { get; set; }

        [JsonPropertyName("bottom")]
        public object? Bottom { get; set; }

        [JsonPropertyName("width")]
        public object? Width { get; set; }

        [JsonPropertyName("height")]
        public object? Height { get; set; }

        [JsonPropertyName("layout")]
        public string? Layout { get; set; } // 'horizontal', 'vertical'

        [JsonPropertyName("axisExpandable")]
        public bool? AxisExpandable { get; set; }

        [JsonPropertyName("axisExpandCenter")]
        public int? AxisExpandCenter { get; set; }

        [JsonPropertyName("axisExpandCount")]
        public int? AxisExpandCount { get; set; }

        [JsonPropertyName("axisExpandWidth")]
        public int? AxisExpandWidth { get; set; }

        [JsonPropertyName("axisExpandTriggerOn")]
        public string? AxisExpandTriggerOn { get; set; }

        [JsonPropertyName("parallelAxisDefault")]
        public object? ParallelAxisDefault { get; set; }

        public static Parallel Default() => new Parallel
        {
            Left = "5%",
            Right = "18%",
            Bottom = "10%",
            Top = "20%"
        };
    }

    /// <summary>
    /// Timeline component
    /// </summary>
    public class Timeline
    {
        [JsonPropertyName("show")]
        public bool? Show { get; set; } = true;

        [JsonPropertyName("type")]
        public string? Type { get; set; } // 'slider'

        [JsonPropertyName("axisType")]
        public string? AxisType { get; set; } // 'category', 'time', 'value'

        [JsonPropertyName("currentIndex")]
        public int? CurrentIndex { get; set; }

        [JsonPropertyName("autoPlay")]
        public bool? AutoPlay { get; set; }

        [JsonPropertyName("rewind")]
        public bool? Rewind { get; set; }

        [JsonPropertyName("loop")]
        public bool? Loop { get; set; }

        [JsonPropertyName("playInterval")]
        public int? PlayInterval { get; set; }

        [JsonPropertyName("realtime")]
        public bool? Realtime { get; set; }

        [JsonPropertyName("replaceMerge")]
        public object? ReplaceMerge { get; set; }

        [JsonPropertyName("controlPosition")]
        public string? ControlPosition { get; set; }

        [JsonPropertyName("zlevel")]
        public int? ZLevel { get; set; }

        [JsonPropertyName("z")]
        public int? Z { get; set; }

        [JsonPropertyName("left")]
        public object? Left { get; set; }

        [JsonPropertyName("top")]
        public object? Top { get; set; }

        [JsonPropertyName("right")]
        public object? Right { get; set; }

        [JsonPropertyName("bottom")]
        public object? Bottom { get; set; }

        [JsonPropertyName("padding")]
        public object? Padding { get; set; }

        [JsonPropertyName("orient")]
        public string? Orient { get; set; }

        [JsonPropertyName("inverse")]
        public bool? Inverse { get; set; }

        [JsonPropertyName("symbol")]
        public string? Symbol { get; set; }

        [JsonPropertyName("symbolSize")]
        public object? SymbolSize { get; set; }

        [JsonPropertyName("symbolRotate")]
        public int? SymbolRotate { get; set; }

        [JsonPropertyName("symbolKeepAspect")]
        public bool? SymbolKeepAspect { get; set; }

        [JsonPropertyName("symbolOffset")]
        public object? SymbolOffset { get; set; }

        [JsonPropertyName("lineStyle")]
        public LineStyle? LineStyle { get; set; }

        [JsonPropertyName("label")]
        public Label? Label { get; set; }

        [JsonPropertyName("itemStyle")]
        public ItemStyle? ItemStyle { get; set; }

        [JsonPropertyName("checkpointStyle")]
        public object? CheckpointStyle { get; set; }

        [JsonPropertyName("controlStyle")]
        public object? ControlStyle { get; set; }

        [JsonPropertyName("progress")]
        public object? Progress { get; set; }

        [JsonPropertyName("emphasis")]
        public Emphasis? Emphasis { get; set; }

        [JsonPropertyName("data")]
        public List<object>? Data { get; set; }

        public static Timeline Default() => new Timeline
        {
            AutoPlay = false,
            PlayInterval = 1000,
            Realtime = true
        };
    }

    /// <summary>
    /// Brush component for data selection
    /// </summary>
    public class Brush
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("toolbox")]
        public List<string>? Toolbox { get; set; }

        [JsonPropertyName("brushLink")]
        public object? BrushLink { get; set; }

        [JsonPropertyName("seriesIndex")]
        public object? SeriesIndex { get; set; }

        [JsonPropertyName("geoIndex")]
        public object? GeoIndex { get; set; }

        [JsonPropertyName("xAxisIndex")]
        public object? XAxisIndex { get; set; }

        [JsonPropertyName("yAxisIndex")]
        public object? YAxisIndex { get; set; }

        [JsonPropertyName("brushType")]
        public string? BrushType { get; set; } // 'rect', 'polygon', 'lineX', 'lineY'

        [JsonPropertyName("brushMode")]
        public string? BrushMode { get; set; } // 'single', 'multiple'

        [JsonPropertyName("transformable")]
        public bool? Transformable { get; set; }

        [JsonPropertyName("brushStyle")]
        public object? BrushStyle { get; set; }

        [JsonPropertyName("throttleType")]
        public string? ThrottleType { get; set; }

        [JsonPropertyName("throttleDelay")]
        public int? ThrottleDelay { get; set; }

        [JsonPropertyName("removeOnClick")]
        public bool? RemoveOnClick { get; set; }

        [JsonPropertyName("inBrush")]
        public object? InBrush { get; set; }

        [JsonPropertyName("outOfBrush")]
        public object? OutOfBrush { get; set; }

        [JsonPropertyName("z")]
        public int? Z { get; set; }

        public static Brush Default() => new Brush
        {
            BrushType = "rect",
            BrushMode = "multiple"
        };
    }

    /// <summary>
    /// Calendar component
    /// </summary>
    public class Calendar
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("zlevel")]
        public int? ZLevel { get; set; }

        [JsonPropertyName("z")]
        public int? Z { get; set; }

        [JsonPropertyName("left")]
        public object? Left { get; set; }

        [JsonPropertyName("top")]
        public object? Top { get; set; }

        [JsonPropertyName("right")]
        public object? Right { get; set; }

        [JsonPropertyName("bottom")]
        public object? Bottom { get; set; }

        [JsonPropertyName("width")]
        public object? Width { get; set; }

        [JsonPropertyName("height")]
        public object? Height { get; set; }

        [JsonPropertyName("range")]
        public object? Range { get; set; } // string, array

        [JsonPropertyName("cellSize")]
        public object? CellSize { get; set; } // number or array

        [JsonPropertyName("orient")]
        public string? Orient { get; set; } // 'horizontal', 'vertical'

        [JsonPropertyName("splitLine")]
        public object? SplitLine { get; set; }

        [JsonPropertyName("itemStyle")]
        public ItemStyle? ItemStyle { get; set; }

        [JsonPropertyName("dayLabel")]
        public object? DayLabel { get; set; }

        [JsonPropertyName("monthLabel")]
        public object? MonthLabel { get; set; }

        [JsonPropertyName("yearLabel")]
        public object? YearLabel { get; set; }

        [JsonPropertyName("silent")]
        public bool? Silent { get; set; }

        public static Calendar Create(string year) => new Calendar
        {
            Range = year,
            CellSize = new object[] { "auto", 20 }
        };

        public static Calendar Create(string startDate, string endDate) => new Calendar
        {
            Range = new[] { startDate, endDate },
            CellSize = new object[] { "auto", 20 }
        };
    }

    /// <summary>
    /// Dataset component for data management
    /// </summary>
    public class Dataset
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("source")]
        public object? Source { get; set; } // array or object

        [JsonPropertyName("dimensions")]
        public List<object>? Dimensions { get; set; }

        [JsonPropertyName("sourceHeader")]
        public bool? SourceHeader { get; set; }

        [JsonPropertyName("transform")]
        public List<object>? Transform { get; set; }

        [JsonPropertyName("fromDatasetIndex")]
        public int? FromDatasetIndex { get; set; }

        [JsonPropertyName("fromDatasetId")]
        public string? FromDatasetId { get; set; }

        [JsonPropertyName("fromTransformResult")]
        public int? FromTransformResult { get; set; }

        public static Dataset FromArray(object[][] data, params string[] dimensions)
        {
            return new Dataset
            {
                Source = data,
                Dimensions = dimensions.Cast<object>().ToList()
            };
        }

        public static Dataset FromObjects(object[] data)
        {
            return new Dataset
            {
                Source = data
            };
        }
    }

    /// <summary>
    /// Graphic component for custom graphics
    /// </summary>
    public class Graphic
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("elements")]
        public List<object>? Elements { get; set; }

        [JsonPropertyName("left")]
        public object? Left { get; set; }

        [JsonPropertyName("right")]
        public object? Right { get; set; }

        [JsonPropertyName("top")]
        public object? Top { get; set; }

        [JsonPropertyName("bottom")]
        public object? Bottom { get; set; }

        [JsonPropertyName("width")]
        public object? Width { get; set; }

        [JsonPropertyName("height")]
        public object? Height { get; set; }

        [JsonPropertyName("bounding")]
        public string? Bounding { get; set; } // 'all', 'raw'

        [JsonPropertyName("z")]
        public int? Z { get; set; }

        [JsonPropertyName("zlevel")]
        public int? ZLevel { get; set; }

        [JsonPropertyName("silent")]
        public bool? Silent { get; set; }

        [JsonPropertyName("invisible")]
        public bool? Invisible { get; set; }

        [JsonPropertyName("cursor")]
        public string? Cursor { get; set; }

        [JsonPropertyName("draggable")]
        public bool? Draggable { get; set; }

        [JsonPropertyName("progressive")]
        public bool? Progressive { get; set; }

        public static Graphic CreateText(string text, object left, object top, TextStyle? style = null)
        {
            return new Graphic
            {
                Type = "text",
                Left = left,
                Top = top,
                Elements = new List<object>
                {
                    new
                    {
                        type = "text",
                        left = left,
                        top = top,
                        style = new
                        {
                            text = text,
                            textAlign = "center",
                            fill = style?.Color ?? "#000"
                        }
                    }
                }
            };
        }
    }
}