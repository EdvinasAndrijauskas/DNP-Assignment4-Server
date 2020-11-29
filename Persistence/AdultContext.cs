using Assignment_4___Server.Models;

using Microsoft.EntityFrameworkCore;
using Models;

namespace Assignment3.Persistance
{
    public class AdultContext : DbContext
    {
        public DbSet<Adult> Adults { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // name of database
            optionsBuilder.UseSqlite("Data Source = Adults.db");
        }
    }
}