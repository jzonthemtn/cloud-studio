namespace CloudStudio.GUI.Forms
{
    partial class NewKeypairForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewKeypairForm));
            this.label1 = new System.Windows.Forms.Label();
            this.KeyFingerprintTextBox = new System.Windows.Forms.TextBox();
            this.KeyMaterialTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SaveMaterialButton = new System.Windows.Forms.Button();
            this.OutputSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Key Fingerprint:";
            // 
            // KeyFingerprintTextBox
            // 
            this.KeyFingerprintTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KeyFingerprintTextBox.Location = new System.Drawing.Point(98, 15);
            this.KeyFingerprintTextBox.Name = "KeyFingerprintTextBox";
            this.KeyFingerprintTextBox.ReadOnly = true;
            this.KeyFingerprintTextBox.Size = new System.Drawing.Size(318, 20);
            this.KeyFingerprintTextBox.TabIndex = 1;
            // 
            // KeyMaterialTextBox
            // 
            this.KeyMaterialTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KeyMaterialTextBox.Location = new System.Drawing.Point(98, 41);
            this.KeyMaterialTextBox.Multiline = true;
            this.KeyMaterialTextBox.Name = "KeyMaterialTextBox";
            this.KeyMaterialTextBox.ReadOnly = true;
            this.KeyMaterialTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.KeyMaterialTextBox.Size = new System.Drawing.Size(318, 178);
            this.KeyMaterialTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Key Material";
            // 
            // SaveMaterialButton
            // 
            this.SaveMaterialButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveMaterialButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveMaterialButton.Image")));
            this.SaveMaterialButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveMaterialButton.Location = new System.Drawing.Point(98, 225);
            this.SaveMaterialButton.Name = "SaveMaterialButton";
            this.SaveMaterialButton.Size = new System.Drawing.Size(95, 38);
            this.SaveMaterialButton.TabIndex = 4;
            this.SaveMaterialButton.Text = "Save As...";
            this.SaveMaterialButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SaveMaterialButton.UseVisualStyleBackColor = true;
            this.SaveMaterialButton.Click += new System.EventHandler(this.SaveMaterialButton_Click);
            // 
            // OutputSaveFileDialog
            // 
            this.OutputSaveFileDialog.Filter = "PEM files|*.pem|All files|*.*";
            this.OutputSaveFileDialog.Title = "Save Key Material";
            // 
            // NewKeypairForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 275);
            this.Controls.Add(this.SaveMaterialButton);
            this.Controls.Add(this.KeyMaterialTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.KeyFingerprintTextBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewKeypairForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cloud Studio";
            this.Load += new System.EventHandler(this.NewKeypairForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox KeyFingerprintTextBox;
        private System.Windows.Forms.TextBox KeyMaterialTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SaveMaterialButton;
        private System.Windows.Forms.SaveFileDialog OutputSaveFileDialog;
    }
}