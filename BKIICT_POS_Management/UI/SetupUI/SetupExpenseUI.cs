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


namespace BKIICT_POS_Management.UI.SetupUI
{
    public partial class SetupExpenseUi : Form
    {
        public SetupExpenseUi()
        {
            InitializeComponent();
            GetExpenseCategory();
            GetAllExpenses();
        }

        private void GetAllExpenses()
        {
            var expenseItems = db.ExpenseItems.ToList();

            expenseCategoryDataGridView.DataSource =
                expenseItems.Select
                    (o => new { o.Id, ExpenseName = o.Name, o.Code, o.Description, ExpenseCategoryId = o.ExpenseCategory.Id, ExpenseCategoryName = o.ExpenseCategory.Name }).ToList();
        }


        private PosManagementDbContext db = new PosManagementDbContext();
        ExpenseItem expense;


        private void GetExpenseCategory()
        {
            //expense=new ExpenseCategory();
            expenseItemComboBox.ValueMember = "Id";
            expenseItemComboBox.DisplayMember = "Name";
            expenseItemComboBox.DataSource = db.ExpenseCategories.ToList();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            int id;
            bool result = int.TryParse(expenseItemComboBox.SelectedValue.ToString(), out id);

            expense = new ExpenseItem();
            expense.Name = nameTextBox.Text;
            expense.Code = codeTextBox.Text;
            expense.Description = descriptionTextBox.Text;
            expense.ExpenseCategoryId = id;

            db.ExpenseItems.Add(expense);

            int rowAffected = db.SaveChanges();
            if (rowAffected > 0)
            {
                MessageBox.Show("Saved!!");
                GetAllExpenses();
            }
            else
            {
                MessageBox.Show("Failed!!");
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string code = searchTextBox.Text;
            var expenseItems = db.ExpenseItems.ToList();

            expenseCategoryDataGridView.DataSource =
                expenseItems.Select(o => new { o.Id, o.Name, o.Code, o.Description })
                    .Where(o => o.Code == code).ToList();

        }

        
    }


}
