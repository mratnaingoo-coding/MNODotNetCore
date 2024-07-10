using Microsoft.AspNetCore.Mvc;

namespace MNODotNetCore.MvcChartApp.Controllers
{
    
    public class CanvasJsController : Controller
    {
		private readonly ILogger<CanvasJsController> _logger;

		public CanvasJsController(ILogger<CanvasJsController> logger)
		{
			_logger = logger;
		}

		public IActionResult LineChart()
        {
            _logger.LogInformation("Line Chart...........");
            return View();
        }
        public IActionResult PyramidChart()
        {
            _logger.LogInformation("Pyramid Chart...........");
            return View();
        }
        public IActionResult ParetoChartWithIndex()
        {
			_logger.LogInformation("Pareto Chart With Index/ Data Label...........");
			return View();
        }
    }
}
