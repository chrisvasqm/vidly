using Microsoft.EntityFrameworkCore;

namespace Vidly.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppConfig.ConnectionString);
        }
    }
}