namespace BKIICT_POS_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpenseDetails_Class_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExpenseDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExpenseCode = c.String(),
                        Quantity = c.Int(nullable: false),
                        Description = c.String(),
                        Amount = c.Double(nullable: false),
                        LineTotal = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ExpenseDetails");
        }
    }
}
