using System;
using System.IO;
using System.Windows.Forms;
using B2_CSharp_SDK;

namespace FileSync
{
    public partial class Form2 : Form
    {
        private static string dbName = "FileSyncMain.sqlite";
        public Form2()
        {
            InitializeComponent();
        }

        private void btnStartSync_Click(object sender, EventArgs e)
        {
            string storageBucketName = txtBucketName.Text;
            SqlQuery dbConnection = new SqlQuery(dbName);
            if (!System.IO.File.Exists(dbName))
                dbConnection.createAndInitializeDatabase();
            string fileSyncDirectory = txtFolderToSync.Text;
            if (Directory.Exists(fileSyncDirectory))
            {
                dbConnection.addDirectoryToFileSyncDirectory(fileSyncDirectory);
            }
            else
            {
                //Invalid directory
            }
        }

        private void btnSelectSyncFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = dialog.SelectedPath;
                txtFolderToSync.Text = selectedPath;
                string[] files = Directory.GetFiles(selectedPath,"*", SearchOption.AllDirectories);
                
            }
        }
    }
}
