namespace INVOICE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.InvoiceDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        InviceNumber = c.String(),
                        Date = c.DateTime(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.ProductInvoiceDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        InvoiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InvoiceDetails", t => t.InvoiceID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.InvoiceID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false, maxLength: 1000),
                        Cost = c.Double(nullable: false),
                        ImagPath = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductInvoiceDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductInvoiceDetails", "InvoiceID", "dbo.InvoiceDetails");
            DropForeignKey("dbo.InvoiceDetails", "CustomerID", "dbo.Customers");
            DropIndex("dbo.ProductInvoiceDetails", new[] { "InvoiceID" });
            DropIndex("dbo.ProductInvoiceDetails", new[] { "ProductID" });
            DropIndex("dbo.InvoiceDetails", new[] { "CustomerID" });
            DropTable("dbo.Products");
            DropTable("dbo.ProductInvoiceDetails");
            DropTable("dbo.InvoiceDetails");
            DropTable("dbo.Customers");
        }
    }
}
