namespace BKIICT_POS_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PartyModel_propertyAdded_Customer_Supplier_IsDeleted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parties", "Customer", c => c.Boolean(nullable: false));
            AddColumn("dbo.Parties", "Supplier", c => c.Boolean(nullable: false));
            AddColumn("dbo.Parties", "IsDeleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Parties", "PartyType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Parties", "PartyType", c => c.String());
            DropColumn("dbo.Parties", "IsDeleted");
            DropColumn("dbo.Parties", "Supplier");
            DropColumn("dbo.Parties", "Customer");
        }
    }
}
