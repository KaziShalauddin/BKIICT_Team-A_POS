using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKIICT_POS_Management.Models.Expense
{
    public class ExpenseDetails
    {
        public int Id { get; set; }
        public string ExpenseCode { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }

        public double LineTotal { get; set; }

        public int ExpenseInfoId { get; set; }
        public ExpenseInfo ExpenseInfo { get; set; }
    }
}
