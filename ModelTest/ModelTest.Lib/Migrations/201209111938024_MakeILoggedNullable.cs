namespace ModelTest.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeILoggedNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.attendees", "WhenCreated", c => c.DateTime());
            AlterColumn("dbo.attendees", "WhenLastModified", c => c.DateTime());
            AlterColumn("dbo.events", "WhenCreated", c => c.DateTime());
            AlterColumn("dbo.events", "WhenLastModified", c => c.DateTime());
            AlterColumn("dbo.users", "WhenCreated", c => c.DateTime());
            AlterColumn("dbo.users", "WhenLastModified", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.users", "WhenLastModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.users", "WhenCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.events", "WhenLastModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.events", "WhenCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.attendees", "WhenLastModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.attendees", "WhenCreated", c => c.DateTime(nullable: false));
        }
    }
}
