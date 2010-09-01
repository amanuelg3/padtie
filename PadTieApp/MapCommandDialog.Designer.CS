namespace PadTieApp {
	partial class MapCommandDialog {
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
			this.cancelBtn = new System.Windows.Forms.Button();
			this.okBtn = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.onRelease = new System.Windows.Forms.RadioButton();
			this.onPress = new System.Windows.Forms.RadioButton();
			this.showError = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.startAs = new System.Windows.Forms.ComboBox();
			this.browseWorkDirBtn = new System.Windows.Forms.Button();
			this.workDir = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.browseCmdBtn = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.args = new System.Windows.Forms.TextBox();
			this.cmd = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.slotCapture = new PadTieApp.PadSlotCaptureControl();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cancelBtn
			// 
			this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.Location = new System.Drawing.Point(155, 362);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(75, 23);
			this.cancelBtn.TabIndex = 2;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
			// 
			// okBtn
			// 
			this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.okBtn.Location = new System.Drawing.Point(236, 362);
			this.okBtn.Name = "okBtn";
			this.okBtn.Size = new System.Drawing.Size(75, 23);
			this.okBtn.TabIndex = 3;
			this.okBtn.Text = "OK";
			this.okBtn.UseVisualStyleBackColor = true;
			this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.onRelease);
			this.groupBox1.Controls.Add(this.onPress);
			this.groupBox1.Controls.Add(this.showError);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.startAs);
			this.groupBox1.Controls.Add(this.browseWorkDirBtn);
			this.groupBox1.Controls.Add(this.workDir);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.browseCmdBtn);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.args);
			this.groupBox1.Controls.Add(this.cmd);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Location = new System.Drawing.Point(8, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(303, 240);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Run Command";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(10, 167);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(75, 13);
			this.label6.TabIndex = 11;
			this.label6.Text = "Action occurs:";
			// 
			// onRelease
			// 
			this.onRelease.AutoSize = true;
			this.onRelease.Location = new System.Drawing.Point(107, 190);
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
			this.onPress.Location = new System.Drawing.Point(107, 167);
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
			this.showError.Location = new System.Drawing.Point(13, 213);
			this.showError.Name = "showError";
			this.showError.Size = new System.Drawing.Size(222, 17);
			this.showError.TabIndex = 14;
			this.showError.Text = "Show an error dialog if the command fails.";
			this.showError.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(10, 143);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(46, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Start as:";
			// 
			// startAs
			// 
			this.startAs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.startAs.FormattingEnabled = true;
			this.startAs.Items.AddRange(new object[] {
            "Normal",
            "Maximized",
            "Minimized",
            "Hidden"});
			this.startAs.Location = new System.Drawing.Point(107, 140);
			this.startAs.Name = "startAs";
			this.startAs.Size = new System.Drawing.Size(157, 21);
			this.startAs.TabIndex = 10;
			// 
			// browseWorkDirBtn
			// 
			this.browseWorkDirBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.browseWorkDirBtn.Location = new System.Drawing.Point(270, 114);
			this.browseWorkDirBtn.Name = "browseWorkDirBtn";
			this.browseWorkDirBtn.Size = new System.Drawing.Size(25, 20);
			this.browseWorkDirBtn.TabIndex = 8;
			this.browseWorkDirBtn.Text = "...";
			this.browseWorkDirBtn.UseVisualStyleBackColor = true;
			this.browseWorkDirBtn.Click += new System.EventHandler(this.browseWorkDirBtn_Click);
			// 
			// workDir
			// 
			this.workDir.Location = new System.Drawing.Point(107, 114);
			this.workDir.Name = "workDir";
			this.workDir.Size = new System.Drawing.Size(157, 20);
			this.workDir.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 117);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(93, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Working directory:";
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
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 90);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Arguments:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 66);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Command:";
			// 
			// args
			// 
			this.args.Location = new System.Drawing.Point(107, 88);
			this.args.Name = "args";
			this.args.Size = new System.Drawing.Size(157, 20);
			this.args.TabIndex = 5;
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
			// slotCapture
			// 
			this.slotCapture.Controller = null;
			this.slotCapture.Location = new System.Drawing.Point(8, 250);
			this.slotCapture.MainForm = null;
			this.slotCapture.MaximumSize = new System.Drawing.Size(1000, 106);
			this.slotCapture.MinimumSize = new System.Drawing.Size(298, 106);
			this.slotCapture.Name = "slotCapture";
			this.slotCapture.Size = new System.Drawing.Size(310, 106);
			this.slotCapture.TabIndex = 1;
			this.slotCapture.Value = null;
			// 
			// MapCommandDialog
			// 
			this.AcceptButton = this.okBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelBtn;
			this.ClientSize = new System.Drawing.Size(323, 393);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.okBtn);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.slotCapture);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "MapCommandDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add \'Run Command\' action";
			this.Load += new System.EventHandler(this.MapCommandDialog_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.Button okBtn;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox args;
		private System.Windows.Forms.TextBox cmd;
		private PadSlotCaptureControl slotCapture;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox startAs;
		private System.Windows.Forms.Button browseWorkDirBtn;
		private System.Windows.Forms.TextBox workDir;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button browseCmdBtn;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.RadioButton onRelease;
		private System.Windows.Forms.RadioButton onPress;
		private System.Windows.Forms.CheckBox showError;
	}
}