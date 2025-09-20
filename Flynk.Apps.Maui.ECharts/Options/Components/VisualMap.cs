using System.Text.Json.Serialization;

namespace Flynk.Apps.Maui.ECharts.Options
{
    /// <summary>
    /// Base class for VisualMap components
    /// </summary>
    public abstract class VisualMap
    {
        [JsonPropertyName("type")]
        public abstract string Type { get; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("show")]
        public bool? Show { get; set; } = true;

        [JsonPropertyName("dimension")]
        public object? Dimension { get; set; } // number or string

        [JsonPropertyName("seriesIndex")]
        public object? SeriesIndex { get; set; } // number or array

        [JsonPropertyName("min")]
        public double? Min { get; set; }

        [JsonPropertyName("max")]
        public double? Max { get; set; }

        [JsonPropertyName("range")]
        public List<double>? Range { get; set; }

        [JsonPropertyName("calculable")]
        public bool? Calculable { get; set; }

        [JsonPropertyName("realtime")]
        public bool? Realtime { get; set; }

        [JsonPropertyName("inverse")]
        public bool? Inverse { get; set; }

        [JsonPropertyName("precision")]
        public int? Precision { get; set; }

        [JsonPropertyName("itemWidth")]
        public int? ItemWidth { get; set; }

        [JsonPropertyName("itemHeight")]
        public int? ItemHeight { get; set; }

        [JsonPropertyName("align")]
        public string? Align { get; set; } // 'auto', 'left', 'right'

        [JsonPropertyName("text")]
        public List<string>? Text { get; set; }

        [JsonPropertyName("textGap")]
        public object? TextGap { get; set; } // number or array

        [JsonPropertyName("showLabel")]
        public bool? ShowLabel { get; set; }

        [JsonPropertyName("itemGap")]
        public int? ItemGap { get; set; }

        [JsonPropertyName("itemSymbol")]
        public string? ItemSymbol { get; set; }

        [JsonPropertyName("orient")]
        public string? Orient { get; set; } // 'horizontal', 'vertical'

        [JsonPropertyName("backgroundColor")]
        public string? BackgroundColor { get; set; }

        [JsonPropertyName("borderColor")]
        public string? BorderColor { get; set; }

        [JsonPropertyName("borderWidth")]
        public int? BorderWidth { get; set; }

        [JsonPropertyName("color")]
        public object? Color { get; set; } // array or string

        [JsonPropertyName("textStyle")]
        public TextStyle? TextStyle { get; set; }

        [JsonPropertyName("formatter")]
        public object? Formatter { get; set; } // string or function

        [JsonPropertyName("left")]
        public object? Left { get; set; }

        [JsonPropertyName("top")]
        public object? Top { get; set; }

        [JsonPropertyName("right")]
        public object? Right { get; set; }

        [JsonPropertyName("bottom")]
        public object? Bottom { get; set; }

        [JsonPropertyName("zlevel")]
        public int? ZLevel { get; set; }

        [JsonPropertyName("z")]
        public int? Z { get; set; }

        [JsonPropertyName("inRange")]
        public object? InRange { get; set; }

        [JsonPropertyName("outOfRange")]
        public object? OutOfRange { get; set; }

        [JsonPropertyName("controller")]
        public object? Controller { get; set; }

        [JsonPropertyName("target")]
        public object? Target { get; set; }
    }

    /// <summary>
    /// Continuous visual map
    /// </summary>
    public class ContinuousVisualMap : VisualMap
    {
        public override string Type => "continuous";

        [JsonPropertyName("splitNumber")]
        public int? SplitNumber { get; set; }

        [JsonPropertyName("hoverLink")]
        public bool? HoverLink { get; set; }

        [JsonPropertyName("hoverLinkDataSize")]
        public int? HoverLinkDataSize { get; set; }

        [JsonPropertyName("hoverLinkOnHandle")]
        public bool? HoverLinkOnHandle { get; set; }

        [JsonPropertyName("handleIcon")]
        public string? HandleIcon { get; set; }

        [JsonPropertyName("handleSize")]
        public object? HandleSize { get; set; } // number or percentage

        [JsonPropertyName("handleStyle")]
        public object? HandleStyle { get; set; }

        [JsonPropertyName("indicatorIcon")]
        public string? IndicatorIcon { get; set; }

        [JsonPropertyName("indicatorSize")]
        public object? IndicatorSize { get; set; }

        [JsonPropertyName("indicatorStyle")]
        public object? IndicatorStyle { get; set; }

        public static ContinuousVisualMap Create(double min, double max, params string[] colors)
        {
            return new ContinuousVisualMap
            {
                Min = min,
                Max = max,
                Color = colors,
                Calculable = true,
                InRange = new { color = colors }
            };
        }

        public static ContinuousVisualMap ColorGradient(double min, double max, string startColor, string endColor)
        {
            return new ContinuousVisualMap
            {
                Min = min,
                Max = max,
                Color = new[] { startColor, endColor },
                Calculable = true,
                InRange = new { color = new[] { startColor, endColor } }
            };
        }

        public ContinuousVisualMap SetPosition(object left, object top)
        {
            Left = left;
            Top = top;
            return this;
        }

        public ContinuousVisualMap SetText(string maxText, string minText)
        {
            Text = new List<string> { maxText, minText };
            return this;
        }
    }

    /// <summary>
    /// Piecewise visual map
    /// </summary>
    public class PiecewiseVisualMap : VisualMap
    {
        public override string Type => "piecewise";

        [JsonPropertyName("splitNumber")]
        public int? SplitNumber { get; set; }

        [JsonPropertyName("pieces")]
        public List<object>? Pieces { get; set; }

        [JsonPropertyName("categories")]
        public List<object>? Categories { get; set; }

        [JsonPropertyName("minOpen")]
        public bool? MinOpen { get; set; }

        [JsonPropertyName("maxOpen")]
        public bool? MaxOpen { get; set; }

        [JsonPropertyName("selectedMode")]
        public object? SelectedMode { get; set; } // 'multiple', 'single', false

        [JsonPropertyName("selected")]
        public Dictionary<string, bool>? Selected { get; set; }

        [JsonPropertyName("showLabel")]
        public new bool? ShowLabel { get; set; }

        [JsonPropertyName("hoverLink")]
        public bool? HoverLink { get; set; }

        public static PiecewiseVisualMap Create(double min, double max, int splitNumber = 5, params string[] colors)
        {
            return new PiecewiseVisualMap
            {
                Min = min,
                Max = max,
                SplitNumber = splitNumber,
                Color = colors,
                InRange = new { color = colors }
            };
        }

        public static PiecewiseVisualMap CreateWithPieces(params (double min, double max, string color, string label)[] pieces)
        {
            var pieceList = pieces.Select(p => new
            {
                min = p.min,
                max = p.max,
                color = p.color,
                label = p.label
            }).Cast<object>().ToList();

            return new PiecewiseVisualMap
            {
                Pieces = pieceList
            };
        }

        public static PiecewiseVisualMap CreateWithCategories(params (string category, string color)[] categories)
        {
            var categoryList = categories.Select(c => new
            {
                value = c.category,
                color = c.color
            }).Cast<object>().ToList();

            return new PiecewiseVisualMap
            {
                Categories = categoryList
            };
        }

        public PiecewiseVisualMap SetSelectedMode(string mode)
        {
            SelectedMode = mode;
            return this;
        }

        public PiecewiseVisualMap SetSplitNumber(int splitNumber)
        {
            SplitNumber = splitNumber;
            return this;
        }
    }
}