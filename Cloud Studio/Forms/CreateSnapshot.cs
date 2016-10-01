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
using CloudStudio.Services;
using CloudStudio.Services.Services;
using CloudStudio.GUI.Classes;
using CloudStudio.SharedLibrary;
using CloudStudio.GUI.Utils;

namespace CloudStudio.GUI.Forms {

    public partial class CreateSnapshotForm : System.Windows.Forms.Form
    {

        private ICloudService awsServices;
        private Volume volume;

        public CreateSnapshotForm(ICloudService awsServices, Volume volume)
        {

            InitializeComponent();

            this.awsServices = awsServices;
            this.volume = volume;

        }

        private void CreateSnapshotForm_Load(object sender, EventArgs e) {

            // Track this event.
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_FORM_OPEN, this.GetType().Name);

            VolumeIDTextBox.Text = volume.VolumeId;
            this.ActiveControl = NameTextBox;

        }

        private void buttonOk_Click(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            if (DescriptionTextBox.TextLength > 0) {

                awsServices.CreateSnapshot(volume, DescriptionTextBox.Text);
                this.Close();

                MessageBox.Show("The snapshot creation process has started.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            } else {

                MessageBox.Show("A description is required.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                DescriptionTextBox.Focus();

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
