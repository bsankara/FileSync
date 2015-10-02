namespace FileSync
{
    partial class Form2
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
            this.bucketNameLabel = new System.Windows.Forms.Label();
            this.txtBucketName = new System.Windows.Forms.TextBox();
            this.btnStartSync = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bucketNameLabel
            // 
            this.bucketNameLabel.AutoSize = true;
            this.bucketNameLabel.Location = new System.Drawing.Point(335, 62);
            this.bucketNameLabel.Name = "bucketNameLabel";
            this.bucketNameLabel.Size = new System.Drawing.Size(118, 13);
            this.bucketNameLabel.TabIndex = 8;
            this.bucketNameLabel.Text = "Preferred Bucket Name";
            // 
            // txtBucketName
            // 
            this.txtBucketName.Location = new System.Drawing.Point(12, 59);
            this.txtBucketName.Name = "txtBucketName";
            this.txtBucketName.Size = new System.Drawing.Size(256, 20);
            this.txtBucketName.TabIndex = 7;
            // 
            // btnStartSync
            // 
            this.btnStartSync.Location = new System.Drawing.Point(191, 244);
            this.btnStartSync.Name = "btnStartSync";
            this.btnStartSync.Size = new System.Drawing.Size(128, 23);
            this.btnStartSync.TabIndex = 9;
            this.btnStartSync.Text = "Start Sync";
            this.btnStartSync.UseVisualStyleBackColor = true;
            this.btnStartSync.Click += new System.EventHandler(this.btnStartSync_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 291);
            this.Controls.Add(this.btnStartSync);
            this.Controls.Add(this.bucketNameLabel);
            this.Controls.Add(this.txtBucketName);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label bucketNameLabel;
        private System.Windows.Forms.TextBox txtBucketName;
        private System.Windows.Forms.Button btnStartSync;
    }
}