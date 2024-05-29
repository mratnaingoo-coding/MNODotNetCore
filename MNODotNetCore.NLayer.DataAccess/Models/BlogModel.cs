using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MNODotNetCore.NLayer.DataAccess.Models;
[Table("tbl_blog")]

public class BlogModel
{
    [Key]
    public int BlogID { get; set; }
    public string? BlogTitle { get; set; }
    public string? BlogAuthor { get; set; }
    public string? BlogContent { get; set; }
}
//public record BlogEntity(int BlogID, string BlogTitle, string BlogAuthor, string BlogContent);


