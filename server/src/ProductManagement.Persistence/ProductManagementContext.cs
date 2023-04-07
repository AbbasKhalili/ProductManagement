using ProductManagement.Domain.Categories;
using ProductManagement.Domain.Products;
using ProductManagement.Persistence.Mappings;

namespace ProductManagement.Persistence
{
    public class ProductManagementContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ProductManagementContext(DbContextOptions<ProductManagementContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductMap).Assembly);
        }
    }
}