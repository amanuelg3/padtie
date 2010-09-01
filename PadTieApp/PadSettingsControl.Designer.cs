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
			this.components = new System.ComponentModel.Container();
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
			this.tabMappings = new System.Windows.Forms.TabPage();
			this.changeBtn = new System.Windows.Forms.Button();
			this.wizardBtn = new System.Windows.Forms.Button();
			this.buttonMappings = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tabActions = new System.Windows.Forms.TabPage();
			this.mapButton = new System.Windows.Forms.Button();
			this.actionTree = new System.Windows.Forms.TreeView();
			this.actionTip = new System.Windows.Forms.Label();
			this.currentMappings = new System.Windows.Forms.TreeView();
			this.tabs = new System.Windows.Forms.TabControl();
			this.tabButtons = new System.Windows.Forms.TabPage();
			this.unmapBtn = new System.Windows.Forms.Button();
			this.editBtn = new System.Windows.Forms.Button();
			this.activeMapping = new System.Windows.Forms.Label();
			this.tabNotes = new System.Windows.Forms.TabPage();
			this.resetLabelBtn = new System.Windows.Forms.Button();
			this.deviceLabel = new System.Windows.Forms.TextBox();
			this.labelLbl = new System.Windows.Forms.Label();
			this.padNotes = new System.Windows.Forms.TextBox();
			this.tabInfo = new System.Windows.Forms.TabPage();
			this.label14 = new System.Windows.Forms.Label();
			this.deviceButtons = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.deviceProductID = new System.Windows.Forms.TextBox();
			this.deviceVendorID = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.deviceInstanceGUID = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.deviceGUID = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.remapPad = new System.Windows.Forms.Button();
			this.slotMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.linkContextMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.editLinkMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.replaceLinkMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.clearLinkMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.tapContextMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.editTapMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.replaceTapMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.clearTapMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.dtapContextMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.editDTapMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.replaceDoubleTapMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.clearDTapMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.holdContextMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.editHoldMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.replaceHoldMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.clearHoldMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.clearAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.deviceName = new System.Windows.Forms.Label();
			this.productName = new System.Windows.Forms.Label();
			this.buttonTabPanel = new System.Windows.Forms.Panel();
			this.actionsTabPanel = new System.Windows.Forms.Panel();
			this.mappingsTabPanel = new System.Windows.Forms.Panel();
			this.padTabPanel = new System.Windows.Forms.Panel();
			this.infoTabPanel = new System.Windows.Forms.Panel();
			this.padView = new PadTieApp.ControllerView();
			this.tabMappings.SuspendLayout();
			this.tabActions.SuspendLayout();
			this.tabs.SuspendLayout();
			this.tabButtons.SuspendLayout();
			this.tabNotes.SuspendLayout();
			this.tabInfo.SuspendLayout();
			this.slotMenu.SuspendLayout();
			this.buttonTabPanel.SuspendLayout();
			this.actionsTabPanel.SuspendLayout();
			this.mappingsTabPanel.SuspendLayout();
			this.padTabPanel.SuspendLayout();
			this.infoTabPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabMappings
			// 
			this.tabMappings.Controls.Add(this.mappingsTabPanel);
			this.tabMappings.Location = new System.Drawing.Point(4, 22);
			this.tabMappings.Name = "tabMappings";
			this.tabMappings.Padding = new System.Windows.Forms.Padding(3);
			this.tabMappings.Size = new System.Drawing.Size(258, 292);
			this.tabMappings.TabIndex = 1;
			this.tabMappings.Text = "Mappings";
			this.tabMappings.UseVisualStyleBackColor = true;
			// 
			// changeBtn
			// 
			this.changeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.changeBtn.Location = new System.Drawing.Point(177, 261);
			this.changeBtn.Name = "changeBtn";
			this.changeBtn.Size = new System.Drawing.Size(75, 23);
			this.changeBtn.TabIndex = 3;
			this.changeBtn.Text = "Remap...";
			this.changeBtn.UseVisualStyleBackColor = true;
			this.changeBtn.Click += new System.EventHandler(this.changeBtn_Click);
			// 
			// wizardBtn
			// 
			this.wizardBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.wizardBtn.Location = new System.Drawing.Point(6, 261);
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
			this.buttonMappings.Location = new System.Drawing.Point(6, 83);
			this.buttonMappings.Name = "buttonMappings";
			this.buttonMappings.Size = new System.Drawing.Size(246, 160);
			this.buttonMappings.TabIndex = 1;
			this.buttonMappings.DoubleClick += new System.EventHandler(this.buttonMappings_DoubleClick);
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Location = new System.Drawing.Point(5, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(247, 67);
			this.label3.TabIndex = 0;
			this.label3.Text = resources.GetString("label3.Text");
			// 
			// tabActions
			// 
			this.tabActions.Controls.Add(this.actionsTabPanel);
			this.tabActions.Location = new System.Drawing.Point(4, 22);
			this.tabActions.Name = "tabActions";
			this.tabActions.Padding = new System.Windows.Forms.Padding(3);
			this.tabActions.Size = new System.Drawing.Size(258, 292);
			this.tabActions.TabIndex = 0;
			this.tabActions.Text = "Actions";
			// 
			// mapButton
			// 
			this.mapButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.mapButton.Location = new System.Drawing.Point(177, 265);
			this.mapButton.Name = "mapButton";
			this.mapButton.Size = new System.Drawing.Size(75, 21);
			this.mapButton.TabIndex = 7;
			this.mapButton.Text = "Add...";
			this.mapButton.UseVisualStyleBackColor = true;
			this.mapButton.Click += new System.EventHandler(this.mapButton_Click);
			// 
			// actionTree
			// 
			this.actionTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.actionTree.Location = new System.Drawing.Point(6, 6);
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
			treeNode7.ToolTipText = "run-command";
			treeNode8.Name = "Node12";
			treeNode8.Tag = "open-file";
			treeNode8.Text = "Open file";
			treeNode8.ToolTipText = "open-file";
			treeNode9.Name = "Node8";
			treeNode9.Tag = "load-config";
			treeNode9.Text = "Load Configuration";
			treeNode9.ToolTipText = "load-config";
			treeNode10.Name = "Node9";
			treeNode10.Tag = "exit";
			treeNode10.Text = "Exit Pad Tie";
			treeNode10.ToolTipText = "exit-pad-tie";
			treeNode11.Name = "Node10";
			treeNode11.Text = "Actions";
			this.actionTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode6,
            treeNode11});
			this.actionTree.Size = new System.Drawing.Size(246, 217);
			this.actionTree.TabIndex = 5;
			this.actionTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.actionTree_AfterSelect);
			this.actionTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.actionTree_NodeMouseDoubleClick);
			// 
			// actionTip
			// 
			this.actionTip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.actionTip.Location = new System.Drawing.Point(6, 226);
			this.actionTip.Name = "actionTip";
			this.actionTip.Size = new System.Drawing.Size(246, 60);
			this.actionTip.TabIndex = 8;
			this.actionTip.Text = "Click an action type above for a short description here.";
			// 
			// currentMappings
			// 
			this.currentMappings.AllowDrop = true;
			this.currentMappings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.currentMappings.HideSelection = false;
			this.currentMappings.Location = new System.Drawing.Point(6, 6);
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
			this.currentMappings.Size = new System.Drawing.Size(245, 196);
			this.currentMappings.TabIndex = 55;
			this.currentMappings.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.currentMappings_AfterSelect);
			this.currentMappings.DoubleClick += new System.EventHandler(this.currentMappings_DoubleClick);
			// 
			// tabs
			// 
			this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabs.Controls.Add(this.tabButtons);
			this.tabs.Controls.Add(this.tabActions);
			this.tabs.Controls.Add(this.tabMappings);
			this.tabs.Controls.Add(this.tabNotes);
			this.tabs.Controls.Add(this.tabInfo);
			this.tabs.Location = new System.Drawing.Point(262, 7);
			this.tabs.Name = "tabs";
			this.tabs.SelectedIndex = 0;
			this.tabs.Size = new System.Drawing.Size(266, 318);
			this.tabs.TabIndex = 54;
			// 
			// tabButtons
			// 
			this.tabButtons.Controls.Add(this.buttonTabPanel);
			this.tabButtons.Location = new System.Drawing.Point(4, 22);
			this.tabButtons.Name = "tabButtons";
			this.tabButtons.Padding = new System.Windows.Forms.Padding(3);
			this.tabButtons.Size = new System.Drawing.Size(258, 292);
			this.tabButtons.TabIndex = 3;
			this.tabButtons.Text = "Buttons";
			this.tabButtons.UseVisualStyleBackColor = true;
			this.tabButtons.Click += new System.EventHandler(this.tabPage4_Click);
			// 
			// unmapBtn
			// 
			this.unmapBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.unmapBtn.Location = new System.Drawing.Point(125, 268);
			this.unmapBtn.Name = "unmapBtn";
			this.unmapBtn.Size = new System.Drawing.Size(46, 21);
			this.unmapBtn.TabIndex = 84;
			this.unmapBtn.Text = "Clear";
			this.unmapBtn.UseVisualStyleBackColor = true;
			this.unmapBtn.Click += new System.EventHandler(this.unmapBtn_Click);
			// 
			// editBtn
			// 
			this.editBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.editBtn.Location = new System.Drawing.Point(177, 268);
			this.editBtn.Name = "editBtn";
			this.editBtn.Size = new System.Drawing.Size(75, 21);
			this.editBtn.TabIndex = 83;
			this.editBtn.Text = "Edit...";
			this.editBtn.UseVisualStyleBackColor = true;
			this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
			// 
			// activeMapping
			// 
			this.activeMapping.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.activeMapping.Location = new System.Drawing.Point(6, 205);
			this.activeMapping.Name = "activeMapping";
			this.activeMapping.Size = new System.Drawing.Size(245, 84);
			this.activeMapping.TabIndex = 82;
			this.activeMapping.Text = "Unassigned";
			// 
			// tabNotes
			// 
			this.tabNotes.Controls.Add(this.padTabPanel);
			this.tabNotes.Location = new System.Drawing.Point(4, 22);
			this.tabNotes.Name = "tabNotes";
			this.tabNotes.Padding = new System.Windows.Forms.Padding(3);
			this.tabNotes.Size = new System.Drawing.Size(258, 292);
			this.tabNotes.TabIndex = 4;
			this.tabNotes.Text = "Pad";
			this.tabNotes.UseVisualStyleBackColor = true;
			// 
			// resetLabelBtn
			// 
			this.resetLabelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.resetLabelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.resetLabelBtn.Location = new System.Drawing.Point(191, 7);
			this.resetLabelBtn.Name = "resetLabelBtn";
			this.resetLabelBtn.Size = new System.Drawing.Size(61, 20);
			this.resetLabelBtn.TabIndex = 19;
			this.resetLabelBtn.Text = "Reset";
			this.resetLabelBtn.UseVisualStyleBackColor = true;
			this.resetLabelBtn.Click += new System.EventHandler(this.resetLabelBtn_Click);
			// 
			// deviceLabel
			// 
			this.deviceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.deviceLabel.Location = new System.Drawing.Point(49, 7);
			this.deviceLabel.Name = "deviceLabel";
			this.deviceLabel.Size = new System.Drawing.Size(136, 20);
			this.deviceLabel.TabIndex = 2;
			this.deviceLabel.TextChanged += new System.EventHandler(this.deviceLabel_TextChanged);
			this.deviceLabel.Enter += new System.EventHandler(this.deviceLabel_Enter);
			this.deviceLabel.Leave += new System.EventHandler(this.deviceLabel_Leave);
			// 
			// labelLbl
			// 
			this.labelLbl.AutoSize = true;
			this.labelLbl.Location = new System.Drawing.Point(7, 10);
			this.labelLbl.Name = "labelLbl";
			this.labelLbl.Size = new System.Drawing.Size(36, 13);
			this.labelLbl.TabIndex = 1;
			this.labelLbl.Text = "Label:";
			// 
			// padNotes
			// 
			this.padNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.padNotes.Location = new System.Drawing.Point(6, 33);
			this.padNotes.Multiline = true;
			this.padNotes.Name = "padNotes";
			this.padNotes.Size = new System.Drawing.Size(246, 253);
			this.padNotes.TabIndex = 0;
			this.padNotes.Leave += new System.EventHandler(this.padNotes_Leave);
			// 
			// tabInfo
			// 
			this.tabInfo.Controls.Add(this.deviceProductID);
			this.tabInfo.Controls.Add(this.infoTabPanel);
			this.tabInfo.Location = new System.Drawing.Point(4, 22);
			this.tabInfo.Name = "tabInfo";
			this.tabInfo.Padding = new System.Windows.Forms.Padding(3);
			this.tabInfo.Size = new System.Drawing.Size(258, 292);
			this.tabInfo.TabIndex = 2;
			this.tabInfo.Text = "Info";
			this.tabInfo.UseVisualStyleBackColor = true;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(6, 11);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(188, 13);
			this.label14.TabIndex = 21;
			this.label14.Text = "This information is for advanced users.";
			// 
			// deviceButtons
			// 
			this.deviceButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.deviceButtons.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.deviceButtons.Location = new System.Drawing.Point(97, 116);
			this.deviceButtons.Name = "deviceButtons";
			this.deviceButtons.ReadOnly = true;
			this.deviceButtons.Size = new System.Drawing.Size(154, 13);
			this.deviceButtons.TabIndex = 11;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(6, 119);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(40, 13);
			this.label9.TabIndex = 10;
			this.label9.Text = "Specs:";
			// 
			// deviceProductID
			// 
			this.deviceProductID.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.deviceProductID.Location = new System.Drawing.Point(177, 37);
			this.deviceProductID.Name = "deviceProductID";
			this.deviceProductID.ReadOnly = true;
			this.deviceProductID.Size = new System.Drawing.Size(74, 13);
			this.deviceProductID.TabIndex = 9;
			// 
			// deviceVendorID
			// 
			this.deviceVendorID.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.deviceVendorID.Location = new System.Drawing.Point(97, 38);
			this.deviceVendorID.Name = "deviceVendorID";
			this.deviceVendorID.ReadOnly = true;
			this.deviceVendorID.Size = new System.Drawing.Size(74, 13);
			this.deviceVendorID.TabIndex = 7;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 41);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(86, 13);
			this.label7.TabIndex = 6;
			this.label7.Text = "Vendor/Product:";
			// 
			// deviceInstanceGUID
			// 
			this.deviceInstanceGUID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.deviceInstanceGUID.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.deviceInstanceGUID.Location = new System.Drawing.Point(97, 90);
			this.deviceInstanceGUID.Name = "deviceInstanceGUID";
			this.deviceInstanceGUID.ReadOnly = true;
			this.deviceInstanceGUID.Size = new System.Drawing.Size(154, 13);
			this.deviceInstanceGUID.TabIndex = 5;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 93);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(81, 13);
			this.label6.TabIndex = 4;
			this.label6.Text = "Instance GUID:";
			// 
			// deviceGUID
			// 
			this.deviceGUID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.deviceGUID.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.deviceGUID.Location = new System.Drawing.Point(97, 64);
			this.deviceGUID.Name = "deviceGUID";
			this.deviceGUID.ReadOnly = true;
			this.deviceGUID.Size = new System.Drawing.Size(154, 13);
			this.deviceGUID.TabIndex = 3;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 67);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(74, 13);
			this.label5.TabIndex = 2;
			this.label5.Text = "Device GUID:";
			// 
			// remapPad
			// 
			this.remapPad.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.remapPad.Location = new System.Drawing.Point(69, 291);
			this.remapPad.Name = "remapPad";
			this.remapPad.Size = new System.Drawing.Size(123, 24);
			this.remapPad.TabIndex = 18;
			this.remapPad.Text = "Change pad number...";
			this.toolTip.SetToolTip(this.remapPad, "Most layouts include actions for one or two gamepads. The pad number indicates wh" +
					"ich pad settings to apply to this device.");
			this.remapPad.UseVisualStyleBackColor = true;
			this.remapPad.Click += new System.EventHandler(this.remapPad_Click);
			// 
			// slotMenu
			// 
			this.slotMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linkContextMenu,
            this.tapContextMenu,
            this.dtapContextMenu,
            this.holdContextMenu,
            this.toolStripMenuItem1,
            this.clearAllMenuItem});
			this.slotMenu.Name = "slotMenu";
			this.slotMenu.Size = new System.Drawing.Size(133, 120);
			// 
			// linkContextMenu
			// 
			this.linkContextMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editLinkMenu,
            this.replaceLinkMenu,
            this.clearLinkMenu});
			this.linkContextMenu.Name = "linkContextMenu";
			this.linkContextMenu.Size = new System.Drawing.Size(132, 22);
			this.linkContextMenu.Text = "Link:";
			// 
			// editLinkMenu
			// 
			this.editLinkMenu.Name = "editLinkMenu";
			this.editLinkMenu.Size = new System.Drawing.Size(124, 22);
			this.editLinkMenu.Text = "Edit...";
			this.editLinkMenu.Click += new System.EventHandler(this.editLinkMenu_Click);
			// 
			// replaceLinkMenu
			// 
			this.replaceLinkMenu.Name = "replaceLinkMenu";
			this.replaceLinkMenu.Size = new System.Drawing.Size(124, 22);
			this.replaceLinkMenu.Text = "Replace...";
			this.replaceLinkMenu.Click += new System.EventHandler(this.replaceLinkMenu_Click);
			// 
			// clearLinkMenu
			// 
			this.clearLinkMenu.Name = "clearLinkMenu";
			this.clearLinkMenu.Size = new System.Drawing.Size(124, 22);
			this.clearLinkMenu.Text = "Clear";
			this.clearLinkMenu.Click += new System.EventHandler(this.clearLinkMenu_Click);
			// 
			// tapContextMenu
			// 
			this.tapContextMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editTapMenu,
            this.replaceTapMenu,
            this.clearTapMenu});
			this.tapContextMenu.Name = "tapContextMenu";
			this.tapContextMenu.Size = new System.Drawing.Size(132, 22);
			this.tapContextMenu.Text = "Tap:";
			// 
			// editTapMenu
			// 
			this.editTapMenu.Name = "editTapMenu";
			this.editTapMenu.Size = new System.Drawing.Size(124, 22);
			this.editTapMenu.Text = "Edit...";
			this.editTapMenu.Click += new System.EventHandler(this.editTapMenu_Click);
			// 
			// replaceTapMenu
			// 
			this.replaceTapMenu.Name = "replaceTapMenu";
			this.replaceTapMenu.Size = new System.Drawing.Size(124, 22);
			this.replaceTapMenu.Text = "Replace...";
			this.replaceTapMenu.Click += new System.EventHandler(this.replaceTapMenu_Click);
			// 
			// clearTapMenu
			// 
			this.clearTapMenu.Name = "clearTapMenu";
			this.clearTapMenu.Size = new System.Drawing.Size(124, 22);
			this.clearTapMenu.Text = "Clear";
			this.clearTapMenu.Click += new System.EventHandler(this.clearTapMenu_Click);
			// 
			// dtapContextMenu
			// 
			this.dtapContextMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editDTapMenu,
            this.replaceDoubleTapMenu,
            this.clearDTapMenu});
			this.dtapContextMenu.Name = "dtapContextMenu";
			this.dtapContextMenu.Size = new System.Drawing.Size(132, 22);
			this.dtapContextMenu.Text = "Double Tap:";
			// 
			// editDTapMenu
			// 
			this.editDTapMenu.Name = "editDTapMenu";
			this.editDTapMenu.Size = new System.Drawing.Size(124, 22);
			this.editDTapMenu.Text = "Edit...";
			this.editDTapMenu.Click += new System.EventHandler(this.editDTapMenu_Click);
			// 
			// replaceDoubleTapMenu
			// 
			this.replaceDoubleTapMenu.Name = "replaceDoubleTapMenu";
			this.replaceDoubleTapMenu.Size = new System.Drawing.Size(124, 22);
			this.replaceDoubleTapMenu.Text = "Replace...";
			this.replaceDoubleTapMenu.Click += new System.EventHandler(this.replaceDoubleTapMenu_Click);
			// 
			// clearDTapMenu
			// 
			this.clearDTapMenu.Name = "clearDTapMenu";
			this.clearDTapMenu.Size = new System.Drawing.Size(124, 22);
			this.clearDTapMenu.Text = "Clear";
			this.clearDTapMenu.Click += new System.EventHandler(this.clearDTapMenu_Click);
			// 
			// holdContextMenu
			// 
			this.holdContextMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editHoldMenu,
            this.replaceHoldMenu,
            this.clearHoldMenu});
			this.holdContextMenu.Name = "holdContextMenu";
			this.holdContextMenu.Size = new System.Drawing.Size(132, 22);
			this.holdContextMenu.Text = "Hold:";
			// 
			// editHoldMenu
			// 
			this.editHoldMenu.Name = "editHoldMenu";
			this.editHoldMenu.Size = new System.Drawing.Size(124, 22);
			this.editHoldMenu.Text = "Edit...";
			this.editHoldMenu.Click += new System.EventHandler(this.editHoldMenu_Click);
			// 
			// replaceHoldMenu
			// 
			this.replaceHoldMenu.Name = "replaceHoldMenu";
			this.replaceHoldMenu.Size = new System.Drawing.Size(124, 22);
			this.replaceHoldMenu.Text = "Replace...";
			this.replaceHoldMenu.Click += new System.EventHandler(this.replaceHoldMenu_Click);
			// 
			// clearHoldMenu
			// 
			this.clearHoldMenu.Name = "clearHoldMenu";
			this.clearHoldMenu.Size = new System.Drawing.Size(124, 22);
			this.clearHoldMenu.Text = "Clear";
			this.clearHoldMenu.Click += new System.EventHandler(this.clearHoldMenu_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(129, 6);
			// 
			// clearAllMenuItem
			// 
			this.clearAllMenuItem.Name = "clearAllMenuItem";
			this.clearAllMenuItem.Size = new System.Drawing.Size(132, 22);
			this.clearAllMenuItem.Text = "Clear All";
			this.clearAllMenuItem.Click += new System.EventHandler(this.clearAllMenuItem_Click);
			// 
			// toolTip
			// 
			this.toolTip.IsBalloon = true;
			// 
			// deviceName
			// 
			this.deviceName.AutoSize = true;
			this.deviceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.deviceName.Location = new System.Drawing.Point(3, 6);
			this.deviceName.Name = "deviceName";
			this.deviceName.Size = new System.Drawing.Size(156, 20);
			this.deviceName.TabIndex = 86;
			this.deviceName.Text = "Logitech Dual Action";
			// 
			// productName
			// 
			this.productName.AutoSize = true;
			this.productName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.productName.Location = new System.Drawing.Point(13, 29);
			this.productName.Name = "productName";
			this.productName.Size = new System.Drawing.Size(104, 13);
			this.productName.TabIndex = 88;
			this.productName.Text = "Logitech Dual Action";
			// 
			// buttonTabPanel
			// 
			this.buttonTabPanel.Controls.Add(this.currentMappings);
			this.buttonTabPanel.Controls.Add(this.unmapBtn);
			this.buttonTabPanel.Controls.Add(this.editBtn);
			this.buttonTabPanel.Controls.Add(this.activeMapping);
			this.buttonTabPanel.Location = new System.Drawing.Point(0, 0);
			this.buttonTabPanel.Name = "buttonTabPanel";
			this.buttonTabPanel.Size = new System.Drawing.Size(258, 292);
			this.buttonTabPanel.TabIndex = 88;
			// 
			// actionsTabPanel
			// 
			this.actionsTabPanel.Controls.Add(this.mapButton);
			this.actionsTabPanel.Controls.Add(this.actionTree);
			this.actionsTabPanel.Controls.Add(this.actionTip);
			this.actionsTabPanel.Location = new System.Drawing.Point(0, 0);
			this.actionsTabPanel.Name = "actionsTabPanel";
			this.actionsTabPanel.Size = new System.Drawing.Size(255, 292);
			this.actionsTabPanel.TabIndex = 9;
			// 
			// mappingsTabPanel
			// 
			this.mappingsTabPanel.Controls.Add(this.changeBtn);
			this.mappingsTabPanel.Controls.Add(this.buttonMappings);
			this.mappingsTabPanel.Controls.Add(this.wizardBtn);
			this.mappingsTabPanel.Controls.Add(this.label3);
			this.mappingsTabPanel.Location = new System.Drawing.Point(0, 0);
			this.mappingsTabPanel.Name = "mappingsTabPanel";
			this.mappingsTabPanel.Size = new System.Drawing.Size(258, 292);
			this.mappingsTabPanel.TabIndex = 4;
			// 
			// padTabPanel
			// 
			this.padTabPanel.Controls.Add(this.resetLabelBtn);
			this.padTabPanel.Controls.Add(this.padNotes);
			this.padTabPanel.Controls.Add(this.deviceLabel);
			this.padTabPanel.Controls.Add(this.labelLbl);
			this.padTabPanel.Location = new System.Drawing.Point(0, 0);
			this.padTabPanel.Name = "padTabPanel";
			this.padTabPanel.Size = new System.Drawing.Size(258, 292);
			this.padTabPanel.TabIndex = 20;
			// 
			// infoTabPanel
			// 
			this.infoTabPanel.Controls.Add(this.label14);
			this.infoTabPanel.Controls.Add(this.deviceButtons);
			this.infoTabPanel.Controls.Add(this.label5);
			this.infoTabPanel.Controls.Add(this.label9);
			this.infoTabPanel.Controls.Add(this.deviceGUID);
			this.infoTabPanel.Controls.Add(this.label6);
			this.infoTabPanel.Controls.Add(this.deviceVendorID);
			this.infoTabPanel.Controls.Add(this.deviceInstanceGUID);
			this.infoTabPanel.Controls.Add(this.label7);
			this.infoTabPanel.Location = new System.Drawing.Point(0, 0);
			this.infoTabPanel.Name = "infoTabPanel";
			this.infoTabPanel.Size = new System.Drawing.Size(258, 292);
			this.infoTabPanel.TabIndex = 22;
			// 
			// padView
			// 
			this.padView.ContextMenuStrip = this.slotMenu;
			this.padView.Location = new System.Drawing.Point(1, 65);
			this.padView.Margin = new System.Windows.Forms.Padding(4);
			this.padView.MaximumSize = new System.Drawing.Size(258, 287);
			this.padView.MinimumSize = new System.Drawing.Size(258, 287);
			this.padView.Name = "padView";
			this.padView.SelectedItem = null;
			this.padView.Size = new System.Drawing.Size(258, 287);
			this.padView.TabIndex = 85;
			this.padView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.padView_MouseDown);
			this.padView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.padView_MouseUp);
			// 
			// PadSettingsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.productName);
			this.Controls.Add(this.remapPad);
			this.Controls.Add(this.deviceName);
			this.Controls.Add(this.tabs);
			this.Controls.Add(this.padView);
			this.MinimumSize = new System.Drawing.Size(532, 329);
			this.Name = "PadSettingsControl";
			this.Size = new System.Drawing.Size(532, 329);
			this.Load += new System.EventHandler(this.PadSettingsControl_Load);
			this.VisibleChanged += new System.EventHandler(this.PadSettingsControl_VisibleChanged);
			this.tabMappings.ResumeLayout(false);
			this.tabActions.ResumeLayout(false);
			this.tabs.ResumeLayout(false);
			this.tabButtons.ResumeLayout(false);
			this.tabNotes.ResumeLayout(false);
			this.tabInfo.ResumeLayout(false);
			this.tabInfo.PerformLayout();
			this.slotMenu.ResumeLayout(false);
			this.buttonTabPanel.ResumeLayout(false);
			this.actionsTabPanel.ResumeLayout(false);
			this.mappingsTabPanel.ResumeLayout(false);
			this.padTabPanel.ResumeLayout(false);
			this.padTabPanel.PerformLayout();
			this.infoTabPanel.ResumeLayout(false);
			this.infoTabPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabPage tabMappings;
		private System.Windows.Forms.Button changeBtn;
		private System.Windows.Forms.Button wizardBtn;
		private System.Windows.Forms.ListBox buttonMappings;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TabPage tabActions;
		private System.Windows.Forms.TreeView actionTree;
		private System.Windows.Forms.TreeView currentMappings;
		private System.Windows.Forms.TabControl tabs;
		private System.Windows.Forms.Button mapButton;
		private System.Windows.Forms.Label activeMapping;
		private System.Windows.Forms.Button editBtn;
		private System.Windows.Forms.Button unmapBtn;
		private System.Windows.Forms.TabPage tabInfo;
		private System.Windows.Forms.TextBox deviceButtons;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox deviceProductID;
		private System.Windows.Forms.TextBox deviceVendorID;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox deviceInstanceGUID;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox deviceGUID;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button remapPad;
		private global::PadTieApp.ControllerView padView;
		private System.Windows.Forms.ContextMenuStrip slotMenu;
		private System.Windows.Forms.ToolStripMenuItem tapContextMenu;
		private System.Windows.Forms.ToolStripMenuItem editTapMenu;
		private System.Windows.Forms.ToolStripMenuItem clearTapMenu;
		private System.Windows.Forms.ToolStripMenuItem dtapContextMenu;
		private System.Windows.Forms.ToolStripMenuItem editDTapMenu;
		private System.Windows.Forms.ToolStripMenuItem clearDTapMenu;
		private System.Windows.Forms.ToolStripMenuItem linkContextMenu;
		private System.Windows.Forms.ToolStripMenuItem editLinkMenu;
		private System.Windows.Forms.ToolStripMenuItem clearLinkMenu;
		private System.Windows.Forms.ToolStripMenuItem holdContextMenu;
		private System.Windows.Forms.ToolStripMenuItem editHoldMenu;
		private System.Windows.Forms.ToolStripMenuItem clearHoldMenu;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem clearAllMenuItem;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label actionTip;
		private System.Windows.Forms.ToolStripMenuItem replaceLinkMenu;
		private System.Windows.Forms.ToolStripMenuItem replaceTapMenu;
		private System.Windows.Forms.ToolStripMenuItem replaceDoubleTapMenu;
		private System.Windows.Forms.ToolStripMenuItem replaceHoldMenu;
		private System.Windows.Forms.TabPage tabButtons;
		private System.Windows.Forms.TabPage tabNotes;
		private System.Windows.Forms.TextBox padNotes;
		private System.Windows.Forms.Button resetLabelBtn;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.TextBox deviceLabel;
		private System.Windows.Forms.Label labelLbl;
		private System.Windows.Forms.Label deviceName;
		private System.Windows.Forms.Label productName;
		private System.Windows.Forms.Panel mappingsTabPanel;
		private System.Windows.Forms.Panel actionsTabPanel;
		private System.Windows.Forms.Panel buttonTabPanel;
		private System.Windows.Forms.Panel padTabPanel;
		private System.Windows.Forms.Panel infoTabPanel;
	}
}
