using CloudStudio.GUI.Classes;
using CloudStudio.GUI.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CloudStudio.GUI.Forms
{
    public partial class SecretKeyForm : Form
    {

        public string SecretKey { get; set;  }

        public SecretKeyForm()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            if (SecretKeyTextBox.TextLength > 0)
            {
                this.SecretKey = SecretKeyTextBox.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("The secret key cannot be empty.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SecretKeyTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SecretKeyForm_Load(object sender, EventArgs e)
        {

            // Track this event.
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_FORM_OPEN, this.GetType().Name);

            this.ActiveControl = SecretKeyTextBox;

        }
    }
}
