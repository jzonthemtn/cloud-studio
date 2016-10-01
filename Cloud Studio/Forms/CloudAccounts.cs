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
using System.Windows.Input;
using CloudStudio.GUI.Utils;
using CloudStudio.Services.Utilities;
using CloudStudio.GUI.Classes;

namespace CloudStudio.GUI.Forms {

    public partial class CloudAccountsForm : System.Windows.Forms.Form
    {

        private static readonly ILog log = LogManager.GetLogger(typeof(CloudAccount));

        public CloudAccount SelectedCloudAccount { get; set; }
        private CloudAccountService svc;

        public CloudAccountsForm() {

            InitializeComponent();

            this.svc = new CloudAccountService();

        }

        private void CloudAccountsForm_Load(object sender, EventArgs e) {

            // Track this event.
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_FORM_OPEN, this.GetType().Name);

            loadCloudAccounts();

            if(cloudAccountsListView.Items.Count > 0)
            {
                // Select the first item.
                cloudAccountsListView.Items[0].Selected = true;
            }

        }

        private void loadCloudAccounts() {

            cloudAccountsListView.Items.Clear();

            IList<CloudAccount> accounts = svc.GetCloudAccounts(false);

            foreach(CloudAccount account in accounts) {
            
                ListViewItem i = new ListViewItem();
                i.Text = account.Description;
                i.SubItems.Add(account.AccessKey);
                i.SubItems.Add(account.Region);
                i.Tag = account;
                i.ImageIndex = 0;

                cloudAccountsListView.Items.Add(i);

            }

        }

        private void button1_Click(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            AddCloudAccount addCloudAccount = new AddCloudAccount();

            if (addCloudAccount.ShowDialog() == DialogResult.OK) {

                loadCloudAccounts();

            }

        }

        private void cloudAccountsListView_SelectedIndexChanged(object sender, EventArgs e) {

            if (cloudAccountsListView.SelectedItems.Count > 0) {

                OpenButton.Enabled = true;

            } else {

                OpenButton.Enabled = false;

            }

        }

        private void cloudAccountsListView_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e) {

            SelectCloudAccount();

        }

        private void CloseButton_Click(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();

        }

        private void OpenButton_Click(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            SelectCloudAccount();

        }

        private void SelectCloudAccount() {

            if (cloudAccountsListView.SelectedItems.Count > 0) {

                CloudAccount cloudAccount = (CloudAccount)cloudAccountsListView.SelectedItems[0].Tag;

                // Make sure this cloud account has the necessary keys.

                if (cloudAccount.AccessKey == null || cloudAccount.SecretKey == null)
                {
                    MessageBox.Show("Cloud account is incomplete. The cloud account's details must be edited.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.SelectedCloudAccount = cloudAccount;

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }                 

            } else {

                MessageBox.Show("Select a cloud account first.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void cloudAccountsListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {

        }

        private void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(cloudAccountsListView.SelectedItems.Count > 0)
            {
                CloudAccount cloudAccount = (CloudAccount)cloudAccountsListView.SelectedItems[0].Tag;
                if(MessageBox.Show("Delete account " + cloudAccount.Description + "?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    svc.Delete(cloudAccount);
                    cloudAccountsListView.SelectedItems[0].Remove();
                }                
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if(cloudAccountsListView.SelectedItems.Count > 0)
            {
                editCloudAccountToolStripMenuItem.Enabled = true;
                deleteAccountToolStripMenuItem.Enabled = true;
            }
            else
            {
                editCloudAccountToolStripMenuItem.Enabled = false;
                deleteAccountToolStripMenuItem.Enabled = false;
            }
        }

        private void editCloudAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);

            if (cloudAccountsListView.SelectedItems.Count > 0)
            {

                CloudAccount cloudAccount = (CloudAccount)cloudAccountsListView.SelectedItems[0].Tag;

                EditCloudAccount editCloudAccount = new EditCloudAccount(cloudAccount);

                if (editCloudAccount.ShowDialog() == DialogResult.OK)
                {

                    // If we made changes update the selected item in the list.
                    cloudAccount = editCloudAccount.GetCloudAccount();

                    // Because we made changes, the account key and secret key will
                    // come back as encrypted. We need to decrypt the access key for the display.
                    cloudAccount.AccessKey = EncryptionUtils.DecryptStringAES(cloudAccount.AccessKey);
                    cloudAccount.SecretKey = EncryptionUtils.DecryptStringAES(cloudAccount.SecretKey);

                    cloudAccountsListView.SelectedItems[0].SubItems[0].Text = cloudAccount.Description;
                    cloudAccountsListView.SelectedItems[0].SubItems[1].Text = cloudAccount.AccessKey;
                    cloudAccountsListView.SelectedItems[0].SubItems[2].Text = cloudAccount.Region;

                    // Update the cloud account in the tag.
                    cloudAccountsListView.SelectedItems[0].Tag = cloudAccount;

                }

            }
        }

    }

}
