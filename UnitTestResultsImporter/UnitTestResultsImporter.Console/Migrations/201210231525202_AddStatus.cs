namespace UnitTestResultsImporter.Console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestRuns", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestRuns", "Status");
        }
    }
}
