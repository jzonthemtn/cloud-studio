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
    public partial class DockablePowerShellWindow : BaseDockableToolWindow
    {

        private MainMDIForm mdiForm;

        public DockablePowerShellWindow(MainMDIForm mdiForm)
        {
            InitializeComponent();

            this.mdiForm = mdiForm;
        }

        private void DockablePowerShellWindow_Load(object sender, EventArgs e)
        {

        }
    }
}