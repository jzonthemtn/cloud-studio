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
using CloudStudio.GUI.Classes;
using CloudStudio.SharedLibrary.Domain;
using CloudStudio.SharedLibrary;
using CloudStudio.GUI.Utils;

namespace CloudStudio.GUI.Forms {

    public partial class VolumeAttachmentsForm : System.Windows.Forms.Form {

        private IList<VolumeAttachment> volumeAttachments;
        private Volume volume;
        private ICloudService awsServices;
        private CloudAccount cloudAccount;

        public VolumeAttachmentsForm(CloudAccount cloudAccount, ICloudService awsServices, Volume volume, IList<VolumeAttachment> volumeAttachments)
        {

            InitializeComponent();

            this.cloudAccount = cloudAccount;
            this.volumeAttachments = volumeAttachments;
            this.volume = volume;
            this.awsServices = awsServices;

        }

        private void VolumeAttachments_Load(object sender, EventArgs e) {

            // Track this event.
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_FORM_OPEN, this.GetType().Name);

            AttachmentsSortableListView.Items.Clear();

            this.Cursor = Cursors.WaitCursor;

            foreach (VolumeAttachment va in volumeAttachments) {

                ListViewItem lvi = new ListViewItem();
                lvi.Text = va.InstanceId;
                lvi.SubItems.Add(va.AttachTime.ToShortTimeString() + " " + va.AttachTime.ToShortDateString());
                lvi.SubItems.Add(va.DeleteOnTermination.ToString());
                lvi.SubItems.Add(va.Device);
                lvi.SubItems.Add(va.State.Value);
                lvi.ImageIndex = 0;
                lvi.Tag = va;

                AttachmentsSortableListView.Items.Add(lvi);
                    
            }

            this.Cursor = Cursors.Default;

        }

        private void DetachVolumeToolStripMenuItem_Click(object sender, EventArgs e) {

            if (AttachmentsSortableListView.SelectedItems.Count > 0) {

                if (MessageBox.Show("Detach the selected volume?", Application.ProductName, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {

                    ListViewItem lvi = AttachmentsSortableListView.SelectedItems[0];
                    VolumeAttachment attachment = (VolumeAttachment)lvi.Tag;

                    this.Cursor = Cursors.WaitCursor;

                    CloudStudio.SharedLibrary.Services.AWSServices.DetachVolumeResponse response = awsServices.DetachVolume(volume, attachment, attachment.InstanceId, false);

                    if (response.Success == true) {

                        AttachmentsSortableListView.Items.Remove(lvi);

                    }

                    this.Cursor = Cursors.Default;

                }

            }

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e) {

            if (AttachmentsSortableListView.SelectedItems.Count > 0) {

                // Readonly mode?
                DetachVolumeToolStripMenuItem.Enabled = !cloudAccount.ReadOnlyMode;
                ForceDetachVolumeToolStripMenuItem.Enabled = !cloudAccount.ReadOnlyMode;

            } else {

                DetachVolumeToolStripMenuItem.Enabled = false;
                ForceDetachVolumeToolStripMenuItem.Enabled = false;

            }

        }

        private void ForceDetachVolumeToolStripMenuItem_Click(object sender, EventArgs e) {

            if (AttachmentsSortableListView.SelectedItems.Count > 0) {

                if (MessageBox.Show("Detach the selected volume?", Application.ProductName, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {

                    ListViewItem lvi = AttachmentsSortableListView.SelectedItems[0];
                    VolumeAttachment attachment = (VolumeAttachment)lvi.Tag;

                    this.Cursor = Cursors.WaitCursor;

                    CloudStudio.SharedLibrary.Services.AWSServices.DetachVolumeResponse response = awsServices.DetachVolume(volume, attachment, attachment.InstanceId, true);

                    if (response.Success == true) {

                        AttachmentsSortableListView.Items.Remove(lvi);

                    }

                    this.Cursor = Cursors.Default;

                }

            }

        }

    }

}