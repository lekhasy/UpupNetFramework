namespace Upup.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProductShipDateApplied : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppConfigs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Key = c.Int(nullable: false),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Name_en = c.String(),
                        Description = c.String(),
                        Description_en = c.String(),
                        ImageUrl = c.String(),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                        MetaKeyword_en = c.String(),
                        MetaDescription_en = c.String(),
                        ParentCategory_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.ParentCategory_Id)
                .Index(t => t.ParentCategory_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Name_en = c.String(),
                        Summary = c.String(),
                        Summary_en = c.String(),
                        ImageUrl = c.String(),
                        PdfUrl = c.String(),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                        MetaKeyword_en = c.String(),
                        MetaDescription_en = c.String(),
                        Category_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.ProductVariants",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        VariantName = c.String(),
                        VariantCode = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OnHand = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cad2dUrl = c.String(),
                        Cad3dUrl = c.String(),
                        BrandName = c.String(),
                        Origin = c.String(),
                        Product_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.ProductShipDateApplies",
                c => new
                    {
                        ShipDateSettingID = c.Int(nullable: false),
                        ProductVariantID = c.Int(nullable: false),
                        ProductVariant_Id = c.Long(),
                        ShipDateSetting_Id = c.Long(),
                    })
                .PrimaryKey(t => new { t.ShipDateSettingID, t.ProductVariantID })
                .ForeignKey("dbo.ProductVariants", t => t.ProductVariant_Id)
                .ForeignKey("dbo.ShipDateSettings", t => t.ShipDateSetting_Id)
                .Index(t => t.ProductVariant_Id)
                .Index(t => t.ShipDateSetting_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        OrgName = c.String(),
                        DepartmentName = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Address3 = c.String(),
                        Address4 = c.String(),
                        PostalCode = c.String(),
                        Fax = c.String(),
                        Webiste = c.String(),
                        IndustryId = c.Int(),
                        ServiceId = c.Int(),
                        NumberOfDesigner = c.Int(),
                        NumberOfEmployee = c.Int(),
                        KnowByid = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PurchaseOrders",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Name_en = c.String(),
                        State = c.Int(nullable: false),
                        Customer_Id = c.String(maxLength: 128),
                        Customer_Id1 = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Customer_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Customer_Id1)
                .Index(t => t.Customer_Id)
                .Index(t => t.Customer_Id1);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.PostCategories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Name_en = c.String(),
                        Description = c.String(),
                        Description_en = c.String(),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                        MetaKeyword_en = c.String(),
                        MetaDescription_en = c.String(),
                        ParentCategory_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PostCategories", t => t.ParentCategory_Id)
                .Index(t => t.ParentCategory_Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Title_en = c.String(),
                        Content = c.String(),
                        Content_en = c.String(),
                        MetaKeyword = c.String(),
                        MetaDescription = c.String(),
                        MetaKeyword_en = c.String(),
                        MetaDescription_en = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                        Category_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PostCategories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.PurchaseOrderDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Quantity = c.Double(nullable: false),
                        Product_Id = c.Long(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.ShipDateSettings",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        QuantityOrderMax = c.Int(nullable: false),
                        TargetDateNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductShipDateApplies", "ShipDateSetting_Id", "dbo.ShipDateSettings");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PurchaseOrderDetails", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PurchaseOrderDetails", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Posts", "Category_Id", "dbo.PostCategories");
            DropForeignKey("dbo.PostCategories", "ParentCategory_Id", "dbo.PostCategories");
            DropForeignKey("dbo.PurchaseOrders", "Customer_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.PurchaseOrders", "Customer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductVariants", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.ProductShipDateApplies", "ProductVariant_Id", "dbo.ProductVariants");
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Categories", "ParentCategory_Id", "dbo.Categories");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PurchaseOrderDetails", new[] { "User_Id" });
            DropIndex("dbo.PurchaseOrderDetails", new[] { "Product_Id" });
            DropIndex("dbo.Posts", new[] { "Category_Id" });
            DropIndex("dbo.PostCategories", new[] { "ParentCategory_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.PurchaseOrders", new[] { "Customer_Id1" });
            DropIndex("dbo.PurchaseOrders", new[] { "Customer_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.ProductShipDateApplies", new[] { "ShipDateSetting_Id" });
            DropIndex("dbo.ProductShipDateApplies", new[] { "ProductVariant_Id" });
            DropIndex("dbo.ProductVariants", new[] { "Product_Id" });
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropIndex("dbo.Categories", new[] { "ParentCategory_Id" });
            DropTable("dbo.ShipDateSettings");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PurchaseOrderDetails");
            DropTable("dbo.Posts");
            DropTable("dbo.PostCategories");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.PurchaseOrders");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ProductShipDateApplies");
            DropTable("dbo.ProductVariants");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.AppConfigs");
        }
    }
}
