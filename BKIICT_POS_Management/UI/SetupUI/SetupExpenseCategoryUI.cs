﻿using System;
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
using    BKIICT_POS_Management.Models.Expense;

namespace BKIICT_POS_Management.UI.SetupUI
{
    public partial class SetupExpenseCategoryUi : Form
    {
        public SetupExpenseCategoryUi()
        {
            InitializeComponent();
            expenseRootCategoryComboBox.Visible = false;
            GetCode();
            GetAllExpenseCategories();
          

        }

       
        private void GetCode()
        {
            
            Random number = new Random();
            codeTextBox.Text = number.Next(100, 999).ToString();
        }

        private void GetAllExpenseCategories()
        {

            var expenseCategories = db.ExpenseCategories.ToList();
            expenseCategoryDataGridView.DataSource = expenseCategories;
        }

        private PosManagementDbContext db = new PosManagementDbContext();
        private ExpenseCategory expense;
        private int _rootId=0;
        private int _childId;


        //private void Get_Max_Id()
        //{
        //    var expenseCategories = db.ExpenseCategories.ToList();
        //    if (expenseCategories.Count == 0)
        //        return;
        //    var maxId = db.ExpenseCategories.Max(r => r.Id);
        //    _rootId = maxId + 1;
        //    _childId = 0;

        //}
        private void rootCategoryRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            expenseRootCategoryComboBox.Visible = false;

        }
        private void childCategoryRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            expenseRootCategoryComboBox.Visible = true;
          
            GetExpenseCategory();

        }
        private void GetExpenseCategory()
        {

            expenseRootCategoryComboBox.ValueMember = "Id";
            expenseRootCategoryComboBox.DisplayMember = "Name";
            expenseRootCategoryComboBox.DataSource = db.ExpenseCategories.ToList();
        }
        private void AddChildCategory()
        {
            var sameRoot = db.ExpenseCategories.Where(r => r.RootId == id).ToList();
            if (sameRoot.Count == 0)
            {
                _childId = 1;
                return;
            }
            var maxChildId = sameRoot.Max(r => r.ChildId);
            _childId = maxChildId + 1;
        }

        int id;
        private void expenseRootCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool result = int.TryParse(expenseRootCategoryComboBox.SelectedValue.ToString(), out id);

        }
        //private void Get_Max_ChildId()
        //{
        //    var sameRoot = db.ExpenseCategories.Where(r => r.RootId == _rootId);
        //    var maxChildId = sameRoot.Max(r => r.ChildId);
        //    _childId = maxChildId + 1;
        //}

       
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (db.ExpenseCategories.Count(c => c.Name == nameTextBox.Text) > 0)
                {
                    MessageBox.Show("Please Check yourName");
                    return;
                }else if (db.ExpenseCategories.Count(c => c.Code == codeTextBox.Text) > 0)
                {
                    MessageBox.Show("Please Check your Code");
                    return;
                }
                            
            
            if (rootCategoryRadioButton.Checked == true)
            {
                _rootId = 0;
                _childId = 0;
            }
            if (childCategoryRadioButton.Checked == true)
            {
                AddChildCategory();
                _rootId = id;
            }
            
            string name = nameTextBox.Text;
            string code = codeTextBox.Text;
            string description = descriptionTextBox.Text;

           
            expense =new ExpenseCategory();
           
            
            int rowAffected = expense.CreateExpenseCategory(_rootId,_childId,name, code, description);
            if (rowAffected > 0)
            {
                MessageBox.Show("Saved!");
                GetAllExpenseCategories();
                GetExpenseCategory();
                GetCode();
            }
            else
            {
                MessageBox.Show(" Not Saved! ");
            }
        }
        
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
<<<<<<< HEAD
=======

        private void addChildsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            expenseRootCategoryComboBox.Visible = false;
            addChildComboBox.Visible = true;
            GetExpenseCategory_Id();
        }

        private void GetExpenseCategory_Id()
        {
            addChildComboBox.DataSource = db.ExpenseCategories.ToList();
            addChildComboBox.ValueMember = "Id";
            addChildComboBox.DisplayMember = "Name";
        }

        private void AddChildCategory()
        {
            var sameRoot = db.ExpenseCategories.Where(r => r.RootId == _rootId).ToList();
            if (sameRoot.Count == 0)
            {
                _childId = 1;
                return;
            }
            var maxChildId = sameRoot.Max(r => r.ChildId);
            _childId = maxChildId + 1;
        }


        private void addChildComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;
            bool result = int.TryParse(addChildComboBox.SelectedValue.ToString(), out id);
            _rootId = id;
        }
>>>>>>> 1d0c2b911d41ee1b9d0628d34bfb0d4691bd05f5
        private void searchButton_Click(object sender, EventArgs e)
        {
            string code = searchTextBox.Text;
            var expenseCategories = db.ExpenseCategories.ToList();

            expenseCategoryDataGridView.DataSource =
                expenseCategories.Select(o => new { o.Id, o.Name, o.Code, o.Description })
                    .Where(o => o.Code == code).ToList();
        }
<<<<<<< HEAD
        //private void addChildsRadioButton_CheckedChanged(object sender, EventArgs e)
        //{
        //    expenseRootCategoryComboBox.Visible = false;
        //    addChildComboBox.Visible = true;
        //    GetExpenseCategory_Id();
        //}

        //private void GetExpenseCategory_Id()
        //{
        //    addChildComboBox.DataSource = db.ExpenseCategories.ToList();
        //    addChildComboBox.ValueMember = "Id";
        //    addChildComboBox.DisplayMember = "Name";
        //}



        //private void addChildComboBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int id;
        //    bool result = int.TryParse(addChildComboBox.SelectedValue.ToString(), out id);
        //    _rootId = id;
        //}

=======

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var db = new PosManagementDbContext();
            string searchText = textBox1.Text;

            var organizationInfo = (from expenceCatagory in db.ExpenseCategories
                                    where (expenceCatagory.Name.Contains(searchText) || expenceCatagory.Code.Contains(searchText))
                                    select expenceCatagory).ToList();
            expenseCategoryDataGridView.DataSource = organizationInfo;

        }

        private void nameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }
  
>>>>>>> 1d0c2b911d41ee1b9d0628d34bfb0d4691bd05f5
    }
}
