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
using CloudStudio.Services.Utilities;
using CloudStudio.SharedLibrary;
using CloudStudio.SharedLibrary.Domain;
using CloudStudio.SharedLibrary.Services.AWSServices;
using CloudStudio.GUI.Classes;
using CloudStudio.GUI.Utils;

namespace CloudStudio.GUI.Forms {

    public partial class SecurityGroupsForm : System.Windows.Forms.Form
    {

        private ICloudService awsServices;
        private IList<Vpc> vpcs;
        private CloudAccount cloudAccount;

        public SecurityGroupsForm(CloudAccount cloudAccount, ICloudService awsServices, IList<Vpc> vpcs)
        {

            InitializeComponent();

            this.cloudAccount = cloudAccount;
            this.awsServices = awsServices;
            this.vpcs = vpcs;

        }

        private void SecurityGroups_Load(object sender, EventArgs e) {

            // Track this event.
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_FORM_OPEN, this.GetType().Name);

            foreach (Vpc vpc in this.vpcs) {

                VPCsComboBox.Items.Add(vpc.VpcId + " : " + AwsUtils.GetNameFromTags(vpc.Tags));

            }

            if (this.vpcs.Count > 0) {

                VPCsComboBox.SelectedIndex = 0;

            }

            if (this.vpcs.Count == 1) {

                VPCsComboBox.Enabled = false;

            } else if(this.vpcs.Count > 1) {

                VPCsComboBox.Enabled = true;

            }

        }

        private void VPCsComboBox_SelectedIndexChanged(object sender, EventArgs e) {

            // Get the selected VPC.
            string vpcId = VPCsComboBox.SelectedItem.ToString().Split(':')[0].Trim();

            LoadSecurityGroups(vpcId);

        }

        private void LoadSecurityGroups(string vpcId) {

            // Load the security groups for the selected VPC.

            GetSecurityGroupsResponse getSecurityGroupsResponse = awsServices.GetSecurityGroups(vpcId);

            GroupsSortableListView.Items.Clear();
            InSortableListView.Items.Clear();
            OutSortableListView.Items.Clear();

            foreach (SecurityGroup group in getSecurityGroupsResponse.SecurityGroups) {

                ListViewItem lvi = new ListViewItem(group.GroupId);
                lvi.SubItems.Add(group.GroupName);
                lvi.SubItems.Add(group.Description);
                lvi.SubItems.Add(group.VpcId);

                lvi.Tag = group;
                lvi.ImageIndex = 0;

                GroupsSortableListView.Items.Add(lvi);

            }

        }

        private void GroupsSortableListView_MouseClick(object sender, MouseEventArgs e) {

            if (GroupsSortableListView.SelectedItems.Count > 0) {

                InSortableListView.Items.Clear();
                OutSortableListView.Items.Clear();

                ListViewItem lvis = GroupsSortableListView.SelectedItems[0];

                SecurityGroup group = (SecurityGroup)lvis.Tag;

                SecurityGroupLabel.Text = group.GroupId + " - " + group.GroupName;

                LoadRulesForGroup(group);

            }

        }

        private void LoadRulesForGroup(SecurityGroup group) {

            // Load the ingress rules.

            InSortableListView.Items.Clear();                

            foreach (IpPermission p in group.IpPermissions) {

                string protocol = p.IpProtocol.ToUpper();
                if (protocol == "-1") {
                    protocol = "ALL";
                }

                ListViewItem lvi = new ListViewItem(AwsUtils.GetTypeFromPort(p.ToPort));
                lvi.SubItems.Add(protocol);
                lvi.SubItems.Add(p.FromPort + "->" + p.ToPort);
                lvi.SubItems.Add(String.Join(", ", p.IpRanges.ToArray()));

                lvi.ImageIndex = 4;
                lvi.Tag = p;

                InSortableListView.Items.Add(lvi);

            }

            // Load the egress rules.

            OutSortableListView.Items.Clear();

            foreach (IpPermission p in group.IpPermissionsEgress) {

                string protocol = p.IpProtocol.ToUpper();
                if (protocol == "-1") {
                    protocol = "ALL";
                }

                ListViewItem lvi = new ListViewItem(AwsUtils.GetTypeFromPort(p.ToPort));
                lvi.SubItems.Add(protocol);
                lvi.SubItems.Add(p.FromPort + "->" + p.ToPort);
                lvi.SubItems.Add(String.Join(", ", p.IpRanges.ToArray()));

                lvi.ImageIndex = 4;
                lvi.Tag = p;

                OutSortableListView.Items.Add(lvi);

            }

        }

        private void RulesContextMenuStrip_Opening(object sender, CancelEventArgs e) {

            if (cloudAccount.ReadOnlyMode == true)
            {
                AddRuleToolStripMenuItem.Enabled = false;
                DeleteRuleToolStripMenuItem.Enabled = false;
            }
            else
            {

                if (GroupsSortableListView.SelectedItems.Count > 0)
                {

                    AddRuleToolStripMenuItem.Enabled = true;

                    if (tabControl1.SelectedIndex == 0)
                    {

                        if (InSortableListView.SelectedItems.Count > 0)
                        {

                            DeleteRuleToolStripMenuItem.Enabled = true;

                        }
                        else
                        {

                            DeleteRuleToolStripMenuItem.Enabled = false;

                        }

                    }
                    else if (tabControl1.SelectedIndex == 1)
                    {

                        if (OutSortableListView.SelectedItems.Count > 0)
                        {

                            DeleteRuleToolStripMenuItem.Enabled = true;

                        }
                        else
                        {

                            DeleteRuleToolStripMenuItem.Enabled = false;

                        }

                    }

                }
                else
                {

                    AddRuleToolStripMenuItem.Enabled = false;
                    DeleteRuleToolStripMenuItem.Enabled = false;

                }

            }

        }

        private void DeleteRuleToolStripMenuItem_Click(object sender, EventArgs e) {

            if (MessageBox.Show("Delete the selected rules?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {

                ListViewItem lvig = GroupsSortableListView.SelectedItems[0];
                SecurityGroup group = (SecurityGroup)lvig.Tag;

                if (tabControl1.SelectedIndex == 0) {

                    List<IpPermission> permissions = new List<IpPermission>();

                    foreach (ListViewItem selectedLvi in InSortableListView.SelectedItems) {

                        IpPermission p = (IpPermission)selectedLvi.Tag;
                        permissions.Add(p);

                    }

                    GenericActionResponse response = awsServices.DeleteRules(group.GroupId, permissions);

                    // Remove the selected items.
                    foreach (ListViewItem selectedLvi in InSortableListView.SelectedItems) {
                        InSortableListView.Items.Remove(selectedLvi);
                    }

                } else if (tabControl1.SelectedIndex == 1) {

                    List<IpPermission> permissions = new List<IpPermission>();

                    foreach (ListViewItem selectedLvi in OutSortableListView.SelectedItems) {

                        IpPermission p = (IpPermission)selectedLvi.Tag;
                        permissions.Add(p);

                    }

                    GenericActionResponse response = awsServices.DeleteRules(group.GroupId, permissions);

                    // Remove the selected items.
                    foreach (ListViewItem selectedLvi in OutSortableListView.SelectedItems) {
                        OutSortableListView.Items.Remove(selectedLvi);
                    }

                }

            }

        }

        private void AddRuleToolStripMenuItem_Click(object sender, EventArgs e) {

            bool reloadRules = false;

            ListViewItem lvig = GroupsSortableListView.SelectedItems[0];

            SecurityGroup group = (SecurityGroup)lvig.Tag;

            if (tabControl1.SelectedIndex == 0) {

                bool inbound = true;

                AddSecurityGroupRuleForm asgrf = new AddSecurityGroupRuleForm(awsServices, group, inbound);
                if (asgrf.ShowDialog() == DialogResult.OK) {

                    // Refresh the list of rules.

                    reloadRules = true;

                }

            } else if (tabControl1.SelectedIndex == 1) {

                bool inbound = false;

                AddSecurityGroupRuleForm asgrf = new AddSecurityGroupRuleForm(awsServices, group, inbound);
                if (asgrf.ShowDialog() == DialogResult.OK) {

                    reloadRules = true;

                }

            }

            if (reloadRules == true) {

                // Get the selected VPC.
                string vpcId = VPCsComboBox.SelectedItem.ToString().Split(':')[0].Trim();

                GetSecurityGroupsResponse response = awsServices.GetSecurityGroup(vpcId, group.GroupId);

                if (response.SecurityGroups.Count > 0) {

                    SecurityGroup updatedGroup = response.SecurityGroups[0];

                    LoadRulesForGroup(updatedGroup);

                    lvig.Tag = updatedGroup;

                }

            }

        }

        private void GroupsSortableListView_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void addGroupToolStripMenuItem_Click(object sender, EventArgs e) {

            // Get the selected VPC.
            string vpcId = VPCsComboBox.SelectedItem.ToString().Split(':')[0].Trim();

            AddSecurityGroupForm asgf = new AddSecurityGroupForm(awsServices, vpcs, vpcId);
            if (asgf.ShowDialog() == DialogResult.OK) {

                // Refresh the list of groups.
                LoadSecurityGroups(vpcId);

            }

        }

        private void GroupsContextMenuStrip_Opening(object sender, CancelEventArgs e) {

            if (cloudAccount.ReadOnlyMode == true)
            {
                addGroupToolStripMenuItem.Enabled = false;
                DeleteGroupToolStripMenuItem.Enabled = false;
            }
            else
            {

                if (GroupsSortableListView.SelectedItems.Count > 0)
                {
                    DeleteGroupToolStripMenuItem.Enabled = true;
                }
                else
                {
                    DeleteGroupToolStripMenuItem.Enabled = false;
                }

            }

        }

        private void DeleteGroupToolStripMenuItem_Click(object sender, EventArgs e) {

            IList<EventError> errors = new List<EventError>(); 

            if (MessageBox.Show("Delete the selected groups?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {

                foreach (ListViewItem lvi in GroupsSortableListView.SelectedItems) {

                    SecurityGroup sg = (SecurityGroup)lvi.Tag;

                    GenericActionResponse response = awsServices.DeleteSecurityGroup(sg.GroupId);

                    if (response.Success == false) {

                        errors.Add(response.EventError);

                    }

                }

                // Refresh the list of security groups.
                RefreshGroups();

            }

            // If the errors list is not empty show them in the form.
            if(errors.Count > 0)
            {
                ErrorListForm elf = new ErrorListForm(errors);
                elf.ShowDialog();
            }

        }

        private void RefreshGroupsToolStripMenuItem_Click(object sender, EventArgs e) {

            RefreshGroups();

        }

        private void RefreshGroups()
        {
            // Refresh the list of groups.

            // Get the selected VPC.
            string vpcId = VPCsComboBox.SelectedItem.ToString().Split(':')[0].Trim();

            LoadSecurityGroups(vpcId);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Get the selected VPC.
            string vpcId = VPCsComboBox.SelectedItem.ToString().Split(':')[0].Trim();

            LoadSecurityGroups(vpcId);

        }

    }

}