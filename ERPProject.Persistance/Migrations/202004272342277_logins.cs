namespace ERPProject.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class logins : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OperatorRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.OperatorRoles", "OperatorId", "dbo.Operators");
            DropForeignKey("dbo.Operators", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.OperatorRoles", new[] { "RoleId" });
            DropIndex("dbo.OperatorRoles", new[] { "OperatorId" });
            DropIndex("dbo.Operators", new[] { "EmployeeId" });
            DropTable("dbo.Roles");
            DropTable("dbo.OperatorRoles");
            DropTable("dbo.Operators");
        }
    }
}
