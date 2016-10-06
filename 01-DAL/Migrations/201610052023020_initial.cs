namespace _01_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subcategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Birthdate = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceNumber = c.Guid(nullable: false),
                        TotalAmount = c.Double(nullable: false),
                        InvoiceDate = c.DateTime(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.InvoiceLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        InvoiceId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Subtotal = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId)
                .Index(t => t.InvoiceId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        SubcategoryId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subcategories", t => t.SubcategoryId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.SubcategoryId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Rolename = c.String(),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAccounts", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Products", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Invoices", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.InvoiceLines", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.InvoiceLines", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "SubcategoryId", "dbo.Subcategories");
            DropForeignKey("dbo.Subcategories", "CategoryId", "dbo.Categories");
            DropIndex("dbo.UserAccounts", new[] { "EmployeeId" });
            DropIndex("dbo.Products", new[] { "EmployeeId" });
            DropIndex("dbo.Products", new[] { "SubcategoryId" });
            DropIndex("dbo.InvoiceLines", new[] { "ProductId" });
            DropIndex("dbo.InvoiceLines", new[] { "InvoiceId" });
            DropIndex("dbo.Invoices", new[] { "EmployeeId" });
            DropIndex("dbo.Subcategories", new[] { "CategoryId" });
            DropTable("dbo.UserAccounts");
            DropTable("dbo.Products");
            DropTable("dbo.InvoiceLines");
            DropTable("dbo.Invoices");
            DropTable("dbo.Employees");
            DropTable("dbo.Subcategories");
            DropTable("dbo.Categories");
        }
    }
}
