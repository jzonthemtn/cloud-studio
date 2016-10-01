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

    public partial class VariablesForm : System.Windows.Forms.Form
    {

        private IDictionary<string, string> variables;

        public VariablesForm(IDictionary<string, string> variables) {

            InitializeComponent();

            this.variables = variables;

        }

        private void VariablesForm_Load(object sender, EventArgs e) {

            // Track this event.
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_FORM_OPEN, this.GetType().Name);

            VariablesSortableListView.Items.Clear();

            foreach(string key in variables.Keys) {
            
                ListViewItem lvi = new ListViewItem();
                lvi.Text = key;
                lvi.SubItems.Add(variables[key]);
                lvi.ImageIndex = 0;

                VariablesSortableListView.Items.Add(lvi);

            }


        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e) {

            if (VariablesSortableListView.SelectedItems.Count > 0) {

                copyVariableToolStripMenuItem.Enabled = true;

            } else {

                copyVariableToolStripMenuItem.Enabled = false;

            }

        }

        private void copyVariableToolStripMenuItem_Click(object sender, EventArgs e) {

            if (VariablesSortableListView.SelectedItems.Count > 0) {

                ListViewItem lvi = VariablesSortableListView.SelectedItems[0];

                Clipboard.SetText(lvi.Text);

            }            

        }

    }

}