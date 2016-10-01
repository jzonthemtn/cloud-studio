using CloudStudio.GUI.Controls;
namespace CloudStudio.GUI.Forms {
    partial class PreferencesForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreferencesForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.InstancesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ValidateButton = new System.Windows.Forms.Button();
            this.RemoveFavoriteAMIButton = new System.Windows.Forms.Button();
            this.AddFavoriteAMIButton = new System.Windows.Forms.Button();
            this.FavoriteAMIsListView = new CloudStudio.GUI.Controls.SortableListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.CloudAccountsComboBox = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 59);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(420, 324);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(412, 298);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Instances";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.InstancesCheckedListBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(17, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 174);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Display";
            // 
            // InstancesCheckedListBox
            // 
            this.InstancesCheckedListBox.FormattingEnabled = true;
            this.InstancesCheckedListBox.Items.AddRange(new object[] {
            "AMI",
            "Architecture",
            "Instance ID",
            "Instance Name",
            "Kernel ID",
            "Key Name",
            "Private IP (When available)",
            "Public DNS Name",
            "Public IP (When available)",
            "Subnet ID"});
            this.InstancesCheckedListBox.Location = new System.Drawing.Point(22, 44);
            this.InstancesCheckedListBox.Name = "InstancesCheckedListBox";
            this.InstancesCheckedListBox.Size = new System.Drawing.Size(325, 94);
            this.InstancesCheckedListBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Display these fields for instances:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ValidateButton);
            this.tabPage2.Controls.Add(this.RemoveFavoriteAMIButton);
            this.tabPage2.Controls.Add(this.AddFavoriteAMIButton);
            this.tabPage2.Controls.Add(this.FavoriteAMIsListView);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(412, 298);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Favorited AMIs";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ValidateButton
            // 
            this.ValidateButton.Location = new System.Drawing.Point(325, 257);
            this.ValidateButton.Name = "ValidateButton";
            this.ValidateButton.Size = new System.Drawing.Size(75, 23);
            this.ValidateButton.TabIndex = 15;
            this.ValidateButton.Text = "Validate";
            this.ValidateButton.UseVisualStyleBackColor = true;
            this.ValidateButton.Click += new System.EventHandler(this.ValidateButton_Click);
            // 
            // RemoveFavoriteAMIButton
            // 
            this.RemoveFavoriteAMIButton.Enabled = false;
            this.RemoveFavoriteAMIButton.Location = new System.Drawing.Point(99, 257);
            this.RemoveFavoriteAMIButton.Name = "RemoveFavoriteAMIButton";
            this.RemoveFavoriteAMIButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveFavoriteAMIButton.TabIndex = 14;
            this.RemoveFavoriteAMIButton.Text = "Remove";
            this.RemoveFavoriteAMIButton.UseVisualStyleBackColor = true;
            // 
            // AddFavoriteAMIButton
            // 
            this.AddFavoriteAMIButton.Location = new System.Drawing.Point(18, 257);
            this.AddFavoriteAMIButton.Name = "AddFavoriteAMIButton";
            this.AddFavoriteAMIButton.Size = new System.Drawing.Size(75, 23);
            this.AddFavoriteAMIButton.TabIndex = 13;
            this.AddFavoriteAMIButton.Text = "Add...";
            this.AddFavoriteAMIButton.UseVisualStyleBackColor = true;
            this.AddFavoriteAMIButton.Click += new System.EventHandler(this.AddFavoriteAMIButton_Click);
            // 
            // FavoriteAMIsListView
            // 
            this.FavoriteAMIsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5});
            this.FavoriteAMIsListView.FullRowSelect = true;
            this.FavoriteAMIsListView.Location = new System.Drawing.Point(18, 33);
            this.FavoriteAMIsListView.Name = "FavoriteAMIsListView";
            this.FavoriteAMIsListView.Size = new System.Drawing.Size(382, 218);
            this.FavoriteAMIsListView.TabIndex = 11;
            this.FavoriteAMIsListView.UseCompatibleStateImageBehavior = false;
            this.FavoriteAMIsListView.View = System.Windows.Forms.View.Details;
            this.FavoriteAMIsListView.SelectedIndexChanged += new System.EventHandler(this.FavoriteAMIsListView_SelectedIndexChanged);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "AMI";
            this.columnHeader5.Width = 219;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Favorite AMIs";
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(276, 400);
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
            this.buttonCancel.Location = new System.Drawing.Point(357, 400);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Apply changes to cloud account:";
            // 
            // CloudAccountsComboBox
            // 
            this.CloudAccountsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CloudAccountsComboBox.FormattingEnabled = true;
            this.CloudAccountsComboBox.Location = new System.Drawing.Point(182, 15);
            this.CloudAccountsComboBox.Name = "CloudAccountsComboBox";
            this.CloudAccountsComboBox.Size = new System.Drawing.Size(250, 21);
            this.CloudAccountsComboBox.TabIndex = 6;
            // 
            // PreferencesForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(444, 437);
            this.Controls.Add(this.CloudAccountsComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PreferencesForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preferences";
            this.Load += new System.EventHandler(this.PreferencesForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox InstancesCheckedListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CloudAccountsComboBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button RemoveFavoriteAMIButton;
        private System.Windows.Forms.Button AddFavoriteAMIButton;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ValidateButton;
        private SortableListView FavoriteAMIsListView;
    }
}