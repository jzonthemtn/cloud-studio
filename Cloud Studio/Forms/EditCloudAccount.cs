using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CloudStudio.SharedLibrary.Domain;
using CloudStudio.Services;
using log4net;
using Amazon;
using CloudStudio.Services;
using CloudStudio.SharedLibrary.Services.AWSServices;
using CloudStudio.Services.Utilities;
using CloudStudio.GUI.Classes;
using CloudStudio.GUI.Utils;

namespace CloudStudio.GUI.Forms {

    public partial class EditCloudAccount : System.Windows.Forms.Form {

        private static readonly ILog log = LogManager.GetLogger(typeof(EditCloudAccount));

        private CloudAccount cloudAccount;

        public EditCloudAccount(CloudAccount cloudAccount) {

            InitializeComponent();

            this.cloudAccount = cloudAccount;

        }

        public CloudAccount GetCloudAccount()
        {
            return this.cloudAccount;
        }

        private void EditCloudAccount_Load(object sender, EventArgs e) {

            // Track this event.
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_FORM_OPEN, this.GetType().Name);

            LoadRegions();

            AccessKeyTextBox.Text = cloudAccount.AccessKey;
            
            DescriptionTextBox.Text = cloudAccount.Description;
            EnabledCheckBox.Checked = cloudAccount.Enabled;
            ReadOnlyModeCheckBox.Checked = cloudAccount.ReadOnlyMode;

            if(cloudAccount.SecretKey != "none")
            {
                SecretKeyTextBox.Text = cloudAccount.SecretKey;
            }
            else
            {
                SecretKeyTextBox.Text = string.Empty;
            }

            for(int x = 0; x < RegionsComboBox.Items.Count; x++) {

                RegionEndpoint endpoint = (RegionEndpoint) RegionsComboBox.Items[x];

                if (endpoint.SystemName == cloudAccount.Region) {
                    RegionsComboBox.SelectedIndex = x;
                    break;
                }

            }

            this.ActiveControl = DescriptionTextBox;

        }

        private void LoadRegions() {

            GetRegionEndpointsResponse getRegionEndpointsResponse = AwsUtils.GetRegionEndpoints();

            foreach (RegionEndpoint endpoint in getRegionEndpointsResponse.Endpoints) {

                RegionsComboBox.Items.Add(endpoint);

            }

            RegionsComboBox.SelectedIndex = 0;

        }

        private void buttonOk_Click(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            CloudAccountService svc = new CloudAccountService();

            // All fields are required.
            if (AccessKeyTextBox.TextLength > 0 && DescriptionTextBox.TextLength > 0) {

                // Are the lengths valid?
                if (DescriptionTextBox.TextLength <= 20) {

                    // Get any cloud accounts that also have this name.
                    CloudAccount act = svc.GetCloudAccountByDescription(DescriptionTextBox.Text);

                    // If the name is not unique see if it is the same cloud account.
                    if (act == null || act.Id == this.cloudAccount.Id) {

                        this.cloudAccount.AccessKey = AccessKeyTextBox.Text;
                        this.cloudAccount.Description = DescriptionTextBox.Text;
                        this.cloudAccount.Enabled = EnabledCheckBox.Checked;
                        this.cloudAccount.ReadOnlyMode = ReadOnlyModeCheckBox.Checked;

                        if (SecretKeyTextBox.TextLength == 0)
                        {
                            cloudAccount.SecretKey = "none";
                        }
                        else
                        {
                            cloudAccount.SecretKey = SecretKeyTextBox.Text;
                        }

                        svc.SaveCloudAccount(cloudAccount);

                        // Close the dialog.
                        this.DialogResult = DialogResult.OK;
                        this.Close();

                    } else {

                        MessageBox.Show("The description must be unique for all added cloud accounts.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DescriptionTextBox.Focus();

                    }

                } else {

                    MessageBox.Show("The description must be 20 characters or less.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DescriptionTextBox.Focus();

                }

            } else {

                MessageBox.Show("All fields are required.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

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