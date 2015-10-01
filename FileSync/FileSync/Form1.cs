using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Amazon.S3;
using Amazon.S3.Model;

namespace FileSync
{
    
    public partial class Form1 : Form
    {
        //TODO make this changable/programaticly generate a unique one
        private const string storageBucketName = "superawesomebucketname";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string secretAccessKey = awsAccessKey.Text;
            string secretKey = awsSecretKey.Text;
            AmazonS3Client client = new AmazonS3Client(secretAccessKey, secretKey, Amazon.RegionEndpoint.USWest2);
            ListBucketsResponse response = client.ListBuckets();

            bool isBucketCreated = false;
            foreach (S3Bucket bucket in response.Buckets)
            {
                if (bucket.BucketName == storageBucketName)
                    isBucketCreated = true;
            }
            if (isBucketCreated)
            {
                //we have the bucket so we don't need to create it.
            }
        }
    }
}
