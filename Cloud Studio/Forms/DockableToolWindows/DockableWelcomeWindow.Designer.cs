using CloudStudio.GUI.Controls;
namespace CloudStudio.GUI
{
    partial class DockableWelcomeWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockableWelcomeWindow));
            this.contextMenuTabPage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllButThisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.betaFeedbackHoverLinkLabel = new CloudStudio.GUI.Controls.HoverLinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RecentCloudAccount5HoverLinkLabel = new CloudStudio.GUI.Controls.HoverLinkLabel();
            this.RecentCloudAccount4HoverLinkLabel = new CloudStudio.GUI.Controls.HoverLinkLabel();
            this.RecentCloudAccount3HoverLinkLabel = new CloudStudio.GUI.Controls.HoverLinkLabel();
            this.RecentCloudAccount2HoverLinkLabel = new CloudStudio.GUI.Controls.HoverLinkLabel();
            this.RecentLabel = new System.Windows.Forms.Label();
            this.RecentCloudAccount1HoverLinkLabel = new CloudStudio.GUI.Controls.HoverLinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ShowWelcomeCheckBox = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.openCloudAccountLinkLabel = new CloudStudio.GUI.Controls.HoverLinkLabel();
            this.contextMenuTabPage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuTabPage
            // 
            this.contextMenuTabPage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem3,
            this.closeAllToolStripMenuItem,
            this.closeAllButThisToolStripMenuItem});
            this.contextMenuTabPage.Name = "contextMenuTabPage";
            this.contextMenuTabPage.Size = new System.Drawing.Size(167, 70);
            // 
            // menuItem3
            // 
            this.menuItem3.Name = "menuItem3";
            this.menuItem3.Size = new System.Drawing.Size(166, 22);
            this.menuItem3.Text = "Close";
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.closeAllToolStripMenuItem.Text = "Close All";
            // 
            // closeAllButThisToolStripMenuItem
            // 
            this.closeAllButThisToolStripMenuItem.Name = "closeAllButThisToolStripMenuItem";
            this.closeAllButThisToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.closeAllButThisToolStripMenuItem.Text = "Close All But This";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cloud Studio";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(160)))), ((int)(((byte)(210)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(542, 56);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(151, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "BETA";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.betaFeedbackHoverLinkLabel);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.RecentCloudAccount5HoverLinkLabel);
            this.panel2.Controls.Add(this.RecentCloudAccount4HoverLinkLabel);
            this.panel2.Controls.Add(this.RecentCloudAccount3HoverLinkLabel);
            this.panel2.Controls.Add(this.RecentCloudAccount2HoverLinkLabel);
            this.panel2.Controls.Add(this.RecentLabel);
            this.panel2.Controls.Add(this.RecentCloudAccount1HoverLinkLabel);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.ShowWelcomeCheckBox);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.openCloudAccountLinkLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(542, 308);
            this.panel2.TabIndex = 3;
            // 
            // betaFeedbackHoverLinkLabel
            // 
            this.betaFeedbackHoverLinkLabel.AutoSize = true;
            this.betaFeedbackHoverLinkLabel.Location = new System.Drawing.Point(180, 101);
            this.betaFeedbackHoverLinkLabel.Name = "betaFeedbackHoverLinkLabel";
            this.betaFeedbackHoverLinkLabel.Size = new System.Drawing.Size(97, 13);
            this.betaFeedbackHoverLinkLabel.TabIndex = 14;
            this.betaFeedbackHoverLinkLabel.TabStop = true;
            this.betaFeedbackHoverLinkLabel.Text = "Send us feedback!";
            this.betaFeedbackHoverLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.betaFeedbackHoverLinkLabel_LinkClicked);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(180, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(326, 47);
            this.label5.TabIndex = 13;
            this.label5.Text = "Welcome to Cloud Studio\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(179, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Welcome to Cloud Studio";
            // 
            // RecentCloudAccount5HoverLinkLabel
            // 
            this.RecentCloudAccount5HoverLinkLabel.AutoSize = true;
            this.RecentCloudAccount5HoverLinkLabel.Location = new System.Drawing.Point(13, 230);
            this.RecentCloudAccount5HoverLinkLabel.Name = "RecentCloudAccount5HoverLinkLabel";
            this.RecentCloudAccount5HoverLinkLabel.Size = new System.Drawing.Size(33, 13);
            this.RecentCloudAccount5HoverLinkLabel.TabIndex = 11;
            this.RecentCloudAccount5HoverLinkLabel.TabStop = true;
            this.RecentCloudAccount5HoverLinkLabel.Text = "name";
            this.RecentCloudAccount5HoverLinkLabel.Visible = false;
            this.RecentCloudAccount5HoverLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RecentCloudAccount5HoverLinkLabel_LinkClicked);
            // 
            // RecentCloudAccount4HoverLinkLabel
            // 
            this.RecentCloudAccount4HoverLinkLabel.AutoSize = true;
            this.RecentCloudAccount4HoverLinkLabel.Location = new System.Drawing.Point(13, 207);
            this.RecentCloudAccount4HoverLinkLabel.Name = "RecentCloudAccount4HoverLinkLabel";
            this.RecentCloudAccount4HoverLinkLabel.Size = new System.Drawing.Size(33, 13);
            this.RecentCloudAccount4HoverLinkLabel.TabIndex = 10;
            this.RecentCloudAccount4HoverLinkLabel.TabStop = true;
            this.RecentCloudAccount4HoverLinkLabel.Text = "name";
            this.RecentCloudAccount4HoverLinkLabel.Visible = false;
            this.RecentCloudAccount4HoverLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RecentCloudAccount4HoverLinkLabel_LinkClicked);
            // 
            // RecentCloudAccount3HoverLinkLabel
            // 
            this.RecentCloudAccount3HoverLinkLabel.AutoSize = true;
            this.RecentCloudAccount3HoverLinkLabel.Location = new System.Drawing.Point(13, 184);
            this.RecentCloudAccount3HoverLinkLabel.Name = "RecentCloudAccount3HoverLinkLabel";
            this.RecentCloudAccount3HoverLinkLabel.Size = new System.Drawing.Size(33, 13);
            this.RecentCloudAccount3HoverLinkLabel.TabIndex = 9;
            this.RecentCloudAccount3HoverLinkLabel.TabStop = true;
            this.RecentCloudAccount3HoverLinkLabel.Text = "name";
            this.RecentCloudAccount3HoverLinkLabel.Visible = false;
            this.RecentCloudAccount3HoverLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RecentCloudAccount3HoverLinkLabel_LinkClicked);
            // 
            // RecentCloudAccount2HoverLinkLabel
            // 
            this.RecentCloudAccount2HoverLinkLabel.AutoSize = true;
            this.RecentCloudAccount2HoverLinkLabel.Location = new System.Drawing.Point(13, 161);
            this.RecentCloudAccount2HoverLinkLabel.Name = "RecentCloudAccount2HoverLinkLabel";
            this.RecentCloudAccount2HoverLinkLabel.Size = new System.Drawing.Size(33, 13);
            this.RecentCloudAccount2HoverLinkLabel.TabIndex = 8;
            this.RecentCloudAccount2HoverLinkLabel.TabStop = true;
            this.RecentCloudAccount2HoverLinkLabel.Text = "name";
            this.RecentCloudAccount2HoverLinkLabel.Visible = false;
            this.RecentCloudAccount2HoverLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RecentCloudAccount2HoverLinkLabel_LinkClicked);
            // 
            // RecentLabel
            // 
            this.RecentLabel.AutoSize = true;
            this.RecentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecentLabel.Location = new System.Drawing.Point(12, 107);
            this.RecentLabel.Name = "RecentLabel";
            this.RecentLabel.Size = new System.Drawing.Size(61, 20);
            this.RecentLabel.TabIndex = 7;
            this.RecentLabel.Text = "Recent";
            this.RecentLabel.Visible = false;
            // 
            // RecentCloudAccount1HoverLinkLabel
            // 
            this.RecentCloudAccount1HoverLinkLabel.AutoSize = true;
            this.RecentCloudAccount1HoverLinkLabel.Location = new System.Drawing.Point(13, 138);
            this.RecentCloudAccount1HoverLinkLabel.Name = "RecentCloudAccount1HoverLinkLabel";
            this.RecentCloudAccount1HoverLinkLabel.Size = new System.Drawing.Size(33, 13);
            this.RecentCloudAccount1HoverLinkLabel.TabIndex = 6;
            this.RecentCloudAccount1HoverLinkLabel.TabStop = true;
            this.RecentCloudAccount1HoverLinkLabel.Text = "name";
            this.RecentCloudAccount1HoverLinkLabel.Visible = false;
            this.RecentCloudAccount1HoverLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RecentCloudAccount1HoverLinkLabel_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Getting Started";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(391, 221);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(137, 72);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // ShowWelcomeCheckBox
            // 
            this.ShowWelcomeCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ShowWelcomeCheckBox.AutoSize = true;
            this.ShowWelcomeCheckBox.Location = new System.Drawing.Point(16, 276);
            this.ShowWelcomeCheckBox.Name = "ShowWelcomeCheckBox";
            this.ShowWelcomeCheckBox.Size = new System.Drawing.Size(158, 17);
            this.ShowWelcomeCheckBox.TabIndex = 2;
            this.ShowWelcomeCheckBox.Text = "Show this Welcome at start.";
            this.ShowWelcomeCheckBox.UseVisualStyleBackColor = true;
            this.ShowWelcomeCheckBox.CheckedChanged += new System.EventHandler(this.ShowWelcomeCheckBox_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(542, 3);
            this.panel3.TabIndex = 1;
            // 
            // openCloudAccountLinkLabel
            // 
            this.openCloudAccountLinkLabel.AutoSize = true;
            this.openCloudAccountLinkLabel.Location = new System.Drawing.Point(13, 51);
            this.openCloudAccountLinkLabel.Name = "openCloudAccountLinkLabel";
            this.openCloudAccountLinkLabel.Size = new System.Drawing.Size(129, 13);
            this.openCloudAccountLinkLabel.TabIndex = 0;
            this.openCloudAccountLinkLabel.TabStop = true;
            this.openCloudAccountLinkLabel.Text = "Open your AWS account.";
            this.openCloudAccountLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.openCloudAccountLinkLabel_LinkClicked);
            // 
            // DockableWelcomeWindow
            // 
            this.ClientSize = new System.Drawing.Size(542, 368);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DockableWelcomeWindow";
            this.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.TabPageContextMenuStrip = this.contextMenuTabPage;
            this.Text = "Welcome to Cloud Studio";
            this.Load += new System.EventHandler(this.DummyDoc_Load);
            this.contextMenuTabPage.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuTabPage;
        private System.Windows.Forms.ToolStripMenuItem menuItem3;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllButThisToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private HoverLinkLabel openCloudAccountLinkLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox ShowWelcomeCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label RecentLabel;
        private HoverLinkLabel RecentCloudAccount1HoverLinkLabel;
        private HoverLinkLabel RecentCloudAccount5HoverLinkLabel;
        private HoverLinkLabel RecentCloudAccount4HoverLinkLabel;
        private HoverLinkLabel RecentCloudAccount3HoverLinkLabel;
        private HoverLinkLabel RecentCloudAccount2HoverLinkLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private HoverLinkLabel betaFeedbackHoverLinkLabel;
    }
}