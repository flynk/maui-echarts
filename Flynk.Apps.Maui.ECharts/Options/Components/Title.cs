using System.Text.Json.Serialization;

namespace Flynk.Apps.Maui.ECharts.Options
{
    public class Title
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("show")]
        public bool? Show { get; set; }

        [JsonPropertyName("text")]
        public string? Text { get; set; }

        [JsonPropertyName("link")]
        public string? Link { get; set; }

        [JsonPropertyName("target")]
        public string? Target { get; set; }

        [JsonPropertyName("textStyle")]
        public TextStyle? TextStyle { get; set; }

        [JsonPropertyName("subtext")]
        public string? Subtext { get; set; }

        [JsonPropertyName("sublink")]
        public string? SubLink { get; set; }

        [JsonPropertyName("subtarget")]
        public string? SubTarget { get; set; }

        [JsonPropertyName("subtextStyle")]
        public TextStyle? SubtextStyle { get; set; }

        [JsonPropertyName("textAlign")]
        public string? TextAlign { get; set; }

        [JsonPropertyName("textVerticalAlign")]
        public string? TextVerticalAlign { get; set; }

        [JsonPropertyName("triggerEvent")]
        public bool? TriggerEvent { get; set; }

        [JsonPropertyName("padding")]
        public object? Padding { get; set; } // can be number or array

        [JsonPropertyName("itemGap")]
        public int? ItemGap { get; set; }

        [JsonPropertyName("zlevel")]
        public int? Zlevel { get; set; }

        [JsonPropertyName("z")]
        public int? Z { get; set; }

        [JsonPropertyName("left")]
        public object? Left { get; set; } // can be string, number, or percentage

        [JsonPropertyName("top")]
        public object? Top { get; set; }

        [JsonPropertyName("right")]
        public object? Right { get; set; }

        [JsonPropertyName("bottom")]
        public object? Bottom { get; set; }

        [JsonPropertyName("backgroundColor")]
        public string? BackgroundColor { get; set; }

        [JsonPropertyName("borderColor")]
        public string? BorderColor { get; set; }

        [JsonPropertyName("borderWidth")]
        public int? BorderWidth { get; set; }

        [JsonPropertyName("borderRadius")]
        public object? BorderRadius { get; set; } // can be number or array

        [JsonPropertyName("shadowBlur")]
        public int? ShadowBlur { get; set; }

        [JsonPropertyName("shadowColor")]
        public string? ShadowColor { get; set; }

        [JsonPropertyName("shadowOffsetX")]
        public int? ShadowOffsetX { get; set; }

        [JsonPropertyName("shadowOffsetY")]
        public int? ShadowOffsetY { get; set; }
    }
}