namespace GridSpike.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBasicPropertiesToQueuedTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.queued_tests", "feature_name", c => c.String());
            AddColumn("dbo.queued_tests", "scenario_title", c => c.String());
            AddColumn("dbo.queued_tests", "target_environment", c => c.String());
            AddColumn("dbo.queued_tests", "selected_on", c => c.DateTime());
            AddColumn("dbo.queued_tests", "selected_by", c => c.String());
            AddColumn("dbo.queued_tests", "when_created", c => c.DateTime());
            AddColumn("dbo.queued_tests", "when_modified", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.queued_tests", "when_modified");
            DropColumn("dbo.queued_tests", "when_created");
            DropColumn("dbo.queued_tests", "selected_by");
            DropColumn("dbo.queued_tests", "selected_on");
            DropColumn("dbo.queued_tests", "target_environment");
            DropColumn("dbo.queued_tests", "scenario_title");
            DropColumn("dbo.queued_tests", "feature_name");
        }
    }
}
