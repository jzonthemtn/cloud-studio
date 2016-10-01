using CloudStudio.SharedLibrary.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace CloudStudio.GUI
{
    public partial class DockableOutputWindow : BaseDockableToolWindow
    {

        private MainMDIForm mdiForm;

        public DockableOutputWindow(MainMDIForm mdiForm)
        {
            InitializeComponent();

            this.mdiForm = mdiForm;
        }

        private void DockableOutputWindow_Load(object sender, EventArgs e)
        {

        }

        public void LogOutputMessage(string message)
        {
            OutputTextBox.AppendText(DateTime.Now.ToString() + ": " + message + "\n");
        }

        private void ClearOutputToolStripButton_Click(object sender, EventArgs e)
        {
            OutputTextBox.Clear();
        }

        private void SaveOutputToolStripButton_Click(object sender, EventArgs e)
        {
            if(OutputSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(OutputSaveFileDialog.FileName, OutputTextBox.Text);
            }
        }

    }
}