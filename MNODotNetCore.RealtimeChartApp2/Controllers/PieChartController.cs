using Microsoft.AspNetCore.Mvc;
using MNODotNetCore.RealtimeChartApp2.Models;

namespace MNODotNetCore.RealtimeChartApp2.Controllers
{
    public class PieChartController : Controller
    {
        private readonly AppDbContext _db;

        public PieChartController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Save(TblPieChart reqModel)
        {
            await _db.TblPieCharts.AddAsync(reqModel);
            await _db.SaveChangesAsync(); 
            return RedirectToAction("Create");
        }
    }
}
