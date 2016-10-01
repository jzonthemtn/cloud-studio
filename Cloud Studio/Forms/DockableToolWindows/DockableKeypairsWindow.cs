using Amazon.EC2.Model;
using CloudStudio.GUI.Forms;
using CloudStudio.Services.Services;
using CloudStudio.Services.Utilities;
using CloudStudio.SharedLibrary;
using CloudStudio.SharedLibrary.Domain;
using CloudStudio.SharedLibrary.Services.AWSServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace CloudStudio.GUI
{
    public partial class DockableKeypairsWindow : BaseDockableToolWindow
    {

        private MainMDIForm mdiForm;
        private PropertyGrid propertyGrid;

        public DockableKeypairsWindow(MainMDIForm mdiForm, PropertyGrid propertyGrid)
        {
            InitializeComponent();

            this.mdiForm = mdiForm;
            this.propertyGrid = propertyGrid;

        }

        private void DockableKeypairsWindow_Load(object sender, EventArgs e)
        {
            RefreshKeypairs();
        }

        private void ShowKeypairs(string search)
        {
            KeypairsSortableListView.Items.Clear();

            if (mdiForm.GetAWSServices() != null)
            {

                this.Cursor = Cursors.WaitCursor;

                GetKeyNamesResponse keyNamesResponse = mdiForm.GetAWSServices().GetKeyNames();

                foreach (KeyPairInfo kpi in keyNamesResponse.KeyPairs)
                {
                    if (kpi.KeyName.Contains(search))
                    {

                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = kpi.KeyName;
                        lvi.SubItems.Add(kpi.KeyFingerprint);
                        lvi.ImageIndex = 0;
                        lvi.Tag = kpi;

                        KeypairsSortableListView.Items.Add(lvi);

                    }

                }

                this.Cursor = Cursors.Default;
            }
        }

        private void RefreshKeypairs()
        {
            KeypairsSortableListView.Items.Clear();

            if (mdiForm.GetAWSServices() != null)
            {

                this.Cursor = Cursors.WaitCursor;

                GetKeyNamesResponse keyNamesResponse = mdiForm.GetAWSServices().GetKeyNames();

                foreach (KeyPairInfo kpi in keyNamesResponse.KeyPairs)
                {

                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = kpi.KeyName;
                    lvi.SubItems.Add(kpi.KeyFingerprint);
                    lvi.ImageIndex = 0;
                    lvi.Tag = kpi;

                    KeypairsSortableListView.Items.Add(lvi);

                }

                this.Cursor = Cursors.Default;
            }
        }

        private void newKeypairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mdiForm.GetAWSServices() != null)
            {
                KeypairsForm nkf = new KeypairsForm(mdiForm.GetCloudAccount(), mdiForm.GetAWSServices());
                if (nkf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Reload the keypairs.
                    RefreshKeypairs();
                }
            }
            else
            {
                mdiForm.ShowCloudAccounts();
            }
        }

        private void deleteKeypairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (KeypairsSortableListView.SelectedItems.Count > 0)
            {

                foreach (ListViewItem lvi in KeypairsSortableListView.SelectedItems)
                {
                    KeyPairInfo kpi = (KeyPairInfo)lvi.Tag;
                    mdiForm.GetAWSServices().DeleteKeypair(kpi.KeyName);
                }

                RefreshKeypairs();

            }

        }

        private void KeypairsSortableListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (KeypairsSortableListView.SelectedItems.Count > 0)
            {
                deleteKeypairToolStripMenuItem.Enabled = true;
            }
            else
            {
                deleteKeypairToolStripMenuItem.Enabled = false;
            }
        }

        private void KeypairsSortableListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (KeypairsSortableListView.SelectedItems.Count > 0)
            {
                propertyGrid.SelectedObject = KeypairsSortableListView.SelectedItems[0].Tag;
            }
        }

        private void refreshKeypairsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshKeypairs();
        }

        private void KeypairsSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            ShowKeypairs(KeypairsSearchTextBox.Text);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if(mdiForm.GetAWSServices() != null)
            {
                newKeypairToolStripMenuItem.Enabled = true;
                refreshKeypairsToolStripMenuItem.Enabled = true;
            }
            else
            {
                newKeypairToolStripMenuItem.Enabled = false;
                refreshKeypairsToolStripMenuItem.Enabled = false;
            }

            if (KeypairsSortableListView.SelectedItems.Count > 0 && mdiForm.GetAWSServices() != null)
            {
                deleteKeypairToolStripMenuItem.Enabled = true;
            }
            else
            {
                deleteKeypairToolStripMenuItem.Enabled = false;
            }
        }

    }
}