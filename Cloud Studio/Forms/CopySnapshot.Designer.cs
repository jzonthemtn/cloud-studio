namespace CloudStudio.GUI.Forms {
    partial class CopySnapshotForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CopySnapshotForm));
            this.label1 = new System.Windows.Forms.Label();
            this.SnapshotTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RegionCopyCheckBox = new System.Windows.Forms.CheckBox();
            this.DestinationRegionLabel = new System.Windows.Forms.Label();
            this.DestinationRegionComboBox = new System.Windows.Forms.ComboBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Snapshot ID:";
            // 
            // SnapshotTextBox
            // 
            this.SnapshotTextBox.Location = new System.Drawing.Point(100, 23);
            this.SnapshotTextBox.Name = "SnapshotTextBox";
            this.SnapshotTextBox.ReadOnly = true;
            this.SnapshotTextBox.Size = new System.Drawing.Size(198, 20);
            this.SnapshotTextBox.TabIndex = 0;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(100, 49);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(198, 20);
            this.DescriptionTextBox.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description:";
            // 
            // RegionCopyCheckBox
            // 
            this.RegionCopyCheckBox.AutoSize = true;
            this.RegionCopyCheckBox.Location = new System.Drawing.Point(28, 91);
            this.RegionCopyCheckBox.Name = "RegionCopyCheckBox";
            this.RegionCopyCheckBox.Size = new System.Drawing.Size(138, 17);
            this.RegionCopyCheckBox.TabIndex = 0;
            this.RegionCopyCheckBox.Text = "Copy to different region.";
            this.RegionCopyCheckBox.UseVisualStyleBackColor = true;
            this.RegionCopyCheckBox.CheckedChanged += new System.EventHandler(this.RegionCopyCheckBox_CheckedChanged);
            // 
            // DestinationRegionLabel
            // 
            this.DestinationRegionLabel.AutoSize = true;
            this.DestinationRegionLabel.Enabled = false;
            this.DestinationRegionLabel.Location = new System.Drawing.Point(25, 116);
            this.DestinationRegionLabel.Name = "DestinationRegionLabel";
            this.DestinationRegionLabel.Size = new System.Drawing.Size(100, 13);
            this.DestinationRegionLabel.TabIndex = 5;
            this.DestinationRegionLabel.Text = "Destination Region:";
            // 
            // DestinationRegionComboBox
            // 
            this.DestinationRegionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DestinationRegionComboBox.Enabled = false;
            this.DestinationRegionComboBox.FormattingEnabled = true;
            this.DestinationRegionComboBox.Location = new System.Drawing.Point(131, 114);
            this.DestinationRegionComboBox.Name = "DestinationRegionComboBox";
            this.DestinationRegionComboBox.Size = new System.Drawing.Size(167, 21);
            this.DestinationRegionComboBox.TabIndex = 0;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(142, 172);
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
            this.buttonCancel.Location = new System.Drawing.Point(223, 172);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // CopySnapshotForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(319, 214);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.DestinationRegionComboBox);
            this.Controls.Add(this.DestinationRegionLabel);
            this.Controls.Add(this.RegionCopyCheckBox);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SnapshotTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CopySnapshotForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Copy Snapshot";
            this.Load += new System.EventHandler(this.CopySnapshotForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SnapshotTextBox;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox RegionCopyCheckBox;
        private System.Windows.Forms.Label DestinationRegionLabel;
        private System.Windows.Forms.ComboBox DestinationRegionComboBox;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
    }
}