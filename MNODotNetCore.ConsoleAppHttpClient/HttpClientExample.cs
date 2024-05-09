using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text; // For Encoding.UTF-8 
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames; // if you wanna choose like JSON or text or sth, use this keyword with 'Application'

namespace MNODotNetCore.ConsoleAppHttpClientExamples
{
    internal class HttpClientExample
    {
        private readonly HttpClient _client = new HttpClient() { BaseAddress = new Uri("https://localhost:7234/") };
        private readonly string _blogEndPoint = "api/Blog";
        public async Task RunAsync() 
        {
            //await ReadAsync();
            /*   await EditAsync(1);*/
            /*await UpdateAsync(1015, "Hello Java", "Rikzil", "Build your project with coffee.");*/
            await EditAsync(1015);
        }

        private async Task ReadAsync() 
        {
            var response = await _client.GetAsync(_blogEndPoint);
            if (response.IsSuccessStatusCode)
            {
                string jsonTest = await response.Content.ReadAsStringAsync();
                List<BlogDto> lst = JsonConvert.DeserializeObject<List<BlogDto>>(jsonTest)!;
                foreach (var item in lst)
                {
                    //  Console.WriteLine(JsonConvert.SerializeObject(blog));
                    Console.WriteLine($"ID: {item.BlogID}");
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

            string jsonBlog = JsonConvert.SerializeObject(blogDto);
            // you can use var instead of HttpContent 
            var httpContent = new StringContent(jsonBlog, Encoding.UTF8, Application.Json);
            var response = await _client.PostAsync(_blogEndPoint, httpContent);
            if(response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }

        private async Task EditAsync(int id) 
        {
            var response = await _client.GetAsync($"{_blogEndPoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonTest = await response.Content.ReadAsStringAsync();
                var item = JsonConvert.DeserializeObject<BlogDto>(jsonTest)!;

                Console.WriteLine($"ID: {item.BlogID}");
                Console.WriteLine($"Title: {item.BlogTitle}");
                Console.WriteLine($"Author: {item.BlogAuthor}");
                Console.WriteLine($"Content: {item.BlogContent}");
                Console.WriteLine("--------------------------------");
               
            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }
        }

        private async Task DeleteAsync(int id)
        {
            var response = await _client.DeleteAsync($"{_blogEndPoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
                // u can continue your other processing project.
            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
                // u can use this message for error.
            }
        }

        private async Task UpdateAsync(int id,string title, string author, string content)
        {

            BlogDto blogDto = new BlogDto()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            string jsonBlog = JsonConvert.SerializeObject(blogDto);
            // you can use var instead of HttpContent 
            var httpContent = new StringContent(jsonBlog, Encoding.UTF8, Application.Json);
            var response = await _client.PutAsync($"{_blogEndPoint}/{id}", httpContent);
            if (response.IsSuccessStatusCode)
            {
                string message = await response.Content.ReadAsStringAsync();
                Console.WriteLine(message);
            }

        }


    }
}
