namespace ERPProject.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "IsActive");
        }
    }
}
