using System.Text.Json.Serialization;

namespace Flynk.Apps.Maui.ECharts.Options
{
    /// <summary>
    /// Tooltip component for displaying information on hover
    /// </summary>
    public class Tooltip
    {
        [JsonPropertyName("show")]
        public bool? Show { get; set; } = true;

        [JsonPropertyName("showContent")]
        public bool? ShowContent { get; set; }

        [JsonPropertyName("trigger")]
        public string? Trigger { get; set; } // 'item', 'axis', 'none'

        [JsonPropertyName("triggerOn")]
        public string? TriggerOn { get; set; } // 'mousemove', 'click', 'mousemove|click', 'none'

        [JsonPropertyName("alwaysShowContent")]
        public bool? AlwaysShowContent { get; set; }

        [JsonPropertyName("displayMode")]
        public string? DisplayMode { get; set; } // 'single', 'multipleByCoordSys'

        [JsonPropertyName("renderMode")]
        public string? RenderMode { get; set; } // 'html', 'richText'

        [JsonPropertyName("showDelay")]
        public int? ShowDelay { get; set; }

        [JsonPropertyName("hideDelay")]
        public int? HideDelay { get; set; }

        [JsonPropertyName("enterable")]
        public bool? Enterable { get; set; }

        [JsonPropertyName("confine")]
        public bool? Confine { get; set; }

        [JsonPropertyName("appendToBody")]
        public bool? AppendToBody { get; set; }

        [JsonPropertyName("className")]
        public string? ClassName { get; set; }

        [JsonPropertyName("transitionDuration")]
        public double? TransitionDuration { get; set; }

        [JsonPropertyName("position")]
        public object? Position { get; set; } // array, string, or function

        [JsonPropertyName("formatter")]
        public object? Formatter { get; set; } // string or function

        [JsonPropertyName("valueFormatter")]
        public object? ValueFormatter { get; set; } // function

        [JsonPropertyName("backgroundColor")]
        public object? BackgroundColor { get; set; }

        [JsonPropertyName("borderColor")]
        public string? BorderColor { get; set; }

        [JsonPropertyName("borderWidth")]
        public int? BorderWidth { get; set; }

        [JsonPropertyName("padding")]
        public object? Padding { get; set; }

        [JsonPropertyName("textStyle")]
        public TextStyle? TextStyle { get; set; }

        [JsonPropertyName("extraCssText")]
        public string? ExtraCssText { get; set; }

        [JsonPropertyName("order")]
        public string? Order { get; set; } // 'seriesAsc', 'seriesDesc', 'valueAsc', 'valueDesc'

        [JsonPropertyName("axisPointer")]
        public AxisPointer? AxisPointer { get; set; }

        public static Tooltip Default() => new Tooltip { Trigger = "item" };

        public static Tooltip Axis() => new Tooltip { Trigger = "axis" };

        public static Tooltip Custom(string formatter) => new Tooltip
        {
            Trigger = "item",
            Formatter = formatter
        };

        public Tooltip SetTrigger(string trigger)
        {
            Trigger = trigger;
            return this;
        }

        public Tooltip SetFormatter(string formatter)
        {
            Formatter = formatter;
            return this;
        }

        public Tooltip SetPosition(object position)
        {
            Position = position;
            return this;
        }

        public Tooltip SetBackgroundColor(string color)
        {
            BackgroundColor = color;
            return this;
        }
    }

    /// <summary>
    /// Axis pointer for tooltip
    /// </summary>
    public class AxisPointer
    {
        [JsonPropertyName("show")]
        public bool? Show { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; } // 'line', 'shadow', 'none', 'cross'

        [JsonPropertyName("snap")]
        public bool? Snap { get; set; }

        [JsonPropertyName("z")]
        public int? Z { get; set; }

        [JsonPropertyName("label")]
        public Label? Label { get; set; }

        [JsonPropertyName("lineStyle")]
        public LineStyle? LineStyle { get; set; }

        [JsonPropertyName("shadowStyle")]
        public object? ShadowStyle { get; set; }

        [JsonPropertyName("crossStyle")]
        public object? CrossStyle { get; set; }

        [JsonPropertyName("animation")]
        public object? Animation { get; set; }

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

        public static AxisPointer Line() => new AxisPointer { Type = "line" };
        public static AxisPointer Shadow() => new AxisPointer { Type = "shadow" };
        public static AxisPointer Cross() => new AxisPointer { Type = "cross" };
        public static AxisPointer None() => new AxisPointer { Type = "none" };
    }
}