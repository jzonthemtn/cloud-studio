using CloudStudio.GUI.Classes;
using CloudStudio.GUI.Utils;
using CloudStudio.SharedLibrary;
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

    public partial class ErrorListForm : System.Windows.Forms.Form
    {

        private IList<EventError> eventErrors;

        public ErrorListForm(IList<EventError> eventErrors) {

            InitializeComponent();

            this.eventErrors = eventErrors;

        }

        private void ErrorListForm_Load(object sender, EventArgs e)
        {

            // Track this event.
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_FORM_OPEN, this.GetType().Name);

            foreach (EventError eventError in this.eventErrors)
            {

                ListViewItem lvi = new ListViewItem(eventError.Error);
                lvi.Tag = eventError;
                lvi.ImageIndex = 0;

                EventErrorListView.Items.Add(lvi);

            }

        }

        private void EventErrorListView_MouseClick(object sender, MouseEventArgs e) {

            if (EventErrorListView.SelectedItems.Count > 0) {

                ListViewItem lvi = EventErrorListView.SelectedItems[0];
                EventError error = (EventError)lvi.Tag;

                ErrorTextBox.Text = error.Message;

            }

        }

    }

}