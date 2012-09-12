namespace SelfReference.Web.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        Manager_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Employees", t => t.Manager_Id)
                .Index(t => t.Manager_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("Employees", new[] { "Manager_Id" });
            DropForeignKey("Employees", "Manager_Id", "Employees");
            DropTable("Employees");
        }
    }
}
