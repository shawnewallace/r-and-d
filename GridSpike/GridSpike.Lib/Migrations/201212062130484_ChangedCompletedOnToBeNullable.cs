namespace GridSpike.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedCompletedOnToBeNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.queued_tests", "completed_on", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.queued_tests", "completed_on", c => c.DateTime(nullable: false));
        }
    }
}
