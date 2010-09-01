namespace PadTieApp {
	partial class ActionSelectDialog {
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
			this.label1 = new System.Windows.Forms.Label();
			this.ActionSelect = new PadTieApp.ActionSelectControl();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(200, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Choose from the available actions below.";
			// 
			// ActionSelect
			// 
			this.ActionSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ActionSelect.Location = new System.Drawing.Point(12, 40);
			this.ActionSelect.Name = "ActionSelect";
			this.ActionSelect.ShowCancel = true;
			this.ActionSelect.Size = new System.Drawing.Size(379, 293);
			this.ActionSelect.TabIndex = 0;
			this.ActionSelect.Finished += new System.EventHandler(this.ActionSelect_Finished);
			this.ActionSelect.Cancelled += new System.EventHandler(this.ActionSelect_Cancelled);
			// 
			// ActionSelectDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(403, 345);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ActionSelect);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "ActionSelectDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Choose an action to bind";
			this.Load += new System.EventHandler(this.ActionSelectDialog_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		public ActionSelectControl ActionSelect;
	}
}