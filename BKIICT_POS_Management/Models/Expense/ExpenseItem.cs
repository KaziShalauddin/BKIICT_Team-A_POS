using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BKIICT_POS_Management.DatabaseContext;


namespace BKIICT_POS_Management.Models.Expense
{
    public class ExpenseItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public int? ExpenseCategoryId { get; set; }
        public ExpenseCategory ExpenseCategory { get; set; }

        private PosManagementDbContext posManagementDb;

        public bool CreateExpenseItem(string name, string code, string description, int expenseCategoryId)
        {
            if (posManagementDb == null)
            {
                posManagementDb = new PosManagementDbContext();
            }

            ExpenseItem expenseItem= new ExpenseItem();
            
            expenseItem.Name = name;
            expenseItem.Code = code;
            expenseItem.Description = description;
            expenseItem.ExpenseCategoryId =expenseCategoryId;

            posManagementDb.ExpenseItems.Add(expenseItem);
            return true;
        }
    }
}
