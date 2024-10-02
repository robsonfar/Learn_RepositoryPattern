using Learn_RepositoryPattern.Model;
using Microsoft.EntityFrameworkCore;

namespace Learn_RepositoryPattern.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // Create Table
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            // Seed Table
            modelBuilder.Entity<ProductType>().HasData(
                new ProductType { Id = 1, Name = "Type 1" }
                , new ProductType { Id = 2, Name = "Type 2" }
                , new ProductType { Id = 3, Name = "Type 3" }
                );
        }

    }
}
