namespace ERPProject.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class edsa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reminders",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(),
                    Description = c.String(),
                    AddingDate = c.DateTime(nullable: false),
                    RemindDate = c.DateTime(nullable: false),
                    EmployeeId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Reminders", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Reminders", new[] { "EmployeeId" });
            DropTable("dbo.Reminders");
        }
    }
}
