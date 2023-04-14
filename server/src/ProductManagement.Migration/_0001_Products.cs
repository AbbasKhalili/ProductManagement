global using FluentMigrator;

namespace ProductManagement.Migration
{
    [Migration(1)]
    public class _0001_Products : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Products")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("SurrogateKey").AsGuid()
                .WithColumn("Name").AsString()
                .WithColumn("Weight").AsDouble()
                .WithColumn("Enabled").AsBoolean()
                .WithColumn("ProductType").AsByte()
                .WithColumn("Description").AsString()
                .WithColumn("CategoryId").AsInt64()
                .WithColumn("CreatedDate").AsDateTime2()
                .WithColumn("LastModified").AsDateTime2()
                .WithColumn("IsDeleted").AsBoolean()
                .WithColumn("DeletedDate").AsDateTime2().Nullable();
        }
    }
}