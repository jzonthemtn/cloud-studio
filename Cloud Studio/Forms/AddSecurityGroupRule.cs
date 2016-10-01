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
using CloudStudio.Services.Model;

namespace CloudStudio.GUI.Forms {

    public partial class AddSecurityGroupRuleForm : System.Windows.Forms.Form
    {

        private ICloudService awsServices;
        private SecurityGroup group;
        private bool inbound;

        public AddSecurityGroupRuleForm(ICloudService awsServices, SecurityGroup group, bool inbound)
        {

            InitializeComponent();

            this.awsServices = awsServices;
            this.group = group;
            this.inbound = inbound;

        }

        private void AddSecurityGroupRule_Load(object sender, EventArgs e) {

            // Track this event.
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_FORM_OPEN, this.GetType().Name);

            GroupIDTextBox.Text = group.GroupId;
            TypeComboBox.SelectedIndex = 1;
            ProtocolComboBox.SelectedIndex = 1;

            this.ActiveControl = GroupIDTextBox;

        }

        private void TypeComboBox_SelectedIndexChanged(object sender, EventArgs e) {

            if(TypeComboBox.SelectedIndex == 0) {
            
                // All traffic.

                ProtocolComboBox.SelectedIndex = 0;
                ProtocolComboBox.Enabled = false;
                RangeComboBox.Text = "0 - 65535";
                RangeComboBox.Enabled = false;

            } else if (TypeComboBox.SelectedIndex == 1) {

                // Custom TCP Rule.

                ProtocolComboBox.SelectedIndex = 1;
                ProtocolComboBox.Enabled = false;
                RangeComboBox.Enabled = true;

            } else if (TypeComboBox.SelectedIndex == 2) {

                // Custom UDP Rule.

                ProtocolComboBox.SelectedIndex = 2;
                ProtocolComboBox.Enabled = false;
                RangeComboBox.Enabled = true;

            } else if (TypeComboBox.SelectedIndex == 3) {

                // Custom ICMP Rule.

                // TODO: Add in the ICMP protocols.
                ProtocolComboBox.Enabled = true;
                RangeComboBox.Text = "N/A";
                RangeComboBox.Enabled = false;

            } else if (TypeComboBox.SelectedIndex == 4) {

                // Custom Protocol.

                ProtocolComboBox.Text = String.Empty;
                ProtocolComboBox.Enabled = true;
                RangeComboBox.Text = "all";
                RangeComboBox.Enabled = false;

            } else if (TypeComboBox.SelectedIndex == 5) {

                // All TCP.

                ProtocolComboBox.SelectedIndex = 1;
                ProtocolComboBox.Enabled = false;
                RangeComboBox.Text = "0 - 65535";
                RangeComboBox.Enabled = false;

            } else if (TypeComboBox.SelectedIndex == 6) {

                // All UDP.

                ProtocolComboBox.SelectedIndex = 2;
                ProtocolComboBox.Enabled = false;
                RangeComboBox.Text = "0 - 65535";
                RangeComboBox.Enabled = false;

            } else if (TypeComboBox.SelectedIndex == 7) {

                // All ICMP.

                ProtocolComboBox.SelectedIndex = 3; ;
                ProtocolComboBox.Enabled = false;
                RangeComboBox.Text = "0 - 65535";
                RangeComboBox.Enabled = false;

            } else if (TypeComboBox.SelectedIndex == 8) {

                // All Traffic.

                ProtocolComboBox.SelectedIndex = 0;
                ProtocolComboBox.Enabled = false;
                RangeComboBox.Text = "0 - 65535";
                RangeComboBox.Enabled = false;

            } else {

                ProtocolComboBox.SelectedIndex = 1;
                ProtocolComboBox.Enabled = false;
                RangeComboBox.Text = AwsUtils.GetPortFromType(TypeComboBox.Text).ToString();
                RangeComboBox.Enabled = false;

            }

        }

        private void ProtocolComboBox_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private Boolean IsNumber(String value) {
            return value.All(Char.IsDigit);
        }

        private void buttonOk_Click(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            int port = 0;

            if(IsNumber(TypeComboBox.Text) == true) {
            
                port = Convert.ToInt32(TypeComboBox.Text);

                if (port < 0 || port > 65535) {

                    MessageBox.Show("Invalid port specified. Valid values are between 0 and 65535.", Application.ProductName);
                    TypeComboBox.Focus();
                    return;

                }

            } else {

                if (AwsUtils.IsValidType(TypeComboBox.Text) == true) {

                    port = AwsUtils.GetPortFromType(TypeComboBox.Text);

                } else {

                    MessageBox.Show("Invalid type. Select a type or enter a numeric value between 0 and 65535.", Application.ProductName);
                    TypeComboBox.Focus();
                    return;

                }
            
            }

            IpPermission p = new IpPermission();
            p.IpProtocol = ProtocolComboBox.Text;
            p.FromPort = port;
            p.ToPort = port;
            p.IpRanges = new List<string> { SourceTextBox.Text };

            // p.UserIdGroupPairs is for EC2-classic.

            List<IpPermission> ipPermissions = new List<IpPermission>();
            ipPermissions.Add(p);

            GenericActionResponse response = awsServices.AddRules(this.group.GroupId, ipPermissions);

            if (response.Success == false) {

                MessageUtils.ShowErrorMessage(response.EventError.ToString());

            } else {

                this.DialogResult = DialogResult.OK;
                this.Close();

            }

        }

        private void UseMyIpAddressLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;

            // TODO: Implement way to get the user's IP address.
            string ip = "127.0.0.1";
            this.Cursor = Cursors.Default;

            if(ip == Constants.UNKNOWN_IP)
            {
                MessageBox.Show("Unable to get your IP address.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Put the IP into the box.
                SourceTextBox.Text = ip + "/32";
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

    }

}