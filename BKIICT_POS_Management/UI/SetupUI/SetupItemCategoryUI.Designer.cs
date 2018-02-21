namespace BKIICT_POS_Management.UI.SetupUI
{
    partial class SetupItemCategoryUi
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
            this.itemCategoryDataGridView = new System.Windows.Forms.DataGridView();
            this.itemRootCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.childCategoryRadioButton = new System.Windows.Forms.RadioButton();
            this.rootCategoryRadioButton = new System.Windows.Forms.RadioButton();
            this.searchButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uploadButton = new System.Windows.Forms.Button();
            this.imgPictureBox = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.barCodePictureBox = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.itemCategoryDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barCodePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // itemCategoryDataGridView
            // 
            this.itemCategoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemCategoryDataGridView.Location = new System.Drawing.Point(365, 77);
            this.itemCategoryDataGridView.Name = "itemCategoryDataGridView";
            this.itemCategoryDataGridView.Size = new System.Drawing.Size(380, 236);
            this.itemCategoryDataGridView.TabIndex = 34;
            // 
            // itemRootCategoryComboBox
            // 
            this.itemRootCategoryComboBox.FormattingEnabled = true;
            this.itemRootCategoryComboBox.Location = new System.Drawing.Point(114, 102);
            this.itemRootCategoryComboBox.Name = "itemRootCategoryComboBox";
            this.itemRootCategoryComboBox.Size = new System.Drawing.Size(196, 21);
            this.itemRootCategoryComboBox.TabIndex = 33;
            this.itemRootCategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.itemRootCategoryComboBox_SelectedIndexChanged);
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(25, 105);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(83, 13);
            this.categoryLabel.TabIndex = 32;
            this.categoryLabel.Text = "Parent Category";
            // 
            // childCategoryRadioButton
            // 
            this.childCategoryRadioButton.AutoSize = true;
            this.childCategoryRadioButton.Location = new System.Drawing.Point(226, 77);
            this.childCategoryRadioButton.Name = "childCategoryRadioButton";
            this.childCategoryRadioButton.Size = new System.Drawing.Size(93, 17);
            this.childCategoryRadioButton.TabIndex = 31;
            this.childCategoryRadioButton.TabStop = true;
            this.childCategoryRadioButton.Text = "Child Category";
            this.childCategoryRadioButton.UseVisualStyleBackColor = true;
            this.childCategoryRadioButton.CheckedChanged += new System.EventHandler(this.childCategoryRadioButton_CheckedChanged);
            // 
            // rootCategoryRadioButton
            // 
            this.rootCategoryRadioButton.AutoSize = true;
            this.rootCategoryRadioButton.Location = new System.Drawing.Point(91, 77);
            this.rootCategoryRadioButton.Name = "rootCategoryRadioButton";
            this.rootCategoryRadioButton.Size = new System.Drawing.Size(93, 17);
            this.rootCategoryRadioButton.TabIndex = 30;
            this.rootCategoryRadioButton.TabStop = true;
            this.rootCategoryRadioButton.Text = "Root Category";
            this.rootCategoryRadioButton.UseVisualStyleBackColor = true;
            this.rootCategoryRadioButton.CheckedChanged += new System.EventHandler(this.rootCategoryRadioButton_CheckedChanged);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(667, 43);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(78, 23);
            this.searchButton.TabIndex = 28;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(215, 435);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(82, 23);
            this.cancelButton.TabIndex = 27;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(616, 329);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(88, 23);
            this.loadButton.TabIndex = 26;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(91, 435);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(91, 23);
            this.saveButton.TabIndex = 25;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(112, 247);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(196, 58);
            this.descriptionTextBox.TabIndex = 24;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(453, 43);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(196, 20);
            this.searchTextBox.TabIndex = 22;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(114, 137);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(196, 20);
            this.nameTextBox.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Description";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(392, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 35);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.label1.Size = new System.Drawing.Size(187, 26);
            this.label1.TabIndex = 16;
            this.label1.Text = "Item Category";
            // 
            // uploadButton
            // 
            this.uploadButton.Location = new System.Drawing.Point(318, 349);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(75, 23);
            this.uploadButton.TabIndex = 37;
            this.uploadButton.Text = "Upload";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // imgPictureBox
            // 
            this.imgPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgPictureBox.Location = new System.Drawing.Point(110, 311);
            this.imgPictureBox.Name = "imgPictureBox";
            this.imgPictureBox.Size = new System.Drawing.Size(198, 99);
            this.imgPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgPictureBox.TabIndex = 36;
            this.imgPictureBox.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 349);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Image";
            // 
            // barCodePictureBox
            // 
            this.barCodePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.barCodePictureBox.Location = new System.Drawing.Point(112, 175);
            this.barCodePictureBox.Name = "barCodePictureBox";
            this.barCodePictureBox.Size = new System.Drawing.Size(198, 66);
            this.barCodePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.barCodePictureBox.TabIndex = 39;
            this.barCodePictureBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Code";
            // 
            // SetupItemCategoryUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 470);
            this.Controls.Add(this.barCodePictureBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.uploadButton);
            this.Controls.Add(this.imgPictureBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.itemCategoryDataGridView);
            this.Controls.Add(this.itemRootCategoryComboBox);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.childCategoryRadioButton);
            this.Controls.Add(this.rootCategoryRadioButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SetupItemCategoryUi";
            this.Text = "SetupItemCategoryUI";
            ((System.ComponentModel.ISupportInitialize)(this.itemCategoryDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barCodePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView itemCategoryDataGridView;
        private System.Windows.Forms.ComboBox itemRootCategoryComboBox;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.RadioButton childCategoryRadioButton;
        private System.Windows.Forms.RadioButton rootCategoryRadioButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.PictureBox imgPictureBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox barCodePictureBox;
        private System.Windows.Forms.Label label3;
    }
}