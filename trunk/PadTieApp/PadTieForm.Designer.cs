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
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.settingsTab = new System.Windows.Forms.TabPage();
			this.analogGestureSettingsBox = new System.Windows.Forms.GroupBox();
			this.label13 = new System.Windows.Forms.Label();
			this.deadzoneSetting = new System.Windows.Forms.NumericUpDown();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.axisPoleSizeSetting = new System.Windows.Forms.NumericUpDown();
			this.buttonGestureSettingsBox = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.tapIntervalSetting = new System.Windows.Forms.NumericUpDown();
			this.label11 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.doubleTapIntervalSetting = new System.Windows.Forms.NumericUpDown();
			this.holdIntervalSetting = new System.Windows.Forms.NumericUpDown();
			this.label9 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.configBox = new System.Windows.Forms.ComboBox();
			this.cloneBtn = new System.Windows.Forms.Button();
			this.iterationTimer = new System.Windows.Forms.Timer(this.components);
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.notifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.switchConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.defaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.padTabs.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.settingsTab.SuspendLayout();
			this.analogGestureSettingsBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.deadzoneSetting)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.axisPoleSizeSetting)).BeginInit();
			this.buttonGestureSettingsBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tapIntervalSetting)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.doubleTapIntervalSetting)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.holdIntervalSetting)).BeginInit();
			this.notifyMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// padTabs
			// 
			this.padTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.padTabs.Controls.Add(this.tabPage1);
			this.padTabs.Controls.Add(this.settingsTab);
			this.padTabs.Location = new System.Drawing.Point(12, 33);
			this.padTabs.Name = "padTabs";
			this.padTabs.SelectedIndex = 0;
			this.padTabs.Size = new System.Drawing.Size(587, 458);
			this.padTabs.TabIndex = 2;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.panel1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(579, 432);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Welcome!";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Location = new System.Drawing.Point(269, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(304, 407);
			this.label2.TabIndex = 0;
			this.label2.Text = resources.GetString("label2.Text");
			// 
			// panel1
			// 
			this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
			this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Location = new System.Drawing.Point(13, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(250, 268);
			this.panel1.TabIndex = 5;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(112, 221);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(107, 13);
			this.label6.TabIndex = 4;
			this.label6.Text = "(C) 2010 William Lahti";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.DarkGray;
			this.label5.Location = new System.Drawing.Point(69, 145);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(134, 13);
			this.label5.TabIndex = 3;
			this.label5.Text = "code.google.com/p/padtie";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.DimGray;
			this.label3.Location = new System.Drawing.Point(61, 122);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 29);
			this.label3.TabIndex = 1;
			this.label3.Text = "Pad Tie!";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(112, 234);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(63, 13);
			this.label4.TabIndex = 2;
			this.label4.Text = "Version: 1.0";
			// 
			// settingsTab
			// 
			this.settingsTab.Controls.Add(this.analogGestureSettingsBox);
			this.settingsTab.Controls.Add(this.buttonGestureSettingsBox);
			this.settingsTab.Location = new System.Drawing.Point(4, 22);
			this.settingsTab.Name = "settingsTab";
			this.settingsTab.Padding = new System.Windows.Forms.Padding(3);
			this.settingsTab.Size = new System.Drawing.Size(579, 432);
			this.settingsTab.TabIndex = 1;
			this.settingsTab.Text = "Settings";
			this.settingsTab.UseVisualStyleBackColor = true;
			// 
			// analogGestureSettingsBox
			// 
			this.analogGestureSettingsBox.Controls.Add(this.label13);
			this.analogGestureSettingsBox.Controls.Add(this.deadzoneSetting);
			this.analogGestureSettingsBox.Controls.Add(this.label15);
			this.analogGestureSettingsBox.Controls.Add(this.label16);
			this.analogGestureSettingsBox.Controls.Add(this.label17);
			this.analogGestureSettingsBox.Controls.Add(this.axisPoleSizeSetting);
			this.analogGestureSettingsBox.Location = new System.Drawing.Point(292, 31);
			this.analogGestureSettingsBox.Name = "analogGestureSettingsBox";
			this.analogGestureSettingsBox.Size = new System.Drawing.Size(281, 109);
			this.analogGestureSettingsBox.TabIndex = 10;
			this.analogGestureSettingsBox.TabStop = false;
			this.analogGestureSettingsBox.Text = "Analog Gestures";
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
			// deadzoneSetting
			// 
			this.deadzoneSetting.Location = new System.Drawing.Point(136, 23);
			this.deadzoneSetting.Name = "deadzoneSetting";
			this.deadzoneSetting.Size = new System.Drawing.Size(54, 20);
			this.deadzoneSetting.TabIndex = 1;
			this.deadzoneSetting.ValueChanged += new System.EventHandler(this.deadzoneSetting_ValueChanged);
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(192, 51);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(15, 13);
			this.label15.TabIndex = 7;
			this.label15.Text = "%";
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
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(192, 25);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(15, 13);
			this.label17.TabIndex = 6;
			this.label17.Text = "%";
			// 
			// axisPoleSizeSetting
			// 
			this.axisPoleSizeSetting.Location = new System.Drawing.Point(136, 49);
			this.axisPoleSizeSetting.Name = "axisPoleSizeSetting";
			this.axisPoleSizeSetting.Size = new System.Drawing.Size(54, 20);
			this.axisPoleSizeSetting.TabIndex = 3;
			this.axisPoleSizeSetting.ValueChanged += new System.EventHandler(this.axisPoleSizeSetting_ValueChanged);
			// 
			// buttonGestureSettingsBox
			// 
			this.buttonGestureSettingsBox.Controls.Add(this.label7);
			this.buttonGestureSettingsBox.Controls.Add(this.label12);
			this.buttonGestureSettingsBox.Controls.Add(this.tapIntervalSetting);
			this.buttonGestureSettingsBox.Controls.Add(this.label11);
			this.buttonGestureSettingsBox.Controls.Add(this.label8);
			this.buttonGestureSettingsBox.Controls.Add(this.label10);
			this.buttonGestureSettingsBox.Controls.Add(this.doubleTapIntervalSetting);
			this.buttonGestureSettingsBox.Controls.Add(this.holdIntervalSetting);
			this.buttonGestureSettingsBox.Controls.Add(this.label9);
			this.buttonGestureSettingsBox.Location = new System.Drawing.Point(6, 31);
			this.buttonGestureSettingsBox.Name = "buttonGestureSettingsBox";
			this.buttonGestureSettingsBox.Size = new System.Drawing.Size(281, 109);
			this.buttonGestureSettingsBox.TabIndex = 9;
			this.buttonGestureSettingsBox.TabStop = false;
			this.buttonGestureSettingsBox.Text = "Button Gestures";
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
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(209, 77);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(20, 13);
			this.label12.TabIndex = 8;
			this.label12.Text = "ms";
			// 
			// tapIntervalSetting
			// 
			this.tapIntervalSetting.Location = new System.Drawing.Point(123, 23);
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
			this.label11.Location = new System.Drawing.Point(209, 51);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(20, 13);
			this.label11.TabIndex = 7;
			this.label11.Text = "ms";
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
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(209, 25);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(20, 13);
			this.label10.TabIndex = 6;
			this.label10.Text = "ms";
			// 
			// doubleTapIntervalSetting
			// 
			this.doubleTapIntervalSetting.Location = new System.Drawing.Point(123, 49);
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
			this.holdIntervalSetting.Location = new System.Drawing.Point(123, 75);
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
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(18, 77);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(69, 13);
			this.label9.TabIndex = 4;
			this.label9.Text = "Hold interval:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Configuration:";
			// 
			// configBox
			// 
			this.configBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.configBox.FormattingEnabled = true;
			this.configBox.Location = new System.Drawing.Point(87, 6);
			this.configBox.Name = "configBox";
			this.configBox.Size = new System.Drawing.Size(431, 21);
			this.configBox.TabIndex = 4;
			this.configBox.TextChanged += new System.EventHandler(this.configBox_TextChanged);
			// 
			// cloneBtn
			// 
			this.cloneBtn.Location = new System.Drawing.Point(524, 6);
			this.cloneBtn.Name = "cloneBtn";
			this.cloneBtn.Size = new System.Drawing.Size(75, 23);
			this.cloneBtn.TabIndex = 7;
			this.cloneBtn.Text = "Save As...";
			this.cloneBtn.UseVisualStyleBackColor = true;
			this.cloneBtn.Click += new System.EventHandler(this.cloneBtn_Click);
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
			this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
			// 
			// notifyMenu
			// 
			this.notifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.switchConfigurationToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
			this.notifyMenu.Name = "notifyMenu";
			this.notifyMenu.Size = new System.Drawing.Size(187, 76);
			// 
			// showToolStripMenuItem
			// 
			this.showToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.showToolStripMenuItem.Name = "showToolStripMenuItem";
			this.showToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.showToolStripMenuItem.Text = "Show Pad Tie";
			this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
			// 
			// switchConfigurationToolStripMenuItem
			// 
			this.switchConfigurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultToolStripMenuItem,
            this.toolStripMenuItem2});
			this.switchConfigurationToolStripMenuItem.Name = "switchConfigurationToolStripMenuItem";
			this.switchConfigurationToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.switchConfigurationToolStripMenuItem.Text = "Switch configuration:";
			// 
			// defaultToolStripMenuItem
			// 
			this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
			this.defaultToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
			this.defaultToolStripMenuItem.Text = "Default";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(117, 6);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(183, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// PadTieForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(611, 503);
			this.Controls.Add(this.cloneBtn);
			this.Controls.Add(this.configBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.padTabs);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(619, 415);
			this.Name = "PadTieForm";
			this.Text = "Pad Tie!";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PadTieForm_FormClosing);
			this.Load += new System.EventHandler(this.PadTieForm_Load);
			this.padTabs.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.settingsTab.ResumeLayout(false);
			this.analogGestureSettingsBox.ResumeLayout(false);
			this.analogGestureSettingsBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.deadzoneSetting)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.axisPoleSizeSetting)).EndInit();
			this.buttonGestureSettingsBox.ResumeLayout(false);
			this.buttonGestureSettingsBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tapIntervalSetting)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.doubleTapIntervalSetting)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.holdIntervalSetting)).EndInit();
			this.notifyMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl padTabs;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox configBox;
		private System.Windows.Forms.Button cloneBtn;
		private System.Windows.Forms.Timer iterationTimer;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TabPage settingsTab;
		private System.Windows.Forms.Panel panel1;
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
		private System.Windows.Forms.ToolStripMenuItem switchConfigurationToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem defaultToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;

	}
}

