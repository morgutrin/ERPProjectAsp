namespace ERPProject.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class receipt : DbMigration
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArticleGroups", t => t.ArticleGroupId, cascadeDelete: true)
                .Index(t => t.ArticleGroupId);
            
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contractors", t => t.ContractorId, cascadeDelete: true)
                .Index(t => t.ContractorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExternalReceiptRows", "ExternalReceiptId", "dbo.ExternalReceipts");
            DropForeignKey("dbo.ExternalReceipts", "ContractorId", "dbo.Contractors");
            DropForeignKey("dbo.ExternalReceiptRows", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Articles", "ArticleGroupId", "dbo.ArticleGroups");
            DropIndex("dbo.ExternalReceipts", new[] { "ContractorId" });
            DropIndex("dbo.ExternalReceiptRows", new[] { "ExternalReceiptId" });
            DropIndex("dbo.ExternalReceiptRows", new[] { "ArticleId" });
            DropIndex("dbo.Articles", new[] { "ArticleGroupId" });
            DropTable("dbo.ExternalReceipts");
            DropTable("dbo.ExternalReceiptRows");
            DropTable("dbo.Articles");
            DropTable("dbo.ArticleGroups");
        }
    }
}
