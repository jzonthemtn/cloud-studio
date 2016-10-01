using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Amazon.EC2;
using Amazon.EC2.Model;
using CloudStudio.GUI.Utils;
using CloudStudio.Services.Services;
using CloudStudio.SharedLibrary.Services.AWSServices;
using CloudStudio.GUI.Classes;
using CloudStudio.Services.Model;
using CloudStudio.SharedLibrary;

namespace CloudStudio.GUI.Forms {

    public partial class RegisterImageForm : System.Windows.Forms.Form
    {

        private ICloudService awsServices;
        private Snapshot snapshot;

        public RegisterImageForm(ICloudService awsServices, Snapshot snapshot)
        {

            InitializeComponent();

            this.awsServices = awsServices;
            this.snapshot = snapshot;

        }

        private void RegisterImageForm_Load(object sender, EventArgs e) {

            // Track this event.
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_FORM_OPEN, this.GetType().Name);

            BlockDeviceMappingsSortableListView.Items.Clear();

            SnapshotTextBox.Text = this.snapshot.SnapshotId;
            ArchitectureComboBox.SelectedIndex = 0;
            VirtualizationTypeComboBox.SelectedIndex = 0;

            // TODO: Need to figure out how this first mapping gets added.
            /*ListViewItem lvi = new ListViewItem();
            lvi.Text = "Root";
            lvi.SubItems.Add("/dev/sda1");
            lvi.SubItems.Add(snapshot.SnapshotId);
            lvi.SubItems.Add(snapshot.VolumeSize.ToString());
            lvi.SubItems.Add("General Purpose (SSD)");
            //lvi.SubItems.Add(volume.Iops.ToString());
            lvi.SubItems.Add(Constants.GetYesNoFromBool(true));
            //lvi.SubItems.Add(Constants.GetYesNoFromBool(volume.Encrypted));

            BlockDeviceMappingsSortableListView.Items.Add(lvi);*/

            this.ActiveControl = NameTextBox;

        }

        private void buttonOk_Click(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            if (BlockDeviceMappingsSortableListView.Items.Count > 0) {

                // TODO: Regex the name to validate it.
                if (NameTextBox.TextLength > 2 && NameTextBox.TextLength < 129) {

                    ArchitectureValues arch = ArchitectureValues.FindValue(ArchitectureComboBox.SelectedItem.ToString());
                    string snapshotId = snapshot.SnapshotId;
                    string description = DescriptionTextBox.Text;
                    string imageLocation = LocationTextBox.Text;
                    string kernelId = KernelIDTextBox.Text;
                    string name = NameTextBox.Text;
                    string ramDiskId = RamDiskIDTextBox.Text;
                    string rootDeviceName = RootDeviceTextBox.Text;

                    string sriovNetSupport = string.Empty;
                    if (SriovCheckBox.Checked == true) {
                        sriovNetSupport = "Simple";
                    }

                    VirtualizationType type = VirtualizationType.FindValue(VirtualizationTypeComboBox.SelectedItem.ToString());

                    List<BlockDeviceMapping> mappings = new List<BlockDeviceMapping>();

                    GenericActionResponse response = awsServices.RegisterImage(arch, mappings, snapshotId,
                        description, imageLocation, kernelId, name,
                        ramDiskId, rootDeviceName, sriovNetSupport, type);

                    if (response.Success == false) {

                        MessageUtils.ShowErrorMessage("Unable to register image from snapshot.");

                    }

                } else {

                    // The name is invalid.
                    // Constraints: 3-128 alphanumeric characters, parenthesis (()), commas (,), slashes (/), dashes (-), or underscores (_)

                    MessageUtils.ShowErrorMessage("The image name is invalid. It must be betewen 3 and 127 characters in length and contain only letters, numbers, parenthesis (()), commas (,), slashes (/), dashes (-), or underscores (_).");
                    NameTextBox.Focus();

                }

            } else {

                // No device mappings.
                MessageUtils.ShowErrorMessage("At least one device mapping must be added.");

            }

        }

        private void VirtualizationTypeComboBox_SelectedIndexChanged(object sender, EventArgs e) {

            if (VirtualizationTypeComboBox.SelectedIndex == 0) {

                SriovCheckBox.Enabled = true;

            } else {

                SriovCheckBox.Enabled = false;

            }
        }

        private void AddButton_Click(object sender, EventArgs e) {

            AddBlockDeviceForm abdf = new AddBlockDeviceForm(awsServices);
            if (abdf.ShowDialog() == DialogResult.OK) {

                ListViewItem lvi = new ListViewItem();
                lvi.Text = abdf.BlockDeviceMapping.Ebs.VolumeType.ToString();
                lvi.SubItems.Add(abdf.BlockDeviceMapping.DeviceName);
                lvi.SubItems.Add(abdf.BlockDeviceMapping.Ebs.SnapshotId);
                lvi.SubItems.Add(abdf.BlockDeviceMapping.Ebs.VolumeSize.ToString());
                lvi.SubItems.Add(abdf.BlockDeviceMapping.Ebs.VolumeType.ToString());
                lvi.SubItems.Add(abdf.BlockDeviceMapping.Ebs.Iops.ToString());
                lvi.SubItems.Add(Constants.GetYesNoFromBool(abdf.BlockDeviceMapping.Ebs.DeleteOnTermination));
                lvi.SubItems.Add(Constants.GetYesNoFromBool(abdf.BlockDeviceMapping.Ebs.Encrypted));
                lvi.Tag = abdf.BlockDeviceMapping;

                BlockDeviceMappingsSortableListView.Items.Add(lvi);

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
