using System;

namespace migration_rnd.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ChangedStuff : DbMigration
    {
        public override void Up()
        {
					Sql("UPDATE MyThings SET FirstName = 'N/A' WHERE FirstName IS NULL");
            AddColumn("MyThings", "CreatedDate", c => c.DateTime(nullable: true, defaultValueSql:"getdate()"));
            AlterColumn("MyThings", "FirstName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("MyThings", "FirstName", c => c.String());
            DropColumn("MyThings", "CreatedDate");
        }
    }
}
