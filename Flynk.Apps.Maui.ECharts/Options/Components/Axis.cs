using System.Text.Json.Serialization;

namespace Flynk.Apps.Maui.ECharts.Options
{
    public class Axis
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("show")]
        public bool? Show { get; set; }

        [JsonPropertyName("gridIndex")]
        public int? GridIndex { get; set; }

        [JsonPropertyName("alignTicks")]
        public bool? AlignTicks { get; set; }

        [JsonPropertyName("position")]
        public string? Position { get; set; }

        [JsonPropertyName("offset")]
        public int? Offset { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; } // 'value', 'category', 'time', 'log'

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("nameLocation")]
        public string? NameLocation { get; set; }

        [JsonPropertyName("nameTextStyle")]
        public TextStyle? NameTextStyle { get; set; }

        [JsonPropertyName("nameGap")]
        public int? NameGap { get; set; }

        [JsonPropertyName("nameRotate")]
        public int? NameRotate { get; set; }

        [JsonPropertyName("inverse")]
        public bool? Inverse { get; set; }

        [JsonPropertyName("boundaryGap")]
        public object? BoundaryGap { get; set; } // bool or array

        [JsonPropertyName("min")]
        public object? Min { get; set; } // number or 'dataMin' or function

        [JsonPropertyName("max")]
        public object? Max { get; set; } // number or 'dataMax' or function

        [JsonPropertyName("scale")]
        public bool? Scale { get; set; }

        [JsonPropertyName("splitNumber")]
        public int? SplitNumber { get; set; }

        [JsonPropertyName("minInterval")]
        public int? MinInterval { get; set; }

        [JsonPropertyName("maxInterval")]
        public int? MaxInterval { get; set; }

        [JsonPropertyName("interval")]
        public int? Interval { get; set; }

        [JsonPropertyName("logBase")]
        public int? LogBase { get; set; }

        [JsonPropertyName("silent")]
        public bool? Silent { get; set; }

        [JsonPropertyName("triggerEvent")]
        public bool? TriggerEvent { get; set; }

        [JsonPropertyName("axisLine")]
        public AxisLine? AxisLine { get; set; }

        [JsonPropertyName("axisTick")]
        public AxisTick? AxisTick { get; set; }

        [JsonPropertyName("minorTick")]
        public MinorTick? MinorTick { get; set; }

        [JsonPropertyName("axisLabel")]
        public AxisLabel? AxisLabel { get; set; }

        [JsonPropertyName("splitLine")]
        public SplitLine? SplitLine { get; set; }

        [JsonPropertyName("minorSplitLine")]
        public MinorSplitLine? MinorSplitLine { get; set; }

        [JsonPropertyName("splitArea")]
        public SplitArea? SplitArea { get; set; }

        [JsonPropertyName("data")]
        public List<object>? Data { get; set; }

        [JsonPropertyName("axisPointer")]
        public AxisPointer? AxisPointer { get; set; }

        [JsonPropertyName("animation")]
        public bool? Animation { get; set; }

        [JsonPropertyName("animationThreshold")]
        public int? AnimationThreshold { get; set; }

        [JsonPropertyName("animationDuration")]
        public int? AnimationDuration { get; set; }

        [JsonPropertyName("animationEasing")]
        public string? AnimationEasing { get; set; }

        [JsonPropertyName("animationDelay")]
        public object? AnimationDelay { get; set; }

        [JsonPropertyName("animationDurationUpdate")]
        public int? AnimationDurationUpdate { get; set; }

        [JsonPropertyName("animationEasingUpdate")]
        public string? AnimationEasingUpdate { get; set; }

        [JsonPropertyName("animationDelayUpdate")]
        public object? AnimationDelayUpdate { get; set; }

        [JsonPropertyName("zlevel")]
        public int? Zlevel { get; set; }

        [JsonPropertyName("z")]
        public int? Z { get; set; }
    }

    public class AxisLine
    {
        [JsonPropertyName("show")]
        public bool? Show { get; set; }

        [JsonPropertyName("onZero")]
        public bool? OnZero { get; set; }

        [JsonPropertyName("onZeroAxisIndex")]
        public int? OnZeroAxisIndex { get; set; }

        [JsonPropertyName("symbol")]
        public object? Symbol { get; set; } // string or array

        [JsonPropertyName("symbolSize")]
        public List<int>? SymbolSize { get; set; }

        [JsonPropertyName("symbolOffset")]
        public object? SymbolOffset { get; set; }

        [JsonPropertyName("lineStyle")]
        public LineStyle? LineStyle { get; set; }
    }

    public class AxisTick
    {
        [JsonPropertyName("show")]
        public bool? Show { get; set; }

        [JsonPropertyName("alignWithLabel")]
        public bool? AlignWithLabel { get; set; }

        [JsonPropertyName("interval")]
        public object? Interval { get; set; }

        [JsonPropertyName("inside")]
        public bool? Inside { get; set; }

        [JsonPropertyName("length")]
        public int? Length { get; set; }

        [JsonPropertyName("lineStyle")]
        public LineStyle? LineStyle { get; set; }
    }

    public class MinorTick
    {
        [JsonPropertyName("show")]
        public bool? Show { get; set; }

        [JsonPropertyName("splitNumber")]
        public int? SplitNumber { get; set; }

        [JsonPropertyName("length")]
        public int? Length { get; set; }

        [JsonPropertyName("lineStyle")]
        public LineStyle? LineStyle { get; set; }
    }

    public class AxisLabel
    {
        [JsonPropertyName("show")]
        public bool? Show { get; set; }

        [JsonPropertyName("interval")]
        public object? Interval { get; set; }

        [JsonPropertyName("inside")]
        public bool? Inside { get; set; }

        [JsonPropertyName("rotate")]
        public int? Rotate { get; set; }

        [JsonPropertyName("margin")]
        public int? Margin { get; set; }

        [JsonPropertyName("formatter")]
        public object? Formatter { get; set; }

        [JsonPropertyName("showMinLabel")]
        public bool? ShowMinLabel { get; set; }

        [JsonPropertyName("showMaxLabel")]
        public bool? ShowMaxLabel { get; set; }

        [JsonPropertyName("hideOverlap")]
        public bool? HideOverlap { get; set; }

        [JsonPropertyName("color")]
        public object? Color { get; set; }

        [JsonPropertyName("fontStyle")]
        public string? FontStyle { get; set; }

        [JsonPropertyName("fontWeight")]
        public object? FontWeight { get; set; }

        [JsonPropertyName("fontFamily")]
        public string? FontFamily { get; set; }

        [JsonPropertyName("fontSize")]
        public int? FontSize { get; set; }

        [JsonPropertyName("align")]
        public string? Align { get; set; }

        [JsonPropertyName("verticalAlign")]
        public string? VerticalAlign { get; set; }

        [JsonPropertyName("lineHeight")]
        public int? LineHeight { get; set; }

        [JsonPropertyName("backgroundColor")]
        public object? BackgroundColor { get; set; }

        [JsonPropertyName("borderColor")]
        public string? BorderColor { get; set; }

        [JsonPropertyName("borderWidth")]
        public int? BorderWidth { get; set; }

        [JsonPropertyName("borderType")]
        public object? BorderType { get; set; }

        [JsonPropertyName("borderDashOffset")]
        public int? BorderDashOffset { get; set; }

        [JsonPropertyName("borderRadius")]
        public object? BorderRadius { get; set; }

        [JsonPropertyName("padding")]
        public object? Padding { get; set; }

        [JsonPropertyName("shadowColor")]
        public string? ShadowColor { get; set; }

        [JsonPropertyName("shadowBlur")]
        public int? ShadowBlur { get; set; }

        [JsonPropertyName("shadowOffsetX")]
        public int? ShadowOffsetX { get; set; }

        [JsonPropertyName("shadowOffsetY")]
        public int? ShadowOffsetY { get; set; }

        [JsonPropertyName("width")]
        public object? Width { get; set; }

        [JsonPropertyName("height")]
        public object? Height { get; set; }

        [JsonPropertyName("textBorderColor")]
        public string? TextBorderColor { get; set; }

        [JsonPropertyName("textBorderWidth")]
        public int? TextBorderWidth { get; set; }

        [JsonPropertyName("textBorderType")]
        public object? TextBorderType { get; set; }

        [JsonPropertyName("textBorderDashOffset")]
        public int? TextBorderDashOffset { get; set; }

        [JsonPropertyName("textShadowColor")]
        public string? TextShadowColor { get; set; }

        [JsonPropertyName("textShadowBlur")]
        public int? TextShadowBlur { get; set; }

        [JsonPropertyName("textShadowOffsetX")]
        public int? TextShadowOffsetX { get; set; }

        [JsonPropertyName("textShadowOffsetY")]
        public int? TextShadowOffsetY { get; set; }

        [JsonPropertyName("overflow")]
        public string? Overflow { get; set; }

        [JsonPropertyName("ellipsis")]
        public string? Ellipsis { get; set; }

        [JsonPropertyName("rich")]
        public Dictionary<string, object>? Rich { get; set; }
    }

    public class SplitLine
    {
        [JsonPropertyName("show")]
        public bool? Show { get; set; }

        [JsonPropertyName("interval")]
        public object? Interval { get; set; }

        [JsonPropertyName("lineStyle")]
        public LineStyle? LineStyle { get; set; }
    }

    public class MinorSplitLine
    {
        [JsonPropertyName("show")]
        public bool? Show { get; set; }

        [JsonPropertyName("lineStyle")]
        public LineStyle? LineStyle { get; set; }
    }

    public class SplitArea
    {
        [JsonPropertyName("interval")]
        public object? Interval { get; set; }

        [JsonPropertyName("show")]
        public bool? Show { get; set; }

        [JsonPropertyName("areaStyle")]
        public AreaStyle? AreaStyle { get; set; }
    }

    // Specialized axis types
    public class RadiusAxis : Axis
    {
        [JsonPropertyName("polarIndex")]
        public int? PolarIndex { get; set; }
    }

    public class AngleAxis : Axis
    {
        [JsonPropertyName("polarIndex")]
        public int? PolarIndex { get; set; }

        [JsonPropertyName("startAngle")]
        public int? StartAngle { get; set; }

        [JsonPropertyName("clockwise")]
        public bool? Clockwise { get; set; }
    }

    public class SingleAxis : Axis
    {
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

        [JsonPropertyName("orient")]
        public string? Orient { get; set; }
    }

    public class ParallelAxis : Axis
    {
        [JsonPropertyName("dim")]
        public int? Dim { get; set; }

        [JsonPropertyName("parallelIndex")]
        public int? ParallelIndex { get; set; }

        [JsonPropertyName("realtime")]
        public bool? Realtime { get; set; }

        [JsonPropertyName("areaSelectStyle")]
        public AreaSelectStyle? AreaSelectStyle { get; set; }
    }

    public class AreaSelectStyle
    {
        [JsonPropertyName("width")]
        public int? Width { get; set; }

        [JsonPropertyName("borderWidth")]
        public int? BorderWidth { get; set; }

        [JsonPropertyName("borderColor")]
        public string? BorderColor { get; set; }

        [JsonPropertyName("color")]
        public string? Color { get; set; }

        [JsonPropertyName("opacity")]
        public double? Opacity { get; set; }
    }

    // 3D Axes
    public class Axis3D : Axis
    {
        [JsonPropertyName("grid3DIndex")]
        public int? Grid3DIndex { get; set; }
    }
}