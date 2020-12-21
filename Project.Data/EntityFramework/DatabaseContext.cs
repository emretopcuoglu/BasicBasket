using Microsoft.EntityFrameworkCore;
using Project.Data.Entities;
using Project.Data.EntityFramework.Seeds;

namespace Project.Data.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductSeed());
        }
    }
}
