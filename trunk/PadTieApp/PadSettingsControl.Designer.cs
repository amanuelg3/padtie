namespace PadTieApp {
	partial class PadSettingsControl {
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PadSettingsControl));
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Key stroke");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Keyboard", new System.Windows.Forms.TreeNode[] {
            treeNode1});
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Pointer motion");
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Button");
			System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Wheel");
			System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Mouse", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4,
            treeNode5});
			System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Run command");
			System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Open file");
			System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Load Configuration");
			System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Exit Pad Tie");
			System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Actions", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10});
			System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Link");
			System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Tap");
			System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Double Tap");
			System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Hold");
			System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("A", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15});
			System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Link");
			System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Tap");
			System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Double Tap");
			System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Hold");
			System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("B", new System.Windows.Forms.TreeNode[] {
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20});
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.changeBtn = new System.Windows.Forms.Button();
			this.wizardBtn = new System.Windows.Forms.Button();
			this.buttonMappings = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.mapButton = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.actionTree = new System.Windows.Forms.TreeView();
			this.currentMappings = new System.Windows.Forms.TreeView();
			this.label2 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.devicePadNum = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.deviceFeedback = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.deviceHats = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.deviceAxes = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.deviceButtons = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.deviceProductID = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.deviceVendorID = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.deviceInstanceGUID = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.deviceGUID = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.deviceName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.activeMapping = new System.Windows.Forms.Label();
			this.editBtn = new System.Windows.Forms.Button();
			this.unmapBtn = new System.Windows.Forms.Button();
			this.padView = new PadTieApp.ControllerView();
			this.tabPage2.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.changeBtn);
			this.tabPage2.Controls.Add(this.wizardBtn);
			this.tabPage2.Controls.Add(this.buttonMappings);
			this.tabPage2.Controls.Add(this.label3);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(276, 405);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Button Layout";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// changeBtn
			// 
			this.changeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.changeBtn.Location = new System.Drawing.Point(199, 82);
			this.changeBtn.Name = "changeBtn";
			this.changeBtn.Size = new System.Drawing.Size(75, 23);
			this.changeBtn.TabIndex = 3;
			this.changeBtn.Text = "Change...";
			this.changeBtn.UseVisualStyleBackColor = true;
			this.changeBtn.Click += new System.EventHandler(this.changeBtn_Click);
			// 
			// wizardBtn
			// 
			this.wizardBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.wizardBtn.Location = new System.Drawing.Point(199, 111);
			this.wizardBtn.Name = "wizardBtn";
			this.wizardBtn.Size = new System.Drawing.Size(75, 23);
			this.wizardBtn.TabIndex = 2;
			this.wizardBtn.Text = "Wizard...";
			this.wizardBtn.UseVisualStyleBackColor = true;
			this.wizardBtn.Click += new System.EventHandler(this.wizardBtn_Click);
			// 
			// buttonMappings
			// 
			this.buttonMappings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.buttonMappings.FormattingEnabled = true;
			this.buttonMappings.Location = new System.Drawing.Point(6, 82);
			this.buttonMappings.Name = "buttonMappings";
			this.buttonMappings.Size = new System.Drawing.Size(188, 173);
			this.buttonMappings.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Location = new System.Drawing.Point(3, 12);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(272, 67);
			this.label3.TabIndex = 0;
			this.label3.Text = resources.GetString("label3.Text");
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.mapButton);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.actionTree);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(276, 405);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Actions";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// mapButton
			// 
			this.mapButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.mapButton.Location = new System.Drawing.Point(7, 376);
			this.mapButton.Name = "mapButton";
			this.mapButton.Size = new System.Drawing.Size(75, 23);
			this.mapButton.TabIndex = 7;
			this.mapButton.Text = "Map...";
			this.mapButton.UseVisualStyleBackColor = true;
			this.mapButton.Click += new System.EventHandler(this.mapButton_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(4, 12);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(258, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "Select an input action and click Map below.";
			// 
			// actionTree
			// 
			this.actionTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.actionTree.Location = new System.Drawing.Point(6, 38);
			this.actionTree.Name = "actionTree";
			treeNode1.Name = "Node3";
			treeNode1.Tag = "keystroke";
			treeNode1.Text = "Key stroke";
			treeNode2.Name = "Node0";
			treeNode2.Text = "Keyboard";
			treeNode3.Name = "Node4";
			treeNode3.Tag = "pointer";
			treeNode3.Text = "Pointer motion";
			treeNode4.Name = "Node5";
			treeNode4.Tag = "mouse-button";
			treeNode4.Text = "Button";
			treeNode5.Name = "Node6";
			treeNode5.Tag = "mouse-wheel";
			treeNode5.Text = "Wheel";
			treeNode6.Name = "Node1";
			treeNode6.Text = "Mouse";
			treeNode7.Name = "Node11";
			treeNode7.Tag = "command";
			treeNode7.Text = "Run command";
			treeNode8.Name = "Node12";
			treeNode8.Tag = "open-file";
			treeNode8.Text = "Open file";
			treeNode9.Name = "Node8";
			treeNode9.Tag = "load-config";
			treeNode9.Text = "Load Configuration";
			treeNode10.Name = "Node9";
			treeNode10.Tag = "exit";
			treeNode10.Text = "Exit Pad Tie";
			treeNode11.Name = "Node10";
			treeNode11.Text = "Actions";
			this.actionTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode6,
            treeNode11});
			this.actionTree.Size = new System.Drawing.Size(264, 334);
			this.actionTree.TabIndex = 5;
			this.actionTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.actionTree_NodeMouseDoubleClick);
			// 
			// currentMappings
			// 
			this.currentMappings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.currentMappings.HideSelection = false;
			this.currentMappings.Location = new System.Drawing.Point(9, 295);
			this.currentMappings.Name = "currentMappings";
			treeNode12.Name = "Node2";
			treeNode12.Text = "Link";
			treeNode13.Name = "Node4";
			treeNode13.Text = "Tap";
			treeNode14.Name = "Node5";
			treeNode14.Text = "Double Tap";
			treeNode15.Name = "Node6";
			treeNode15.Text = "Hold";
			treeNode16.Name = "Node0";
			treeNode16.Text = "A";
			treeNode17.Name = "Node7";
			treeNode17.Text = "Link";
			treeNode18.Name = "Node8";
			treeNode18.Text = "Tap";
			treeNode19.Name = "Node9";
			treeNode19.Text = "Double Tap";
			treeNode20.Name = "Node10";
			treeNode20.Text = "Hold";
			treeNode21.Name = "Node1";
			treeNode21.Text = "B";
			this.currentMappings.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode21});
			this.currentMappings.Size = new System.Drawing.Size(247, 106);
			this.currentMappings.TabIndex = 55;
			this.currentMappings.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.currentMappings_AfterSelect);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 409);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(61, 13);
			this.label2.TabIndex = 57;
			this.label2.Text = "Mapped to:";
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(262, 7);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(284, 431);
			this.tabControl1.TabIndex = 54;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.devicePadNum);
			this.tabPage3.Controls.Add(this.label13);
			this.tabPage3.Controls.Add(this.button1);
			this.tabPage3.Controls.Add(this.deviceFeedback);
			this.tabPage3.Controls.Add(this.label12);
			this.tabPage3.Controls.Add(this.deviceHats);
			this.tabPage3.Controls.Add(this.label11);
			this.tabPage3.Controls.Add(this.deviceAxes);
			this.tabPage3.Controls.Add(this.label10);
			this.tabPage3.Controls.Add(this.deviceButtons);
			this.tabPage3.Controls.Add(this.label9);
			this.tabPage3.Controls.Add(this.deviceProductID);
			this.tabPage3.Controls.Add(this.label8);
			this.tabPage3.Controls.Add(this.deviceVendorID);
			this.tabPage3.Controls.Add(this.label7);
			this.tabPage3.Controls.Add(this.deviceInstanceGUID);
			this.tabPage3.Controls.Add(this.label6);
			this.tabPage3.Controls.Add(this.deviceGUID);
			this.tabPage3.Controls.Add(this.label5);
			this.tabPage3.Controls.Add(this.deviceName);
			this.tabPage3.Controls.Add(this.label1);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(276, 405);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Device";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// devicePadNum
			// 
			this.devicePadNum.Location = new System.Drawing.Point(97, 42);
			this.devicePadNum.Name = "devicePadNum";
			this.devicePadNum.ReadOnly = true;
			this.devicePadNum.Size = new System.Drawing.Size(162, 20);
			this.devicePadNum.TabIndex = 20;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(6, 45);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(67, 13);
			this.label13.TabIndex = 19;
			this.label13.Text = "Pad number:";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(97, 69);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(162, 23);
			this.button1.TabIndex = 18;
			this.button1.Text = "Map to another pad number...";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// deviceFeedback
			// 
			this.deviceFeedback.Location = new System.Drawing.Point(97, 283);
			this.deviceFeedback.Name = "deviceFeedback";
			this.deviceFeedback.ReadOnly = true;
			this.deviceFeedback.Size = new System.Drawing.Size(162, 20);
			this.deviceFeedback.TabIndex = 17;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(6, 286);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(88, 13);
			this.label12.TabIndex = 16;
			this.label12.Text = "Force Feedback:";
			// 
			// deviceHats
			// 
			this.deviceHats.Location = new System.Drawing.Point(97, 257);
			this.deviceHats.Name = "deviceHats";
			this.deviceHats.ReadOnly = true;
			this.deviceHats.Size = new System.Drawing.Size(162, 20);
			this.deviceHats.TabIndex = 15;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(6, 260);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(54, 13);
			this.label11.TabIndex = 14;
			this.label11.Text = "# of Hats:";
			// 
			// deviceAxes
			// 
			this.deviceAxes.Location = new System.Drawing.Point(97, 231);
			this.deviceAxes.Name = "deviceAxes";
			this.deviceAxes.ReadOnly = true;
			this.deviceAxes.Size = new System.Drawing.Size(162, 20);
			this.deviceAxes.TabIndex = 13;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(6, 234);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(55, 13);
			this.label10.TabIndex = 12;
			this.label10.Text = "# of Axes:";
			// 
			// deviceButtons
			// 
			this.deviceButtons.Location = new System.Drawing.Point(97, 204);
			this.deviceButtons.Name = "deviceButtons";
			this.deviceButtons.ReadOnly = true;
			this.deviceButtons.Size = new System.Drawing.Size(162, 20);
			this.deviceButtons.TabIndex = 11;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(6, 207);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(68, 13);
			this.label9.TabIndex = 10;
			this.label9.Text = "# of Buttons:";
			// 
			// deviceProductID
			// 
			this.deviceProductID.Location = new System.Drawing.Point(97, 178);
			this.deviceProductID.Name = "deviceProductID";
			this.deviceProductID.ReadOnly = true;
			this.deviceProductID.Size = new System.Drawing.Size(162, 20);
			this.deviceProductID.TabIndex = 9;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(6, 181);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(61, 13);
			this.label8.TabIndex = 8;
			this.label8.Text = "Product ID:";
			// 
			// deviceVendorID
			// 
			this.deviceVendorID.Location = new System.Drawing.Point(97, 152);
			this.deviceVendorID.Name = "deviceVendorID";
			this.deviceVendorID.ReadOnly = true;
			this.deviceVendorID.Size = new System.Drawing.Size(162, 20);
			this.deviceVendorID.TabIndex = 7;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 155);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(58, 13);
			this.label7.TabIndex = 6;
			this.label7.Text = "Vendor ID:";
			// 
			// deviceInstanceGUID
			// 
			this.deviceInstanceGUID.Location = new System.Drawing.Point(97, 124);
			this.deviceInstanceGUID.Name = "deviceInstanceGUID";
			this.deviceInstanceGUID.ReadOnly = true;
			this.deviceInstanceGUID.Size = new System.Drawing.Size(162, 20);
			this.deviceInstanceGUID.TabIndex = 5;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 127);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(81, 13);
			this.label6.TabIndex = 4;
			this.label6.Text = "Instance GUID:";
			// 
			// deviceGUID
			// 
			this.deviceGUID.Location = new System.Drawing.Point(97, 98);
			this.deviceGUID.Name = "deviceGUID";
			this.deviceGUID.ReadOnly = true;
			this.deviceGUID.Size = new System.Drawing.Size(162, 20);
			this.deviceGUID.TabIndex = 3;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 101);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(74, 13);
			this.label5.TabIndex = 2;
			this.label5.Text = "Device GUID:";
			// 
			// deviceName
			// 
			this.deviceName.Location = new System.Drawing.Point(97, 16);
			this.deviceName.Name = "deviceName";
			this.deviceName.ReadOnly = true;
			this.deviceName.Size = new System.Drawing.Size(162, 20);
			this.deviceName.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name:";
			// 
			// activeMapping
			// 
			this.activeMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.activeMapping.AutoSize = true;
			this.activeMapping.Location = new System.Drawing.Point(70, 409);
			this.activeMapping.Name = "activeMapping";
			this.activeMapping.Size = new System.Drawing.Size(63, 13);
			this.activeMapping.TabIndex = 82;
			this.activeMapping.Text = "Unassigned";
			// 
			// editBtn
			// 
			this.editBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.editBtn.Location = new System.Drawing.Point(180, 406);
			this.editBtn.Name = "editBtn";
			this.editBtn.Size = new System.Drawing.Size(75, 21);
			this.editBtn.TabIndex = 83;
			this.editBtn.Text = "Edit...";
			this.editBtn.UseVisualStyleBackColor = true;
			this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
			// 
			// unmapBtn
			// 
			this.unmapBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.unmapBtn.Location = new System.Drawing.Point(162, 406);
			this.unmapBtn.Name = "unmapBtn";
			this.unmapBtn.Size = new System.Drawing.Size(15, 21);
			this.unmapBtn.TabIndex = 84;
			this.unmapBtn.Text = "X";
			this.unmapBtn.UseVisualStyleBackColor = true;
			this.unmapBtn.Click += new System.EventHandler(this.unmapBtn_Click);
			// 
			// padView
			// 
			this.padView.Location = new System.Drawing.Point(-2, 3);
			this.padView.Name = "padView";
			this.padView.Size = new System.Drawing.Size(258, 286);
			this.padView.TabIndex = 85;
			// 
			// PadSettingsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.padView);
			this.Controls.Add(this.unmapBtn);
			this.Controls.Add(this.editBtn);
			this.Controls.Add(this.activeMapping);
			this.Controls.Add(this.currentMappings);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tabControl1);
			this.MinimumSize = new System.Drawing.Size(550, 381);
			this.Name = "PadSettingsControl";
			this.Size = new System.Drawing.Size(550, 442);
			this.Load += new System.EventHandler(this.PadSettingsControl_Load);
			this.tabPage2.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Button changeBtn;
		private System.Windows.Forms.Button wizardBtn;
		private System.Windows.Forms.ListBox buttonMappings;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TreeView actionTree;
		private System.Windows.Forms.TreeView currentMappings;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Button mapButton;
		private System.Windows.Forms.Label activeMapping;
		private System.Windows.Forms.Button editBtn;
		private System.Windows.Forms.Button unmapBtn;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TextBox deviceFeedback;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox deviceHats;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox deviceAxes;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox deviceButtons;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox deviceProductID;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox deviceVendorID;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox deviceInstanceGUID;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox deviceGUID;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox deviceName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox devicePadNum;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Button button1;
		private ControllerView padView;
	}
}
