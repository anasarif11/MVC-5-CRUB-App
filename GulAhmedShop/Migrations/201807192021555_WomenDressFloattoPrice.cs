namespace GulAhmedShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WomenDressFloattoPrice : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WomenDresses", "price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WomenDresses", "price", c => c.Double(nullable: false));
        }
    }
}
