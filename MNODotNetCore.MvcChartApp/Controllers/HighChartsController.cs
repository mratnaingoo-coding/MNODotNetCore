using Microsoft.AspNetCore.Mvc;

namespace MNODotNetCore.MvcChartApp.Controllers
{
    public class HighChartsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
