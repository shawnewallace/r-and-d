namespace ModelTest.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeNameAndEmailAddressNotRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.attendees", "FirstName", c => c.String());
            AlterColumn("dbo.attendees", "LastName", c => c.String());
            AlterColumn("dbo.attendees", "EmailAddress", c => c.String());
            AlterColumn("dbo.users", "FirstName", c => c.String());
            AlterColumn("dbo.users", "LastName", c => c.String());
            AlterColumn("dbo.users", "EmailAddress", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.users", "EmailAddress", c => c.String(nullable: false));
            AlterColumn("dbo.users", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.users", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.attendees", "EmailAddress", c => c.String(nullable: false));
            AlterColumn("dbo.attendees", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.attendees", "FirstName", c => c.String(nullable: false));
        }
    }
}
