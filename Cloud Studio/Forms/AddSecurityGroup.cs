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
using CloudStudio.GUI.Utils;
using CloudStudio.Services.Services;
using CloudStudio.Services.Utilities;
using CloudStudio.SharedLibrary.Services.AWSServices;
using CloudStudio.GUI.Classes;
using CloudStudio.SharedLibrary;

namespace CloudStudio.GUI.Forms {

    public partial class AddSecurityGroupForm : System.Windows.Forms.Form
    {

        private ICloudService awsServices;
        private IList<Vpc> vpcs;
        private string selectedVpcId;

        public AddSecurityGroupForm(ICloudService awsServices, IList<Vpc> vpcs, string selectedVpcId)
        {

            InitializeComponent();

            this.awsServices = awsServices;
            this.vpcs = vpcs;
            this.selectedVpcId = selectedVpcId;

        }

        private void AddSecurityGroupRule_Load(object sender, EventArgs e) {

            // Track this event.
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_FORM_OPEN, this.GetType().Name);

            foreach (Vpc vpc in this.vpcs) {

                VPCsComboBox.Items.Add(vpc.VpcId + " : " + AwsUtils.GetNameFromTags(vpc.Tags));

            }

            for (int x = 0; x < VPCsComboBox.Items.Count; x++ )
            {

                string vpcId = VPCsComboBox.Items[x].ToString().Split(':')[0].Trim();
                if(vpcId == selectedVpcId)
                {
                    VPCsComboBox.SelectedIndex = x;
                    break;
                }
            }

            this.ActiveControl = VPCsComboBox;

        }

        private void buttonOk_Click(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            if (NameTextBox.TextLength < 256) {

                // Get the selected VPC.
                string vpcId = VPCsComboBox.SelectedItem.ToString().Split(':')[0].Trim();

                GenericActionResponse response = awsServices.CreateSecurityGroup(vpcId, NameTextBox.Text, DescriptionTextBox.Text);

                if (response.Success == false) {

                    MessageUtils.ShowErrorMessage("Unable to create group.");

                } else {

                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }

            } else {

                MessageBox.Show("The maximum length for a group name is 255 characters.", Application.ProductName);
                NameTextBox.Focus();

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
