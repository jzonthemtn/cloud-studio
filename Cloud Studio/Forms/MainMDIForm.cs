using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using WeifenLuo.WinFormsUI.Docking;
using CloudStudio.GUI.Forms;
using log4net;
using CloudStudio.Services;
using CloudStudio.Services.Services;
using CloudStudio.SharedLibrary.Domain;
using Amazon.EC2.Model;
using System.Collections.Generic;
using CloudStudio.SharedLibrary.Services.AWSServices;
using CloudStudio.Services.Utilities;
using CloudStudio.GUI.Controls;
using System.Threading;
using CloudStudio.GUI.Utils;
using CloudStudio.Services.Model;
using CloudStudio.GUI.Classes;
using CloudStudio.SharedLibrary;
using CloudStudio.GUI.Themes;

namespace CloudStudio.GUI
{
    public partial class MainMDIForm : Form
    {

        private static readonly ILog Logger = LogManager.GetLogger(typeof(MainMDIForm));

        private CloudAccountService cloudAccountService;
        private ICloudService awsServices;

        // The open cloud account.
        private CloudAccount cloudAccount;

        private bool m_bSaveLayout = true;
        private DeserializeDockContent m_deserializeDockContent;

        private DockablePropertiesWindow m_DockablePropertiesWindow;
        private DockableToolboxWindow m_toolbox;
        private DockableOutputWindow m_DockableOutputWindow;
        private DockableSnapshotsWindow m_snapshotsWindow;
        private DockablePowerShellWindow m_powerShellWindow;
        private DockableLegendWindow m_DockableLegendWindow;
        private DockableConsoleWindow m_DockableConsoleWindow;
        private DockableWelcomeWindow m_DockableWelcomeWindow;
        private DockableKeypairsWindow m_DockableKeypairsWindow;

        private readonly ToolStripRenderer _system = new ToolStripProfessionalRenderer();
        private readonly ToolStripRenderer _custom = new VS2012ToolStripRenderer();

        private AutoHideStripSkin _autoHideStripSkin;
        private DockPaneStripSkin _dockPaneStripSkin;

        public MainMDIForm()
        {
            InitializeComponent();

            CreateStandardControls();

            this.cloudAccountService = new CloudAccountService();

            m_deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);
            
            vS2012ToolStripExtender1.DefaultRenderer = _system;
            vS2012ToolStripExtender1.VS2012Renderer = _custom;
        }

        private IDockContent GetContentFromPersistString(string persistString)
        {

            // TODO: All windows here?
            if (persistString == typeof(DockablePropertiesWindow).ToString())
            {
                return m_DockablePropertiesWindow;
            }
            else if (persistString == typeof(DockableToolboxWindow).ToString())
            {
                return m_toolbox;
            }
            else if (persistString == typeof(DockableOutputWindow).ToString())
            {
                return m_DockableOutputWindow;
            }
            else
            {
                // DummyDoc overrides GetPersistString to add extra information into persistString.
                // Any DockContent may override this value to add any needed information for deserialization.

                string[] parsedStrings = persistString.Split(new char[] { ',' });
                if (parsedStrings.Length != 3)
                    return null;

                if (parsedStrings[0] != typeof(DockableCloudViewWindow).ToString())
                    return null;

                /*DummyDoc dummyDoc = new DummyDoc();
                if (parsedStrings[1] != string.Empty)
                    dummyDoc.FileName = parsedStrings[1];
                if (parsedStrings[2] != string.Empty)
                    dummyDoc.Text = parsedStrings[2];

                return dummyDoc;*/
                // TODO: Return something.
                return null;
            }
        }      

        public void LogOutputMessage(string message)
        {
            // The window will be null when it is closed.
            if(m_DockableOutputWindow != null)
            {
                m_DockableOutputWindow.LogOutputMessage(message);
            }
        }

        private void menuItemExit_Click(object sender, System.EventArgs e)
        {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);
            
            Close();
        }

        private void menuItemPropertyWindow_Click(object sender, System.EventArgs e)
        {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);
            
            if (m_DockablePropertiesWindow.IsDisposed || m_DockablePropertiesWindow != null)
            {
                m_DockablePropertiesWindow = new DockablePropertiesWindow(this);
            }

            m_DockablePropertiesWindow.Show(dockPanel);
        }

        private void menuItemToolbox_Click(object sender, System.EventArgs e)
        {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);
            
            if (m_toolbox.IsDisposed || m_toolbox == null)
            {
                m_toolbox = new DockableToolboxWindow(this);
            }
            m_toolbox.Show(dockPanel);
        }

        private void menuItemOutputWindow_Click(object sender, System.EventArgs e)
        {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);
            
            if (m_DockableOutputWindow.IsDisposed || m_DockableOutputWindow == null)
            {
                m_DockableOutputWindow = new DockableOutputWindow(this);
            }
            m_DockableOutputWindow.Show(dockPanel);
        }

        private void menuItemAbout_Click(object sender, System.EventArgs e)
        {
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);
            
            AboutForm ab = new AboutForm();
            ab.ShowDialog();
        }

        private string GetDockConfigFile()
        {
            return Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), "DockPanel.config");
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {

            this.Text = Application.ProductName;

            string configFile = GetDockConfigFile();
            
            if (File.Exists(configFile))
            {
                dockPanel.LoadFromXml(configFile, m_deserializeDockContent);
            }

            if (Properties.Settings.Default.ShowWelcome == true)
            {
                m_DockableWelcomeWindow.Show(dockPanel);
            }

        }

        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string configFile = GetDockConfigFile();

            if (m_bSaveLayout)
            {
                dockPanel.SaveAsXml(configFile);
            }
            else if (File.Exists(configFile))
            {
                File.Delete(configFile);
            }

        }

        public CloudAccount GetCloudAccount()
        {
            return cloudAccount;
        }

        public ICloudService GetAWSServices()
        {
            return awsServices;
        }

        private void CreateStandardControls()
        {
            m_DockablePropertiesWindow = new DockablePropertiesWindow(this);
            m_toolbox = new DockableToolboxWindow(this);
            m_DockableOutputWindow = new DockableOutputWindow(this);            
            m_powerShellWindow = new DockablePowerShellWindow(this);
            m_DockableLegendWindow = new DockableLegendWindow();
            m_DockableConsoleWindow = new DockableConsoleWindow(this);
            m_DockableWelcomeWindow = new DockableWelcomeWindow(this, cloudAccountService);
            m_snapshotsWindow = new DockableSnapshotsWindow(this, m_DockablePropertiesWindow.GetPropertyGrid());
            m_DockableKeypairsWindow = new DockableKeypairsWindow(this, m_DockablePropertiesWindow.GetPropertyGrid());
        }

        private void menuItemSnapshots_Click(object sender, EventArgs e)
        {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);
            
            if (m_snapshotsWindow.IsDisposed || m_snapshotsWindow == null)
            {
                if(m_DockablePropertiesWindow.IsDisposed || m_DockablePropertiesWindow == null)
                {
                    // The snapshots depends on the properties so make sure there is one.
                    m_DockablePropertiesWindow = new DockablePropertiesWindow(this);
                }
                m_snapshotsWindow = new DockableSnapshotsWindow(this, m_DockablePropertiesWindow.GetPropertyGrid());
            }
            m_snapshotsWindow.Show(dockPanel);
        }

        private void menuItemCloudAccounts_Click(object sender, EventArgs e)
        {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);
            
            ShowCloudAccounts();
        }

        public void ShowCloudAccounts()
        {

            CloudAccountsForm caf = new CloudAccountsForm();
            if (caf.ShowDialog() == DialogResult.OK)
            {

                // Update the list of recent cloud accounts if this account is not the most recent.
                if (Properties.Settings.Default.RecentCloudAccount1 != caf.SelectedCloudAccount.Id.ToString())
                {                    
                    // Knock each down a number and set 1 to the newest.
                    Properties.Settings.Default.RecentCloudAccount5 = Properties.Settings.Default.RecentCloudAccount4;
                    Properties.Settings.Default.RecentCloudAccount4 = Properties.Settings.Default.RecentCloudAccount3;
                    Properties.Settings.Default.RecentCloudAccount3 = Properties.Settings.Default.RecentCloudAccount2;
                    Properties.Settings.Default.RecentCloudAccount2 = Properties.Settings.Default.RecentCloudAccount1;
                    Properties.Settings.Default.RecentCloudAccount1 = caf.SelectedCloudAccount.Id.ToString();
                }

                OpenCloudAccount(caf.SelectedCloudAccount);

            }

        }

        public void OpenCloudAccount(CloudAccount cloudAccount)
        {
            bool haveSecretKey = false;

            if (cloudAccount.SecretKey == "none")
            {
                // Prompt for the secret key.
                SecretKeyForm skf = new SecretKeyForm();
                if (skf.ShowDialog() == DialogResult.OK)
                {
                    cloudAccount.SecretKey = skf.SecretKey;
                    haveSecretKey = true;
                }
            }
            else
            {
                haveSecretKey = true;
            }

            if (haveSecretKey == true)
            {

                // Close all open cloud view documents.
                foreach (IDockContent document in dockPanel.DocumentsToArray())
                {
                    if (document is DockableCloudViewWindow)
                    {
                        document.DockHandler.Close();
                    }
                }

                this.cloudAccount = cloudAccount;
                this.awsServices = new AwsServiceProxy(this, cloudAccount, BuildCloudServiceConfig());
                this.Text = Application.ProductName + " - " + cloudAccount.Description;

                loadVpcs();

            }
        }

        public static CloudServiceConfig BuildCloudServiceConfig()
        {

            CloudServiceConfig cloudServiceConfig = new CloudServiceConfig();
            cloudServiceConfig.Timeout = Properties.Settings.Default.Timeout;
            cloudServiceConfig.UseProxy = Properties.Settings.Default.UseProxy;
            cloudServiceConfig.ProxyHost = Properties.Settings.Default.ProxyHost;
            cloudServiceConfig.ProxyPort = Properties.Settings.Default.ProxyPort;
            cloudServiceConfig.ProxyUserName = Properties.Settings.Default.ProxyUserName;
            cloudServiceConfig.ProxyPassword = Properties.Settings.Default.ProxyPassword;

            return cloudServiceConfig;

        }

        public void loadVpcs()
        {

            this.Cursor = Cursors.WaitCursor;

            GetVpcsResponse getVpcsResponse = this.awsServices.GetVpcs();

            // VPCs that are already open.
            IList<Vpc> openVPCs = new List<Vpc>();

            // Get the VPCs that are already open.
            foreach (IDockContent dockWindow in dockPanel.DocumentsToArray())
            {
                if (dockWindow is DockableCloudViewWindow)
                {
                    DockableCloudViewWindow cloudViewWindow = (DockableCloudViewWindow)dockWindow;
                    openVPCs.Add(cloudViewWindow.GetVpc());
                }
            }

            this.Cursor = Cursors.Default;

            if (getVpcsResponse.Success == true)
            {

                SelectVPCsForm spf = new SelectVPCsForm(getVpcsResponse.Vpcs, openVPCs);
                if (spf.ShowDialog() == DialogResult.OK)
                {

                    IList<Vpc> selectedVPcs = spf.SelectedVpcs;

                    foreach (Vpc vpc in selectedVPcs)
                    {

                        this.LogOutputMessage("Opening VPC: " + vpc.VpcId);

                        TabPage tab = new TabPage();
                        tab.Text = vpc.VpcId + " (" + AwsUtils.GetNameFromTags(vpc.Tags) + ")";
                        tab.ImageIndex = 2;
                        tab.Tag = vpc;

                        // Make sure the properties window has not been disposed.
                        if (m_DockablePropertiesWindow.IsDisposed || m_DockablePropertiesWindow == null)
                        {
                            m_DockablePropertiesWindow = new DockablePropertiesWindow(this);
                        }

                        CloudView cloudView = new CloudView();
                        cloudView.Dock = DockStyle.Fill;
                        cloudView.InitializeServices(this, cloudAccountService, vpc, m_DockablePropertiesWindow.GetPropertyGrid());
                        cloudView.RefreshResouces();

                        tab.Controls.Add(cloudView);

                        DockableCloudViewWindow dummyDoc = new DockableCloudViewWindow(this, m_DockablePropertiesWindow.GetPropertyGrid(), cloudAccountService, vpc);
                        dummyDoc.Text = vpc.VpcId;

                        if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
                        {
                            dummyDoc.MdiParent = this;
                            dummyDoc.Show();
                        }
                        else
                        {
                            dummyDoc.Show(dockPanel);
                        }

                    }

                }

            }
            else
            {

                MessageBox.Show("Unable to get VPCs. Check your cloud account credentials and network access. Cloud Studio requires full EC2 permissions, or full read-only EC2 permissions if operating in read-only mode.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void dockPanel_ActiveContentChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);

            SettingsForm sf = new SettingsForm();
            sf.ShowDialog();
        }

        private void menuItemPowerShellConsole_Click(object sender, EventArgs e)
        {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);
            
            if (m_powerShellWindow.IsDisposed || m_powerShellWindow == null)
            {
                m_powerShellWindow = new DockablePowerShellWindow(this);
            }
            m_powerShellWindow.Show(dockPanel);
        }

        private void newVersionAvailableToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);

            System.Diagnostics.Process.Start(Constants.DOWNLOAD_UPDATE_URL + "?version=" + Application.ProductVersion);
        }

        private void legendToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);
            
            if (m_DockableLegendWindow.IsDisposed || m_DockableLegendWindow == null)
            {
                m_DockableLegendWindow = new DockableLegendWindow();
            }
            m_DockableLegendWindow.Show(dockPanel);
        }

        private void consoleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);

            if (m_DockableConsoleWindow.IsDisposed || m_DockableConsoleWindow == null)
            {
                m_DockableConsoleWindow = new DockableConsoleWindow(this);
            }
            m_DockableConsoleWindow.Show(dockPanel);
        }

        private void welcomeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);
            
            if (m_DockableWelcomeWindow.IsDisposed || m_DockableWelcomeWindow == null)
            {
                m_DockableWelcomeWindow = new DockableWelcomeWindow(this, cloudAccountService);
            }
            m_DockableWelcomeWindow.Show(dockPanel);
        }

        private void VPCsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);
            
            loadVpcs();
        }

        private void menuItemFile_DropDownOpening(object sender, EventArgs e)
        {
            if(this.cloudAccount == null)
            {
                VPCsToolStripMenuItem.Enabled = false;
            }
            else
            {
                VPCsToolStripMenuItem.Enabled = true;
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);

            System.Diagnostics.Process.Start(Constants.HELP_URL);

        }

        private void keypairsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);

            if (m_DockableKeypairsWindow.IsDisposed || m_DockableKeypairsWindow == null)
            {
                if (m_DockableKeypairsWindow.IsDisposed || m_DockablePropertiesWindow == null)
                {
                    // The snapshots depends on the properties so make sure there is one.
                    m_DockablePropertiesWindow = new DockablePropertiesWindow(this);
                }
                m_DockableKeypairsWindow = new DockableKeypairsWindow(this, m_DockablePropertiesWindow.GetPropertyGrid());
            }
            m_DockableKeypairsWindow.Show(dockPanel);

        }

        private void GetSupportToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

    }

}