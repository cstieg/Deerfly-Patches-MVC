namespace Deerfly_Patches.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCustomerAddress : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Registered = c.DateTime(nullable: false),
                        LastVisited = c.DateTime(nullable: false),
                        TimesVisited = c.Int(nullable: false),
                        EmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Recipient = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                        Type = c.Int(nullable: false),
                        Owner_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.Owner_ID)
                .Index(t => t.Owner_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "Owner_ID", "dbo.Customers");
            DropIndex("dbo.Addresses", new[] { "Owner_ID" });
            DropTable("dbo.Addresses");
            DropTable("dbo.Customers");
        }
    }
}
