using CloudStudio.GUI.Controls;
namespace CloudStudio.GUI.Forms {
    partial class AddSecurityGroupRuleForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSecurityGroupRuleForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.UseMyIpAddressLinkLabel = new HoverLinkLabel();
            this.RangeComboBox = new System.Windows.Forms.ComboBox();
            this.ProtocolComboBox = new System.Windows.Forms.ComboBox();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            this.SourceTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GroupIDTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.UseMyIpAddressLinkLabel);
            this.groupBox1.Controls.Add(this.RangeComboBox);
            this.groupBox1.Controls.Add(this.ProtocolComboBox);
            this.groupBox1.Controls.Add(this.TypeComboBox);
            this.groupBox1.Controls.Add(this.SourceTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.GroupIDTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 206);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Security Group Rule";
            // 
            // UseMyIpAddressLinkLabel
            // 
            this.UseMyIpAddressLinkLabel.AutoSize = true;
            this.UseMyIpAddressLinkLabel.Location = new System.Drawing.Point(201, 168);
            this.UseMyIpAddressLinkLabel.Name = "UseMyIpAddressLinkLabel";
            this.UseMyIpAddressLinkLabel.Size = new System.Drawing.Size(98, 13);
            this.UseMyIpAddressLinkLabel.TabIndex = 9;
            this.UseMyIpAddressLinkLabel.TabStop = true;
            this.UseMyIpAddressLinkLabel.Text = "Use my IP address.";
            this.UseMyIpAddressLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.UseMyIpAddressLinkLabel_LinkClicked);
            // 
            // RangeComboBox
            // 
            this.RangeComboBox.FormattingEnabled = true;
            this.RangeComboBox.Items.AddRange(new object[] {
            "All"});
            this.RangeComboBox.Location = new System.Drawing.Point(78, 109);
            this.RangeComboBox.Name = "RangeComboBox";
            this.RangeComboBox.Size = new System.Drawing.Size(221, 21);
            this.RangeComboBox.TabIndex = 0;
            // 
            // ProtocolComboBox
            // 
            this.ProtocolComboBox.FormattingEnabled = true;
            this.ProtocolComboBox.Items.AddRange(new object[] {
            "All",
            "TCP",
            "UDP",
            "ICMP"});
            this.ProtocolComboBox.Location = new System.Drawing.Point(78, 83);
            this.ProtocolComboBox.Name = "ProtocolComboBox";
            this.ProtocolComboBox.Size = new System.Drawing.Size(221, 21);
            this.ProtocolComboBox.TabIndex = 0;
            this.ProtocolComboBox.SelectedIndexChanged += new System.EventHandler(this.ProtocolComboBox_SelectedIndexChanged);
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Items.AddRange(new object[] {
            "All Traffic",
            "Custom TCP Rule",
            "Custom UDP Rule",
            "Custom ICMP Rule",
            "Custom Protocol",
            "All TCP",
            "All UDP",
            "All ICMP",
            "All Traffic",
            "SSH",
            "FTP",
            "SMTP",
            "HTTP",
            "POP3",
            "IMAP",
            "HTTPS",
            "LDAP",
            "DNS",
            "SMTPS",
            "IMAPS",
            "POP3S",
            "MS SQL",
            "MYSQL",
            "RDP"});
            this.TypeComboBox.Location = new System.Drawing.Point(78, 57);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(221, 21);
            this.TypeComboBox.TabIndex = 0;
            this.TypeComboBox.SelectedIndexChanged += new System.EventHandler(this.TypeComboBox_SelectedIndexChanged);
            // 
            // SourceTextBox
            // 
            this.SourceTextBox.Location = new System.Drawing.Point(78, 136);
            this.SourceTextBox.Name = "SourceTextBox";
            this.SourceTextBox.Size = new System.Drawing.Size(221, 20);
            this.SourceTextBox.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Source:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Range:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Protocol:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Type:";
            // 
            // GroupIDTextBox
            // 
            this.GroupIDTextBox.Location = new System.Drawing.Point(78, 32);
            this.GroupIDTextBox.Name = "GroupIDTextBox";
            this.GroupIDTextBox.ReadOnly = true;
            this.GroupIDTextBox.Size = new System.Drawing.Size(221, 20);
            this.GroupIDTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Group ID:";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(188, 244);
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
            this.buttonCancel.Location = new System.Drawing.Point(269, 244);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // AddSecurityGroupRuleForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(356, 279);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddSecurityGroupRuleForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Security Group Rule";
            this.Load += new System.EventHandler(this.AddSecurityGroupRule_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox SourceTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox GroupIDTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox TypeComboBox;
        private System.Windows.Forms.ComboBox ProtocolComboBox;
        private System.Windows.Forms.ComboBox RangeComboBox;
        private HoverLinkLabel UseMyIpAddressLinkLabel;

    }
}