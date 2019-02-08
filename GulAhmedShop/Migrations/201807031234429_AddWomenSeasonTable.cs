namespace GulAhmedShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWomenSeasonTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SeasonDresses",
                c => new
                    {
                        seasonId = c.Int(nullable: false, identity: true),
                        seasonName = c.String(),
                    })
                .PrimaryKey(t => t.seasonId);
            
            CreateTable(
                "dbo.WomenDresses",
                c => new
                    {
                        dressId = c.Int(nullable: false, identity: true),
                        dressName = c.String(),
                        price = c.Double(nullable: false),
                        year = c.String(),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.dressId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WomenDresses");
            DropTable("dbo.SeasonDresses");
        }
    }
}
