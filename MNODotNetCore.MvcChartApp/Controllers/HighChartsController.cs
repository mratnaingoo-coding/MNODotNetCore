
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MNODotNetCore.MvcChartApp.Models;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace MNODotNetCore.MvcChartApp.Controllers
{
    public class HighChartsController : Controller
    {
        private readonly ILogger<HighChartsController> _logger;

        public HighChartsController(ILogger<HighChartsController> logger)
        {
            _logger = logger;
        }

        public IActionResult PieChart()
        {
            _logger.LogInformation("Pie Chart...........");
            return View();
        }
        public IActionResult Variwide()
        {
            _logger.LogInformation("Variwide...........");
            return View();
        }

        public IActionResult BubbleChart()
        {
            _logger.LogInformation("Bubble Chart...........");
            BubbleChartModel model = new BubbleChartModel();
            model.BubbleData = new List<ListOfData>()
            {
                new ListOfData()
                {
                    x = 95,
                    y = 95,
                    z = 13.8,
                    name = "BE",
                    country = "Belgium",
                },
                new ListOfData()
                {
                    x = 86.5,
                    y = 102.9,
                    z = 14.7,
                    name = "DE",
                    country = "Germany",
                },
                new ListOfData()
                {
                   x = 80.4,
                    y = 102.5,
                    z = 12,
                    name = "NL",
                    country = "Netherlands"
                },
                new ListOfData()
                {
                     x = 80.3,
                    y = 86.1,
                    z = 11.8,
                    name = "SE",
                    country = "Sweden"
                },
                new ListOfData()
                {
                    x = 78.4,
                    y = 70.1,
                    z = 16.6,
                    name = "ES",
                    country = "Spain"
                },
                new ListOfData()
                {
                    x = 74.2,
                    y = 68.5,
                    z = 14.5,
                    name = "FR",
                    country = "France"
                },
                new ListOfData()
                {
                    x = 73.5,
                    y = 83.1,
                    z = 10,
                    name = "NO",
                    country = "Norway"
                },
                new ListOfData()
                {
                    x = 71,
                    y = 93.2,
                    z = 24.7,
                    name = "UK",
                    country = "United Kingdom"
                },
                new ListOfData()
                {
                    x = 69.2,
                    y = 57.6,
                    z = 10.4,
                    name = "IT",
                    country = "Italy"
                },
                new ListOfData()
                {
                    x = 68.6,
                    y = 20,
                    z = 16,
                    name = "RU",
                    country = "Russia"
                },
                new ListOfData()
                {
                    x = 65.5,
                    y = 126.4,
                    z = 35.3,
                    name ="US",
                    country = "United States"
                },
                new ListOfData()
                {
                    x = 65.4, 
                    y = 50.8, 
                    z = 28.5, 
                    name = "HU", 
                    country = "Hungary"
                },
                new ListOfData()
                {
                    x = 63.4, 
                    y = 51.8, 
                    z = 15.4, 
                    name = "PT", 
                    country = "Portugal"
                },
                new ListOfData()
                {
                    x = 64, 
                    y = 82.9, 
                    z = 31.3, 
                    name = "NZ", 
                    country = "New Zealand"
                },

            };

            return View(model);
        }
        private async Task<AreaRangeDataModel> GetDataAsync()
        {

            string jsonTest = await System.IO.File.ReadAllTextAsync("Arearange.json");
            var model = JsonConvert.DeserializeObject<AreaRangeDataModel>(jsonTest);
            return model;
        }
        public async Task<IActionResult> AreaRange()
        {
            var model = await GetDataAsync();
            return View(model);
        }

       

    }
}
