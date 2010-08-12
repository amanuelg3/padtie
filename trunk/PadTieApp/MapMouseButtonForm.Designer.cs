namespace PadTieApp {
	partial class MapMouseButtonForm {
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
			this.slotCapture = new PadTieApp.PadSlotCaptureControl();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.okBtn = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.mouseButton = new System.Windows.Forms.ComboBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// slotCapture
			// 
			this.slotCapture.Controller = null;
			this.slotCapture.Location = new System.Drawing.Point(5, 60);
			this.slotCapture.MaximumSize = new System.Drawing.Size(1000, 79);
			this.slotCapture.MinimumSize = new System.Drawing.Size(233, 79);
			this.slotCapture.Name = "slotCapture";
			this.slotCapture.Size = new System.Drawing.Size(282, 79);
			this.slotCapture.TabIndex = 19;
			this.slotCapture.Value = null;
			// 
			// cancelBtn
			// 
			this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.Location = new System.Drawing.Point(125, 145);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(75, 23);
			this.cancelBtn.TabIndex = 18;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
			// 
			// okBtn
			// 
			this.okBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.okBtn.Location = new System.Drawing.Point(206, 145);
			this.okBtn.Name = "okBtn";
			this.okBtn.Size = new System.Drawing.Size(75, 23);
			this.okBtn.TabIndex = 17;
			this.okBtn.Text = "OK";
			this.okBtn.UseVisualStyleBackColor = true;
			this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.mouseButton);
			this.groupBox1.Location = new System.Drawing.Point(7, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(274, 55);
			this.groupBox1.TabIndex = 16;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Pointer Motion";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(75, 13);
			this.label1.TabIndex = 20;
			this.label1.Text = "Mouse button:";
			// 
			// mouseButton
			// 
			this.mouseButton.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.mouseButton.FormattingEnabled = true;
			this.mouseButton.Items.AddRange(new object[] {
            "Left",
            "Middle",
            "Right",
            "Extra 1 (Back)",
            "Extra 2 (Forward)"});
			this.mouseButton.Location = new System.Drawing.Point(87, 19);
			this.mouseButton.Name = "mouseButton";
			this.mouseButton.Size = new System.Drawing.Size(178, 21);
			this.mouseButton.TabIndex = 19;
			// 
			// MapMouseButtonForm
			// 
			this.AcceptButton = this.okBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelBtn;
			this.ClientSize = new System.Drawing.Size(292, 178);
			this.Controls.Add(this.slotCapture);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.okBtn);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "MapMouseButtonForm";
			this.Text = "MapMouseButtonForm";
			this.Load += new System.EventHandler(this.MapMouseButtonForm_Load);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MapMouseButtonForm_KeyPress);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private PadSlotCaptureControl slotCapture;
		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.Button okBtn;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox mouseButton;
	}
}