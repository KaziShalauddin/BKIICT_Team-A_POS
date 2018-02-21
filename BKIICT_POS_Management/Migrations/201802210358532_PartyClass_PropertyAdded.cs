namespace BKIICT_POS_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PartyClass_PropertyAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parties", "CustomerParty", c => c.String());
            AddColumn("dbo.Parties", "SupplierParty", c => c.String());
            AddColumn("dbo.Parties", "IsDeleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Parties", "PartyType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Parties", "PartyType", c => c.String());
            DropColumn("dbo.Parties", "IsDeleted");
            DropColumn("dbo.Parties", "SupplierParty");
            DropColumn("dbo.Parties", "CustomerParty");
        }
    }
}
