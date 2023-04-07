global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagement.Domain.Products;

namespace ProductManagement.Persistence.Mappings
{
    internal class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(a => a.SurrogateKey).HasColumnName("SurrogateKey");
            builder.Property(a => a.Name).HasColumnName("Name");
            builder.Property(a => a.Weight).HasColumnName("Weight");
            builder.Property(a => a.Enabled).HasColumnName("Enabled");
            builder.Property(a => a.ProductType).HasColumnName("ProductType");
            builder.Property(a => a.Description).HasColumnName("Description");
            builder.Property(a => a.CategoryId).HasColumnName("CategoryId");
            builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(a => a.LastModified).HasColumnName("LastModified");
            builder.Property(a => a.IsDeleted).HasColumnName("IsDeleted");
            builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");

            builder.HasOne(a => a.Category).WithMany(a => a.Products).HasForeignKey(a => a.CategoryId);
        }
    }
}
