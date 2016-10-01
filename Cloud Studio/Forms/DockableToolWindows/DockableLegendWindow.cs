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
    public partial class DockableLegendWindow : BaseDockableToolWindow
    {

        public DockableLegendWindow()
        {
            InitializeComponent();
        }

        private void DockableLegendWindow_Load(object sender, EventArgs e)
        {
            this.StoppedPanel.BackColor = GetColorForState("Stopped");
            this.ShuttingDownPanel.BackColor = GetColorForState("Shutting-Down");
            this.StoppingPanel.BackColor = GetColorForState("Stopping");
            this.PendingPanel.BackColor = GetColorForState("Pending");
            this.RunningPanel.BackColor = GetColorForState("Running");
            this.TerminatedPanel.BackColor = GetColorForState("Terminated");
        }

        public Color GetColorForState(String stateName)
        {

            Color color = Color.White;

            if (stateName.ToLower() == "running")
            {
                color = Color.Green;
            }
            else if (stateName.ToLower() == "stopped")
            {
                color = Color.White;
            }
            else if (stateName.ToLower() == "pending")
            {
                color = Color.LightGreen;
            }
            else if (stateName.ToLower() == "stopping")
            {
                color = Color.LightGray;
            }
            else if (stateName.ToLower() == "shutting-down")
            {
                color = Color.DarkGray;
            }
            else if (stateName.ToLower() == "terminated")
            {
                color = Color.Red;
            }

            return color;

        }

    }
}