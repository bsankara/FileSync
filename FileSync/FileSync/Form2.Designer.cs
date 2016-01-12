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
            this.btnPushData = new System.Windows.Forms.Button();
            this.btnSelectSyncFolder = new System.Windows.Forms.Button();
            this.txtFolderToSync = new System.Windows.Forms.TextBox();
            this.btnPullData = new System.Windows.Forms.Button();
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
            this.txtBucketName.Size = new System.Drawing.Size(307, 20);
            this.txtBucketName.TabIndex = 7;
            // 
            // btnPushData
            // 
            this.btnPushData.Location = new System.Drawing.Point(49, 171);
            this.btnPushData.Name = "btnPushData";
            this.btnPushData.Size = new System.Drawing.Size(128, 23);
            this.btnPushData.TabIndex = 9;
            this.btnPushData.Text = "Push Data To B2";
            this.btnPushData.UseVisualStyleBackColor = true;
            this.btnPushData.Click += new System.EventHandler(this.btnStartSync_Click);
            // 
            // btnSelectSyncFolder
            // 
            this.btnSelectSyncFolder.Location = new System.Drawing.Point(338, 107);
            this.btnSelectSyncFolder.Name = "btnSelectSyncFolder";
            this.btnSelectSyncFolder.Size = new System.Drawing.Size(125, 23);
            this.btnSelectSyncFolder.TabIndex = 10;
            this.btnSelectSyncFolder.Text = "Select Folder To Sync";
            this.btnSelectSyncFolder.UseVisualStyleBackColor = true;
            this.btnSelectSyncFolder.Click += new System.EventHandler(this.btnSelectSyncFolder_Click);
            // 
            // txtFolderToSync
            // 
            this.txtFolderToSync.Location = new System.Drawing.Point(12, 110);
            this.txtFolderToSync.Name = "txtFolderToSync";
            this.txtFolderToSync.Size = new System.Drawing.Size(307, 20);
            this.txtFolderToSync.TabIndex = 11;
            // 
            // btnPullData
            // 
            this.btnPullData.Location = new System.Drawing.Point(298, 171);
            this.btnPullData.Name = "btnPullData";
            this.btnPullData.Size = new System.Drawing.Size(128, 23);
            this.btnPullData.TabIndex = 12;
            this.btnPullData.Text = "Pull Data From B2";
            this.btnPullData.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 208);
            this.Controls.Add(this.btnPullData);
            this.Controls.Add(this.txtFolderToSync);
            this.Controls.Add(this.btnSelectSyncFolder);
            this.Controls.Add(this.btnPushData);
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
        private System.Windows.Forms.Button btnPushData;
        private System.Windows.Forms.Button btnSelectSyncFolder;
        private System.Windows.Forms.TextBox txtFolderToSync;
        private System.Windows.Forms.Button btnPullData;
    }
}