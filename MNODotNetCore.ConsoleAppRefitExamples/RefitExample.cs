using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNODotNetCore.ConsoleAppRefitExamples;

public class RefitExample
{
    private readonly IBlogAPI _service = RestService.For<IBlogAPI>("https://localhost:7226");
    public async Task RunAsync()
    {
        // await ReadAsync();
        /*await EditAsync(1);
        await EditAsync(25);*/
        await PatchAsync(1017,"Hi Mg", "Hi aut", "hi content");
    }
    private async Task ReadAsync()
    {
        var lst = await _service.GetBlogs();

        foreach (var item in lst)
        {

            Console.WriteLine($"ID: {item.BlogId}");
            Console.WriteLine($"Title: {item.BlogTitle}");
            Console.WriteLine($"Author: {item.BlogAuthor}");
            Console.WriteLine($"Content: {item.BlogContent}");
            Console.WriteLine("--------------------------------");
        }

    }
    private async Task EditAsync(int id)
    {
        try
        {
            var item = await _service.GetBlog(id);
            Console.WriteLine($"ID: {item.BlogId}");
            Console.WriteLine($"Title: {item.BlogTitle}");
            Console.WriteLine($"Author: {item.BlogAuthor}");
            Console.WriteLine($"Content: {item.BlogContent}");
            Console.WriteLine("--------------------------------");

        }
        catch (ApiException ex)
        {
            Console.WriteLine(ex.StatusCode.ToString());
            Console.WriteLine(ex.Content);
        } 
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }


    }

    private async Task CreateAsync(string title, string author, string content)
    {
        try
        {
            BlogModel blog = new BlogModel
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content

            };
            var message = await _service.CreateBlog(blog);
            Console.WriteLine(message);
        }
        catch(ApiException ex)
        {
            Console.WriteLine(ex.StatusCode.ToString());
            Console.WriteLine(ex.Content);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async Task UpdateAsync(int id, string title, string author, string content)
    {
        try
        {
            BlogModel blog = new BlogModel
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            var message = await _service.UpdateBlog(id, blog);
            Console.WriteLine(message);
        }
        catch (ApiException ex)
        {
            Console.WriteLine(ex.StatusCode.ToString());
            Console.WriteLine(ex.Content);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
    private async Task PatchAsync(int id, string title, string author, string content)
    {
        try
        {
            BlogModel blog = new BlogModel
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            var message = await _service.PatchBlog(id, blog);
            Console.WriteLine(message);
        }
        catch (ApiException ex)
        {
            Console.WriteLine(ex.StatusCode.ToString());
            Console.WriteLine(ex.Content);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }

    private async Task DeleteAsync(int id)
    {
        try
        {
            var message = await _service.DeleteBlog(id);
            Console.WriteLine(message);
        }
        catch (ApiException ex)
        {
            Console.WriteLine(ex.StatusCode.ToString());
            Console.WriteLine(ex.Content);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}
