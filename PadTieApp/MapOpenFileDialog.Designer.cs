namespace PadTieApp {
	partial class MapOpenFileDialog {
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
			this.label6 = new System.Windows.Forms.Label();
			this.onRelease = new System.Windows.Forms.RadioButton();
			this.onPress = new System.Windows.Forms.RadioButton();
			this.showError = new System.Windows.Forms.CheckBox();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.browseCmdBtn = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cmd = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.okBtn = new System.Windows.Forms.Button();
			this.slotCapture = new PadTieApp.PadSlotCaptureControl();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(10, 93);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(75, 13);
			this.label6.TabIndex = 11;
			this.label6.Text = "Action occurs:";
			// 
			// onRelease
			// 
			this.onRelease.AutoSize = true;
			this.onRelease.Location = new System.Drawing.Point(107, 116);
			this.onRelease.Name = "onRelease";
			this.onRelease.Size = new System.Drawing.Size(76, 17);
			this.onRelease.TabIndex = 13;
			this.onRelease.TabStop = true;
			this.onRelease.Text = "On release";
			this.onRelease.UseVisualStyleBackColor = true;
			// 
			// onPress
			// 
			this.onPress.AutoSize = true;
			this.onPress.Location = new System.Drawing.Point(107, 93);
			this.onPress.Name = "onPress";
			this.onPress.Size = new System.Drawing.Size(67, 17);
			this.onPress.TabIndex = 12;
			this.onPress.TabStop = true;
			this.onPress.Text = "On press";
			this.onPress.UseVisualStyleBackColor = true;
			// 
			// showError
			// 
			this.showError.AutoSize = true;
			this.showError.Location = new System.Drawing.Point(13, 139);
			this.showError.Name = "showError";
			this.showError.Size = new System.Drawing.Size(205, 17);
			this.showError.TabIndex = 14;
			this.showError.Text = "Show an error dialog if the action fails.";
			this.showError.UseVisualStyleBackColor = true;
			// 
			// cancelBtn
			// 
			this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.Location = new System.Drawing.Point(156, 291);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(75, 23);
			this.cancelBtn.TabIndex = 6;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
			// 
			// browseCmdBtn
			// 
			this.browseCmdBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.browseCmdBtn.Location = new System.Drawing.Point(270, 64);
			this.browseCmdBtn.Name = "browseCmdBtn";
			this.browseCmdBtn.Size = new System.Drawing.Size(25, 20);
			this.browseCmdBtn.TabIndex = 3;
			this.browseCmdBtn.Text = "...";
			this.browseCmdBtn.UseVisualStyleBackColor = true;
			this.browseCmdBtn.Click += new System.EventHandler(this.browseCmdBtn_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.onRelease);
			this.groupBox1.Controls.Add(this.onPress);
			this.groupBox1.Controls.Add(this.showError);
			this.groupBox1.Controls.Add(this.browseCmdBtn);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.cmd);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Location = new System.Drawing.Point(9, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(303, 167);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Run Command";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 66);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(26, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "File:";
			// 
			// cmd
			// 
			this.cmd.Location = new System.Drawing.Point(107, 64);
			this.cmd.Name = "cmd";
			this.cmd.Size = new System.Drawing.Size(157, 20);
			this.cmd.TabIndex = 2;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(291, 45);
			this.label5.TabIndex = 0;
			this.label5.Text = "Choose the command, arguments, and options below. Caution: The command will be ru" +
				"n each time the action is activated.";
			// 
			// okBtn
			// 
			this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.okBtn.Location = new System.Drawing.Point(237, 291);
			this.okBtn.Name = "okBtn";
			this.okBtn.Size = new System.Drawing.Size(75, 23);
			this.okBtn.TabIndex = 7;
			this.okBtn.Text = "OK";
			this.okBtn.UseVisualStyleBackColor = true;
			this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
			// 
			// slotCapture
			// 
			this.slotCapture.Controller = null;
			this.slotCapture.Location = new System.Drawing.Point(7, 179);
			this.slotCapture.MainForm = null;
			this.slotCapture.MaximumSize = new System.Drawing.Size(1000, 106);
			this.slotCapture.MinimumSize = new System.Drawing.Size(298, 106);
			this.slotCapture.Name = "slotCapture";
			this.slotCapture.Size = new System.Drawing.Size(310, 106);
			this.slotCapture.TabIndex = 5;
			this.slotCapture.Value = null;
			// 
			// MapOpenFileDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(324, 323);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.okBtn);
			this.Controls.Add(this.slotCapture);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "MapOpenFileDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add \'Open File\' action";
			this.Load += new System.EventHandler(this.MapOpenFileDialog_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.RadioButton onRelease;
		private System.Windows.Forms.RadioButton onPress;
		private System.Windows.Forms.CheckBox showError;
		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.Button browseCmdBtn;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox cmd;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button okBtn;
		private PadSlotCaptureControl slotCapture;
	}
}