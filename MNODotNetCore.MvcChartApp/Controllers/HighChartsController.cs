
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MNODotNetCore.MvcChartApp.Models;

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
            return View();
        }
    }
}
