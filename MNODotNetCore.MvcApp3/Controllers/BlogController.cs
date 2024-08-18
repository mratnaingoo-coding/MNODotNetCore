using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MNODotNetCore.MvcApp3.Databases;
using System.Collections.Generic;

namespace MNODotNetCore.MvcApp3.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;
        //constructor injection
        public BlogController(AppDbContext db)
        {
            _db = db;
        }

        //logical path -> https://localhost:3000/blog/index
        //physical path -> https://localhost:3000/blog/blogindex

        //Get
        //[ActionName("Index")] //nickname
        //public IActionResult BlogIndex([FromServices] AppDbContext db) //method injection 
        //{
        //    //select * from tbl_blog
        //    //select * from tbl_blog with (nolock)

        //    List < BlogEntity >
        //    return View("BlogIndex"); //real name
        //}

        //[FromService]
        // public AppDbContext db {get; set;} //property injection




        [HttpGet]
        [ActionName("Index")]
        public IActionResult BlogIndex()
        {
            //select * from tbl_blog
            //select * from tbl_blog with (nolock)

            List<BlogEntity> lst = _db.Blogs.AsNoTracking()
                .OrderByDescending(x=> x.BlogId)
                .ToList();
            return View("BlogIndex", lst);
        }

        //Create
        [HttpGet]
        [ActionName("Create")]
        public IActionResult BlogCreate()
        {
            return View("BlogCreate");
        }
        //Save
        [HttpPost]
        [ActionName("Save")]
        public IActionResult BlogSave(BlogEntity blog)
        {
            _db.Blogs.Add(blog);
            //_db.Add(blog);
            var result = _db.SaveChanges();
            string message = result > 0 ? "Saving Successful" : "Saving Fail";

            //return View("BlogSave");
            return Json(new { Message = message, IsSuccess = result > 0 });

        }
        // blog/edit?blogId=1
        // blog/edit/1
        //Edit
        [HttpGet]
        [ActionName("Edit")]
        public IActionResult BlogEdit(int id)
        {
            var item = _db.Blogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
            if (item is null) return RedirectToAction("Index");

            return View("BlogEdit", item);
        }
        //Update
        [HttpPost]
        [ActionName("Update")]
        public IActionResult BlogUpdate(int id, BlogEntity blog)
        {
            var item = _db.Blogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
            if (item is null) return Json(new { Message = "No data found.", IsSuccess = false });

            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;

            _db.Entry(item).State = EntityState.Modified;
            var result = _db.SaveChanges();
            string message = result > 0 ? "Updating Successful" : "Updating Fail";

            //return View("BlogSave");
            return Json(new { Message = message, IsSuccess = result > 0 });

        }
        //Delete
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult BlogDelete(BlogEntity blog)
        {
            var item = _db.Blogs.AsNoTracking().FirstOrDefault(x => x.BlogId == blog.BlogId);
            if (item is null) return Json(new { Message = "No data found.", IsSuccess = false });

            _db.Entry(item).State = EntityState.Deleted;
            var result = _db.SaveChanges();
            string message = result > 0 ? "Deleting Successful" : "Deleting Fail";

            //return View("BlogSave");
            return Json(new { Message = message, IsSuccess = result > 0 });

        }

    }
}
