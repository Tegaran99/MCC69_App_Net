using MCC69_App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC69_App.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> dbContext) : base(dbContext)
        {

        }
        //ketik ovveride on control spasi
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseLazyLoadingProxies();
        }
        public DbSet<Regions> Region { get; set; }
        public DbSet<Locations> Location { get; set; }
        public DbSet<Jobs> Job { get; set; }
        public DbSet<JobHistory> JobHistory { get; set; }
        public DbSet<Employees> Employee { get; set; }
        public DbSet<Departments> Department { get; set; }
        public DbSet<Countries> Country { get; set; }
        public DbSet<MCC69_App.Models.Login> Login { get; set; }
        public DbSet<MCC69_App.Models.User> User { get; set; }
        public DbSet<MCC69_App.Models.Token> Token { get; set; }

        /* public DbSet<User> User { get; set; }
         public DbSet<Role> Role { get; set; }
         public DbSet<UserRole> UserRole { get; set; }*/

    }
}