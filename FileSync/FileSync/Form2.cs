using System;
using System.IO;
using System.Windows.Forms;
using B2_CSharp_SDK;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;

namespace FileSync
{
    public partial class Form2 : Form
    {
        private static string dbName = "FileSyncMain.sqlite";
        B2SDK authorizedSDK;
        public Form2(B2SDK sdk)
        {
            InitializeComponent();
            authorizedSDK = sdk;
            SqlQuery dbConnection = new SqlQuery(dbName);
            if (System.IO.File.Exists(dbName))
            {
                string bucketName = dbConnection.getPrefferedBucketName();
                txtBucketName.Text = bucketName;

                string directoryName = dbConnection.getDirectoryName();
                txtFolderToSync.Text = directoryName;
            }

        }

        private string calculateSHA1 (byte[] bytes)
        {
            SHA1CryptoServiceProvider sh = new SHA1CryptoServiceProvider();
            sh.ComputeHash(bytes);
            byte[] hash = sh.Hash;
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hash)
            {
                sb.Append(b.ToString("x2"));
            }

            string sha1 = sb.ToString();
            return sha1;
        }

        private string getOrCreateBucketId (string bucketName)
        {
            List<B2Bucket> buckets = authorizedSDK.b2_list_buckets();
            foreach(B2Bucket bucket in buckets)
            {
                if (bucket.bucketName == bucketName)
                {
                    return bucket.bucketId;
                }
            }
            // if we get here we need to create the bucket

            B2Bucket createdBucket = authorizedSDK.b2_create_bucket(bucketName, "allPrivate");

            return createdBucket.bucketId;
        }

        private void btnStartSync_Click(object sender, EventArgs e)
        {
            string storageBucketName = txtBucketName.Text;
            SqlQuery dbConnection = new SqlQuery(dbName);
            if (!System.IO.File.Exists(dbName))
            {
                dbConnection.createAndInitializeDatabase();
            }
            string fileSyncDirectory = txtFolderToSync.Text;
            dbConnection.savePreferredBucketName(storageBucketName);
            if (Directory.Exists(fileSyncDirectory))
            {
                dbConnection.addDirectoryToFileSyncDirectory(fileSyncDirectory);
                string[] files = Directory.GetFiles(fileSyncDirectory, "*", SearchOption.AllDirectories);
                // disable buttons

                btnPullData.Enabled = false;
                btnPushData.Enabled = false;
                string bucketId = getOrCreateBucketId(storageBucketName);
                foreach (string fileName in files)
                {
                    byte[] fileBytes = File.ReadAllBytes(fileName);

                    // backblaze doesnt allow \'s so we have to replace with /'s .... we'll have to do this the other way around
                    // thankfully windows doesnt let you name files with that so it will only denominate folder separations.
                    string file = fileName.Replace(@"\", "/");
                    string sha1Hash = calculateSHA1(fileBytes);
                    B2FileInfo fileInfo = authorizedSDK.b2_upload_file(fileBytes, file, bucketId);
                    TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
                    int secondsSinceEpoch = (int)t.TotalSeconds;
                    if (fileInfo.contentSha1 == sha1Hash)
                    {
                        dbConnection.addSyncedFileInfo(file, secondsSinceEpoch, sha1Hash);
                    }
                }

                //now that I think about this, it doesnt make sense to push this filelist on there -- we should only be putting things in when they're on the server
                //dbConnection.pushUnsyncedFileList(files);
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
                
            }
        }
    }
}
