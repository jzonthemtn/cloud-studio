namespace CloudStudio.GUI.Forms {
    partial class SecurityGroupsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecurityGroupsForm));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.RulesContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.RefreshGroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.GroupsSortableListView = new CloudStudio.GUI.Controls.SortableListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.VPCsComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.InSortableListView = new CloudStudio.GUI.Controls.SortableListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.OutSortableListView = new CloudStudio.GUI.Controls.SortableListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.SecurityGroupLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RulesContextMenuStrip.SuspendLayout();
            this.GroupsContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "firewall-26.png");
            this.imageList1.Images.SetKeyName(1, "password2-26.png");
            this.imageList1.Images.SetKeyName(2, "left_circular-26.png");
            this.imageList1.Images.SetKeyName(3, "right_circular-26.png");
            this.imageList1.Images.SetKeyName(4, "warning_shield-26.png");
            // 
            // RulesContextMenuStrip
            // 
            this.RulesContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddRuleToolStripMenuItem,
            this.DeleteRuleToolStripMenuItem,
            this.toolStripSeparator2,
            this.refreshToolStripMenuItem});
            this.RulesContextMenuStrip.Name = "RulesContextMenuStrip";
            this.RulesContextMenuStrip.Size = new System.Drawing.Size(143, 76);
            this.RulesContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.RulesContextMenuStrip_Opening);
            // 
            // AddRuleToolStripMenuItem
            // 
            this.AddRuleToolStripMenuItem.Name = "AddRuleToolStripMenuItem";
            this.AddRuleToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.AddRuleToolStripMenuItem.Text = "Add Rule...";
            this.AddRuleToolStripMenuItem.Click += new System.EventHandler(this.AddRuleToolStripMenuItem_Click);
            // 
            // DeleteRuleToolStripMenuItem
            // 
            this.DeleteRuleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DeleteRuleToolStripMenuItem.Image")));
            this.DeleteRuleToolStripMenuItem.Name = "DeleteRuleToolStripMenuItem";
            this.DeleteRuleToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.DeleteRuleToolStripMenuItem.Text = "Delete Rule...";
            this.DeleteRuleToolStripMenuItem.Click += new System.EventHandler(this.DeleteRuleToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(139, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("refreshToolStripMenuItem.Image")));
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // GroupsContextMenuStrip
            // 
            this.GroupsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addGroupToolStripMenuItem,
            this.DeleteGroupToolStripMenuItem,
            this.toolStripSeparator1,
            this.RefreshGroupsToolStripMenuItem});
            this.GroupsContextMenuStrip.Name = "GroupsContextMenuStrip";
            this.GroupsContextMenuStrip.Size = new System.Drawing.Size(153, 76);
            this.GroupsContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.GroupsContextMenuStrip_Opening);
            // 
            // addGroupToolStripMenuItem
            // 
            this.addGroupToolStripMenuItem.Name = "addGroupToolStripMenuItem";
            this.addGroupToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addGroupToolStripMenuItem.Text = "Add Group...";
            this.addGroupToolStripMenuItem.Click += new System.EventHandler(this.addGroupToolStripMenuItem_Click);
            // 
            // DeleteGroupToolStripMenuItem
            // 
            this.DeleteGroupToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DeleteGroupToolStripMenuItem.Image")));
            this.DeleteGroupToolStripMenuItem.Name = "DeleteGroupToolStripMenuItem";
            this.DeleteGroupToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.DeleteGroupToolStripMenuItem.Text = "Delete Group...";
            this.DeleteGroupToolStripMenuItem.Click += new System.EventHandler(this.DeleteGroupToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // RefreshGroupsToolStripMenuItem
            // 
            this.RefreshGroupsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RefreshGroupsToolStripMenuItem.Image")));
            this.RefreshGroupsToolStripMenuItem.Name = "RefreshGroupsToolStripMenuItem";
            this.RefreshGroupsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.RefreshGroupsToolStripMenuItem.Text = "Refresh";
            this.RefreshGroupsToolStripMenuItem.Click += new System.EventHandler(this.RefreshGroupsToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.GroupsSortableListView);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(520, 416);
            this.splitContainer1.SplitterDistance = 228;
            this.splitContainer1.TabIndex = 2;
            // 
            // GroupsSortableListView
            // 
            this.GroupsSortableListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.GroupsSortableListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.GroupsSortableListView.ContextMenuStrip = this.GroupsContextMenuStrip;
            this.GroupsSortableListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupsSortableListView.FullRowSelect = true;
            this.GroupsSortableListView.LargeImageList = this.imageList1;
            this.GroupsSortableListView.Location = new System.Drawing.Point(0, 41);
            this.GroupsSortableListView.Name = "GroupsSortableListView";
            this.GroupsSortableListView.Size = new System.Drawing.Size(520, 187);
            this.GroupsSortableListView.SmallImageList = this.imageList1;
            this.GroupsSortableListView.TabIndex = 1;
            this.GroupsSortableListView.UseCompatibleStateImageBehavior = false;
            this.GroupsSortableListView.View = System.Windows.Forms.View.Details;
            this.GroupsSortableListView.SelectedIndexChanged += new System.EventHandler(this.GroupsSortableListView_SelectedIndexChanged);
            this.GroupsSortableListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GroupsSortableListView_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 109;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 108;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Description";
            this.columnHeader3.Width = 255;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "VPC ID";
            this.columnHeader4.Width = 100;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.VPCsComboBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(520, 41);
            this.panel1.TabIndex = 2;
            // 
            // VPCsComboBox
            // 
            this.VPCsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VPCsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VPCsComboBox.FormattingEnabled = true;
            this.VPCsComboBox.Location = new System.Drawing.Point(66, 10);
            this.VPCsComboBox.Name = "VPCsComboBox";
            this.VPCsComboBox.Size = new System.Drawing.Size(442, 21);
            this.VPCsComboBox.TabIndex = 1;
            this.VPCsComboBox.SelectedIndexChanged += new System.EventHandler(this.VPCsComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "VPC:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(0, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(520, 152);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.InSortableListView);
            this.tabPage1.ImageIndex = 3;
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(512, 125);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Inbound Rules";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // InSortableListView
            // 
            this.InSortableListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.InSortableListView.ContextMenuStrip = this.RulesContextMenuStrip;
            this.InSortableListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InSortableListView.FullRowSelect = true;
            this.InSortableListView.LargeImageList = this.imageList1;
            this.InSortableListView.Location = new System.Drawing.Point(3, 3);
            this.InSortableListView.Name = "InSortableListView";
            this.InSortableListView.Size = new System.Drawing.Size(506, 119);
            this.InSortableListView.SmallImageList = this.imageList1;
            this.InSortableListView.TabIndex = 0;
            this.InSortableListView.UseCompatibleStateImageBehavior = false;
            this.InSortableListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Type";
            this.columnHeader5.Width = 93;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Protocol";
            this.columnHeader6.Width = 107;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Port Range";
            this.columnHeader7.Width = 110;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Source(s)";
            this.columnHeader8.Width = 166;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.OutSortableListView);
            this.tabPage2.ImageIndex = 2;
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(512, 125);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Outbound Rules";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // OutSortableListView
            // 
            this.OutSortableListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.OutSortableListView.ContextMenuStrip = this.RulesContextMenuStrip;
            this.OutSortableListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutSortableListView.FullRowSelect = true;
            this.OutSortableListView.LargeImageList = this.imageList1;
            this.OutSortableListView.Location = new System.Drawing.Point(3, 3);
            this.OutSortableListView.Name = "OutSortableListView";
            this.OutSortableListView.Size = new System.Drawing.Size(506, 119);
            this.OutSortableListView.SmallImageList = this.imageList1;
            this.OutSortableListView.TabIndex = 1;
            this.OutSortableListView.UseCompatibleStateImageBehavior = false;
            this.OutSortableListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Type";
            this.columnHeader9.Width = 104;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Protocol";
            this.columnHeader10.Width = 105;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Port Range";
            this.columnHeader11.Width = 112;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Destination";
            this.columnHeader12.Width = 159;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SecurityGroupLabel);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(520, 32);
            this.panel2.TabIndex = 2;
            // 
            // SecurityGroupLabel
            // 
            this.SecurityGroupLabel.AutoSize = true;
            this.SecurityGroupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SecurityGroupLabel.Location = new System.Drawing.Point(92, 9);
            this.SecurityGroupLabel.Name = "SecurityGroupLabel";
            this.SecurityGroupLabel.Size = new System.Drawing.Size(89, 13);
            this.SecurityGroupLabel.TabIndex = 1;
            this.SecurityGroupLabel.Text = "None selected";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Rules for group:";
            // 
            // SecurityGroupsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 416);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "SecurityGroupsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Security Groups";
            this.Load += new System.EventHandler(this.SecurityGroups_Load);
            this.RulesContextMenuStrip.ResumeLayout(false);
            this.GroupsContextMenuStrip.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.SortableListView GroupsSortableListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controls.SortableListView InSortableListView;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox VPCsComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private Controls.SortableListView OutSortableListView;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ContextMenuStrip RulesContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem AddRuleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteRuleToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip GroupsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem RefreshGroupsToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label SecurityGroupLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
    }
}