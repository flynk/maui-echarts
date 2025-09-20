using System.Text.Json.Serialization;

namespace Flynk.Apps.Maui.ECharts.Options
{
    public class Legend
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; } // 'plain' or 'scroll'

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("show")]
        public bool? Show { get; set; }

        [JsonPropertyName("zlevel")]
        public int? Zlevel { get; set; }

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

        [JsonPropertyName("orient")]
        public string? Orient { get; set; } // 'horizontal' or 'vertical'

        [JsonPropertyName("align")]
        public string? Align { get; set; } // 'auto', 'left', 'right'

        [JsonPropertyName("padding")]
        public object? Padding { get; set; }

        [JsonPropertyName("itemGap")]
        public int? ItemGap { get; set; }

        [JsonPropertyName("itemWidth")]
        public int? ItemWidth { get; set; }

        [JsonPropertyName("itemHeight")]
        public int? ItemHeight { get; set; }

        [JsonPropertyName("itemStyle")]
        public ItemStyle? ItemStyle { get; set; }

        [JsonPropertyName("lineStyle")]
        public LineStyle? LineStyle { get; set; }

        [JsonPropertyName("symbolRotate")]
        public object? SymbolRotate { get; set; }

        [JsonPropertyName("formatter")]
        public object? Formatter { get; set; } // string or function

        [JsonPropertyName("selectedMode")]
        public object? SelectedMode { get; set; } // bool or 'single' or 'multiple'

        [JsonPropertyName("inactiveColor")]
        public string? InactiveColor { get; set; }

        [JsonPropertyName("inactiveBorderColor")]
        public string? InactiveBorderColor { get; set; }

        [JsonPropertyName("inactiveBorderWidth")]
        public object? InactiveBorderWidth { get; set; }

        [JsonPropertyName("selected")]
        public Dictionary<string, bool>? Selected { get; set; }

        [JsonPropertyName("textStyle")]
        public TextStyle? TextStyle { get; set; }

        [JsonPropertyName("tooltip")]
        public Tooltip? Tooltip { get; set; }

        [JsonPropertyName("data")]
        public List<object>? Data { get; set; }

        [JsonPropertyName("backgroundColor")]
        public string? BackgroundColor { get; set; }

        [JsonPropertyName("borderColor")]
        public string? BorderColor { get; set; }

        [JsonPropertyName("borderWidth")]
        public int? BorderWidth { get; set; }

        [JsonPropertyName("borderRadius")]
        public object? BorderRadius { get; set; }

        [JsonPropertyName("shadowBlur")]
        public int? ShadowBlur { get; set; }

        [JsonPropertyName("shadowColor")]
        public string? ShadowColor { get; set; }

        [JsonPropertyName("shadowOffsetX")]
        public int? ShadowOffsetX { get; set; }

        [JsonPropertyName("shadowOffsetY")]
        public int? ShadowOffsetY { get; set; }

        [JsonPropertyName("scrollDataIndex")]
        public int? ScrollDataIndex { get; set; }

        [JsonPropertyName("pageButtonItemGap")]
        public int? PageButtonItemGap { get; set; }

        [JsonPropertyName("pageButtonGap")]
        public int? PageButtonGap { get; set; }

        [JsonPropertyName("pageButtonPosition")]
        public string? PageButtonPosition { get; set; }

        [JsonPropertyName("pageFormatter")]
        public object? PageFormatter { get; set; }

        [JsonPropertyName("pageIcons")]
        public PageIcons? PageIcons { get; set; }

        [JsonPropertyName("pageIconColor")]
        public string? PageIconColor { get; set; }

        [JsonPropertyName("pageIconInactiveColor")]
        public string? PageIconInactiveColor { get; set; }

        [JsonPropertyName("pageIconSize")]
        public object? PageIconSize { get; set; }

        [JsonPropertyName("pageTextStyle")]
        public TextStyle? PageTextStyle { get; set; }

        [JsonPropertyName("animation")]
        public bool? Animation { get; set; }

        [JsonPropertyName("animationDurationUpdate")]
        public int? AnimationDurationUpdate { get; set; }

        [JsonPropertyName("emphasis")]
        public LegendEmphasis? Emphasis { get; set; }

        [JsonPropertyName("selector")]
        public object? Selector { get; set; }

        [JsonPropertyName("selectorLabel")]
        public SelectorLabel? SelectorLabel { get; set; }

        [JsonPropertyName("selectorPosition")]
        public string? SelectorPosition { get; set; }

        [JsonPropertyName("selectorItemGap")]
        public int? SelectorItemGap { get; set; }

        [JsonPropertyName("selectorButtonGap")]
        public int? SelectorButtonGap { get; set; }
    }

    public class LegendData
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("icon")]
        public string? Icon { get; set; }

        [JsonPropertyName("itemStyle")]
        public ItemStyle? ItemStyle { get; set; }

        [JsonPropertyName("lineStyle")]
        public LineStyle? LineStyle { get; set; }

        [JsonPropertyName("symbolRotate")]
        public object? SymbolRotate { get; set; }

        [JsonPropertyName("textStyle")]
        public TextStyle? TextStyle { get; set; }
    }

    public class PageIcons
    {
        [JsonPropertyName("horizontal")]
        public List<string>? Horizontal { get; set; }

        [JsonPropertyName("vertical")]
        public List<string>? Vertical { get; set; }
    }

    public class LegendEmphasis
    {
        [JsonPropertyName("selectorLabel")]
        public SelectorLabel? SelectorLabel { get; set; }
    }

    public class SelectorLabel
    {
        [JsonPropertyName("show")]
        public bool? Show { get; set; }

        [JsonPropertyName("distance")]
        public int? Distance { get; set; }

        [JsonPropertyName("rotate")]
        public int? Rotate { get; set; }

        [JsonPropertyName("offset")]
        public List<int>? Offset { get; set; }

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
        public string? BackgroundColor { get; set; }

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
}