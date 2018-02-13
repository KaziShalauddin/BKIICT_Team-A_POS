namespace BKIICT_POS_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExpenseCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExpenseItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        Description = c.String(),
                        ExpenseCategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExpenseCategories", t => t.ExpenseCategoryId)
                .Index(t => t.ExpenseCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExpenseItems", "ExpenseCategoryId", "dbo.ExpenseCategories");
            DropIndex("dbo.ExpenseItems", new[] { "ExpenseCategoryId" });
            DropTable("dbo.ExpenseItems");
            DropTable("dbo.ExpenseCategories");
        }
    }
}
