namespace Deerfly_Patches.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class product : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PlacedInCart = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Shipping = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CheckedOut = c.Boolean(nullable: false),
                        Item_ID = c.Int(),
                        Order_ID = c.Int(),
                        Purchaser_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.Item_ID)
                .ForeignKey("dbo.Orders", t => t.Order_ID)
                .ForeignKey("dbo.Customers", t => t.Purchaser_ID)
                .Index(t => t.Item_ID)
                .Index(t => t.Order_ID)
                .Index(t => t.Purchaser_ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Shipping = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImageURL = c.String(),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateOrdered = c.DateTime(nullable: false),
                        Subtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Shipping = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BillTo_ID = c.Int(),
                        Purchaser_ID = c.Int(),
                        ShipTo_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Addresses", t => t.BillTo_ID)
                .ForeignKey("dbo.Customers", t => t.Purchaser_ID)
                .ForeignKey("dbo.Addresses", t => t.ShipTo_ID)
                .Index(t => t.BillTo_ID)
                .Index(t => t.Purchaser_ID)
                .Index(t => t.ShipTo_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "Purchaser_ID", "dbo.Customers");
            DropForeignKey("dbo.Orders", "ShipTo_ID", "dbo.Addresses");
            DropForeignKey("dbo.Orders", "Purchaser_ID", "dbo.Customers");
            DropForeignKey("dbo.OrderDetails", "Order_ID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "BillTo_ID", "dbo.Addresses");
            DropForeignKey("dbo.OrderDetails", "Item_ID", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "ShipTo_ID" });
            DropIndex("dbo.Orders", new[] { "Purchaser_ID" });
            DropIndex("dbo.Orders", new[] { "BillTo_ID" });
            DropIndex("dbo.OrderDetails", new[] { "Purchaser_ID" });
            DropIndex("dbo.OrderDetails", new[] { "Order_ID" });
            DropIndex("dbo.OrderDetails", new[] { "Item_ID" });
            DropTable("dbo.Orders");
            DropTable("dbo.Products");
            DropTable("dbo.OrderDetails");
        }
    }
}
