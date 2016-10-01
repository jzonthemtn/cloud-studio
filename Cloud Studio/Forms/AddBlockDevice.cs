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
using CloudStudio.SharedLibrary.Services.AWSServices;
using CloudStudio.GUI.Classes;
using CloudStudio.SharedLibrary;
using CloudStudio.GUI.Utils;

namespace CloudStudio.GUI.Forms {

    public partial class AddBlockDeviceForm : System.Windows.Forms.Form {

        private ICloudService awsServices;
        public BlockDeviceMapping BlockDeviceMapping { get; set; }

        public AddBlockDeviceForm(ICloudService awsServices)
        {

            InitializeComponent();

            this.awsServices = awsServices;

        }

        private void AddBlockDeviceForm_Load(object sender, EventArgs e) {

            // Track this event.
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_FORM_OPEN, this.GetType().Name);

            TypeComboBox.Items.Add("EBS");

            for (int x = 0; x < 24; x++) {
                TypeComboBox.Items.Add("Instance Store " + x.ToString());
            }

            TypeComboBox.SelectedIndex = 0;

            DeviceComboBox.Items.Add("/dev/sda1");
            DeviceComboBox.Items.Add("/dev/sdb");
            DeviceComboBox.Items.Add("/dev/sdc");
            DeviceComboBox.Items.Add("/dev/sdd");
            DeviceComboBox.Items.Add("/dev/sde");
            DeviceComboBox.Items.Add("/dev/sdf");
            DeviceComboBox.Items.Add("/dev/sdg");
            DeviceComboBox.Items.Add("/dev/sdh");
            DeviceComboBox.Items.Add("/dev/sdi");
            DeviceComboBox.Items.Add("/dev/sdj");
            DeviceComboBox.Items.Add("/dev/sdk");
            DeviceComboBox.Items.Add("/dev/sdl");

            DeviceComboBox.SelectedIndex = 0;

            GetSnapshotsResponse response = awsServices.GetSnapshots(false);

            foreach(Snapshot snapshot in response.Snapshots) {

                SnapshotComboBox.Items.Add(snapshot.SnapshotId + " : " + AwsUtils.GetNameFromTags(snapshot.Tags) + " : " + snapshot.Description);

            }

            SnapshotComboBox.SelectedIndex = 0;

            VolumeTypeComboBox.SelectedIndex = 0;

        }

        private void VolumeTypeComboBox_SelectedIndexChanged(object sender, EventArgs e) {

            if (VolumeTypeComboBox.SelectedIndex == 0) {

                IOPSTextBox.ReadOnly = true;
                IOPSTextBox.Text = "30 / 3000";

            } else if (VolumeTypeComboBox.SelectedIndex == 1) {

                IOPSTextBox.ReadOnly = false;
                IOPSTextBox.Text = "30";

            } else if (VolumeTypeComboBox.SelectedIndex == 2) {

                IOPSTextBox.ReadOnly = true;
                IOPSTextBox.Text = "N/A";

            }

        }

        private void buttonOk_Click(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            this.BlockDeviceMapping = new BlockDeviceMapping();
            this.BlockDeviceMapping.DeviceName = DeviceComboBox.SelectedItem.ToString();

            this.BlockDeviceMapping.Ebs = new EbsBlockDevice();
            this.BlockDeviceMapping.Ebs.DeleteOnTermination = DeleteOnTerminationheckBox.Checked;
            this.BlockDeviceMapping.Ebs.Encrypted = EncryptedCheckBox.Checked;
            this.BlockDeviceMapping.Ebs.VolumeSize = Convert.ToInt32(SizeTextBox.Text);
            this.BlockDeviceMapping.Ebs.VolumeType = Amazon.EC2.VolumeType.FindValue(VolumeTypeComboBox.SelectedItem.ToString());

            if (VolumeTypeComboBox.SelectedIndex == 1) {
                this.BlockDeviceMapping.Ebs.Iops = Convert.ToInt32(IOPSTextBox.Text);
            }

            string snapshotId = SnapshotComboBox.SelectedItem.ToString().Split(':')[0].Trim();
            this.BlockDeviceMapping.Ebs.SnapshotId = snapshotId;

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

    }

}
