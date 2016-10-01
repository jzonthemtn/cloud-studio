using Amazon.EC2.Model;
using CloudStudio.GUI.Classes;
using CloudStudio.GUI.Utils;
using CloudStudio.Services;
using CloudStudio.Services.Utilities;
using CloudStudio.SharedLibrary.Domain;
using CloudStudio.SharedLibrary.Services.AWSServices;
using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CloudStudio.Services.Services;
using CloudStudio.SharedLibrary;
using CloudStudio.SharedLibrary.Domain;
using CloudStudio.GUI.Classes;

namespace CloudStudio.GUI.Forms {

    public partial class VolumesForm : System.Windows.Forms.Form {

        private MainMDIForm mdiForm;
        private Instance instance;
        private Vpc vpc;
        private CloudAccount cloudAccount;

        public VolumesForm(MainMDIForm mdiForm, CloudAccount cloudAccount, Instance instance, Vpc vpc)
        {

            InitializeComponent();

            this.mdiForm = mdiForm;
            this.cloudAccount = cloudAccount;
            this.instance = instance;
            this.vpc = vpc;

        }

        private void AMIsListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            
        }

        private void SnapshotsListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {

        }

        private void VolumesListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            
        }

        private void VolumesForm_Load(object sender, EventArgs e)
        {

            // Track this event.
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_FORM_OPEN, this.GetType().Name);

            GetInstancesResponse getInstancesResponse = mdiForm.GetAWSServices().GetInstancesInVpc(vpc);

            InstancesComboBox.Items.Add("All Volumes");

            foreach (Instance i in getInstancesResponse.Instances) {

                InstancesComboBox.Items.Add(i.InstanceId + " : " + AwsUtils.GetNameFromTags(i.Tags));

            }

            if(instance == null) {

                if (getInstancesResponse.Instances.Count > 0) {

                    instance = getInstancesResponse.Instances[0];

                }

            }

            if (instance != null) {

                string instanceLabel = instance.InstanceId + " : " + AwsUtils.GetNameFromTags(instance.Tags);

                for (int x = 0; x < InstancesComboBox.Items.Count; x++) {

                    if (InstancesComboBox.Items[x].ToString() == instanceLabel) {

                        InstancesComboBox.SelectedIndex = x;
                        break;

                    }

                }

                LoadVolumes(instance.InstanceId);

            }

        }

        private void LoadVolumes(string instanceId) {

            VolumesListView.Items.Clear();

            GetVolumesResponse getVolumesResponse = null;

            if (instanceId == null) {

                getVolumesResponse = mdiForm.GetAWSServices().GetVolumes();

            } else {

                getVolumesResponse = mdiForm.GetAWSServices().GetVolumesForInstance(instanceId);

            }

            foreach (Volume volume in getVolumesResponse.Volumes) {

                ListViewItem lvi = new ListViewItem(volume.VolumeId);
                lvi.SubItems.Add(AwsUtils.GetNameFromTags(volume.Tags));
                lvi.SubItems.Add(volume.Size + " GB");
                lvi.SubItems.Add(volume.VolumeType.Value);
                lvi.SubItems.Add(volume.CreateTime.ToShortTimeString() + " " + volume.CreateTime.ToShortDateString());
                lvi.SubItems.Add(volume.AvailabilityZone);
                lvi.SubItems.Add(volume.State.Value);

                StringBuilder attachments = new StringBuilder();
                foreach (VolumeAttachment va in volume.Attachments) {
                    attachments.Append(va.InstanceId + "; ");
                }
                lvi.SubItems.Add(attachments.ToString());

                lvi.ImageIndex = 0;
                lvi.Tag = volume;

                VolumesListView.Items.Add(lvi);

            }
            
            // Clear the other listviews.
            SnapshotsListView.Items.Clear();
            AMIsListView.Items.Clear();

        }

        private void VolumesListView_ItemActivate(object sender, EventArgs e)
        {
            RefreshSnapshots();          
        }

        private void RefreshSnapshots()
        {
            this.Cursor = Cursors.WaitCursor;

            SnapshotsListView.Items.Clear();

            ListViewItem volumeListViewItem = VolumesListView.SelectedItems[0];
            Volume volume = (Volume)volumeListViewItem.Tag;

            GetSnapshotsResponse response = mdiForm.GetAWSServices().GetSnapshotsForVolume(volume);

            foreach (Snapshot snapshot in response.Snapshots)
            {

                ListViewItem lvi = new ListViewItem(snapshot.SnapshotId);
                lvi.SubItems.Add(AwsUtils.GetNameFromTags(snapshot.Tags));
                lvi.SubItems.Add(snapshot.VolumeSize + " GB");
                lvi.SubItems.Add(snapshot.Description);
                lvi.SubItems.Add(snapshot.Progress);
                lvi.SubItems.Add(snapshot.State.Value);
                lvi.SubItems.Add(snapshot.StartTime.ToShortDateString());
                lvi.SubItems.Add(snapshot.OwnerId);
                lvi.ImageIndex = 1;
                lvi.Tag = snapshot;

                SnapshotsListView.Items.Add(lvi);

            }

            this.Cursor = Cursors.Default;
        }

        private void VolumesListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SnapshotsListView_ItemActivate(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;

            AMIsListView.Items.Clear();

            ListViewItem snapshotListViewItem = SnapshotsListView.SelectedItems[0];
            Snapshot snapshot = (Snapshot)snapshotListViewItem.Tag;

            GetImagesResponse response = mdiForm.GetAWSServices().GetImagesForSnapshot(snapshot);

            foreach (Amazon.EC2.Model.Image image in response.Images)
            {

                ListViewItem lvi = new ListViewItem(image.ImageId);
                lvi.SubItems.Add(image.Name);
                lvi.SubItems.Add(image.Architecture);
                lvi.SubItems.Add(image.Description);
                lvi.SubItems.Add(image.Hypervisor);
                lvi.SubItems.Add(image.ImageLocation);
                lvi.SubItems.Add(image.Platform);
                lvi.SubItems.Add(image.Public.ToString());
                lvi.ImageIndex = 2;
                lvi.Tag = image;

                AMIsListView.Items.Add(lvi);

            }

            this.Cursor = Cursors.Default;

        }

        private void VolumesListView_MouseDown(object sender, MouseEventArgs e) {

        }

        private void CreateSnapshotToolStripMenuItem_Click(object sender, EventArgs e) {

            ListViewItem lvi = VolumesListView.SelectedItems[0];
            Volume volume = (Volume)lvi.Tag;

            CreateSnapshotForm csf = new CreateSnapshotForm(mdiForm.GetAWSServices(), volume);
            csf.ShowDialog();

        }

        private void VolumesContextMenuStrip_Opening(object sender, CancelEventArgs e) {

            if (cloudAccount.ReadOnlyMode == true)
            {
                CreateSnapshotToolStripMenuItem.Enabled = false;
            }
            else
            {
                if (VolumesListView.SelectedItems.Count > 0)
                {
                    CreateSnapshotToolStripMenuItem.Enabled = true;
                    ViewAttachmentsToolStripMenuItem.Enabled = true;
                    VolumeTagsToolStripMenuItem.Enabled = true;
                }
                else
                {
                    CreateSnapshotToolStripMenuItem.Enabled = false;
                    ViewAttachmentsToolStripMenuItem.Enabled = false;
                    VolumeTagsToolStripMenuItem.Enabled = false;
                }

            }

        }

        private void CreateSnapshotToolStripMenuItem_Click_1(object sender, EventArgs e) {

            ListViewItem lvi = VolumesListView.SelectedItems[0];
            Volume volume = (Volume)lvi.Tag;

            CreateSnapshotForm csf = new CreateSnapshotForm(mdiForm.GetAWSServices(), volume);
            csf.ShowDialog();

        }

        private void SnapshotsContextMenuStrip_Opening(object sender, CancelEventArgs e) {

            if (cloudAccount.ReadOnlyMode == true)
            {
                RegisterAsImageToolStripMenuItem.Enabled = false;
                CopySnapshotToolStripMenuItem.Enabled = false;
                DeleteSnapshotToolStripMenuItem.Enabled = false;
            }
            else
            {

                if (SnapshotsListView.SelectedItems.Count > 0)
                {
                    RegisterAsImageToolStripMenuItem.Enabled = true;
                    DeleteSnapshotToolStripMenuItem.Enabled = true;
                    SnapshotTagsToolStripMenuItem.Enabled = true;
                    CopySnapshotToolStripMenuItem.Enabled = true;
                }
                else
                {
                    RegisterAsImageToolStripMenuItem.Enabled = false;
                    DeleteSnapshotToolStripMenuItem.Enabled = false;
                    SnapshotTagsToolStripMenuItem.Enabled = false;
                    CopySnapshotToolStripMenuItem.Enabled = false;
                }

            }

        }

        private void DeleteSnapshotToolStripMenuItem_Click(object sender, EventArgs e) {

            if (SnapshotsListView.SelectedItems.Count > 0) {

                IList<EventError> eventErrors = new List<EventError>();

                if (MessageBox.Show("Delete the selected snapshot(s)?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {

                    foreach (ListViewItem lvi in SnapshotsListView.SelectedItems) {

                        Snapshot snapshot = (Snapshot)lvi.Tag;

                        CloudStudio.SharedLibrary.Services.AWSServices.DeleteSnapshotResponse response = mdiForm.GetAWSServices().DeleteSnapshot(snapshot);

                        if (response.Success == true) {

                            // Remove it from the list.
                            SnapshotsListView.Items.Remove(lvi);

                        } else {

                            // Add it to a list of errors to display to the user.
                            EventError eventError = new EventError("Unable to delete snapshot " + snapshot.SnapshotId + ".", "Unable to delete snapshot " + snapshot.SnapshotId + ".");
                            eventErrors.Add(eventError);

                        }

                    }                        

                }

                if (eventErrors.Count > 0) {

                    ErrorListForm elf = new ErrorListForm(eventErrors);
                    elf.ShowDialog();

                }
                

            }

        }

        private void ViewAttachmentsToolStripMenuItem_Click(object sender, EventArgs e) {

            if (VolumesListView.SelectedItems.Count > 0) {

                ListViewItem lvi = VolumesListView.SelectedItems[0];
                Volume volume = (Volume) lvi.Tag;

                VolumeAttachmentsForm vaf = new VolumeAttachmentsForm(cloudAccount, mdiForm.GetAWSServices(), volume, volume.Attachments);
                vaf.Text = "Volume Attachments - " + volume.VolumeId;
                vaf.ShowDialog();

            }

        }

        private void SnapshotTagsToolStripMenuItem_Click(object sender, EventArgs e) {

            if (SnapshotsListView.SelectedItems.Count > 0) {

                ListViewItem lvi = SnapshotsListView.SelectedItems[0];
                Snapshot snapshot = (Snapshot)lvi.Tag;

                TagEditorForm tef = new TagEditorForm(cloudAccount, mdiForm.GetAWSServices(), snapshot.SnapshotId, snapshot.Tags);
                tef.ShowDialog();

            }
            
        }

        private void VolumeTagsToolStripMenuItem_Click(object sender, EventArgs e) {

            if (VolumesListView.SelectedItems.Count > 0) {

                ListViewItem lvi = VolumesListView.SelectedItems[0];
                Volume volume = (Volume)lvi.Tag;

                TagEditorForm tef = new TagEditorForm(cloudAccount, mdiForm.GetAWSServices(), volume.VolumeId, volume.Tags);
                tef.ShowDialog();

            }

        }

        private void InstancesComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            RefreshVolumes();
        }

        private void RefreshVolumes()
        {
            if (InstancesComboBox.SelectedItem.ToString() == "All Volumes")
            {

                LoadVolumes(null);

            }
            else
            {

                // Get the instance ID.
                string instanceId = InstancesComboBox.SelectedItem.ToString().Split(':')[0].Trim();

                LoadVolumes(instanceId);

            }
        }

        private void RegisterAsImageToolStripMenuItem_Click(object sender, EventArgs e) {

            if (SnapshotsListView.SelectedItems.Count > 0) {

                ListViewItem lvi = SnapshotsListView.SelectedItems[0];
                Snapshot snapshot = (Snapshot)lvi.Tag;               

                RegisterImageForm rif = new RegisterImageForm(mdiForm.GetAWSServices(), snapshot);
                if (rif.ShowDialog() == DialogResult.OK) {

                    // TODO: Refresh the list of images.

                }

            }

        }

        private void ImagesContextMenuStrip_Opening(object sender, CancelEventArgs e) {

            if (AMIsListView.SelectedItems.Count > 0) {

                // Readonly mode?
                DeregisterImageToolStripMenuItem.Enabled = !cloudAccount.ReadOnlyMode;
                LaunchInstanceToolStripMenuItem.Enabled = !cloudAccount.ReadOnlyMode;

            } else {

                DeregisterImageToolStripMenuItem.Enabled = false;
                LaunchInstanceToolStripMenuItem.Enabled = false;

            }

        }

        private void CopySnapshotToolStripMenuItem_Click(object sender, EventArgs e) {

            ListViewItem lvi = SnapshotsListView.SelectedItems[0];
            Snapshot snapshot = (Snapshot)lvi.Tag;

            CopySnapshotForm csf = new CopySnapshotForm(this.mdiForm, snapshot);
            csf.ShowDialog();

        }

        private void LaunchInstanceToolStripMenuItem_Click(object sender, EventArgs e) {

            LaunchInstanceForm lif = new LaunchInstanceForm(cloudAccount, mdiForm.GetAWSServices());
            lif.ShowDialog();

        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshSnapshots();
        }

        private void RefreshVolumesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshVolumes();
        }

    }

}
