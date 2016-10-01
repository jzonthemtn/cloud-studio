using CloudStudio.GUI.Controls;
namespace CloudStudio.GUI.Forms {
    partial class VolumesForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VolumesForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.VolumesContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CreateSnapshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ViewAttachmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.VolumeTagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SnapshotsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RegisterAsImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CopySnapshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteSnapshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.SnapshotTagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.InstancesComboBox = new System.Windows.Forms.ComboBox();
            this.ImagesContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeregisterImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LaunchInstanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AMIsListView = new CloudStudio.GUI.Controls.SortableListView();
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SnapshotsListView = new CloudStudio.GUI.Controls.SortableListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VolumesListView = new CloudStudio.GUI.Controls.SortableListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.RefreshVolumesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VolumesContextMenuStrip.SuspendLayout();
            this.SnapshotsContextMenuStrip.SuspendLayout();
            this.ImagesContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Volumes:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Snapshots:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 354);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "AMIs:";
            // 
            // VolumesContextMenuStrip
            // 
            this.VolumesContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateSnapshotToolStripMenuItem,
            this.toolStripSeparator2,
            this.ViewAttachmentsToolStripMenuItem,
            this.toolStripSeparator3,
            this.VolumeTagsToolStripMenuItem,
            this.toolStripSeparator6,
            this.RefreshVolumesToolStripMenuItem});
            this.VolumesContextMenuStrip.Name = "VolumesContextMenuStrip";
            this.VolumesContextMenuStrip.Size = new System.Drawing.Size(180, 132);
            this.VolumesContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.VolumesContextMenuStrip_Opening);
            // 
            // CreateSnapshotToolStripMenuItem
            // 
            this.CreateSnapshotToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CreateSnapshotToolStripMenuItem.Image")));
            this.CreateSnapshotToolStripMenuItem.Name = "CreateSnapshotToolStripMenuItem";
            this.CreateSnapshotToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.CreateSnapshotToolStripMenuItem.Text = "Create Snapshot...";
            this.CreateSnapshotToolStripMenuItem.Click += new System.EventHandler(this.CreateSnapshotToolStripMenuItem_Click_1);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(176, 6);
            // 
            // ViewAttachmentsToolStripMenuItem
            // 
            this.ViewAttachmentsToolStripMenuItem.Name = "ViewAttachmentsToolStripMenuItem";
            this.ViewAttachmentsToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.ViewAttachmentsToolStripMenuItem.Text = "View Attachments...";
            this.ViewAttachmentsToolStripMenuItem.Click += new System.EventHandler(this.ViewAttachmentsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(176, 6);
            // 
            // VolumeTagsToolStripMenuItem
            // 
            this.VolumeTagsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("VolumeTagsToolStripMenuItem.Image")));
            this.VolumeTagsToolStripMenuItem.Name = "VolumeTagsToolStripMenuItem";
            this.VolumeTagsToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.VolumeTagsToolStripMenuItem.Text = "Tags...";
            this.VolumeTagsToolStripMenuItem.Click += new System.EventHandler(this.VolumeTagsToolStripMenuItem_Click);
            // 
            // SnapshotsContextMenuStrip
            // 
            this.SnapshotsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RegisterAsImageToolStripMenuItem,
            this.toolStripSeparator1,
            this.CopySnapshotToolStripMenuItem,
            this.DeleteSnapshotToolStripMenuItem,
            this.toolStripSeparator4,
            this.SnapshotTagsToolStripMenuItem,
            this.toolStripSeparator5,
            this.refreshToolStripMenuItem});
            this.SnapshotsContextMenuStrip.Name = "SnapshotsContextMenuStrip";
            this.SnapshotsContextMenuStrip.Size = new System.Drawing.Size(176, 132);
            this.SnapshotsContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.SnapshotsContextMenuStrip_Opening);
            // 
            // RegisterAsImageToolStripMenuItem
            // 
            this.RegisterAsImageToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RegisterAsImageToolStripMenuItem.Image")));
            this.RegisterAsImageToolStripMenuItem.Name = "RegisterAsImageToolStripMenuItem";
            this.RegisterAsImageToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.RegisterAsImageToolStripMenuItem.Text = "Register as Image...";
            this.RegisterAsImageToolStripMenuItem.Click += new System.EventHandler(this.RegisterAsImageToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(172, 6);
            // 
            // CopySnapshotToolStripMenuItem
            // 
            this.CopySnapshotToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CopySnapshotToolStripMenuItem.Image")));
            this.CopySnapshotToolStripMenuItem.Name = "CopySnapshotToolStripMenuItem";
            this.CopySnapshotToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.CopySnapshotToolStripMenuItem.Text = "Copy...";
            this.CopySnapshotToolStripMenuItem.Click += new System.EventHandler(this.CopySnapshotToolStripMenuItem_Click);
            // 
            // DeleteSnapshotToolStripMenuItem
            // 
            this.DeleteSnapshotToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DeleteSnapshotToolStripMenuItem.Image")));
            this.DeleteSnapshotToolStripMenuItem.Name = "DeleteSnapshotToolStripMenuItem";
            this.DeleteSnapshotToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.DeleteSnapshotToolStripMenuItem.Text = "Delete Snapshot...";
            this.DeleteSnapshotToolStripMenuItem.Click += new System.EventHandler(this.DeleteSnapshotToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(172, 6);
            // 
            // SnapshotTagsToolStripMenuItem
            // 
            this.SnapshotTagsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SnapshotTagsToolStripMenuItem.Image")));
            this.SnapshotTagsToolStripMenuItem.Name = "SnapshotTagsToolStripMenuItem";
            this.SnapshotTagsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.SnapshotTagsToolStripMenuItem.Text = "Tags...";
            this.SnapshotTagsToolStripMenuItem.Click += new System.EventHandler(this.SnapshotTagsToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ssd-26.png");
            this.imageList1.Images.SetKeyName(1, "camera-26.png");
            this.imageList1.Images.SetKeyName(2, "cd-26.png");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Instance:";
            // 
            // InstancesComboBox
            // 
            this.InstancesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InstancesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InstancesComboBox.FormattingEnabled = true;
            this.InstancesComboBox.Location = new System.Drawing.Point(69, 16);
            this.InstancesComboBox.Name = "InstancesComboBox";
            this.InstancesComboBox.Size = new System.Drawing.Size(358, 21);
            this.InstancesComboBox.TabIndex = 7;
            this.InstancesComboBox.SelectedIndexChanged += new System.EventHandler(this.InstancesComboBox_SelectedIndexChanged);
            // 
            // ImagesContextMenuStrip
            // 
            this.ImagesContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeregisterImageToolStripMenuItem,
            this.LaunchInstanceToolStripMenuItem});
            this.ImagesContextMenuStrip.Name = "ImagesContextMenuStrip";
            this.ImagesContextMenuStrip.Size = new System.Drawing.Size(235, 48);
            this.ImagesContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.ImagesContextMenuStrip_Opening);
            // 
            // DeregisterImageToolStripMenuItem
            // 
            this.DeregisterImageToolStripMenuItem.Name = "DeregisterImageToolStripMenuItem";
            this.DeregisterImageToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.DeregisterImageToolStripMenuItem.Text = "Deregister Image...";
            // 
            // LaunchInstanceToolStripMenuItem
            // 
            this.LaunchInstanceToolStripMenuItem.Name = "LaunchInstanceToolStripMenuItem";
            this.LaunchInstanceToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.LaunchInstanceToolStripMenuItem.Text = "Launch Instance from Image...";
            this.LaunchInstanceToolStripMenuItem.Click += new System.EventHandler(this.LaunchInstanceToolStripMenuItem_Click);
            // 
            // AMIsListView
            // 
            this.AMIsListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.AMIsListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AMIsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader21,
            this.columnHeader22,
            this.columnHeader23,
            this.columnHeader24});
            this.AMIsListView.ContextMenuStrip = this.ImagesContextMenuStrip;
            this.AMIsListView.FullRowSelect = true;
            this.AMIsListView.LargeImageList = this.imageList1;
            this.AMIsListView.Location = new System.Drawing.Point(15, 370);
            this.AMIsListView.Name = "AMIsListView";
            this.AMIsListView.Size = new System.Drawing.Size(411, 124);
            this.AMIsListView.SmallImageList = this.imageList1;
            this.AMIsListView.TabIndex = 5;
            this.AMIsListView.UseCompatibleStateImageBehavior = false;
            this.AMIsListView.View = System.Windows.Forms.View.Details;
            this.AMIsListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.AMIsListView_ColumnClick);
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "ID";
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Name";
            this.columnHeader18.Width = 100;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Architecture";
            this.columnHeader19.Width = 75;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Description";
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "Hypervisor";
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "Location";
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "Platform";
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "Public";
            // 
            // SnapshotsListView
            // 
            this.SnapshotsListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.SnapshotsListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SnapshotsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16});
            this.SnapshotsListView.ContextMenuStrip = this.SnapshotsContextMenuStrip;
            this.SnapshotsListView.FullRowSelect = true;
            this.SnapshotsListView.LargeImageList = this.imageList1;
            this.SnapshotsListView.Location = new System.Drawing.Point(15, 215);
            this.SnapshotsListView.Name = "SnapshotsListView";
            this.SnapshotsListView.Size = new System.Drawing.Size(411, 124);
            this.SnapshotsListView.SmallImageList = this.imageList1;
            this.SnapshotsListView.TabIndex = 3;
            this.SnapshotsListView.UseCompatibleStateImageBehavior = false;
            this.SnapshotsListView.View = System.Windows.Forms.View.Details;
            this.SnapshotsListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.SnapshotsListView_ColumnClick);
            this.SnapshotsListView.ItemActivate += new System.EventHandler(this.SnapshotsListView_ItemActivate);
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "ID";
            this.columnHeader9.Width = 61;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Name";
            this.columnHeader10.Width = 100;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Volume Size";
            this.columnHeader11.Width = 75;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Description";
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Progress";
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "State";
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Start Date";
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Owner ID";
            // 
            // VolumesListView
            // 
            this.VolumesListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.VolumesListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VolumesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.VolumesListView.ContextMenuStrip = this.VolumesContextMenuStrip;
            this.VolumesListView.FullRowSelect = true;
            this.VolumesListView.LargeImageList = this.imageList1;
            this.VolumesListView.Location = new System.Drawing.Point(15, 59);
            this.VolumesListView.Name = "VolumesListView";
            this.VolumesListView.Size = new System.Drawing.Size(411, 124);
            this.VolumesListView.SmallImageList = this.imageList1;
            this.VolumesListView.TabIndex = 1;
            this.VolumesListView.UseCompatibleStateImageBehavior = false;
            this.VolumesListView.View = System.Windows.Forms.View.Details;
            this.VolumesListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.VolumesListView_ColumnClick);
            this.VolumesListView.ItemActivate += new System.EventHandler(this.VolumesListView_ItemActivate);
            this.VolumesListView.SelectedIndexChanged += new System.EventHandler(this.VolumesListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 94;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Capacity";
            this.columnHeader3.Width = 75;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Type";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Created";
            this.columnHeader5.Width = 113;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Zone";
            this.columnHeader6.Width = 90;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "State";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Attachment(s)";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(172, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(176, 6);
            // 
            // RefreshVolumesToolStripMenuItem
            // 
            this.RefreshVolumesToolStripMenuItem.Name = "RefreshVolumesToolStripMenuItem";
            this.RefreshVolumesToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.RefreshVolumesToolStripMenuItem.Text = "Refresh";
            this.RefreshVolumesToolStripMenuItem.Click += new System.EventHandler(this.RefreshVolumesToolStripMenuItem_Click);
            // 
            // VolumesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 507);
            this.Controls.Add(this.InstancesComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.AMIsListView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SnapshotsListView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.VolumesListView);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "VolumesForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Volumes and Snapshots";
            this.Load += new System.EventHandler(this.VolumesForm_Load);
            this.VolumesContextMenuStrip.ResumeLayout(false);
            this.SnapshotsContextMenuStrip.ResumeLayout(false);
            this.ImagesContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.Label label3;
        private SortableListView VolumesListView;
        private SortableListView SnapshotsListView;
        private SortableListView AMIsListView;
        private System.Windows.Forms.ContextMenuStrip VolumesContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem CreateSnapshotToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip SnapshotsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem DeleteSnapshotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RegisterAsImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ViewAttachmentsToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem VolumeTagsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem SnapshotTagsToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox InstancesComboBox;
        private System.Windows.Forms.ContextMenuStrip ImagesContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem DeregisterImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LaunchInstanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopySnapshotToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem RefreshVolumesToolStripMenuItem;
    }
}