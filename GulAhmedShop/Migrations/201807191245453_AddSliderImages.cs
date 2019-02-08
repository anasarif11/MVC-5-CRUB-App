namespace GulAhmedShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSliderImages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SliderImages",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        image = c.Binary(),
                        imageHeading = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SliderImages");
        }
    }
}
