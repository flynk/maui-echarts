using System.Text.Json.Serialization;

namespace Flynk.Apps.Maui.ECharts.Options
{
    /// <summary>
    /// Toolbox component for chart interaction tools
    /// </summary>
    public class Toolbox
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("show")]
        public bool? Show { get; set; } = true;

        [JsonPropertyName("orient")]
        public string? Orient { get; set; } // 'horizontal', 'vertical'

        [JsonPropertyName("itemSize")]
        public int? ItemSize { get; set; }

        [JsonPropertyName("itemGap")]
        public int? ItemGap { get; set; }

        [JsonPropertyName("showTitle")]
        public bool? ShowTitle { get; set; }

        [JsonPropertyName("feature")]
        public ToolboxFeature? Feature { get; set; }

        [JsonPropertyName("iconStyle")]
        public object? IconStyle { get; set; }

        [JsonPropertyName("emphasis")]
        public object? Emphasis { get; set; }

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

        [JsonPropertyName("zlevel")]
        public int? ZLevel { get; set; }

        [JsonPropertyName("z")]
        public int? Z { get; set; }

        [JsonPropertyName("tooltip")]
        public object? Tooltip { get; set; }

        public static Toolbox Default() => new Toolbox
        {
            Show = true,
            Feature = ToolboxFeature.Default()
        };

        public static Toolbox WithFeatures(params string[] features) => new Toolbox
        {
            Show = true,
            Feature = ToolboxFeature.WithFeatures(features)
        };

        public Toolbox SetPosition(object left, object top)
        {
            Left = left;
            Top = top;
            return this;
        }

        public Toolbox SetOrientation(string orient)
        {
            Orient = orient;
            return this;
        }
    }

    /// <summary>
    /// Toolbox features configuration
    /// </summary>
    public class ToolboxFeature
    {
        [JsonPropertyName("saveAsImage")]
        public ToolboxSaveAsImage? SaveAsImage { get; set; }

        [JsonPropertyName("restore")]
        public ToolboxRestore? Restore { get; set; }

        [JsonPropertyName("dataView")]
        public ToolboxDataView? DataView { get; set; }

        [JsonPropertyName("dataZoom")]
        public ToolboxDataZoom? DataZoom { get; set; }

        [JsonPropertyName("magicType")]
        public ToolboxMagicType? MagicType { get; set; }

        [JsonPropertyName("brush")]
        public ToolboxBrush? Brush { get; set; }

        [JsonPropertyName("myTool")]
        public Dictionary<string, object>? MyTool { get; set; }

        public static ToolboxFeature Default() => new ToolboxFeature
        {
            SaveAsImage = new ToolboxSaveAsImage { Show = true },
            Restore = new ToolboxRestore { Show = true },
            DataZoom = new ToolboxDataZoom { Show = true }
        };

        public static ToolboxFeature WithFeatures(params string[] features)
        {
            var feature = new ToolboxFeature();

            foreach (var f in features)
            {
                switch (f.ToLower())
                {
                    case "saveasimage":
                        feature.SaveAsImage = new ToolboxSaveAsImage { Show = true };
                        break;
                    case "restore":
                        feature.Restore = new ToolboxRestore { Show = true };
                        break;
                    case "dataview":
                        feature.DataView = new ToolboxDataView { Show = true };
                        break;
                    case "datazoom":
                        feature.DataZoom = new ToolboxDataZoom { Show = true };
                        break;
                    case "magictype":
                        feature.MagicType = new ToolboxMagicType { Show = true, Type = new[] { "line", "bar" } };
                        break;
                    case "brush":
                        feature.Brush = new ToolboxBrush { Show = true };
                        break;
                }
            }

            return feature;
        }
    }

    /// <summary>
    /// Save as image tool
    /// </summary>
    public class ToolboxSaveAsImage
    {
        [JsonPropertyName("show")]
        public bool? Show { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; } // 'png', 'jpeg'

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("backgroundColor")]
        public string? BackgroundColor { get; set; }

        [JsonPropertyName("connectedBackgroundColor")]
        public string? ConnectedBackgroundColor { get; set; }

        [JsonPropertyName("excludeComponents")]
        public List<string>? ExcludeComponents { get; set; }

        [JsonPropertyName("pixelRatio")]
        public double? PixelRatio { get; set; }

        [JsonPropertyName("lang")]
        public List<string>? Lang { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("icon")]
        public string? Icon { get; set; }

        [JsonPropertyName("iconStyle")]
        public object? IconStyle { get; set; }

        [JsonPropertyName("emphasis")]
        public object? Emphasis { get; set; }
    }

    /// <summary>
    /// Restore tool
    /// </summary>
    public class ToolboxRestore
    {
        [JsonPropertyName("show")]
        public bool? Show { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("icon")]
        public string? Icon { get; set; }

        [JsonPropertyName("iconStyle")]
        public object? IconStyle { get; set; }

        [JsonPropertyName("emphasis")]
        public object? Emphasis { get; set; }
    }

    /// <summary>
    /// Data view tool
    /// </summary>
    public class ToolboxDataView
    {
        [JsonPropertyName("show")]
        public bool? Show { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("icon")]
        public string? Icon { get; set; }

        [JsonPropertyName("iconStyle")]
        public object? IconStyle { get; set; }

        [JsonPropertyName("emphasis")]
        public object? Emphasis { get; set; }

        [JsonPropertyName("readOnly")]
        public bool? ReadOnly { get; set; }

        [JsonPropertyName("optionToContent")]
        public object? OptionToContent { get; set; } // function

        [JsonPropertyName("contentToOption")]
        public object? ContentToOption { get; set; } // function

        [JsonPropertyName("lang")]
        public List<string>? Lang { get; set; }

        [JsonPropertyName("backgroundColor")]
        public string? BackgroundColor { get; set; }

        [JsonPropertyName("textareaColor")]
        public string? TextareaColor { get; set; }

        [JsonPropertyName("textareaBorderColor")]
        public string? TextareaBorderColor { get; set; }

        [JsonPropertyName("textColor")]
        public string? TextColor { get; set; }

        [JsonPropertyName("buttonColor")]
        public string? ButtonColor { get; set; }

        [JsonPropertyName("buttonTextColor")]
        public string? ButtonTextColor { get; set; }
    }

    /// <summary>
    /// Data zoom tool
    /// </summary>
    public class ToolboxDataZoom
    {
        [JsonPropertyName("show")]
        public bool? Show { get; set; }

        [JsonPropertyName("title")]
        public object? Title { get; set; } // object with zoom and back

        [JsonPropertyName("icon")]
        public object? Icon { get; set; } // object with zoom and back

        [JsonPropertyName("iconStyle")]
        public object? IconStyle { get; set; }

        [JsonPropertyName("emphasis")]
        public object? Emphasis { get; set; }

        [JsonPropertyName("xAxisIndex")]
        public object? XAxisIndex { get; set; } // number, array, bool

        [JsonPropertyName("yAxisIndex")]
        public object? YAxisIndex { get; set; }

        [JsonPropertyName("filterMode")]
        public string? FilterMode { get; set; } // 'filter', 'weakFilter', 'empty', 'none'

        [JsonPropertyName("brushStyle")]
        public object? BrushStyle { get; set; }
    }

    /// <summary>
    /// Magic type tool (switch chart types)
    /// </summary>
    public class ToolboxMagicType
    {
        [JsonPropertyName("show")]
        public bool? Show { get; set; }

        [JsonPropertyName("type")]
        public string[]? Type { get; set; } // 'line', 'bar', 'stack', 'tiled'

        [JsonPropertyName("title")]
        public object? Title { get; set; } // object with type names as keys

        [JsonPropertyName("icon")]
        public object? Icon { get; set; }

        [JsonPropertyName("iconStyle")]
        public object? IconStyle { get; set; }

        [JsonPropertyName("emphasis")]
        public object? Emphasis { get; set; }

        [JsonPropertyName("option")]
        public object? Option { get; set; }

        [JsonPropertyName("seriesIndex")]
        public object? SeriesIndex { get; set; }
    }

    /// <summary>
    /// Brush tool
    /// </summary>
    public class ToolboxBrush
    {
        [JsonPropertyName("show")]
        public bool? Show { get; set; }

        [JsonPropertyName("type")]
        public string[]? Type { get; set; } // 'rect', 'polygon', 'lineX', 'lineY', 'keep', 'clear'

        [JsonPropertyName("icon")]
        public object? Icon { get; set; }

        [JsonPropertyName("title")]
        public object? Title { get; set; }

        [JsonPropertyName("iconStyle")]
        public object? IconStyle { get; set; }

        [JsonPropertyName("emphasis")]
        public object? Emphasis { get; set; }
    }
}