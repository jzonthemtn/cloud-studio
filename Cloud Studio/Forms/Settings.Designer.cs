using CloudStudio.GUI.Controls;
namespace CloudStudio.GUI.Forms {
    partial class SettingsForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.ShowWelcomeCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.InstanceNameCheckBox = new System.Windows.Forms.CheckBox();
            this.PrivateDNSNameCheckBox = new System.Windows.Forms.CheckBox();
            this.PrivateIPCheckBox = new System.Windows.Forms.CheckBox();
            this.PublicDNSNameCheckBox = new System.Windows.Forms.CheckBox();
            this.PublicIPCheckBox = new System.Windows.Forms.CheckBox();
            this.InstanceIDCheckBox = new System.Windows.Forms.CheckBox();
            this.CheckForUpdatesCheckBox = new System.Windows.Forms.CheckBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.RemoveCustomEndpointButton = new System.Windows.Forms.Button();
            this.AddCustomEndpointButton = new System.Windows.Forms.Button();
            this.CustomEndpointsListView = new CloudStudio.GUI.Controls.SortableListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.StandardEndpointsListView = new CloudStudio.GUI.Controls.SortableListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ProxyCheckBox = new System.Windows.Forms.CheckBox();
            this.ProxyGroupBox = new System.Windows.Forms.GroupBox();
            this.ProxyPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ProxyUserNameTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ProxyPortTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ProxyHostTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TimeoutNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RDPVariablesLinkLabel = new CloudStudio.GUI.Controls.HoverLinkLabel();
            this.BrowseRDPExecutableButton = new System.Windows.Forms.Button();
            this.ExternalRDPClientParametersLabel = new System.Windows.Forms.Label();
            this.ExternalRDPClientExecutableLabel = new System.Windows.Forms.Label();
            this.ExternalRDPClientParametersTextBox = new System.Windows.Forms.TextBox();
            this.ExternalRDPClientTextBox = new System.Windows.Forms.TextBox();
            this.UseWindowsRDPClientRadioButton = new System.Windows.Forms.RadioButton();
            this.UseCustomRDPClientRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SSHVariablesLinkLabel = new CloudStudio.GUI.Controls.HoverLinkLabel();
            this.BrowseSSHExecutableButton = new System.Windows.Forms.Button();
            this.ExternalSSHParamtersLabel = new System.Windows.Forms.Label();
            this.ExternalSSHParamtersTextBox = new System.Windows.Forms.TextBox();
            this.SSHExecutableLabel = new System.Windows.Forms.Label();
            this.ExternalSSHTextBox = new System.Windows.Forms.TextBox();
            this.UseInternalSSHRadioButton = new System.Windows.Forms.RadioButton();
            this.UseCustomSSHRadioButton = new System.Windows.Forms.RadioButton();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.ProxyGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeoutNumericUpDown)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(374, 396);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.ShowWelcomeCheckBox);
            this.tabPage4.Controls.Add(this.groupBox3);
            this.tabPage4.Controls.Add(this.CheckForUpdatesCheckBox);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(366, 370);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "General";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // ShowWelcomeCheckBox
            // 
            this.ShowWelcomeCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ShowWelcomeCheckBox.AutoSize = true;
            this.ShowWelcomeCheckBox.Location = new System.Drawing.Point(19, 47);
            this.ShowWelcomeCheckBox.Name = "ShowWelcomeCheckBox";
            this.ShowWelcomeCheckBox.Size = new System.Drawing.Size(157, 17);
            this.ShowWelcomeCheckBox.TabIndex = 5;
            this.ShowWelcomeCheckBox.Text = "Show the Welcome at start.";
            this.ShowWelcomeCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.InstanceNameCheckBox);
            this.groupBox3.Controls.Add(this.PrivateDNSNameCheckBox);
            this.groupBox3.Controls.Add(this.PrivateIPCheckBox);
            this.groupBox3.Controls.Add(this.PublicDNSNameCheckBox);
            this.groupBox3.Controls.Add(this.PublicIPCheckBox);
            this.groupBox3.Controls.Add(this.InstanceIDCheckBox);
            this.groupBox3.Location = new System.Drawing.Point(19, 84);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(325, 212);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Instance Fields Display";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(177, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Select fields to display for instances.";
            // 
            // InstanceNameCheckBox
            // 
            this.InstanceNameCheckBox.AutoSize = true;
            this.InstanceNameCheckBox.Location = new System.Drawing.Point(15, 175);
            this.InstanceNameCheckBox.Name = "InstanceNameCheckBox";
            this.InstanceNameCheckBox.Size = new System.Drawing.Size(98, 17);
            this.InstanceNameCheckBox.TabIndex = 10;
            this.InstanceNameCheckBox.Text = "Instance Name";
            this.InstanceNameCheckBox.UseVisualStyleBackColor = true;
            // 
            // PrivateDNSNameCheckBox
            // 
            this.PrivateDNSNameCheckBox.AutoSize = true;
            this.PrivateDNSNameCheckBox.Location = new System.Drawing.Point(15, 152);
            this.PrivateDNSNameCheckBox.Name = "PrivateDNSNameCheckBox";
            this.PrivateDNSNameCheckBox.Size = new System.Drawing.Size(116, 17);
            this.PrivateDNSNameCheckBox.TabIndex = 9;
            this.PrivateDNSNameCheckBox.Text = "Private DNS Name";
            this.PrivateDNSNameCheckBox.UseVisualStyleBackColor = true;
            // 
            // PrivateIPCheckBox
            // 
            this.PrivateIPCheckBox.AutoSize = true;
            this.PrivateIPCheckBox.Location = new System.Drawing.Point(15, 129);
            this.PrivateIPCheckBox.Name = "PrivateIPCheckBox";
            this.PrivateIPCheckBox.Size = new System.Drawing.Size(72, 17);
            this.PrivateIPCheckBox.TabIndex = 8;
            this.PrivateIPCheckBox.Text = "Private IP";
            this.PrivateIPCheckBox.UseVisualStyleBackColor = true;
            // 
            // PublicDNSNameCheckBox
            // 
            this.PublicDNSNameCheckBox.AutoSize = true;
            this.PublicDNSNameCheckBox.Location = new System.Drawing.Point(15, 106);
            this.PublicDNSNameCheckBox.Name = "PublicDNSNameCheckBox";
            this.PublicDNSNameCheckBox.Size = new System.Drawing.Size(112, 17);
            this.PublicDNSNameCheckBox.TabIndex = 7;
            this.PublicDNSNameCheckBox.Text = "Public DNS Name";
            this.PublicDNSNameCheckBox.UseVisualStyleBackColor = true;
            // 
            // PublicIPCheckBox
            // 
            this.PublicIPCheckBox.AutoSize = true;
            this.PublicIPCheckBox.Location = new System.Drawing.Point(15, 83);
            this.PublicIPCheckBox.Name = "PublicIPCheckBox";
            this.PublicIPCheckBox.Size = new System.Drawing.Size(68, 17);
            this.PublicIPCheckBox.TabIndex = 6;
            this.PublicIPCheckBox.Text = "Public IP";
            this.PublicIPCheckBox.UseVisualStyleBackColor = true;
            // 
            // InstanceIDCheckBox
            // 
            this.InstanceIDCheckBox.AutoSize = true;
            this.InstanceIDCheckBox.Location = new System.Drawing.Point(15, 60);
            this.InstanceIDCheckBox.Name = "InstanceIDCheckBox";
            this.InstanceIDCheckBox.Size = new System.Drawing.Size(81, 17);
            this.InstanceIDCheckBox.TabIndex = 5;
            this.InstanceIDCheckBox.Text = "Instance ID";
            this.InstanceIDCheckBox.UseVisualStyleBackColor = true;
            // 
            // CheckForUpdatesCheckBox
            // 
            this.CheckForUpdatesCheckBox.AutoSize = true;
            this.CheckForUpdatesCheckBox.Location = new System.Drawing.Point(19, 24);
            this.CheckForUpdatesCheckBox.Name = "CheckForUpdatesCheckBox";
            this.CheckForUpdatesCheckBox.Size = new System.Drawing.Size(226, 17);
            this.CheckForUpdatesCheckBox.TabIndex = 0;
            this.CheckForUpdatesCheckBox.Text = "Check for Cloud Studio updates at startup.";
            this.CheckForUpdatesCheckBox.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.RemoveCustomEndpointButton);
            this.tabPage1.Controls.Add(this.AddCustomEndpointButton);
            this.tabPage1.Controls.Add(this.CustomEndpointsListView);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.StandardEndpointsListView);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(366, 370);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "AWS Region Endpoints";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // RemoveCustomEndpointButton
            // 
            this.RemoveCustomEndpointButton.Enabled = false;
            this.RemoveCustomEndpointButton.Location = new System.Drawing.Point(101, 299);
            this.RemoveCustomEndpointButton.Name = "RemoveCustomEndpointButton";
            this.RemoveCustomEndpointButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveCustomEndpointButton.TabIndex = 8;
            this.RemoveCustomEndpointButton.Text = "Remove";
            this.RemoveCustomEndpointButton.UseVisualStyleBackColor = true;
            this.RemoveCustomEndpointButton.Click += new System.EventHandler(this.RemoveCustomEndpointButton_Click);
            // 
            // AddCustomEndpointButton
            // 
            this.AddCustomEndpointButton.Location = new System.Drawing.Point(20, 299);
            this.AddCustomEndpointButton.Name = "AddCustomEndpointButton";
            this.AddCustomEndpointButton.Size = new System.Drawing.Size(75, 23);
            this.AddCustomEndpointButton.TabIndex = 5;
            this.AddCustomEndpointButton.Text = "Add...";
            this.AddCustomEndpointButton.UseVisualStyleBackColor = true;
            this.AddCustomEndpointButton.Click += new System.EventHandler(this.AddCustomEndpointButton_Click);
            // 
            // CustomEndpointsListView
            // 
            this.CustomEndpointsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.CustomEndpointsListView.FullRowSelect = true;
            this.CustomEndpointsListView.Location = new System.Drawing.Point(20, 181);
            this.CustomEndpointsListView.Name = "CustomEndpointsListView";
            this.CustomEndpointsListView.Size = new System.Drawing.Size(326, 112);
            this.CustomEndpointsListView.TabIndex = 7;
            this.CustomEndpointsListView.UseCompatibleStateImageBehavior = false;
            this.CustomEndpointsListView.View = System.Windows.Forms.View.Details;
            this.CustomEndpointsListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.CustomEndpointsListView_ColumnClick);
            this.CustomEndpointsListView.SelectedIndexChanged += new System.EventHandler(this.CustomEndpointsListView_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 132;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Endpoint";
            this.columnHeader4.Width = 174;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Custom Endpoints:";
            // 
            // StandardEndpointsListView
            // 
            this.StandardEndpointsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.StandardEndpointsListView.FullRowSelect = true;
            this.StandardEndpointsListView.Location = new System.Drawing.Point(20, 35);
            this.StandardEndpointsListView.Name = "StandardEndpointsListView";
            this.StandardEndpointsListView.Size = new System.Drawing.Size(326, 112);
            this.StandardEndpointsListView.TabIndex = 5;
            this.StandardEndpointsListView.UseCompatibleStateImageBehavior = false;
            this.StandardEndpointsListView.View = System.Windows.Forms.View.Details;
            this.StandardEndpointsListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.StandardEndpointsListView_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Region";
            this.columnHeader1.Width = 132;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 174;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Standard Region Endpoints:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ProxyCheckBox);
            this.tabPage2.Controls.Add(this.ProxyGroupBox);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.TimeoutNumericUpDown);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(366, 370);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Network";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ProxyCheckBox
            // 
            this.ProxyCheckBox.AutoSize = true;
            this.ProxyCheckBox.Location = new System.Drawing.Point(20, 60);
            this.ProxyCheckBox.Name = "ProxyCheckBox";
            this.ProxyCheckBox.Size = new System.Drawing.Size(85, 17);
            this.ProxyCheckBox.TabIndex = 5;
            this.ProxyCheckBox.Text = "Use a proxy.";
            this.ProxyCheckBox.UseVisualStyleBackColor = true;
            this.ProxyCheckBox.CheckedChanged += new System.EventHandler(this.ProxyCheckBox_CheckedChanged);
            // 
            // ProxyGroupBox
            // 
            this.ProxyGroupBox.Controls.Add(this.ProxyPasswordTextBox);
            this.ProxyGroupBox.Controls.Add(this.label7);
            this.ProxyGroupBox.Controls.Add(this.ProxyUserNameTextBox);
            this.ProxyGroupBox.Controls.Add(this.label8);
            this.ProxyGroupBox.Controls.Add(this.ProxyPortTextBox);
            this.ProxyGroupBox.Controls.Add(this.label6);
            this.ProxyGroupBox.Controls.Add(this.ProxyHostTextBox);
            this.ProxyGroupBox.Controls.Add(this.label5);
            this.ProxyGroupBox.Enabled = false;
            this.ProxyGroupBox.Location = new System.Drawing.Point(20, 85);
            this.ProxyGroupBox.Name = "ProxyGroupBox";
            this.ProxyGroupBox.Size = new System.Drawing.Size(328, 170);
            this.ProxyGroupBox.TabIndex = 4;
            this.ProxyGroupBox.TabStop = false;
            this.ProxyGroupBox.Text = "Proxy";
            // 
            // ProxyPasswordTextBox
            // 
            this.ProxyPasswordTextBox.Location = new System.Drawing.Point(93, 105);
            this.ProxyPasswordTextBox.MaxLength = 5;
            this.ProxyPasswordTextBox.Name = "ProxyPasswordTextBox";
            this.ProxyPasswordTextBox.PasswordChar = '*';
            this.ProxyPasswordTextBox.Size = new System.Drawing.Size(212, 20);
            this.ProxyPasswordTextBox.TabIndex = 10;
            this.ProxyPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Password:";
            // 
            // ProxyUserNameTextBox
            // 
            this.ProxyUserNameTextBox.Location = new System.Drawing.Point(93, 79);
            this.ProxyUserNameTextBox.MaxLength = 250;
            this.ProxyUserNameTextBox.Name = "ProxyUserNameTextBox";
            this.ProxyUserNameTextBox.Size = new System.Drawing.Size(212, 20);
            this.ProxyUserNameTextBox.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "User Name:";
            // 
            // ProxyPortTextBox
            // 
            this.ProxyPortTextBox.Location = new System.Drawing.Point(93, 53);
            this.ProxyPortTextBox.MaxLength = 5;
            this.ProxyPortTextBox.Name = "ProxyPortTextBox";
            this.ProxyPortTextBox.Size = new System.Drawing.Size(212, 20);
            this.ProxyPortTextBox.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Proxy Port:";
            // 
            // ProxyHostTextBox
            // 
            this.ProxyHostTextBox.Location = new System.Drawing.Point(93, 27);
            this.ProxyHostTextBox.MaxLength = 250;
            this.ProxyHostTextBox.Name = "ProxyHostTextBox";
            this.ProxyHostTextBox.Size = new System.Drawing.Size(212, 20);
            this.ProxyHostTextBox.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Proxy Host:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(201, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "minutes";
            // 
            // TimeoutNumericUpDown
            // 
            this.TimeoutNumericUpDown.Location = new System.Drawing.Point(124, 17);
            this.TimeoutNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.TimeoutNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TimeoutNumericUpDown.Name = "TimeoutNumericUpDown";
            this.TimeoutNumericUpDown.Size = new System.Drawing.Size(70, 20);
            this.TimeoutNumericUpDown.TabIndex = 1;
            this.TimeoutNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Connection timeout:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(366, 370);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Applications";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RDPVariablesLinkLabel);
            this.groupBox2.Controls.Add(this.BrowseRDPExecutableButton);
            this.groupBox2.Controls.Add(this.ExternalRDPClientParametersLabel);
            this.groupBox2.Controls.Add(this.ExternalRDPClientExecutableLabel);
            this.groupBox2.Controls.Add(this.ExternalRDPClientParametersTextBox);
            this.groupBox2.Controls.Add(this.ExternalRDPClientTextBox);
            this.groupBox2.Controls.Add(this.UseWindowsRDPClientRadioButton);
            this.groupBox2.Controls.Add(this.UseCustomRDPClientRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(17, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(322, 159);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RDP Client";
            // 
            // RDPVariablesLinkLabel
            // 
            this.RDPVariablesLinkLabel.AutoSize = true;
            this.RDPVariablesLinkLabel.Location = new System.Drawing.Point(257, 126);
            this.RDPVariablesLinkLabel.Name = "RDPVariablesLinkLabel";
            this.RDPVariablesLinkLabel.Size = new System.Drawing.Size(50, 13);
            this.RDPVariablesLinkLabel.TabIndex = 11;
            this.RDPVariablesLinkLabel.TabStop = true;
            this.RDPVariablesLinkLabel.Text = "Variables";
            this.RDPVariablesLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RDPVariablesLinkLabel_LinkClicked);
            // 
            // BrowseRDPExecutableButton
            // 
            this.BrowseRDPExecutableButton.Location = new System.Drawing.Point(249, 75);
            this.BrowseRDPExecutableButton.Name = "BrowseRDPExecutableButton";
            this.BrowseRDPExecutableButton.Size = new System.Drawing.Size(59, 23);
            this.BrowseRDPExecutableButton.TabIndex = 10;
            this.BrowseRDPExecutableButton.Text = "Browse";
            this.BrowseRDPExecutableButton.UseVisualStyleBackColor = true;
            this.BrowseRDPExecutableButton.Click += new System.EventHandler(this.BrowseRDPExecutableButton_Click);
            // 
            // ExternalRDPClientParametersLabel
            // 
            this.ExternalRDPClientParametersLabel.AutoSize = true;
            this.ExternalRDPClientParametersLabel.Enabled = false;
            this.ExternalRDPClientParametersLabel.Location = new System.Drawing.Point(38, 106);
            this.ExternalRDPClientParametersLabel.Name = "ExternalRDPClientParametersLabel";
            this.ExternalRDPClientParametersLabel.Size = new System.Drawing.Size(63, 13);
            this.ExternalRDPClientParametersLabel.TabIndex = 10;
            this.ExternalRDPClientParametersLabel.Text = "Parameters:";
            // 
            // ExternalRDPClientExecutableLabel
            // 
            this.ExternalRDPClientExecutableLabel.AutoSize = true;
            this.ExternalRDPClientExecutableLabel.Enabled = false;
            this.ExternalRDPClientExecutableLabel.Location = new System.Drawing.Point(38, 80);
            this.ExternalRDPClientExecutableLabel.Name = "ExternalRDPClientExecutableLabel";
            this.ExternalRDPClientExecutableLabel.Size = new System.Drawing.Size(63, 13);
            this.ExternalRDPClientExecutableLabel.TabIndex = 7;
            this.ExternalRDPClientExecutableLabel.Text = "Executable:";
            // 
            // ExternalRDPClientParametersTextBox
            // 
            this.ExternalRDPClientParametersTextBox.Enabled = false;
            this.ExternalRDPClientParametersTextBox.Location = new System.Drawing.Point(107, 103);
            this.ExternalRDPClientParametersTextBox.Name = "ExternalRDPClientParametersTextBox";
            this.ExternalRDPClientParametersTextBox.Size = new System.Drawing.Size(200, 20);
            this.ExternalRDPClientParametersTextBox.TabIndex = 9;
            // 
            // ExternalRDPClientTextBox
            // 
            this.ExternalRDPClientTextBox.Enabled = false;
            this.ExternalRDPClientTextBox.Location = new System.Drawing.Point(107, 77);
            this.ExternalRDPClientTextBox.Name = "ExternalRDPClientTextBox";
            this.ExternalRDPClientTextBox.ReadOnly = true;
            this.ExternalRDPClientTextBox.Size = new System.Drawing.Size(136, 20);
            this.ExternalRDPClientTextBox.TabIndex = 5;
            // 
            // UseWindowsRDPClientRadioButton
            // 
            this.UseWindowsRDPClientRadioButton.AutoSize = true;
            this.UseWindowsRDPClientRadioButton.Checked = true;
            this.UseWindowsRDPClientRadioButton.Location = new System.Drawing.Point(19, 31);
            this.UseWindowsRDPClientRadioButton.Name = "UseWindowsRDPClientRadioButton";
            this.UseWindowsRDPClientRadioButton.Size = new System.Drawing.Size(224, 17);
            this.UseWindowsRDPClientRadioButton.TabIndex = 2;
            this.UseWindowsRDPClientRadioButton.TabStop = true;
            this.UseWindowsRDPClientRadioButton.Text = "Use Windows RDP client (recommended).";
            this.UseWindowsRDPClientRadioButton.UseVisualStyleBackColor = true;
            // 
            // UseCustomRDPClientRadioButton
            // 
            this.UseCustomRDPClientRadioButton.AutoSize = true;
            this.UseCustomRDPClientRadioButton.Location = new System.Drawing.Point(19, 54);
            this.UseCustomRDPClientRadioButton.Name = "UseCustomRDPClientRadioButton";
            this.UseCustomRDPClientRadioButton.Size = new System.Drawing.Size(138, 17);
            this.UseCustomRDPClientRadioButton.TabIndex = 3;
            this.UseCustomRDPClientRadioButton.Text = "Use custom RDP client.";
            this.UseCustomRDPClientRadioButton.UseVisualStyleBackColor = true;
            this.UseCustomRDPClientRadioButton.CheckedChanged += new System.EventHandler(this.UseCustomRDPClientRadioButton_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SSHVariablesLinkLabel);
            this.groupBox1.Controls.Add(this.BrowseSSHExecutableButton);
            this.groupBox1.Controls.Add(this.ExternalSSHParamtersLabel);
            this.groupBox1.Controls.Add(this.ExternalSSHParamtersTextBox);
            this.groupBox1.Controls.Add(this.SSHExecutableLabel);
            this.groupBox1.Controls.Add(this.ExternalSSHTextBox);
            this.groupBox1.Controls.Add(this.UseInternalSSHRadioButton);
            this.groupBox1.Controls.Add(this.UseCustomSSHRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(17, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 159);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SSH Client";
            // 
            // SSHVariablesLinkLabel
            // 
            this.SSHVariablesLinkLabel.AutoSize = true;
            this.SSHVariablesLinkLabel.Location = new System.Drawing.Point(258, 130);
            this.SSHVariablesLinkLabel.Name = "SSHVariablesLinkLabel";
            this.SSHVariablesLinkLabel.Size = new System.Drawing.Size(50, 13);
            this.SSHVariablesLinkLabel.TabIndex = 10;
            this.SSHVariablesLinkLabel.TabStop = true;
            this.SSHVariablesLinkLabel.Text = "Variables";
            this.SSHVariablesLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SSHVariablesLinkLabel_LinkClicked);
            // 
            // BrowseSSHExecutableButton
            // 
            this.BrowseSSHExecutableButton.Location = new System.Drawing.Point(248, 81);
            this.BrowseSSHExecutableButton.Name = "BrowseSSHExecutableButton";
            this.BrowseSSHExecutableButton.Size = new System.Drawing.Size(59, 23);
            this.BrowseSSHExecutableButton.TabIndex = 9;
            this.BrowseSSHExecutableButton.Text = "Browse";
            this.BrowseSSHExecutableButton.UseVisualStyleBackColor = true;
            this.BrowseSSHExecutableButton.Click += new System.EventHandler(this.BrowseSSHExecutableButton_Click);
            // 
            // ExternalSSHParamtersLabel
            // 
            this.ExternalSSHParamtersLabel.AutoSize = true;
            this.ExternalSSHParamtersLabel.Enabled = false;
            this.ExternalSSHParamtersLabel.Location = new System.Drawing.Point(38, 110);
            this.ExternalSSHParamtersLabel.Name = "ExternalSSHParamtersLabel";
            this.ExternalSSHParamtersLabel.Size = new System.Drawing.Size(63, 13);
            this.ExternalSSHParamtersLabel.TabIndex = 8;
            this.ExternalSSHParamtersLabel.Text = "Parameters:";
            // 
            // ExternalSSHParamtersTextBox
            // 
            this.ExternalSSHParamtersTextBox.Enabled = false;
            this.ExternalSSHParamtersTextBox.Location = new System.Drawing.Point(107, 107);
            this.ExternalSSHParamtersTextBox.Name = "ExternalSSHParamtersTextBox";
            this.ExternalSSHParamtersTextBox.Size = new System.Drawing.Size(200, 20);
            this.ExternalSSHParamtersTextBox.TabIndex = 7;
            // 
            // SSHExecutableLabel
            // 
            this.SSHExecutableLabel.AutoSize = true;
            this.SSHExecutableLabel.Enabled = false;
            this.SSHExecutableLabel.Location = new System.Drawing.Point(38, 84);
            this.SSHExecutableLabel.Name = "SSHExecutableLabel";
            this.SSHExecutableLabel.Size = new System.Drawing.Size(63, 13);
            this.SSHExecutableLabel.TabIndex = 6;
            this.SSHExecutableLabel.Text = "Executable:";
            // 
            // ExternalSSHTextBox
            // 
            this.ExternalSSHTextBox.Enabled = false;
            this.ExternalSSHTextBox.Location = new System.Drawing.Point(107, 81);
            this.ExternalSSHTextBox.Name = "ExternalSSHTextBox";
            this.ExternalSSHTextBox.ReadOnly = true;
            this.ExternalSSHTextBox.Size = new System.Drawing.Size(136, 20);
            this.ExternalSSHTextBox.TabIndex = 4;
            // 
            // UseInternalSSHRadioButton
            // 
            this.UseInternalSSHRadioButton.AutoSize = true;
            this.UseInternalSSHRadioButton.Checked = true;
            this.UseInternalSSHRadioButton.Location = new System.Drawing.Point(19, 31);
            this.UseInternalSSHRadioButton.Name = "UseInternalSSHRadioButton";
            this.UseInternalSSHRadioButton.Size = new System.Drawing.Size(117, 17);
            this.UseInternalSSHRadioButton.TabIndex = 2;
            this.UseInternalSSHRadioButton.TabStop = true;
            this.UseInternalSSHRadioButton.Text = "Use included Putty.";
            this.UseInternalSSHRadioButton.UseVisualStyleBackColor = true;
            // 
            // UseCustomSSHRadioButton
            // 
            this.UseCustomSSHRadioButton.AutoSize = true;
            this.UseCustomSSHRadioButton.Location = new System.Drawing.Point(19, 54);
            this.UseCustomSSHRadioButton.Name = "UseCustomSSHRadioButton";
            this.UseCustomSSHRadioButton.Size = new System.Drawing.Size(140, 17);
            this.UseCustomSSHRadioButton.TabIndex = 3;
            this.UseCustomSSHRadioButton.Text = "Use external SSH client.";
            this.UseCustomSSHRadioButton.UseVisualStyleBackColor = true;
            this.UseCustomSSHRadioButton.CheckedChanged += new System.EventHandler(this.UseCustomSSHRadioButton_CheckedChanged);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(230, 423);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(311, 423);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(398, 458);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ProxyGroupBox.ResumeLayout(false);
            this.ProxyGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeoutNumericUpDown)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddCustomEndpointButton;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button RemoveCustomEndpointButton;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown TimeoutNumericUpDown;
        private System.Windows.Forms.Label label3;
        private SortableListView StandardEndpointsListView;
        private SortableListView CustomEndpointsListView;
        private System.Windows.Forms.GroupBox ProxyGroupBox;
        private System.Windows.Forms.TextBox ProxyPortTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ProxyHostTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox ProxyCheckBox;
        private System.Windows.Forms.TextBox ProxyPasswordTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ProxyUserNameTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RadioButton UseCustomSSHRadioButton;
        private System.Windows.Forms.RadioButton UseInternalSSHRadioButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton UseWindowsRDPClientRadioButton;
        private System.Windows.Forms.RadioButton UseCustomRDPClientRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ExternalRDPClientTextBox;
        private System.Windows.Forms.TextBox ExternalSSHTextBox;
        private System.Windows.Forms.Label ExternalRDPClientExecutableLabel;
        private System.Windows.Forms.Label SSHExecutableLabel;
        private System.Windows.Forms.Label ExternalRDPClientParametersLabel;
        private System.Windows.Forms.TextBox ExternalRDPClientParametersTextBox;
        private System.Windows.Forms.Label ExternalSSHParamtersLabel;
        private System.Windows.Forms.TextBox ExternalSSHParamtersTextBox;
        private System.Windows.Forms.Button BrowseRDPExecutableButton;
        private System.Windows.Forms.Button BrowseSSHExecutableButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private HoverLinkLabel RDPVariablesLinkLabel;
        private HoverLinkLabel SSHVariablesLinkLabel;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.CheckBox CheckForUpdatesCheckBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox InstanceNameCheckBox;
        private System.Windows.Forms.CheckBox PrivateDNSNameCheckBox;
        private System.Windows.Forms.CheckBox PrivateIPCheckBox;
        private System.Windows.Forms.CheckBox PublicDNSNameCheckBox;
        private System.Windows.Forms.CheckBox PublicIPCheckBox;
        private System.Windows.Forms.CheckBox InstanceIDCheckBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox ShowWelcomeCheckBox;
    }
}