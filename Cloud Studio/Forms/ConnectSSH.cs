using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Amazon.EC2.Model;
using CloudStudio.Services;
using CloudStudio.SharedLibrary.Domain;
using CloudStudio.GUI.Classes;
using CloudStudio.GUI.Utils;

namespace CloudStudio.GUI.Forms {

    public partial class ConnectSSHForm : System.Windows.Forms.Form {

        private Instance instance;
        private CloudAccount cloudAccount;

        private CloudAccountService CloudAccountService;
        private InstanceSSHConnectionService InstanceSSHConnectionService;
        private InstanceSSHConnection instanceSSHConnection;

        public ConnectSSHForm(Instance instance, CloudAccount cloudAccount) {

            InitializeComponent();

            this.instance = instance;
            this.cloudAccount = cloudAccount;

            this.CloudAccountService = new CloudAccountService();
            this.InstanceSSHConnectionService = new InstanceSSHConnectionService();

        }

        private void BrowseButton_Click(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            openFileDialog1.FileName = string.Empty;
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.Filter = "PPK files (*.ppk)|*.ppk|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 0;

            if (openFileDialog1.ShowDialog() == DialogResult.OK) {

                PrivateKeyFileTextBox.Text = openFileDialog1.FileName;

            }

        }

        private void buttonOk_Click(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            string userName = UserNameTextBox.Text;
            string host = instance.PublicIpAddress;
            string keyFile = PrivateKeyFileTextBox.Text;

            if (RememberCheckBox.Checked == true) {

                // Save this config to the database.
                InstanceSSHConnectionService.SaveInstanceSSHConnectionDetails(this.instance.InstanceId, userName, keyFile, this.cloudAccount.Id);

            } else {

                // Delete any config for this instance from the database.
                InstanceSSHConnectionService.DeleteInstanceSSHConnectionDetails(instanceSSHConnection);

            }

            if (Properties.Settings.Default.UseInternalSSH == true) {

                // Connect using putty.                           
                string program = Path.Combine(Application.StartupPath, "putty.exe");
                string arguments = String.Format("{0}@{1} -i {2}", userName, host, keyFile);

                Process process = System.Diagnostics.Process.Start(program, arguments);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();

            } else {

                // Launch an external SSH client.
                String program = Properties.Settings.Default.CustomSSH;
                String arguments = Properties.Settings.Default.CustomSSHParameters; 

                // Replace the variables in the arguments.
                arguments = arguments.Replace("${username}", userName)
                    .Replace("${keyfile}", userName)
                    .Replace("${host}", host);

                // Make sure the application exists.
                if (File.Exists(program) == true)
                {
                    Process process = System.Diagnostics.Process.Start(program, arguments);
                }
                else
                {
                    MessageBox.Show("The application " + program + " does not exist. Check your settings.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }

        }

        private void ConnectSSHForm_Load(object sender, EventArgs e) {

            // Track this event.
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_FORM_OPEN, this.GetType().Name);

            InstanceTextBox.Text = this.instance.InstanceId;

            // Is this connection saved?
            instanceSSHConnection = InstanceSSHConnectionService.GetByInstanceId(this.instance.InstanceId, this.cloudAccount.Id);

            if (instanceSSHConnection != null) {

                UserNameTextBox.Text = instanceSSHConnection.UserName;
                PrivateKeyFileTextBox.Text = instanceSSHConnection.KeyFilePath;

                RememberCheckBox.Checked = true;

            }

            this.ActiveControl = UserNameTextBox;

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

    }

}