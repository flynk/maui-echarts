using System.Text.Json.Serialization;

namespace Flynk.Apps.Maui.ECharts.Options
{
    /// <summary>
    /// Grid component for Cartesian coordinates
    /// </summary>
    public class Grid
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("show")]
        public bool? Show { get; set; }

        [JsonPropertyName("zlevel")]
        public int? ZLevel { get; set; }

        [JsonPropertyName("z")]
        public int? Z { get; set; }

        [JsonPropertyName("left")]
        public object? Left { get; set; } // string, number, or percentage

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

        [JsonPropertyName("containLabel")]
        public bool? ContainLabel { get; set; }

        [JsonPropertyName("backgroundColor")]
        public object? BackgroundColor { get; set; }

        [JsonPropertyName("borderColor")]
        public string? BorderColor { get; set; }

        [JsonPropertyName("borderWidth")]
        public int? BorderWidth { get; set; }

        [JsonPropertyName("shadowBlur")]
        public int? ShadowBlur { get; set; }

        [JsonPropertyName("shadowColor")]
        public string? ShadowColor { get; set; }

        [JsonPropertyName("shadowOffsetX")]
        public int? ShadowOffsetX { get; set; }

        [JsonPropertyName("shadowOffsetY")]
        public int? ShadowOffsetY { get; set; }

        [JsonPropertyName("tooltip")]
        public object? Tooltip { get; set; }

        public static Grid Default() => new Grid
        {
            Left = "10%",
            Right = "10%",
            Top = "15%",
            Bottom = "10%",
            ContainLabel = true
        };

        public static Grid FullSize() => new Grid
        {
            Left = 0,
            Right = 0,
            Top = 0,
            Bottom = 0,
            ContainLabel = true
        };

        public Grid SetPosition(object left, object top, object right, object bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
            return this;
        }

        public Grid SetContainLabel(bool containLabel = true)
        {
            ContainLabel = containLabel;
            return this;
        }

        public Grid SetBackgroundColor(object color)
        {
            BackgroundColor = color;
            return this;
        }
    }
}