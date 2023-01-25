namespace MyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newone : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "Customer_ID", "dbo.Customers");
            DropForeignKey("dbo.Rentals", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Rentals", new[] { "Customer_ID" });
            DropIndex("dbo.Rentals", new[] { "Movie_Id" });
            DropColumn("dbo.Rentals", "Customer_ID");
            DropColumn("dbo.Rentals", "Movie_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "Movie_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Rentals", "Customer_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Rentals", "Movie_Id");
            CreateIndex("dbo.Rentals", "Customer_ID");
            AddForeignKey("dbo.Rentals", "Movie_Id", "dbo.Movies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rentals", "Customer_ID", "dbo.Customers", "ID", cascadeDelete: true);
        }
    }
}
