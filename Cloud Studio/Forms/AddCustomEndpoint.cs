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

    public partial class AddCustomEndpointForm : System.Windows.Forms.Form
    {

        public string Name { get; set; }
        public string Url { get; set; }

        public AddCustomEndpointForm() {

            InitializeComponent();

        }

        private void buttonOk_Click(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            if (NameTextBox.TextLength > 0 && URLTextBox.TextLength > 0) {                

                this.Name = NameTextBox.Text;
                this.Url = URLTextBox.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();

            } else {

                MessageBox.Show("A name and URL are required.", Application.ProductName);

            }

        }

        private void AddCustomEndpointForm_Load(object sender, EventArgs e)
        {
         
            // Track this event.
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_FORM_OPEN, this.GetType().Name);

            this.ActiveControl = NameTextBox;

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

    }

}
