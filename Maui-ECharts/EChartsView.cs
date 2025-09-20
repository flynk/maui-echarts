using Microsoft.Maui.Controls;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MauiECharts
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
        {(string.IsNullOrEmpty(chartOptions) ? "" : $"var option = {chartOptions}; chart.setOption(option);")}
        window.addEventListener('resize', function() {{
            chart.resize();
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