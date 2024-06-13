using Microsoft.EntityFrameworkCore;
using MNODotNETCORE.RestApi.Model;
using MNODotNETCORE.RestApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNODotNETCORE.RestApi.Databases
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
