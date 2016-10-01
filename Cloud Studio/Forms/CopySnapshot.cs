using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Amazon;
using Amazon.EC2.Model;
using CloudStudio.Services.Services;
using CloudStudio.Services.Utilities;
using CloudStudio.SharedLibrary.Services.AWSServices;
using CloudStudio.GUI.Classes;
using CloudStudio.SharedLibrary;
using CloudStudio.GUI.Utils;

namespace CloudStudio.GUI.Forms {

    public partial class CopySnapshotForm : System.Windows.Forms.Form
    {

        private MainMDIForm mdiForm;
        private Snapshot snapshot;

        public CopySnapshotForm(MainMDIForm mdiForm, Snapshot snapshot)
        {

            InitializeComponent();

            this.mdiForm = mdiForm;
            this.snapshot = snapshot;

        }

        private void RegionCopyCheckBox_CheckedChanged(object sender, EventArgs e) {

            DestinationRegionLabel.Enabled = RegionCopyCheckBox.Checked;
            DestinationRegionComboBox.Enabled = RegionCopyCheckBox.Checked;

        }

        private void CopySnapshotForm_Load(object sender, EventArgs e) {

            // Track this event.
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_FORM_OPEN, this.GetType().Name);

            SnapshotTextBox.Text = snapshot.SnapshotId;

            GetRegionEndpointsResponse getRegionEndpointsResponse = AwsUtils.GetRegionEndpoints();

            int region = 0;
            int x = 0;
            foreach (RegionEndpoint endpoint in getRegionEndpointsResponse.Endpoints) {

                DestinationRegionComboBox.Items.Add(endpoint.SystemName);
                if (endpoint.SystemName == mdiForm.GetAWSServices().GetRegion()) {               
                    region = x;
                }

                x++;

            }

            DestinationRegionComboBox.SelectedIndex = region;

            this.ActiveControl = DescriptionTextBox;

        }

        private void buttonOk_Click(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            string sourceRegion = mdiForm.GetAWSServices().GetRegion();
            string destinationRegion = DestinationRegionComboBox.SelectedItem.ToString();

            GenericActionResponse response = mdiForm.GetAWSServices().CopySnapshot(snapshot, DescriptionTextBox.Text, sourceRegion, destinationRegion);

            // TODO: Check the result.

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

    }

}