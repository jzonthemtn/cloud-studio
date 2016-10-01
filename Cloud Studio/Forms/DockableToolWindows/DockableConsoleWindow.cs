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
    public partial class DockableConsoleWindow : BaseDockableToolWindow
    {

        private MainMDIForm mdiForm;

        public DockableConsoleWindow(MainMDIForm mdiForm)
        {
            InitializeComponent();

            this.mdiForm = mdiForm;
        }

        private void DockableConsoleWindow_Load(object sender, EventArgs e)
        {

        }

        private void shellControl1_Load(object sender, EventArgs e)
        {

        }
    }
}