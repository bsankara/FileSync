﻿namespace FileSync
{
    partial class Form1
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
            this.b2AccountId = new System.Windows.Forms.TextBox();
            this.accessKeyLabel = new System.Windows.Forms.Label();
            this.b2ApplicationKey = new System.Windows.Forms.TextBox();
            this.awsSecretKeyLabel = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.selectCSVDialog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b2AccountId
            // 
            this.b2AccountId.Location = new System.Drawing.Point(42, 55);
            this.b2AccountId.Name = "b2AccountId";
            this.b2AccountId.Size = new System.Drawing.Size(256, 20);
            this.b2AccountId.TabIndex = 0;
            // 
            // accessKeyLabel
            // 
            this.accessKeyLabel.AutoSize = true;
            this.accessKeyLabel.Location = new System.Drawing.Point(337, 61);
            this.accessKeyLabel.Name = "accessKeyLabel";
            this.accessKeyLabel.Size = new System.Drawing.Size(77, 13);
            this.accessKeyLabel.TabIndex = 1;
            this.accessKeyLabel.Text = "B2 Account ID";
            // 
            // b2ApplicationKey
            // 
            this.b2ApplicationKey.Location = new System.Drawing.Point(42, 81);
            this.b2ApplicationKey.Name = "b2ApplicationKey";
            this.b2ApplicationKey.Size = new System.Drawing.Size(256, 20);
            this.b2ApplicationKey.TabIndex = 2;
            // 
            // awsSecretKeyLabel
            // 
            this.awsSecretKeyLabel.AutoSize = true;
            this.awsSecretKeyLabel.Location = new System.Drawing.Point(337, 88);
            this.awsSecretKeyLabel.Name = "awsSecretKeyLabel";
            this.awsSecretKeyLabel.Size = new System.Drawing.Size(96, 13);
            this.awsSecretKeyLabel.TabIndex = 3;
            this.awsSecretKeyLabel.Text = "B2 Application Key";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(223, 193);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // selectCSVDialog
            // 
            this.selectCSVDialog.Location = new System.Drawing.Point(179, 126);
            this.selectCSVDialog.Name = "selectCSVDialog";
            this.selectCSVDialog.Size = new System.Drawing.Size(145, 23);
            this.selectCSVDialog.TabIndex = 7;
            this.selectCSVDialog.Text = "Select CSV file";
            this.selectCSVDialog.UseVisualStyleBackColor = true;
            this.selectCSVDialog.Click += new System.EventHandler(this.selectCSVDialog_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 237);
            this.Controls.Add(this.selectCSVDialog);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.awsSecretKeyLabel);
            this.Controls.Add(this.b2ApplicationKey);
            this.Controls.Add(this.accessKeyLabel);
            this.Controls.Add(this.b2AccountId);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox b2AccountId;
        private System.Windows.Forms.Label accessKeyLabel;
        private System.Windows.Forms.TextBox b2ApplicationKey;
        private System.Windows.Forms.Label awsSecretKeyLabel;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button selectCSVDialog;
    }
}

