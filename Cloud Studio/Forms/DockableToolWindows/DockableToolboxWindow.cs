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
    public partial class DockableToolboxWindow : BaseDockableToolWindow
    {

        private MainMDIForm mdiForm;

        public DockableToolboxWindow(MainMDIForm mdiForm)
        {
            InitializeComponent();

            this.mdiForm = mdiForm;
        }

        private void DockableToolboxWindow_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            //InstanceLabel.DoDragDrop(InstanceLabel.Text, DragDropEffects.Copy | DragDropEffects.Move);
        }
    }
}