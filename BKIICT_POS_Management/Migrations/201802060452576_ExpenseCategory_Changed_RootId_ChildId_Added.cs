namespace BKIICT_POS_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpenseCategory_Changed_RootId_ChildId_Added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExpenseCategories", "RootId", c => c.Int(nullable: false));
            AddColumn("dbo.ExpenseCategories", "ChildId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExpenseCategories", "ChildId");
            DropColumn("dbo.ExpenseCategories", "RootId");
        }
    }
}
