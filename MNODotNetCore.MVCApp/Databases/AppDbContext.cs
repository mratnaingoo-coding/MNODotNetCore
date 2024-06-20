using Microsoft.EntityFrameworkCore;
using MNODotNetCore.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNODotNetCore.MVCApp.Databases
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
   //if you use MySQL or Oracle or other change name behind Use.
   optionsBuilder.UseSqlServer(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
}*/
        public DbSet<BlogModel> Blog { get; set; }
    }
}
