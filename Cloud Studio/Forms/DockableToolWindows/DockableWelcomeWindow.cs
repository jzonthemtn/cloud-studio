using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;
using Amazon.EC2.Model;
using CloudStudio.Services.Services;
using CloudStudio.SharedLibrary.Domain;
using CloudStudio.Services;
using CloudStudio.GUI.Classes;
using CloudStudio.Services.Model;
using CloudStudio.SharedLibrary;
using CloudStudio.GUI.Utils;

namespace CloudStudio.GUI
{
    public partial class DockableWelcomeWindow : DockContent
    {

        private MainMDIForm mdiForm;
        private CloudAccountService cloudAccountService;

        public DockableWelcomeWindow(MainMDIForm mdiForm, CloudAccountService cloudAccountService)
        {
            InitializeComponent();

            this.mdiForm = mdiForm;
            this.cloudAccountService = cloudAccountService;
        }      

        private void DummyDoc_Load(object sender, EventArgs e)
        {
            ShowWelcomeCheckBox.Checked = Properties.Settings.Default.ShowWelcome;

            if(Properties.Settings.Default.RecentCloudAccount1 != string.Empty)
            {
                string cloudAccountId = Properties.Settings.Default.RecentCloudAccount1;
                CloudAccount cloudAccount = cloudAccountService.GetCloudAccountById(cloudAccountId);
                RecentCloudAccount1HoverLinkLabel.Text = cloudAccount.Description;
                RecentCloudAccount1HoverLinkLabel.Visible = true;
                RecentCloudAccount1HoverLinkLabel.Tag = cloudAccountId;
            }

            if (Properties.Settings.Default.RecentCloudAccount2 != string.Empty)
            {
                string cloudAccountId = Properties.Settings.Default.RecentCloudAccount2;
                CloudAccount cloudAccount = cloudAccountService.GetCloudAccountById(cloudAccountId);
                RecentCloudAccount2HoverLinkLabel.Text = cloudAccount.Description;
                RecentCloudAccount2HoverLinkLabel.Visible = true;
                RecentCloudAccount2HoverLinkLabel.Tag = cloudAccountId;
            }

            if (Properties.Settings.Default.RecentCloudAccount3 != string.Empty)
            {
                string cloudAccountId = Properties.Settings.Default.RecentCloudAccount3;
                CloudAccount cloudAccount = cloudAccountService.GetCloudAccountById(cloudAccountId);
                RecentCloudAccount3HoverLinkLabel.Text = cloudAccount.Description;
                RecentCloudAccount3HoverLinkLabel.Visible = true;
                RecentCloudAccount3HoverLinkLabel.Tag = cloudAccountId;
            }

            if (Properties.Settings.Default.RecentCloudAccount4 != string.Empty)
            {
                string cloudAccountId = Properties.Settings.Default.RecentCloudAccount4;
                CloudAccount cloudAccount = cloudAccountService.GetCloudAccountById(cloudAccountId);
                RecentCloudAccount4HoverLinkLabel.Text = cloudAccount.Description;
                RecentCloudAccount4HoverLinkLabel.Visible = true;
                RecentCloudAccount4HoverLinkLabel.Tag = cloudAccountId;
            }

            if (Properties.Settings.Default.RecentCloudAccount5 != string.Empty)
            {
                string cloudAccountId = Properties.Settings.Default.RecentCloudAccount5;
                CloudAccount cloudAccount = cloudAccountService.GetCloudAccountById(cloudAccountId);
                RecentCloudAccount5HoverLinkLabel.Text = cloudAccount.Description;
                RecentCloudAccount5HoverLinkLabel.Visible = true;
                RecentCloudAccount5HoverLinkLabel.Tag = cloudAccountId;
            }

            if(RecentCloudAccount1HoverLinkLabel.Visible == false &&
                RecentCloudAccount1HoverLinkLabel.Visible == false &&
                RecentCloudAccount1HoverLinkLabel.Visible == false &&
                RecentCloudAccount1HoverLinkLabel.Visible == false &&
                RecentCloudAccount1HoverLinkLabel.Visible == false)
            {
                RecentLabel.Visible = false;
            }
            else
            {
                RecentLabel.Visible = true;
            }

        }

        private void ShowWelcomeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowWelcome = ShowWelcomeCheckBox.Checked;
        }

        private void openCloudAccountLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((LinkLabel)sender).Name);

            mdiForm.ShowCloudAccounts();
        }

        private void RecentCloudAccount1HoverLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenCloudAccount(RecentCloudAccount1HoverLinkLabel.Tag.ToString());
        }

        private void OpenCloudAccount(string cloudAccountId)
        {
            CloudAccount cloudAccount = cloudAccountService.GetCloudAccountById(cloudAccountId);
            if (cloudAccount != null)
            {
                this.mdiForm.OpenCloudAccount(cloudAccount);
            }
            else
            {
                MessageBox.Show("The cloud account could not be found.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RecentCloudAccount2HoverLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenCloudAccount(RecentCloudAccount2HoverLinkLabel.Tag.ToString());
        }

        private void RecentCloudAccount3HoverLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenCloudAccount(RecentCloudAccount3HoverLinkLabel.Tag.ToString());
        }

        private void RecentCloudAccount4HoverLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenCloudAccount(RecentCloudAccount4HoverLinkLabel.Tag.ToString());
        }

        private void RecentCloudAccount5HoverLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenCloudAccount(RecentCloudAccount5HoverLinkLabel.Tag.ToString());
        }

        private void betaFeedbackHoverLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((LinkLabel)sender).Name);
        }

    }

}