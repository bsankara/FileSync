using System;
using System.IO;
using System.Windows.Forms;

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
            Form2 realDataForm = new Form2();
            realDataForm.Closed += (s, args) => this.Close();
            realDataForm.Show();
            this.Hide();
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
