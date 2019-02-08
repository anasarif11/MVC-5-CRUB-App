namespace GulAhmedShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesInWomenDress : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WomenDresses", "dressName", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WomenDresses", "dressName", c => c.String());
        }
    }
}
