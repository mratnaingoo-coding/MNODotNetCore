using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MNODotNetCore.MvcApp3.Databases
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) 
        {

        }
        public DbSet<BlogEntity> Blogs { get; set; }

    }
    //Data Model
    [Table ("tbl_blog")]
    public class BlogEntity
    {
        [Key]
        public int BlogId { get; set; } 
        public string BlogTitle { get; set; }
        public string BlogAuthor { get; set;}
        public string BlogContent { get; set;}

    }
    //view model
    /*public class BlogModel
    {

    }*/
}
