namespace BKIICT_POS_Management.UI.SetupUI
{
    partial class SetupExpenseCategoryUi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.rootCategoryRadioButton = new System.Windows.Forms.RadioButton();
            this.childCategoryRadioButton = new System.Windows.Forms.RadioButton();
            this.expenseRootCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.expenseCategoryDataGridView = new System.Windows.Forms.DataGridView();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.codeTextBox = new System.Windows.Forms.TextBox();
            this.addChildsRadioButton = new System.Windows.Forms.RadioButton();
            this.addChildComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.expenseCategoryDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 28);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.label1.Size = new System.Drawing.Size(228, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Expense Category";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(133, 130);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(196, 20);
            this.nameTextBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Description";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(133, 220);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(196, 58);
            this.descriptionTextBox.TabIndex = 2;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(238, 290);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(91, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // rootCategoryRadioButton
            // 
            this.rootCategoryRadioButton.AutoSize = true;
            this.rootCategoryRadioButton.Location = new System.Drawing.Point(12, 67);
            this.rootCategoryRadioButton.Name = "rootCategoryRadioButton";
            this.rootCategoryRadioButton.Size = new System.Drawing.Size(93, 17);
            this.rootCategoryRadioButton.TabIndex = 4;
            this.rootCategoryRadioButton.TabStop = true;
            this.rootCategoryRadioButton.Text = "Root Category";
            this.rootCategoryRadioButton.UseVisualStyleBackColor = true;
            this.rootCategoryRadioButton.CheckedChanged += new System.EventHandler(this.rootCategoryRadioButton_CheckedChanged);
            // 
            // childCategoryRadioButton
            // 
            this.childCategoryRadioButton.AutoSize = true;
            this.childCategoryRadioButton.Location = new System.Drawing.Point(147, 67);
            this.childCategoryRadioButton.Name = "childCategoryRadioButton";
            this.childCategoryRadioButton.Size = new System.Drawing.Size(93, 17);
            this.childCategoryRadioButton.TabIndex = 4;
            this.childCategoryRadioButton.TabStop = true;
            this.childCategoryRadioButton.Text = "Child Category";
            this.childCategoryRadioButton.UseVisualStyleBackColor = true;
            this.childCategoryRadioButton.CheckedChanged += new System.EventHandler(this.childCategoryRadioButton_CheckedChanged);
            // 
            // expenseRootCategoryComboBox
            // 
            this.expenseRootCategoryComboBox.FormattingEnabled = true;
            this.expenseRootCategoryComboBox.Location = new System.Drawing.Point(133, 95);
            this.expenseRootCategoryComboBox.Name = "expenseRootCategoryComboBox";
            this.expenseRootCategoryComboBox.Size = new System.Drawing.Size(196, 21);
            this.expenseRootCategoryComboBox.TabIndex = 14;
            this.expenseRootCategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.expenseRootCategoryComboBox_SelectedIndexChanged);
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(55, 98);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(49, 13);
            this.categoryLabel.TabIndex = 13;
            this.categoryLabel.Text = "Category";
            // 
            // expenseCategoryDataGridView
            // 
            this.expenseCategoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.expenseCategoryDataGridView.Location = new System.Drawing.Point(421, 67);
            this.expenseCategoryDataGridView.Name = "expenseCategoryDataGridView";
            this.expenseCategoryDataGridView.RowTemplate.Height = 70;
            this.expenseCategoryDataGridView.Size = new System.Drawing.Size(380, 267);
            this.expenseCategoryDataGridView.TabIndex = 15;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(723, 33);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(78, 23);
            this.searchButton.TabIndex = 3;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(509, 33);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(196, 20);
            this.searchTextBox.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(448, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Code";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(133, 290);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(76, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Code";
            // 
            // codeTextBox
            // 
            this.codeTextBox.Location = new System.Drawing.Point(133, 176);
            this.codeTextBox.Name = "codeTextBox";
            this.codeTextBox.Size = new System.Drawing.Size(196, 20);
            this.codeTextBox.TabIndex = 2;
            // 
            // addChildsRadioButton
            // 
            this.addChildsRadioButton.AutoSize = true;
            this.addChildsRadioButton.Location = new System.Drawing.Point(254, 67);
            this.addChildsRadioButton.Name = "addChildsRadioButton";
            this.addChildsRadioButton.Size = new System.Drawing.Size(75, 17);
            this.addChildsRadioButton.TabIndex = 41;
            this.addChildsRadioButton.TabStop = true;
            this.addChildsRadioButton.Text = "Add Childs";
            this.addChildsRadioButton.UseVisualStyleBackColor = true;
            this.addChildsRadioButton.CheckedChanged += new System.EventHandler(this.addChildsRadioButton_CheckedChanged);
            // 
            // addChildComboBox
            // 
            this.addChildComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.addChildComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.addChildComboBox.FormattingEnabled = true;
            this.addChildComboBox.Location = new System.Drawing.Point(133, 95);
            this.addChildComboBox.Name = "addChildComboBox";
            this.addChildComboBox.Size = new System.Drawing.Size(196, 21);
            this.addChildComboBox.TabIndex = 42;
            this.addChildComboBox.SelectedIndexChanged += new System.EventHandler(this.addChildComboBox_SelectedIndexChanged);
            // 
            // SetupExpenseCategoryUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 369);
            this.Controls.Add(this.addChildComboBox);
            this.Controls.Add(this.addChildsRadioButton);
            this.Controls.Add(this.expenseCategoryDataGridView);
            this.Controls.Add(this.expenseRootCategoryComboBox);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.childCategoryRadioButton);
            this.Controls.Add(this.rootCategoryRadioButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.codeTextBox);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SetupExpenseCategoryUi";
            this.Text = "SetupExpenseCategory";
            ((System.ComponentModel.ISupportInitialize)(this.expenseCategoryDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.RadioButton rootCategoryRadioButton;
        private System.Windows.Forms.RadioButton childCategoryRadioButton;
        private System.Windows.Forms.ComboBox expenseRootCategoryComboBox;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.DataGridView expenseCategoryDataGridView;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox codeTextBox;
        private System.Windows.Forms.RadioButton addChildsRadioButton;
        private System.Windows.Forms.ComboBox addChildComboBox;
    }
}