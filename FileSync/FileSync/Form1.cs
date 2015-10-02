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
                createBucket(client, storageBucketName);
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
                //TODO add a better exception handler here
                return false;
            }
            return true;
        }
    }
}
