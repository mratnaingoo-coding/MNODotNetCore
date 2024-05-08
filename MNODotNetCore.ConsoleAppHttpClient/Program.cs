// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;

Console.WriteLine("Hello, World!");

string jsonTest = await File.ReadAllTextAsync("Birds.json");
var model = JsonConvert.DeserializeObject<Birds>(jsonTest);
/*
Console.WriteLine(jsonTest);*/

foreach (var item in model.Tbl_Bird)
{
    Console.WriteLine(item.BirdEnglishName);
}

static string ToNum(string num)
{
    num = num.Replace("1","၁")း;

    return num;

}


Console.ReadLine();

public class Birds
{
    public Tbl_Bird[] Tbl_Bird { get; set; }
}

public class Tbl_Bird
{
    public int Id { get; set; }
    public string BirdMyanmarName { get; set; }
    public string BirdEnglishName { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
}




// json to C# -> install newtonsoft package 
