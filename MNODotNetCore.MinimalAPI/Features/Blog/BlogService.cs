using MNODotNetCore.MinimalAPI.Databases;
using MNODotNetCore.MinimalAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace MNODotNetCore.MinimalAPI.Features.Blog
{
    public static class BlogService
    {
        public static IEndpointRouteBuilder MapBlogs(this IEndpointRouteBuilder app)
        {
            app.MapGet("api/Blog", async (AppDbContext db) =>
            {
                var lst = await db.Blogs.AsNoTracking().ToListAsync();
                return Results.Ok(lst);
            });

            app.MapGet("api/Blog/{id}", async (AppDbContext db, int id) =>
            {
                var item = await db.Blogs.FirstOrDefaultAsync(x => x.BlogID == id);
                if (item == null)
                {
                    return Results.NotFound("No data was found. Try again.");
                }
                return Results.Ok(item);
            });

            app.MapPost("api/Blog", async (AppDbContext db, BlogModel blog) =>
            {
                await db.Blogs.AddAsync(blog);
                var result = await db.SaveChangesAsync();

                string message = result > 0 ? "Saving Successful." : "Saving Fail!";
                return Results.Ok(message);

            });

            app.MapPut("api/Blog/{id}", async (AppDbContext db, int id, BlogModel blog) =>
            {
                var item = await db.Blogs.FirstOrDefaultAsync(x => x.BlogID == id);
                if (item is null)
                {
                    return Results.NotFound("No data was found. Try again.");
                }
                item.BlogTitle = blog.BlogTitle;
                item.BlogAuthor = blog.BlogAuthor;
                item.BlogContent = blog.BlogContent;
                var result = await db.SaveChangesAsync();
                string message = result > 0 ? "Updating successful." : "Updating fail.";
                return Results.Ok(message);

            });

            app.MapDelete("api/Blog/{id}", async (AppDbContext db, int id) =>
            {
                var item = await db.Blogs.FirstOrDefaultAsync(x => x.BlogID == id);
                if (item is null)
                {
                    return Results.NotFound("No data was found. Try again.");
                }

                db.Blogs.Remove(item);
                var result = await db.SaveChangesAsync();

                string message = result > 0 ? "Deleting successful." : "Deleting fail.";
                return Results.Ok(message);

            });

            return app;
        }
    }
}
