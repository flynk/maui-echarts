using System.Text.Json.Serialization;

namespace Flynk.Apps.Maui.ECharts.Options
{
    /// <summary>
    /// Base position class for flexible positioning
    /// </summary>
    public class Position
    {
        [JsonPropertyName("left")]
        public object? Left { get; set; } // string, number, or percentage

        [JsonPropertyName("top")]
        public object? Top { get; set; } // string, number, or percentage

        [JsonPropertyName("right")]
        public object? Right { get; set; } // string, number, or percentage

        [JsonPropertyName("bottom")]
        public object? Bottom { get; set; } // string, number, or percentage

        [JsonPropertyName("width")]
        public object? Width { get; set; } // string, number, or percentage

        [JsonPropertyName("height")]
        public object? Height { get; set; } // string, number, or percentage

        public static Position From(string left, string top) => new Position { Left = left, Top = top };
        public static Position From(double left, double top) => new Position { Left = left, Top = top };
        public static Position Center() => new Position { Left = "center", Top = "center" };
    }

    /// <summary>
    /// Color definition supporting multiple formats
    /// </summary>
    public class Color
    {
        private readonly object _value;

        private Color(object value) => _value = value;

        public static implicit operator Color(string color) => new Color(color);

        public static Color Hex(string hexColor) => new Color(hexColor);
        public static Color Rgb(int r, int g, int b) => new Color($"rgb({r},{g},{b})");
        public static Color Rgba(int r, int g, int b, double a) => new Color($"rgba({r},{g},{b},{a})");
        public static Color Hsl(int h, int s, int l) => new Color($"hsl({h},{s}%,{l}%)");
        public static Color Hsla(int h, int s, int l, double a) => new Color($"hsla({h},{s}%,{l}%,{a})");

        public static Color LinearGradient(double x1, double y1, double x2, double y2, params ColorStop[] colorStops)
        {
            return new Color(new
            {
                type = "linear",
                x = x1,
                y = y1,
                x2 = x2,
                y2 = y2,
                colorStops = colorStops.Select(cs => new { offset = cs.Offset, color = cs.Color }).ToArray()
            });
        }

        public static Color RadialGradient(double x, double y, double r, params ColorStop[] colorStops)
        {
            return new Color(new
            {
                type = "radial",
                x = x,
                y = y,
                r = r,
                colorStops = colorStops.Select(cs => new { offset = cs.Offset, color = cs.Color }).ToArray()
            });
        }

        public object GetValue() => _value;
    }

    /// <summary>
    /// Color stop for gradients
    /// </summary>
    public class ColorStop
    {
        public double Offset { get; set; }
        public string Color { get; set; } = string.Empty;

        public ColorStop(double offset, string color)
        {
            Offset = offset;
            Color = color;
        }
    }

    /// <summary>
    /// Text style definition
    /// </summary>
    public class TextStyle
    {
        [JsonPropertyName("color")]
        public string? Color { get; set; }

        [JsonPropertyName("fontStyle")]
        public string? FontStyle { get; set; } // 'normal', 'italic', 'oblique'

        [JsonPropertyName("fontWeight")]
        public object? FontWeight { get; set; } // 'normal', 'bold', 'bolder', 'lighter', or number

        [JsonPropertyName("fontFamily")]
        public string? FontFamily { get; set; }

        [JsonPropertyName("fontSize")]
        public int? FontSize { get; set; }

        [JsonPropertyName("lineHeight")]
        public int? LineHeight { get; set; }

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
        public string? Overflow { get; set; } // 'truncate', 'break', 'breakAll'

        [JsonPropertyName("ellipsis")]
        public string? Ellipsis { get; set; }

        [JsonPropertyName("rich")]
        public Dictionary<string, TextStyle>? Rich { get; set; }
    }

    /// <summary>
    /// Animation configuration
    /// </summary>
    public class Animation
    {
        [JsonPropertyName("animation")]
        public bool? Enabled { get; set; }

        [JsonPropertyName("animationThreshold")]
        public int? Threshold { get; set; }

        [JsonPropertyName("animationDuration")]
        public object? Duration { get; set; } // number or function

        [JsonPropertyName("animationEasing")]
        public string? Easing { get; set; }

        [JsonPropertyName("animationDelay")]
        public object? Delay { get; set; } // number or function

        [JsonPropertyName("animationDurationUpdate")]
        public object? DurationUpdate { get; set; }

        [JsonPropertyName("animationEasingUpdate")]
        public string? EasingUpdate { get; set; }

        [JsonPropertyName("animationDelayUpdate")]
        public object? DelayUpdate { get; set; }

        public static Animation Fast() => new Animation { Duration = 300, Easing = "cubicOut" };
        public static Animation Slow() => new Animation { Duration = 1000, Easing = "cubicInOut" };
        public static Animation None() => new Animation { Enabled = false };
    }

    /// <summary>
    /// Shadow configuration
    /// </summary>
    public class Shadow
    {
        [JsonPropertyName("shadowBlur")]
        public int? Blur { get; set; }

        [JsonPropertyName("shadowColor")]
        public string? Color { get; set; }

        [JsonPropertyName("shadowOffsetX")]
        public int? OffsetX { get; set; }

        [JsonPropertyName("shadowOffsetY")]
        public int? OffsetY { get; set; }

        public static Shadow Default() => new Shadow { Blur = 10, Color = "rgba(0,0,0,0.3)", OffsetX = 2, OffsetY = 2 };
    }

    /// <summary>
    /// Border configuration
    /// </summary>
    public class Border
    {
        [JsonPropertyName("borderColor")]
        public string? Color { get; set; }

        [JsonPropertyName("borderWidth")]
        public int? Width { get; set; }

        [JsonPropertyName("borderType")]
        public object? Type { get; set; } // 'solid', 'dashed', 'dotted', or array

        [JsonPropertyName("borderDashOffset")]
        public int? DashOffset { get; set; }

        [JsonPropertyName("borderCap")]
        public string? Cap { get; set; } // 'butt', 'round', 'square'

        [JsonPropertyName("borderJoin")]
        public string? Join { get; set; } // 'bevel', 'round', 'miter'

        [JsonPropertyName("borderMiterLimit")]
        public int? MiterLimit { get; set; }

        [JsonPropertyName("borderRadius")]
        public object? Radius { get; set; } // number or array

        public static Border Solid(string color, int width = 1) => new Border { Color = color, Width = width, Type = "solid" };
        public static Border Dashed(string color, int width = 1) => new Border { Color = color, Width = width, Type = "dashed" };
        public static Border Dotted(string color, int width = 1) => new Border { Color = color, Width = width, Type = "dotted" };
    }

    /// <summary>
    /// Padding configuration
    /// </summary>
    public class Padding
    {
        private readonly object _value;

        private Padding(object value) => _value = value;

        public static implicit operator Padding(int padding) => new Padding(padding);
        public static implicit operator Padding(int[] padding) => new Padding(padding);

        public static Padding All(int value) => new Padding(value);
        public static Padding Symmetric(int vertical, int horizontal) => new Padding(new[] { vertical, horizontal });
        public static Padding Custom(int top, int right, int bottom, int left) => new Padding(new[] { top, right, bottom, left });

        public object GetValue() => _value;
    }

    /// <summary>
    /// Symbol configuration for markers and points
    /// </summary>
    public class Symbol
    {
        public string Type { get; set; } = "circle";
        public object? Size { get; set; } // number or array [width, height]
        public int? Rotate { get; set; }
        public bool? KeepAspect { get; set; }
        public object? Offset { get; set; } // array [x, y]

        public static Symbol Circle(int size = 4) => new Symbol { Type = "circle", Size = size };
        public static Symbol Square(int size = 4) => new Symbol { Type = "rect", Size = size };
        public static Symbol Triangle(int size = 4) => new Symbol { Type = "triangle", Size = size };
        public static Symbol Diamond(int size = 4) => new Symbol { Type = "diamond", Size = size };
        public static Symbol Pin(int size = 4) => new Symbol { Type = "pin", Size = size };
        public static Symbol Arrow(int size = 4) => new Symbol { Type = "arrow", Size = size };
        public static Symbol None() => new Symbol { Type = "none" };

        public static Symbol Custom(string path, object? size = null) => new Symbol { Type = $"path://{path}", Size = size };
        public static Symbol Image(string url, object? size = null) => new Symbol { Type = $"image://{url}", Size = size };
    }

    /// <summary>
    /// Rich text configuration
    /// </summary>
    public class RichText : Dictionary<string, TextStyle>
    {
        public RichText AddStyle(string name, TextStyle style)
        {
            this[name] = style;
            return this;
        }
    }

    /// <summary>
    /// Data item with additional properties
    /// </summary>
    public class DataItem : Dictionary<string, object?>
    {
        [JsonPropertyName("name")]
        public string? Name
        {
            get => this.ContainsKey("name") ? this["name"] as string : null;
            set => this["name"] = value;
        }

        [JsonPropertyName("value")]
        public object? Value
        {
            get => this.ContainsKey("value") ? this["value"] : null;
            set => this["value"] = value;
        }

        [JsonPropertyName("itemStyle")]
        public ItemStyle? ItemStyle
        {
            get => this.ContainsKey("itemStyle") ? this["itemStyle"] as ItemStyle : null;
            set => this["itemStyle"] = value;
        }

        [JsonPropertyName("label")]
        public Label? Label
        {
            get => this.ContainsKey("label") ? this["label"] as Label : null;
            set => this["label"] = value;
        }

        public DataItem() { }

        public DataItem(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public DataItem SetProperty(string key, object? value)
        {
            this[key] = value;
            return this;
        }
    }
}