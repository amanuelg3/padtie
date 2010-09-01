namespace PadTieApp {
	partial class MapMouseWheelForm {
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
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.useIntensity = new System.Windows.Forms.CheckBox();
			this.continuous = new System.Windows.Forms.CheckBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.twoClicksUp = new System.Windows.Forms.Button();
			this.twoClicksDown = new System.Windows.Forms.Button();
			this.oneClickDown = new System.Windows.Forms.Button();
			this.oneClickUp = new System.Windows.Forms.Button();
			this.motion = new System.Windows.Forms.TextBox();
			this.okBtn = new System.Windows.Forms.Button();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.slotCapture = new PadTieApp.PadSlotCaptureControl();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 22);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(276, 30);
			this.label5.TabIndex = 18;
			this.label5.Text = "Pick a speed and click a direction or enter the X and Y manually (negative is lef" +
				"t/up, positive is right/down).";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(136, 77);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(37, 13);
			this.label4.TabIndex = 17;
			this.label4.Text = "Value:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.useIntensity);
			this.groupBox1.Controls.Add(this.continuous);
			this.groupBox1.Controls.Add(this.panel1);
			this.groupBox1.Controls.Add(this.twoClicksUp);
			this.groupBox1.Controls.Add(this.twoClicksDown);
			this.groupBox1.Controls.Add(this.oneClickDown);
			this.groupBox1.Controls.Add(this.oneClickUp);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.motion);
			this.groupBox1.Location = new System.Drawing.Point(7, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(288, 169);
			this.groupBox1.TabIndex = 16;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Mouse Wheel";
			// 
			// useIntensity
			// 
			this.useIntensity.AutoSize = true;
			this.useIntensity.Checked = true;
			this.useIntensity.CheckState = System.Windows.Forms.CheckState.Checked;
			this.useIntensity.Location = new System.Drawing.Point(136, 119);
			this.useIntensity.Name = "useIntensity";
			this.useIntensity.Size = new System.Drawing.Size(139, 17);
			this.useIntensity.TabIndex = 26;
			this.useIntensity.Text = "Use intensity if available";
			this.useIntensity.UseVisualStyleBackColor = true;
			// 
			// continuous
			// 
			this.continuous.AutoSize = true;
			this.continuous.Checked = true;
			this.continuous.CheckState = System.Windows.Forms.CheckState.Checked;
			this.continuous.Location = new System.Drawing.Point(136, 98);
			this.continuous.Name = "continuous";
			this.continuous.Size = new System.Drawing.Size(79, 17);
			this.continuous.TabIndex = 25;
			this.continuous.Text = "Continuous";
			this.continuous.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Black;
			this.panel1.Location = new System.Drawing.Point(14, 104);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(102, 2);
			this.panel1.TabIndex = 24;
			// 
			// twoClicksUp
			// 
			this.twoClicksUp.Location = new System.Drawing.Point(14, 53);
			this.twoClicksUp.Name = "twoClicksUp";
			this.twoClicksUp.Size = new System.Drawing.Size(102, 20);
			this.twoClicksUp.TabIndex = 23;
			this.twoClicksUp.Text = "Two clicks (^^)";
			this.twoClicksUp.UseVisualStyleBackColor = true;
			this.twoClicksUp.Click += new System.EventHandler(this.twoClicksUp_Click);
			// 
			// twoClicksDown
			// 
			this.twoClicksDown.Location = new System.Drawing.Point(14, 138);
			this.twoClicksDown.Name = "twoClicksDown";
			this.twoClicksDown.Size = new System.Drawing.Size(102, 20);
			this.twoClicksDown.TabIndex = 22;
			this.twoClicksDown.Text = "Two clicks (vv)";
			this.twoClicksDown.UseVisualStyleBackColor = true;
			this.twoClicksDown.Click += new System.EventHandler(this.twoClicksDown_Click);
			// 
			// oneClickDown
			// 
			this.oneClickDown.Location = new System.Drawing.Point(14, 114);
			this.oneClickDown.Name = "oneClickDown";
			this.oneClickDown.Size = new System.Drawing.Size(102, 20);
			this.oneClickDown.TabIndex = 21;
			this.oneClickDown.Text = "One click  (v)";
			this.oneClickDown.UseVisualStyleBackColor = true;
			this.oneClickDown.Click += new System.EventHandler(this.oneClickDown_Click);
			// 
			// oneClickUp
			// 
			this.oneClickUp.Location = new System.Drawing.Point(14, 77);
			this.oneClickUp.Name = "oneClickUp";
			this.oneClickUp.Size = new System.Drawing.Size(102, 20);
			this.oneClickUp.TabIndex = 20;
			this.oneClickUp.Text = "One click (^)";
			this.oneClickUp.UseVisualStyleBackColor = true;
			this.oneClickUp.Click += new System.EventHandler(this.oneClickUp_Click);
			// 
			// motion
			// 
			this.motion.Location = new System.Drawing.Point(174, 74);
			this.motion.Name = "motion";
			this.motion.Size = new System.Drawing.Size(57, 20);
			this.motion.TabIndex = 2;
			// 
			// okBtn
			// 
			this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.okBtn.Location = new System.Drawing.Point(223, 288);
			this.okBtn.Name = "okBtn";
			this.okBtn.Size = new System.Drawing.Size(75, 23);
			this.okBtn.TabIndex = 17;
			this.okBtn.Text = "OK";
			this.okBtn.UseVisualStyleBackColor = true;
			this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
			// 
			// cancelBtn
			// 
			this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.Location = new System.Drawing.Point(142, 288);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(75, 23);
			this.cancelBtn.TabIndex = 18;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
			// 
			// slotCapture
			// 
			this.slotCapture.Controller = null;
			this.slotCapture.Location = new System.Drawing.Point(5, 178);
			this.slotCapture.MainForm = null;
			this.slotCapture.MaximumSize = new System.Drawing.Size(1000, 106);
			this.slotCapture.MinimumSize = new System.Drawing.Size(298, 106);
			this.slotCapture.Name = "slotCapture";
			this.slotCapture.Size = new System.Drawing.Size(298, 106);
			this.slotCapture.TabIndex = 19;
			this.slotCapture.Value = null;
			// 
			// MapMouseWheelForm
			// 
			this.AcceptButton = this.okBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelBtn;
			this.ClientSize = new System.Drawing.Size(307, 319);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.okBtn);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.slotCapture);
			this.Name = "MapMouseWheelForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Map mouse wheel";
			this.Load += new System.EventHandler(this.MapMouseWheelForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox motion;
		private System.Windows.Forms.Button okBtn;
		private System.Windows.Forms.Button cancelBtn;
		private PadSlotCaptureControl slotCapture;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button twoClicksUp;
		private System.Windows.Forms.Button twoClicksDown;
		private System.Windows.Forms.Button oneClickDown;
		private System.Windows.Forms.Button oneClickUp;
		private System.Windows.Forms.CheckBox useIntensity;
		private System.Windows.Forms.CheckBox continuous;
	}
}