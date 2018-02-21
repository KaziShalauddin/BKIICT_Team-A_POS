namespace BKIICT_POS_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpenseInfo_Added_ExpenseInfoId_PropertyAddedTo_ExpenseDetails_Class : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExpenseInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ExpenseDetails", "ExpenseInfoId", c => c.Int(nullable: false));
            CreateIndex("dbo.ExpenseDetails", "ExpenseInfoId");
            AddForeignKey("dbo.ExpenseDetails", "ExpenseInfoId", "dbo.ExpenseInfoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExpenseDetails", "ExpenseInfoId", "dbo.ExpenseInfoes");
            DropIndex("dbo.ExpenseDetails", new[] { "ExpenseInfoId" });
            DropColumn("dbo.ExpenseDetails", "ExpenseInfoId");
            DropTable("dbo.ExpenseInfoes");
        }
    }
}
