using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MNODotNetCore.MvcApp2.Databases;
using MNODotNetCore.MvcApp2.Models;

namespace MNODotNetCore.MvcApp2.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;

        public BlogController(AppDbContext db)
        {
            _db = db;
        }

        [ActionName("Index")]
        public async Task<IActionResult> BlogIndex()
        {
            var lst = await _db.Blog
                .OrderByDescending(x => x.BlogID)
                .ToListAsync();
            return View("BlogIndex",lst);
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
             var item = await _db.Blog.FirstOrDefaultAsync(x => x.BlogID == id);
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
            var item = await _db.Blog.FirstOrDefaultAsync(x => x.BlogID == id);
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
            var item = await _db.Blog.FirstOrDefaultAsync(x => x.BlogID == id);
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
