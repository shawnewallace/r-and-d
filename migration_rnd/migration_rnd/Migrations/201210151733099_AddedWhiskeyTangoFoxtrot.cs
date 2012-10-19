namespace migration_rnd.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddedWhiskeyTangoFoxtrot : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "WhiskeyTangoFoxtrots",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("WhiskeyTangoFoxtrots");
        }
    }
}
