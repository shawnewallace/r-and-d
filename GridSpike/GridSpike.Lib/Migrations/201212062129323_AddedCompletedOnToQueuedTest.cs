namespace GridSpike.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCompletedOnToQueuedTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.queued_tests", "completed_on", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.queued_tests", "completed_on");
        }
    }
}
