namespace ERPProject.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class eluwina : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Code = c.String(),
                    ContractorId = c.Int(nullable: false),
                    EmployeeId = c.Int(nullable: false),
                    CreationDate = c.DateTime(nullable: false),
                    RealizationDate = c.DateTime(nullable: false),
                    Status = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contractors", t => t.ContractorId, cascadeDelete: false)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: false)
                .Index(t => t.ContractorId)
                .Index(t => t.EmployeeId);

            CreateTable(
                "dbo.OrderRows",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    ArticleId = c.Int(nullable: false),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Amount = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.ArticleId);

            AddColumn("dbo.ExternalReceipts", "OrderId", c => c.Int(nullable: false));
            AddColumn("dbo.ExternalReleases", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.ExternalReceipts", "OrderId");
            CreateIndex("dbo.ExternalReleases", "OrderId");
            AddForeignKey("dbo.ExternalReceipts", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ExternalReleases", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.OrderRows", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.ExternalReleases", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.ExternalReceipts", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Orders", "ContractorId", "dbo.Contractors");
            DropIndex("dbo.OrderRows", new[] { "ArticleId" });
            DropIndex("dbo.ExternalReleases", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "EmployeeId" });
            DropIndex("dbo.Orders", new[] { "ContractorId" });
            DropIndex("dbo.ExternalReceipts", new[] { "OrderId" });
            DropColumn("dbo.ExternalReleases", "OrderId");
            DropColumn("dbo.ExternalReceipts", "OrderId");
            DropTable("dbo.OrderRows");
            DropTable("dbo.Orders");
        }
    }
}
