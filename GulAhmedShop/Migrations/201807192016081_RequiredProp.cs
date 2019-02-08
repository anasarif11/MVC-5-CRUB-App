namespace GulAhmedShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredProp : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WomenDresses", "dressName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.WomenDresses", "year", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WomenDresses", "year", c => c.String());
            AlterColumn("dbo.WomenDresses", "dressName", c => c.String(maxLength: 200));
        }
    }
}
