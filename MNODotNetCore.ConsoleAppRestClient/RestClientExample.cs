using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text; // For Encoding.UTF-8 
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames; // if you wanna choose like JSON or text or sth, use this keyword with 'Application'

namespace MNODotNetCore.ConsoleAppRestClient;

internal class RestClientExample
{
    private readonly RestClient _client = new RestClient(new Uri("https://localhost:7234/"));
    private readonly string _blogEndPoint = "api/Blog";
    public async Task RunAsync()
    {
        /*await ReadAsync();*/
        /*   await EditAsync(1);*/
        await PatchAsync(1015, "Hello Web Developer","","");
        await EditAsync(1015);
    }

    private async Task ReadAsync()
    {
        // two ways that u can choose your request.
        /*RestRequest request = new RestRequest(_blogEndPoint);
        var response = await _client.GetAsync(request);*/

        RestRequest request = new RestRequest(_blogEndPoint, Method.Get);
        var response = await _client.ExecuteAsync(request);
        if (response.IsSuccessStatusCode)
        {
            string jsonTest = response.Content!;
            List<BlogDto> lst = JsonConvert.DeserializeObject<List<BlogDto>>(jsonTest)!;
            foreach (var item in lst)
            {
                //  Console.WriteLine(JsonConvert.SerializeObject(blog));
                Console.WriteLine($"ID: {item.BlogId}");
                Console.WriteLine($"Title: {item.BlogTitle}");
                Console.WriteLine($"Author: {item.BlogAuthor}");
                Console.WriteLine($"Content: {item.BlogContent}");
                Console.WriteLine("--------------------------------");
            }
        }
    }

    private async Task CreateAsync(string title, string author, string content)
    {
        BlogDto blogDto = new BlogDto()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };

        RestRequest request = new RestRequest(_blogEndPoint,Method.Post);
        request.AddJsonBody(blogDto);
        var response = await _client.ExecuteAsync(request);
        if (response.IsSuccessStatusCode)
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }
    }

    private async Task EditAsync(int id)
    {
        RestRequest request = new RestRequest($"{_blogEndPoint}/{id}");
        var response = await _client.GetAsync(request);
        if (response.IsSuccessStatusCode)
        {
            string jsonTest = response.Content!;
            var item = JsonConvert.DeserializeObject<BlogDto>(jsonTest)!;

            Console.WriteLine($"ID: {item.BlogId}");
            Console.WriteLine($"Title: {item.BlogTitle}");
            Console.WriteLine($"Author: {item.BlogAuthor}");
            Console.WriteLine($"Content: {item.BlogContent}");
            Console.WriteLine("--------------------------------");

        }
        else
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }
    }

    private async Task DeleteAsync(int id)
    {
        RestRequest request = new RestRequest($"{_blogEndPoint}/{id}", Method.Delete);
        var response = await _client.ExecuteAsync(request);
        if (response.IsSuccessStatusCode)
        {
            string message = response.Content!;
            Console.WriteLine(message);
            // u can continue your other processing project.
        }
        else
        {
            string message = response.Content!;
            Console.WriteLine(message);
            // u can use this message for error.
        }
    }

    private async Task UpdateAsync(int id, string title, string author, string content)
    {

        BlogDto blogDto = new BlogDto()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };

        RestRequest request = new RestRequest($"{_blogEndPoint}/{id}", Method.Put);
        request.AddJsonBody(blogDto);
        var response = await _client.ExecuteAsync(request);
        if (response.IsSuccessStatusCode)
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }
    }
    private async Task PatchAsync(int id, string? title, string? author, string? content)
    {

        BlogDto blogDto = new BlogDto()
        {
            BlogTitle = title,
            BlogAuthor = author,
            BlogContent = content
        };

        RestRequest request = new RestRequest($"{_blogEndPoint}/{id}", Method.Patch);
        request.AddJsonBody(blogDto);
        var response = await _client.ExecuteAsync(request);
        if (response.IsSuccessStatusCode)
        {
            string message = response.Content!;
            Console.WriteLine(message);
        }

    }


}
