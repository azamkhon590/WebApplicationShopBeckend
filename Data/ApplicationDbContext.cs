using Microsoft.EntityFrameworkCore;
using WebApplicationBackend.Model;

namespace WebApplicationBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<UserApp> User { get; set; }
        public DbSet<Product> product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserApp>().ToTable("User");
        }
    }
}
