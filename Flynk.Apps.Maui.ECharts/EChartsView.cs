using Microsoft.Maui.Controls;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Flynk.Apps.Maui.ECharts
{
    public class EChartsView : WebView
    {

        public static readonly BindableProperty OptionsProperty = BindableProperty.Create(
            nameof(Options),
            typeof(object),
            typeof(EChartsView),
            null,
            propertyChanged: OnOptionsChanged);

        public static readonly BindableProperty ThemeProperty = BindableProperty.Create(
            nameof(Theme),
            typeof(EChartsTheme),
            typeof(EChartsView),
            EChartsTheme.Default,
            propertyChanged: OnThemeChanged);

        public static readonly BindableProperty UseLocalAssetsProperty = BindableProperty.Create(
            nameof(UseLocalAssets),
            typeof(bool),
            typeof(EChartsView),
            false,
            propertyChanged: OnUseLocalAssetsChanged);

        public object Options
        {
            get => GetValue(OptionsProperty);
            set => SetValue(OptionsProperty, value);
        }

        public EChartsTheme Theme
        {
            get => (EChartsTheme)GetValue(ThemeProperty);
            set => SetValue(ThemeProperty, value);
        }

        public bool UseLocalAssets
        {
            get => (bool)GetValue(UseLocalAssetsProperty);
            set => SetValue(UseLocalAssetsProperty, value);
        }

        public EChartsView()
        {
            InitializeChart();
        }

        private static void OnOptionsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is EChartsView chartView && newValue != null)
            {
                chartView.UpdateChart(newValue);
            }
        }

        private static void OnThemeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is EChartsView chartView)
            {
                chartView.InitializeChart();
            }
        }

        private static void OnUseLocalAssetsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is EChartsView chartView)
            {
                chartView.InitializeChart();
            }
        }

        private void InitializeChart()
        {
            string html = GenerateHtml();
            Source = new HtmlWebViewSource { Html = html };
        }

        private string GenerateHtml()
        {
            return GenerateHtmlWithOptions(null);
        }

        private string GenerateHtmlWithOptions(object options)
        {
            string echartsSource = UseLocalAssets
                ? "echarts.min.js"
                : "https://cdn.jsdelivr.net/npm/echarts@5.4.3/dist/echarts.min.js";

            // Add ECharts GL support
            string echartsGlSource = UseLocalAssets
                ? "echarts-gl.min.js"
                : "https://cdn.jsdelivr.net/npm/echarts-gl@2.0.9/dist/echarts-gl.min.js";

            string themeScript = GetThemeScript();

            string chartOptions = "";
            if (options != null)
            {
                if (options is string str)
                {
                    chartOptions = str;
                }
                else
                {
                    var serializerOptions = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        WriteIndented = false
                    };
                    chartOptions = JsonSerializer.Serialize(options, serializerOptions);
                }
            }

            return $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no'>
    <script src='{echartsSource}'></script>
    <script src='{echartsGlSource}'></script>
    {themeScript}
    <style>
        * {{ margin: 0; padding: 0; box-sizing: border-box; }}
        html, body {{ width: 100%; height: 100%; overflow: hidden; }}
        #chart {{ width: 100%; height: 100%; }}
    </style>
</head>
<body>
    <div id='chart'></div>
    <script>
        var chart = echarts.init(document.getElementById('chart'{(GetThemeName() != "Default" ? $", '{GetThemeName()}'" : "")}));

        // Enable better interaction defaults
        function enhanceOptions(option) {{
            if (!option) return option;

            // Add dataZoom by default for compatible chart types
            if (!option.dataZoom && (option.xAxis || option.singleAxis)) {{
                option.dataZoom = [
                    {{
                        type: 'inside',
                        start: 0,
                        end: 100,
                        filterMode: 'filter'
                    }},
                    {{
                        type: 'slider',
                        show: true,
                        start: 0,
                        end: 100,
                        handleIcon: 'path://M10.7,11.9v-1.3H9.3v1.3c-4.9,0.3-8.8,4.4-8.8,9.4c0,5,3.9,9.1,8.8,9.4v1.3h1.3v-1.3c4.9-0.3,8.8-4.4,8.8-9.4C19.5,16.3,15.6,12.2,10.7,11.9z M13.3,24.4H6.7V23h6.6V24.4z M13.3,19.6H6.7v-1.4h6.6V19.6z',
                        handleSize: '80%',
                        handleStyle: {{
                            color: '#fff',
                            shadowBlur: 3,
                            shadowColor: 'rgba(0, 0, 0, 0.6)',
                            shadowOffsetX: 2,
                            shadowOffsetY: 2
                        }}
                    }}
                ];
            }}

            // Enable roam for graph-type charts
            if (option.series) {{
                option.series.forEach(function(serie) {{
                    if (serie.type === 'graph' || serie.type === 'tree') {{
                        serie.roam = true;
                    }}
                    if (serie.type === 'tree' && !serie.orient) {{
                        serie.orient = 'TB';  // Top-Bottom for organizational charts
                        serie.layout = 'orthogonal';
                        serie.edgeShape = 'polyline';
                    }}
                }});
            }}

            // Add default toolbox if not present
            if (!option.toolbox) {{
                option.toolbox = {{
                    show: true,
                    feature: {{
                        dataZoom: {{ show: true }},
                        dataView: {{ show: false }},
                        restore: {{ show: true }},
                        saveAsImage: {{ show: true }}
                    }}
                }};
            }}

            return option;
        }}

        {(string.IsNullOrEmpty(chartOptions) ? "" : $@"
        var option = {chartOptions};
        option = enhanceOptions(option);
        chart.setOption(option);")}

        window.addEventListener('resize', function() {{
            chart.resize();
        }});

        // Enable mouse wheel zoom
        chart.on('dataZoom', function() {{
            // Handle dataZoom events if needed
        }});
    </script>
</body>
</html>";
        }

        private string GetThemeName()
        {
            return Theme.ToString();
        }

        private string GetThemeScript()
        {
            return Theme switch
            {
                EChartsTheme.Dark => @"<script src='https://cdn.jsdelivr.net/npm/echarts@5.4.3/dist/theme/dark.js'></script>",
                EChartsTheme.Vintage => @"<script src='https://cdn.jsdelivr.net/npm/echarts@5.4.3/dist/theme/vintage.js'></script>",
                EChartsTheme.Westeros => @"<script src='https://cdn.jsdelivr.net/npm/echarts@5.4.3/dist/theme/westeros.js'></script>",
                EChartsTheme.Essos => @"<script src='https://cdn.jsdelivr.net/npm/echarts@5.4.3/dist/theme/essos.js'></script>",
                EChartsTheme.Wonderland => @"<script src='https://cdn.jsdelivr.net/npm/echarts@5.4.3/dist/theme/wonderland.js'></script>",
                EChartsTheme.Walden => @"<script src='https://cdn.jsdelivr.net/npm/echarts@5.4.3/dist/theme/walden.js'></script>",
                EChartsTheme.Chalk => @"<script src='https://cdn.jsdelivr.net/npm/echarts@5.4.3/dist/theme/chalk.js'></script>",
                EChartsTheme.Infographic => @"<script src='https://cdn.jsdelivr.net/npm/echarts@5.4.3/dist/theme/infographic.js'></script>",
                EChartsTheme.Macarons => @"<script src='https://cdn.jsdelivr.net/npm/echarts@5.4.3/dist/theme/macarons.js'></script>",
                EChartsTheme.Roma => @"<script src='https://cdn.jsdelivr.net/npm/echarts@5.4.3/dist/theme/roma.js'></script>",
                EChartsTheme.Shine => @"<script src='https://cdn.jsdelivr.net/npm/echarts@5.4.3/dist/theme/shine.js'></script>",
                EChartsTheme.Purple => @"<script src='https://cdn.jsdelivr.net/npm/echarts@5.4.3/dist/theme/purple-passion.js'></script>",
                EChartsTheme.Halloween => @"<script src='https://cdn.jsdelivr.net/npm/echarts@5.4.3/dist/theme/halloween.js'></script>",
                _ => ""
            };
        }

        private void UpdateChart(object options)
        {
            // Regenerate the HTML with the new options embedded
            string html = GenerateHtmlWithOptions(options);
            Source = new HtmlWebViewSource { Html = html };
        }

        public async Task SetOptionAsync(object options)
        {
            UpdateChart(options);
            await Task.CompletedTask;
        }

        public async Task ClearAsync()
        {
            await this.EvaluateJavaScriptAsync("if(typeof chart !== 'undefined') chart.clear();");
        }

        public async Task DisposeAsync()
        {
            await this.EvaluateJavaScriptAsync("if(typeof chart !== 'undefined') { chart.dispose(); chart = null; }");
        }

        public async Task ResizeAsync()
        {
            await this.EvaluateJavaScriptAsync("if(typeof chart !== 'undefined') chart.resize();");
        }
    }

    public enum EChartsTheme
    {
        Default,
        Dark,
        Vintage,
        Westeros,
        Essos,
        Wonderland,
        Walden,
        Chalk,
        Infographic,
        Macarons,
        Roma,
        Shine,
        Purple,
        Halloween
    }
}