using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Amazon;
using CloudStudio.GUI.Settings;
using CloudStudio.Services;
using CloudStudio.SharedLibrary.Services.AWSServices;
using CloudStudio.GUI.Utils;
using CloudStudio.Services.Utilities;
using CloudStudio.GUI.Classes;
using CloudStudio.Services.Model;
using CloudStudio.SharedLibrary;

namespace CloudStudio.GUI.Forms {

    public partial class SettingsForm : System.Windows.Forms.Form
    {

        public SettingsForm() {

            InitializeComponent();

        }

        private void SettingsForm_Load(object sender, EventArgs e) {

            // Track this event.
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_FORM_OPEN, this.GetType().Name);

            GetRegionEndpointsResponse response = CloudStudio.GUI.Utils.AwsUtils.GetRegionEndpoints();

            foreach (RegionEndpoint endpoint in response.Endpoints) {

                ListViewItem item = new ListViewItem(endpoint.DisplayName);
                item.SubItems.Add(endpoint.SystemName);

                StandardEndpointsListView.Items.Add(item);

            }

            // Load the custom endpoints.

            List<CustomEndpoint> endpoints = Properties.Settings.Default.CustomEndpoints;

            if (endpoints != null && endpoints.Count > 0) {

                foreach (CustomEndpoint endpoint in endpoints) {

                    ListViewItem item = new ListViewItem(endpoint.Name);
                    item.SubItems.Add(endpoint.Url);

                    CustomEndpointsListView.Items.Add(item);

                }

            }            

            // Load the Network tab.
            TimeoutNumericUpDown.Value = Properties.Settings.Default.Timeout;
            ProxyCheckBox.Checked = Properties.Settings.Default.UseProxy;
            ProxyHostTextBox.Text = Properties.Settings.Default.ProxyHost; 
            ProxyPortTextBox.Text = Properties.Settings.Default.ProxyPort.ToString();
            ProxyUserNameTextBox.Text = Properties.Settings.Default.ProxyUserName;
            ProxyPasswordTextBox.Text = EncryptionUtils.DecryptStringAES(Properties.Settings.Default.ProxyPassword);

            // Load the Applications tab.
            UseInternalSSHRadioButton.Checked = Properties.Settings.Default.UseInternalSSH;
            ExternalSSHTextBox.Text = Properties.Settings.Default.CustomSSH;
            ExternalSSHParamtersTextBox.Text = Properties.Settings.Default.CustomSSHParameters;
            UseWindowsRDPClientRadioButton.Checked = Properties.Settings.Default.UseWindowsRDP;
            ExternalRDPClientTextBox.Text = Properties.Settings.Default.CustomRDP;
            ExternalRDPClientParametersTextBox.Text = Properties.Settings.Default.CustomRDPParameters;

            // Load the General tab.
            CheckForUpdatesCheckBox.Checked = Properties.Settings.Default.CheckForUpdates;
            ShowWelcomeCheckBox.Checked = Properties.Settings.Default.ShowWelcome;            
            InstanceIDCheckBox.Checked = Properties.Settings.Default.ShowInstanceID;
            PublicIPCheckBox.Checked = Properties.Settings.Default.ShowPublicIP;
            PublicDNSNameCheckBox.Checked = Properties.Settings.Default.PublicDNSName;
            PrivateIPCheckBox.Checked = Properties.Settings.Default.PrivateIP;
            InstanceNameCheckBox.Checked = Properties.Settings.Default.InstanceName;            

        }

        private void AddCustomEndpointButton_Click(object sender, EventArgs e) {

            AddCustomEndpointForm acef = new AddCustomEndpointForm();
            if (acef.ShowDialog() == DialogResult.OK) {

                ListViewItem lvi = new ListViewItem();
                lvi.Text = acef.Name;
                lvi.SubItems.Add(acef.Url);

                CustomEndpointsListView.Items.Add(lvi);

            }

        }

        private void CustomEndpointsListView_SelectedIndexChanged(object sender, EventArgs e) {

            if (CustomEndpointsListView.SelectedItems.Count > 0) {

                RemoveCustomEndpointButton.Enabled = true;

            } else {

                RemoveCustomEndpointButton.Enabled = false;

            }

        }

        private void RemoveCustomEndpointButton_Click(object sender, EventArgs e) {

            CustomEndpointsListView.Items.RemoveAt(CustomEndpointsListView.SelectedIndices[0]);

        }
     
        private void SaveCustomEndpoints() {

            // Save the custom endpoints.
            List<CustomEndpoint> endpoints = new List<CustomEndpoint>();

            foreach (ListViewItem item in CustomEndpointsListView.Items) {

                endpoints.Add(new CustomEndpoint(item.Text, item.SubItems[1].Text));

            }

            Properties.Settings.Default.CustomEndpoints = endpoints;

        }

        private void buttonOk_Click(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            SaveCustomEndpoints();

            // Save the Network tab.
            Properties.Settings.Default.Timeout = Convert.ToInt32(TimeoutNumericUpDown.Value);
            Properties.Settings.Default.UseProxy = ProxyCheckBox.Checked;
            Properties.Settings.Default.ProxyHost = ProxyHostTextBox.Text;
            Properties.Settings.Default.ProxyPort = Convert.ToInt32(ProxyPortTextBox.Text);
            Properties.Settings.Default.ProxyUserName = ProxyUserNameTextBox.Text;
            Properties.Settings.Default.ProxyPassword = EncryptionUtils.EncryptStringAES(ProxyPasswordTextBox.Text);

            // Save the Applications tab.
            Properties.Settings.Default.UseInternalSSH = UseInternalSSHRadioButton.Checked;
            Properties.Settings.Default.CustomSSH = ExternalSSHTextBox.Text;
            Properties.Settings.Default.CustomSSHParameters = ExternalSSHParamtersTextBox.Text;
            Properties.Settings.Default.UseWindowsRDP = UseWindowsRDPClientRadioButton.Checked;
            Properties.Settings.Default.CustomRDP = ExternalRDPClientTextBox.Text;
            Properties.Settings.Default.CustomRDPParameters = ExternalRDPClientParametersTextBox.Text;
            
            // Save the General tab.
            Properties.Settings.Default.CheckForUpdates = CheckForUpdatesCheckBox.Checked;            
            Properties.Settings.Default.ShowInstanceID = InstanceIDCheckBox.Checked;
            Properties.Settings.Default.ShowPublicIP = PublicIPCheckBox.Checked;
            Properties.Settings.Default.PublicDNSName = PublicDNSNameCheckBox.Checked;
            Properties.Settings.Default.PrivateIP = PrivateIPCheckBox.Checked;
            Properties.Settings.Default.InstanceName = InstanceNameCheckBox.Checked;
            Properties.Settings.Default.ShowWelcome = ShowWelcomeCheckBox.Checked;

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void CustomEndpointsListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            
        }

        private void StandardEndpointsListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
          
        }

        private void ProxyCheckBox_CheckedChanged(object sender, EventArgs e) {

            ProxyGroupBox.Enabled = ProxyCheckBox.Checked;

        }

        private void UseCustomRDPClientRadioButton_CheckedChanged(object sender, EventArgs e) {

            ExternalRDPClientExecutableLabel.Enabled = UseCustomRDPClientRadioButton.Checked;
            ExternalRDPClientTextBox.Enabled = UseCustomRDPClientRadioButton.Checked;
            ExternalRDPClientParametersLabel.Enabled = UseCustomRDPClientRadioButton.Checked;
            ExternalRDPClientParametersTextBox.Enabled = UseCustomRDPClientRadioButton.Checked;

        }

        private void UseCustomSSHRadioButton_CheckedChanged(object sender, EventArgs e) {

            SSHExecutableLabel.Enabled = UseCustomSSHRadioButton.Checked;
            ExternalSSHTextBox.Enabled = UseCustomSSHRadioButton.Checked;
            ExternalSSHParamtersTextBox.Enabled = UseCustomSSHRadioButton.Checked;
            ExternalSSHParamtersLabel.Enabled = UseCustomSSHRadioButton.Checked;

        }

        private void BrowseSSHExecutableButton_Click(object sender, EventArgs e) {

            openFileDialog1.FileName = string.Empty;
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.Filter = "Programs (*.exe)|*.exe|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.Title = "Select SSH Client";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {

                ExternalSSHTextBox.Text = openFileDialog1.FileName;

            }

        }

        private void BrowseRDPExecutableButton_Click(object sender, EventArgs e) {

            openFileDialog1.FileName = string.Empty;
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.Filter = "Programs (*.exe)|*.exe|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.Title = "Select RDP Client";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {

                ExternalRDPClientTextBox.Text = openFileDialog1.FileName;

            }

        }

        private void SSHVariablesLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {

            VariablesForm vf = new VariablesForm(Constants.RemoteConnectVariables);
            vf.Show();

        }

        private void RDPVariablesLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {

            VariablesForm vf = new VariablesForm(Constants.RemoteConnectVariables);
            vf.Show();

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

    }

}
