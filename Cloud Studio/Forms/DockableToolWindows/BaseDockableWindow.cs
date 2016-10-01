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
    public partial class BaseDockableToolWindow : DockContent
    {

        public BaseDockableToolWindow()
        {
            InitializeComponent();

        }

        private void BaseDockable_Load(object sender, EventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DockHandler.Close();
        }

    }
}