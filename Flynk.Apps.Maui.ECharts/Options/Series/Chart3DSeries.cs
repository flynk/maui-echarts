using System.Text.Json.Serialization;

namespace Flynk.Apps.Maui.ECharts.Options.Series
{
    /// <summary>
    /// Base class for 3D series
    /// </summary>
    public abstract class Series3DBase : SeriesBase
    {
        [JsonPropertyName("grid3DIndex")]
        public int? Grid3DIndex { get; set; }

        [JsonPropertyName("geo3DIndex")]
        public int? Geo3DIndex { get; set; }

        [JsonPropertyName("globeIndex")]
        public int? GlobeIndex { get; set; }

        [JsonPropertyName("shading")]
        public string? Shading { get; set; } // 'color', 'lambert', 'realistic'

        [JsonPropertyName("realisticMaterial")]
        public object? RealisticMaterial { get; set; }

        [JsonPropertyName("lambertMaterial")]
        public object? LambertMaterial { get; set; }

        [JsonPropertyName("colorMaterial")]
        public object? ColorMaterial { get; set; }

        [JsonPropertyName("light")]
        public object? Light { get; set; }

        [JsonPropertyName("postEffect")]
        public object? PostEffect { get; set; }

        [JsonPropertyName("temporalSuperSampling")]
        public object? TemporalSuperSampling { get; set; }

        [JsonPropertyName("viewControl")]
        public object? ViewControl { get; set; }

        public override string CoordinateSystem { get; set; } = "cartesian3D";
    }

    /// <summary>
    /// 3D Scatter chart series
    /// </summary>
    public class Scatter3DSeries : Series3DBase
    {
        public override string Type => "scatter3D";

        [JsonPropertyName("symbol")]
        public object? Symbol { get; set; }

        [JsonPropertyName("symbolSize")]
        public object? SymbolSize { get; set; }

        [JsonPropertyName("itemStyle")]
        public new ItemStyle? ItemStyle { get; set; }

        public static Scatter3DSeries Create(string name, params double[][] data)
        {
            var items = data.Select(d => d.Cast<object>().ToList()).Cast<object>().ToList();
            return new Scatter3DSeries { Name = name, Data = items };
        }

        public static Scatter3DSeries Create(string name, List<(double x, double y, double z)> points)
        {
            var items = points.Select(p => new List<object> { p.x, p.y, p.z }).Cast<object>().ToList();
            return new Scatter3DSeries { Name = name, Data = items };
        }
    }

    /// <summary>
    /// 3D Line chart series
    /// </summary>
    public class Line3DSeries : Series3DBase
    {
        public override string Type => "line3D";

        [JsonPropertyName("lineStyle")]
        public new LineStyle? LineStyle { get; set; }

        public static Line3DSeries Create(string name, params double[][] data)
        {
            var items = data.Select(d => d.Cast<object>().ToList()).Cast<object>().ToList();
            return new Line3DSeries { Name = name, Data = items };
        }

        public static Line3DSeries Create(string name, List<(double x, double y, double z)> points)
        {
            var items = points.Select(p => new List<object> { p.x, p.y, p.z }).Cast<object>().ToList();
            return new Line3DSeries { Name = name, Data = items };
        }
    }

    /// <summary>
    /// 3D Bar chart series
    /// </summary>
    public class Bar3DSeries : Series3DBase
    {
        public override string Type => "bar3D";

        [JsonPropertyName("bevelSize")]
        public double? BevelSize { get; set; }

        [JsonPropertyName("bevelSmoothness")]
        public int? BevelSmoothness { get; set; }

        [JsonPropertyName("minHeight")]
        public double? MinHeight { get; set; }

        public static Bar3DSeries Create(string name, params double[][] data)
        {
            var items = data.Select(d => d.Cast<object>().ToList()).Cast<object>().ToList();
            return new Bar3DSeries { Name = name, Data = items };
        }

        public static Bar3DSeries Create(string name, List<(double x, double y, double value)> data)
        {
            var items = data.Select(d => new List<object> { d.x, d.y, d.value }).Cast<object>().ToList();
            return new Bar3DSeries { Name = name, Data = items };
        }
    }

    /// <summary>
    /// 3D Surface chart series
    /// </summary>
    public class SurfaceSeries : Series3DBase
    {
        public override string Type => "surface";

        [JsonPropertyName("parametric")]
        public bool? Parametric { get; set; }

        [JsonPropertyName("wireframe")]
        public object? Wireframe { get; set; }

        [JsonPropertyName("equation")]
        public object? Equation { get; set; }

        [JsonPropertyName("parametricEquation")]
        public object? ParametricEquation { get; set; }

        public static SurfaceSeries Create(string name, double[][] data)
        {
            return new SurfaceSeries { Name = name, Data = new List<object> { data } };
        }

        public static SurfaceSeries CreateParametric(string name, object parametricEquation)
        {
            return new SurfaceSeries
            {
                Name = name,
                Parametric = true,
                ParametricEquation = parametricEquation
            };
        }

        public SurfaceSeries SetWireframe(bool show = true, LineStyle? lineStyle = null)
        {
            Wireframe = new { show = show, lineStyle = lineStyle };
            return this;
        }
    }

    /// <summary>
    /// 3D Map chart series (for geographic data)
    /// </summary>
    public class Map3DSeries : Series3DBase
    {
        public override string Type => "map3D";

        [JsonPropertyName("map")]
        public string? Map { get; set; }

        [JsonPropertyName("boxHeight")]
        public double? BoxHeight { get; set; }

        [JsonPropertyName("boxDepth")]
        public double? BoxDepth { get; set; }

        [JsonPropertyName("regionHeight")]
        public double? RegionHeight { get; set; }

        [JsonPropertyName("environment")]
        public object? Environment { get; set; }

        [JsonPropertyName("groundPlane")]
        public object? GroundPlane { get; set; }

        [JsonPropertyName("instancing")]
        public bool? Instancing { get; set; }

        public override string CoordinateSystem { get; set; } = "geo3D";

        public static Map3DSeries Create(string name, string mapName, params DataItem[] data)
        {
            return new Map3DSeries
            {
                Name = name,
                Map = mapName,
                Data = data.Cast<object>().ToList()
            };
        }
    }

    /// <summary>
    /// Globe chart series (for world map data)
    /// </summary>
    public class ScatterGLSeries : SeriesBase
    {
        public override string Type => "scatterGL";

        [JsonPropertyName("symbol")]
        public object? Symbol { get; set; }

        [JsonPropertyName("symbolSize")]
        public object? SymbolSize { get; set; }

        [JsonPropertyName("blendMode")]
        public string? BlendMode { get; set; }

        [JsonPropertyName("large")]
        public bool? Large { get; set; }

        [JsonPropertyName("largeThreshold")]
        public int? LargeThreshold { get; set; }

        [JsonPropertyName("progressive")]
        public int? Progressive { get; set; }

        [JsonPropertyName("progressiveThreshold")]
        public int? ProgressiveThreshold { get; set; }

        public override string CoordinateSystem { get; set; } = "cartesian2d";

        public static ScatterGLSeries Create(string name, params double[][] data)
        {
            var items = data.Select(d => d.Cast<object>().ToList()).Cast<object>().ToList();
            return new ScatterGLSeries { Name = name, Data = items };
        }

        public ScatterGLSeries SetLarge(bool large = true, int threshold = 2000)
        {
            Large = large;
            LargeThreshold = threshold;
            return this;
        }
    }

    /// <summary>
    /// GraphGL series for large graph/network visualization
    /// </summary>
    public class GraphGLSeries : SeriesBase
    {
        public override string Type => "graphGL";

        [JsonPropertyName("layout")]
        public string? Layout { get; set; } // 'forceAtlas2'

        [JsonPropertyName("forceAtlas2")]
        public object? ForceAtlas2 { get; set; }

        [JsonPropertyName("symbol")]
        public object? Symbol { get; set; }

        [JsonPropertyName("symbolSize")]
        public object? SymbolSize { get; set; }

        [JsonPropertyName("itemStyle")]
        public new ItemStyle? ItemStyle { get; set; }

        [JsonPropertyName("lineStyle")]
        public new LineStyle? LineStyle { get; set; }

        [JsonPropertyName("nodes")]
        public List<GraphDataItem>? Nodes { get; set; }

        [JsonPropertyName("links")]
        public List<GraphLinkItem>? Links { get; set; }

        [JsonPropertyName("edges")]
        public List<GraphLinkItem>? Edges { get; set; }

        public static GraphGLSeries Create(string name, List<GraphDataItem> nodes, List<GraphLinkItem> links)
        {
            return new GraphGLSeries
            {
                Name = name,
                Data = nodes.Cast<object>().ToList(),
                Links = links
            };
        }
    }

    /// <summary>
    /// FlowGL series for flow field visualization
    /// </summary>
    public class FlowGLSeries : SeriesBase
    {
        public override string Type => "flowGL";

        [JsonPropertyName("particleDensity")]
        public int? ParticleDensity { get; set; }

        [JsonPropertyName("particleType")]
        public string? ParticleType { get; set; } // 'point', 'line'

        [JsonPropertyName("particleSize")]
        public double? ParticleSize { get; set; }

        [JsonPropertyName("particleSpeed")]
        public double? ParticleSpeed { get; set; }

        [JsonPropertyName("particleTrail")]
        public double? ParticleTrail { get; set; }

        [JsonPropertyName("supersampling")]
        public int? Supersampling { get; set; }

        [JsonPropertyName("gridWidth")]
        public int? GridWidth { get; set; }

        [JsonPropertyName("gridHeight")]
        public int? GridHeight { get; set; }

        public static FlowGLSeries Create(string name, double[][] vectorField)
        {
            return new FlowGLSeries { Name = name, Data = new List<object> { vectorField } };
        }
    }

    /// <summary>
    /// LinesGL series for large-scale line visualization
    /// </summary>
    public class LinesGLSeries : SeriesBase
    {
        public override string Type => "linesGL";

        [JsonPropertyName("effect")]
        public object? Effect { get; set; }

        [JsonPropertyName("lineStyle")]
        public new LineStyle? LineStyle { get; set; }

        [JsonPropertyName("blendMode")]
        public string? BlendMode { get; set; }

        [JsonPropertyName("polyline")]
        public bool? Polyline { get; set; }

        public static LinesGLSeries Create(string name, params double[][][] data)
        {
            var items = data.Select(line =>
                line.Select(point => point.Cast<object>().ToList()).ToList()
            ).Cast<object>().ToList();
            return new LinesGLSeries { Name = name, Data = items };
        }

        public LinesGLSeries SetEffect(bool enabled = true, double trailLength = 0.2)
        {
            Effect = new { show = enabled, trailLength = trailLength };
            return this;
        }
    }
}