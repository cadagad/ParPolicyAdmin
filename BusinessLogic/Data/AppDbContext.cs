using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;


using BusinessLogic.Models;
using System.Data.Entity;


namespace BusinessLogic.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=DefaultConnection")
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<PolicyFeed> PolicyFeeds { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<Policy> Policy { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasIndex(p => new { p.Name })
                .IsUnique();
        }
    }
}
