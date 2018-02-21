using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BKIICT_POS_Management.Models.Expense
{
   public class ExpenseInfo
    {
        public int Id { get; set; }
        //public string EmployeeName { get; set; }

        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime? ExpenseDate { get; set; }

        public int? OutletId { get; set; }
        public Outlet Outlet { get; set; }

        public decimal ExpenseTotal { get; set; }
        public decimal ExpenseDue { get; set; }

        private List<ExpenseDetails> expenseDetailses { get; set; }
    }
}
