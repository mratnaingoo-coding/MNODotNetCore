using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNODotNetCore.WinFormsApp.Queries;

internal class BlogQuery
{
    public static string CreateQuery { get; } = @"INSERT INTO [dbo].[tbl_blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
    public static string BlogList { get; } = @"SELECT [BlogID]
            ,[BlogTitle]
            ,[BlogAuthor]
            ,[BlogContent]
            FROM [dbo].[tbl_blog]";
}
