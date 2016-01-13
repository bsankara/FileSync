using System;
using System.IO;
using System.Windows.Forms;
using B2_CSharp_SDK;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Collections;

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

        private Dictionary<string, string> processFilesInBucket(string storageBucketId)
        {

            Dictionary<string, string> fileList = new Dictionary<string, string>();
            B2FileList list = authorizedSDK.b2_list_file_names(storageBucketId, "");
            List<B2File> individualFiles = new List<B2File>();
            individualFiles.AddRange(list.files);
            while (list.nextFileName != null)
            {
                list = authorizedSDK.b2_list_file_names(storageBucketId, list.nextFileName);
                individualFiles.AddRange(list.files);
            }

            foreach(B2File file in individualFiles)
            {
                fileList.Add(file.fileName, file.fileId);
            }
            return fileList;
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
                string bucketId = getOrCreateBucketId(storageBucketName);
                Dictionary<string, string> processedFileList = processFilesInBucket(bucketId);
                dbConnection.addDirectoryToFileSyncDirectory(fileSyncDirectory);
                string[] files = Directory.GetFiles(fileSyncDirectory, "*", SearchOption.AllDirectories);
                // disable buttons

                btnPullData.Enabled = false;
                btnPushData.Enabled = false;

                foreach (string fileName in files)
                {
                    // backblaze doesnt allow \'s so we have to replace with /'s .... we'll have to do this the other way around
                    // thankfully windows doesnt let you name files with that so it will only denominate folder separations.
                    string cleanFileName = fileName.Replace(@"\", "/");
                    byte[] fileBytes = File.ReadAllBytes(fileName);
                    string sha1Hash = calculateSHA1(fileBytes);
                    if (processedFileList.ContainsKey(cleanFileName))
                    {
                        B2FileInfo fileInfo = authorizedSDK.b2_get_file_info(processedFileList[cleanFileName]);
                        if (fileInfo.contentSha1.Equals(sha1Hash))
                        {
                            // do nothing
                        }
                        else
                        {
                            authorizedSDK.b2_delete_file_version(cleanFileName, processedFileList[cleanFileName]);
                            fileInfo = authorizedSDK.b2_upload_file(fileBytes, cleanFileName, bucketId);
                            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
                            int secondsSinceEpoch = (int)t.TotalSeconds;
                            if (fileInfo.contentSha1 == sha1Hash)
                            {
                                dbConnection.addSyncedFileInfo(cleanFileName, secondsSinceEpoch, sha1Hash);
                            }
                        }
                    }
                    else
                    { 
                        B2FileInfo fileInfo = authorizedSDK.b2_upload_file(fileBytes, cleanFileName, bucketId);
                        TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
                        int secondsSinceEpoch = (int)t.TotalSeconds;
                        if (fileInfo.contentSha1 == sha1Hash)
                        {
                            dbConnection.addSyncedFileInfo(cleanFileName, secondsSinceEpoch, sha1Hash);
                        }

                    }
                }
            }
            else
            {
                //Invalid directory
            }

            btnPullData.Enabled = true;
            btnPushData.Enabled = true;
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
