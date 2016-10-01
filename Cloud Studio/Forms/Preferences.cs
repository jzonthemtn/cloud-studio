using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CloudStudio.GUI.Settings;
using CloudStudio.Services;
using CloudStudio.SharedLibrary.Services.AWSServices;
using CloudStudio.SharedLibrary.Domain;
using CloudStudio.Services.Services;
using CloudStudio.GUI.Classes;
using CloudStudio.GUI.Utils;

namespace CloudStudio.GUI.Forms {

    public partial class PreferencesForm : System.Windows.Forms.Form
    {

        private CloudAccountService CloudAccountService;

        public PreferencesForm(CloudAccountService CloudAccountService) {

            InitializeComponent();

            this.CloudAccountService = CloudAccountService;

        }

        private void PreferencesForm_Load(object sender, EventArgs e) {

            // Track this event.
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_FORM_OPEN, this.GetType().Name);

            IList<CloudAccount> cloudAccounts = CloudAccountService.GetCloudAccounts(false);

            if (cloudAccounts.Count > 0) {

                foreach (CloudAccount account in cloudAccounts) {

                    CloudAccountsComboBox.Items.Add(account);

                }

                CloudAccountsComboBox.SelectedIndex = 0;

                // Load the favorite AMIs.

                List<FavoriteAMI> favoriteAMIs = Properties.Settings.Default.FavoriteAMIs;

                if (favoriteAMIs != null && favoriteAMIs.Count > 0) {

                    foreach (FavoriteAMI favoriteAMI in favoriteAMIs) {

                        ListViewItem item = new ListViewItem(favoriteAMI.Ami);

                        FavoriteAMIsListView.Items.Add(item);

                    }

                }

            } else {

                MessageBox.Show("At least one cloud account must be added before preferences can be set.", Application.ProductName);
                this.Close();

            }

        }

        private void AddFavoriteAMIButton_Click(object sender, EventArgs e) {

            AddFavoriteAMIForm afaf = new AddFavoriteAMIForm();
            if (afaf.ShowDialog() == DialogResult.OK) {

                ListViewItem lvi = new ListViewItem();
                lvi.Text = afaf.AMI;
                lvi.SubItems.Add(afaf.Name);

                FavoriteAMIsListView.Items.Add(lvi);

            }

        }

        private void SaveFavoriteAMIs() {

            // Save the favorite AMIs.
            List<FavoriteAMI> favoriteAMIs = new List<FavoriteAMI>();

            foreach (ListViewItem item in FavoriteAMIsListView.Items) {

                favoriteAMIs.Add(new FavoriteAMI(item.Text));

            }

            Properties.Settings.Default.FavoriteAMIs = favoriteAMIs;

        }

        private void buttonOk_Click(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            SaveFavoriteAMIs();

        }

        private void FavoriteAMIsListView_SelectedIndexChanged(object sender, EventArgs e) {

            if (FavoriteAMIsListView.SelectedItems.Count > 0) {

                RemoveFavoriteAMIButton.Enabled = true;

            } else {

                RemoveFavoriteAMIButton.Enabled = false;

            }

        }

        private void ValidateButton_Click(object sender, EventArgs e) {

            CloudAccount cloudAccount = (CloudAccount) CloudAccountsComboBox.SelectedItem;

            CloudServiceConfig cloudServiceConfig = MainMDIForm.BuildCloudServiceConfig();
            AwsService awsServices = new AwsService(cloudAccount, cloudServiceConfig);

            foreach (ListViewItem lvi in FavoriteAMIsListView.Items) {

                GetImagesResponse response = awsServices.GetImages(new List<string> {lvi.Text});

                if(response.Success == false) {
                
                    lvi.ForeColor = Color.Red;

                }

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
