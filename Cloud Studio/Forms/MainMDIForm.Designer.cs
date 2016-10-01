using CloudStudio.GUI.Themes;

namespace CloudStudio.GUI
{
    partial class MainMDIForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMDIForm));
            WeifenLuo.WinFormsUI.Docking.DockPanelSkin dockPanelSkin2 = new WeifenLuo.WinFormsUI.Docking.DockPanelSkin();
            WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin autoHideStripSkin2 = new WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient4 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient8 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin dockPaneStripSkin2 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient dockPaneStripGradient2 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient9 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient5 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient10 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient2 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient11 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient12 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient6 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient13 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient14 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCloudAccounts = new System.Windows.Forms.ToolStripMenuItem();
            this.VPCsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.consoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keypairsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.legendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOutputWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPowerShellConsole = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPropertyWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSnapshots = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemToolbox = new System.Windows.Forms.ToolStripMenuItem();
            this.welcomeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.newVersionAvailableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.licenseKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.GetSupportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.vS2012LightTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2012LightTheme();
            this.vS2012ToolStripExtender1 = new VS2012ToolStripExtender(this.components);
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemView,
            this.menuItemHelp,
            this.newVersionAvailableToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(579, 24);
            this.mainMenu.TabIndex = 7;
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemCloudAccounts,
            this.VPCsToolStripMenuItem,
            this.toolStripSeparator2,
            this.toolStripMenuItem1,
            this.menuItem4,
            this.menuItemExit});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(37, 20);
            this.menuItemFile.Text = "File";
            this.menuItemFile.DropDownOpening += new System.EventHandler(this.menuItemFile_DropDownOpening);
            // 
            // menuItemCloudAccounts
            // 
            this.menuItemCloudAccounts.Image = ((System.Drawing.Image)(resources.GetObject("menuItemCloudAccounts.Image")));
            this.menuItemCloudAccounts.Name = "menuItemCloudAccounts";
            this.menuItemCloudAccounts.Size = new System.Drawing.Size(161, 22);
            this.menuItemCloudAccounts.Text = "AWS Accounts...";
            this.menuItemCloudAccounts.Click += new System.EventHandler(this.menuItemCloudAccounts_Click);
            // 
            // VPCsToolStripMenuItem
            // 
            this.VPCsToolStripMenuItem.Name = "VPCsToolStripMenuItem";
            this.VPCsToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.VPCsToolStripMenuItem.Text = "VPCs...";
            this.VPCsToolStripMenuItem.Click += new System.EventHandler(this.VPCsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(158, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(161, 22);
            this.toolStripMenuItem1.Text = "Settings...";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Name = "menuItem4";
            this.menuItem4.Size = new System.Drawing.Size(158, 6);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(161, 22);
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // menuItemView
            // 
            this.menuItemView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consoleToolStripMenuItem,
            this.keypairsToolStripMenuItem,
            this.legendToolStripMenuItem,
            this.menuItemOutputWindow,
            this.menuItemPowerShellConsole,
            this.menuItemPropertyWindow,
            this.menuItemSnapshots,
            this.menuItemToolbox,
            this.welcomeToolStripMenuItem});
            this.menuItemView.MergeIndex = 1;
            this.menuItemView.Name = "menuItemView";
            this.menuItemView.Size = new System.Drawing.Size(44, 20);
            this.menuItemView.Text = "View";
            // 
            // consoleToolStripMenuItem
            // 
            this.consoleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("consoleToolStripMenuItem.Image")));
            this.consoleToolStripMenuItem.Name = "consoleToolStripMenuItem";
            this.consoleToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.consoleToolStripMenuItem.Text = "Console";
            this.consoleToolStripMenuItem.Click += new System.EventHandler(this.consoleToolStripMenuItem_Click);
            // 
            // keypairsToolStripMenuItem
            // 
            this.keypairsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("keypairsToolStripMenuItem.Image")));
            this.keypairsToolStripMenuItem.Name = "keypairsToolStripMenuItem";
            this.keypairsToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.keypairsToolStripMenuItem.Text = "Keypairs";
            this.keypairsToolStripMenuItem.Click += new System.EventHandler(this.keypairsToolStripMenuItem_Click);
            // 
            // legendToolStripMenuItem
            // 
            this.legendToolStripMenuItem.Name = "legendToolStripMenuItem";
            this.legendToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.legendToolStripMenuItem.Text = "Legend";
            this.legendToolStripMenuItem.Click += new System.EventHandler(this.legendToolStripMenuItem_Click);
            // 
            // menuItemOutputWindow
            // 
            this.menuItemOutputWindow.Name = "menuItemOutputWindow";
            this.menuItemOutputWindow.Size = new System.Drawing.Size(178, 22);
            this.menuItemOutputWindow.Text = "Output";
            this.menuItemOutputWindow.Click += new System.EventHandler(this.menuItemOutputWindow_Click);
            // 
            // menuItemPowerShellConsole
            // 
            this.menuItemPowerShellConsole.Image = ((System.Drawing.Image)(resources.GetObject("menuItemPowerShellConsole.Image")));
            this.menuItemPowerShellConsole.Name = "menuItemPowerShellConsole";
            this.menuItemPowerShellConsole.Size = new System.Drawing.Size(178, 22);
            this.menuItemPowerShellConsole.Text = "PowerShell Console";
            this.menuItemPowerShellConsole.Click += new System.EventHandler(this.menuItemPowerShellConsole_Click);
            // 
            // menuItemPropertyWindow
            // 
            this.menuItemPropertyWindow.Image = ((System.Drawing.Image)(resources.GetObject("menuItemPropertyWindow.Image")));
            this.menuItemPropertyWindow.Name = "menuItemPropertyWindow";
            this.menuItemPropertyWindow.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.menuItemPropertyWindow.Size = new System.Drawing.Size(178, 22);
            this.menuItemPropertyWindow.Text = "Properties";
            this.menuItemPropertyWindow.Click += new System.EventHandler(this.menuItemPropertyWindow_Click);
            // 
            // menuItemSnapshots
            // 
            this.menuItemSnapshots.Image = ((System.Drawing.Image)(resources.GetObject("menuItemSnapshots.Image")));
            this.menuItemSnapshots.Name = "menuItemSnapshots";
            this.menuItemSnapshots.Size = new System.Drawing.Size(178, 22);
            this.menuItemSnapshots.Text = "Snapshots";
            this.menuItemSnapshots.Click += new System.EventHandler(this.menuItemSnapshots_Click);
            // 
            // menuItemToolbox
            // 
            this.menuItemToolbox.Name = "menuItemToolbox";
            this.menuItemToolbox.Size = new System.Drawing.Size(178, 22);
            this.menuItemToolbox.Text = "Toolbox";
            this.menuItemToolbox.Click += new System.EventHandler(this.menuItemToolbox_Click);
            // 
            // welcomeToolStripMenuItem
            // 
            this.welcomeToolStripMenuItem.Name = "welcomeToolStripMenuItem";
            this.welcomeToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.welcomeToolStripMenuItem.Text = "Welcome";
            this.welcomeToolStripMenuItem.Click += new System.EventHandler(this.welcomeToolStripMenuItem_Click);
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.toolStripSeparator1,
            this.GetSupportToolStripMenuItem,
            this.licenseKeyToolStripMenuItem,
            this.toolStripSeparator3,
            this.menuItemAbout});
            this.menuItemHelp.MergeIndex = 3;
            this.menuItemHelp.Name = "menuItemHelp";
            this.menuItemHelp.Size = new System.Drawing.Size(44, 20);
            this.menuItemHelp.Text = "Help";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripMenuItem.Image")));
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.helpToolStripMenuItem.Text = "Help...";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(185, 6);
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Name = "menuItemAbout";
            this.menuItemAbout.Size = new System.Drawing.Size(188, 22);
            this.menuItemAbout.Text = "About Cloud Studio...";
            this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
            // 
            // newVersionAvailableToolStripMenuItem
            // 
            this.newVersionAvailableToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.newVersionAvailableToolStripMenuItem.Name = "newVersionAvailableToolStripMenuItem";
            this.newVersionAvailableToolStripMenuItem.Size = new System.Drawing.Size(136, 20);
            this.newVersionAvailableToolStripMenuItem.Text = "New Version Available";
            this.newVersionAvailableToolStripMenuItem.Visible = false;
            this.newVersionAvailableToolStripMenuItem.Click += new System.EventHandler(this.newVersionAvailableToolStripMenuItem_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "");
            this.imageList.Images.SetKeyName(1, "");
            this.imageList.Images.SetKeyName(2, "");
            this.imageList.Images.SetKeyName(3, "");
            this.imageList.Images.SetKeyName(4, "");
            this.imageList.Images.SetKeyName(5, "");
            this.imageList.Images.SetKeyName(6, "");
            this.imageList.Images.SetKeyName(7, "");
            this.imageList.Images.SetKeyName(8, "");
            // 
            // licenseKeyToolStripMenuItem
            // 
            this.licenseKeyToolStripMenuItem.Name = "licenseKeyToolStripMenuItem";
            this.licenseKeyToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.licenseKeyToolStripMenuItem.Text = "License Key...";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(185, 6);
            // 
            // GetSupportToolStripMenuItem
            // 
            this.GetSupportToolStripMenuItem.Name = "GetSupportToolStripMenuItem";
            this.GetSupportToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.GetSupportToolStripMenuItem.Text = "Get Support...";
            this.GetSupportToolStripMenuItem.Click += new System.EventHandler(this.GetSupportToolStripMenuItem_Click);
            // 
            // dockPanel
            // 
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.DockBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(160)))), ((int)(((byte)(210)))));
            this.dockPanel.DockBottomPortion = 150D;
            this.dockPanel.DockLeftPortion = 200D;
            this.dockPanel.DockRightPortion = 200D;
            this.dockPanel.DockTopPortion = 150D;
            this.dockPanel.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this.dockPanel.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.dockPanel.Location = new System.Drawing.Point(0, 24);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.RightToLeftLayout = true;
            this.dockPanel.Size = new System.Drawing.Size(579, 385);
            dockPanelGradient4.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient4.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            autoHideStripSkin2.DockStripGradient = dockPanelGradient4;
            tabGradient8.EndColor = System.Drawing.SystemColors.Control;
            tabGradient8.StartColor = System.Drawing.SystemColors.Control;
            tabGradient8.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            autoHideStripSkin2.TabGradient = tabGradient8;
            autoHideStripSkin2.TextFont = new System.Drawing.Font("Segoe UI", 9F);
            dockPanelSkin2.AutoHideStripSkin = autoHideStripSkin2;
            tabGradient9.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(206)))), ((int)(((byte)(219)))));
            tabGradient9.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            tabGradient9.TextColor = System.Drawing.Color.White;
            dockPaneStripGradient2.ActiveTabGradient = tabGradient9;
            dockPanelGradient5.EndColor = System.Drawing.SystemColors.Control;
            dockPanelGradient5.StartColor = System.Drawing.SystemColors.Control;
            dockPaneStripGradient2.DockStripGradient = dockPanelGradient5;
            tabGradient10.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(151)))), ((int)(((byte)(234)))));
            tabGradient10.StartColor = System.Drawing.SystemColors.Control;
            tabGradient10.TextColor = System.Drawing.Color.Black;
            dockPaneStripGradient2.InactiveTabGradient = tabGradient10;
            dockPaneStripSkin2.DocumentGradient = dockPaneStripGradient2;
            dockPaneStripSkin2.TextFont = new System.Drawing.Font("Segoe UI", 9F);
            tabGradient11.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(170)))), ((int)(((byte)(220)))));
            tabGradient11.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient11.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            tabGradient11.TextColor = System.Drawing.Color.White;
            dockPaneStripToolWindowGradient2.ActiveCaptionGradient = tabGradient11;
            tabGradient12.EndColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient12.StartColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient12.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dockPaneStripToolWindowGradient2.ActiveTabGradient = tabGradient12;
            dockPanelGradient6.EndColor = System.Drawing.SystemColors.Control;
            dockPanelGradient6.StartColor = System.Drawing.SystemColors.Control;
            dockPaneStripToolWindowGradient2.DockStripGradient = dockPanelGradient6;
            tabGradient13.EndColor = System.Drawing.SystemColors.ControlDark;
            tabGradient13.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient13.StartColor = System.Drawing.SystemColors.Control;
            tabGradient13.TextColor = System.Drawing.SystemColors.GrayText;
            dockPaneStripToolWindowGradient2.InactiveCaptionGradient = tabGradient13;
            tabGradient14.EndColor = System.Drawing.SystemColors.Control;
            tabGradient14.StartColor = System.Drawing.SystemColors.Control;
            tabGradient14.TextColor = System.Drawing.SystemColors.GrayText;
            dockPaneStripToolWindowGradient2.InactiveTabGradient = tabGradient14;
            dockPaneStripSkin2.ToolWindowGradient = dockPaneStripToolWindowGradient2;
            dockPanelSkin2.DockPaneStripSkin = dockPaneStripSkin2;
            this.dockPanel.Skin = dockPanelSkin2;
            this.dockPanel.TabIndex = 0;
            this.dockPanel.ActiveContentChanged += new System.EventHandler(this.dockPanel_ActiveContentChanged);
            // 
            // vS2012ToolStripExtender1
            // 
            this.vS2012ToolStripExtender1.DefaultRenderer = null;
            this.vS2012ToolStripExtender1.VS2012Renderer = null;
            // 
            // MainMDIForm
            // 
            this.ClientSize = new System.Drawing.Size(579, 409);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainMDIForm";
            this.Text = "Cloud Studio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripSeparator menuItem4;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem menuItemView;
        private System.Windows.Forms.ToolStripMenuItem menuItemPropertyWindow;
        private System.Windows.Forms.ToolStripMenuItem menuItemToolbox;
        private System.Windows.Forms.ToolStripMenuItem menuItemOutputWindow;
        private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem menuItemAbout;
        private WeifenLuo.WinFormsUI.Docking.VS2012LightTheme vS2012LightTheme1;
        private VS2012ToolStripExtender vS2012ToolStripExtender1;
        private System.Windows.Forms.ToolStripMenuItem menuItemSnapshots;
        private System.Windows.Forms.ToolStripMenuItem menuItemCloudAccounts;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuItemPowerShellConsole;
        private System.Windows.Forms.ToolStripMenuItem newVersionAvailableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem legendToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem consoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem welcomeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VPCsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem keypairsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem licenseKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GetSupportToolStripMenuItem;
    }
}