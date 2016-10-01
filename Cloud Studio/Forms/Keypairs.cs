using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Amazon.EC2.Model;
using CloudStudio.Services.Services;
using CloudStudio.GUI.Classes;
using CloudStudio.SharedLibrary.Domain;
using CloudStudio.SharedLibrary;
using CloudStudio.SharedLibrary.Services.AWSServices;
using CloudStudio.GUI.Utils;

namespace CloudStudio.GUI.Forms {

    public partial class KeypairsForm : System.Windows.Forms.Form {

        private ICloudService awsServices;
        private CloudAccount cloudAccount;

        public KeypairsForm(CloudAccount cloudAccount, ICloudService awsServices)
        {

            InitializeComponent();

            this.cloudAccount = cloudAccount;
            this.awsServices = awsServices;

        }

        private void KeypairsForm_Load(object sender, EventArgs e) {

            // Track this event.
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_FORM_OPEN, this.GetType().Name);

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {

            // Track this event.
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_FORM_OPEN, this.GetType().Name);

            if (KeyPairNameTextBox.TextLength == 0)
            {
                MessageBox.Show("A name for the keypair is required.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = KeyPairNameTextBox;
                return;
            }

            CloudStudio.SharedLibrary.Services.AWSServices.CreateKeyPairResponse response = awsServices.CreateKeyPair(KeyPairNameTextBox.Text);

            NewKeypairForm newKeyPairForm = new NewKeypairForm(response.KeyName, response.Fingerprint, response.Material);
            newKeyPairForm.ShowDialog();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

    }

}