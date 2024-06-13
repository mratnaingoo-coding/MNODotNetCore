using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MNODotNETCORE.RestApi.Databases;
using MNODotNETCORE.RestApi.Model;

namespace MNODotNETCORE.RestApi.Controllers
{
    // https://localhost:3000 => domain url
    // api/blog => endpoint
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
       /* private readonly AppDbContext _context;
        public BlogController()
        {
            _context = new AppDbContext();
        }*/
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Read()
        {
            var item = _context.Blog.ToList();
            return Ok(item);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var item = _context.Blog.FirstOrDefault(x=> x.BlogID == id);
            if(item == null)
            {
                return NotFound("No data was found. Try again.");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {
            _context.Blog.Add(blog);
            var result = _context.SaveChanges();
            string message = result > 0 ? "Saving successful" : "Saving fail.";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BlogModel blog)
        {
            var item = _context.Blog.FirstOrDefault(x => x.BlogID == id);
            if (item is null)
            {
                return NotFound("No data was found. Try again.");
            }
            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;
            var result = _context.SaveChanges();
            string message = result > 0 ? "Updating successful" : "Updating fail.";

            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel blog)
        {
            var item = _context.Blog.FirstOrDefault(x => x.BlogID == id);
            if (item is null)
            {
                return NotFound("No data was found. Try again.");
            }
            if(!string.IsNullOrEmpty(blog.BlogTitle))
            {
                item.BlogTitle = blog.BlogTitle;
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                item.BlogAuthor = blog.BlogAuthor;
            }
            if(!string.IsNullOrEmpty(blog.BlogContent)) 
            {
                item.BlogContent = blog.BlogContent;
            }
            
            
            var result = _context.SaveChanges();
            string message = result > 0 ? "Modifying successful" : "Modifying fail.";

            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.Blog.FirstOrDefault(x => x.BlogID == id);
            if (item is null)
            {
                return NotFound("No data was found. Try again.");
            }
            _context.Blog.Remove(item);
            var result = _context.SaveChanges();
            string message = result > 0 ? "Deleting successful" : "Deleting fail.";
            return Ok(message);
        }

        

    }
}
