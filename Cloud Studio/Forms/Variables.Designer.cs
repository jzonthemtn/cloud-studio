namespace CloudStudio.GUI.Forms {
    partial class VariablesForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VariablesForm));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyVariableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.VariablesSortableListView = new CloudStudio.GUI.Controls.SortableListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyVariableToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(148, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // copyVariableToolStripMenuItem
            // 
            this.copyVariableToolStripMenuItem.Name = "copyVariableToolStripMenuItem";
            this.copyVariableToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.copyVariableToolStripMenuItem.Text = "Copy Variable";
            this.copyVariableToolStripMenuItem.Click += new System.EventHandler(this.copyVariableToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "compare-26.png");
            // 
            // VariablesSortableListView
            // 
            this.VariablesSortableListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.VariablesSortableListView.ContextMenuStrip = this.contextMenuStrip1;
            this.VariablesSortableListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VariablesSortableListView.FullRowSelect = true;
            this.VariablesSortableListView.LargeImageList = this.imageList1;
            this.VariablesSortableListView.Location = new System.Drawing.Point(0, 0);
            this.VariablesSortableListView.Name = "VariablesSortableListView";
            this.VariablesSortableListView.Size = new System.Drawing.Size(420, 248);
            this.VariablesSortableListView.SmallImageList = this.imageList1;
            this.VariablesSortableListView.TabIndex = 0;
            this.VariablesSortableListView.UseCompatibleStateImageBehavior = false;
            this.VariablesSortableListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Variable";
            this.columnHeader1.Width = 125;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Replaced With";
            this.columnHeader2.Width = 250;
            // 
            // VariablesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 248);
            this.Controls.Add(this.VariablesSortableListView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VariablesForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Variables";
            this.Load += new System.EventHandler(this.VariablesForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.SortableListView VariablesSortableListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyVariableToolStripMenuItem;

    }
}