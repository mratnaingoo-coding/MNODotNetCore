using Microsoft.AspNetCore.Mvc;
using MNODotNetCore.MvcChartApp.Models;
namespace MNODotNetCore.MvcChartApp.Controllers
{
    public class ChartJsController : Controller
    {
        public IActionResult ExampleChart()
        {
            return View();
        }
        public IActionResult FloatingBars()
        {
            ChartJsModel model = new ChartJsModel();
            model.Month = new List<string>() {"January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"};
            return View(model);
        }
        public IActionResult StackedBarChart()
        {
            ChartJsModel model = new ChartJsModel();
            model.Month = new List<string>() {"January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"};
            return View(model);
        }
        
        public IActionResult InterpolationLineChart()
        {
            ChartJsModel model = new ChartJsModel();
            model.ILCdatapoints = new List<double>
            {
                0, 20, 20, 60, 60, 120, 0, 180, 120, 125, 105, 110, 170
            };
            return View(model);
        }

    }
}
