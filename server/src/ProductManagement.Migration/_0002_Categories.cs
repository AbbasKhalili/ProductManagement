namespace ProductManagement.Migration
{
    [Migration(2)]
    public class _0002_Categories : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Categories")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("SurrogateKey").AsGuid()
                .WithColumn("Name").AsString()
                .WithColumn("CreatedDate").AsDateTime2()
                .WithColumn("LastModified").AsDateTime2()
                .WithColumn("IsDeleted").AsBoolean()
                .WithColumn("DeletedDate").AsDateTime2().Nullable();
        }
    }
}