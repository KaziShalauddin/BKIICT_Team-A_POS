using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BKIICT_POS_Management.UI.Operations
{
    public partial class OperationsWelcomeUi : Form
    {
        public OperationsWelcomeUi()
        {
            InitializeComponent();
        }

        private void purchaseFormButton_Click(object sender, EventArgs e)
        {
            PurchaseOperationUi purchaseOperation=new PurchaseOperationUi();
            purchaseOperation.Show();
        }

        private void salesFormButton_Click(object sender, EventArgs e)
        {
            SalesOperationUi salesOperation=new SalesOperationUi();
            salesOperation.Show();
        }

        private void expenseFormButton_Click(object sender, EventArgs e)
        {
            ExpenseOperationUi expenseOperation=new ExpenseOperationUi();
            expenseOperation.Show();
        }
    }
}
