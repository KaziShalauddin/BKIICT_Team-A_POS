using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BKIICT_POS_Management.DatabaseContext;

namespace BKIICT_POS_Management.Models.Expense
{
    public class ExpenseCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int RootId  { get; set; }
        public int ChildId { get; set; }


        public List<ExpenseItem> ExpenseItems { get; set; }

        private PosManagementDbContext _posManagementDb;

        public int CreateExpenseCategory(int rootId,int childId,string name, string code,string description)
        {
            if(_posManagementDb==null)
            { 
           _posManagementDb =new PosManagementDbContext();
            }

            ExpenseCategory expenseCategory =new ExpenseCategory();

            expenseCategory.RootId = rootId;
            expenseCategory.ChildId = childId;
            expenseCategory.Name = name;
            expenseCategory.Code = code;
            expenseCategory.Description = description;

            _posManagementDb.ExpenseCategories.Add(expenseCategory);

           int rowAffected= _posManagementDb.SaveChanges();
            if (rowAffected > 0)
            {
                return rowAffected;
            }
            return 0;
        }
    }
}
