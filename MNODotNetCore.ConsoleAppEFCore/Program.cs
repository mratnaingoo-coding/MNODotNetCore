
using MNODotNetCore.ConsoleAppEFCore.Databases.Models;

AppDbContext db = new AppDbContext();
var item = db.TblPieCharts.ToList();