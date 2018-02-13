namespace BKIICT_POS_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Organization_Outlet_Employee_Party_Classes_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 150),
                        Code = c.String(maxLength: 8),
                        StartDate = c.DateTime(storeType: "date"),
                        Img = c.Binary(),
                        ContactNo = c.String(maxLength: 12),
                        Email = c.String(maxLength: 150),
                        EmergencyContactNo = c.String(maxLength: 12),
                        NID = c.String(maxLength: 50),
                        FathersName = c.String(maxLength: 100),
                        MothersName = c.String(maxLength: 100),
                        PresentAddress = c.String(maxLength: 100),
                        PermanentAddress = c.String(maxLength: 100),
                        OutletId = c.Int(),
                        OrganizationId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId)
                .ForeignKey("dbo.Outlets", t => t.OutletId)
                .Index(t => t.OutletId)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 150),
                        Code = c.String(),
                        ContactNo = c.String(maxLength: 12),
                        Logo = c.Binary(),
                        Address = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Outlets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 150),
                        Code = c.String(),
                        ContactNo = c.String(maxLength: 12),
                        Logo = c.Binary(),
                        Address = c.String(maxLength: 150),
                        OrganizationId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.Parties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 150),
                        Code = c.String(maxLength: 8),
                        ContactNo = c.String(maxLength: 12),
                        Email = c.String(maxLength: 150),
                        Img = c.Binary(),
                        Address = c.String(maxLength: 100),
                        PartyType = c.String(),
                        OutletId = c.Int(),
                        OrganizationId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId)
                .ForeignKey("dbo.Outlets", t => t.OutletId)
                .Index(t => t.OutletId)
                .Index(t => t.OrganizationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parties", "OutletId", "dbo.Outlets");
            DropForeignKey("dbo.Parties", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Outlets", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Employees", "OutletId", "dbo.Outlets");
            DropForeignKey("dbo.Employees", "OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Parties", new[] { "OrganizationId" });
            DropIndex("dbo.Parties", new[] { "OutletId" });
            DropIndex("dbo.Outlets", new[] { "OrganizationId" });
            DropIndex("dbo.Employees", new[] { "OrganizationId" });
            DropIndex("dbo.Employees", new[] { "OutletId" });
            DropTable("dbo.Parties");
            DropTable("dbo.Outlets");
            DropTable("dbo.Organizations");
            DropTable("dbo.Employees");
        }
    }
}
