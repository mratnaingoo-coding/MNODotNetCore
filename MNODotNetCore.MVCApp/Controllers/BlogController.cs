using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MNODotNetCore.MVCApp2.Databases;
using MNODotNetCore.MVCApp2.Models;

namespace MNODotNetCore.MVCApp2.Controllers
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
            var lst = await _db.Blog
                .OrderByDescending(x => x.BlogId)
                .ToListAsync();
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

        [HttpGet]
        [ActionName("Edit")]
        public async Task<IActionResult> BlogEdit(int id)
        {
             var item = await _db.Blog.FirstOrDefaultAsync(x => x.BlogId == id);
             if (item is null)
            {
                return Redirect("/Blog");
            }
             return View("BlogEdit",item);
        }

        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> BlogUpdate(int id, BlogModel blog)
        {
            var item = await _db.Blog.FirstOrDefaultAsync(x => x.BlogId == id);
            if (item is null)
            {
                return Redirect("/Blog");
            }

            item.BlogTitle    = blog.BlogTitle;
            item.BlogAuthor   = blog.BlogAuthor;
            item.BlogContent  = blog.BlogContent;

            await _db.SaveChangesAsync();
            return Redirect("/Blog");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> BlogDelete(int id)
        {
            var item = await _db.Blog.FirstOrDefaultAsync(x => x.BlogId == id);
            if (item is null)
            {
                return Redirect("/Blog");
            }

            _db.Blog.Remove(item);

            await _db.SaveChangesAsync();
            return Redirect("/Blog");
        }
    }
}
