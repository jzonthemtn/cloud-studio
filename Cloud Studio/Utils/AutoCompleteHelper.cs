using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CloudStudio.GUI.Utils
{
    public class AutoCompleteUtils
    {
        public static void SetAutoComplete(TextBox textbox, IList<string> values)
        {

            textbox.AutoCompleteMode = AutoCompleteMode.Suggest;
            textbox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection dataCollection = new AutoCompleteStringCollection();
            
            foreach(string value in values)
            {
                dataCollection.Add(value);
            }

            textbox.AutoCompleteCustomSource = dataCollection;

        }
        
    }
}
