namespace ERPProject.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcontractors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactPersons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContractorId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contractors", t => t.ContractorId, cascadeDelete: true)
                .Index(t => t.ContractorId);
            
            CreateTable(
                "dbo.Contractors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        TIN = c.String(),
                        CountrySign = c.Int(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        PostCode = c.String(),
                        Country = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactPersons", "ContractorId", "dbo.Contractors");
            DropIndex("dbo.ContactPersons", new[] { "ContractorId" });
            DropTable("dbo.Contractors");
            DropTable("dbo.ContactPersons");
        }
    }
}
