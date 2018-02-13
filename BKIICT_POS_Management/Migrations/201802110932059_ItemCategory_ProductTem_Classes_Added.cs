namespace BKIICT_POS_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemCategory_ProductTem_Classes_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        Description = c.String(),
                        Image = c.Binary(),
                        RootId = c.Int(nullable: false),
                        ChildId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        Description = c.String(),
                        Image = c.Binary(),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ItemCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemCategories", t => t.ItemCategoryId, cascadeDelete: true)
                .Index(t => t.ItemCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductItems", "ItemCategoryId", "dbo.ItemCategories");
            DropIndex("dbo.ProductItems", new[] { "ItemCategoryId" });
            DropTable("dbo.ProductItems");
            DropTable("dbo.ItemCategories");
        }
    }
}
