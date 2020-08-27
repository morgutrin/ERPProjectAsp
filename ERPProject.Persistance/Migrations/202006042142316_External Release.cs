namespace ERPProject.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExternalRelease : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArticleGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        Unit = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ArticleGroupId = c.Int(nullable: false),
                        WarehouseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArticleGroups", t => t.ArticleGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseId, cascadeDelete: true)
                .Index(t => t.ArticleGroupId)
                .Index(t => t.WarehouseId);
            
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactPersons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContractorId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contractors", t => t.ContractorId, cascadeDelete: true)
                .Index(t => t.ContractorId);
            
            CreateTable(
                "dbo.Contractors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        TIN = c.String(),
                        CountrySign = c.Int(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        PostCode = c.String(),
                        Country = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeNo = c.String(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        SecondName = c.String(),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FullName = c.String(),
                        Gender = c.String(),
                        ImageUrl = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        DateJoined = c.DateTime(nullable: false),
                        Email = c.String(),
                        IdDocumentNo = c.String(nullable: false, maxLength: 50),
                        PaymentMethod = c.Int(nullable: false),
                        Phone = c.String(),
                        Address = c.String(nullable: false, maxLength: 150),
                        City = c.String(nullable: false, maxLength: 50),
                        PostCode = c.String(nullable: false, maxLength: 9),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                        InventoryNumber = c.String(),
                        InventoryGroup = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Operators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.OperatorRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OperatorId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Operators", t => t.OperatorId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.OperatorId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExternalReceiptRows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticleId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Int(nullable: false),
                        ExternalReceiptId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .ForeignKey("dbo.ExternalReceipts", t => t.ExternalReceiptId, cascadeDelete: true)
                .Index(t => t.ArticleId)
                .Index(t => t.ExternalReceiptId);
            
            CreateTable(
                "dbo.ExternalReceipts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        ContractorId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contractors", t => t.ContractorId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.ContractorId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.ExternalReleaseRows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticleId = c.Int(nullable: false),
                        ExternalReleaseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .ForeignKey("dbo.ExternalReleases", t => t.ExternalReleaseId, cascadeDelete: true)
                .Index(t => t.ArticleId)
                .Index(t => t.ExternalReleaseId);
            
            CreateTable(
                "dbo.ExternalReleases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedOn = c.DateTime(nullable: false),
                        Code = c.String(),
                        CreatedById = c.Int(nullable: false),
                        ContractorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contractors", t => t.ContractorId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.CreatedById, cascadeDelete: true)
                .Index(t => t.CreatedById)
                .Index(t => t.ContractorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExternalReleaseRows", "ExternalReleaseId", "dbo.ExternalReleases");
            DropForeignKey("dbo.ExternalReleases", "CreatedById", "dbo.Employees");
            DropForeignKey("dbo.ExternalReleases", "ContractorId", "dbo.Contractors");
            DropForeignKey("dbo.ExternalReleaseRows", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.ExternalReceiptRows", "ExternalReceiptId", "dbo.ExternalReceipts");
            DropForeignKey("dbo.ExternalReceipts", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.ExternalReceipts", "ContractorId", "dbo.Contractors");
            DropForeignKey("dbo.ExternalReceiptRows", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.OperatorRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.OperatorRoles", "OperatorId", "dbo.Operators");
            DropForeignKey("dbo.Operators", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Inventory", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.ContactPersons", "ContractorId", "dbo.Contractors");
            DropForeignKey("dbo.Articles", "WarehouseId", "dbo.Warehouses");
            DropForeignKey("dbo.Articles", "ArticleGroupId", "dbo.ArticleGroups");
            DropIndex("dbo.ExternalReleases", new[] { "ContractorId" });
            DropIndex("dbo.ExternalReleases", new[] { "CreatedById" });
            DropIndex("dbo.ExternalReleaseRows", new[] { "ExternalReleaseId" });
            DropIndex("dbo.ExternalReleaseRows", new[] { "ArticleId" });
            DropIndex("dbo.ExternalReceipts", new[] { "EmployeeId" });
            DropIndex("dbo.ExternalReceipts", new[] { "ContractorId" });
            DropIndex("dbo.ExternalReceiptRows", new[] { "ExternalReceiptId" });
            DropIndex("dbo.ExternalReceiptRows", new[] { "ArticleId" });
            DropIndex("dbo.OperatorRoles", new[] { "RoleId" });
            DropIndex("dbo.OperatorRoles", new[] { "OperatorId" });
            DropIndex("dbo.Operators", new[] { "EmployeeId" });
            DropIndex("dbo.Inventory", new[] { "EmployeeId" });
            DropIndex("dbo.ContactPersons", new[] { "ContractorId" });
            DropIndex("dbo.Articles", new[] { "WarehouseId" });
            DropIndex("dbo.Articles", new[] { "ArticleGroupId" });
            DropTable("dbo.ExternalReleases");
            DropTable("dbo.ExternalReleaseRows");
            DropTable("dbo.ExternalReceipts");
            DropTable("dbo.ExternalReceiptRows");
            DropTable("dbo.Roles");
            DropTable("dbo.OperatorRoles");
            DropTable("dbo.Operators");
            DropTable("dbo.Inventory");
            DropTable("dbo.Employees");
            DropTable("dbo.Contractors");
            DropTable("dbo.ContactPersons");
            DropTable("dbo.Warehouses");
            DropTable("dbo.Articles");
            DropTable("dbo.ArticleGroups");
        }
    }
}
