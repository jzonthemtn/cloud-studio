namespace CloudStudio.GUI.Forms {
    partial class AddBlockDeviceForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddBlockDeviceForm));
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.DeviceComboBox = new System.Windows.Forms.ComboBox();
            this.SnapshotComboBox = new System.Windows.Forms.ComboBox();
            this.VolumeTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DeleteOnTerminationheckBox = new System.Windows.Forms.CheckBox();
            this.EncryptedCheckBox = new System.Windows.Forms.CheckBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.IOPSTextBox = new CloudStudio.GUI.Controls.NumericTextBox();
            this.SizeTextBox = new CloudStudio.GUI.Controls.NumericTextBox();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Size (GB):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Snapshot:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Device:";
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Location = new System.Drawing.Point(89, 15);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(335, 21);
            this.TypeComboBox.TabIndex = 0;
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Location = new System.Drawing.Point(12, 18);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(34, 13);
            this.TypeLabel.TabIndex = 14;
            this.TypeLabel.Text = "Type:";
            // 
            // DeviceComboBox
            // 
            this.DeviceComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DeviceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DeviceComboBox.FormattingEnabled = true;
            this.DeviceComboBox.Location = new System.Drawing.Point(89, 41);
            this.DeviceComboBox.Name = "DeviceComboBox";
            this.DeviceComboBox.Size = new System.Drawing.Size(335, 21);
            this.DeviceComboBox.TabIndex = 0;
            // 
            // SnapshotComboBox
            // 
            this.SnapshotComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SnapshotComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SnapshotComboBox.FormattingEnabled = true;
            this.SnapshotComboBox.Location = new System.Drawing.Point(89, 67);
            this.SnapshotComboBox.Name = "SnapshotComboBox";
            this.SnapshotComboBox.Size = new System.Drawing.Size(335, 21);
            this.SnapshotComboBox.TabIndex = 0;
            // 
            // VolumeTypeComboBox
            // 
            this.VolumeTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VolumeTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VolumeTypeComboBox.FormattingEnabled = true;
            this.VolumeTypeComboBox.Items.AddRange(new object[] {
            "General Purpose (SSD)",
            "Provisioned IOPS (SSD)",
            "Magnetic"});
            this.VolumeTypeComboBox.Location = new System.Drawing.Point(89, 119);
            this.VolumeTypeComboBox.Name = "VolumeTypeComboBox";
            this.VolumeTypeComboBox.Size = new System.Drawing.Size(335, 21);
            this.VolumeTypeComboBox.TabIndex = 0;
            this.VolumeTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.VolumeTypeComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Volume Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "IOPS:";
            // 
            // DeleteOnTerminationheckBox
            // 
            this.DeleteOnTerminationheckBox.AutoSize = true;
            this.DeleteOnTerminationheckBox.Location = new System.Drawing.Point(89, 205);
            this.DeleteOnTerminationheckBox.Name = "DeleteOnTerminationheckBox";
            this.DeleteOnTerminationheckBox.Size = new System.Drawing.Size(126, 17);
            this.DeleteOnTerminationheckBox.TabIndex = 0;
            this.DeleteOnTerminationheckBox.Text = "Delete on termination";
            this.DeleteOnTerminationheckBox.UseVisualStyleBackColor = true;
            // 
            // EncryptedCheckBox
            // 
            this.EncryptedCheckBox.AutoSize = true;
            this.EncryptedCheckBox.Location = new System.Drawing.Point(89, 182);
            this.EncryptedCheckBox.Name = "EncryptedCheckBox";
            this.EncryptedCheckBox.Size = new System.Drawing.Size(74, 17);
            this.EncryptedCheckBox.TabIndex = 0;
            this.EncryptedCheckBox.Text = "Encrypted";
            this.EncryptedCheckBox.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(268, 267);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Tag = "";
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(349, 267);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Tag = "";
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // IOPSTextBox
            // 
            this.IOPSTextBox.AllowSpace = false;
            this.IOPSTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IOPSTextBox.Location = new System.Drawing.Point(89, 146);
            this.IOPSTextBox.MaxLength = 10;
            this.IOPSTextBox.Name = "IOPSTextBox";
            this.IOPSTextBox.ReadOnly = true;
            this.IOPSTextBox.Size = new System.Drawing.Size(335, 20);
            this.IOPSTextBox.TabIndex = 0;
            this.IOPSTextBox.Text = "30 / 3000";
            // 
            // SizeTextBox
            // 
            this.SizeTextBox.AllowSpace = false;
            this.SizeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SizeTextBox.Location = new System.Drawing.Point(89, 94);
            this.SizeTextBox.MaxLength = 8;
            this.SizeTextBox.Name = "SizeTextBox";
            this.SizeTextBox.Size = new System.Drawing.Size(335, 20);
            this.SizeTextBox.TabIndex = 0;
            this.SizeTextBox.Text = "8";
            // 
            // AddBlockDeviceForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(443, 306);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.EncryptedCheckBox);
            this.Controls.Add(this.DeleteOnTerminationheckBox);
            this.Controls.Add(this.IOPSTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.VolumeTypeComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SnapshotComboBox);
            this.Controls.Add(this.DeviceComboBox);
            this.Controls.Add(this.SizeTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TypeComboBox);
            this.Controls.Add(this.TypeLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddBlockDeviceForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Block Device";
            this.Load += new System.EventHandler(this.AddBlockDeviceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CloudStudio.GUI.Controls.NumericTextBox SizeTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox TypeComboBox;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.ComboBox DeviceComboBox;
        private System.Windows.Forms.ComboBox SnapshotComboBox;
        private System.Windows.Forms.ComboBox VolumeTypeComboBox;
        private System.Windows.Forms.Label label1;
        private CloudStudio.GUI.Controls.NumericTextBox IOPSTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox DeleteOnTerminationheckBox;
        private System.Windows.Forms.CheckBox EncryptedCheckBox;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
    }
}