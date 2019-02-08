namespace GulAhmedShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOtherImagesInWomen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WomenDresses", "otherImage1Path", c => c.String());
            AddColumn("dbo.WomenDresses", "otherImage2Path", c => c.String());
            AddColumn("dbo.WomenDresses", "otherImage3Path", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WomenDresses", "otherImage3Path");
            DropColumn("dbo.WomenDresses", "otherImage2Path");
            DropColumn("dbo.WomenDresses", "otherImage1Path");
        }
    }
}
