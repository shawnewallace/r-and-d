namespace UnitTestResultsImporter.Console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeParentNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TestRuns", "TestRunId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TestRuns", "TestRunId", c => c.Int(nullable: false));
        }
    }
}
