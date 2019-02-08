namespace GulAhmedShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConnetionofTbale : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.SeasonDresses");
            AddColumn("dbo.WomenDresses", "SeasonDressseasonId", c => c.Byte(nullable: false));
            AlterColumn("dbo.SeasonDresses", "seasonId", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.SeasonDresses", "seasonId");
            CreateIndex("dbo.WomenDresses", "SeasonDressseasonId");
            AddForeignKey("dbo.WomenDresses", "SeasonDressseasonId", "dbo.SeasonDresses", "seasonId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WomenDresses", "SeasonDressseasonId", "dbo.SeasonDresses");
            DropIndex("dbo.WomenDresses", new[] { "SeasonDressseasonId" });
            DropPrimaryKey("dbo.SeasonDresses");
            AlterColumn("dbo.SeasonDresses", "seasonId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.WomenDresses", "SeasonDressseasonId");
            AddPrimaryKey("dbo.SeasonDresses", "seasonId");
        }
    }
}
