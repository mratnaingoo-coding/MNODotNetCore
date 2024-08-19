using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MNODotNETCORE.RestApi.Model;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MNODotNETCORE.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNetController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBlogs()
        {
            SqlConnection conn = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            conn.Open();
            
           
            string query = "SELECT * from tbl_blog";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            conn.Close();

          /* List<BlogModel> lst = new List<BlogModel>();
                foreach (DataRow dr in dt.Rows)
                {
                 BlogModel blog = new BlogModel();
                blog.BlogId = Convert.ToInt32(dr["BlogId"]);
                blog.BlogTitle = Convert.ToString(dr["BlogTitle"]);
                blog.BlogAuthor= Convert.ToString(dr["BlogAuthor"]);
                blog.BlogContent= Convert.ToString(dr["BlogContent"]); 
                BlogModel blog = new BlogModel
                {
                    BlogId = Convert.ToInt32(dr["BlogId"]),
                    BlogTitle = Convert.ToString(dr["BlogTitle"]),
                    BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
                    BlogContent = Convert.ToString(dr["BlogContent"])
                };
                lst.Add(blog);

                } */

            List<BlogModel> lst = dt.AsEnumerable().Select(dr => new BlogModel
                 {
                BlogId = Convert.ToInt32(dr["BlogId"]),
                BlogTitle = Convert.ToString(dr["BlogTitle"]),
                BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
                BlogContent = Convert.ToString(dr["BlogContent"])

            }).ToList();
     
              return Ok(lst);

          }
        
        [HttpGet("{id}")]
          public IActionResult GetBlog(int id)
          {
              SqlConnection conn = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
              conn.Open();

             
              string query = "SELECT * from tbl_blog WHERE BlogId = @BlogId";
              SqlCommand cmd = new SqlCommand(query, conn);
              cmd.Parameters.AddWithValue("BlogId", id);
              SqlDataAdapter adapter = new SqlDataAdapter(cmd);
              DataTable dt = new DataTable();
              adapter.Fill(dt);
            conn.Close();

           
            if(dt.Rows.Count == 0)
            {
                return NotFound("No data was found.");
            }
            DataRow dr = dt.Rows[0];
            var item = new BlogModel
            {
                BlogId = Convert.ToInt32(dr["BlogId"]),
                BlogTitle = Convert.ToString(dr["BlogTitle"]),
                BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
                BlogContent = Convert.ToString(dr["BlogContent"])

            };
            return Ok(item);
        }
        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            SqlConnection conn = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            conn.Open();

            
            Console.WriteLine();
            string query = @"INSERT INTO [dbo].[tbl_blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor",blog.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            int result = cmd.ExecuteNonQuery();

            conn.Close();
            string message = result > 0 ? "Saving success." : "Saving fail.";
           return Ok(message);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            SqlConnection conn = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            conn.Open();
           
            string query = @"UPDATE [dbo].[tbl_blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            int result = cmd.ExecuteNonQuery();

            conn.Close();
            string message = result > 0 ? "Updating success." : "Updating fail.";
           return Ok(message);
        }
        [HttpPatch("{id}")]
        public IActionResult ModifiedBlog(int id, BlogModel blog)
        {
            SqlConnection conn = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            conn.Open();
            string item = string.Empty;
            string query = @"UPDATE [dbo].[tbl_blog]
   SET ";
            
            
           
            if (blog.BlogTitle != null)
            {
              item += "[BlogTitle] = @BlogTitle, ";
              
            }
            if (blog.BlogAuthor != null)
            {
                item += "[BlogAuthor] = @BlogAuthor, ";
               
            }
            if (blog.BlogContent != null)
            {
                item += "[BlogContent] = @BlogContent, ";
                
            }
            if (item.Length == 0)
            {
                conn.Close();
                return NotFound("Please input at least one.");
            }
            item = item.Substring(0, item.Length - 2);
            query += item + " WHERE BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@BlogId",id);
            if (blog.BlogTitle != null)
            {
                cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);

            }
            if (blog.BlogAuthor != null)
            {
                cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);

            }
            if (blog.BlogContent != null)
            {
                cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);

            }
            int result = cmd.ExecuteNonQuery();

            conn.Close();
            string message = result > 0 ? "Modifying success." : "Modifying fail.";
            return Ok(message);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            SqlConnection conn = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            conn.Open();

            string query = @"DELETE FROM tbl_blog WHERE BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@BlogId", id);
            int result = cmd.ExecuteNonQuery();

            conn.Close();
            string message = result > 0 ? "Deleting success." : "Deleting fail.";
            return Ok(message);
        }
    }
}
