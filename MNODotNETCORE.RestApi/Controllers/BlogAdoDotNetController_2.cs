using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MNODotNETCORE.RestApi.Model;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using MNODotNetCore.shared;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MNODotNETCORE.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNetController_2 : ControllerBase
    {
        private readonly AdoDotNetServices _adoDotNetServices = new AdoDotNetServices(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "SELECT * from tbl_blog";
            
            var lst = _adoDotNetServices.Query<BlogModel>(query);
              return Ok(lst);

          }
        
        [HttpGet("{id}")]
          public IActionResult GetBlog(int id)
          {
              
              string query = "SELECT * from tbl_blog WHERE BlogID = @BlogID";
            // if u didn't use params in AdoDotNetService & put parameters into null, use below.
           /* AdoDotNetParameter[] para = new AdoDotNetParameter[1];
            para[0] = new AdoDotNetParameter("@BlogID", id);
              var lst = _adoDotNetServices.Query<BlogModel>(query, para);*/
           var lst= _adoDotNetServices.QueryFirstOrDefault<BlogModel>(query, new AdoDotNetParameter("@BlogID",id));

            if (lst is null)
            {
                return NotFound("No data was found.");
            }
            
            return Ok(lst);
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
            

            int result = _adoDotNetServices.Execute(query, 
                new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
                new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
                new AdoDotNetParameter("@BlogContent", blog.BlogContent)
                );

            string message = result > 0 ? "Saving success." : "Saving fail.";
           return Ok(message);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
           
           
            string query = @"UPDATE [dbo].[tbl_blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogID = @BlogID";
           
            int result = _adoDotNetServices.Execute(query,
                    new AdoDotNetParameter("@BlogID", id),
                    new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
                    new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
                    new AdoDotNetParameter("@BlogContent", blog.BlogContent)
                );

           
            string message = result > 0 ? "Updating success." : "Updating fail.";
           return Ok(message);
        }
        [HttpPatch("{id}")]
        public IActionResult ModifiedBlog(int id, BlogModel blog)
        {
            
            List<AdoDotNetParameter> parameters = new List<AdoDotNetParameter>();
            string item = string.Empty;
            string query = @"UPDATE [dbo].[tbl_blog]
   SET ";
            
            
           
            if (blog.BlogTitle != null)
            {
              item += "[BlogTitle] = @BlogTitle, ";
              parameters.Add(new AdoDotNetParameter("@BlogTitle", blog.BlogTitle));
            }
            if (blog.BlogAuthor != null)
            {
                item += "[BlogAuthor] = @BlogAuthor, ";
                parameters.Add(new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor));
            }
            if (blog.BlogContent != null)
            {
                item += "[BlogContent] = @BlogContent, ";
                parameters.Add(new AdoDotNetParameter("@BlogContent", blog.BlogContent));
            }
            if (item.Length == 0)
            {
                return NotFound("Please input at least one.");
            }
            parameters.Add(new AdoDotNetParameter("@BlogID", id));
            item = item.Substring(0, item.Length - 2);
            query += item + " WHERE BlogID = @BlogID";
           
            int result = _adoDotNetServices.Execute(query,
               parameters.ToArray() );
            

            string message = result > 0 ? "Modifying success." : "Modifying fail.";
            return Ok(message);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
           

            string query = @"DELETE FROM tbl_blog WHERE BlogID = @BlogID";
            
            int result = _adoDotNetServices.Execute(query,
                new AdoDotNetParameter("@BlogID", id));

           
            string message = result > 0 ? "Deleting success." : "Deleting fail.";
            return Ok(message);
        }
    }
}
