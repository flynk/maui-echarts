using System.Text.Json.Serialization;

namespace Flynk.Apps.Maui.ECharts.Options
{
    /// <summary>
    /// Base class for DataZoom components
    /// </summary>
    public abstract class DataZoom
    {
        [JsonPropertyName("type")]
        public abstract string Type { get; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("disabled")]
        public bool? Disabled { get; set; }

        [JsonPropertyName("xAxisIndex")]
        public object? XAxisIndex { get; set; } // number or array

        [JsonPropertyName("yAxisIndex")]
        public object? YAxisIndex { get; set; }

        [JsonPropertyName("radiusAxisIndex")]
        public object? RadiusAxisIndex { get; set; }

        [JsonPropertyName("angleAxisIndex")]
        public object? AngleAxisIndex { get; set; }

        [JsonPropertyName("filterMode")]
        public string? FilterMode { get; set; } // 'filter', 'weakFilter', 'empty', 'none'

        [JsonPropertyName("start")]
        public double? Start { get; set; } // percentage 0-100

        [JsonPropertyName("end")]
        public double? End { get; set; } // percentage 0-100

        [JsonPropertyName("startValue")]
        public object? StartValue { get; set; }

        [JsonPropertyName("endValue")]
        public object? EndValue { get; set; }

        [JsonPropertyName("minSpan")]
        public double? MinSpan { get; set; }

        [JsonPropertyName("maxSpan")]
        public double? MaxSpan { get; set; }

        [JsonPropertyName("minValueSpan")]
        public object? MinValueSpan { get; set; }

        [JsonPropertyName("maxValueSpan")]
        public object? MaxValueSpan { get; set; }

        [JsonPropertyName("orient")]
        public string? Orient { get; set; } // 'horizontal', 'vertical'

        [JsonPropertyName("zoomLock")]
        public bool? ZoomLock { get; set; }

        [JsonPropertyName("throttle")]
        public int? Throttle { get; set; }

        [JsonPropertyName("rangeMode")]
        public object? RangeMode { get; set; } // array ['value', 'percent']

        [JsonPropertyName("zoomOnMouseWheel")]
        public object? ZoomOnMouseWheel { get; set; } // bool, 'shift', 'ctrl'

        [JsonPropertyName("moveOnMouseMove")]
        public object? MoveOnMouseMove { get; set; } // bool, 'shift', 'ctrl'

        [JsonPropertyName("moveOnMouseWheel")]
        public object? MoveOnMouseWheel { get; set; } // bool, 'shift', 'ctrl'

        [JsonPropertyName("preventDefaultMouseMove")]
        public bool? PreventDefaultMouseMove { get; set; }
    }

    /// <summary>
    /// Inside data zoom (pan and zoom with mouse/touch)
    /// </summary>
    public class InsideDataZoom : DataZoom
    {
        public override string Type => "inside";

        public static InsideDataZoom Default() => new InsideDataZoom
        {
            Start = 0,
            End = 100,
            FilterMode = "filter"
        };

        public static InsideDataZoom ForXAxis(int axisIndex = 0) => new InsideDataZoom
        {
            XAxisIndex = axisIndex,
            Start = 0,
            End = 100
        };

        public static InsideDataZoom ForYAxis(int axisIndex = 0) => new InsideDataZoom
        {
            YAxisIndex = axisIndex,
            Start = 0,
            End = 100
        };

        public InsideDataZoom SetRange(double start, double end)
        {
            Start = start;
            End = end;
            return this;
        }

        public InsideDataZoom SetZoomOnMouseWheel(bool enabled = true)
        {
            ZoomOnMouseWheel = enabled;
            return this;
        }
    }

    /// <summary>
    /// Slider data zoom (visible slider control)
    /// </summary>
    public class SliderDataZoom : DataZoom
    {
        public override string Type => "slider";

        [JsonPropertyName("show")]
        public bool? Show { get; set; } = true;

        [JsonPropertyName("backgroundColor")]
        public string? BackgroundColor { get; set; }

        [JsonPropertyName("dataBackground")]
        public object? DataBackground { get; set; }

        [JsonPropertyName("selectedDataBackground")]
        public object? SelectedDataBackground { get; set; }

        [JsonPropertyName("fillerColor")]
        public string? FillerColor { get; set; }

        [JsonPropertyName("borderColor")]
        public string? BorderColor { get; set; }

        [JsonPropertyName("handleIcon")]
        public string? HandleIcon { get; set; }

        [JsonPropertyName("handleSize")]
        public object? HandleSize { get; set; } // number or percentage

        [JsonPropertyName("handleStyle")]
        public object? HandleStyle { get; set; }

        [JsonPropertyName("moveHandleIcon")]
        public string? MoveHandleIcon { get; set; }

        [JsonPropertyName("moveHandleSize")]
        public int? MoveHandleSize { get; set; }

        [JsonPropertyName("moveHandleStyle")]
        public object? MoveHandleStyle { get; set; }

        [JsonPropertyName("labelPrecision")]
        public object? LabelPrecision { get; set; } // number or 'auto'

        [JsonPropertyName("labelFormatter")]
        public object? LabelFormatter { get; set; } // string or function

        [JsonPropertyName("showDetail")]
        public bool? ShowDetail { get; set; }

        [JsonPropertyName("showDataShadow")]
        public object? ShowDataShadow { get; set; } // bool or 'auto'

        [JsonPropertyName("realtime")]
        public bool? Realtime { get; set; }

        [JsonPropertyName("textStyle")]
        public TextStyle? TextStyle { get; set; }

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

        [JsonPropertyName("brushSelect")]
        public bool? BrushSelect { get; set; }

        [JsonPropertyName("brushStyle")]
        public object? BrushStyle { get; set; }

        [JsonPropertyName("emphasis")]
        public object? Emphasis { get; set; }

        [JsonPropertyName("zlevel")]
        public int? ZLevel { get; set; }

        [JsonPropertyName("z")]
        public int? Z { get; set; }

        public static SliderDataZoom Default() => new SliderDataZoom
        {
            Show = true,
            Start = 0,
            End = 100,
            FilterMode = "filter"
        };

        public static SliderDataZoom ForXAxis(int axisIndex = 0) => new SliderDataZoom
        {
            Show = true,
            XAxisIndex = axisIndex,
            Start = 0,
            End = 100
        };

        public static SliderDataZoom ForYAxis(int axisIndex = 0) => new SliderDataZoom
        {
            Show = true,
            YAxisIndex = axisIndex,
            Start = 0,
            End = 100,
            Orient = "vertical"
        };

        public SliderDataZoom SetRange(double start, double end)
        {
            Start = start;
            End = end;
            return this;
        }

        public SliderDataZoom SetPosition(object left, object top, object right, object bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
            return this;
        }

        public SliderDataZoom SetColors(string backgroundColor, string fillerColor)
        {
            BackgroundColor = backgroundColor;
            FillerColor = fillerColor;
            return this;
        }
    }

    /// <summary>
    /// Select data zoom (brush selection)
    /// </summary>
    public class SelectDataZoom : DataZoom
    {
        public override string Type => "select";

        [JsonPropertyName("brushStyle")]
        public object? BrushStyle { get; set; }

        public static SelectDataZoom Default() => new SelectDataZoom
        {
            Start = 0,
            End = 100,
            FilterMode = "filter"
        };
    }
}