using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.DBL
{
    public class DatabaseContainer : DbContext
    {
     public   DatabaseContainer(DbContextOptions<DatabaseContainer> options):base(options)
        {

        }
        public DbSet<Department> departments { get; set; }
        public DbSet<employee> employees { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<District> District { get; set; }



        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=.; database=DBnew ; integrated security = true;");
        //}

    }
}
