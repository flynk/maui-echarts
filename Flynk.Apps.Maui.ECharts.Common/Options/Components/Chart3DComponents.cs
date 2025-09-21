using System.Text.Json.Serialization;

namespace Flynk.Apps.Maui.ECharts.Options
{
    /// <summary>
    /// Globe component for 3D earth visualization
    /// </summary>
    public class Globe
    {
        [JsonPropertyName("show")]
        public bool? Show { get; set; } = true;

        [JsonPropertyName("zlevel")]
        public int? ZLevel { get; set; }

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

        [JsonPropertyName("globeRadius")]
        public double? GlobeRadius { get; set; }

        [JsonPropertyName("globeOuterRadius")]
        public double? GlobeOuterRadius { get; set; }

        [JsonPropertyName("environment")]
        public object? Environment { get; set; } // string (texture) or '#000'

        [JsonPropertyName("baseTexture")]
        public string? BaseTexture { get; set; }

        [JsonPropertyName("heightTexture")]
        public string? HeightTexture { get; set; }

        [JsonPropertyName("displacementTexture")]
        public string? DisplacementTexture { get; set; }

        [JsonPropertyName("displacementScale")]
        public double? DisplacementScale { get; set; }

        [JsonPropertyName("displacementQuality")]
        public string? DisplacementQuality { get; set; } // 'low', 'medium', 'high', 'ultra'

        [JsonPropertyName("globeOuterRadius")]
        public new double? GlobeOuterRadius2 { get; set; }

        [JsonPropertyName("atmosphere")]
        public object? Atmosphere { get; set; }

        [JsonPropertyName("light")]
        public Light? Light { get; set; }

        [JsonPropertyName("realisticMaterial")]
        public RealisticMaterial? RealisticMaterial { get; set; }

        [JsonPropertyName("lambertMaterial")]
        public LambertMaterial? LambertMaterial { get; set; }

        [JsonPropertyName("colorMaterial")]
        public ColorMaterial? ColorMaterial { get; set; }

        [JsonPropertyName("shading")]
        public string? Shading { get; set; } // 'color', 'lambert', 'realistic'

        [JsonPropertyName("postEffect")]
        public PostEffect? PostEffect { get; set; }

        [JsonPropertyName("temporalSuperSampling")]
        public TemporalSuperSampling? TemporalSuperSampling { get; set; }

        [JsonPropertyName("viewControl")]
        public ViewControl? ViewControl { get; set; }

        [JsonPropertyName("layers")]
        public List<object>? Layers { get; set; }

        public static Globe Default() => new Globe
        {
            GlobeRadius = 100,
            Environment = "#000",
            Shading = "realistic"
        };

        public static Globe Earth() => new Globe
        {
            GlobeRadius = 100,
            BaseTexture = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wBDAAYEBQYFBAYGBQYHBwYIChAKCgkJChQODwwQFxQYGBcUFhYaHSUfGhsjHBYWICwgIyYnKSopGR8tMC0oMCUoKSj/2wBDAQcHBwoIChMKChMoGhYaKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCj/wAARCAABAAEDASIAAhEBAxEB/8QAFQABAQAAAAAAAAAAAAAAAAAAAAv/xAAUEAEAAAAAAAAAAAAAAAAAAAAA/8QAFQEBAQAAAAAAAAAAAAAAAAAAAAX/xAAUEQEAAAAAAAAAAAAAAAAAAAAA/9oADAMBAAIRAxEAPwCdABmX/9k=",
            Environment = "#000",
            Shading = "realistic"
        };
    }

    /// <summary>
    /// 3D geographic coordinate system
    /// </summary>
    public class Geo3D
    {
        [JsonPropertyName("show")]
        public bool? Show { get; set; } = true;

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

        [JsonPropertyName("label")]
        public Label? Label { get; set; }

        [JsonPropertyName("itemStyle")]
        public ItemStyle? ItemStyle { get; set; }

        [JsonPropertyName("emphasis")]
        public Emphasis? Emphasis { get; set; }

        [JsonPropertyName("light")]
        public Light? Light { get; set; }

        [JsonPropertyName("realisticMaterial")]
        public RealisticMaterial? RealisticMaterial { get; set; }

        [JsonPropertyName("lambertMaterial")]
        public LambertMaterial? LambertMaterial { get; set; }

        [JsonPropertyName("colorMaterial")]
        public ColorMaterial? ColorMaterial { get; set; }

        [JsonPropertyName("shading")]
        public string? Shading { get; set; }

        [JsonPropertyName("postEffect")]
        public PostEffect? PostEffect { get; set; }

        [JsonPropertyName("temporalSuperSampling")]
        public TemporalSuperSampling? TemporalSuperSampling { get; set; }

        [JsonPropertyName("viewControl")]
        public ViewControl? ViewControl { get; set; }

        [JsonPropertyName("zlevel")]
        public int? ZLevel { get; set; }

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

        public static Geo3D Create(string mapName) => new Geo3D
        {
            Map = mapName,
            BoxHeight = 10,
            RegionHeight = 3,
            Shading = "lambert"
        };
    }

    /// <summary>
    /// 3D grid component
    /// </summary>
    public class Grid3D
    {
        [JsonPropertyName("show")]
        public bool? Show { get; set; } = true;

        [JsonPropertyName("zlevel")]
        public int? ZLevel { get; set; }

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

        [JsonPropertyName("boxWidth")]
        public double? BoxWidth { get; set; }

        [JsonPropertyName("boxHeight")]
        public double? BoxHeight { get; set; }

        [JsonPropertyName("boxDepth")]
        public double? BoxDepth { get; set; }

        [JsonPropertyName("axisLine")]
        public AxisLine3D? AxisLine { get; set; }

        [JsonPropertyName("axisLabel")]
        public AxisLabel3D? AxisLabel { get; set; }

        [JsonPropertyName("axisTick")]
        public AxisTick3D? AxisTick { get; set; }

        [JsonPropertyName("splitLine")]
        public SplitLine3D? SplitLine { get; set; }

        [JsonPropertyName("splitArea")]
        public SplitArea3D? SplitArea { get; set; }

        [JsonPropertyName("axisPointer")]
        public AxisPointer3D? AxisPointer { get; set; }

        [JsonPropertyName("environment")]
        public object? Environment { get; set; }

        [JsonPropertyName("light")]
        public Light? Light { get; set; }

        [JsonPropertyName("postEffect")]
        public PostEffect? PostEffect { get; set; }

        [JsonPropertyName("temporalSuperSampling")]
        public TemporalSuperSampling? TemporalSuperSampling { get; set; }

        [JsonPropertyName("viewControl")]
        public ViewControl? ViewControl { get; set; }

        public static Grid3D Default() => new Grid3D
        {
            BoxWidth = 100,
            BoxHeight = 100,
            BoxDepth = 100,
            Environment = "auto"
        };
    }

    /// <summary>
    /// 3D axis line configuration
    /// </summary>
    public class AxisLine3D
    {
        [JsonPropertyName("show")]
        public bool? Show { get; set; }

        [JsonPropertyName("interval")]
        public object? Interval { get; set; }

        [JsonPropertyName("lineStyle")]
        public LineStyle? LineStyle { get; set; }
    }

    /// <summary>
    /// 3D axis label configuration
    /// </summary>
    public class AxisLabel3D
    {
        [JsonPropertyName("show")]
        public bool? Show { get; set; }

        [JsonPropertyName("interval")]
        public object? Interval { get; set; }

        [JsonPropertyName("margin")]
        public int? Margin { get; set; }

        [JsonPropertyName("formatter")]
        public object? Formatter { get; set; }

        [JsonPropertyName("textStyle")]
        public TextStyle? TextStyle { get; set; }
    }

    /// <summary>
    /// 3D axis tick configuration
    /// </summary>
    public class AxisTick3D
    {
        [JsonPropertyName("show")]
        public bool? Show { get; set; }

        [JsonPropertyName("interval")]
        public object? Interval { get; set; }

        [JsonPropertyName("length")]
        public int? Length { get; set; }

        [JsonPropertyName("lineStyle")]
        public LineStyle? LineStyle { get; set; }
    }

    /// <summary>
    /// 3D split line configuration
    /// </summary>
    public class SplitLine3D
    {
        [JsonPropertyName("show")]
        public bool? Show { get; set; }

        [JsonPropertyName("interval")]
        public object? Interval { get; set; }

        [JsonPropertyName("lineStyle")]
        public LineStyle? LineStyle { get; set; }
    }

    /// <summary>
    /// 3D split area configuration
    /// </summary>
    public class SplitArea3D
    {
        [JsonPropertyName("show")]
        public bool? Show { get; set; }

        [JsonPropertyName("interval")]
        public object? Interval { get; set; }

        [JsonPropertyName("areaStyle")]
        public AreaStyle? AreaStyle { get; set; }
    }

    /// <summary>
    /// 3D axis pointer configuration
    /// </summary>
    public class AxisPointer3D
    {
        [JsonPropertyName("show")]
        public bool? Show { get; set; }

        [JsonPropertyName("lineStyle")]
        public LineStyle? LineStyle { get; set; }

        [JsonPropertyName("label")]
        public Label? Label { get; set; }
    }

    /// <summary>
    /// Light configuration for 3D scenes
    /// </summary>
    public class Light
    {
        [JsonPropertyName("main")]
        public MainLight? Main { get; set; }

        [JsonPropertyName("ambient")]
        public AmbientLight? Ambient { get; set; }

        [JsonPropertyName("ambientCubemap")]
        public AmbientCubemap? AmbientCubemap { get; set; }

        public static Light Default() => new Light
        {
            Main = new MainLight
            {
                Color = "#fff",
                Intensity = 1.2,
                Shadow = true,
                Alpha = 40,
                Beta = 40
            },
            Ambient = new AmbientLight
            {
                Color = "#fff",
                Intensity = 0.2
            }
        };
    }

    /// <summary>
    /// Main directional light
    /// </summary>
    public class MainLight
    {
        [JsonPropertyName("color")]
        public string? Color { get; set; }

        [JsonPropertyName("intensity")]
        public double? Intensity { get; set; }

        [JsonPropertyName("shadow")]
        public bool? Shadow { get; set; }

        [JsonPropertyName("shadowQuality")]
        public string? ShadowQuality { get; set; } // 'low', 'medium', 'high', 'ultra'

        [JsonPropertyName("alpha")]
        public double? Alpha { get; set; }

        [JsonPropertyName("beta")]
        public double? Beta { get; set; }
    }

    /// <summary>
    /// Ambient light
    /// </summary>
    public class AmbientLight
    {
        [JsonPropertyName("color")]
        public string? Color { get; set; }

        [JsonPropertyName("intensity")]
        public double? Intensity { get; set; }
    }

    /// <summary>
    /// Ambient cubemap lighting
    /// </summary>
    public class AmbientCubemap
    {
        [JsonPropertyName("texture")]
        public string? Texture { get; set; }

        [JsonPropertyName("diffuseIntensity")]
        public double? DiffuseIntensity { get; set; }

        [JsonPropertyName("specularIntensity")]
        public double? SpecularIntensity { get; set; }
    }

    /// <summary>
    /// Realistic material properties
    /// </summary>
    public class RealisticMaterial
    {
        [JsonPropertyName("detailTexture")]
        public string? DetailTexture { get; set; }

        [JsonPropertyName("textureTiling")]
        public double? TextureTiling { get; set; }

        [JsonPropertyName("roughness")]
        public double? Roughness { get; set; }

        [JsonPropertyName("metalness")]
        public double? Metalness { get; set; }

        [JsonPropertyName("roughnessAdjust")]
        public double? RoughnessAdjust { get; set; }

        [JsonPropertyName("metalnessAdjust")]
        public double? MetalnessAdjust { get; set; }

        [JsonPropertyName("normalTexture")]
        public string? NormalTexture { get; set; }
    }

    /// <summary>
    /// Lambert material properties
    /// </summary>
    public class LambertMaterial
    {
        [JsonPropertyName("detailTexture")]
        public string? DetailTexture { get; set; }

        [JsonPropertyName("textureTiling")]
        public double? TextureTiling { get; set; }
    }

    /// <summary>
    /// Color material properties
    /// </summary>
    public class ColorMaterial
    {
        [JsonPropertyName("detailTexture")]
        public string? DetailTexture { get; set; }

        [JsonPropertyName("textureTiling")]
        public double? TextureTiling { get; set; }
    }

    /// <summary>
    /// Post-processing effects
    /// </summary>
    public class PostEffect
    {
        [JsonPropertyName("enable")]
        public bool? Enable { get; set; }

        [JsonPropertyName("bloom")]
        public Bloom? Bloom { get; set; }

        [JsonPropertyName("depthOfField")]
        public DepthOfField? DepthOfField { get; set; }

        [JsonPropertyName("screenSpaceAmbientOcclusion")]
        public SSAO? ScreenSpaceAmbientOcclusion { get; set; }

        [JsonPropertyName("SSAO")]
        public SSAO? SSAO { get; set; }

        [JsonPropertyName("colorCorrection")]
        public ColorCorrection? ColorCorrection { get; set; }

        [JsonPropertyName("FXAA")]
        public FXAA? FXAA { get; set; }
    }

    /// <summary>
    /// Bloom effect
    /// </summary>
    public class Bloom
    {
        [JsonPropertyName("enable")]
        public bool? Enable { get; set; }

        [JsonPropertyName("bloomIntensity")]
        public double? BloomIntensity { get; set; }
    }

    /// <summary>
    /// Depth of field effect
    /// </summary>
    public class DepthOfField
    {
        [JsonPropertyName("enable")]
        public bool? Enable { get; set; }

        [JsonPropertyName("focalDistance")]
        public double? FocalDistance { get; set; }

        [JsonPropertyName("focalRange")]
        public double? FocalRange { get; set; }

        [JsonPropertyName("blurRadius")]
        public double? BlurRadius { get; set; }
    }

    /// <summary>
    /// Screen space ambient occlusion
    /// </summary>
    public class SSAO
    {
        [JsonPropertyName("enable")]
        public bool? Enable { get; set; }

        [JsonPropertyName("quality")]
        public string? Quality { get; set; } // 'low', 'medium', 'high', 'ultra'

        [JsonPropertyName("radius")]
        public double? Radius { get; set; }

        [JsonPropertyName("intensity")]
        public double? Intensity { get; set; }
    }

    /// <summary>
    /// Color correction
    /// </summary>
    public class ColorCorrection
    {
        [JsonPropertyName("enable")]
        public bool? Enable { get; set; }

        [JsonPropertyName("exposure")]
        public double? Exposure { get; set; }

        [JsonPropertyName("brightness")]
        public double? Brightness { get; set; }

        [JsonPropertyName("contrast")]
        public double? Contrast { get; set; }

        [JsonPropertyName("saturation")]
        public double? Saturation { get; set; }
    }

    /// <summary>
    /// Fast approximate anti-aliasing
    /// </summary>
    public class FXAA
    {
        [JsonPropertyName("enable")]
        public bool? Enable { get; set; }
    }

    /// <summary>
    /// Temporal super sampling
    /// </summary>
    public class TemporalSuperSampling
    {
        [JsonPropertyName("enable")]
        public bool? Enable { get; set; }
    }

    /// <summary>
    /// View control for 3D scenes
    /// </summary>
    public class ViewControl
    {
        [JsonPropertyName("projection")]
        public string? Projection { get; set; } // 'perspective', 'orthographic'

        [JsonPropertyName("autoRotate")]
        public bool? AutoRotate { get; set; }

        [JsonPropertyName("autoRotateDirection")]
        public string? AutoRotateDirection { get; set; } // 'cw', 'ccw'

        [JsonPropertyName("autoRotateSpeed")]
        public double? AutoRotateSpeed { get; set; }

        [JsonPropertyName("autoRotateAfterStill")]
        public double? AutoRotateAfterStill { get; set; }

        [JsonPropertyName("damping")]
        public double? Damping { get; set; }

        [JsonPropertyName("rotateSensitivity")]
        public object? RotateSensitivity { get; set; } // number or array

        [JsonPropertyName("zoomSensitivity")]
        public double? ZoomSensitivity { get; set; }

        [JsonPropertyName("panSensitivity")]
        public double? PanSensitivity { get; set; }

        [JsonPropertyName("panMouseButton")]
        public string? PanMouseButton { get; set; } // 'left', 'middle', 'right'

        [JsonPropertyName("rotateMouseButton")]
        public string? RotateMouseButton { get; set; }

        [JsonPropertyName("distance")]
        public double? Distance { get; set; }

        [JsonPropertyName("minDistance")]
        public double? MinDistance { get; set; }

        [JsonPropertyName("maxDistance")]
        public double? MaxDistance { get; set; }

        [JsonPropertyName("orthographicSize")]
        public double? OrthographicSize { get; set; }

        [JsonPropertyName("maxOrthographicSize")]
        public double? MaxOrthographicSize { get; set; }

        [JsonPropertyName("minOrthographicSize")]
        public double? MinOrthographicSize { get; set; }

        [JsonPropertyName("alpha")]
        public double? Alpha { get; set; }

        [JsonPropertyName("beta")]
        public double? Beta { get; set; }

        [JsonPropertyName("center")]
        public List<double>? Center { get; set; }

        [JsonPropertyName("minAlpha")]
        public double? MinAlpha { get; set; }

        [JsonPropertyName("maxAlpha")]
        public double? MaxAlpha { get; set; }

        [JsonPropertyName("minBeta")]
        public double? MinBeta { get; set; }

        [JsonPropertyName("maxBeta")]
        public double? MaxBeta { get; set; }

        [JsonPropertyName("animation")]
        public bool? Animation { get; set; }

        [JsonPropertyName("animationDurationUpdate")]
        public int? AnimationDurationUpdate { get; set; }

        [JsonPropertyName("animationEasingUpdate")]
        public string? AnimationEasingUpdate { get; set; }

        public static ViewControl Default() => new ViewControl
        {
            AutoRotate = false,
            Distance = 200,
            Alpha = 40,
            Beta = 0,
            Damping = 0.8
        };

        public ViewControl SetAutoRotate(bool enabled = true, double speed = 10)
        {
            AutoRotate = enabled;
            AutoRotateSpeed = speed;
            return this;
        }

        public ViewControl SetDistance(double distance, double? min = null, double? max = null)
        {
            Distance = distance;
            MinDistance = min;
            MaxDistance = max;
            return this;
        }

        public ViewControl SetAngles(double alpha, double beta)
        {
            Alpha = alpha;
            Beta = beta;
            return this;
        }
    }
}