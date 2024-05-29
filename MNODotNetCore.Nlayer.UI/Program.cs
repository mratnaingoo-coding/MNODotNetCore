// See https://aka.ms/new-console-template for more information
using MNODotNetCore.NLayer.BusinessLogic.Services;

Console.WriteLine("Hello, World!");

Business_Logic_Blog bl_Blog = new Business_Logic_Blog();
var result = bl_Blog.GetBlogs();
Console.WriteLine(result);