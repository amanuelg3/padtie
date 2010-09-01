namespace PadTieApp {
	partial class RemapPadDialog {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemapPadDialog));
			this.lbl = new System.Windows.Forms.Label();
			this.padNumber = new System.Windows.Forms.NumericUpDown();
			this.okBtn = new System.Windows.Forms.Button();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.staticAssign = new System.Windows.Forms.RadioButton();
			this.freeAssign = new System.Windows.Forms.RadioButton();
			this.warning = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.padNumber)).BeginInit();
			this.SuspendLayout();
			// 
			// lbl
			// 
			this.lbl.Location = new System.Drawing.Point(12, 9);
			this.lbl.Name = "lbl";
			this.lbl.Size = new System.Drawing.Size(427, 108);
			this.lbl.TabIndex = 0;
			this.lbl.Text = resources.GetString("lbl.Text");
			// 
			// padNumber
			// 
			this.padNumber.Location = new System.Drawing.Point(309, 145);
			this.padNumber.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.padNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.padNumber.Name = "padNumber";
			this.padNumber.Size = new System.Drawing.Size(120, 20);
			this.padNumber.TabIndex = 1;
			this.padNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.padNumber.ValueChanged += new System.EventHandler(this.padNumber_ValueChanged);
			// 
			// okBtn
			// 
			this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okBtn.Location = new System.Drawing.Point(364, 228);
			this.okBtn.Name = "okBtn";
			this.okBtn.Size = new System.Drawing.Size(75, 23);
			this.okBtn.TabIndex = 3;
			this.okBtn.Text = "OK";
			this.okBtn.UseVisualStyleBackColor = true;
			this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
			// 
			// cancelBtn
			// 
			this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.Location = new System.Drawing.Point(283, 228);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(75, 23);
			this.cancelBtn.TabIndex = 4;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			// 
			// staticAssign
			// 
			this.staticAssign.AutoSize = true;
			this.staticAssign.Location = new System.Drawing.Point(32, 145);
			this.staticAssign.Name = "staticAssign";
			this.staticAssign.Size = new System.Drawing.Size(271, 17);
			this.staticAssign.TabIndex = 5;
			this.staticAssign.TabStop = true;
			this.staticAssign.Text = "Always attempt to map this gamepad to pad number:";
			this.staticAssign.UseVisualStyleBackColor = true;
			this.staticAssign.CheckedChanged += new System.EventHandler(this.staticAssign_CheckedChanged);
			// 
			// freeAssign
			// 
			this.freeAssign.AutoSize = true;
			this.freeAssign.Location = new System.Drawing.Point(32, 122);
			this.freeAssign.Name = "freeAssign";
			this.freeAssign.Size = new System.Drawing.Size(199, 17);
			this.freeAssign.TabIndex = 6;
			this.freeAssign.TabStop = true;
			this.freeAssign.Text = "Assign to the lowest free pad number";
			this.freeAssign.UseVisualStyleBackColor = true;
			// 
			// warning
			// 
			this.warning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.warning.Location = new System.Drawing.Point(15, 173);
			this.warning.Name = "warning";
			this.warning.Size = new System.Drawing.Size(424, 60);
			this.warning.TabIndex = 7;
			this.warning.Text = resources.GetString("warning.Text");
			this.warning.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.warning.Visible = false;
			// 
			// RemapPadDialog
			// 
			this.AcceptButton = this.okBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelBtn;
			this.ClientSize = new System.Drawing.Size(451, 263);
			this.Controls.Add(this.freeAssign);
			this.Controls.Add(this.staticAssign);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.okBtn);
			this.Controls.Add(this.padNumber);
			this.Controls.Add(this.lbl);
			this.Controls.Add(this.warning);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "RemapPadDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Change Pad Number";
			this.Load += new System.EventHandler(this.RemapPadDialog_Load);
			((System.ComponentModel.ISupportInitialize)(this.padNumber)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbl;
		private System.Windows.Forms.NumericUpDown padNumber;
		private System.Windows.Forms.Button okBtn;
		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.RadioButton staticAssign;
		private System.Windows.Forms.RadioButton freeAssign;
		private System.Windows.Forms.Label warning;
	}
}