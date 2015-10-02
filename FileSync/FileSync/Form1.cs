using System;
using System.IO;
using System.Windows.Forms;
using Amazon.S3;
using Amazon.S3.Model;

namespace FileSync
{

    public partial class Form1 : Form
    {
        private const string validLine1 = "User Name,Access Key Id,Secret Access Key";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string secretAccessKey = awsAccessKey.Text;
            string secretKey = awsSecretKey.Text;
            string storageBucketName = txtBucketName.Text;
            AmazonS3Client client = new AmazonS3Client(secretAccessKey, secretKey, Amazon.RegionEndpoint.USWest2);
            ListBucketsResponse response = client.ListBuckets();

            bool isBucketCreated = false;
            foreach (S3Bucket bucket in response.Buckets)
            {
                if (bucket.BucketName == storageBucketName)
                    isBucketCreated = true;
            }
            if (!isBucketCreated)
            {
                try
                {
                    createBucket(client, storageBucketName);
                }
                catch (AmazonS3Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
            Form2 realDataForm = new Form2();
            realDataForm.Closed += (s, args) => this.Close();
            realDataForm.Show();
            this.Hide();
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


        //parses the CSV that you can download from Amazon
        private void selectCSVDialog_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string[] allLines = File.ReadAllLines(dialog.FileName);

                // should only be 2 lines
                if (allLines.Length == 2 && allLines[0] == validLine1)
                {
                    string[] data = allLines[1].Split(',');
                    if (data.Length == 3)
                    {
                        awsAccessKey.Text = data[1];
                        awsSecretKey.Text = data[2];
                        return;
                    }
                }
                // if we get here we know the file is incorrectly formatted
                System.Windows.Forms.MessageBox.Show("Error, file is in an incorrect format, please download your credentials directly from Amazon's IAM console.");
            }

        }
    }
}
