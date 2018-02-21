using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BKIICT_POS_Management.Models;
using BKIICT_POS_Management.Models.Expense;
using BKIICT_POS_Management.Models.Item;
using BKIICT_POS_Management.Models.ItemModels;

namespace BKIICT_POS_Management.DatabaseContext
{
    public class PosManagementDbContext:DbContext
    {
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Outlet> Outlets { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Party> Parties { get; set; }
        

        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<ExpenseItem> ExpenseItems { get; set; }
        public DbSet<ExpenseDetails> ExpenseDetailses { get; set; }
        public DbSet<ExpenseInfo> ExpenseInfos { get; set; }

        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
    }
}
