namespace Deerfly_Patches.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class promoCode : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PromoCodes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                        PromotionalItemPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MinimumQualifyingPurchase = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PercentOffItem = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PercentOffOrder = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SpecialPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CodeStart = c.DateTime(nullable: false),
                        CodeEnd = c.DateTime(nullable: false),
                        PromotionalItem_ID = c.Int(),
                        SpecialPriceItem_ID = c.Int(),
                        WithPurchaseOf_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.PromotionalItem_ID)
                .ForeignKey("dbo.Products", t => t.SpecialPriceItem_ID)
                .ForeignKey("dbo.Products", t => t.WithPurchaseOf_ID)
                .Index(t => t.PromotionalItem_ID)
                .Index(t => t.SpecialPriceItem_ID)
                .Index(t => t.WithPurchaseOf_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PromoCodes", "WithPurchaseOf_ID", "dbo.Products");
            DropForeignKey("dbo.PromoCodes", "SpecialPriceItem_ID", "dbo.Products");
            DropForeignKey("dbo.PromoCodes", "PromotionalItem_ID", "dbo.Products");
            DropIndex("dbo.PromoCodes", new[] { "WithPurchaseOf_ID" });
            DropIndex("dbo.PromoCodes", new[] { "SpecialPriceItem_ID" });
            DropIndex("dbo.PromoCodes", new[] { "PromotionalItem_ID" });
            DropTable("dbo.PromoCodes");
        }
    }
}
