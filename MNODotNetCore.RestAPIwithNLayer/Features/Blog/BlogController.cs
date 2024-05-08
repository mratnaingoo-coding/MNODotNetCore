using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MNODotNetCore.RestAPIwithNLayer.Features.Blog
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly Business_Logic_Blog _Logic_Blog;

        public BlogController()
        {
            _Logic_Blog = new Business_Logic_Blog();
        }

        [HttpGet]
        public IActionResult Read()
        {
            var item = _Logic_Blog.GetBlogs();
            return Ok(item);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var item = _Logic_Blog.GetBlog(id);
            if (item == null)
            {
                return NotFound("No data was found. Try again.");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {
           
            var result = _Logic_Blog.CreateBlog(blog);
            string message = result > 0 ? "Saving successful" : "Saving fail.";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BlogModel blog)
        {
            var item = _Logic_Blog.GetBlog(id);
            if (item is null)
            {
                return NotFound("No data was found. Try again.");
            }
            
            var result = _Logic_Blog.UpdateBlog(id, blog);
            string message = result > 0 ? "Updating successful" : "Updating fail.";

            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel blog)
        {
            var item = _Logic_Blog.GetBlog(id);
            if (item is null)
            {
                return NotFound("No data was found. Try again.");
            }
            
            var result = _Logic_Blog.PatchBlog(id, blog);
            string message = result > 0 ? "Modifying successful" : "Modifying fail.";

            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _Logic_Blog.GetBlog(id);
            if (item is null)
            {
                return NotFound("No data was found. Try again.");
            }
            
            var result = _Logic_Blog.DeleteBlog(id);
            string message = result > 0 ? "Deleting successful" : "Deleting fail.";
            return Ok(message);
        }


    }
}
