namespace UnitTestResultsImporter.Console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Two : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestRuns", "NumberOfTests", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestRuns", "NumberOfTests");
        }
    }
}
