using CloudStudio.GUI.Controls;
namespace CloudStudio.GUI.Forms {
    partial class LaunchInstanceForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaunchInstanceForm));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ManageKeysLinkLabel = new HoverLinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.AmiTextBox = new System.Windows.Forms.TextBox();
            this.InstancesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.VpcsSubnetsComboBox = new System.Windows.Forms.ComboBox();
            this.CreateNewSecurityGroupLinkLabel = new HoverLinkLabel();
            this.SecurityGroupsListView = new CloudStudio.GUI.Controls.SortableListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.ImagesListView = new CloudStudio.GUI.Controls.SortableListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.KeyNameComboBox = new System.Windows.Forms.ComboBox();
            this.InstanceTypesComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InstancesNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "guest-26.png");
            this.imageList1.Images.SetKeyName(1, "monitor-26.png");
            this.imageList1.Images.SetKeyName(2, "firewall-26.png");
            this.imageList1.Images.SetKeyName(3, "star-26.png");
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(328, 512);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(409, 512);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(472, 494);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ManageKeysLinkLabel);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.AmiTextBox);
            this.tabPage1.Controls.Add(this.InstancesNumericUpDown);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.VpcsSubnetsComboBox);
            this.tabPage1.Controls.Add(this.CreateNewSecurityGroupLinkLabel);
            this.tabPage1.Controls.Add(this.SecurityGroupsListView);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.ImagesListView);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.KeyNameComboBox);
            this.tabPage1.Controls.Add(this.InstanceTypesComboBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(464, 468);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "On-Demand Instance(s)";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ManageKeysLinkLabel
            // 
            this.ManageKeysLinkLabel.AutoSize = true;
            this.ManageKeysLinkLabel.Location = new System.Drawing.Point(371, 53);
            this.ManageKeysLinkLabel.Name = "ManageKeysLinkLabel";
            this.ManageKeysLinkLabel.Size = new System.Drawing.Size(72, 13);
            this.ManageKeysLinkLabel.TabIndex = 28;
            this.ManageKeysLinkLabel.TabStop = true;
            this.ManageKeysLinkLabel.Text = "Manage Keys";
            this.ManageKeysLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ManageKeysLinkLabel_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(107, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "AMI:";
            // 
            // AmiTextBox
            // 
            this.AmiTextBox.Location = new System.Drawing.Point(142, 198);
            this.AmiTextBox.Name = "AmiTextBox";
            this.AmiTextBox.Size = new System.Drawing.Size(142, 20);
            this.AmiTextBox.TabIndex = 6;
            // 
            // InstancesNumericUpDown
            // 
            this.InstancesNumericUpDown.Location = new System.Drawing.Point(136, 427);
            this.InstancesNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.InstancesNumericUpDown.Name = "InstancesNumericUpDown";
            this.InstancesNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.InstancesNumericUpDown.TabIndex = 26;
            this.InstancesNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 429);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Number of Instances:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "VPC / Subnet:";
            // 
            // VpcsSubnetsComboBox
            // 
            this.VpcsSubnetsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VpcsSubnetsComboBox.FormattingEnabled = true;
            this.VpcsSubnetsComboBox.Location = new System.Drawing.Point(110, 230);
            this.VpcsSubnetsComboBox.Name = "VpcsSubnetsComboBox";
            this.VpcsSubnetsComboBox.Size = new System.Drawing.Size(333, 21);
            this.VpcsSubnetsComboBox.TabIndex = 23;
            this.VpcsSubnetsComboBox.SelectedIndexChanged += new System.EventHandler(this.VpcsSubnetsComboBox_SelectedIndexChanged);
            // 
            // CreateNewSecurityGroupLinkLabel
            // 
            this.CreateNewSecurityGroupLinkLabel.AutoSize = true;
            this.CreateNewSecurityGroupLinkLabel.Location = new System.Drawing.Point(319, 398);
            this.CreateNewSecurityGroupLinkLabel.Name = "CreateNewSecurityGroupLinkLabel";
            this.CreateNewSecurityGroupLinkLabel.Size = new System.Drawing.Size(124, 13);
            this.CreateNewSecurityGroupLinkLabel.TabIndex = 20;
            this.CreateNewSecurityGroupLinkLabel.TabStop = true;
            this.CreateNewSecurityGroupLinkLabel.Text = "Manage Security Groups";
            this.CreateNewSecurityGroupLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CreateNewSecurityGroupLinkLabel_LinkClicked);
            // 
            // SecurityGroupsListView
            // 
            this.SecurityGroupsListView.CheckBoxes = true;
            this.SecurityGroupsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.SecurityGroupsListView.FullRowSelect = true;
            this.SecurityGroupsListView.LargeImageList = this.imageList1;
            this.SecurityGroupsListView.Location = new System.Drawing.Point(110, 283);
            this.SecurityGroupsListView.Name = "SecurityGroupsListView";
            this.SecurityGroupsListView.Size = new System.Drawing.Size(333, 112);
            this.SecurityGroupsListView.SmallImageList = this.imageList1;
            this.SecurityGroupsListView.TabIndex = 22;
            this.SecurityGroupsListView.UseCompatibleStateImageBehavior = false;
            this.SecurityGroupsListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "ID";
            this.columnHeader4.Width = 97;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Name";
            this.columnHeader5.Width = 102;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Description";
            this.columnHeader6.Width = 295;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Security Groups:";
            // 
            // ImagesListView
            // 
            this.ImagesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.ImagesListView.FullRowSelect = true;
            this.ImagesListView.LargeImageList = this.imageList1;
            this.ImagesListView.Location = new System.Drawing.Point(110, 80);
            this.ImagesListView.Name = "ImagesListView";
            this.ImagesListView.Size = new System.Drawing.Size(333, 112);
            this.ImagesListView.SmallImageList = this.imageList1;
            this.ImagesListView.TabIndex = 18;
            this.ImagesListView.UseCompatibleStateImageBehavior = false;
            this.ImagesListView.View = System.Windows.Forms.View.Details;
            this.ImagesListView.SelectedIndexChanged += new System.EventHandler(this.ImagesListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 97;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 102;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Description";
            this.columnHeader3.Width = 295;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Image (AMI):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Key Name:";
            // 
            // KeyNameComboBox
            // 
            this.KeyNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KeyNameComboBox.FormattingEnabled = true;
            this.KeyNameComboBox.Location = new System.Drawing.Point(110, 50);
            this.KeyNameComboBox.Name = "KeyNameComboBox";
            this.KeyNameComboBox.Size = new System.Drawing.Size(255, 21);
            this.KeyNameComboBox.TabIndex = 15;
            // 
            // InstanceTypesComboBox
            // 
            this.InstanceTypesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InstanceTypesComboBox.FormattingEnabled = true;
            this.InstanceTypesComboBox.Location = new System.Drawing.Point(110, 23);
            this.InstanceTypesComboBox.Name = "InstanceTypesComboBox";
            this.InstanceTypesComboBox.Size = new System.Drawing.Size(333, 21);
            this.InstanceTypesComboBox.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Type:";
            // 
            // LaunchInstanceForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(501, 547);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LaunchInstanceForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launch Instance";
            this.Load += new System.EventHandler(this.LaunchInstanceForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InstancesNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox VpcsSubnetsComboBox;
        private HoverLinkLabel CreateNewSecurityGroupLinkLabel;
        private SortableListView SecurityGroupsListView;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label label4;
        private SortableListView ImagesListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox KeyNameComboBox;
        private System.Windows.Forms.ComboBox InstanceTypesComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown InstancesNumericUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox AmiTextBox;
        private HoverLinkLabel ManageKeysLinkLabel;
    }
}