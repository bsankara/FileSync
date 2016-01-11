using System;
using System.IO;
using System.Windows.Forms;
using B2_CSharp_SDK;

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
            B2SDK sdk = new B2SDK(b2AccountId.Text, b2ApplicationKey.Text);
            Form2 realDataForm = new Form2(sdk);
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

                string[] data = allLines[0].Split(',');

                // only two parameters we're reading
                if (data.Length == 2)
                {
                    b2AccountId.Text = data[0].Trim();
                    b2ApplicationKey.Text = data[1].Trim();
                    return;
                }
                // if we get here we know the file is incorrectly formatted
                System.Windows.Forms.MessageBox.Show("Error, file is in an incorrect format, please format your credentials file as \"<accountId> , <applicationKey>\".");
            }

        }
    }
}
