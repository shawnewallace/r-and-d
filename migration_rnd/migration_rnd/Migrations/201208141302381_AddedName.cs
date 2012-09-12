namespace migration_rnd.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddedName : DbMigration
    {
        public override void Up()
        {
            AddColumn("MyThings", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("MyThings", "Name");
        }
    }
}
