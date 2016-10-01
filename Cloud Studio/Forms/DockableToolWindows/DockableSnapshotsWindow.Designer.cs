using Amazon.EC2.Model;
using CloudStudio.GUI.Utils;
using CloudStudio.Services.Services;
using CloudStudio.Services.Utilities;
using CloudStudio.SharedLibrary.Services.AWSServices;
using System.Collections.Generic;
using System.Windows.Forms;
namespace CloudStudio.GUI
{
    partial class DockableSnapshotsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockableSnapshotsWindow));
            this.SnapshotsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RegisterAsImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.CopySnapshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteSnapshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.SnapshotTagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.RefreshSnapshotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.SnapshotsListView = new CloudStudio.GUI.Controls.SortableListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.SnapshotSearchTextBox = new System.Windows.Forms.TextBox();
            this.SnapshotsContextMenuStrip.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SnapshotsContextMenuStrip
            // 
            this.SnapshotsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RegisterAsImageToolStripMenuItem,
            this.toolStripSeparator6,
            this.CopySnapshotToolStripMenuItem,
            this.DeleteSnapshotToolStripMenuItem,
            this.toolStripSeparator8,
            this.SnapshotTagsToolStripMenuItem,
            this.toolStripSeparator9,
            this.RefreshSnapshotsToolStripMenuItem});
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
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(172, 6);
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
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(172, 6);
            // 
            // SnapshotTagsToolStripMenuItem
            // 
            this.SnapshotTagsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SnapshotTagsToolStripMenuItem.Image")));
            this.SnapshotTagsToolStripMenuItem.Name = "SnapshotTagsToolStripMenuItem";
            this.SnapshotTagsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.SnapshotTagsToolStripMenuItem.Text = "Tags...";
            this.SnapshotTagsToolStripMenuItem.Click += new System.EventHandler(this.SnapshotTagsToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(172, 6);
            // 
            // RefreshSnapshotsToolStripMenuItem
            // 
            this.RefreshSnapshotsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("RefreshSnapshotsToolStripMenuItem.Image")));
            this.RefreshSnapshotsToolStripMenuItem.Name = "RefreshSnapshotsToolStripMenuItem";
            this.RefreshSnapshotsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.RefreshSnapshotsToolStripMenuItem.Text = "Refresh";
            this.RefreshSnapshotsToolStripMenuItem.Click += new System.EventHandler(this.RefreshSnapshotsToolStripMenuItem_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "camera-26.png");
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
            // panel2
            // 
            this.panel2.Controls.Add(this.SnapshotsListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(623, 199);
            this.panel2.TabIndex = 8;
            // 
            // SnapshotsListView
            // 
            this.SnapshotsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.SnapshotsListView.ContextMenuStrip = this.SnapshotsContextMenuStrip;
            this.SnapshotsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SnapshotsListView.FullRowSelect = true;
            this.SnapshotsListView.LargeImageList = this.imageList2;
            this.SnapshotsListView.Location = new System.Drawing.Point(0, 0);
            this.SnapshotsListView.Name = "SnapshotsListView";
            this.SnapshotsListView.Size = new System.Drawing.Size(623, 199);
            this.SnapshotsListView.SmallImageList = this.imageList2;
            this.SnapshotsListView.StateImageList = this.imageList2;
            this.SnapshotsListView.TabIndex = 8;
            this.SnapshotsListView.UseCompatibleStateImageBehavior = false;
            this.SnapshotsListView.View = System.Windows.Forms.View.Details;
            this.SnapshotsListView.ItemActivate += new System.EventHandler(this.SnapshotsListView_ItemActivate);
            this.SnapshotsListView.SelectedIndexChanged += new System.EventHandler(this.SnapshotsListView_SelectedIndexChanged);
            this.SnapshotsListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SnapshotsListView_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 118;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Volume Size";
            this.columnHeader3.Width = 85;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Description";
            this.columnHeader4.Width = 138;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Progress";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "State";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Start Date";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Owner ID";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.SnapshotSearchTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(623, 31);
            this.panel1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Search";
            // 
            // SnapshotSearchTextBox
            // 
            this.SnapshotSearchTextBox.Location = new System.Drawing.Point(50, 5);
            this.SnapshotSearchTextBox.Name = "SnapshotSearchTextBox";
            this.SnapshotSearchTextBox.Size = new System.Drawing.Size(130, 20);
            this.SnapshotSearchTextBox.TabIndex = 0;
            this.SnapshotSearchTextBox.TextChanged += new System.EventHandler(this.SnapshotSearchTextBox_TextChanged);
            // 
            // DockableSnapshotsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(623, 234);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DockableSnapshotsWindow";
            this.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockBottom;
            this.TabText = "Snapshots";
            this.Text = "Snapshots";
            this.Load += new System.EventHandler(this.DockableSnapshotsWindow_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DockableSnapshotsWindow_MouseClick);
            this.SnapshotsContextMenuStrip.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SnapshotSearchTextBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private CloudStudio.GUI.Controls.SortableListView SnapshotsListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;

        private IList<Snapshot> snapshots;

        private ImageList imageList2;

        private ContextMenuStrip SnapshotsContextMenuStrip;
        private ToolStripMenuItem RegisterAsImageToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem CopySnapshotToolStripMenuItem;
        private ToolStripMenuItem DeleteSnapshotToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem SnapshotTagsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripMenuItem RefreshSnapshotsToolStripMenuItem;        

    }


}