namespace UnitTestResultsImporter.Console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestRuns", "Description", c => c.String());
            AddColumn("dbo.TestRuns", "Duration", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestRuns", "Duration");
            DropColumn("dbo.TestRuns", "Description");
        }
    }
}
