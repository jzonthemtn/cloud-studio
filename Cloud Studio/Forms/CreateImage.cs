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

    public partial class CreateImageForm : System.Windows.Forms.Form
    {

        private MainMDIForm mdiForm;
        private Instance instance;

        public CreateImageForm(MainMDIForm mdiForm, Instance instance)
        {

            InitializeComponent();

            this.mdiForm = mdiForm;
            this.instance = instance;

        }

        private void CopySnapshotForm_Load(object sender, EventArgs e) {

            // Track this event.
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_FORM_OPEN, this.GetType().Name);

            InstanceIDTextBox.Text = instance.InstanceId;

            this.ActiveControl = ImageNameTextBox;

        }

        private void buttonOk_Click(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            // Validate the input.
            // Naming restrictions: http://docs.aws.amazon.com/AWSEC2/latest/CommandLineReference/ApiReference-cmd-CreateImage.html
            if(ImageNameTextBox.TextLength < 3 || ImageNameTextBox.TextLength > 128)
            {
                MessageBox.Show("The image name must be between 3 and 128 characters.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = ImageNameTextBox;
                return;
            }

            if (DescriptionTextBox.TextLength > 255)
            {
                MessageBox.Show("The description cannot exceed 255 characters.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ActiveControl = DescriptionTextBox;
                return;
            }

            GenericActionResponse response = mdiForm.GetAWSServices().CreateImage(instance.InstanceId, ImageNameTextBox.Text, DescriptionTextBox.Text);

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

        private void ImageNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if(ImageNameTextBox.TextLength == 0)
            {
                errorProvider1.SetError(ImageNameTextBox, "Image name is required.");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void DescriptionTextBox_TextChanged(object sender, EventArgs e)
        {

        }

    }

}