using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BKIICT_POS_Management.DatabaseContext;
using BKIICT_POS_Management.Models;
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
            GetBarCode();
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
        private string GetBarCode()
        {
            Random number = new Random();
            var l = new Organization();
            l.Code = number.Next(100, 200).ToString();
            string b = l.Code;
            Bitmap a = new Bitmap(b.Length * 50, 60);
            using (Graphics graphic = Graphics.FromImage(a))
            {
                Font o = new System.Drawing.Font("IDAutomationHC39M Free Version", 10);
                PointF f = new PointF(2f, 2f);
                SolidBrush brush = new SolidBrush(Color.Black);
                SolidBrush white = new SolidBrush(Color.White);
                graphic.FillRectangle(white, 0, 0, a.Width, a.Height);
                graphic.DrawString("*" + b + "*", o, brush, f);
            }
            using (MemoryStream ms = new MemoryStream())
            {
                a.Save(ms, ImageFormat.Png);
                barCodePictureBox.Image = a;
                barCodePictureBox.Height = a.Height;
                barCodePictureBox.Width = a.Width;
            }
            return l.Code;
        }

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
            if (db.ExpenseItems.Count(c => c.Name == nameTextBox.Text) > 0)
                {
                    MessageBox.Show("Please Check yourName");
                    return;
                }
            else if (db.ExpenseItems.Count(c => c.Code == codeTextBox.Text) > 0)
                {
                    MessageBox.Show("Please Check yourName");
                    return;
                }
                
            expense = new ExpenseItem();
            expense.Name = nameTextBox.Text;
            expense.Code = GetBarCode();
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

        private int gvId;
        private void expenseCategoryDataGridView_DoubleClick(object sender, EventArgs e)
        {
             var db = new PosManagementDbContext();
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in expenseCategoryDataGridView.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                nameTextBox.Text = row.Cells[1].Value.ToString();
                codeTextBox.Visible = true;
                barCodePictureBox.Visible = false;
                codeTextBox.Text = row.Cells[2].Value.ToString();
                descriptionTextBox.Text = row.Cells[3].Value.ToString();
                gvId = expenseCategoryDataGridView.CurrentRow.Index;

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var db = new PosManagementDbContext();
            string searchText = textBox1.Text;

            var organizationInfo = (from exItem in db.ExpenseItems
                                    where (exItem.Name.Contains(searchText) || exItem.Code.Contains(searchText))
                                    select exItem).ToList();
            expenseCategoryDataGridView.DataSource = organizationInfo;

        }

        private void nameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            int y = Convert.ToInt32(expenseCategoryDataGridView.CurrentRow.Cells["Id"].Value);
            var db = new PosManagementDbContext();
            var b = db.ExpenseItems.FirstOrDefault(c => c.Id == y);
            b.Name = nameTextBox.Text;
            b.Description = descriptionTextBox.Text;
            b.Code = codeTextBox.Text;
           
            bool update = db.SaveChanges() > 0;
            if (update)
            {
                MessageBox.Show("update");
            }
            else
            {
                MessageBox.Show("not updated");
            }

        }

      }

        
    }



