namespace CloudStudio.GUI.Forms {
    partial class VolumeAttachmentsForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VolumeAttachmentsForm));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DetachVolumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ForceDetachVolumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.AttachmentsSortableListView = new CloudStudio.GUI.Controls.SortableListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DetachVolumeToolStripMenuItem,
            this.ForceDetachVolumeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(197, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // DetachVolumeToolStripMenuItem
            // 
            this.DetachVolumeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DetachVolumeToolStripMenuItem.Image")));
            this.DetachVolumeToolStripMenuItem.Name = "DetachVolumeToolStripMenuItem";
            this.DetachVolumeToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.DetachVolumeToolStripMenuItem.Text = "Detach Volume...";
            this.DetachVolumeToolStripMenuItem.Click += new System.EventHandler(this.DetachVolumeToolStripMenuItem_Click);
            // 
            // ForceDetachVolumeToolStripMenuItem
            // 
            this.ForceDetachVolumeToolStripMenuItem.Name = "ForceDetachVolumeToolStripMenuItem";
            this.ForceDetachVolumeToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.ForceDetachVolumeToolStripMenuItem.Text = "Force Detach Volume...";
            this.ForceDetachVolumeToolStripMenuItem.Click += new System.EventHandler(this.ForceDetachVolumeToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "slave-26.png");
            // 
            // AttachmentsSortableListView
            // 
            this.AttachmentsSortableListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.AttachmentsSortableListView.ContextMenuStrip = this.contextMenuStrip1;
            this.AttachmentsSortableListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AttachmentsSortableListView.FullRowSelect = true;
            this.AttachmentsSortableListView.LargeImageList = this.imageList1;
            this.AttachmentsSortableListView.Location = new System.Drawing.Point(0, 0);
            this.AttachmentsSortableListView.Name = "AttachmentsSortableListView";
            this.AttachmentsSortableListView.Size = new System.Drawing.Size(537, 334);
            this.AttachmentsSortableListView.SmallImageList = this.imageList1;
            this.AttachmentsSortableListView.TabIndex = 0;
            this.AttachmentsSortableListView.UseCompatibleStateImageBehavior = false;
            this.AttachmentsSortableListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Instance ID";
            this.columnHeader1.Width = 92;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Attachment Time";
            this.columnHeader2.Width = 134;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Delete on Termination";
            this.columnHeader3.Width = 135;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Device";
            this.columnHeader4.Width = 90;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "State";
            this.columnHeader5.Width = 88;
            // 
            // VolumeAttachmentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 334);
            this.Controls.Add(this.AttachmentsSortableListView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VolumeAttachmentsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Volume Attachments";
            this.Load += new System.EventHandler(this.VolumeAttachments_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.SortableListView AttachmentsSortableListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem DetachVolumeToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem ForceDetachVolumeToolStripMenuItem;
    }
}