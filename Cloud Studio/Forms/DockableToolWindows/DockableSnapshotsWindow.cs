using Amazon.EC2.Model;
using CloudStudio.GUI.Forms;
using CloudStudio.GUI.Utils;
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
    public partial class DockableSnapshotsWindow : BaseDockableToolWindow
    {

        private MainMDIForm mdiForm;
        private PropertyGrid propertyGrid;

        public DockableSnapshotsWindow(MainMDIForm mdiForm, PropertyGrid propertyGrid)
        {
            InitializeComponent();

            this.mdiForm = mdiForm;
            this.propertyGrid = propertyGrid;

        }

        private void ShowSnapshots(string search)
        {

            SnapshotsListView.Items.Clear();

            foreach (Snapshot snapshot in snapshots)
            {

                if (snapshot.Description.Contains(search)
                    || snapshot.SnapshotId.Contains(search)
                    || AwsUtils.SearchInTags(snapshot.Tags, search))
                {

                    ListViewItem lvi = new ListViewItem(snapshot.SnapshotId);
                    lvi.SubItems.Add(AwsUtils.GetNameFromTags(snapshot.Tags));
                    lvi.SubItems.Add(snapshot.VolumeSize + " GB");
                    lvi.SubItems.Add(snapshot.Description);
                    lvi.SubItems.Add(snapshot.Progress);
                    lvi.SubItems.Add(snapshot.State.Value);
                    lvi.SubItems.Add(snapshot.StartTime.ToShortDateString());
                    lvi.SubItems.Add(snapshot.OwnerId);
                    lvi.ImageIndex = 0;
                    lvi.Tag = snapshot;

                    SnapshotsListView.Items.Add(lvi);

                }

            }

        }

        private void DockableSnapshotsWindow_Load(object sender, EventArgs e)
        {
            RefreshMySnapshots();
        }

        private void RefreshMySnapshots()
        {
            if (mdiForm.GetAWSServices() != null)
            {

                SnapshotsListView.Items.Clear();

                GetSnapshotsResponse response = mdiForm.GetAWSServices().GetSnapshots(true);

                snapshots = response.Snapshots;

                SnapshotSearchTextBox.Clear();

                ShowSnapshots();

            }
        }

        private void ShowSnapshots()
        {

            SnapshotsListView.Items.Clear();

            foreach (Snapshot snapshot in snapshots)
            {

                ListViewItem lvi = new ListViewItem(snapshot.SnapshotId);
                lvi.SubItems.Add(AwsUtils.GetNameFromTags(snapshot.Tags));
                lvi.SubItems.Add(snapshot.VolumeSize + " GB");
                lvi.SubItems.Add(snapshot.Description);
                lvi.SubItems.Add(snapshot.Progress);
                lvi.SubItems.Add(snapshot.State.Value);
                lvi.SubItems.Add(snapshot.StartTime.ToShortDateString());
                lvi.SubItems.Add(snapshot.OwnerId);
                lvi.ImageIndex = 0;
                lvi.Tag = snapshot;

                SnapshotsListView.Items.Add(lvi);

            }

        }

        private void SnapshotsContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {            

            if (SnapshotsListView.SelectedItems.Count > 0 && mdiForm.GetAWSServices() != null)
            {

                RegisterAsImageToolStripMenuItem.Enabled = true;
                DeleteSnapshotToolStripMenuItem.Enabled = true;
                SnapshotTagsToolStripMenuItem.Enabled = true;
                CopySnapshotToolStripMenuItem.Enabled = true;

                if (mdiForm.GetCloudAccount() != null)
                {
                    RegisterAsImageToolStripMenuItem.Enabled = !mdiForm.GetCloudAccount().ReadOnlyMode;
                    CopySnapshotToolStripMenuItem.Enabled = !mdiForm.GetCloudAccount().ReadOnlyMode;
                    DeleteSnapshotToolStripMenuItem.Enabled = !mdiForm.GetCloudAccount().ReadOnlyMode;
                    RefreshSnapshotsToolStripMenuItem.Enabled = true;
                }
                else
                {
                    RefreshSnapshotsToolStripMenuItem.Enabled = false;
                }
                
            }
            else
            {

                RegisterAsImageToolStripMenuItem.Enabled = false;
                DeleteSnapshotToolStripMenuItem.Enabled = false;
                SnapshotTagsToolStripMenuItem.Enabled = false;
                CopySnapshotToolStripMenuItem.Enabled = false;

                if (mdiForm.GetCloudAccount() != null)
                {                    
                    RefreshSnapshotsToolStripMenuItem.Enabled = true;
                }
                else
                {
                    RefreshSnapshotsToolStripMenuItem.Enabled = false;
                }

            }       
            
        }

        private void RegisterAsImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SnapshotsListView.SelectedItems.Count > 0)
            {

                ListViewItem lvi = SnapshotsListView.SelectedItems[0];
                Snapshot snapshot = (Snapshot)lvi.Tag;

                RegisterImageForm rif = new RegisterImageForm(mdiForm.GetAWSServices(), snapshot);
                if (rif.ShowDialog() == DialogResult.OK)
                {

                    // TODO: Refresh the list of images.

                }

            }
        }

        private void CopySnapshotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = SnapshotsListView.SelectedItems[0];
            Snapshot snapshot = (Snapshot)lvi.Tag;

            CopySnapshotForm csf = new CopySnapshotForm(this.mdiForm, snapshot);
            csf.ShowDialog();
        }

        private void DeleteSnapshotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SnapshotsListView.SelectedItems.Count > 0)
            {

                IList<EventError> eventErrors = new List<EventError>();

                if (MessageBox.Show("Delete the selected snapshot(s)?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {

                    foreach (ListViewItem lvi in SnapshotsListView.SelectedItems)
                    {

                        Snapshot snapshot = (Snapshot)lvi.Tag;

                        CloudStudio.SharedLibrary.Services.AWSServices.DeleteSnapshotResponse response = mdiForm.GetAWSServices().DeleteSnapshot(snapshot);

                        if (response.Success == true)
                        {

                            // Remove it from the list.
                            SnapshotsListView.Items.Remove(lvi);

                        }
                        else
                        {

                            // Add it to a list of errors to display to the user.
                            EventError eventError = new EventError("Unable to delete snapshot " + snapshot.SnapshotId + ".", "Unable to delete snapshot " + snapshot.SnapshotId + ".");
                            eventErrors.Add(eventError);

                        }

                    }

                }

                if (eventErrors.Count > 0)
                {

                    ErrorListForm elf = new ErrorListForm(eventErrors);
                    elf.ShowDialog();

                }

            }
        }

        private void SnapshotTagsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SnapshotsListView.SelectedItems.Count > 0)
            {

                ListViewItem lvi = SnapshotsListView.SelectedItems[0];
                Snapshot snapshot = (Snapshot)lvi.Tag;

                TagEditorForm tef = new TagEditorForm(mdiForm.GetCloudAccount(), mdiForm.GetAWSServices(), snapshot.SnapshotId, snapshot.Tags);
                tef.ShowDialog();

            }
        }

        private void RefreshSnapshotsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshMySnapshots();
        }

        private void DockableSnapshotsWindow_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void SnapshotsListView_ItemActivate(object sender, EventArgs e)
        {
            
        }

        private void SnapshotsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void SnapshotsListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (SnapshotsListView.SelectedItems.Count > 0)
            {
                propertyGrid.SelectedObject = SnapshotsListView.SelectedItems[0].Tag;
            }
        }

        private void SnapshotSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            ShowSnapshots(SnapshotSearchTextBox.Text);
        }

    }

}