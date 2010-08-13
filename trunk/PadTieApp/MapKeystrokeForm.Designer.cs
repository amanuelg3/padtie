namespace PadTieApp {
	partial class MapKeystrokeForm {
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
			this.ctrl = new System.Windows.Forms.CheckBox();
			this.alt = new System.Windows.Forms.CheckBox();
			this.shift = new System.Windows.Forms.CheckBox();
			this.meta = new System.Windows.Forms.CheckBox();
			this.keyBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.okBtn = new System.Windows.Forms.Button();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.slotCapture = new PadTieApp.PadSlotCaptureControl();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// ctrl
			// 
			this.ctrl.AutoSize = true;
			this.ctrl.Location = new System.Drawing.Point(6, 16);
			this.ctrl.Name = "ctrl";
			this.ctrl.Size = new System.Drawing.Size(59, 17);
			this.ctrl.TabIndex = 0;
			this.ctrl.Text = "Control";
			this.ctrl.UseVisualStyleBackColor = true;
			// 
			// alt
			// 
			this.alt.AutoSize = true;
			this.alt.Location = new System.Drawing.Point(6, 39);
			this.alt.Name = "alt";
			this.alt.Size = new System.Drawing.Size(38, 17);
			this.alt.TabIndex = 1;
			this.alt.Text = "Alt";
			this.alt.UseVisualStyleBackColor = true;
			// 
			// shift
			// 
			this.shift.AutoSize = true;
			this.shift.Location = new System.Drawing.Point(6, 62);
			this.shift.Name = "shift";
			this.shift.Size = new System.Drawing.Size(47, 17);
			this.shift.TabIndex = 2;
			this.shift.Text = "Shift";
			this.shift.UseVisualStyleBackColor = true;
			// 
			// meta
			// 
			this.meta.AutoSize = true;
			this.meta.Location = new System.Drawing.Point(6, 85);
			this.meta.Name = "meta";
			this.meta.Size = new System.Drawing.Size(80, 17);
			this.meta.TabIndex = 3;
			this.meta.Text = "Win / Meta";
			this.meta.UseVisualStyleBackColor = true;
			// 
			// keyBox
			// 
			this.keyBox.Location = new System.Drawing.Point(131, 14);
			this.keyBox.Name = "keyBox";
			this.keyBox.Size = new System.Drawing.Size(137, 20);
			this.keyBox.TabIndex = 4;
			this.keyBox.Enter += new System.EventHandler(this.keyBox_Enter);
			this.keyBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyBox_KeyDown);
			this.keyBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.keyBox_KeyPress);
			this.keyBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyBox_KeyUp);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(97, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(28, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Key:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.alt);
			this.groupBox1.Controls.Add(this.ctrl);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.shift);
			this.groupBox1.Controls.Add(this.keyBox);
			this.groupBox1.Controls.Add(this.meta);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(274, 109);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Key";
			// 
			// okBtn
			// 
			this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.okBtn.Location = new System.Drawing.Point(211, 210);
			this.okBtn.Name = "okBtn";
			this.okBtn.Size = new System.Drawing.Size(75, 23);
			this.okBtn.TabIndex = 9;
			this.okBtn.Text = "OK";
			this.okBtn.UseVisualStyleBackColor = true;
			this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
			// 
			// cancelBtn
			// 
			this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.Location = new System.Drawing.Point(130, 210);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(75, 23);
			this.cancelBtn.TabIndex = 10;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
			// 
			// slotCapture
			// 
			this.slotCapture.Controller = null;
			this.slotCapture.Location = new System.Drawing.Point(10, 125);
			this.slotCapture.MaximumSize = new System.Drawing.Size(1000, 79);
			this.slotCapture.MinimumSize = new System.Drawing.Size(233, 79);
			this.slotCapture.Name = "slotCapture";
			this.slotCapture.Size = new System.Drawing.Size(282, 79);
			this.slotCapture.TabIndex = 11;
			this.slotCapture.Value = null;
			// 
			// MapKeystrokeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(298, 243);
			this.Controls.Add(this.slotCapture);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.okBtn);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "MapKeystrokeForm";
			this.Text = "Map key stroke";
			this.Load += new System.EventHandler(this.MapKeystrokeForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CheckBox ctrl;
		private System.Windows.Forms.CheckBox alt;
		private System.Windows.Forms.CheckBox shift;
		private System.Windows.Forms.CheckBox meta;
		private System.Windows.Forms.TextBox keyBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button okBtn;
		private System.Windows.Forms.Button cancelBtn;
		private PadSlotCaptureControl slotCapture;
	}
}