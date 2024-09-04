using authTask.Models;
using Microsoft.EntityFrameworkCore;

namespace authTask.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=authTask;Trusted_Connection=true;TrustServerCertificate=true");
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
