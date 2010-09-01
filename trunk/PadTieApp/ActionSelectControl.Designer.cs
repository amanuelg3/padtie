namespace PadTieApp {
	partial class ActionSelectControl {
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
			this.mapButton = new System.Windows.Forms.Button();
			this.actionTree = new System.Windows.Forms.TreeView();
			this.actionTip = new System.Windows.Forms.Label();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// mapButton
			// 
			this.mapButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.mapButton.Location = new System.Drawing.Point(212, 244);
			this.mapButton.Name = "mapButton";
			this.mapButton.Size = new System.Drawing.Size(75, 21);
			this.mapButton.TabIndex = 10;
			this.mapButton.Text = "Add...";
			this.mapButton.UseVisualStyleBackColor = true;
			this.mapButton.Click += new System.EventHandler(this.mapButton_Click);
			// 
			// actionTree
			// 
			this.actionTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.actionTree.Location = new System.Drawing.Point(3, 3);
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
			this.actionTree.Size = new System.Drawing.Size(281, 202);
			this.actionTree.TabIndex = 9;
			this.actionTree.DoubleClick += new System.EventHandler(this.actionTree_DoubleClick);
			// 
			// actionTip
			// 
			this.actionTip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.actionTip.Location = new System.Drawing.Point(3, 208);
			this.actionTip.Name = "actionTip";
			this.actionTip.Size = new System.Drawing.Size(281, 57);
			this.actionTip.TabIndex = 11;
			this.actionTip.Text = "Click an action type above for a short description here.";
			// 
			// cancelBtn
			// 
			this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn.Location = new System.Drawing.Point(131, 244);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(75, 21);
			this.cancelBtn.TabIndex = 12;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Visible = false;
			this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
			// 
			// ActionSelectControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.mapButton);
			this.Controls.Add(this.actionTree);
			this.Controls.Add(this.actionTip);
			this.Name = "ActionSelectControl";
			this.Size = new System.Drawing.Size(287, 268);
			this.Load += new System.EventHandler(this.ActionSelectControl_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button mapButton;
		private System.Windows.Forms.TreeView actionTree;
		private System.Windows.Forms.Label actionTip;
		private System.Windows.Forms.Button cancelBtn;
	}
}
