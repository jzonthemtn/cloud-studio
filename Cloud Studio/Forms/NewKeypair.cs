using Amazon.EC2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CloudStudio.GUI.Forms
{
    public partial class NewKeypairForm : Form
    {

        private string keyname;
        private string fingerprint;
        private string material;

        public NewKeypairForm(string keyname, string fingerprint, string material)
        {
            InitializeComponent();

            this.keyname = keyname;
            this.fingerprint = fingerprint;
            this.material = material;
        }

        private void NewKeypairForm_Load(object sender, EventArgs e)
        {
            KeyFingerprintTextBox.Text = fingerprint;
            KeyMaterialTextBox.Text = material;
        }

        private void SaveMaterialButton_Click(object sender, EventArgs e)
        {
            OutputSaveFileDialog.FileName = keyname = ".pem";
            if (OutputSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(OutputSaveFileDialog.FileName, KeyMaterialTextBox.Text);
                    MessageBox.Show("The key has been saved to " + OutputSaveFileDialog.FileName + ".", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Unable to save the key: " + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                
            }
        }

    }

}
