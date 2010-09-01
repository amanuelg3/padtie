namespace PadTieApp {
	partial class ChangeMappingDialog {
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
			this.lblSource = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.options = new System.Windows.Forms.ComboBox();
			this.okBtn = new System.Windows.Forms.Button();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.padSelector = new System.Windows.Forms.NumericUpDown();
			this.sendToOther = new System.Windows.Forms.RadioButton();
			this.sendDefault = new System.Windows.Forms.RadioButton();
			this.gestureOptions = new System.Windows.Forms.ComboBox();
			this.lblGesture = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.padSelector)).BeginInit();
			this.SuspendLayout();
			// 
			// lblSource
			// 
			this.lblSource.AutoSize = true;
			this.lblSource.Location = new System.Drawing.Point(12, 13);
			this.lblSource.Name = "lblSource";
			this.lblSource.Size = new System.Drawing.Size(50, 13);
			this.lblSource.TabIndex = 0;
			this.lblSource.Text = "Button: 0";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 86);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(61, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Mapped to:";
			// 
			// options
			// 
			this.options.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.options.FormattingEnabled = true;
			this.options.Location = new System.Drawing.Point(79, 83);
			this.options.Name = "options";
			this.options.Size = new System.Drawing.Size(257, 21);
			this.options.TabIndex = 2;
			// 
			// okBtn
			// 
			this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okBtn.Location = new System.Drawing.Point(261, 144);
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
			this.cancelBtn.Location = new System.Drawing.Point(180, 144);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(75, 23);
			this.cancelBtn.TabIndex = 4;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
			// 
			// padSelector
			// 
			this.padSelector.Enabled = false;
			this.padSelector.Location = new System.Drawing.Point(161, 55);
			this.padSelector.Name = "padSelector";
			this.padSelector.Size = new System.Drawing.Size(67, 20);
			this.padSelector.TabIndex = 6;
			// 
			// sendToOther
			// 
			this.sendToOther.AutoSize = true;
			this.sendToOther.Location = new System.Drawing.Point(19, 56);
			this.sendToOther.Name = "sendToOther";
			this.sendToOther.Size = new System.Drawing.Size(136, 17);
			this.sendToOther.TabIndex = 7;
			this.sendToOther.Text = "Send to a different pad:";
			this.sendToOther.UseVisualStyleBackColor = true;
			this.sendToOther.CheckedChanged += new System.EventHandler(this.sendToOther_CheckedChanged);
			// 
			// sendDefault
			// 
			this.sendDefault.AutoSize = true;
			this.sendDefault.Checked = true;
			this.sendDefault.Location = new System.Drawing.Point(19, 33);
			this.sendDefault.Name = "sendDefault";
			this.sendDefault.Size = new System.Drawing.Size(197, 17);
			this.sendDefault.TabIndex = 8;
			this.sendDefault.TabStop = true;
			this.sendDefault.Text = "Send to assigned pad for this device";
			this.sendDefault.UseVisualStyleBackColor = true;
			// 
			// gestureOptions
			// 
			this.gestureOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.gestureOptions.FormattingEnabled = true;
			this.gestureOptions.Items.AddRange(new object[] {
            "Link",
            "Tap",
            "Double Tap",
            "Hold"});
			this.gestureOptions.Location = new System.Drawing.Point(79, 110);
			this.gestureOptions.Name = "gestureOptions";
			this.gestureOptions.Size = new System.Drawing.Size(257, 21);
			this.gestureOptions.TabIndex = 9;
			this.gestureOptions.Visible = false;
			// 
			// lblGesture
			// 
			this.lblGesture.AutoSize = true;
			this.lblGesture.Location = new System.Drawing.Point(12, 113);
			this.lblGesture.Name = "lblGesture";
			this.lblGesture.Size = new System.Drawing.Size(47, 13);
			this.lblGesture.TabIndex = 10;
			this.lblGesture.Text = "Gesture:";
			this.lblGesture.Visible = false;
			// 
			// ChangeMappingDialog
			// 
			this.AcceptButton = this.okBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelBtn;
			this.ClientSize = new System.Drawing.Size(348, 179);
			this.Controls.Add(this.lblGesture);
			this.Controls.Add(this.gestureOptions);
			this.Controls.Add(this.sendDefault);
			this.Controls.Add(this.sendToOther);
			this.Controls.Add(this.padSelector);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.okBtn);
			this.Controls.Add(this.options);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblSource);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "ChangeMappingDialog";
			this.Text = "Change device mapping";
			this.Load += new System.EventHandler(this.ChangeMappingDialog_Load);
			((System.ComponentModel.ISupportInitialize)(this.padSelector)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblSource;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox options;
		private System.Windows.Forms.Button okBtn;
		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.NumericUpDown padSelector;
		private System.Windows.Forms.RadioButton sendToOther;
		private System.Windows.Forms.RadioButton sendDefault;
		private System.Windows.Forms.ComboBox gestureOptions;
		private System.Windows.Forms.Label lblGesture;
	}
}