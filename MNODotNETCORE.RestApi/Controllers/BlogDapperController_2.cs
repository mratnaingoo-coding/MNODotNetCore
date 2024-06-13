using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MNODotNetCore.shared;
using MNODotNETCORE.RestApi.Model;
using System.Data;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MNODotNETCORE.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogDapperController_2 : ControllerBase
    {
        /*private readonly DapperServices _dapperItem = new DapperServices(ConnectionString.sqlConnectionStringBuilder.ConnectionString); */        
        
        private readonly DapperServices _dapperService;

        public BlogDapperController_2(DapperServices dapperService)
        {
            _dapperService = dapperService;
        }

        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "SELECT * FROM tbl_blog";
           

            var lst = _dapperService.Query<BlogModel>(query);
            return Ok(lst);
        }
        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
           // string query = "SELECT * FROM tbl_blog WHERE BlogID = @BlogID";
           // using IDbConnection db = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
           // var item = db.Query<BlogModel>(query, new BlogModel { BlogID = id }).FirstOrDefault();
            // if(item == null) net same.
            var item = searchWithID(id);
            if (item is null)
            {
                return NotFound("No data was found.");
            }
            return Ok(item);
        }
        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            string query = @"INSERT INTO [dbo].[tbl_blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

           int result = _dapperService.Execute(query, blog);

            string message = result > 0 ? "Saving success." : "Saving fail.";
            return Ok(message);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog) 
        {
            var item = searchWithID(id);
            if (item is null)
            {
                return NotFound("No data was found.");
            }
            blog.BlogID = id;
            string query = @"UPDATE [dbo].[tbl_blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogID = @BlogID";

            int result = _dapperService.Execute(query, blog);

            string message = result > 0 ? "Updating success." : "Updating fail.";
            return Ok(message);
        }
        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogModel blog)
        {

            var item = searchWithID(id);
            if (item is null)
            {
                return NotFound("No data was found.");
            }

            string conditions = string.Empty;
            if(!string.IsNullOrEmpty(blog.BlogTitle))
            {
                conditions += "[BlogTitle] = @BlogTitle, ";
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                conditions += "[BlogAuthor] = @BlogAuthor, ";
            }
            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                conditions += "[BlogContent] = @BlogContent, ";
            }
            if(conditions.Length == 0)
            {
                return NotFound("please input at least one.");
            }
            conditions = conditions.Substring(0, conditions.Length - 2);
            blog.BlogID = id;

            string query = $@"UPDATE [dbo].[tbl_blog]
   SET {conditions}
 WHERE BlogID = @BlogID";

            int result = _dapperService.Execute(query, blog);

            string message = result > 0 ? "Updating success." : "Updating fail.";
            return Ok(message);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var item = searchWithID(id);
            if (item is null)
            {
                return NotFound("No data was found.");
            }

            string query = @"DELETE FROM tbl_blog WHERE BlogID = @BlogID";

            using IDbConnection db = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, new BlogModel { BlogID = id});

            string message = result > 0 ? "Deleting success." : "Deleting fail.";

            return Ok(message);
        }
        
        private BlogModel? searchWithID(int id)
        {
            string query = "SELECT * FROM tbl_blog WHERE BlogID = @BlogID";
            using IDbConnection db = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            // Query2 is for FirstOrDefault(); 

            var item = _dapperService.Query2<BlogModel>(query, new BlogModel { BlogID = id });

            return item;

        }

    }
}
