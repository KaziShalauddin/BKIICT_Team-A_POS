using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BKIICT_POS_Management.UI.ReportUI
{
    public partial class ReportWelcomeUi : Form
    {
        public ReportWelcomeUi()
        {
            InitializeComponent();
        }

        private void purchaseReportFormButton_Click(object sender, EventArgs e)
        {
            PurchaseReportUi purchaseReport=new PurchaseReportUi();
            purchaseReport.Show();
        }

        private void salesReportFormButton_Click(object sender, EventArgs e)
        {
            SalesReportUi salesReport=new SalesReportUi();
            salesReport.Show();
        }

        private void stockReportFormButton_Click(object sender, EventArgs e)
        {
            StockReportUi stockReport=new StockReportUi();
            stockReport.Show();
        }

        private void incomeReportFormButton_Click(object sender, EventArgs e)
        {
            IncomeReportUi incomeReport=new IncomeReportUi();
            incomeReport.Show();

        }

        private void expenseReportFormButton_Click(object sender, EventArgs e)
        {
            ExpenseReportUi expenseReport=new ExpenseReportUi();
            expenseReport.Show();
        }
    }
}
