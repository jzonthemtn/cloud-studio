using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CloudStudio.GUI.Utils;
using CloudStudio.GUI.Classes;
using CloudStudio.Services.Model;
using CloudStudio.SharedLibrary;

namespace CloudStudio.GUI.Forms {

    public partial class AboutForm : System.Windows.Forms.Form {

        public AboutForm() {

            InitializeComponent();

        }

        private void AboutForm_Load(object sender, EventArgs e) {

            // Track this event.
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_FORM_OPEN, this.GetType().Name);

            AppTitleLabel.Text = Application.ProductName;
            VersionLabel.Text = Application.ProductVersion;
            CompanyNameLabel.Text = Application.CompanyName;                 

        }

        private void ProductLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {

            System.Diagnostics.Process.Start(Constants.HOMEPAGE_URL);

        }

        private void IconsLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {

            System.Diagnostics.Process.Start(Constants.ICONS8_URL);

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }

}
