namespace CloudStudio.GUI.Forms {
    partial class RegisterImageForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterImageForm));
            this.label1 = new System.Windows.Forms.Label();
            this.ArchitectureComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.SnapshotTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LocationTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.KernelIDTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.RootDeviceTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.RamDiskIDTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.VirtualizationTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SriovCheckBox = new System.Windows.Forms.CheckBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.BlockDeviceMappingsSortableListView = new CloudStudio.GUI.Controls.SortableListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Architecture:";
            // 
            // ArchitectureComboBox
            // 
            this.ArchitectureComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ArchitectureComboBox.FormattingEnabled = true;
            this.ArchitectureComboBox.Items.AddRange(new object[] {
            "I386",
            "X86_64"});
            this.ArchitectureComboBox.Location = new System.Drawing.Point(101, 104);
            this.ArchitectureComboBox.Name = "ArchitectureComboBox";
            this.ArchitectureComboBox.Size = new System.Drawing.Size(121, 21);
            this.ArchitectureComboBox.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Description:";
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(101, 78);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(221, 20);
            this.DescriptionTextBox.TabIndex = 0;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(101, 52);
            this.NameTextBox.MaxLength = 128;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(221, 20);
            this.NameTextBox.TabIndex = 0;
            // 
            // SnapshotTextBox
            // 
            this.SnapshotTextBox.Location = new System.Drawing.Point(101, 26);
            this.SnapshotTextBox.Name = "SnapshotTextBox";
            this.SnapshotTextBox.ReadOnly = true;
            this.SnapshotTextBox.Size = new System.Drawing.Size(221, 20);
            this.SnapshotTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Snapshot:";
            // 
            // LocationTextBox
            // 
            this.LocationTextBox.Location = new System.Drawing.Point(101, 131);
            this.LocationTextBox.Name = "LocationTextBox";
            this.LocationTextBox.Size = new System.Drawing.Size(221, 20);
            this.LocationTextBox.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Location:";
            // 
            // KernelIDTextBox
            // 
            this.KernelIDTextBox.Location = new System.Drawing.Point(101, 157);
            this.KernelIDTextBox.Name = "KernelIDTextBox";
            this.KernelIDTextBox.Size = new System.Drawing.Size(221, 20);
            this.KernelIDTextBox.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Kernel ID:";
            // 
            // RootDeviceTextBox
            // 
            this.RootDeviceTextBox.Location = new System.Drawing.Point(101, 209);
            this.RootDeviceTextBox.Name = "RootDeviceTextBox";
            this.RootDeviceTextBox.Size = new System.Drawing.Size(221, 20);
            this.RootDeviceTextBox.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Root Device:";
            // 
            // RamDiskIDTextBox
            // 
            this.RamDiskIDTextBox.Location = new System.Drawing.Point(101, 183);
            this.RamDiskIDTextBox.Name = "RamDiskIDTextBox";
            this.RamDiskIDTextBox.Size = new System.Drawing.Size(221, 20);
            this.RamDiskIDTextBox.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 186);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Ramdisk ID:";
            // 
            // VirtualizationTypeComboBox
            // 
            this.VirtualizationTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VirtualizationTypeComboBox.FormattingEnabled = true;
            this.VirtualizationTypeComboBox.Items.AddRange(new object[] {
            "HVM",
            "Paravirtual"});
            this.VirtualizationTypeComboBox.Location = new System.Drawing.Point(101, 235);
            this.VirtualizationTypeComboBox.Name = "VirtualizationTypeComboBox";
            this.VirtualizationTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.VirtualizationTypeComboBox.TabIndex = 0;
            this.VirtualizationTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.VirtualizationTypeComboBox_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 238);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Type:";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(166, 468);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(247, 468);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // SriovCheckBox
            // 
            this.SriovCheckBox.AutoSize = true;
            this.SriovCheckBox.Enabled = false;
            this.SriovCheckBox.Location = new System.Drawing.Point(101, 265);
            this.SriovCheckBox.Name = "SriovCheckBox";
            this.SriovCheckBox.Size = new System.Drawing.Size(147, 17);
            this.SriovCheckBox.TabIndex = 0;
            this.SriovCheckBox.Text = "Sriov Networking Support";
            this.SriovCheckBox.UseVisualStyleBackColor = true;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(31, 419);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(112, 419);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveButton.TabIndex = 0;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            // 
            // BlockDeviceMappingsSortableListView
            // 
            this.BlockDeviceMappingsSortableListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.BlockDeviceMappingsSortableListView.FullRowSelect = true;
            this.BlockDeviceMappingsSortableListView.Location = new System.Drawing.Point(31, 300);
            this.BlockDeviceMappingsSortableListView.Name = "BlockDeviceMappingsSortableListView";
            this.BlockDeviceMappingsSortableListView.Size = new System.Drawing.Size(291, 113);
            this.BlockDeviceMappingsSortableListView.TabIndex = 0;
            this.BlockDeviceMappingsSortableListView.UseCompatibleStateImageBehavior = false;
            this.BlockDeviceMappingsSortableListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Type";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Device";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Snapshot";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Size";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Volume Type";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "IOPS";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Delete on Termination";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Encrypted";
            // 
            // RegisterImageForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(348, 503);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.BlockDeviceMappingsSortableListView);
            this.Controls.Add(this.SriovCheckBox);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.VirtualizationTypeComboBox);
            this.Controls.Add(this.RootDeviceTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.RamDiskIDTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.KernelIDTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LocationTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SnapshotTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ArchitectureComboBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegisterImageForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register Image";
            this.Load += new System.EventHandler(this.RegisterImageForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ArchitectureComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox SnapshotTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox LocationTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox KernelIDTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox RootDeviceTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox RamDiskIDTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox VirtualizationTypeComboBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox SriovCheckBox;
        private Controls.SortableListView BlockDeviceMappingsSortableListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button RemoveButton;
    }
}