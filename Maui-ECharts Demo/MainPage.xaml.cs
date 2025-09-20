using System.Collections.ObjectModel;

namespace Maui_ECharts_Demo;

public partial class MainPage : ContentPage
{
    public ObservableCollection<ChartType> ChartTypes { get; set; }

    public MainPage()
    {
        InitializeComponent();
        InitializeChartTypes();
        ChartTypesCollectionView.ItemsSource = ChartTypes;
        
        // Auto-select the first chart type
        if (ChartTypes.Count > 0)
        {
            ChartTypesCollectionView.SelectedItem = ChartTypes[0];
        }
    }

    private void InitializeChartTypes()
    {
        ChartTypes = new ObservableCollection<ChartType>
        {
            new ChartType { Name = "Line Chart", Type = "line" },
            new ChartType { Name = "Bar Chart", Type = "bar" },
            new ChartType { Name = "Pie Chart", Type = "pie" },
            new ChartType { Name = "Scatter Chart", Type = "scatter" },
            new ChartType { Name = "Area Chart", Type = "area" },
            new ChartType { Name = "Radar Chart", Type = "radar" },
            new ChartType { Name = "Gauge Chart", Type = "gauge" },
            new ChartType { Name = "Funnel Chart", Type = "funnel" },
            new ChartType { Name = "Heatmap", Type = "heatmap" },
            new ChartType { Name = "Candlestick Chart", Type = "candlestick" }
        };
    }

    private async void OnChartTypeSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is ChartType selectedChart)
        {
            ChartTitleLabel.Text = selectedChart.Name;
            await LoadChart(selectedChart.Type);
        }
    }

    private async Task LoadChart(string chartType)
    {
        var options = GetChartOptions(chartType);
        ChartView.Options = options;
    }

    private string GetChartOptions(string chartType)
    {
        return chartType switch
        {
            "line" => @"{
                title: { text: 'Line Chart Example' },
                tooltip: { trigger: 'axis' },
                legend: { data: ['Sales', 'Revenue'] },
                xAxis: { type: 'category', data: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'] },
                yAxis: { type: 'value' },
                series: [
                    { name: 'Sales', type: 'line', data: [120, 200, 150, 80, 70, 110, 130] },
                    { name: 'Revenue', type: 'line', data: [220, 182, 191, 234, 290, 330, 310] }
                ]
            }",
            
            "bar" => @"{
                title: { text: 'Bar Chart Example' },
                tooltip: { trigger: 'axis' },
                legend: { data: ['2022', '2023'] },
                xAxis: { type: 'category', data: ['Q1', 'Q2', 'Q3', 'Q4'] },
                yAxis: { type: 'value' },
                series: [
                    { name: '2022', type: 'bar', data: [320, 302, 301, 334] },
                    { name: '2023', type: 'bar', data: [220, 182, 191, 234] }
                ]
            }",
            
            "pie" => @"{
                title: { text: 'Pie Chart Example', left: 'center' },
                tooltip: { trigger: 'item' },
                legend: { orient: 'vertical', left: 'left' },
                series: [{
                    name: 'Access From',
                    type: 'pie',
                    radius: '50%',
                    data: [
                        { value: 1048, name: 'Search Engine' },
                        { value: 735, name: 'Direct' },
                        { value: 580, name: 'Email' },
                        { value: 484, name: 'Union Ads' },
                        { value: 300, name: 'Video Ads' }
                    ],
                    emphasis: {
                        itemStyle: {
                            shadowBlur: 10,
                            shadowOffsetX: 0,
                            shadowColor: 'rgba(0, 0, 0, 0.5)'
                        }
                    }
                }]
            }",

            "scatter" => @"{
                title: { text: 'Scatter Chart Example' },
                xAxis: {},
                yAxis: {},
                series: [{
                    symbolSize: 20,
                    type: 'scatter',
                    data: [
                        [10.0, 8.04], [8.07, 6.95], [13.0, 7.58], [9.05, 8.81],
                        [11.0, 8.33], [14.0, 7.66], [13.4, 6.81], [10.0, 6.33],
                        [14.0, 8.96], [12.5, 6.82], [9.15, 7.20], [11.5, 7.20],
                        [3.03, 4.23], [12.2, 7.83], [2.02, 4.47], [1.05, 3.33],
                        [4.05, 4.96], [6.03, 7.24], [12.0, 6.26], [12.0, 8.84]
                    ]
                }]
            }",

            "area" => @"{
                title: { text: 'Area Chart Example' },
                tooltip: { trigger: 'axis' },
                xAxis: { type: 'category', boundaryGap: false, data: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'] },
                yAxis: { type: 'value' },
                series: [{
                    name: 'Data',
                    type: 'line',
                    stack: 'Total',
                    areaStyle: {},
                    emphasis: { focus: 'series' },
                    data: [120, 132, 101, 134, 90, 230, 210]
                }]
            }",

            "radar" => @"{
                title: { text: 'Radar Chart Example' },
                legend: { data: ['Allocated Budget', 'Actual Spending'] },
                radar: {
                    indicator: [
                        { name: 'Sales', max: 6500 },
                        { name: 'Administration', max: 16000 },
                        { name: 'IT', max: 30000 },
                        { name: 'Support', max: 38000 },
                        { name: 'Development', max: 52000 },
                        { name: 'Marketing', max: 25000 }
                    ]
                },
                series: [{
                    name: 'Budget vs Spending',
                    type: 'radar',
                    data: [
                        { value: [4200, 3000, 20000, 35000, 50000, 18000], name: 'Allocated Budget' },
                        { value: [5000, 14000, 28000, 26000, 42000, 21000], name: 'Actual Spending' }
                    ]
                }]
            }",

            "gauge" => @"{
                title: { text: 'Gauge Chart Example' },
                tooltip: { formatter: '{a} <br/>{b} : {c}%' },
                series: [{
                    name: 'Performance',
                    type: 'gauge',
                    detail: { formatter: '{value}%' },
                    data: [{ value: 75, name: 'Score' }]
                }]
            }",

            "funnel" => @"{
                title: { text: 'Funnel Chart Example' },
                tooltip: { trigger: 'item', formatter: '{a} <br/>{b} : {c}%' },
                legend: { data: ['Show', 'Click', 'Visit', 'Inquiry', 'Order'] },
                series: [{
                    name: 'Funnel',
                    type: 'funnel',
                    left: '10%',
                    top: 60,
                    bottom: 60,
                    width: '80%',
                    min: 0,
                    max: 100,
                    minSize: '0%',
                    maxSize: '100%',
                    sort: 'descending',
                    gap: 2,
                    label: { show: true, position: 'inside' },
                    labelLine: { length: 10, lineStyle: { width: 1, type: 'solid' } },
                    itemStyle: { borderColor: '#fff', borderWidth: 1 },
                    emphasis: { label: { fontSize: 20 } },
                    data: [
                        { value: 60, name: 'Visit' },
                        { value: 40, name: 'Inquiry' },
                        { value: 20, name: 'Order' },
                        { value: 80, name: 'Click' },
                        { value: 100, name: 'Show' }
                    ]
                }]
            }",

            "heatmap" => @"{
                title: { text: 'Heatmap Example' },
                tooltip: { position: 'top' },
                grid: { height: '50%', top: '10%' },
                xAxis: { type: 'category', data: ['12a', '1a', '2a', '3a', '4a', '5a', '6a', '7a', '8a', '9a', '10a', '11a'], splitArea: { show: true } },
                yAxis: { type: 'category', data: ['Saturday', 'Friday', 'Thursday', 'Wednesday', 'Tuesday', 'Monday', 'Sunday'], splitArea: { show: true } },
                visualMap: { min: 0, max: 10, calculable: true, orient: 'horizontal', left: 'center', bottom: '15%' },
                series: [{
                    name: 'Punch Card',
                    type: 'heatmap',
                    data: [[0,0,5],[0,1,1],[0,2,0],[0,3,0],[0,4,0],[0,5,0],[0,6,0],[1,0,7],[1,1,0],[1,2,0],[1,3,0],[1,4,0],[1,5,0],[1,6,0],[2,0,1],[2,1,1],[2,2,0],[2,3,0],[2,4,0],[2,5,0],[2,6,0],[3,0,0],[3,1,0],[3,2,0],[3,3,0],[3,4,0],[3,5,0],[3,6,0],[4,0,3],[4,1,4],[4,2,0],[4,3,0],[4,4,0],[4,5,0],[4,6,0],[5,0,4],[5,1,6],[5,2,5],[5,3,7],[5,4,9],[5,5,8],[5,6,10],[6,0,3],[6,1,0],[6,2,0],[6,3,0],[6,4,0],[6,5,0],[6,6,0],[7,0,3],[7,1,0],[7,2,0],[7,3,0],[7,4,0],[7,5,0],[7,6,0],[8,0,3],[8,1,0],[8,2,0],[8,3,0],[8,4,0],[8,5,0],[8,6,0],[9,0,1],[9,1,0],[9,2,0],[9,3,0],[9,4,0],[9,5,0],[9,6,0],[10,0,2],[10,1,0],[10,2,0],[10,3,0],[10,4,0],[10,5,0],[10,6,0],[11,0,4],[11,1,2],[11,2,2],[11,3,6],[11,4,10],[11,5,7],[11,6,6]],
                    label: { show: true },
                    emphasis: { itemStyle: { shadowBlur: 10, shadowColor: 'rgba(0, 0, 0, 0.5)' } }
                }]
            }",

            "candlestick" => @"{
                title: { text: 'Candlestick Chart Example' },
                tooltip: { trigger: 'axis', axisPointer: { type: 'cross' } },
                xAxis: { data: ['2017-10-24', '2017-10-25', '2017-10-26', '2017-10-27'] },
                yAxis: {},
                series: [{
                    type: 'candlestick',
                    data: [
                        [20, 34, 10, 38],
                        [40, 35, 30, 50],
                        [31, 38, 33, 44],
                        [38, 15, 5, 42]
                    ]
                }]
            }",

            _ => @"{
                title: { text: 'Default Chart' },
                xAxis: { type: 'category', data: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'] },
                yAxis: { type: 'value' },
                series: [{ data: [150, 230, 224, 218, 135, 147, 260], type: 'line' }]
            }"
        };
    }
}

public class ChartType
{
    public string Name { get; set; }
    public string Type { get; set; }
}