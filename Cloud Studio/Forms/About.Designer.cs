using CloudStudio.GUI.Controls;
namespace CloudStudio.GUI.Forms {
    partial class AboutForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.AppTitleLabel = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.CompanyNameLabel = new System.Windows.Forms.Label();
            this.ProductLinkLabel = new CloudStudio.GUI.Controls.HoverLinkLabel();
            this.OkButton = new System.Windows.Forms.Button();
            this.IconsLinkLabel = new CloudStudio.GUI.Controls.HoverLinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.InfoTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // AppTitleLabel
            // 
            this.AppTitleLabel.AutoSize = true;
            this.AppTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppTitleLabel.Location = new System.Drawing.Point(12, 9);
            this.AppTitleLabel.Name = "AppTitleLabel";
            this.AppTitleLabel.Size = new System.Drawing.Size(147, 25);
            this.AppTitleLabel.TabIndex = 7;
            this.AppTitleLabel.Text = "Cloud Studio";
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Location = new System.Drawing.Point(14, 34);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(22, 13);
            this.VersionLabel.TabIndex = 8;
            this.VersionLabel.Text = "1.0";
            // 
            // CompanyNameLabel
            // 
            this.CompanyNameLabel.AutoSize = true;
            this.CompanyNameLabel.Location = new System.Drawing.Point(14, 61);
            this.CompanyNameLabel.Name = "CompanyNameLabel";
            this.CompanyNameLabel.Size = new System.Drawing.Size(281, 13);
            this.CompanyNameLabel.TabIndex = 9;
            this.CompanyNameLabel.Text = "Licensed under the Apache Software License, version 2.0";
            // 
            // ProductLinkLabel
            // 
            this.ProductLinkLabel.AutoSize = true;
            this.ProductLinkLabel.Location = new System.Drawing.Point(14, 79);
            this.ProductLinkLabel.Name = "ProductLinkLabel";
            this.ProductLinkLabel.Size = new System.Drawing.Size(240, 13);
            this.ProductLinkLabel.TabIndex = 10;
            this.ProductLinkLabel.TabStop = true;
            this.ProductLinkLabel.Text = "https://www.github.com/jzonthemtn/cloud-studio";
            this.ProductLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ProductLinkLabel_LinkClicked);
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.OkButton.Location = new System.Drawing.Point(270, 197);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 11;
            this.OkButton.Tag = "";
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // IconsLinkLabel
            // 
            this.IconsLinkLabel.AutoSize = true;
            this.IconsLinkLabel.Location = new System.Drawing.Point(12, 203);
            this.IconsLinkLabel.Name = "IconsLinkLabel";
            this.IconsLinkLabel.Size = new System.Drawing.Size(84, 13);
            this.IconsLinkLabel.TabIndex = 12;
            this.IconsLinkLabel.TabStop = true;
            this.IconsLinkLabel.Text = "Icons by icons8.";
            this.IconsLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.IconsLinkLabel_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Attributions";
            // 
            // InfoTextBox
            // 
            this.InfoTextBox.Location = new System.Drawing.Point(17, 108);
            this.InfoTextBox.Multiline = true;
            this.InfoTextBox.Name = "InfoTextBox";
            this.InfoTextBox.ReadOnly = true;
            this.InfoTextBox.Size = new System.Drawing.Size(328, 61);
            this.InfoTextBox.TabIndex = 14;
            // 
            // AboutForm
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.OkButton;
            this.ClientSize = new System.Drawing.Size(357, 232);
            this.Controls.Add(this.InfoTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IconsLinkLabel);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.ProductLinkLabel);
            this.Controls.Add(this.CompanyNameLabel);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.AppTitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About Cloud Studio";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AppTitleLabel;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Label CompanyNameLabel;
        private HoverLinkLabel ProductLinkLabel;
        private System.Windows.Forms.Button OkButton;
        private HoverLinkLabel IconsLinkLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InfoTextBox;
    }
}