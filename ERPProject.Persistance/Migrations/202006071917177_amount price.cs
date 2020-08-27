namespace ERPProject.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class amountprice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExternalReleaseRows", "Amount", c => c.Int(nullable: false));
            AddColumn("dbo.ExternalReleaseRows", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExternalReleaseRows", "Price");
            DropColumn("dbo.ExternalReleaseRows", "Amount");
        }
    }
}
