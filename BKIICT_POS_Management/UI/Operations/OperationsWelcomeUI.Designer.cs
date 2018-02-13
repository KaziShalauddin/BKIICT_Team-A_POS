namespace BKIICT_POS_Management.UI.Operations
{
    partial class OperationsWelcomeUi
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
            this.purchaseFormButton = new System.Windows.Forms.Button();
            this.salesFormButton = new System.Windows.Forms.Button();
            this.expenseFormButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 35);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(50, 0, 50, 0);
            this.label1.Size = new System.Drawing.Size(252, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Operations Form";
            // 
            // purchaseFormButton
            // 
            this.purchaseFormButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchaseFormButton.Location = new System.Drawing.Point(105, 90);
            this.purchaseFormButton.Name = "purchaseFormButton";
            this.purchaseFormButton.Size = new System.Drawing.Size(133, 28);
            this.purchaseFormButton.TabIndex = 2;
            this.purchaseFormButton.Text = "Purchase";
            this.purchaseFormButton.UseVisualStyleBackColor = true;
            this.purchaseFormButton.Click += new System.EventHandler(this.purchaseFormButton_Click);
            // 
            // salesFormButton
            // 
            this.salesFormButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salesFormButton.Location = new System.Drawing.Point(105, 137);
            this.salesFormButton.Name = "salesFormButton";
            this.salesFormButton.Size = new System.Drawing.Size(133, 28);
            this.salesFormButton.TabIndex = 2;
            this.salesFormButton.Text = "Sale";
            this.salesFormButton.UseVisualStyleBackColor = true;
            this.salesFormButton.Click += new System.EventHandler(this.salesFormButton_Click);
            // 
            // expenseFormButton
            // 
            this.expenseFormButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expenseFormButton.Location = new System.Drawing.Point(105, 184);
            this.expenseFormButton.Name = "expenseFormButton";
            this.expenseFormButton.Size = new System.Drawing.Size(133, 28);
            this.expenseFormButton.TabIndex = 2;
            this.expenseFormButton.Text = "Expense";
            this.expenseFormButton.UseVisualStyleBackColor = true;
            this.expenseFormButton.Click += new System.EventHandler(this.expenseFormButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(12, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(307, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Developed by : BKIICT_.Net(Batch-01)_Team A";
            // 
            // OperationsWelcomeUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 259);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.expenseFormButton);
            this.Controls.Add(this.salesFormButton);
            this.Controls.Add(this.purchaseFormButton);
            this.Controls.Add(this.label1);
            this.Name = "OperationsWelcomeUi";
            this.Text = "OperationsWelcomeUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button purchaseFormButton;
        private System.Windows.Forms.Button salesFormButton;
        private System.Windows.Forms.Button expenseFormButton;
        private System.Windows.Forms.Label label2;
    }
}