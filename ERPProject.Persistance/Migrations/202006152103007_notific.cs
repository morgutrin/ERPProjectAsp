namespace ERPProject.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notific : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "IsNotificationSended", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "IsNotificationSended");
        }
    }
}
