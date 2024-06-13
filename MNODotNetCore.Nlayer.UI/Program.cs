// See https://aka.ms/new-console-template for more information
using MNODotNetCore.NLayer.BusinessLogic.Services;
using MNODotNetCore.NLayer.DataAccess.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

Console.WriteLine("Hello, World!");

Business_Logic_Blog bl_Blog = new Business_Logic_Blog();
var jsr = bl_Blog.GetBlogs();
var blogs = JsonConvert.SerializeObject(jsr);

