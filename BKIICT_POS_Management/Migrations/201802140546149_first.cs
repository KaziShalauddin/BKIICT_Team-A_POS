namespace BKIICT_POS_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Organizations", "IsDelete");
            DropColumn("dbo.Outlets", "delete");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Outlets", "delete", c => c.Boolean(nullable: false));
            AddColumn("dbo.Organizations", "IsDelete", c => c.Boolean(nullable: false));
        }
    }
}
