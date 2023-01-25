namespace MyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "CustomerID", c => c.String(nullable: false));
            AddColumn("dbo.Rentals", "MovieID", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rentals", "MovieID");
            DropColumn("dbo.Rentals", "CustomerID");
        }
    }
}
