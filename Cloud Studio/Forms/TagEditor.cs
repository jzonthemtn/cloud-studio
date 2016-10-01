using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CloudStudio.Services.Services;
using CloudStudio.GUI.Classes;
using CloudStudio.SharedLibrary.Domain;
using CloudStudio.SharedLibrary;
using CloudStudio.GUI.Utils;

namespace CloudStudio.GUI.Forms {

    public partial class TagEditorForm : System.Windows.Forms.Form
    {

        private ICloudService awsServices;
        private string resourceId;
        private IList<Amazon.EC2.Model.Tag> tags;
        private CloudAccount cloudAccount;

        public TagEditorForm(CloudAccount cloudAccount, ICloudService awsServices, String resourceId, IList<Amazon.EC2.Model.Tag> tags)
        {

            InitializeComponent();

            this.cloudAccount = cloudAccount;
            this.awsServices = awsServices;
            this.resourceId = resourceId;
            this.tags = tags;

            this.Text = "Tag Editor - " + resourceId;

        }

        private void AddButton_Click(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            // Tag restrictions: http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/Using_Tags.html

            if (KeyTextBox.TextLength > 0 && KeyTextBox.MaxLength < 128) {

                if (KeyTextBox.Text.StartsWith("aws:") == false) {

                    if (ValueTextBox.TextLength >= 0 && ValueTextBox.TextLength < 256) {

                        if (TagsSortableListView.Items.Count < 10) {

                            ListViewItem existingLvi = GetItemForKey(KeyTextBox.Text);

                            if (existingLvi == null) {

                                Amazon.EC2.Model.Tag tag = new Amazon.EC2.Model.Tag();
                                tag.Key = KeyTextBox.Text;
                                tag.Value = ValueTextBox.Text;

                                ListViewItem lvi = new ListViewItem();
                                lvi.Text = KeyTextBox.Text;
                                lvi.SubItems.Add(ValueTextBox.Text);
                                lvi.ImageIndex = 0;
                                lvi.Tag = tag;

                                TagsSortableListView.Items.Add(lvi);

                                awsServices.CreateTag(resourceId, tag);

                            } else {

                                MessageBox.Show("A tag with this key already exists.", Application.ProductName);
                                KeyTextBox.Focus();

                            }

                            KeyTextBox.Clear();
                            ValueTextBox.Clear();

                        } else {

                            // Max tags is 10.
                            MessageBox.Show("The maximum number of tags is 10.", Application.ProductName);

                        }

                    } else {

                        // Must be > 0 and < 256.
                        MessageBox.Show("The value must be between 1 and 255 characters.", Application.ProductName);
                        ValueTextBox.Focus();

                    }

                } else {

                    // aws: prefix is not allowed.
                    MessageBox.Show("The aws: prefix is not allowed for tag keys.", Application.ProductName);
                    KeyTextBox.Focus();

                }

            } else {

                // Must be > 0 and < 128.
                MessageBox.Show("The key must be between 1 and 128 characters.", Application.ProductName);
                KeyTextBox.Focus();

            }

        }

        private ListViewItem GetItemForKey(string key) {

            foreach (ListViewItem lvi in TagsSortableListView.Items) {

                if (lvi.Text == key) {

                    return lvi;

                }

            }

            return null;

        }

        private void TagEditorForm_Load(object sender, EventArgs e) {

            // Track this event.
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_FORM_OPEN, this.GetType().Name);

            TagsSortableListView.Items.Clear();

            foreach (Amazon.EC2.Model.Tag tag in tags) {

                ListViewItem lvi = new ListViewItem(tag.Key);
                lvi.SubItems.Add(tag.Value);
                lvi.ImageIndex = 0;
                lvi.Tag = tag;

                TagsSortableListView.Items.Add(lvi);

            }

            // Readonly mode?
            KeyTextBox.Enabled = !cloudAccount.ReadOnlyMode;
            ValueTextBox.Enabled = !cloudAccount.ReadOnlyMode;
            AddButton.Enabled = !cloudAccount.ReadOnlyMode;
            RemoveButton.Enabled = !cloudAccount.ReadOnlyMode;

            AutoCompleteUtils.SetAutoComplete(KeyTextBox, new List<string>(new string[] { "Name" }));

            this.ActiveControl = KeyTextBox;

        }       

        private void TagsSortableListView_MouseClick(object sender, MouseEventArgs e) {

            if (TagsSortableListView.SelectedItems.Count > 0) {

                ListViewItem lvi = TagsSortableListView.SelectedItems[0];
                Amazon.EC2.Model.Tag tag = (Amazon.EC2.Model.Tag)lvi.Tag;

                KeyTextBox.Text = tag.Key;
                ValueTextBox.Text = tag.Value;                

            }

        }

        private void TagsSortableListView_SelectedIndexChanged(object sender, EventArgs e) {

            if (TagsSortableListView.SelectedItems.Count > 0) {

                RemoveButton.Enabled = true;

            } else {

                RemoveButton.Enabled = false;

            }

        }

        private void RemoveButton_Click(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            ListViewItem lvi = GetItemForKey(KeyTextBox.Text);

            if (lvi != null) {

                Amazon.EC2.Model.Tag tag = (Amazon.EC2.Model.Tag)lvi.Tag;

                awsServices.DeleteTag(resourceId, tag);

                TagsSortableListView.Items.Remove(lvi);

                KeyTextBox.Clear();
                ValueTextBox.Clear();

                RemoveButton.Enabled = false;

            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((Button)sender).Name);

            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();   
        }

        private void copyKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);

            if(TagsSortableListView.SelectedItems.Count > 0)
            {
                Clipboard.SetText(TagsSortableListView.SelectedItems[0].Text);
            }
        }

        private void copyValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);

            if (TagsSortableListView.SelectedItems.Count > 0)
            {
                Clipboard.SetText(TagsSortableListView.SelectedItems[0].SubItems[1].Text);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (TagsSortableListView.SelectedItems.Count == 0)
            {
                copyKeyToolStripMenuItem.Enabled = false;
                copyValueToolStripMenuItem.Enabled = false;
            }
            else
            {
                copyKeyToolStripMenuItem.Enabled = true;
                copyValueToolStripMenuItem.Enabled = true;
            }
        }

    }

}