using CloudStudio.GUI.Controls;
namespace CloudStudio.GUI
{
    partial class DockableLegendWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockableLegendWindow));
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TerminatedPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.RunningPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.PendingPanel = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.StoppingPanel = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.StoppedPanel = new System.Windows.Forms.Panel();
            this.ShuttingDownPanel = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(45, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "Shutting Down";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 203);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 50;
            this.label7.Text = "Components";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 260);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 48;
            this.label8.Text = "Internet Gateway";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Yellow;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(18, 229);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(21, 20);
            this.panel4.TabIndex = 47;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 45;
            this.label6.Text = "Instance States";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "Terminated";
            // 
            // TerminatedPanel
            // 
            this.TerminatedPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TerminatedPanel.Location = new System.Drawing.Point(18, 168);
            this.TerminatedPanel.Name = "TerminatedPanel";
            this.TerminatedPanel.Size = new System.Drawing.Size(21, 20);
            this.TerminatedPanel.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 41;
            this.label4.Text = "Running";
            // 
            // RunningPanel
            // 
            this.RunningPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RunningPanel.Location = new System.Drawing.Point(18, 142);
            this.RunningPanel.Name = "RunningPanel";
            this.RunningPanel.Size = new System.Drawing.Size(21, 20);
            this.RunningPanel.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Pending";
            // 
            // PendingPanel
            // 
            this.PendingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PendingPanel.Location = new System.Drawing.Point(18, 116);
            this.PendingPanel.Name = "PendingPanel";
            this.PendingPanel.Size = new System.Drawing.Size(21, 20);
            this.PendingPanel.TabIndex = 40;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(45, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Stopping";
            // 
            // StoppingPanel
            // 
            this.StoppingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StoppingPanel.Location = new System.Drawing.Point(18, 91);
            this.StoppingPanel.Name = "StoppingPanel";
            this.StoppingPanel.Size = new System.Drawing.Size(21, 20);
            this.StoppingPanel.TabIndex = 38;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(45, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 34;
            this.label11.Text = "Stopped";
            // 
            // StoppedPanel
            // 
            this.StoppedPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StoppedPanel.Location = new System.Drawing.Point(18, 39);
            this.StoppedPanel.Name = "StoppedPanel";
            this.StoppedPanel.Size = new System.Drawing.Size(21, 20);
            this.StoppedPanel.TabIndex = 33;
            // 
            // ShuttingDownPanel
            // 
            this.ShuttingDownPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ShuttingDownPanel.Location = new System.Drawing.Point(18, 65);
            this.ShuttingDownPanel.Name = "ShuttingDownPanel";
            this.ShuttingDownPanel.Size = new System.Drawing.Size(21, 20);
            this.ShuttingDownPanel.TabIndex = 37;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Blue;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Location = new System.Drawing.Point(18, 253);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(21, 20);
            this.panel5.TabIndex = 49;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(45, 236);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 13);
            this.label12.TabIndex = 46;
            this.label12.Text = "Elastic Load Balancer";
            // 
            // DockableLegendWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(208, 289);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TerminatedPanel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RunningPanel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PendingPanel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.StoppingPanel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.StoppedPanel);
            this.Controls.Add(this.ShuttingDownPanel);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label12);
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DockableLegendWindow";
            this.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockRight;
            this.TabText = "Legend";
            this.Text = "Legend";
            this.Load += new System.EventHandler(this.DockableLegendWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel TerminatedPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel RunningPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel PendingPanel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel StoppingPanel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel StoppedPanel;
        private System.Windows.Forms.Panel ShuttingDownPanel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label12;

    }
}