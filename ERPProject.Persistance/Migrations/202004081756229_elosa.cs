namespace ERPProject.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class elosa : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inventory", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Inventory", new[] { "EmployeeId" });
            DropTable("dbo.Inventory");
            DropTable("dbo.Employees");
        }
    }
}
