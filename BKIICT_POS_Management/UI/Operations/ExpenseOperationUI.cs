using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BKIICT_POS_Management.DatabaseContext;
using BKIICT_POS_Management.Models.Expense;

namespace BKIICT_POS_Management.UI
{
    public partial class ExpenseOperationUi : Form
    {
        public ExpenseOperationUi()
        {
            InitializeComponent();
            GetExpenseItem();
            GetOutlet();
            GetEmployee(id);
        }
        private void GetOutlet()
        {
            outletComboBox.ValueMember = "Id";
            outletComboBox.DisplayMember = "Name";
            outletComboBox.DataSource = db.Outlets.ToList();
        }

        private void GetEmployee(int id)
        {
            employeeComboBox.ValueMember = "Id";
            employeeComboBox.DisplayMember = "Name";
            employeeComboBox.DataSource = db.Employees.Where(o => o.OutletId == id).ToList();

        }


        
        private decimal GetTotalPrice()
        {
           var  totalPrice = db.ExpenseDetailses.Where(o => o.ExpenseInfoId == _maxExpenseInfoId).Sum(o => o.LineTotal);

            totalLabel.Text = totalPrice.ToString();

            return Convert.ToDecimal(totalPrice) ;
           

        }

        private void GetExpenseDetails()
        {
            expenseDetailsDataGridView.DataSource =
                db.ExpenseDetailses.Where(o => o.ExpenseInfoId == _maxExpenseInfoId)
                .Select(o => new { o.Id, o.ExpenseCode, o.Description, o.Quantity, o.Amount, o.LineTotal })
                .ToList();
        }
       
        private PosManagementDbContext db = new PosManagementDbContext();
        private ExpenseInfo expenseInfo;
        private ExpenseDetails expenseDetails;
        private void GetExpenseItem()
        {
            expenseItemComboBox.ValueMember = "Id";
            expenseItemComboBox.DisplayMember = "Name";
            expenseItemComboBox.DataSource = db.ExpenseItems.ToList();
        }

        private void addButton_Click(object sender, EventArgs e)
        {


            //Expense Details
            int id;
            bool result = int.TryParse(expenseItemComboBox.SelectedValue.ToString(), out id);

            expenseDetails = new ExpenseDetails();
            expenseDetails.ExpenseCode = id.ToString();
            expenseDetails.Quantity = Convert.ToInt32(qtyTextBox.Text);
            expenseDetails.Description = descriptionTextBox.Text;
            expenseDetails.Amount = Convert.ToDouble(amountTextBox.Text);

            expenseDetails.LineTotal = expenseDetails.Quantity * expenseDetails.Amount;
            expenseDetails.ExpenseInfoId = _maxExpenseInfoId;

            db.ExpenseDetailses.Add(expenseDetails);
            int n = db.SaveChanges();
            if (n > 0)
            {
                MessageBox.Show("Saved!");
                GetExpenseDetails();
                GetTotalPrice();
            }
            else
            {
                MessageBox.Show("Not saved!");
            }

        }

        private int _maxExpenseInfoId;
        private void GetMaxExpenseInfoId()
        {
            _maxExpenseInfoId = db.ExpenseInfos.Max(o => o.Id);

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            GetExpenseFinalResult();
        }

        private void GetExpenseFinalResult()
        {
            outletLabel.Text = outletComboBox.Text;
            employeeLabel.Text = employeeComboBox.Text;
            dateLabel.Text = expenseDateTimePicker.Value.ToShortDateString();
        }

        int outletId;
        private void GetOutletId()
        {
            bool outletResult = int.TryParse(outletComboBox.SelectedValue.ToString(), out outletId);
        }


        int employeeId;
        private void GetEmployeeId()
        {
            bool employeeResult = int.TryParse(employeeComboBox.SelectedValue.ToString(), out employeeId);
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            //expenseInfoGroupBox.Visible = false;

            //Expense Info
            GetOutletId();
            GetEmployeeId();

            expenseInfo = new ExpenseInfo();
            expenseInfo.OutletId = outletId;
            expenseInfo.EmployeeId = employeeId;
            expenseInfo.ExpenseDate = expenseDateTimePicker.Value;
            db.ExpenseInfos.Add(expenseInfo);
            int info = db.SaveChanges();
            if (info > 0)
            {
                MessageBox.Show("Info Saved!");
                GetMaxExpenseInfoId();
                // GetExpenseInfo();
               expenseDetailsGroupBox.Enabled = true;


            }
            else
            {
                MessageBox.Show("Info Not saved!");
            }
        }

        private void GetExpenseInfo()
        {
            var list = db.Outlets.Where(o => o.Id == id).Select(o => o.Name).ToList();
            employeeLabel.Text = list.ToString();
        }

        private void nextButton2_Click(object sender, EventArgs e)
        {
            //expenseSummaryGroupBox.Enabled = true;
            GetTotalPrice();
           
        }

        int id;

        private void outletComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool result = int.TryParse(outletComboBox.SelectedValue.ToString(), out id);

            GetEmployee(id);


        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            GetMaxExpenseInfoId();
           
            var due = db.ExpenseInfos.First(o=>o.Id==_maxExpenseInfoId);
            if (due != null)
            {
               
               due.ExpenseDue =Convert.ToDecimal(dueTextBox.Text);
                due.ExpenseTotal = GetTotalPrice();
                db.SaveChanges();
               
            }
            GetExpenseFinalResult();
            GetExpenseDetailsFinal();
            totalPriceLabel.Text = GetTotalPrice().ToString() + " tk";


        }
        private void GetExpenseDetailsFinal()
        {
            var slCol = new DataGridViewTextBoxColumn();
            slCol.Name = "Sl No.";
            finalDataGridView.Columns.Add(slCol);
            var expenseDetailsList = db.ExpenseDetailses.Where(o => o.ExpenseInfoId == _maxExpenseInfoId)
                 .Select(o => new {  o.ExpenseCode, o.Description, o.Quantity, o.Amount, o.LineTotal })
                 .ToList();
            finalDataGridView.DataSource = expenseDetailsList;


        }

        private void finalDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.finalDataGridView.Rows[e.RowIndex].Cells["Sl No."].Value = (e.RowIndex + 1).ToString();
        }
    }
}
