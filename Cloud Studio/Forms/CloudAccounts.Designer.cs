using CloudStudio.GUI.Classes;
using CloudStudio.GUI.Controls;
namespace CloudStudio.GUI.Forms {
    partial class CloudAccountsForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CloudAccountsForm));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.CloseButton = new System.Windows.Forms.Button();
            this.OpenButton = new System.Windows.Forms.Button();
            this.AddCloudAccountButton = new System.Windows.Forms.Button();
            this.cloudAccountsListView = new CloudStudio.GUI.Controls.SortableListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editCloudAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "cloud-26.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CloseButton);
            this.panel1.Controls.Add(this.OpenButton);
            this.panel1.Controls.Add(this.AddCloudAccountButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 241);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(465, 54);
            this.panel1.TabIndex = 1;
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(373, 19);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 4;
            this.CloseButton.Text = "Cancel";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // OpenButton
            // 
            this.OpenButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenButton.Enabled = false;
            this.OpenButton.Location = new System.Drawing.Point(292, 19);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(75, 23);
            this.OpenButton.TabIndex = 3;
            this.OpenButton.Text = "Open";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // AddCloudAccountButton
            // 
            this.AddCloudAccountButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddCloudAccountButton.Location = new System.Drawing.Point(12, 19);
            this.AddCloudAccountButton.Name = "AddCloudAccountButton";
            this.AddCloudAccountButton.Size = new System.Drawing.Size(133, 23);
            this.AddCloudAccountButton.TabIndex = 0;
            this.AddCloudAccountButton.Text = "Add AWS Account...";
            this.AddCloudAccountButton.UseVisualStyleBackColor = true;
            this.AddCloudAccountButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // cloudAccountsListView
            // 
            this.cloudAccountsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader2,
            this.columnHeader1});
            this.cloudAccountsListView.ContextMenuStrip = this.contextMenuStrip1;
            this.cloudAccountsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cloudAccountsListView.FullRowSelect = true;
            this.cloudAccountsListView.LargeImageList = this.imageList1;
            this.cloudAccountsListView.Location = new System.Drawing.Point(0, 0);
            this.cloudAccountsListView.MultiSelect = false;
            this.cloudAccountsListView.Name = "cloudAccountsListView";
            this.cloudAccountsListView.Size = new System.Drawing.Size(465, 241);
            this.cloudAccountsListView.SmallImageList = this.imageList1;
            this.cloudAccountsListView.TabIndex = 0;
            this.cloudAccountsListView.UseCompatibleStateImageBehavior = false;
            this.cloudAccountsListView.View = System.Windows.Forms.View.Details;
            this.cloudAccountsListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.cloudAccountsListView_ColumnClick);
            this.cloudAccountsListView.SelectedIndexChanged += new System.EventHandler(this.cloudAccountsListView_SelectedIndexChanged);
            this.cloudAccountsListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.cloudAccountsListView_MouseDoubleClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Description";
            this.columnHeader3.Width = 105;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Access Key";
            this.columnHeader2.Width = 170;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Region";
            this.columnHeader1.Width = 112;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editCloudAccountToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteAccountToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(165, 54);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // editCloudAccountToolStripMenuItem
            // 
            this.editCloudAccountToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editCloudAccountToolStripMenuItem.Image")));
            this.editCloudAccountToolStripMenuItem.Name = "editCloudAccountToolStripMenuItem";
            this.editCloudAccountToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.editCloudAccountToolStripMenuItem.Text = "Edit...";
            this.editCloudAccountToolStripMenuItem.Click += new System.EventHandler(this.editCloudAccountToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // deleteAccountToolStripMenuItem
            // 
            this.deleteAccountToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteAccountToolStripMenuItem.Image")));
            this.deleteAccountToolStripMenuItem.Name = "deleteAccountToolStripMenuItem";
            this.deleteAccountToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.deleteAccountToolStripMenuItem.Text = "Delete Account...";
            this.deleteAccountToolStripMenuItem.Click += new System.EventHandler(this.deleteAccountToolStripMenuItem_Click);
            // 
            // CloudAccountsForm
            // 
            this.AcceptButton = this.OpenButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(465, 295);
            this.Controls.Add(this.cloudAccountsListView);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(421, 333);
            this.Name = "CloudAccountsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cloud Accounts";
            this.Load += new System.EventHandler(this.CloudAccountsForm_Load);
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button AddCloudAccountButton;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.Button CloseButton;
        private SortableListView cloudAccountsListView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editCloudAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}