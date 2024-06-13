using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MNODotNetCore.ConsoleApp.AdoDotNetExamples;
using MNODotNetCore.ConsoleApp.DapperExamples;
using MNODotNetCore.ConsoleApp.EFCoreExamples;
using MNODotNetCore.ConsoleApp.Services;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

Console.WriteLine("Hello, welcome to C# DotNet!");




//AdoDotNetExample example = new AdoDotNetExample();
/*example.Create("A Day in the Life of Abed Salama","Nathan Thrall","About Gaza");
example.Create("A Living Remedy", "Nicole Chung", "Even grief provides a living remedy");
example.Create("After Sappho", "Selby Wynn Schwartz", "Sappho’s own writing");
example.Create("All Souls", "Saskia Hamilton", "Saskia Hamilton’s latest poetry collection");

example.Read();
*/
//example.Delete(15);
//example.Edit(15);
//example.Edit(1);
//DapperExample dapperExample = new DapperExample();
//dapperExample.Run();

/*EFCoreExample eFCoreExample = new EFCoreExample();
eFCoreExample.Run();
*/

var connectionString = ConnectionStrings.sqlConnectionStringBuilder.ConnectionString;
var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
var serviceProvider = new ServiceCollection()
    .AddScoped(n => new AdoDotNetExample(sqlConnectionStringBuilder))
    .AddScoped(n => new DapperExample(sqlConnectionStringBuilder))
    .AddDbContext<AppDbContext>(opt =>
    {
        opt.UseSqlServer(connectionString);
    })
    .AddScoped<EFCoreExample>()
    .BuildServiceProvider();

/*AppDbContext db = serviceProvider.GetRequiredService<AppDbContext>();*/
var adoDotNetExample = serviceProvider.GetRequiredService<AdoDotNetExample>();
adoDotNetExample.Read();

/*
var dapperExample = serviceProvider.GetRequiredService<DapperExample>();
dapperExample.Run();*/

Console.ReadKey();
    