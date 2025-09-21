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
            // Don't initialize here - wait for Options to be set
        }

        private static void OnOptionsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is EChartsView chartView && newValue != null)
            {
                // Only load chart with options (don't initialize empty first)
                chartView.LoadChartWithOptions(newValue);
            }
        }

        private static void OnThemeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is EChartsView chartView)
            {
                // Reload with new theme
                if (chartView.Options != null)
                {
                    chartView.LoadChartWithOptions(chartView.Options);
                }
                else
                {
                    chartView.InitializeChart();
                }
            }
        }

        private static void OnUseLocalAssetsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is EChartsView chartView)
            {
                // Reload with new asset settings
                if (chartView.Options != null)
                {
                    chartView.LoadChartWithOptions(chartView.Options);
                }
                else
                {
                    chartView.InitializeChart();
                }
            }
        }

        private void InitializeChart()
        {
            string html = GenerateHtml();
            Source = new HtmlWebViewSource { Html = html };
        }

        private void LoadChartWithOptions(object options)
        {
            // Generate HTML with options embedded directly
            string html = GenerateHtmlWithOptions(options);
            Source = new HtmlWebViewSource { Html = html };
        }

        private string GenerateHtml()
        {
            // Always generate without embedded options - they'll be set via JavaScript
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
                        WriteIndented = false,
                        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
                        NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowNamedFloatingPointLiterals,
                        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
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
        // Debug mode flag
        var DEBUG_MODE = true;
        var debugLog = [];
        var chart; // Global chart instance

        // Log and validate incoming options
        function logDebug(level, message, data) {{
            if (DEBUG_MODE) {{
                var timestamp = new Date().toISOString();
                var entry = {{ time: timestamp, level: level, message: message, data: data }};
                debugLog.push(entry);
                console.log('[' + timestamp + '] ' + level + ': ' + message, data || '');
            }}
        }}

        // Validate and fix serialization issues
        function validateAndFixOptions(options) {{
            logDebug('info', 'Received options from C#', options);

            if (!options || typeof options !== 'object') {{
                logDebug('error', 'Invalid options: not an object', options);
                return null;
            }}

            // Fix common serialization issues
            if (options.series && Array.isArray(options.series)) {{
                options.series = options.series.map((serie, index) => {{
                    // Log each series
                    logDebug('info', 'Processing series ' + index + ' (' + serie.type + ')', serie);

                    // Special handling for sankey charts
                    if (serie.type === 'sankey') {{
                        logDebug('info', 'Processing sankey chart for series ' + index);
                        // Sankey needs both data (nodes) and links
                        if (serie.data && serie.links) {{
                            logDebug('info', 'Sankey has ' + serie.data.length + ' nodes and ' + serie.links.length + ' links');
                        }} else if (serie.nodes && serie.links) {{
                            // Some implementations use 'nodes' instead of 'data'
                            logDebug('info', 'Moving nodes to data for sankey');
                            serie.data = serie.nodes;
                            delete serie.nodes;
                        }}
                    }}

                    // Special handling for pie charts
                    if (serie.type === 'pie') {{
                        // Fix radius for donut charts
                        if (serie.radius) {{
                            logDebug('info', 'Processing pie chart radius for series ' + index, serie.radius);
                            // Ensure radius stays as array if it's an array (for donut charts)
                            if (Array.isArray(serie.radius) && serie.radius.length === 2) {{
                                logDebug('info', 'Keeping radius as array for donut chart: [' + serie.radius[0] + ', ' + serie.radius[1] + ']');
                            }}
                        }}

                        if (serie.data) {{
                            logDebug('info', 'Processing pie chart data for series ' + index, serie.data);
                            serie.data = serie.data.map((item, itemIndex) => {{
                                // Ensure pie data has correct format
                                if (typeof item === 'object' && item !== null) {{
                                    // Handle both lowercase and uppercase property names
                                    var fixedItem = {{
                                        name: item.name || item.Name || 'Item ' + itemIndex,
                                        value: item.value || item.Value || 0
                                    }};

                                    // Copy any additional properties (like itemStyle)
                                    Object.keys(item).forEach(key => {{
                                        if (key !== 'name' && key !== 'Name' && key !== 'value' && key !== 'Value') {{
                                            fixedItem[key] = item[key];
                                        }}
                                    }});

                                    logDebug('info', 'Fixed pie item ' + itemIndex, fixedItem);
                                    return fixedItem;
                                }}
                                return item;
                            }});
                        }}
                    }}

                    // Fix gradient colors
                    ['itemStyle', 'lineStyle', 'areaStyle'].forEach(styleProp => {{
                        if (serie[styleProp] && serie[styleProp].color) {{
                            var color = serie[styleProp].color;
                            if (typeof color === 'object' && color.type) {{
                                logDebug('info', 'Fixing gradient in ' + styleProp + ' for series ' + index, color);
                                // Ensure gradient properties are numbers
                                ['x', 'y', 'x2', 'y2', 'r'].forEach(prop => {{
                                    if (color[prop] !== undefined) {{
                                        color[prop] = parseFloat(color[prop]) || 0;
                                    }}
                                }});
                                // Fix colorStops
                                if (Array.isArray(color.colorStops)) {{
                                    color.colorStops = color.colorStops.map(stop => ({{
                                        offset: parseFloat(stop.offset) || 0,
                                        color: stop.color || '#000'
                                    }}));
                                }}
                            }}
                        }}
                    }});

                    // Fix data arrays
                    if (serie.data && !Array.isArray(serie.data)) {{
                        logDebug('warn', 'Series ' + index + ' data is not an array', serie.data);
                        serie.data = [];
                    }}

                    // Remove null/undefined properties
                    Object.keys(serie).forEach(key => {{
                        if (serie[key] === null || serie[key] === undefined) {{
                            delete serie[key];
                        }}
                    }});

                    return serie;
                }});
            }}

            // Log final processed options
            logDebug('success', 'Options validated and fixed', options);
            return options;
        }}

        // Initialize global chart instance
        chart = echarts.init(document.getElementById('chart'{(GetThemeName() != "Default" ? $", '{GetThemeName()}'" : "")}));

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

        // Export debug log for inspection
        window.getDebugLog = function() {{ return debugLog; }};
        window.getLastError = function() {{ return debugLog.filter(e => e.level === 'error').slice(-1)[0]; }};

        // Set initial options if provided
        {(string.IsNullOrEmpty(chartOptions) ? @"
        // No initial options - show placeholder
        chart.setOption({
            title: {
                text: 'Chart Ready',
                subtext: 'Waiting for data',
                left: 'center',
                top: 'middle',
                textStyle: { color: '#999' }
            }
        });" : $@"
        // Apply initial options
        try {{
            var initialOptions = {chartOptions};
            console.log('RAW JSON:', JSON.stringify(initialOptions));
            logDebug('info', 'Applying initial options', initialOptions);

            // Log the series structure specifically
            if (initialOptions.series) {{
                console.log('Series structure:', initialOptions.series);
                if (initialOptions.series[0]) {{
                    console.log('First series:', initialOptions.series[0]);
                    if (initialOptions.series[0].data) {{
                        console.log('First series data:', initialOptions.series[0].data);
                    }}
                }}
            }}

            var processedOptions = validateAndFixOptions(initialOptions);
            if (processedOptions) {{
                processedOptions = enhanceOptions(processedOptions);
                console.log('PROCESSED OPTIONS:', JSON.stringify(processedOptions));
                chart.setOption(processedOptions);
                logDebug('success', 'Initial chart loaded successfully', null);
            }} else {{
                throw new Error('Initial options validation failed');
            }}
        }} catch (error) {{
            logDebug('error', 'Failed to load initial chart: ' + error.message, error.stack);
            chart.setOption({{
                title: {{
                    text: 'Chart Error',
                    subtext: error.message,
                    left: 'center',
                    top: 'middle',
                    textStyle: {{ color: '#ff0000' }}
                }}
            }});
        }}")}

        // Function to update chart options from outside
        window.updateChartOptions = function(optionsJson) {{
            try {{
                var rawOption = typeof optionsJson === 'string' ? JSON.parse(optionsJson) : optionsJson;
                logDebug('info', 'Updating chart via updateChartOptions', rawOption);
                var option = validateAndFixOptions(rawOption);
                if (option) {{
                    option = enhanceOptions(option);
                    logDebug('info', 'Applying options to chart', option);
                    chart.clear();
                    chart.setOption(option);
                    logDebug('success', 'Chart updated successfully', null);
                    return true;
                }} else {{
                    throw new Error('Options validation failed');
                }}
            }} catch (error) {{
                logDebug('error', 'Failed to update chart: ' + error.message, error.stack);
                // Display error message on chart
                chart.setOption({{
                    title: {{
                        text: 'Chart Error',
                        subtext: error.message,
                        left: 'center',
                        top: 'middle',
                        textStyle: {{ color: '#ff0000' }}
                    }}
                }});
                return false;
            }}
        }};

        // Signal that the chart is ready
        logDebug('info', 'Chart initialized and ready', null);

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
            // Convert options to JSON
            string chartOptions;
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
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
                    NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowNamedFloatingPointLiterals,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };
                chartOptions = JsonSerializer.Serialize(options, serializerOptions);
            }

            // Use JavaScript to update the chart instead of reloading HTML
            var jsCode = $@"
                (function() {{
                    try {{
                        console.log('Attempting to update chart...');
                        if (typeof chart === 'undefined' || !chart) {{
                            console.error('Chart not initialized');
                            return false;
                        }}

                        var rawOptions = {chartOptions};
                        console.log('Raw options received:', rawOptions);

                        // Apply validation and fixes if functions exist
                        var options = rawOptions;
                        if (typeof validateAndFixOptions === 'function') {{
                            console.log('Applying validateAndFixOptions');
                            options = validateAndFixOptions(rawOptions);
                        }}
                        if (typeof enhanceOptions === 'function') {{
                            console.log('Applying enhanceOptions');
                            options = enhanceOptions(options);
                        }}

                        console.log('Final options to apply:', options);
                        chart.clear();
                        chart.setOption(options);
                        console.log('Chart updated successfully');

                        if (typeof logDebug === 'function') {{
                            logDebug('success', 'Chart updated successfully', null);
                        }}
                        return true;
                    }} catch (error) {{
                        console.error('Failed to update chart:', error.message, error.stack);
                        if (typeof logDebug === 'function') {{
                            logDebug('error', 'Failed to update chart: ' + error.message, error.stack);
                        }}
                        // Try to show error on chart
                        if (typeof chart !== 'undefined' && chart) {{
                            chart.setOption({{
                                title: {{
                                    text: 'Update Error',
                                    subtext: error.message,
                                    left: 'center',
                                    top: 'middle'
                                }}
                            }});
                        }}
                        return false;
                    }}
                }})();
            ";

            _ = this.EvaluateJavaScriptAsync(jsCode);
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