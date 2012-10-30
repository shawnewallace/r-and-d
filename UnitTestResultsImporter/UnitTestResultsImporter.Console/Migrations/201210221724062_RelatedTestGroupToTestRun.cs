namespace UnitTestResultsImporter.Console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelatedTestGroupToTestRun : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Duration = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TestRunId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TestRuns", t => t.TestRunId, cascadeDelete: true)
                .Index(t => t.TestRunId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.TestGroups", new[] { "TestRunId" });
            DropForeignKey("dbo.TestGroups", "TestRunId", "dbo.TestRuns");
            DropTable("dbo.TestGroups");
        }
    }
}
