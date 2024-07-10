namespace MNODotNetCore.MvcChartApp.Models
{
    public class BubbleChartModel
    {
        public List<ListOfData>? BubbleData { get; set; }
    }
    public class ListOfData
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        public string? name { get; set; }
        public string? country { get; set; }
    }
}
