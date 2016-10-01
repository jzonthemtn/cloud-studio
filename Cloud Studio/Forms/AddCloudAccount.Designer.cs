using CloudStudio.GUI.Controls;
namespace CloudStudio.GUI.Forms {
    partial class AddCloudAccount {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCloudAccount));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ReadOnlyModeCheckBox = new System.Windows.Forms.CheckBox();
            this.AddCustomEndpointLinkLabel = new HoverLinkLabel();
            this.CustomComboBox = new System.Windows.Forms.ComboBox();
            this.CustomRegionsRadioButton = new System.Windows.Forms.RadioButton();
            this.AWSRegionsRadioButton = new System.Windows.Forms.RadioButton();
            this.RegionsComboBox = new System.Windows.Forms.ComboBox();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.SecretKeyTextBox = new System.Windows.Forms.TextBox();
            this.AccessKeyTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ReadOnlyModeCheckBox);
            this.groupBox1.Controls.Add(this.AddCustomEndpointLinkLabel);
            this.groupBox1.Controls.Add(this.CustomComboBox);
            this.groupBox1.Controls.Add(this.CustomRegionsRadioButton);
            this.groupBox1.Controls.Add(this.AWSRegionsRadioButton);
            this.groupBox1.Controls.Add(this.RegionsComboBox);
            this.groupBox1.Controls.Add(this.DescriptionTextBox);
            this.groupBox1.Controls.Add(this.DescriptionLabel);
            this.groupBox1.Controls.Add(this.SecretKeyTextBox);
            this.groupBox1.Controls.Add(this.AccessKeyTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 217);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add AWS Account";
            // 
            // ReadOnlyModeCheckBox
            // 
            this.ReadOnlyModeCheckBox.AutoSize = true;
            this.ReadOnlyModeCheckBox.Location = new System.Drawing.Point(28, 186);
            this.ReadOnlyModeCheckBox.Name = "ReadOnlyModeCheckBox";
            this.ReadOnlyModeCheckBox.Size = new System.Drawing.Size(176, 17);
            this.ReadOnlyModeCheckBox.TabIndex = 0;
            this.ReadOnlyModeCheckBox.Text = "Use account in read-only mode.";
            this.toolTip1.SetToolTip(this.ReadOnlyModeCheckBox, "When enabled, Cloud Studio will not be able to make any changes to the cloud acco" +
        "unt.");
            this.ReadOnlyModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // AddCustomEndpointLinkLabel
            // 
            this.AddCustomEndpointLinkLabel.AutoSize = true;
            this.AddCustomEndpointLinkLabel.Location = new System.Drawing.Point(234, 159);
            this.AddCustomEndpointLinkLabel.Name = "AddCustomEndpointLinkLabel";
            this.AddCustomEndpointLinkLabel.Size = new System.Drawing.Size(109, 13);
            this.AddCustomEndpointLinkLabel.TabIndex = 3;
            this.AddCustomEndpointLinkLabel.TabStop = true;
            this.AddCustomEndpointLinkLabel.Text = "Add Custom Endpoint";
            this.AddCustomEndpointLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AddCustomEndpointLinkLabel_LinkClicked);
            // 
            // CustomComboBox
            // 
            this.CustomComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CustomComboBox.Enabled = false;
            this.CustomComboBox.FormattingEnabled = true;
            this.CustomComboBox.Location = new System.Drawing.Point(132, 135);
            this.CustomComboBox.Name = "CustomComboBox";
            this.CustomComboBox.Size = new System.Drawing.Size(211, 21);
            this.CustomComboBox.TabIndex = 0;
            // 
            // CustomRegionsRadioButton
            // 
            this.CustomRegionsRadioButton.AutoSize = true;
            this.CustomRegionsRadioButton.Enabled = false;
            this.CustomRegionsRadioButton.Location = new System.Drawing.Point(28, 136);
            this.CustomRegionsRadioButton.Name = "CustomRegionsRadioButton";
            this.CustomRegionsRadioButton.Size = new System.Drawing.Size(63, 17);
            this.CustomRegionsRadioButton.TabIndex = 0;
            this.CustomRegionsRadioButton.Text = "Custom:";
            this.CustomRegionsRadioButton.UseVisualStyleBackColor = true;
            this.CustomRegionsRadioButton.CheckedChanged += new System.EventHandler(this.CustomRegionsRadioButton_CheckedChanged);
            // 
            // AWSRegionsRadioButton
            // 
            this.AWSRegionsRadioButton.AutoSize = true;
            this.AWSRegionsRadioButton.Checked = true;
            this.AWSRegionsRadioButton.Location = new System.Drawing.Point(28, 113);
            this.AWSRegionsRadioButton.Name = "AWSRegionsRadioButton";
            this.AWSRegionsRadioButton.Size = new System.Drawing.Size(98, 17);
            this.AWSRegionsRadioButton.TabIndex = 0;
            this.AWSRegionsRadioButton.TabStop = true;
            this.AWSRegionsRadioButton.Text = "AWS Regions: ";
            this.AWSRegionsRadioButton.UseVisualStyleBackColor = true;
            this.AWSRegionsRadioButton.CheckedChanged += new System.EventHandler(this.AWSRegionsRadioButton_CheckedChanged);
            // 
            // RegionsComboBox
            // 
            this.RegionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RegionsComboBox.FormattingEnabled = true;
            this.RegionsComboBox.Location = new System.Drawing.Point(132, 109);
            this.RegionsComboBox.Name = "RegionsComboBox";
            this.RegionsComboBox.Size = new System.Drawing.Size(211, 21);
            this.RegionsComboBox.TabIndex = 0;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(97, 31);
            this.DescriptionTextBox.MaxLength = 20;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(246, 20);
            this.DescriptionTextBox.TabIndex = 0;
            this.toolTip1.SetToolTip(this.DescriptionTextBox, "Description used to identify the cloud account in Cloud Studio.");
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(25, 34);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.DescriptionLabel.TabIndex = 6;
            this.DescriptionLabel.Text = "Description:";
            // 
            // SecretKeyTextBox
            // 
            this.SecretKeyTextBox.Location = new System.Drawing.Point(97, 83);
            this.SecretKeyTextBox.Name = "SecretKeyTextBox";
            this.SecretKeyTextBox.PasswordChar = '*';
            this.SecretKeyTextBox.Size = new System.Drawing.Size(246, 20);
            this.SecretKeyTextBox.TabIndex = 0;
            this.toolTip1.SetToolTip(this.SecretKeyTextBox, "The secret key for the AWS account. Leave blank to be prompted");
            // 
            // AccessKeyTextBox
            // 
            this.AccessKeyTextBox.Location = new System.Drawing.Point(97, 57);
            this.AccessKeyTextBox.Name = "AccessKeyTextBox";
            this.AccessKeyTextBox.Size = new System.Drawing.Size(246, 20);
            this.AccessKeyTextBox.TabIndex = 0;
            this.toolTip1.SetToolTip(this.AccessKeyTextBox, "The access key for the AWS account.");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Secret Key:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Access Key:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(308, 245);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Tag = "";
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(227, 245);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Tag = "";
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // AddCloudAccount
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(400, 280);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddCloudAccount";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Cloud Account";
            this.Load += new System.EventHandler(this.AddCloudAccount_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox SecretKeyTextBox;
        private System.Windows.Forms.TextBox AccessKeyTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.ComboBox RegionsComboBox;
        private System.Windows.Forms.ComboBox CustomComboBox;
        private System.Windows.Forms.RadioButton CustomRegionsRadioButton;
        private System.Windows.Forms.RadioButton AWSRegionsRadioButton;
        private HoverLinkLabel AddCustomEndpointLinkLabel;
        private System.Windows.Forms.CheckBox ReadOnlyModeCheckBox;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}