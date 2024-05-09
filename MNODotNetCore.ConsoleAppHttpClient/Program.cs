using MNODotNetCore.ConsoleAppHttpClientExamples;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

// json to C# -> install newtonsoft package 
// Console App - Client (Frontend)
// ASP .Net Core Web Api - Server (Backend)


/*Console.Write("Hello");*/

/*
HttpClient client = new HttpClient();
var response = await client.GetAsync("https://localhost:7234/api/Blog");

if (response.IsSuccessStatusCode)
{
    string jsonTest = await response.Content.ReadAsStringAsync();
    List<BlogDto> lst =  JsonConvert.DeserializeObject<List<BlogDto>>(jsonTest)!;
    foreach(var blog in lst)
    {
      //  Console.WriteLine(JsonConvert.SerializeObject(blog));
        Console.WriteLine($"ID: {blog.BlogID}");
        Console.WriteLine($"Title: {blog.BlogTitle}");
        Console.WriteLine($"Author: {blog.BlogAuthor}");
        Console.WriteLine($"Content: {blog.BlogContent}");
        Console.WriteLine("--------------------------------");
    }
}*/

HttpClientExample httpClientExample = new HttpClientExample();
await httpClientExample.RunAsync();

