namespace PadTieApp {
	partial class PadTieForm {
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
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PadTieForm));
			this.padTabs = new System.Windows.Forms.TabControl();
			this.legendTab = new System.Windows.Forms.TabPage();
			this.padLegend = new PadTieApp.PadLegendControl();
			this.infoTab = new System.Windows.Forms.TabPage();
			this.layoutName = new System.Windows.Forms.TextBox();
			this.infobox = new System.Windows.Forms.TextBox();
			this.settingsTab = new System.Windows.Forms.TabPage();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.buttonGestureSettingsBox = new System.Windows.Forms.GroupBox();
			this.label12 = new System.Windows.Forms.Label();
			this.tapIntervalSetting = new System.Windows.Forms.NumericUpDown();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.doubleTapIntervalSetting = new System.Windows.Forms.NumericUpDown();
			this.holdIntervalSetting = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.analogGestureSettingsBox = new System.Windows.Forms.GroupBox();
			this.deadzoneSetting = new System.Windows.Forms.NumericUpDown();
			this.label15 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.axisPoleSizeSetting = new System.Windows.Forms.NumericUpDown();
			this.label13 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.showCompatBalloonSetting = new System.Windows.Forms.CheckBox();
			this.showBalloonSetting = new System.Windows.Forms.CheckBox();
			this.label14 = new System.Windows.Forms.Label();
			this.balloonTimeoutSetting = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.noGamepadsConfiguredSetting = new System.Windows.Forms.CheckBox();
			this.aboutTab = new System.Windows.Forms.TabPage();
			this.label6 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.iterationTimer = new System.Windows.Forms.Timer(this.components);
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.notifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.switchConfigMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.defaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.refreshConfigListTimer = new System.Windows.Forms.Timer(this.components);
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.configTools = new System.Windows.Forms.ToolStrip();
			this.layoutToolBtn = new System.Windows.Forms.ToolStripDropDownButton();
			this.saveLayoutAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.defaultMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.configBox = new System.Windows.Forms.ToolStripComboBox();
			this.padTabs.SuspendLayout();
			this.legendTab.SuspendLayout();
			this.infoTab.SuspendLayout();
			this.settingsTab.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.buttonGestureSettingsBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tapIntervalSetting)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.doubleTapIntervalSetting)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.holdIntervalSetting)).BeginInit();
			this.analogGestureSettingsBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.deadzoneSetting)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.axisPoleSizeSetting)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.balloonTimeoutSetting)).BeginInit();
			this.aboutTab.SuspendLayout();
			this.notifyMenu.SuspendLayout();
			this.toolStripContainer1.ContentPanel.SuspendLayout();
			this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			this.configTools.SuspendLayout();
			this.SuspendLayout();
			// 
			// padTabs
			// 
			this.padTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.padTabs.Controls.Add(this.legendTab);
			this.padTabs.Controls.Add(this.infoTab);
			this.padTabs.Controls.Add(this.settingsTab);
			this.padTabs.Controls.Add(this.aboutTab);
			this.padTabs.Location = new System.Drawing.Point(3, 3);
			this.padTabs.Multiline = true;
			this.padTabs.Name = "padTabs";
			this.padTabs.SelectedIndex = 0;
			this.padTabs.Size = new System.Drawing.Size(646, 486);
			this.padTabs.TabIndex = 2;
			this.padTabs.Tag = "";
			// 
			// legendTab
			// 
			this.legendTab.Controls.Add(this.padLegend);
			this.legendTab.Location = new System.Drawing.Point(4, 22);
			this.legendTab.Name = "legendTab";
			this.legendTab.Padding = new System.Windows.Forms.Padding(3);
			this.legendTab.Size = new System.Drawing.Size(638, 460);
			this.legendTab.TabIndex = 3;
			this.legendTab.Tag = "first";
			this.legendTab.Text = "Legend";
			this.legendTab.UseVisualStyleBackColor = true;
			// 
			// padLegend
			// 
			this.padLegend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.padLegend.Location = new System.Drawing.Point(0, 0);
			this.padLegend.MinimumSize = new System.Drawing.Size(642, 460);
			this.padLegend.Name = "padLegend";
			this.padLegend.Pad = 1;
			this.padLegend.SelectedMode = PadTieApp.LegendMode.Overview;
			this.padLegend.Size = new System.Drawing.Size(642, 506);
			this.padLegend.TabIndex = 0;
			this.padLegend.SelectedModeChanged += new System.EventHandler(this.padLegend_SelectedModeChanged);
			this.padLegend.PadChanged += new System.EventHandler(this.padLegend_PadChanged);
			this.padLegend.LayoutChanged += new System.EventHandler(this.padLegend_LayoutChanged);
			// 
			// infoTab
			// 
			this.infoTab.Controls.Add(this.layoutName);
			this.infoTab.Controls.Add(this.infobox);
			this.infoTab.Location = new System.Drawing.Point(4, 22);
			this.infoTab.Name = "infoTab";
			this.infoTab.Padding = new System.Windows.Forms.Padding(3);
			this.infoTab.Size = new System.Drawing.Size(638, 458);
			this.infoTab.TabIndex = 2;
			this.infoTab.Tag = "first";
			this.infoTab.Text = "Information";
			this.infoTab.UseVisualStyleBackColor = true;
			// 
			// layoutName
			// 
			this.layoutName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.layoutName.BackColor = System.Drawing.SystemColors.Control;
			this.layoutName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.layoutName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.layoutName.Location = new System.Drawing.Point(6, 6);
			this.layoutName.Name = "layoutName";
			this.layoutName.Size = new System.Drawing.Size(626, 28);
			this.layoutName.TabIndex = 1;
			this.layoutName.Text = "My Configuration!";
			this.layoutName.Enter += new System.EventHandler(this.layoutName_Enter);
			this.layoutName.Leave += new System.EventHandler(this.layoutName_Leave);
			// 
			// infobox
			// 
			this.infobox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.infobox.BackColor = System.Drawing.SystemColors.Control;
			this.infobox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.infobox.Location = new System.Drawing.Point(6, 40);
			this.infobox.Multiline = true;
			this.infobox.Name = "infobox";
			this.infobox.Size = new System.Drawing.Size(626, 435);
			this.infobox.TabIndex = 0;
			this.infobox.Enter += new System.EventHandler(this.infobox_Enter);
			this.infobox.Leave += new System.EventHandler(this.infobox_Leave);
			// 
			// settingsTab
			// 
			this.settingsTab.Controls.Add(this.flowLayoutPanel1);
			this.settingsTab.Location = new System.Drawing.Point(4, 22);
			this.settingsTab.Name = "settingsTab";
			this.settingsTab.Padding = new System.Windows.Forms.Padding(3);
			this.settingsTab.Size = new System.Drawing.Size(638, 458);
			this.settingsTab.TabIndex = 1;
			this.settingsTab.Tag = "last";
			this.settingsTab.Text = "Settings";
			this.settingsTab.UseVisualStyleBackColor = true;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanel1.Controls.Add(this.buttonGestureSettingsBox);
			this.flowLayoutPanel1.Controls.Add(this.analogGestureSettingsBox);
			this.flowLayoutPanel1.Controls.Add(this.groupBox1);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(638, 460);
			this.flowLayoutPanel1.TabIndex = 13;
			// 
			// buttonGestureSettingsBox
			// 
			this.buttonGestureSettingsBox.Controls.Add(this.label12);
			this.buttonGestureSettingsBox.Controls.Add(this.tapIntervalSetting);
			this.buttonGestureSettingsBox.Controls.Add(this.label11);
			this.buttonGestureSettingsBox.Controls.Add(this.label10);
			this.buttonGestureSettingsBox.Controls.Add(this.doubleTapIntervalSetting);
			this.buttonGestureSettingsBox.Controls.Add(this.holdIntervalSetting);
			this.buttonGestureSettingsBox.Controls.Add(this.label7);
			this.buttonGestureSettingsBox.Controls.Add(this.label9);
			this.buttonGestureSettingsBox.Controls.Add(this.label8);
			this.buttonGestureSettingsBox.Location = new System.Drawing.Point(3, 3);
			this.buttonGestureSettingsBox.Name = "buttonGestureSettingsBox";
			this.buttonGestureSettingsBox.Size = new System.Drawing.Size(281, 109);
			this.buttonGestureSettingsBox.TabIndex = 9;
			this.buttonGestureSettingsBox.TabStop = false;
			this.buttonGestureSettingsBox.Text = "Button Timing";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(220, 77);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(20, 13);
			this.label12.TabIndex = 8;
			this.label12.Text = "ms";
			// 
			// tapIntervalSetting
			// 
			this.tapIntervalSetting.Location = new System.Drawing.Point(134, 23);
			this.tapIntervalSetting.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
			this.tapIntervalSetting.Name = "tapIntervalSetting";
			this.tapIntervalSetting.Size = new System.Drawing.Size(81, 20);
			this.tapIntervalSetting.TabIndex = 1;
			this.tapIntervalSetting.ValueChanged += new System.EventHandler(this.tapIntervalSetting_ValueChanged);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(220, 51);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(20, 13);
			this.label11.TabIndex = 7;
			this.label11.Text = "ms";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(220, 25);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(20, 13);
			this.label10.TabIndex = 6;
			this.label10.Text = "ms";
			// 
			// doubleTapIntervalSetting
			// 
			this.doubleTapIntervalSetting.Location = new System.Drawing.Point(134, 49);
			this.doubleTapIntervalSetting.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
			this.doubleTapIntervalSetting.Name = "doubleTapIntervalSetting";
			this.doubleTapIntervalSetting.Size = new System.Drawing.Size(81, 20);
			this.doubleTapIntervalSetting.TabIndex = 3;
			this.doubleTapIntervalSetting.ValueChanged += new System.EventHandler(this.doubleTapIntervalSetting_ValueChanged);
			// 
			// holdIntervalSetting
			// 
			this.holdIntervalSetting.Location = new System.Drawing.Point(134, 75);
			this.holdIntervalSetting.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
			this.holdIntervalSetting.Name = "holdIntervalSetting";
			this.holdIntervalSetting.Size = new System.Drawing.Size(81, 20);
			this.holdIntervalSetting.TabIndex = 5;
			this.holdIntervalSetting.ValueChanged += new System.EventHandler(this.holdIntervalSetting_ValueChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(18, 25);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(66, 13);
			this.label7.TabIndex = 0;
			this.label7.Text = "Tap interval:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(18, 77);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(69, 13);
			this.label9.TabIndex = 4;
			this.label9.Text = "Hold interval:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(18, 51);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(99, 13);
			this.label8.TabIndex = 2;
			this.label8.Text = "Double tap interval:";
			// 
			// analogGestureSettingsBox
			// 
			this.analogGestureSettingsBox.Controls.Add(this.deadzoneSetting);
			this.analogGestureSettingsBox.Controls.Add(this.label15);
			this.analogGestureSettingsBox.Controls.Add(this.label17);
			this.analogGestureSettingsBox.Controls.Add(this.axisPoleSizeSetting);
			this.analogGestureSettingsBox.Controls.Add(this.label13);
			this.analogGestureSettingsBox.Controls.Add(this.label16);
			this.analogGestureSettingsBox.Location = new System.Drawing.Point(290, 3);
			this.analogGestureSettingsBox.Name = "analogGestureSettingsBox";
			this.analogGestureSettingsBox.Size = new System.Drawing.Size(281, 109);
			this.analogGestureSettingsBox.TabIndex = 10;
			this.analogGestureSettingsBox.TabStop = false;
			this.analogGestureSettingsBox.Text = "Analog Sensitivity";
			// 
			// deadzoneSetting
			// 
			this.deadzoneSetting.Location = new System.Drawing.Point(148, 23);
			this.deadzoneSetting.Name = "deadzoneSetting";
			this.deadzoneSetting.Size = new System.Drawing.Size(54, 20);
			this.deadzoneSetting.TabIndex = 1;
			this.deadzoneSetting.ValueChanged += new System.EventHandler(this.deadzoneSetting_ValueChanged);
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(205, 51);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(15, 13);
			this.label15.TabIndex = 7;
			this.label15.Text = "%";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(205, 25);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(15, 13);
			this.label17.TabIndex = 6;
			this.label17.Text = "%";
			// 
			// axisPoleSizeSetting
			// 
			this.axisPoleSizeSetting.Location = new System.Drawing.Point(148, 49);
			this.axisPoleSizeSetting.Name = "axisPoleSizeSetting";
			this.axisPoleSizeSetting.Size = new System.Drawing.Size(54, 20);
			this.axisPoleSizeSetting.TabIndex = 3;
			this.axisPoleSizeSetting.ValueChanged += new System.EventHandler(this.axisPoleSizeSetting_ValueChanged);
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(18, 25);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(94, 13);
			this.label13.TabIndex = 0;
			this.label13.Text = "Default deadzone:";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(18, 51);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(109, 13);
			this.label16.TabIndex = 2;
			this.label16.Text = "Default axis pole size:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.showCompatBalloonSetting);
			this.groupBox1.Controls.Add(this.showBalloonSetting);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.balloonTimeoutSetting);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.noGamepadsConfiguredSetting);
			this.groupBox1.Location = new System.Drawing.Point(3, 118);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(281, 126);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			// 
			// showCompatBalloonSetting
			// 
			this.showCompatBalloonSetting.AutoSize = true;
			this.showCompatBalloonSetting.Location = new System.Drawing.Point(21, 23);
			this.showCompatBalloonSetting.Name = "showCompatBalloonSetting";
			this.showCompatBalloonSetting.Size = new System.Drawing.Size(121, 17);
			this.showCompatBalloonSetting.TabIndex = 3;
			this.showCompatBalloonSetting.Text = "Compatibility notices";
			this.showCompatBalloonSetting.UseVisualStyleBackColor = true;
			this.showCompatBalloonSetting.CheckedChanged += new System.EventHandler(this.showCompatBalloonSetting_CheckedChanged);
			// 
			// showBalloonSetting
			// 
			this.showBalloonSetting.AutoSize = true;
			this.showBalloonSetting.Location = new System.Drawing.Point(7, -1);
			this.showBalloonSetting.Name = "showBalloonSetting";
			this.showBalloonSetting.Size = new System.Drawing.Size(149, 17);
			this.showBalloonSetting.TabIndex = 11;
			this.showBalloonSetting.Text = "Show balloon notifications";
			this.showBalloonSetting.UseVisualStyleBackColor = true;
			this.showBalloonSetting.CheckedChanged += new System.EventHandler(this.showBalloonSetting_CheckedChanged);
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(22, 94);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(53, 13);
			this.label14.TabIndex = 2;
			this.label14.Text = "Hide after";
			// 
			// balloonTimeoutSetting
			// 
			this.balloonTimeoutSetting.Location = new System.Drawing.Point(81, 92);
			this.balloonTimeoutSetting.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.balloonTimeoutSetting.Name = "balloonTimeoutSetting";
			this.balloonTimeoutSetting.Size = new System.Drawing.Size(93, 20);
			this.balloonTimeoutSetting.TabIndex = 1;
			this.balloonTimeoutSetting.ValueChanged += new System.EventHandler(this.balloonTimeoutSetting_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(180, 94);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(24, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "sec";
			// 
			// noGamepadsConfiguredSetting
			// 
			this.noGamepadsConfiguredSetting.Location = new System.Drawing.Point(21, 34);
			this.noGamepadsConfiguredSetting.Name = "noGamepadsConfiguredSetting";
			this.noGamepadsConfiguredSetting.Size = new System.Drawing.Size(254, 45);
			this.noGamepadsConfiguredSetting.TabIndex = 4;
			this.noGamepadsConfiguredSetting.Text = "Warn me when I load a layout where none of my gamepads are configured";
			this.noGamepadsConfiguredSetting.UseVisualStyleBackColor = true;
			this.noGamepadsConfiguredSetting.CheckedChanged += new System.EventHandler(this.noGamepadsConfiguredSetting_CheckedChanged);
			// 
			// aboutTab
			// 
			this.aboutTab.Controls.Add(this.label6);
			this.aboutTab.Controls.Add(this.label2);
			this.aboutTab.Controls.Add(this.label5);
			this.aboutTab.Controls.Add(this.label3);
			this.aboutTab.Controls.Add(this.label4);
			this.aboutTab.Location = new System.Drawing.Point(4, 22);
			this.aboutTab.Name = "aboutTab";
			this.aboutTab.Padding = new System.Windows.Forms.Padding(3);
			this.aboutTab.Size = new System.Drawing.Size(638, 458);
			this.aboutTab.TabIndex = 0;
			this.aboutTab.Tag = "end";
			this.aboutTab.Text = "About";
			this.aboutTab.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(61, 133);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(107, 13);
			this.label6.TabIndex = 4;
			this.label6.Text = "(C) 2010 William Lahti";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Location = new System.Drawing.Point(229, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(403, 444);
			this.label2.TabIndex = 0;
			this.label2.Text = resources.GetString("label2.Text");
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.DarkGray;
			this.label5.Location = new System.Drawing.Point(49, 80);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(134, 13);
			this.label5.TabIndex = 3;
			this.label5.Text = "code.google.com/p/padtie";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.DimGray;
			this.label3.Location = new System.Drawing.Point(25, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(198, 58);
			this.label3.TabIndex = 1;
			this.label3.Text = "Pad Tie!";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(78, 111);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(75, 13);
			this.label4.TabIndex = 2;
			this.label4.Text = "Version: 0.1b2";
			// 
			// iterationTimer
			// 
			this.iterationTimer.Enabled = true;
			this.iterationTimer.Interval = 10;
			this.iterationTimer.Tick += new System.EventHandler(this.iterationTimer_Tick);
			// 
			// notifyIcon
			// 
			this.notifyIcon.ContextMenuStrip = this.notifyMenu;
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Text = "Pad Tie!";
			this.notifyIcon.Visible = true;
			this.notifyIcon.BalloonTipClicked += new System.EventHandler(this.notifyIcon_BalloonTipClicked);
			this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
			// 
			// notifyMenu
			// 
			this.notifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.switchConfigMenu,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
			this.notifyMenu.Name = "notifyMenu";
			this.notifyMenu.Size = new System.Drawing.Size(176, 76);
			// 
			// showToolStripMenuItem
			// 
			this.showToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.showToolStripMenuItem.Name = "showToolStripMenuItem";
			this.showToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
			this.showToolStripMenuItem.Text = "Show Pad Tie";
			this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
			// 
			// switchConfigMenu
			// 
			this.switchConfigMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultToolStripMenuItem,
            this.toolStripMenuItem2});
			this.switchConfigMenu.Name = "switchConfigMenu";
			this.switchConfigMenu.Size = new System.Drawing.Size(175, 22);
			this.switchConfigMenu.Text = "Switch configuration:";
			// 
			// defaultToolStripMenuItem
			// 
			this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
			this.defaultToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
			this.defaultToolStripMenuItem.Text = "Default";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(106, 6);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(172, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// refreshConfigListTimer
			// 
			this.refreshConfigListTimer.Enabled = true;
			this.refreshConfigListTimer.Interval = 10000;
			this.refreshConfigListTimer.Tick += new System.EventHandler(this.refreshConfigListTimer_Tick);
			// 
			// toolStripContainer1
			// 
			this.toolStripContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.Controls.Add(this.padTabs);
			this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(652, 492);
			this.toolStripContainer1.ContentPanel.Load += new System.EventHandler(this.toolStripContainer1_ContentPanel_Load);
			this.toolStripContainer1.LeftToolStripPanelVisible = false;
			this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.RightToolStripPanelVisible = false;
			this.toolStripContainer1.Size = new System.Drawing.Size(652, 517);
			this.toolStripContainer1.TabIndex = 10;
			this.toolStripContainer1.Text = "toolStripContainer1";
			// 
			// toolStripContainer1.TopToolStripPanel
			// 
			this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.configTools);
			// 
			// configTools
			// 
			this.configTools.Dock = System.Windows.Forms.DockStyle.None;
			this.configTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.layoutToolBtn,
            this.configBox});
			this.configTools.Location = new System.Drawing.Point(3, 0);
			this.configTools.Name = "configTools";
			this.configTools.Size = new System.Drawing.Size(519, 25);
			this.configTools.TabIndex = 10;
			this.configTools.Text = "Configuration";
			// 
			// layoutToolBtn
			// 
			this.layoutToolBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.layoutToolBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveLayoutAsToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.defaultMenuItem});
			this.layoutToolBtn.Image = ((System.Drawing.Image)(resources.GetObject("layoutToolBtn.Image")));
			this.layoutToolBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.layoutToolBtn.Name = "layoutToolBtn";
			this.layoutToolBtn.Size = new System.Drawing.Size(57, 22);
			this.layoutToolBtn.Text = "Layout:";
			this.layoutToolBtn.ToolTipText = "Click for layout options";
			this.layoutToolBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.layoutToolBtn_MouseDown);
			// 
			// saveLayoutAsToolStripMenuItem
			// 
			this.saveLayoutAsToolStripMenuItem.Name = "saveLayoutAsToolStripMenuItem";
			this.saveLayoutAsToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
			this.saveLayoutAsToolStripMenuItem.Text = "Save As...";
			this.saveLayoutAsToolStripMenuItem.Click += new System.EventHandler(this.cloneBtn_Click);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			// 
			// defaultMenuItem
			// 
			this.defaultMenuItem.Checked = true;
			this.defaultMenuItem.CheckOnClick = true;
			this.defaultMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.defaultMenuItem.Name = "defaultMenuItem";
			this.defaultMenuItem.Size = new System.Drawing.Size(243, 22);
			this.defaultMenuItem.Text = "Use this layout when Pad Tie starts";
			this.defaultMenuItem.CheckStateChanged += new System.EventHandler(this.defaultMenuItem_CheckStateChanged);
			// 
			// configBox
			// 
			this.configBox.AutoSize = false;
			this.configBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.configBox.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.configBox.Name = "configBox";
			this.configBox.Size = new System.Drawing.Size(450, 23);
			this.configBox.SelectedIndexChanged += new System.EventHandler(this.configBox_SelectedIndexChanged);
			// 
			// PadTieForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(651, 518);
			this.Controls.Add(this.toolStripContainer1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(659, 550);
			this.Name = "PadTieForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "Pad Tie!";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PadTieForm_FormClosing);
			this.Load += new System.EventHandler(this.PadTieForm_Load);
			this.ResizeEnd += new System.EventHandler(this.PadTieForm_ResizeEnd);
			this.Move += new System.EventHandler(this.PadTieForm_Move);
			this.Resize += new System.EventHandler(this.PadTieForm_Resize);
			this.padTabs.ResumeLayout(false);
			this.legendTab.ResumeLayout(false);
			this.infoTab.ResumeLayout(false);
			this.infoTab.PerformLayout();
			this.settingsTab.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.buttonGestureSettingsBox.ResumeLayout(false);
			this.buttonGestureSettingsBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tapIntervalSetting)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.doubleTapIntervalSetting)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.holdIntervalSetting)).EndInit();
			this.analogGestureSettingsBox.ResumeLayout(false);
			this.analogGestureSettingsBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.deadzoneSetting)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.axisPoleSizeSetting)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.balloonTimeoutSetting)).EndInit();
			this.aboutTab.ResumeLayout(false);
			this.aboutTab.PerformLayout();
			this.notifyMenu.ResumeLayout(false);
			this.toolStripContainer1.ContentPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.PerformLayout();
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			this.configTools.ResumeLayout(false);
			this.configTools.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl padTabs;
		private System.Windows.Forms.Timer iterationTimer;
		private System.Windows.Forms.TabPage aboutTab;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TabPage settingsTab;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown holdIntervalSetting;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.NumericUpDown doubleTapIntervalSetting;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.NumericUpDown tapIntervalSetting;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.GroupBox analogGestureSettingsBox;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.NumericUpDown deadzoneSetting;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.NumericUpDown axisPoleSizeSetting;
		private System.Windows.Forms.GroupBox buttonGestureSettingsBox;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.ContextMenuStrip notifyMenu;
		private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem switchConfigMenu;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem defaultToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.Timer refreshConfigListTimer;
		private System.Windows.Forms.ToolStripContainer toolStripContainer1;
		private System.Windows.Forms.ToolStrip configTools;
		private System.Windows.Forms.ToolStripComboBox configBox;
		private System.Windows.Forms.ToolStripDropDownButton layoutToolBtn;
		private System.Windows.Forms.ToolStripMenuItem saveLayoutAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem defaultMenuItem;
		private System.Windows.Forms.CheckBox showBalloonSetting;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox noGamepadsConfiguredSetting;
		private System.Windows.Forms.CheckBox showCompatBalloonSetting;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.NumericUpDown balloonTimeoutSetting;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabPage infoTab;
		private System.Windows.Forms.TextBox infobox;
		private System.Windows.Forms.TextBox layoutName;
		private System.Windows.Forms.TabPage legendTab;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private PadLegendControl padLegend;

	}
}

