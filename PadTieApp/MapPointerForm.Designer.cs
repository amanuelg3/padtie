namespace PadTieApp {
	partial class MapPointerForm {
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
			this.useIntensity = new System.Windows.Forms.CheckBox();
			this.continuous = new System.Windows.Forms.CheckBox();
			this.cBtn = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.autoSpeed = new System.Windows.Forms.ComboBox();
			this.seBtn = new System.Windows.Forms.Button();
			this.swBtn = new System.Windows.Forms.Button();
			this.nwBtn = new System.Windows.Forms.Button();
			this.neBtn = new System.Windows.Forms.Button();
			this.wBtn = new System.Windows.Forms.Button();
			this.eBtn = new System.Windows.Forms.Button();
			this.sBtn = new System.Windows.Forms.Button();
			this.nBtn = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.motionY = new System.Windows.Forms.TextBox();
			this.motionX = new System.Windows.Forms.TextBox();
			this.slotCapture = new PadTieApp.PadSlotCaptureControl();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cancelBtn
			// 
			this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn.Location = new System.Drawing.Point(158, 295);
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
			this.okBtn.Location = new System.Drawing.Point(239, 295);
			this.okBtn.Name = "okBtn";
			this.okBtn.Size = new System.Drawing.Size(75, 23);
			this.okBtn.TabIndex = 3;
			this.okBtn.Text = "OK";
			this.okBtn.UseVisualStyleBackColor = true;
			this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.useIntensity);
			this.groupBox1.Controls.Add(this.continuous);
			this.groupBox1.Controls.Add(this.cBtn);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.autoSpeed);
			this.groupBox1.Controls.Add(this.seBtn);
			this.groupBox1.Controls.Add(this.swBtn);
			this.groupBox1.Controls.Add(this.nwBtn);
			this.groupBox1.Controls.Add(this.neBtn);
			this.groupBox1.Controls.Add(this.wBtn);
			this.groupBox1.Controls.Add(this.eBtn);
			this.groupBox1.Controls.Add(this.sBtn);
			this.groupBox1.Controls.Add(this.nBtn);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.motionY);
			this.groupBox1.Controls.Add(this.motionX);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(303, 169);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Pointer Motion";
			// 
			// useIntensity
			// 
			this.useIntensity.AutoSize = true;
			this.useIntensity.Checked = true;
			this.useIntensity.CheckState = System.Windows.Forms.CheckState.Checked;
			this.useIntensity.Location = new System.Drawing.Point(147, 142);
			this.useIntensity.Name = "useIntensity";
			this.useIntensity.Size = new System.Drawing.Size(139, 17);
			this.useIntensity.TabIndex = 10;
			this.useIntensity.Text = "Use intensity if available";
			this.useIntensity.UseVisualStyleBackColor = true;
			// 
			// continuous
			// 
			this.continuous.AutoSize = true;
			this.continuous.Checked = true;
			this.continuous.CheckState = System.Windows.Forms.CheckState.Checked;
			this.continuous.Location = new System.Drawing.Point(147, 121);
			this.continuous.Name = "continuous";
			this.continuous.Size = new System.Drawing.Size(79, 17);
			this.continuous.TabIndex = 9;
			this.continuous.Text = "Continuous";
			this.continuous.UseVisualStyleBackColor = true;
			// 
			// cBtn
			// 
			this.cBtn.Location = new System.Drawing.Point(54, 84);
			this.cBtn.Name = "cBtn";
			this.cBtn.Size = new System.Drawing.Size(26, 22);
			this.cBtn.TabIndex = 15;
			this.cBtn.Text = " ";
			this.cBtn.UseVisualStyleBackColor = true;
			this.cBtn.Click += new System.EventHandler(this.cBtn_Click);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(291, 30);
			this.label5.TabIndex = 1;
			this.label5.Text = "Pick a speed and click a direction or enter the X and Y manually (negative is lef" +
				"t/up, positive is right/down).";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(142, 55);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(45, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Manual:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(70, 143);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "px per sec";
			// 
			// autoSpeed
			// 
			this.autoSpeed.FormattingEnabled = true;
			this.autoSpeed.Items.AddRange(new object[] {
            "15",
            "25",
            "35",
            "45"});
			this.autoSpeed.Location = new System.Drawing.Point(11, 140);
			this.autoSpeed.Name = "autoSpeed";
			this.autoSpeed.Size = new System.Drawing.Size(53, 21);
			this.autoSpeed.TabIndex = 2;
			this.autoSpeed.Text = "25";
			// 
			// seBtn
			// 
			this.seBtn.Location = new System.Drawing.Point(86, 112);
			this.seBtn.Name = "seBtn";
			this.seBtn.Size = new System.Drawing.Size(26, 22);
			this.seBtn.TabIndex = 0;
			this.seBtn.Text = " ";
			this.seBtn.UseVisualStyleBackColor = true;
			this.seBtn.Click += new System.EventHandler(this.seBtn_Click);
			// 
			// swBtn
			// 
			this.swBtn.Location = new System.Drawing.Point(22, 112);
			this.swBtn.Name = "swBtn";
			this.swBtn.Size = new System.Drawing.Size(26, 22);
			this.swBtn.TabIndex = 17;
			this.swBtn.Text = " ";
			this.swBtn.UseVisualStyleBackColor = true;
			this.swBtn.Click += new System.EventHandler(this.swBtn_Click);
			// 
			// nwBtn
			// 
			this.nwBtn.Location = new System.Drawing.Point(22, 56);
			this.nwBtn.Name = "nwBtn";
			this.nwBtn.Size = new System.Drawing.Size(26, 22);
			this.nwBtn.TabIndex = 11;
			this.nwBtn.Text = " ";
			this.nwBtn.UseVisualStyleBackColor = true;
			this.nwBtn.Click += new System.EventHandler(this.nwBtn_Click);
			// 
			// neBtn
			// 
			this.neBtn.Location = new System.Drawing.Point(86, 56);
			this.neBtn.Name = "neBtn";
			this.neBtn.Size = new System.Drawing.Size(26, 22);
			this.neBtn.TabIndex = 13;
			this.neBtn.Text = " ";
			this.neBtn.UseVisualStyleBackColor = true;
			this.neBtn.Click += new System.EventHandler(this.neBtn_Click);
			// 
			// wBtn
			// 
			this.wBtn.Location = new System.Drawing.Point(22, 83);
			this.wBtn.Name = "wBtn";
			this.wBtn.Size = new System.Drawing.Size(26, 23);
			this.wBtn.TabIndex = 14;
			this.wBtn.Text = "<";
			this.wBtn.UseVisualStyleBackColor = true;
			this.wBtn.Click += new System.EventHandler(this.wBtn_Click);
			// 
			// eBtn
			// 
			this.eBtn.Location = new System.Drawing.Point(86, 83);
			this.eBtn.Name = "eBtn";
			this.eBtn.Size = new System.Drawing.Size(26, 23);
			this.eBtn.TabIndex = 16;
			this.eBtn.Text = ">";
			this.eBtn.UseVisualStyleBackColor = true;
			this.eBtn.Click += new System.EventHandler(this.eBtn_Click);
			// 
			// sBtn
			// 
			this.sBtn.Location = new System.Drawing.Point(54, 112);
			this.sBtn.Name = "sBtn";
			this.sBtn.Size = new System.Drawing.Size(26, 23);
			this.sBtn.TabIndex = 18;
			this.sBtn.Text = "v";
			this.sBtn.UseVisualStyleBackColor = true;
			this.sBtn.Click += new System.EventHandler(this.sBtn_Click);
			// 
			// nBtn
			// 
			this.nBtn.Location = new System.Drawing.Point(54, 55);
			this.nBtn.Name = "nBtn";
			this.nBtn.Size = new System.Drawing.Size(26, 23);
			this.nBtn.TabIndex = 12;
			this.nBtn.Text = "^";
			this.nBtn.UseVisualStyleBackColor = true;
			this.nBtn.Click += new System.EventHandler(this.nBtn_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(144, 98);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(17, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Y:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(144, 74);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(17, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "X:";
			// 
			// motionY
			// 
			this.motionY.Location = new System.Drawing.Point(163, 95);
			this.motionY.Name = "motionY";
			this.motionY.Size = new System.Drawing.Size(55, 20);
			this.motionY.TabIndex = 8;
			// 
			// motionX
			// 
			this.motionX.Location = new System.Drawing.Point(163, 71);
			this.motionX.Name = "motionX";
			this.motionX.Size = new System.Drawing.Size(55, 20);
			this.motionX.TabIndex = 6;
			// 
			// slotCapture
			// 
			this.slotCapture.Controller = null;
			this.slotCapture.Location = new System.Drawing.Point(10, 187);
			this.slotCapture.MainForm = null;
			this.slotCapture.MaximumSize = new System.Drawing.Size(1000, 106);
			this.slotCapture.MinimumSize = new System.Drawing.Size(298, 106);
			this.slotCapture.Name = "slotCapture";
			this.slotCapture.Size = new System.Drawing.Size(310, 106);
			this.slotCapture.TabIndex = 1;
			this.slotCapture.Value = null;
			this.slotCapture.Enter += new System.EventHandler(this.slotCapture_Enter);
			// 
			// MapPointerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(326, 326);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.okBtn);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.slotCapture);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "MapPointerForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Map pointer motion";
			this.Load += new System.EventHandler(this.MapPointerForm_Load);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MapPointerForm_KeyUp);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private PadSlotCaptureControl slotCapture;
		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.Button okBtn;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox motionY;
		private System.Windows.Forms.TextBox motionX;
		private System.Windows.Forms.ComboBox autoSpeed;
		private System.Windows.Forms.Button seBtn;
		private System.Windows.Forms.Button swBtn;
		private System.Windows.Forms.Button nwBtn;
		private System.Windows.Forms.Button neBtn;
		private System.Windows.Forms.Button wBtn;
		private System.Windows.Forms.Button eBtn;
		private System.Windows.Forms.Button sBtn;
		private System.Windows.Forms.Button nBtn;
		private System.Windows.Forms.Button cBtn;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox useIntensity;
		private System.Windows.Forms.CheckBox continuous;
	}
}