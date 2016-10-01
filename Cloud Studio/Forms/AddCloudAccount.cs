using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CloudStudio.SharedLibrary.Domain;
using CloudStudio.Services;
using log4net;
using CloudStudio.Services;
using Amazon.EC2.Model;
using Amazon;
using CloudStudio.SharedLibrary.Services.AWSServices;
using CloudStudio.GUI.Settings;
using CloudStudio.Services.Utilities;
using CloudStudio.GUI.Classes;
using CloudStudio.GUI.Utils;

namespace CloudStudio.GUI.Forms {

    public partial class AddCloudAccount : System.Windows.Forms.Form
    {

        private static readonly ILog log = LogManager.GetLogger(typeof(AddCloudAccount));

        public AddCloudAccount() {

            InitializeComponent();

        }

        private void AddCloudAccount_Load(object sender, EventArgs e) {

            // Track this event.
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_FORM_OPEN, this.GetType().Name);

            LoadRegions();

            this.ActiveControl = DescriptionTextBox;

        }

        private void LoadRegions() {

            GetRegionEndpointsResponse getRegionEndpointsResponse = AwsUtils.GetRegionEndpoints();

            foreach (RegionEndpoint endpoint in getRegionEndpointsResponse.Endpoints) {

                RegionsComboBox.Items.Add(endpoint);

            }

            RegionsComboBox.SelectedIndex = 0;

        }

        private void LoadCustomEndpoints() {

            CustomComboBox.Items.Clear();

            List<CustomEndpoint> endpoints = Properties.Settings.Default.CustomEndpoints;

            if (endpoints != null && endpoints.Count > 0) {

                foreach (CustomEndpoint endpoint in endpoints) {

                    CustomComboBox.Items.Add(endpoint);

                }

                CustomRegionsRadioButton.Enabled = true;

            } else {

                CustomRegionsRadioButton.Enabled = false;

            }

        }

        private void buttonOk_Click(object sender, EventArgs e) {

            CloudAccountService svc = new CloudAccountService();

            // All fields are required.
            if (AccessKeyTextBox.TextLength > 0 && DescriptionTextBox.TextLength > 0) {

                // Are the lengths valid?
                if (DescriptionTextBox.TextLength <= 20) {

                    // Is the description unique?
                    if (svc.GetCloudAccountByDescription(DescriptionTextBox.Text) == null) {

                        CloudAccount cloudAccount = new CloudAccount();
                        cloudAccount.Provider = "AWS";
                        cloudAccount.AccessKey = AccessKeyTextBox.Text;                        
                        cloudAccount.Description = DescriptionTextBox.Text;
                        cloudAccount.Region = ((RegionEndpoint)RegionsComboBox.SelectedItem).SystemName;
                        cloudAccount.Enabled = true;
                        cloudAccount.ReadOnlyMode = ReadOnlyModeCheckBox.Checked;

                        if(SecretKeyTextBox.TextLength == 0)
                        {
                            cloudAccount.SecretKey = "none";
                        }
                        else
                        {
                            cloudAccount.SecretKey = SecretKeyTextBox.Text;
                        }

                        svc.SaveCloudAccount(cloudAccount);

                        this.DialogResult = DialogResult.OK;
                        this.Close();

                    } else {

                        MessageBox.Show("The description must be unique for all added cloud accounts.", Application.ProductName);
                        DescriptionTextBox.Focus();

                    }

                } else {

                    MessageBox.Show("The description must be 20 characters or less.", Application.ProductName);
                    DescriptionTextBox.Focus();

                }

            } else {

                MessageBox.Show("All fields are required.", Application.ProductName);

            }

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

        }

        private void CustomRegionsRadioButton_CheckedChanged(object sender, EventArgs e) {

            CustomComboBox.Enabled = CustomRegionsRadioButton.Checked;

        }

        private void AWSRegionsRadioButton_CheckedChanged(object sender, EventArgs e) {

            RegionsComboBox.Enabled = AWSRegionsRadioButton.Checked;

        }

        private void AddCustomEndpointLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {

            SettingsForm sf = new SettingsForm();
            if (sf.ShowDialog() == DialogResult.OK) {

                LoadCustomEndpoints();

            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

    }

}