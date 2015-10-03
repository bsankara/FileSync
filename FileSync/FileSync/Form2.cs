using System;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Amazon.S3;
using Amazon.S3.Model;

namespace FileSync
{
    public partial class Form2 : Form
    {
        private AmazonS3Client client;
        public Form2(AmazonS3Client authenticatedClient)
        {
            client = authenticatedClient;
            InitializeComponent();
        }

        private void btnStartSync_Click(object sender, EventArgs e)
        {
            string storageBucketName = txtBucketName.Text;
            ListBucketsResponse response = client.ListBuckets();

            bool isBucketCreated = false;
            foreach (S3Bucket bucket in response.Buckets)
            {
                if (bucket.BucketName == storageBucketName)
                {
                    isBucketCreated = true;
                    break;
                }
            }
            if (!isBucketCreated)
            {
                try
                {
                    createBucket(client, storageBucketName);
                }
                catch (AmazonS3Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>,
        /// <param name="client">Amazon S3 Cleint</param>
        /// <param name="bucketName">Name of bucket</param>
        /// <returns>boolean denotings success vs failure</returns>
        private bool createBucket(AmazonS3Client client, string bucketName)
        {
            try
            {
                PutBucketRequest request = new PutBucketRequest
                {
                    BucketName = bucketName,
                    UseClientRegion = true
                };
                PutBucketResponse response = client.PutBucket(request);
            }
            catch (AmazonS3Exception ex)
            {
                throw ex;
            }
            return true;
        }

        private void btnSelectSyncFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = dialog.SelectedPath;
                txtFolderToSync.Text = selectedPath;
                string[] files = Directory.GetFiles(selectedPath);
            }
        }
    }
}
