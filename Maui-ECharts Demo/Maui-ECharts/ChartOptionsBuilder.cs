using System.Collections.Generic;
using System.Dynamic;

namespace MauiECharts
{
    public class ChartOptionsBuilder
    {
        private readonly dynamic _options = new ExpandoObject();

        public ChartOptionsBuilder SetTitle(string text, string subtext = null)
        {
            _options.title = new ExpandoObject();
            _options.title.text = text;
            if (!string.IsNullOrEmpty(subtext))
                _options.title.subtext = subtext;
            return this;
        }

        public ChartOptionsBuilder SetTooltip(bool show = true, string trigger = "item")
        {
            _options.tooltip = new ExpandoObject();
            _options.tooltip.show = show;
            _options.tooltip.trigger = trigger;
            return this;
        }

        public ChartOptionsBuilder SetLegend(params string[] data)
        {
            _options.legend = new ExpandoObject();
            _options.legend.data = data;
            return this;
        }

        public ChartOptionsBuilder SetXAxis(string type = "category", params string[] data)
        {
            _options.xAxis = new ExpandoObject();
            _options.xAxis.type = type;
            if (data != null && data.Length > 0)
                _options.xAxis.data = data;
            return this;
        }

        public ChartOptionsBuilder SetYAxis(string type = "value")
        {
            _options.yAxis = new ExpandoObject();
            _options.yAxis.type = type;
            return this;
        }

        public ChartOptionsBuilder AddLineSeries(string name, params double[] data)
        {
            AddSeries("line", name, data);
            return this;
        }

        public ChartOptionsBuilder AddBarSeries(string name, params double[] data)
        {
            AddSeries("bar", name, data);
            return this;
        }

        public ChartOptionsBuilder AddPieSeries(string name, List<PieDataItem> data, string radius = "50%")
        {
            if (!(_options as IDictionary<string, object>).ContainsKey("series"))
                _options.series = new List<dynamic>();

            dynamic series = new ExpandoObject();
            series.name = name;
            series.type = "pie";
            series.radius = radius;
            series.data = data.Select(d => 
            {
                dynamic item = new ExpandoObject();
                item.value = d.Value;
                item.name = d.Name;
                return item;
            }).ToList();

            _options.series.Add(series);
            return this;
        }

        public ChartOptionsBuilder AddScatterSeries(string name, List<double[]> data)
        {
            if (!(_options as IDictionary<string, object>).ContainsKey("series"))
                _options.series = new List<dynamic>();

            dynamic series = new ExpandoObject();
            series.name = name;
            series.type = "scatter";
            series.data = data;

            _options.series.Add(series);
            return this;
        }

        public ChartOptionsBuilder AddRadarSeries(string name, List<double> data, List<RadarIndicator> indicators)
        {
            if (!(_options as IDictionary<string, object>).ContainsKey("radar"))
            {
                _options.radar = new ExpandoObject();
                _options.radar.indicator = indicators.Select(i => 
                {
                    dynamic indicator = new ExpandoObject();
                    indicator.name = i.Name;
                    indicator.max = i.Max;
                    return indicator;
                }).ToList();
            }

            if (!(_options as IDictionary<string, object>).ContainsKey("series"))
                _options.series = new List<dynamic>();

            dynamic series = new ExpandoObject();
            series.name = name;
            series.type = "radar";
            series.data = new List<dynamic>
            {
                new { value = data, name = name }
            };

            _options.series.Add(series);
            return this;
        }

        public ChartOptionsBuilder AddGaugeSeries(string name, double value, string unit = "%")
        {
            if (!(_options as IDictionary<string, object>).ContainsKey("series"))
                _options.series = new List<dynamic>();

            dynamic series = new ExpandoObject();
            series.name = name;
            series.type = "gauge";
            series.detail = new ExpandoObject();
            series.detail.formatter = $"{{value}}{unit}";
            series.data = new List<dynamic>
            {
                new { value = value, name = name }
            };

            _options.series.Add(series);
            return this;
        }

        private void AddSeries(string type, string name, double[] data)
        {
            if (!(_options as IDictionary<string, object>).ContainsKey("series"))
                _options.series = new List<dynamic>();

            dynamic series = new ExpandoObject();
            series.name = name;
            series.type = type;
            series.data = data;

            _options.series.Add(series);
        }

        public dynamic Build()
        {
            return _options;
        }

        public static ChartOptionsBuilder Create()
        {
            return new ChartOptionsBuilder();
        }
    }

    public class PieDataItem
    {
        public double Value { get; set; }
        public string Name { get; set; }

        public PieDataItem(double value, string name)
        {
            Value = value;
            Name = name;
        }
    }

    public class RadarIndicator
    {
        public string Name { get; set; }
        public double Max { get; set; }

        public RadarIndicator(string name, double max)
        {
            Name = name;
            Max = max;
        }
    }
}