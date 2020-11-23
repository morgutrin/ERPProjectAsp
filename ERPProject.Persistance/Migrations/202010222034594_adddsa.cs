namespace ERPProject.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddsa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderRows", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderRows", new[] { "OrderId" });
            AlterColumn("dbo.OrderRows", "OrderId", c => c.Int());
            CreateIndex("dbo.OrderRows", "OrderId");
            AddForeignKey("dbo.OrderRows", "OrderId", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderRows", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderRows", new[] { "OrderId" });
            AlterColumn("dbo.OrderRows", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderRows", "OrderId");
            AddForeignKey("dbo.OrderRows", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
        }
    }
}
