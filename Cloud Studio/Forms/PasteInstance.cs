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
    public partial class PasteInstanceForm : Form
    {
        public PasteInstanceForm()
        {
            InitializeComponent();
        }

        private void PasteButton_Click(object sender, EventArgs e)
        {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void DontShowNextTimeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowPasteConfirmation = !DontShowNextTimeCheckBox.Checked;
        }

        private void PasteInstanceForm_Load(object sender, EventArgs e)
        {
            // Track this event.
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_FORM_OPEN, this.GetType().Name);
        }
    }
}
