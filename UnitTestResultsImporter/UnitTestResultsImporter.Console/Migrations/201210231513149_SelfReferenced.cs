namespace UnitTestResultsImporter.Console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SelfReferenced : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TestGroups", "TestRunId", "dbo.TestRuns");
            DropIndex("dbo.TestGroups", new[] { "TestRunId" });
            AddColumn("dbo.TestRuns", "TestRunId", c => c.Int(nullable: false));
            AddForeignKey("dbo.TestRuns", "TestRunId", "dbo.TestRuns", "Id");
            CreateIndex("dbo.TestRuns", "TestRunId");
            DropTable("dbo.TestGroups");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            DropIndex("dbo.TestRuns", new[] { "TestRunId" });
            DropForeignKey("dbo.TestRuns", "TestRunId", "dbo.TestRuns");
            DropColumn("dbo.TestRuns", "TestRunId");
            CreateIndex("dbo.TestGroups", "TestRunId");
            AddForeignKey("dbo.TestGroups", "TestRunId", "dbo.TestRuns", "Id", cascadeDelete: true);
        }
    }
}
