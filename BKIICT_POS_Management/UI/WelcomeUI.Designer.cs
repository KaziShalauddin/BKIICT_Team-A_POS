﻿namespace BKIICT_POS_Management.UI
{
    partial class WelcomeUi
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
            this.operationsWelcomeUiButton = new System.Windows.Forms.Button();
            this.setupUiButton = new System.Windows.Forms.Button();
            this.reportWelcomeUiButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(99, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome To POS System";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(74, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(307, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Developed by : BKIICT_.Net(Batch-01)_Team A";
            // 
            // operationsWelcomeUiButton
            // 
            this.operationsWelcomeUiButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operationsWelcomeUiButton.Location = new System.Drawing.Point(223, 81);
            this.operationsWelcomeUiButton.Name = "operationsWelcomeUiButton";
            this.operationsWelcomeUiButton.Size = new System.Drawing.Size(169, 33);
            this.operationsWelcomeUiButton.TabIndex = 2;
            this.operationsWelcomeUiButton.Text = "Operations Form";
            this.operationsWelcomeUiButton.UseVisualStyleBackColor = true;
            this.operationsWelcomeUiButton.Click += new System.EventHandler(this.operationsWelcomeUiButton_Click);
            // 
            // setupUiButton
            // 
            this.setupUiButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setupUiButton.Location = new System.Drawing.Point(35, 81);
            this.setupUiButton.Name = "setupUiButton";
            this.setupUiButton.Size = new System.Drawing.Size(169, 33);
            this.setupUiButton.TabIndex = 2;
            this.setupUiButton.Text = "Setup Form";
            this.setupUiButton.UseVisualStyleBackColor = true;
            this.setupUiButton.Click += new System.EventHandler(this.setupUiButton_Click);
            // 
            // reportWelcomeUiButton
            // 
            this.reportWelcomeUiButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportWelcomeUiButton.Location = new System.Drawing.Point(135, 139);
            this.reportWelcomeUiButton.Name = "reportWelcomeUiButton";
            this.reportWelcomeUiButton.Size = new System.Drawing.Size(169, 33);
            this.reportWelcomeUiButton.TabIndex = 2;
            this.reportWelcomeUiButton.Text = "Reports Form";
            this.reportWelcomeUiButton.UseVisualStyleBackColor = true;
            this.reportWelcomeUiButton.Click += new System.EventHandler(this.reportWelcomeUiButton_Click);
            // 
            // WelcomeUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 254);
            this.Controls.Add(this.reportWelcomeUiButton);
            this.Controls.Add(this.setupUiButton);
            this.Controls.Add(this.operationsWelcomeUiButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "WelcomeUi";
            this.Text = "WelcomeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button operationsWelcomeUiButton;
        private System.Windows.Forms.Button setupUiButton;
        private System.Windows.Forms.Button reportWelcomeUiButton;
    }
}