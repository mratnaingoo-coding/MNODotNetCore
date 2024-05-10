using MNODotNetCore.ConsoleAppRestClient;
using RestSharp;

Console.WriteLine("Hello, World!");
RestClientExample restClientExample = new RestClientExample();
await restClientExample.RunAsync();
