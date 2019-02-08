namespace GulAhmedShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesInSliderImages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SliderImages", "imagePath", c => c.String());
            DropColumn("dbo.SliderImages", "image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SliderImages", "image", c => c.Binary());
            DropColumn("dbo.SliderImages", "imagePath");
        }
    }
}
