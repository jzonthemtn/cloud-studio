using CloudStudio.GUI.Classes;
using CloudStudio.GUI.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudStudio.GUI.Forms {

    public partial class AddFavoriteAMIForm : System.Windows.Forms.Form
    {

        public string AMI { get; set; }

        public AddFavoriteAMIForm() {

            InitializeComponent();

        }

        private void AddFavoriteAMI_Load(object sender, EventArgs e) {

            // Track this event.
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_FORM_OPEN, this.GetType().Name);

            this.ActiveControl = AMITextBox;

        }

        private void buttonOk_Click_1(object sender, EventArgs e) {

            if (AMITextBox.TextLength > 0) {

                //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);
                this.AMI = AMITextBox.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();

            } else {

                MessageBox.Show("An AMI ID is required.", Application.ProductName);

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
