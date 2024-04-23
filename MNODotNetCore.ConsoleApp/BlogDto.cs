using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNODotNetCore.ConsoleApp;
[Table("tbl_blog")]

public class BlogDto
{
    [Key]
    public int BlogID { get; set; }
    public string BlogTitle { get; set; }
    public string BlogAuthor {  get; set; }
    public string BlogContent {  get; set; }
}
//public record BlogEntity(int BlogID, string BlogTitle, string BlogAuthor, string BlogContent);


