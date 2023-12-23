using APIDevelopmentUsingDapper.Model;
using Microsoft.EntityFrameworkCore;

namespace APIDevelopmentUsingDapper.App
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity mappings here if needed
            base.OnModelCreating(modelBuilder);
        }
    }
}
