namespace ModelTest.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelatedUsersToEventsAsOrganizers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.events", "Organizer_Id", c => c.Int());
            AddForeignKey("dbo.events", "Organizer_Id", "dbo.users", "Id");
            CreateIndex("dbo.events", "Organizer_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.events", new[] { "Organizer_Id" });
            DropForeignKey("dbo.events", "Organizer_Id", "dbo.users");
            DropColumn("dbo.events", "Organizer_Id");
        }
    }
}
