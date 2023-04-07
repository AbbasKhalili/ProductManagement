using ProductManagement.Domain.Categories;

namespace ProductManagement.Persistence.Mappings
{
    internal class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(a => a.SurrogateKey).HasColumnName("SurrogateKey");
            builder.Property(a => a.Title).HasColumnName("Name");
            builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(a => a.LastModified).HasColumnName("LastModified");
            builder.Property(a => a.IsDeleted).HasColumnName("IsDeleted");
            builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");

            builder.HasMany(a => a.Products).WithOne(a => a.Category).HasForeignKey(a => a.CategoryId);
        }
    }
}
