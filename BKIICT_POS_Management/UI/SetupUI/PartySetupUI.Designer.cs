namespace BKIICT_POS_Management.UI.SetupUI
{
    partial class PartySetupUi
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
            this.partyPart1GroupBox = new System.Windows.Forms.GroupBox();
            this.outletComboBox = new System.Windows.Forms.ComboBox();
            this.organizationComboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nextButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.partyDataGridView = new System.Windows.Forms.DataGridView();
            this.showButton = new System.Windows.Forms.Button();
            this.partyPart2GroupBox = new System.Windows.Forms.GroupBox();
            this.barCodePictureBox = new System.Windows.Forms.PictureBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.uploadButton = new System.Windows.Forms.Button();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.orgPictureBox = new System.Windows.Forms.PictureBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.mobNoTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.supplierCheckBox = new System.Windows.Forms.CheckBox();
            this.customerCheckBox = new System.Windows.Forms.CheckBox();
            this.partyPart1GroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.partyDataGridView)).BeginInit();
            this.partyPart2GroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barCodePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orgPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // partyPart1GroupBox
            // 
            this.partyPart1GroupBox.Controls.Add(this.customerCheckBox);
            this.partyPart1GroupBox.Controls.Add(this.supplierCheckBox);
            this.partyPart1GroupBox.Controls.Add(this.outletComboBox);
            this.partyPart1GroupBox.Controls.Add(this.organizationComboBox);
            this.partyPart1GroupBox.Controls.Add(this.label9);
            this.partyPart1GroupBox.Controls.Add(this.label8);
            this.partyPart1GroupBox.Controls.Add(this.label7);
            this.partyPart1GroupBox.Controls.Add(this.nextButton);
            this.partyPart1GroupBox.Controls.Add(this.cancelButton);
            this.partyPart1GroupBox.Location = new System.Drawing.Point(12, 12);
            this.partyPart1GroupBox.Name = "partyPart1GroupBox";
            this.partyPart1GroupBox.Size = new System.Drawing.Size(394, 176);
            this.partyPart1GroupBox.TabIndex = 16;
            this.partyPart1GroupBox.TabStop = false;
            this.partyPart1GroupBox.Text = "Praty( Part 1)";
            // 
            // outletComboBox
            // 
            this.outletComboBox.FormattingEnabled = true;
            this.outletComboBox.Location = new System.Drawing.Point(105, 64);
            this.outletComboBox.Name = "outletComboBox";
            this.outletComboBox.Size = new System.Drawing.Size(178, 21);
            this.outletComboBox.TabIndex = 19;
            // 
            // organizationComboBox
            // 
            this.organizationComboBox.FormattingEnabled = true;
            this.organizationComboBox.Location = new System.Drawing.Point(105, 25);
            this.organizationComboBox.Name = "organizationComboBox";
            this.organizationComboBox.Size = new System.Drawing.Size(178, 21);
            this.organizationComboBox.TabIndex = 19;
            this.organizationComboBox.SelectedIndexChanged += new System.EventHandler(this.organizationComboBox_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Party Type";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Outlet Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Organization Name";
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(141, 130);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(86, 23);
            this.nextButton.TabIndex = 17;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(254, 130);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(86, 23);
            this.cancelButton.TabIndex = 17;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.partyDataGridView);
            this.groupBox1.Controls.Add(this.showButton);
            this.groupBox1.Location = new System.Drawing.Point(427, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(549, 570);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // partyDataGridView
            // 
            this.partyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.partyDataGridView.Location = new System.Drawing.Point(22, 56);
            this.partyDataGridView.Name = "partyDataGridView";
            this.partyDataGridView.ReadOnly = true;
            this.partyDataGridView.RowHeadersVisible = false;
            this.partyDataGridView.Size = new System.Drawing.Size(503, 500);
            this.partyDataGridView.TabIndex = 18;
            // 
            // showButton
            // 
            this.showButton.Location = new System.Drawing.Point(397, 19);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(109, 31);
            this.showButton.TabIndex = 16;
            this.showButton.Text = "Show";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // partyPart2GroupBox
            // 
            this.partyPart2GroupBox.Controls.Add(this.barCodePictureBox);
            this.partyPart2GroupBox.Controls.Add(this.nameTextBox);
            this.partyPart2GroupBox.Controls.Add(this.uploadButton);
            this.partyPart2GroupBox.Controls.Add(this.addressTextBox);
            this.partyPart2GroupBox.Controls.Add(this.saveButton);
            this.partyPart2GroupBox.Controls.Add(this.label1);
            this.partyPart2GroupBox.Controls.Add(this.orgPictureBox);
            this.partyPart2GroupBox.Controls.Add(this.emailTextBox);
            this.partyPart2GroupBox.Controls.Add(this.mobNoTextBox);
            this.partyPart2GroupBox.Controls.Add(this.label5);
            this.partyPart2GroupBox.Controls.Add(this.label2);
            this.partyPart2GroupBox.Controls.Add(this.label6);
            this.partyPart2GroupBox.Controls.Add(this.label3);
            this.partyPart2GroupBox.Controls.Add(this.label4);
            this.partyPart2GroupBox.Location = new System.Drawing.Point(12, 194);
            this.partyPart2GroupBox.Name = "partyPart2GroupBox";
            this.partyPart2GroupBox.Size = new System.Drawing.Size(394, 388);
            this.partyPart2GroupBox.TabIndex = 22;
            this.partyPart2GroupBox.TabStop = false;
            this.partyPart2GroupBox.Text = "Praty( Part 2)";
            // 
            // barCodePictureBox
            // 
            this.barCodePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.barCodePictureBox.Location = new System.Drawing.Point(97, 44);
            this.barCodePictureBox.Name = "barCodePictureBox";
            this.barCodePictureBox.Size = new System.Drawing.Size(198, 66);
            this.barCodePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.barCodePictureBox.TabIndex = 30;
            this.barCodePictureBox.TabStop = false;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(97, 17);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(198, 20);
            this.nameTextBox.TabIndex = 25;
            // 
            // uploadButton
            // 
            this.uploadButton.Location = new System.Drawing.Point(296, 265);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(75, 23);
            this.uploadButton.TabIndex = 28;
            this.uploadButton.Text = "Upload";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(96, 179);
            this.addressTextBox.Multiline = true;
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(198, 42);
            this.addressTextBox.TabIndex = 22;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(200, 351);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 29;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Name";
            // 
            // orgPictureBox
            // 
            this.orgPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.orgPictureBox.Location = new System.Drawing.Point(92, 228);
            this.orgPictureBox.Name = "orgPictureBox";
            this.orgPictureBox.Size = new System.Drawing.Size(198, 99);
            this.orgPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.orgPictureBox.TabIndex = 27;
            this.orgPictureBox.TabStop = false;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(97, 150);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(198, 20);
            this.emailTextBox.TabIndex = 23;
            // 
            // mobNoTextBox
            // 
            this.mobNoTextBox.Location = new System.Drawing.Point(97, 118);
            this.mobNoTextBox.Name = "mobNoTextBox";
            this.mobNoTextBox.Size = new System.Drawing.Size(198, 20);
            this.mobNoTextBox.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Logo/Image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Code";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Contact No:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Address";
            // 
            // supplierCheckBox
            // 
            this.supplierCheckBox.AutoSize = true;
            this.supplierCheckBox.Location = new System.Drawing.Point(105, 98);
            this.supplierCheckBox.Name = "supplierCheckBox";
            this.supplierCheckBox.Size = new System.Drawing.Size(64, 17);
            this.supplierCheckBox.TabIndex = 20;
            this.supplierCheckBox.Text = "Supplier";
            this.supplierCheckBox.UseVisualStyleBackColor = true;
            this.supplierCheckBox.CheckedChanged += new System.EventHandler(this.supplierCheckBox_CheckedChanged);
            // 
            // customerCheckBox
            // 
            this.customerCheckBox.AutoSize = true;
            this.customerCheckBox.Location = new System.Drawing.Point(203, 98);
            this.customerCheckBox.Name = "customerCheckBox";
            this.customerCheckBox.Size = new System.Drawing.Size(70, 17);
            this.customerCheckBox.TabIndex = 20;
            this.customerCheckBox.Text = "Customer";
            this.customerCheckBox.UseVisualStyleBackColor = true;
            this.customerCheckBox.CheckedChanged += new System.EventHandler(this.customerCheckBox_CheckedChanged);
            // 
            // PartySetupUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 594);
            this.Controls.Add(this.partyPart2GroupBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.partyPart1GroupBox);
            this.Name = "PartySetupUi";
            this.Text = "PartySetupUI";
            this.partyPart1GroupBox.ResumeLayout(false);
            this.partyPart1GroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.partyDataGridView)).EndInit();
            this.partyPart2GroupBox.ResumeLayout(false);
            this.partyPart2GroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barCodePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orgPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox partyPart1GroupBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView partyDataGridView;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.ComboBox organizationComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox outletComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox partyPart2GroupBox;
        private System.Windows.Forms.PictureBox barCodePictureBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox orgPictureBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox mobNoTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.CheckBox customerCheckBox;
        private System.Windows.Forms.CheckBox supplierCheckBox;
    }
}