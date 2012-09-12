namespace ModelTest.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DontKnow : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.users", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.users", "UserName");
        }
    }
}
