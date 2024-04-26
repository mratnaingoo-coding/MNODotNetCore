using Microsoft.EntityFrameworkCore;
using MNODotNetCore.ConsoleApp.Dtos;
using MNODotNetCore.ConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNODotNetCore.ConsoleApp.EFCoreExamples
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if you use MySQL or Oracle or other change name behind Use.
            optionsBuilder.UseSqlServer(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<BlogDto> Blog { get; set; }
    }
}
