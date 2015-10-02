namespace FileSync
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
            this.awsAccessKey = new System.Windows.Forms.TextBox();
            this.accessKeyLabel = new System.Windows.Forms.Label();
            this.awsSecretKey = new System.Windows.Forms.TextBox();
            this.awsSecretKeyLabel = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtBucketName = new System.Windows.Forms.TextBox();
            this.bucketNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // awsAccessKey
            // 
            this.awsAccessKey.Location = new System.Drawing.Point(42, 55);
            this.awsAccessKey.Name = "awsAccessKey";
            this.awsAccessKey.Size = new System.Drawing.Size(256, 20);
            this.awsAccessKey.TabIndex = 0;
            // 
            // accessKeyLabel
            // 
            this.accessKeyLabel.AutoSize = true;
            this.accessKeyLabel.Location = new System.Drawing.Point(337, 61);
            this.accessKeyLabel.Name = "accessKeyLabel";
            this.accessKeyLabel.Size = new System.Drawing.Size(91, 13);
            this.accessKeyLabel.TabIndex = 1;
            this.accessKeyLabel.Text = "AWS Access Key";
            // 
            // awsSecretKey
            // 
            this.awsSecretKey.Location = new System.Drawing.Point(42, 118);
            this.awsSecretKey.Name = "awsSecretKey";
            this.awsSecretKey.Size = new System.Drawing.Size(256, 20);
            this.awsSecretKey.TabIndex = 2;
            // 
            // awsSecretKeyLabel
            // 
            this.awsSecretKeyLabel.AutoSize = true;
            this.awsSecretKeyLabel.Location = new System.Drawing.Point(337, 125);
            this.awsSecretKeyLabel.Name = "awsSecretKeyLabel";
            this.awsSecretKeyLabel.Size = new System.Drawing.Size(87, 13);
            this.awsSecretKeyLabel.TabIndex = 3;
            this.awsSecretKeyLabel.Text = "AWS Secret Key";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(223, 226);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtBucketName
            // 
            this.txtBucketName.Location = new System.Drawing.Point(42, 165);
            this.txtBucketName.Name = "txtBucketName";
            this.txtBucketName.Size = new System.Drawing.Size(256, 20);
            this.txtBucketName.TabIndex = 5;
            // 
            // bucketNameLabel
            // 
            this.bucketNameLabel.AutoSize = true;
            this.bucketNameLabel.Location = new System.Drawing.Point(337, 168);
            this.bucketNameLabel.Name = "bucketNameLabel";
            this.bucketNameLabel.Size = new System.Drawing.Size(118, 13);
            this.bucketNameLabel.TabIndex = 6;
            this.bucketNameLabel.Text = "Preferred Bucket Name";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 261);
            this.Controls.Add(this.bucketNameLabel);
            this.Controls.Add(this.txtBucketName);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.awsSecretKeyLabel);
            this.Controls.Add(this.awsSecretKey);
            this.Controls.Add(this.accessKeyLabel);
            this.Controls.Add(this.awsAccessKey);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox awsAccessKey;
        private System.Windows.Forms.Label accessKeyLabel;
        private System.Windows.Forms.TextBox awsSecretKey;
        private System.Windows.Forms.Label awsSecretKeyLabel;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtBucketName;
        private System.Windows.Forms.Label bucketNameLabel;
    }
}

