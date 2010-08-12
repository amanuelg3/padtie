namespace PadTieApp {
	partial class PadSlotCaptureControl {
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
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.gestureBox = new System.Windows.Forms.ComboBox();
			this.lblGesture = new System.Windows.Forms.Label();
			this.captureButton = new System.Windows.Forms.Button();
			this.lblSlot = new System.Windows.Forms.Label();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.gestureBox);
			this.groupBox2.Controls.Add(this.lblGesture);
			this.groupBox2.Controls.Add(this.captureButton);
			this.groupBox2.Controls.Add(this.lblSlot);
			this.groupBox2.Location = new System.Drawing.Point(3, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(290, 71);
			this.groupBox2.TabIndex = 9;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Pad";
			// 
			// gestureBox
			// 
			this.gestureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.gestureBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.gestureBox.FormattingEnabled = true;
			this.gestureBox.Items.AddRange(new object[] {
            "Link",
            "Tap",
            "Double Tap",
            "Hold"});
			this.gestureBox.Location = new System.Drawing.Point(59, 44);
			this.gestureBox.Name = "gestureBox";
			this.gestureBox.Size = new System.Drawing.Size(220, 21);
			this.gestureBox.TabIndex = 9;
			this.gestureBox.Visible = false;
			this.gestureBox.SelectedIndexChanged += new System.EventHandler(this.gestureBox_SelectedIndexChanged);
			// 
			// lblGesture
			// 
			this.lblGesture.AutoSize = true;
			this.lblGesture.Location = new System.Drawing.Point(6, 45);
			this.lblGesture.Name = "lblGesture";
			this.lblGesture.Size = new System.Drawing.Size(47, 13);
			this.lblGesture.TabIndex = 8;
			this.lblGesture.Text = "Gesture:";
			this.lblGesture.Visible = false;
			// 
			// captureButton
			// 
			this.captureButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.captureButton.Location = new System.Drawing.Point(204, 16);
			this.captureButton.Name = "captureButton";
			this.captureButton.Size = new System.Drawing.Size(75, 23);
			this.captureButton.TabIndex = 7;
			this.captureButton.Text = "Capture";
			this.captureButton.UseVisualStyleBackColor = true;
			this.captureButton.Click += new System.EventHandler(this.captureButton_Click);
			// 
			// lblSlot
			// 
			this.lblSlot.AutoSize = true;
			this.lblSlot.Location = new System.Drawing.Point(6, 16);
			this.lblSlot.Name = "lblSlot";
			this.lblSlot.Size = new System.Drawing.Size(87, 13);
			this.lblSlot.TabIndex = 6;
			this.lblSlot.Text = "Slot: Unassigned";
			// 
			// PadSlotCaptureControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox2);
			this.MaximumSize = new System.Drawing.Size(1000, 79);
			this.MinimumSize = new System.Drawing.Size(233, 79);
			this.Name = "PadSlotCaptureControl";
			this.Size = new System.Drawing.Size(298, 79);
			this.Load += new System.EventHandler(this.PadSlotCaptureControl_Load);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox gestureBox;
		private System.Windows.Forms.Label lblGesture;
		private System.Windows.Forms.Button captureButton;
		private System.Windows.Forms.Label lblSlot;
	}
}
