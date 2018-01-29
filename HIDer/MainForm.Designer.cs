namespace HIDer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.AvailableDevicesListBox = new System.Windows.Forms.ListBox();
            this.HideDeviceBtn = new System.Windows.Forms.Button();
            this.UnhideDeviceBtn = new System.Windows.Forms.Button();
            this.HiddenDevicesListBox = new System.Windows.Forms.ListBox();
            this.DeniedProcessesListBox = new System.Windows.Forms.ListBox();
            this.AllowProcessBtn = new System.Windows.Forms.Button();
            this.DenyProcessBtn = new System.Windows.Forms.Button();
            this.RefreshProcessesBtn = new System.Windows.Forms.Button();
            this.AllowedProcessesListBox = new System.Windows.Forms.ListBox();
            this.HIDerTab = new System.Windows.Forms.TabControl();
            this.DevicesTab = new System.Windows.Forms.TabPage();
            this.UnhideAllBtn = new System.Windows.Forms.Button();
            this.ProcessesTab = new System.Windows.Forms.TabPage();
            this.DenyAllProcessBtn = new System.Windows.Forms.Button();
            this.SettingsTab = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.PermenantProccessesTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.StopHidCerberusBtn = new System.Windows.Forms.Button();
            this.UninstallHidCerberusBtn = new System.Windows.Forms.Button();
            this.UninstallHidGuardianBtn = new System.Windows.Forms.Button();
            this.UninstallViGEmBtn = new System.Windows.Forms.Button();
            this.StartHidCerberusBtn = new System.Windows.Forms.Button();
            this.InstallHidCerberusBtn = new System.Windows.Forms.Button();
            this.InstallHidGuardianBtn = new System.Windows.Forms.Button();
            this.InstallViGEmBtn = new System.Windows.Forms.Button();
            this.HidCerberusLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AppNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.HiderStausMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TrayMenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.TrayMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.HIDerTab.SuspendLayout();
            this.DevicesTab.SuspendLayout();
            this.ProcessesTab.SuspendLayout();
            this.SettingsTab.SuspendLayout();
            this.HiderStausMenu.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // AvailableDevicesListBox
            // 
            this.AvailableDevicesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AvailableDevicesListBox.FormattingEnabled = true;
            this.AvailableDevicesListBox.Location = new System.Drawing.Point(6, 6);
            this.AvailableDevicesListBox.Name = "AvailableDevicesListBox";
            this.AvailableDevicesListBox.Size = new System.Drawing.Size(638, 160);
            this.AvailableDevicesListBox.Sorted = true;
            this.AvailableDevicesListBox.TabIndex = 1;
            // 
            // HideDeviceBtn
            // 
            this.HideDeviceBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HideDeviceBtn.Location = new System.Drawing.Point(650, 7);
            this.HideDeviceBtn.Name = "HideDeviceBtn";
            this.HideDeviceBtn.Size = new System.Drawing.Size(75, 159);
            this.HideDeviceBtn.TabIndex = 2;
            this.HideDeviceBtn.Text = "Hide";
            this.HideDeviceBtn.UseVisualStyleBackColor = true;
            this.HideDeviceBtn.Click += new System.EventHandler(this.HideDeviceBtn_Click);
            // 
            // UnhideDeviceBtn
            // 
            this.UnhideDeviceBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UnhideDeviceBtn.Location = new System.Drawing.Point(650, 174);
            this.UnhideDeviceBtn.Name = "UnhideDeviceBtn";
            this.UnhideDeviceBtn.Size = new System.Drawing.Size(75, 73);
            this.UnhideDeviceBtn.TabIndex = 3;
            this.UnhideDeviceBtn.Text = "Unhide";
            this.UnhideDeviceBtn.UseVisualStyleBackColor = true;
            this.UnhideDeviceBtn.Click += new System.EventHandler(this.UnhideDeviceBtn_Click);
            // 
            // HiddenDevicesListBox
            // 
            this.HiddenDevicesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HiddenDevicesListBox.FormattingEnabled = true;
            this.HiddenDevicesListBox.Location = new System.Drawing.Point(6, 174);
            this.HiddenDevicesListBox.Name = "HiddenDevicesListBox";
            this.HiddenDevicesListBox.Size = new System.Drawing.Size(638, 160);
            this.HiddenDevicesListBox.Sorted = true;
            this.HiddenDevicesListBox.TabIndex = 5;
            // 
            // DeniedProcessesListBox
            // 
            this.DeniedProcessesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DeniedProcessesListBox.FormattingEnabled = true;
            this.DeniedProcessesListBox.Location = new System.Drawing.Point(6, 6);
            this.DeniedProcessesListBox.Name = "DeniedProcessesListBox";
            this.DeniedProcessesListBox.Size = new System.Drawing.Size(316, 329);
            this.DeniedProcessesListBox.Sorted = true;
            this.DeniedProcessesListBox.TabIndex = 6;
            // 
            // AllowProcessBtn
            // 
            this.AllowProcessBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AllowProcessBtn.Location = new System.Drawing.Point(328, 6);
            this.AllowProcessBtn.Name = "AllowProcessBtn";
            this.AllowProcessBtn.Size = new System.Drawing.Size(75, 23);
            this.AllowProcessBtn.TabIndex = 7;
            this.AllowProcessBtn.Text = "Allow ->";
            this.AllowProcessBtn.UseVisualStyleBackColor = true;
            this.AllowProcessBtn.Click += new System.EventHandler(this.AllowProcessBtn_Click);
            // 
            // DenyProcessBtn
            // 
            this.DenyProcessBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DenyProcessBtn.Location = new System.Drawing.Point(328, 35);
            this.DenyProcessBtn.Name = "DenyProcessBtn";
            this.DenyProcessBtn.Size = new System.Drawing.Size(75, 23);
            this.DenyProcessBtn.TabIndex = 8;
            this.DenyProcessBtn.Text = "<- Deny";
            this.DenyProcessBtn.UseVisualStyleBackColor = true;
            this.DenyProcessBtn.Click += new System.EventHandler(this.DenyProcessBtn_Click);
            // 
            // RefreshProcessesBtn
            // 
            this.RefreshProcessesBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RefreshProcessesBtn.Location = new System.Drawing.Point(328, 93);
            this.RefreshProcessesBtn.Name = "RefreshProcessesBtn";
            this.RefreshProcessesBtn.Size = new System.Drawing.Size(75, 23);
            this.RefreshProcessesBtn.TabIndex = 9;
            this.RefreshProcessesBtn.Text = "Refresh";
            this.RefreshProcessesBtn.UseVisualStyleBackColor = true;
            this.RefreshProcessesBtn.Click += new System.EventHandler(this.RefreshProcessesBtn_Click);
            // 
            // AllowedProcessesListBox
            // 
            this.AllowedProcessesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AllowedProcessesListBox.FormattingEnabled = true;
            this.AllowedProcessesListBox.Location = new System.Drawing.Point(409, 6);
            this.AllowedProcessesListBox.Name = "AllowedProcessesListBox";
            this.AllowedProcessesListBox.Size = new System.Drawing.Size(316, 329);
            this.AllowedProcessesListBox.Sorted = true;
            this.AllowedProcessesListBox.TabIndex = 10;
            // 
            // HIDerTab
            // 
            this.HIDerTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HIDerTab.Controls.Add(this.DevicesTab);
            this.HIDerTab.Controls.Add(this.ProcessesTab);
            this.HIDerTab.Controls.Add(this.SettingsTab);
            this.HIDerTab.Location = new System.Drawing.Point(12, 27);
            this.HIDerTab.Name = "HIDerTab";
            this.HIDerTab.SelectedIndex = 0;
            this.HIDerTab.Size = new System.Drawing.Size(741, 365);
            this.HIDerTab.TabIndex = 11;
            // 
            // DevicesTab
            // 
            this.DevicesTab.Controls.Add(this.UnhideAllBtn);
            this.DevicesTab.Controls.Add(this.AvailableDevicesListBox);
            this.DevicesTab.Controls.Add(this.HideDeviceBtn);
            this.DevicesTab.Controls.Add(this.HiddenDevicesListBox);
            this.DevicesTab.Controls.Add(this.UnhideDeviceBtn);
            this.DevicesTab.Location = new System.Drawing.Point(4, 22);
            this.DevicesTab.Name = "DevicesTab";
            this.DevicesTab.Padding = new System.Windows.Forms.Padding(3);
            this.DevicesTab.Size = new System.Drawing.Size(733, 339);
            this.DevicesTab.TabIndex = 0;
            this.DevicesTab.Text = "Devices";
            this.DevicesTab.UseVisualStyleBackColor = true;
            // 
            // UnhideAllBtn
            // 
            this.UnhideAllBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UnhideAllBtn.Location = new System.Drawing.Point(650, 253);
            this.UnhideAllBtn.Name = "UnhideAllBtn";
            this.UnhideAllBtn.Size = new System.Drawing.Size(75, 81);
            this.UnhideAllBtn.TabIndex = 6;
            this.UnhideAllBtn.Text = "Unhide (All)";
            this.UnhideAllBtn.UseVisualStyleBackColor = true;
            this.UnhideAllBtn.Click += new System.EventHandler(this.UnhideAllBtn_Click);
            // 
            // ProcessesTab
            // 
            this.ProcessesTab.Controls.Add(this.DenyAllProcessBtn);
            this.ProcessesTab.Controls.Add(this.DeniedProcessesListBox);
            this.ProcessesTab.Controls.Add(this.AllowedProcessesListBox);
            this.ProcessesTab.Controls.Add(this.AllowProcessBtn);
            this.ProcessesTab.Controls.Add(this.RefreshProcessesBtn);
            this.ProcessesTab.Controls.Add(this.DenyProcessBtn);
            this.ProcessesTab.Location = new System.Drawing.Point(4, 22);
            this.ProcessesTab.Name = "ProcessesTab";
            this.ProcessesTab.Padding = new System.Windows.Forms.Padding(3);
            this.ProcessesTab.Size = new System.Drawing.Size(733, 339);
            this.ProcessesTab.TabIndex = 1;
            this.ProcessesTab.Text = "Processes";
            this.ProcessesTab.UseVisualStyleBackColor = true;
            // 
            // DenyAllProcessBtn
            // 
            this.DenyAllProcessBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DenyAllProcessBtn.Location = new System.Drawing.Point(328, 64);
            this.DenyAllProcessBtn.Name = "DenyAllProcessBtn";
            this.DenyAllProcessBtn.Size = new System.Drawing.Size(75, 23);
            this.DenyAllProcessBtn.TabIndex = 11;
            this.DenyAllProcessBtn.Text = "<- Deny (All)";
            this.DenyAllProcessBtn.UseVisualStyleBackColor = true;
            this.DenyAllProcessBtn.Click += new System.EventHandler(this.DenyAllProcessBtn_Click);
            // 
            // SettingsTab
            // 
            this.SettingsTab.Controls.Add(this.richTextBox1);
            this.SettingsTab.Controls.Add(this.PermenantProccessesTextBox);
            this.SettingsTab.Controls.Add(this.label4);
            this.SettingsTab.Controls.Add(this.StopHidCerberusBtn);
            this.SettingsTab.Controls.Add(this.UninstallHidCerberusBtn);
            this.SettingsTab.Controls.Add(this.UninstallHidGuardianBtn);
            this.SettingsTab.Controls.Add(this.UninstallViGEmBtn);
            this.SettingsTab.Controls.Add(this.StartHidCerberusBtn);
            this.SettingsTab.Controls.Add(this.InstallHidCerberusBtn);
            this.SettingsTab.Controls.Add(this.InstallHidGuardianBtn);
            this.SettingsTab.Controls.Add(this.InstallViGEmBtn);
            this.SettingsTab.Controls.Add(this.HidCerberusLbl);
            this.SettingsTab.Controls.Add(this.label3);
            this.SettingsTab.Controls.Add(this.label2);
            this.SettingsTab.Controls.Add(this.label1);
            this.SettingsTab.Location = new System.Drawing.Point(4, 22);
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsTab.Size = new System.Drawing.Size(733, 339);
            this.SettingsTab.TabIndex = 2;
            this.SettingsTab.Text = "Settings";
            this.SettingsTab.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(405, 46);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(301, 35);
            this.richTextBox1.TabIndex = 16;
            this.richTextBox1.Text = "Restart the application after installing one or more of the components.";
            // 
            // PermenantProccessesTextBox
            // 
            this.PermenantProccessesTextBox.Location = new System.Drawing.Point(21, 207);
            this.PermenantProccessesTextBox.Name = "PermenantProccessesTextBox";
            this.PermenantProccessesTextBox.Size = new System.Drawing.Size(685, 20);
            this.PermenantProccessesTextBox.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(528, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Add the names of the processes to be whitelisted here separated by a semicolon e." +
    "g. random.exe;random2.exe\r\n";
            // 
            // StopHidCerberusBtn
            // 
            this.StopHidCerberusBtn.Location = new System.Drawing.Point(245, 113);
            this.StopHidCerberusBtn.Name = "StopHidCerberusBtn";
            this.StopHidCerberusBtn.Size = new System.Drawing.Size(61, 23);
            this.StopHidCerberusBtn.TabIndex = 13;
            this.StopHidCerberusBtn.Text = "Stop";
            this.StopHidCerberusBtn.UseVisualStyleBackColor = true;
            this.StopHidCerberusBtn.Click += new System.EventHandler(this.StopHidCerberusBtn_Click);
            // 
            // UninstallHidCerberusBtn
            // 
            this.UninstallHidCerberusBtn.Location = new System.Drawing.Point(312, 113);
            this.UninstallHidCerberusBtn.Name = "UninstallHidCerberusBtn";
            this.UninstallHidCerberusBtn.Size = new System.Drawing.Size(75, 23);
            this.UninstallHidCerberusBtn.TabIndex = 12;
            this.UninstallHidCerberusBtn.Text = "Uninstall";
            this.UninstallHidCerberusBtn.UseVisualStyleBackColor = true;
            this.UninstallHidCerberusBtn.Click += new System.EventHandler(this.UninstallHidCerberusBtn_Click);
            // 
            // UninstallHidGuardianBtn
            // 
            this.UninstallHidGuardianBtn.Location = new System.Drawing.Point(312, 76);
            this.UninstallHidGuardianBtn.Name = "UninstallHidGuardianBtn";
            this.UninstallHidGuardianBtn.Size = new System.Drawing.Size(75, 23);
            this.UninstallHidGuardianBtn.TabIndex = 11;
            this.UninstallHidGuardianBtn.Text = "Uninstall";
            this.UninstallHidGuardianBtn.UseVisualStyleBackColor = true;
            this.UninstallHidGuardianBtn.Click += new System.EventHandler(this.UninstallHidGuardianBtn_Click);
            // 
            // UninstallViGEmBtn
            // 
            this.UninstallViGEmBtn.Location = new System.Drawing.Point(312, 41);
            this.UninstallViGEmBtn.Name = "UninstallViGEmBtn";
            this.UninstallViGEmBtn.Size = new System.Drawing.Size(75, 23);
            this.UninstallViGEmBtn.TabIndex = 10;
            this.UninstallViGEmBtn.Text = "Uninstall";
            this.UninstallViGEmBtn.UseVisualStyleBackColor = true;
            this.UninstallViGEmBtn.Click += new System.EventHandler(this.UninstallViGEmBtn_Click);
            // 
            // StartHidCerberusBtn
            // 
            this.StartHidCerberusBtn.Location = new System.Drawing.Point(179, 113);
            this.StartHidCerberusBtn.Name = "StartHidCerberusBtn";
            this.StartHidCerberusBtn.Size = new System.Drawing.Size(60, 23);
            this.StartHidCerberusBtn.TabIndex = 9;
            this.StartHidCerberusBtn.Text = "Start";
            this.StartHidCerberusBtn.UseVisualStyleBackColor = true;
            this.StartHidCerberusBtn.Click += new System.EventHandler(this.StartHidCerberusBtn_Click);
            // 
            // InstallHidCerberusBtn
            // 
            this.InstallHidCerberusBtn.Location = new System.Drawing.Point(107, 113);
            this.InstallHidCerberusBtn.Name = "InstallHidCerberusBtn";
            this.InstallHidCerberusBtn.Size = new System.Drawing.Size(66, 23);
            this.InstallHidCerberusBtn.TabIndex = 8;
            this.InstallHidCerberusBtn.Text = "Install";
            this.InstallHidCerberusBtn.UseVisualStyleBackColor = true;
            this.InstallHidCerberusBtn.Click += new System.EventHandler(this.InstallHidCerberusBtn_Click);
            // 
            // InstallHidGuardianBtn
            // 
            this.InstallHidGuardianBtn.Location = new System.Drawing.Point(107, 76);
            this.InstallHidGuardianBtn.Name = "InstallHidGuardianBtn";
            this.InstallHidGuardianBtn.Size = new System.Drawing.Size(199, 23);
            this.InstallHidGuardianBtn.TabIndex = 6;
            this.InstallHidGuardianBtn.Text = "Install";
            this.InstallHidGuardianBtn.UseVisualStyleBackColor = true;
            this.InstallHidGuardianBtn.Click += new System.EventHandler(this.InstallHidGuardianBtn_Click);
            // 
            // InstallViGEmBtn
            // 
            this.InstallViGEmBtn.Location = new System.Drawing.Point(107, 41);
            this.InstallViGEmBtn.Name = "InstallViGEmBtn";
            this.InstallViGEmBtn.Size = new System.Drawing.Size(199, 23);
            this.InstallViGEmBtn.TabIndex = 4;
            this.InstallViGEmBtn.Text = "Install";
            this.InstallViGEmBtn.UseVisualStyleBackColor = true;
            this.InstallViGEmBtn.Click += new System.EventHandler(this.InstallViGEmBtn_Click);
            // 
            // HidCerberusLbl
            // 
            this.HidCerberusLbl.AutoSize = true;
            this.HidCerberusLbl.Location = new System.Drawing.Point(18, 118);
            this.HidCerberusLbl.Name = "HidCerberusLbl";
            this.HidCerberusLbl.Size = new System.Drawing.Size(65, 13);
            this.HidCerberusLbl.TabIndex = 3;
            this.HidCerberusLbl.Text = "HidCerberus";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "HidGuardian";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ViGEmBus";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(616, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "You need to install the following for the project to work. Do not use the Uninsta" +
    "ll option unless you no longer need this application.";
            // 
            // AppNotifyIcon
            // 
            this.AppNotifyIcon.ContextMenuStrip = this.HiderStausMenu;
            this.AppNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("AppNotifyIcon.Icon")));
            this.AppNotifyIcon.Text = "HIDer";
            this.AppNotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AppNotifyIcon_MouseClick);
            // 
            // HiderStausMenu
            // 
            this.HiderStausMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TrayMenuOpen,
            this.TrayMenuExit});
            this.HiderStausMenu.Name = "HiderStausMenu";
            this.HiderStausMenu.Size = new System.Drawing.Size(104, 48);
            // 
            // TrayMenuOpen
            // 
            this.TrayMenuOpen.Name = "TrayMenuOpen";
            this.TrayMenuOpen.Size = new System.Drawing.Size(152, 22);
            this.TrayMenuOpen.Text = "Open";
            this.TrayMenuOpen.Click += new System.EventHandler(this.TrayMenuOpen_Click);
            // 
            // TrayMenuExit
            // 
            this.TrayMenuExit.Name = "TrayMenuExit";
            this.TrayMenuExit.Size = new System.Drawing.Size(152, 22);
            this.TrayMenuExit.Text = "Exit";
            this.TrayMenuExit.Click += new System.EventHandler(this.TrayMenuExit_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(765, 24);
            this.MainMenu.TabIndex = 12;
            this.MainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // MenuFileExit
            // 
            this.MenuFileExit.Name = "MenuFileExit";
            this.MenuFileExit.Size = new System.Drawing.Size(92, 22);
            this.MenuFileExit.Text = "Exit";
            this.MenuFileExit.Click += new System.EventHandler(this.MenuFileExit_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuHelpAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // MenuHelpAbout
            // 
            this.MenuHelpAbout.Name = "MenuHelpAbout";
            this.MenuHelpAbout.Size = new System.Drawing.Size(107, 22);
            this.MenuHelpAbout.Text = "About";
            this.MenuHelpAbout.Click += new System.EventHandler(this.MenuHelpAbout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 403);
            this.Controls.Add(this.HIDerTab);
            this.Controls.Add(this.MainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "HIDer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.HIDerTab.ResumeLayout(false);
            this.DevicesTab.ResumeLayout(false);
            this.ProcessesTab.ResumeLayout(false);
            this.SettingsTab.ResumeLayout(false);
            this.SettingsTab.PerformLayout();
            this.HiderStausMenu.ResumeLayout(false);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox AvailableDevicesListBox;
        private System.Windows.Forms.Button HideDeviceBtn;
        private System.Windows.Forms.Button UnhideDeviceBtn;
        private System.Windows.Forms.ListBox HiddenDevicesListBox;
        private System.Windows.Forms.ListBox DeniedProcessesListBox;
        private System.Windows.Forms.Button AllowProcessBtn;
        private System.Windows.Forms.Button DenyProcessBtn;
        private System.Windows.Forms.Button RefreshProcessesBtn;
        private System.Windows.Forms.ListBox AllowedProcessesListBox;
        private System.Windows.Forms.TabControl HIDerTab;
        private System.Windows.Forms.TabPage DevicesTab;
        private System.Windows.Forms.TabPage ProcessesTab;
        private System.Windows.Forms.TabPage SettingsTab;
        private System.Windows.Forms.Button UnhideAllBtn;
        private System.Windows.Forms.Button DenyAllProcessBtn;
        private System.Windows.Forms.Button InstallHidCerberusBtn;
        private System.Windows.Forms.Button InstallHidGuardianBtn;
        private System.Windows.Forms.Button InstallViGEmBtn;
        private System.Windows.Forms.Label HidCerberusLbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button StartHidCerberusBtn;
        private System.Windows.Forms.Button UninstallHidCerberusBtn;
        private System.Windows.Forms.Button UninstallHidGuardianBtn;
        private System.Windows.Forms.Button UninstallViGEmBtn;
        private System.Windows.Forms.Button StopHidCerberusBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PermenantProccessesTextBox;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.NotifyIcon AppNotifyIcon;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuFileExit;
        private System.Windows.Forms.ToolStripMenuItem MenuHelpAbout;
        private System.Windows.Forms.ContextMenuStrip HiderStausMenu;
        private System.Windows.Forms.ToolStripMenuItem TrayMenuOpen;
        private System.Windows.Forms.ToolStripMenuItem TrayMenuExit;
    }
}

