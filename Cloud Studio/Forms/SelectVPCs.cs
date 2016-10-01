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
using CloudStudio.Services.Utilities;
using CloudStudio.GUI.Classes;
using CloudStudio.GUI.Utils;

namespace CloudStudio.GUI.Forms {

    public partial class SelectVPCsForm : System.Windows.Forms.Form {

        private IList<Vpc> vpcs;
        public IList<Vpc> SelectedVpcs { get; set; }
        public IList<Vpc> OpenVPCs { get; set; }

        public SelectVPCsForm(IList<Vpc> vpcs, IList<Vpc> openVPCs) {

            InitializeComponent();

            this.vpcs = vpcs;
            this.OpenVPCs = openVPCs;


        }

        private void SelectVPC_Load(object sender, EventArgs e) {

            // Track this event.
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_FORM_OPEN, this.GetType().Name);

            foreach (Vpc vpc in vpcs) {

                SelectableVpc selectableVpc = new SelectableVpc(vpc);

                bool add = true;

                foreach(Vpc openVpc in OpenVPCs) {
                    if (openVpc.VpcId == vpc.VpcId) {
                        add = false;
                        break;
                    }
                }

                if (add == true) {
                    VPCsCheckedListBox.Items.Add(selectableVpc);                    
                }

                for (int i = 0; i < VPCsCheckedListBox.Items.Count; i++) {
                    VPCsCheckedListBox.SetItemChecked(i, true);
                }
                  
            }            

        }

        private void buttonOk_Click(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            IList<Vpc> checkedVpcs = new List<Vpc>();

            foreach (SelectableVpc selectableVpc in VPCsCheckedListBox.CheckedItems)
             {
                 checkedVpcs.Add(selectableVpc.Vpc);  
             }

            this.SelectedVpcs = checkedVpcs;

            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void SelectAllButton_Click(object sender, EventArgs e) {

            for (int x = 0; x < VPCsCheckedListBox.Items.Count; x++) {
                VPCsCheckedListBox.SetItemChecked(x, true);
            }

        }

        private void NoneButton_Click(object sender, EventArgs e) {

            for (int x = 0; x < VPCsCheckedListBox.Items.Count; x++) {
                VPCsCheckedListBox.SetItemChecked(x, false);
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
