namespace ERPProject.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class warehouse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Articles", "WarehouseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Articles", "WarehouseId");
            AddForeignKey("dbo.Articles", "WarehouseId", "dbo.Warehouses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "WarehouseId", "dbo.Warehouses");
            DropIndex("dbo.Articles", new[] { "WarehouseId" });
            DropColumn("dbo.Articles", "WarehouseId");
            DropTable("dbo.Warehouses");
        }
    }
}
