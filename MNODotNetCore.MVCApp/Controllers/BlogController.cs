using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MNODotNetCore.MVCApp.Databases;
using MNODotNetCore.MVCApp.Models;

namespace MNODotNetCore.MVCApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;

        public BlogController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var lst = await _db.Blog.ToListAsync();
            return View(lst);
        }
        [ActionName("Create")]
        public IActionResult BlogCreate()
        {
            return View("BlogCreate");
        }
        [HttpPost]
        [ActionName("Submit")]
        public async Task<IActionResult> BlogCreate(BlogModel blog)
        {
            await _db.Blog.AddAsync(blog);
            var result = await _db.SaveChangesAsync();
            /* return View("BlogCreate");*/
            return Redirect("/Blog");
        }
    }
}
