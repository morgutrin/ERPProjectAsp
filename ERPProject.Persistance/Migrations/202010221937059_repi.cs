namespace ERPProject.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class repi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderRows", "OrderId", c => c.Int(nullable: true));
            CreateIndex("dbo.OrderRows", "OrderId");
            AddForeignKey("dbo.OrderRows", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.OrderRows", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderRows", new[] { "OrderId" });
            DropColumn("dbo.OrderRows", "OrderId");
        }
    }
}
