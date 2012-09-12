namespace ModelTest.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEventAttendeeRelationship : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventAttendees",
                c => new
                    {
                        Event_Id = c.Int(nullable: false),
                        Attendee_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Event_Id, t.Attendee_Id })
                .ForeignKey("dbo.events", t => t.Event_Id, cascadeDelete: true)
                .ForeignKey("dbo.attendees", t => t.Attendee_Id, cascadeDelete: true)
                .Index(t => t.Event_Id)
                .Index(t => t.Attendee_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.EventAttendees", new[] { "Attendee_Id" });
            DropIndex("dbo.EventAttendees", new[] { "Event_Id" });
            DropForeignKey("dbo.EventAttendees", "Attendee_Id", "dbo.attendees");
            DropForeignKey("dbo.EventAttendees", "Event_Id", "dbo.events");
            DropTable("dbo.EventAttendees");
        }
    }
}
