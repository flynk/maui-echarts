using Microsoft.Maui.Controls;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Flynk.Apps.Maui.ECharts
{
    /// <summary>
    /// Simplified ECharts view that regenerates HTML on each update
    /// This ensures charts always load properly
    /// </summary>
    public class EChartsViewSimple : WebView
    {
        public static readonly BindableProperty OptionsProperty = BindableProperty.Create(
            nameof(Options),
            typeof(object),
            typeof(EChartsViewSimple),
            null,
            propertyChanged: OnOptionsChanged);

        public static readonly BindableProperty ThemeProperty = BindableProperty.Create(
            nameof(Theme),
            typeof(EChartsTheme),
            typeof(EChartsViewSimple),
            EChartsTheme.Default,
            propertyChanged: OnThemeChanged);

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

        public EChartsViewSimple()
        {
            // Initialize with empty chart
            LoadChart(null);
        }

        private static void OnOptionsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is EChartsViewSimple chartView)
            {
                chartView.LoadChart(newValue);
            }
        }

        private static void OnThemeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is EChartsViewSimple chartView)
            {
                chartView.LoadChart(chartView.Options);
            }
        }

        private void LoadChart(object options)
        {
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
                        WriteIndented = false,
                        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                        NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals,
                        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                    };
                    chartOptions = JsonSerializer.Serialize(options, serializerOptions);
                }
            }

            string html = $@"<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no'>
    <script src='https://cdn.jsdelivr.net/npm/echarts@5.4.3/dist/echarts.min.js'></script>
    {GetThemeScript()}
    <style>
        * {{ margin: 0; padding: 0; box-sizing: border-box; }}
        html, body {{ width: 100%; height: 100%; overflow: hidden; }}
        #chart {{ width: 100%; height: 100%; }}
    </style>
</head>
<body>
    <div id='chart'></div>
    <script>
        console.log('Initializing ECharts...');

        // Initialize chart with proper error handling
        var chart;
        try {{
            chart = echarts.init(document.getElementById('chart'){(Theme != EChartsTheme.Default ? $", '{Theme}'" : "")});
            console.log('ECharts initialized successfully');
        }} catch (initError) {{
            console.error('Failed to initialize ECharts:', initError);
            document.getElementById('chart').innerHTML = '<div style=""color: red; padding: 20px;"">Failed to initialize chart: ' + initError.message + '</div>';
        }}

        function setChartOption(option) {{
            try {{
                if (!chart) {{
                    console.error('Chart not initialized');
                    return false;
                }}

                console.log('Setting chart option:', JSON.stringify(option, null, 2));

                // Validate option structure
                if (!option || typeof option !== 'object') {{
                    throw new Error('Invalid chart options: must be an object');
                }}

                // Clear any existing chart
                chart.clear();

                // Apply the new options with proper error handling
                chart.setOption(option, true);

                console.log('Chart rendered successfully');
                return true;
            }} catch (error) {{
                console.error('Error setting chart option:', error.message);
                console.error('Stack:', error.stack);

                // Try to display error message
                if (chart) {{
                    try {{
                        chart.clear();
                        chart.setOption({{
                            title: {{
                                text: 'Chart Error',
                                subtext: error.message,
                                left: 'center',
                                top: 'middle',
                                textStyle: {{ color: '#ff0000' }}
                            }}
                        }});
                    }} catch (e) {{
                        console.error('Failed to display error on chart:', e);
                    }}
                }} else {{
                    document.getElementById('chart').innerHTML = '<div style=""color: red; padding: 20px;"">Error: ' + error.message + '</div>';
                }}
                return false;
            }}
        }}

        // Handle window resize
        window.addEventListener('resize', function() {{
            chart.resize();
        }});

        // Set initial options if provided
        {(string.IsNullOrEmpty(chartOptions) ? @"
        // No initial options - show placeholder
        chart.setOption({
            title: {
                text: 'Ready',
                subtext: 'Waiting for chart data',
                left: 'center',
                top: 'middle',
                textStyle: { color: '#999' }
            }
        });" : $@"
        // Apply initial options
        var initialOptions = {chartOptions};
        setChartOption(initialOptions);")}
    </script>
</body>
</html>";

            Source = new HtmlWebViewSource { Html = html };
        }

        private string GetThemeScript()
        {
            return Theme switch
            {
                EChartsTheme.Dark => @"<script src='https://cdn.jsdelivr.net/npm/echarts@5.4.3/dist/theme/dark.js'></script>",
                EChartsTheme.Vintage => @"<script src='https://cdn.jsdelivr.net/npm/echarts@5.4.3/dist/theme/vintage.js'></script>",
                _ => ""
            };
        }

        public async Task ClearAsync()
        {
            await this.EvaluateJavaScriptAsync("if(typeof chart !== 'undefined') chart.clear();");
        }

        public async Task ResizeAsync()
        {
            await this.EvaluateJavaScriptAsync("if(typeof chart !== 'undefined') chart.resize();");
        }
    }
}