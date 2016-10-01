using Amazon.EC2.Model;
using CloudStudio.GUI.Utils;
using CloudStudio.Services.Services;
using CloudStudio.Services.Utilities;
using CloudStudio.SharedLibrary.Services.AWSServices;
using System.Collections.Generic;
using System.Windows.Forms;
namespace CloudStudio.GUI
{
    partial class DockableKeypairsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockableKeypairsWindow));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.KeypairsSortableListView = new CloudStudio.GUI.Controls.SortableListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newKeypairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteKeypairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshKeypairsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.KeypairsSearchTextBox = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.panel2.Controls.Add(this.KeypairsSortableListView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(623, 199);
            this.panel2.TabIndex = 8;
            // 
            // KeypairsSortableListView
            // 
            this.KeypairsSortableListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.KeypairsSortableListView.ContextMenuStrip = this.contextMenuStrip1;
            this.KeypairsSortableListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KeypairsSortableListView.FullRowSelect = true;
            this.KeypairsSortableListView.LargeImageList = this.imageList1;
            this.KeypairsSortableListView.Location = new System.Drawing.Point(0, 0);
            this.KeypairsSortableListView.Name = "KeypairsSortableListView";
            this.KeypairsSortableListView.Size = new System.Drawing.Size(623, 199);
            this.KeypairsSortableListView.SmallImageList = this.imageList1;
            this.KeypairsSortableListView.StateImageList = this.imageList1;
            this.KeypairsSortableListView.TabIndex = 1;
            this.KeypairsSortableListView.UseCompatibleStateImageBehavior = false;
            this.KeypairsSortableListView.View = System.Windows.Forms.View.Details;
            this.KeypairsSortableListView.SelectedIndexChanged += new System.EventHandler(this.KeypairsSortableListView_SelectedIndexChanged);
            this.KeypairsSortableListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.KeypairsSortableListView_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Keypair Name";
            this.columnHeader1.Width = 116;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Fingerprint";
            this.columnHeader2.Width = 332;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newKeypairToolStripMenuItem,
            this.deleteKeypairToolStripMenuItem,
            this.toolStripSeparator1,
            this.refreshKeypairsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(159, 76);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // newKeypairToolStripMenuItem
            // 
            this.newKeypairToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newKeypairToolStripMenuItem.Image")));
            this.newKeypairToolStripMenuItem.Name = "newKeypairToolStripMenuItem";
            this.newKeypairToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.newKeypairToolStripMenuItem.Text = "New Keypair...";
            this.newKeypairToolStripMenuItem.Click += new System.EventHandler(this.newKeypairToolStripMenuItem_Click);
            // 
            // deleteKeypairToolStripMenuItem
            // 
            this.deleteKeypairToolStripMenuItem.Enabled = false;
            this.deleteKeypairToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteKeypairToolStripMenuItem.Image")));
            this.deleteKeypairToolStripMenuItem.Name = "deleteKeypairToolStripMenuItem";
            this.deleteKeypairToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.deleteKeypairToolStripMenuItem.Text = "Delete Keypair...";
            this.deleteKeypairToolStripMenuItem.Click += new System.EventHandler(this.deleteKeypairToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(155, 6);
            // 
            // refreshKeypairsToolStripMenuItem
            // 
            this.refreshKeypairsToolStripMenuItem.Name = "refreshKeypairsToolStripMenuItem";
            this.refreshKeypairsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.refreshKeypairsToolStripMenuItem.Text = "Refresh";
            this.refreshKeypairsToolStripMenuItem.Click += new System.EventHandler(this.refreshKeypairsToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "key_security-26.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.KeypairsSearchTextBox);
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
            // KeypairsSearchTextBox
            // 
            this.KeypairsSearchTextBox.Location = new System.Drawing.Point(50, 5);
            this.KeypairsSearchTextBox.Name = "KeypairsSearchTextBox";
            this.KeypairsSearchTextBox.Size = new System.Drawing.Size(130, 20);
            this.KeypairsSearchTextBox.TabIndex = 0;
            this.KeypairsSearchTextBox.TextChanged += new System.EventHandler(this.KeypairsSearchTextBox_TextChanged);
            // 
            // DockableKeypairsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(623, 234);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DockableKeypairsWindow";
            this.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockBottom;
            this.TabText = "Keypairs";
            this.Text = "Keypairs";
            this.Load += new System.EventHandler(this.DockableKeypairsWindow_Load);
            this.panel2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox KeypairsSearchTextBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;

        private IList<Snapshot> snapshots;

        private Controls.SortableListView KeypairsSortableListView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem deleteKeypairToolStripMenuItem;
        private ImageList imageList1;
        private ToolStripMenuItem newKeypairToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem refreshKeypairsToolStripMenuItem;        

    }


}