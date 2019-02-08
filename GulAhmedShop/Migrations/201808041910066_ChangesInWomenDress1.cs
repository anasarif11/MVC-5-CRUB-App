namespace GulAhmedShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesInWomenDress1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WomenDresses", "imagePath", c => c.String());
            AddColumn("dbo.WomenDresses", "numberInStock", c => c.Int(nullable: false));
            DropColumn("dbo.WomenDresses", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WomenDresses", "Image", c => c.Binary());
            DropColumn("dbo.WomenDresses", "numberInStock");
            DropColumn("dbo.WomenDresses", "imagePath");
        }
    }
}
