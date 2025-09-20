using System.Text.Json.Serialization;

namespace Flynk.Apps.Maui.ECharts.Options
{
    public class ItemStyle
    {
        [JsonPropertyName("color")]
        public object? Color { get; set; } // string or gradient object

        [JsonPropertyName("borderColor")]
        public string? BorderColor { get; set; }

        [JsonPropertyName("borderWidth")]
        public int? BorderWidth { get; set; }

        [JsonPropertyName("borderType")]
        public object? BorderType { get; set; } // string or number or array

        [JsonPropertyName("borderDashOffset")]
        public int? BorderDashOffset { get; set; }

        [JsonPropertyName("borderCap")]
        public string? BorderCap { get; set; }

        [JsonPropertyName("borderJoin")]
        public string? BorderJoin { get; set; }

        [JsonPropertyName("borderMiterLimit")]
        public int? BorderMiterLimit { get; set; }

        [JsonPropertyName("shadowBlur")]
        public int? ShadowBlur { get; set; }

        [JsonPropertyName("shadowColor")]
        public string? ShadowColor { get; set; }

        [JsonPropertyName("shadowOffsetX")]
        public int? ShadowOffsetX { get; set; }

        [JsonPropertyName("shadowOffsetY")]
        public int? ShadowOffsetY { get; set; }

        [JsonPropertyName("opacity")]
        public double? Opacity { get; set; }

        [JsonPropertyName("decal")]
        public object? Decal { get; set; }

        [JsonPropertyName("borderRadius")]
        public object? BorderRadius { get; set; }
    }

    public class LineStyle
    {
        [JsonPropertyName("color")]
        public object? Color { get; set; }

        [JsonPropertyName("width")]
        public int? Width { get; set; }

        [JsonPropertyName("type")]
        public object? Type { get; set; } // 'solid', 'dashed', 'dotted' or array

        [JsonPropertyName("dashOffset")]
        public int? DashOffset { get; set; }

        [JsonPropertyName("cap")]
        public string? Cap { get; set; }

        [JsonPropertyName("join")]
        public string? Join { get; set; }

        [JsonPropertyName("miterLimit")]
        public int? MiterLimit { get; set; }

        [JsonPropertyName("shadowBlur")]
        public int? ShadowBlur { get; set; }

        [JsonPropertyName("shadowColor")]
        public string? ShadowColor { get; set; }

        [JsonPropertyName("shadowOffsetX")]
        public int? ShadowOffsetX { get; set; }

        [JsonPropertyName("shadowOffsetY")]
        public int? ShadowOffsetY { get; set; }

        [JsonPropertyName("opacity")]
        public double? Opacity { get; set; }

        [JsonPropertyName("curveness")]
        public double? Curveness { get; set; }
    }

    public class AreaStyle
    {
        [JsonPropertyName("color")]
        public object? Color { get; set; }

        [JsonPropertyName("origin")]
        public string? Origin { get; set; }

        [JsonPropertyName("shadowBlur")]
        public int? ShadowBlur { get; set; }

        [JsonPropertyName("shadowColor")]
        public string? ShadowColor { get; set; }

        [JsonPropertyName("shadowOffsetX")]
        public int? ShadowOffsetX { get; set; }

        [JsonPropertyName("shadowOffsetY")]
        public int? ShadowOffsetY { get; set; }

        [JsonPropertyName("opacity")]
        public double? Opacity { get; set; }
    }

    public class Label
    {
        [JsonPropertyName("show")]
        public bool? Show { get; set; }

        [JsonPropertyName("position")]
        public object? Position { get; set; } // string or array

        [JsonPropertyName("distance")]
        public int? Distance { get; set; }

        [JsonPropertyName("rotate")]
        public int? Rotate { get; set; }

        [JsonPropertyName("offset")]
        public List<int>? Offset { get; set; }

        [JsonPropertyName("formatter")]
        public object? Formatter { get; set; }

        [JsonPropertyName("color")]
        public string? Color { get; set; }

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

    public class LabelLine
    {
        [JsonPropertyName("show")]
        public bool? Show { get; set; }

        [JsonPropertyName("showAbove")]
        public bool? ShowAbove { get; set; }

        [JsonPropertyName("length")]
        public int? Length { get; set; }

        [JsonPropertyName("length2")]
        public int? Length2 { get; set; }

        [JsonPropertyName("smooth")]
        public object? Smooth { get; set; } // bool or number

        [JsonPropertyName("minTurnAngle")]
        public int? MinTurnAngle { get; set; }

        [JsonPropertyName("lineStyle")]
        public LineStyle? LineStyle { get; set; }
    }

    public class Emphasis
    {
        [JsonPropertyName("disabled")]
        public bool? Disabled { get; set; }

        [JsonPropertyName("scale")]
        public object? Scale { get; set; } // bool or number

        [JsonPropertyName("focus")]
        public string? Focus { get; set; } // 'none', 'self', 'series'

        [JsonPropertyName("blurScope")]
        public string? BlurScope { get; set; } // 'coordinateSystem', 'series', 'global'

        [JsonPropertyName("label")]
        public Label? Label { get; set; }

        [JsonPropertyName("labelLine")]
        public LabelLine? LabelLine { get; set; }

        [JsonPropertyName("itemStyle")]
        public ItemStyle? ItemStyle { get; set; }

        [JsonPropertyName("lineStyle")]
        public LineStyle? LineStyle { get; set; }

        [JsonPropertyName("areaStyle")]
        public AreaStyle? AreaStyle { get; set; }

        [JsonPropertyName("endLabel")]
        public Label? EndLabel { get; set; }
    }

    public class Blur
    {
        [JsonPropertyName("label")]
        public Label? Label { get; set; }

        [JsonPropertyName("labelLine")]
        public LabelLine? LabelLine { get; set; }

        [JsonPropertyName("itemStyle")]
        public ItemStyle? ItemStyle { get; set; }

        [JsonPropertyName("lineStyle")]
        public LineStyle? LineStyle { get; set; }

        [JsonPropertyName("areaStyle")]
        public AreaStyle? AreaStyle { get; set; }

        [JsonPropertyName("endLabel")]
        public Label? EndLabel { get; set; }
    }

    public class Select
    {
        [JsonPropertyName("disabled")]
        public bool? Disabled { get; set; }

        [JsonPropertyName("label")]
        public Label? Label { get; set; }

        [JsonPropertyName("labelLine")]
        public LabelLine? LabelLine { get; set; }

        [JsonPropertyName("itemStyle")]
        public ItemStyle? ItemStyle { get; set; }

        [JsonPropertyName("lineStyle")]
        public LineStyle? LineStyle { get; set; }

        [JsonPropertyName("areaStyle")]
        public AreaStyle? AreaStyle { get; set; }

        [JsonPropertyName("endLabel")]
        public Label? EndLabel { get; set; }
    }

    public class MarkPoint
    {
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

        [JsonPropertyName("silent")]
        public bool? Silent { get; set; }

        [JsonPropertyName("label")]
        public Label? Label { get; set; }

        [JsonPropertyName("itemStyle")]
        public ItemStyle? ItemStyle { get; set; }

        [JsonPropertyName("emphasis")]
        public Emphasis? Emphasis { get; set; }

        [JsonPropertyName("blur")]
        public Blur? Blur { get; set; }

        [JsonPropertyName("data")]
        public List<MarkPointData>? Data { get; set; }

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
    }

    public class MarkPointData
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; } // 'min', 'max', 'average'

        [JsonPropertyName("valueIndex")]
        public int? ValueIndex { get; set; }

        [JsonPropertyName("valueDim")]
        public string? ValueDim { get; set; }

        [JsonPropertyName("coord")]
        public List<object>? Coord { get; set; }

        [JsonPropertyName("x")]
        public object? X { get; set; }

        [JsonPropertyName("y")]
        public object? Y { get; set; }

        [JsonPropertyName("value")]
        public object? Value { get; set; }

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

        [JsonPropertyName("itemStyle")]
        public ItemStyle? ItemStyle { get; set; }

        [JsonPropertyName("label")]
        public Label? Label { get; set; }

        [JsonPropertyName("emphasis")]
        public Emphasis? Emphasis { get; set; }

        [JsonPropertyName("blur")]
        public Blur? Blur { get; set; }
    }

    public class MarkLine
    {
        [JsonPropertyName("silent")]
        public bool? Silent { get; set; }

        [JsonPropertyName("symbol")]
        public object? Symbol { get; set; } // string or array

        [JsonPropertyName("symbolSize")]
        public object? SymbolSize { get; set; }

        [JsonPropertyName("precision")]
        public int? Precision { get; set; }

        [JsonPropertyName("label")]
        public Label? Label { get; set; }

        [JsonPropertyName("lineStyle")]
        public LineStyle? LineStyle { get; set; }

        [JsonPropertyName("emphasis")]
        public Emphasis? Emphasis { get; set; }

        [JsonPropertyName("blur")]
        public Blur? Blur { get; set; }

        [JsonPropertyName("data")]
        public List<object>? Data { get; set; }

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
    }

    public class MarkArea
    {
        [JsonPropertyName("silent")]
        public bool? Silent { get; set; }

        [JsonPropertyName("label")]
        public Label? Label { get; set; }

        [JsonPropertyName("itemStyle")]
        public ItemStyle? ItemStyle { get; set; }

        [JsonPropertyName("emphasis")]
        public Emphasis? Emphasis { get; set; }

        [JsonPropertyName("blur")]
        public Blur? Blur { get; set; }

        [JsonPropertyName("data")]
        public List<List<object>>? Data { get; set; }

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
    }
}