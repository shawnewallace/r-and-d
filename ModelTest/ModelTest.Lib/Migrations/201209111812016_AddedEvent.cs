namespace ModelTest.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEvent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        WhenCreated = c.DateTime(nullable: false),
                        WhenLastModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.events");
        }
    }
}
