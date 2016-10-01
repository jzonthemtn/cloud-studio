using CloudStudio.SharedLibrary.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace CloudStudio.GUI
{
    public partial class DockablePropertiesWindow : BaseDockableToolWindow
    {

        private MainMDIForm mdiForm;

        public DockablePropertiesWindow(MainMDIForm mdiForm)
        {
            InitializeComponent();

            this.mdiForm = mdiForm;
        }

        private void DockablePropertiesWindow_Load(object sender, EventArgs e)
        {

        }

        public PropertyGrid GetPropertyGrid()
        {
            return propertyGrid;
        }

    }
}