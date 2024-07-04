using Microsoft.AspNetCore.Mvc;
using MNODotNetCore.MvcChartApp.Models;

namespace MNODotNetCore.MvcChartApp.Controllers
{
    public class ApexChartController : Controller
    {
        public IActionResult SimplePieChart()
        {
            SimplePieChartModel model = new SimplePieChartModel();
            model.Series = new List<int> { 44, 55, 13, 43, 22 };
            model.Labels = new List<string>() { "Team A", "Team B", "Team C", "Team D", "Team E" };

            return View(model);
        }
        public IActionResult MultipleYAxisChart()
        {
            MultipleYAxisChartModel model = new MultipleYAxisChartModel();
            model.Series = new List<ListOfSeries>()
            {
                new ListOfSeries
                {
                    name = "Income",
                    type = "column",
                    data = new List<double> { 1.4, 2, 2.5, 1.5, 2.5, 2.8, 3.8, 4.6 }
                },
                new ListOfSeries
                {
                    name = "Cashflow",
                    type = "column",
                    data = new List<double> { 1.1, 3, 3.1, 4, 4.1, 4.9, 6.5, 8.5 }
                },
                new ListOfSeries
                {
                    name = "Revenue",
                    type = "line",
                    data = new List<double> { 20, 29, 37, 36, 44, 45, 50, 58 }
                }
            };

            model.Categories = new List<int> { 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016 };
            return View(model);
        }
    }
}
