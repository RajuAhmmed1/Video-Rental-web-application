namespace MyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyental : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rentals", "DateRented");
            DropColumn("dbo.Rentals", "DateReturned");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "DateReturned", c => c.DateTime());
            AddColumn("dbo.Rentals", "DateRented", c => c.DateTime(nullable: false));
        }
    }
}
