namespace BKIICT_POS_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpenseInfo_Some_PropertyAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExpenseInfoes", "EmployeeId", c => c.Int());
            AddColumn("dbo.ExpenseInfoes", "ExpenseDate", c => c.DateTime(storeType: "date"));
            AddColumn("dbo.ExpenseInfoes", "OutletId", c => c.Int());
            AddColumn("dbo.ExpenseInfoes", "ExpenseTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ExpenseInfoes", "ExpenseDue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.ExpenseInfoes", "EmployeeId");
            CreateIndex("dbo.ExpenseInfoes", "OutletId");
            AddForeignKey("dbo.ExpenseInfoes", "EmployeeId", "dbo.Employees", "Id");
            AddForeignKey("dbo.ExpenseInfoes", "OutletId", "dbo.Outlets", "Id");
            DropColumn("dbo.ExpenseInfoes", "EmployeeName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExpenseInfoes", "EmployeeName", c => c.String());
            DropForeignKey("dbo.ExpenseInfoes", "OutletId", "dbo.Outlets");
            DropForeignKey("dbo.ExpenseInfoes", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.ExpenseInfoes", new[] { "OutletId" });
            DropIndex("dbo.ExpenseInfoes", new[] { "EmployeeId" });
            DropColumn("dbo.ExpenseInfoes", "ExpenseDue");
            DropColumn("dbo.ExpenseInfoes", "ExpenseTotal");
            DropColumn("dbo.ExpenseInfoes", "OutletId");
            DropColumn("dbo.ExpenseInfoes", "ExpenseDate");
            DropColumn("dbo.ExpenseInfoes", "EmployeeId");
        }
    }
}
