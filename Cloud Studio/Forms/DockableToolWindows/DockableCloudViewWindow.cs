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

namespace CloudStudio.GUI
{
    public partial class DockableCloudViewWindow : DockContent
    {

        private MainMDIForm mdiForm;
        private PropertyGrid propertyGrid;
        private Vpc vpc;

        public Vpc GetVpc()
        {
            return vpc;
        }

        public DockableCloudViewWindow(MainMDIForm mdiForm, PropertyGrid propertyGrid, CloudAccountService CloudAccountService, Vpc vpc)
        {
            InitializeComponent();
            
            this.vpc = vpc;
            this.propertyGrid = propertyGrid;
            this.mdiForm = mdiForm;

            cloudView1.InitializeServices(mdiForm, CloudAccountService, vpc, propertyGrid);
            cloudView1.RefreshResouces();

        }

        private void menuItem2_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("This is to demostrate menu item has been successfully merged into the main form. Form Text=" + Text);
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            // dockPanel.ActiveDocument.DockHandler.Close();
            this.Close();
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* foreach (IDockContent document in dockPanel.DocumentsToArray())
            {
                document.DockHandler.Close();
            }*/
        }

        private void closeAllButThisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*foreach (IDockContent document in dockPanel.DocumentsToArray())
            {
                if (!document.DockHandler.IsActivated)
                    document.DockHandler.Close();
            }*/
        }

        private void DummyDoc_Load(object sender, EventArgs e)
        {

        }

    }
}