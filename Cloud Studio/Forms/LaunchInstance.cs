using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Amazon.EC2.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CloudStudio.Services;
using CloudStudio.SharedLibrary.Domain;
using CloudStudio.SharedLibrary.Services.AWSServices;
using CloudStudio.GUI.Settings;
using CloudStudio.GUI.Utils;
using CloudStudio.Services.Utilities;
using CloudStudio.Services.Services;
using CloudStudio.GUI.Classes;
using CloudStudio.Services.Model;
using CloudStudio.SharedLibrary;

namespace CloudStudio.GUI.Forms {

    public partial class LaunchInstanceForm : System.Windows.Forms.Form {

        private CloudAccount cloudAccount;
        private ICloudService awsServices;
        private Image preSelectedImage;

        private IList<Vpc> vpcs;

        public LaunchInstanceForm(CloudAccount cloudAccount, ICloudService awsServices)
        {

            InitializeComponent();

            this.cloudAccount = cloudAccount;
            this.awsServices = awsServices;
           
        }

        public LaunchInstanceForm(CloudAccount cloudAccount, AwsService awsServices, Image image) {

            InitializeComponent();

            this.cloudAccount = cloudAccount;
            this.awsServices = awsServices;
            this.preSelectedImage = image;

        }

        private void LaunchInstanceForm_Load(object sender, EventArgs e) {

            // Track this event.
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_FORM_OPEN, this.GetType().Name);

            GetInstanceTypesResponse getInstanceTypesResponse = awsServices.GetInstanceTypes();

            foreach (string type in getInstanceTypesResponse.InstanceTypes) {
                InstanceTypesComboBox.Items.Add(type);
            }

            InstanceTypesComboBox.SelectedIndex = 0;

            LoadKeyPairs();

            // Load the favorite AMIs.
            List<string> amis = new List<string>();

            foreach (FavoriteAMI favoriteAmi in Properties.Settings.Default.FavoriteAMIs) {

                amis.Add(favoriteAmi.Ami);

            }

            GetImagesResponse getFavoriteImagesResponse = awsServices.GetImages(amis);

            foreach (Image image in getFavoriteImagesResponse.Images) {

                ListViewItem lvi = new ListViewItem(image.ImageId);
                lvi.SubItems.Add(image.Name);
                lvi.SubItems.Add(image.Description);
                lvi.Tag = image;
                lvi.ImageIndex = 3;

                ImagesListView.Items.Add(lvi);

            }

            GetImagesResponse getMyImagesResponse = awsServices.GetMyImages();

            foreach (Image image in getMyImagesResponse.Images) {

                ListViewItem lvi = new ListViewItem(image.ImageId);
                lvi.SubItems.Add(image.Name);
                lvi.SubItems.Add(image.Description);
                lvi.Tag = image;
                lvi.ImageIndex = 0;

                if (preSelectedImage != null && preSelectedImage.ImageId == image.ImageId)
                {
                    lvi.Selected = true;
                }

                ImagesListView.Items.Add(lvi);

            }

            GetImagesResponse getImagesResponse = awsServices.GetCommonImages();

            foreach (Image image in getImagesResponse.Images) {

                ListViewItem lvi = new ListViewItem(image.ImageId);
                lvi.SubItems.Add(image.Name);
                lvi.SubItems.Add(image.Description);
                lvi.Tag = image;
                lvi.ImageIndex = 1;

                ImagesListView.Items.Add(lvi);

            }

            GetVpcsResponse getVpcsResponse = awsServices.GetVpcs();

            foreach (Vpc vpc in getVpcsResponse.Vpcs) {

                GetSubnetsResponse getSubnetsResponse = awsServices.GetSubnets(vpc);

                foreach (Subnet subnet in getSubnetsResponse.Subnets) {

                    VpcsSubnetsComboBox.Items.Add(vpc.VpcId + " : " + subnet.SubnetId + " : " + subnet.CidrBlock + " : " + CloudStudio.GUI.Utils.AwsUtils.GetNameFromTags(subnet.Tags));

                }                               

            }

            vpcs = getVpcsResponse.Vpcs;

            VpcsSubnetsComboBox.SelectedIndex = 0;           

        }

        private void LoadKeyPairs()
        {
            KeyNameComboBox.Items.Clear();

            GetKeyNamesResponse getKeyNamesResponse = awsServices.GetKeyNames();

            foreach (KeyPairInfo kpi in getKeyNamesResponse.KeyPairs)
            {
                KeyNameComboBox.Items.Add(kpi.KeyName);
            }

            KeyNameComboBox.SelectedIndex = 0;
        }

        private void buttonOk_Click(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            if (tabControl1.SelectedIndex == 0) {

                // Launch on-demand instance(s).

                if (ImagesListView.SelectedItems.Count == 0 || AmiTextBox.TextLength == 0)
                {

                    MessageBox.Show("Select or specify an image to launch.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                string imageId = AmiTextBox.Text;
                string instanceType = InstanceTypesComboBox.SelectedItem.ToString();                
                int minCount = Convert.ToInt32(InstancesNumericUpDown.Value);
                int maxCount = Convert.ToInt32(InstancesNumericUpDown.Value);
                string keyName = KeyNameComboBox.SelectedItem.ToString();
                string subnetId = VpcsSubnetsComboBox.SelectedItem.ToString().Split(':')[1].Trim();

                List<string> securityGroupIds = new List<string>();

                foreach (ListViewItem lvi in SecurityGroupsListView.SelectedItems) {

                    SecurityGroup group = (SecurityGroup)lvi.Tag;
                    securityGroupIds.Add(group.GroupId);

                }

                awsServices.LaunchInstance(imageId, instanceType, minCount, maxCount, keyName, subnetId, securityGroupIds);

                this.DialogResult = DialogResult.OK;
                this.Close();

            } else if (tabControl1.SelectedIndex == 1) {

                // TODO: Spot requests.

            }        

        }

        private void buttonCancel_Click(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void VpcsSubnetsComboBox_SelectedIndexChanged(object sender, EventArgs e) {

            LoadSecurityGroups();

        }

        private void CreateNewSecurityGroupLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {

            // Track this event.
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_FORM_OPEN, this.GetType().Name);

            SecurityGroupsForm sgf = new SecurityGroupsForm(this.cloudAccount, this.awsServices, this.vpcs);
            sgf.ShowDialog();

            // Reload the list of security groups.
            LoadSecurityGroups();

        }

        private void LoadSecurityGroups() {

            // Get the selected VPC.
            string vpcId = VpcsSubnetsComboBox.SelectedItem.ToString().Split(':')[0].Trim();

            // Load the security groups for the selected VPC.

            GetSecurityGroupsResponse getSecurityGroupsResponse = awsServices.GetSecurityGroups(vpcId);

            SecurityGroupsListView.Items.Clear();

            foreach (SecurityGroup group in getSecurityGroupsResponse.SecurityGroups) {

                ListViewItem lvi = new ListViewItem(group.GroupId);
                lvi.SubItems.Add(group.GroupName);
                lvi.SubItems.Add(group.Description);
                lvi.Tag = group;
                lvi.ImageIndex = 2;

                SecurityGroupsListView.Items.Add(lvi);

            }

        }

        private void ImagesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ImagesListView.SelectedItems.Count > 0)
            {
                AmiTextBox.Text = ImagesListView.SelectedItems[0].Text;
            }
        }

        private void ManageKeysLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Track this event.
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_FORM_OPEN, this.GetType().Name);

            KeypairsForm keypairsForm = new KeypairsForm(cloudAccount, awsServices);
            keypairsForm.ShowDialog();

            // Refresh the list of keys.
            LoadKeyPairs();

        }

    }

}