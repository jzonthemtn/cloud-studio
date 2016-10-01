namespace CloudStudio.GUI
{
    partial class DockableOutputWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockableOutputWindow));
            this.OutputTextBox = new System.Windows.Forms.TextBox();
            this.OutputToolStrip = new System.Windows.Forms.ToolStrip();
            this.SaveOutputToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ClearOutputToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.OutputSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.OutputToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputTextBox.Location = new System.Drawing.Point(0, 27);
            this.OutputTextBox.Multiline = true;
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ReadOnly = true;
            this.OutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.OutputTextBox.Size = new System.Drawing.Size(479, 136);
            this.OutputTextBox.TabIndex = 2;
            this.OutputTextBox.WordWrap = false;
            // 
            // OutputToolStrip
            // 
            this.OutputToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveOutputToolStripButton,
            this.toolStripSeparator1,
            this.ClearOutputToolStripButton});
            this.OutputToolStrip.Location = new System.Drawing.Point(0, 2);
            this.OutputToolStrip.Name = "OutputToolStrip";
            this.OutputToolStrip.Size = new System.Drawing.Size(479, 25);
            this.OutputToolStrip.TabIndex = 3;
            this.OutputToolStrip.Text = "toolStrip1";
            // 
            // SaveOutputToolStripButton
            // 
            this.SaveOutputToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveOutputToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveOutputToolStripButton.Image")));
            this.SaveOutputToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveOutputToolStripButton.Name = "SaveOutputToolStripButton";
            this.SaveOutputToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.SaveOutputToolStripButton.Text = "Save Output";
            this.SaveOutputToolStripButton.Click += new System.EventHandler(this.SaveOutputToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ClearOutputToolStripButton
            // 
            this.ClearOutputToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ClearOutputToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("ClearOutputToolStripButton.Image")));
            this.ClearOutputToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClearOutputToolStripButton.Name = "ClearOutputToolStripButton";
            this.ClearOutputToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.ClearOutputToolStripButton.Text = "Clear Output";
            this.ClearOutputToolStripButton.Click += new System.EventHandler(this.ClearOutputToolStripButton_Click);
            // 
            // OutputSaveFileDialog
            // 
            this.OutputSaveFileDialog.Filter = "Text files|*.txt|All files|*.*";
            this.OutputSaveFileDialog.Title = "Save Output As";
            // 
            // DockableOutputWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(479, 165);
            this.Controls.Add(this.OutputTextBox);
            this.Controls.Add(this.OutputToolStrip);
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DockableOutputWindow";
            this.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockBottomAutoHide;
            this.TabText = "Output";
            this.Text = "Output";
            this.Load += new System.EventHandler(this.DockableOutputWindow_Load);
            this.OutputToolStrip.ResumeLayout(false);
            this.OutputToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.TextBox OutputTextBox;
        private System.Windows.Forms.ToolStrip OutputToolStrip;
        private System.Windows.Forms.ToolStripButton ClearOutputToolStripButton;
        private System.Windows.Forms.ToolStripButton SaveOutputToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SaveFileDialog OutputSaveFileDialog;
    }
}