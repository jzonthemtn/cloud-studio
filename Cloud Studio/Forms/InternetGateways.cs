using Amazon.EC2.Model;
using CloudStudio.GUI.Classes;
using CloudStudio.GUI.Utils;
using CloudStudio.Services.Utilities;
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
    public partial class InternetGatewaysForm : Form
    {

        private IList<InternetGateway> InternetGateways;
        public InternetGateway SelectedInternetGateway { get; set; }

        public InternetGatewaysForm(IList<InternetGateway> InternetGateways)
        {
            InitializeComponent();

            this.InternetGateways = InternetGateways;
        }

        private void InternetGatewaysForm_Load(object sender, EventArgs e)
        {

            // Track this event.
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_FORM_OPEN, this.GetType().Name);

            foreach (InternetGateway gateway in InternetGateways)
            {

                if (gateway.Attachments.Count == 0)
                {

                    ListViewItem lvi = new ListViewItem(AwsUtils.GetNameFromTags(gateway.Tags));
                    lvi.SubItems.Add(gateway.InternetGatewayId);

                    if (gateway.Attachments.Count == 0)
                    {
                        lvi.SubItems.Add("Detached");
                    }
                    else
                    {
                        lvi.SubItems.Add(gateway.Attachments[0].State.Value);
                        lvi.SubItems.Add(gateway.Attachments[0].VpcId);
                    }

                    lvi.Tag = gateway;
                    InternetGatewaysListview.Items.Add(lvi);

                }

            }

        }

        private void InternetGatewaysListview_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(InternetGatewaysListview.SelectedItems.Count == 0)
            {
                buttonOk.Enabled = false;
            }
            else
            {
                buttonOk.Enabled = true;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            if (InternetGatewaysListview.SelectedItems.Count > 0)
            {
                this.SelectedInternetGateway = (InternetGateway)InternetGatewaysListview.SelectedItems[0].Tag;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Select an internet gateway.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
