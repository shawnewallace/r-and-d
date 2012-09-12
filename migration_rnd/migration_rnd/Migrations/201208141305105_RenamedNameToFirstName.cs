namespace migration_rnd.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RenamedNameToFirstName : DbMigration
    {
        public override void Up()
        {
            AddColumn("MyThings", "FirstName", c => c.String());
            DropColumn("MyThings", "Name");
        }
        
        public override void Down()
        {
            AddColumn("MyThings", "Name", c => c.String());
            DropColumn("MyThings", "FirstName");
        }
    }
}
