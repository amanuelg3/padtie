namespace PadTieApp {
	partial class MappingWizard {
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MappingWizard));
			this.page1 = new System.Windows.Forms.Panel();
			this.lblPage1 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.startBtn = new System.Windows.Forms.Button();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.page2 = new System.Windows.Forms.Panel();
			this.noHaveBtn = new System.Windows.Forms.Button();
			this.indicator = new System.Windows.Forms.PictureBox();
			this.progress = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.top = new System.Windows.Forms.PictureBox();
			this.front = new System.Windows.Forms.PictureBox();
			this.blinker = new System.Windows.Forms.Timer(this.components);
			this.page3 = new System.Windows.Forms.Panel();
			this.sendPermission = new System.Windows.Forms.CheckBox();
			this.finishedLbl = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.pbar = new System.Windows.Forms.ProgressBar();
			this.page1.SuspendLayout();
			this.page2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.indicator)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.top)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.front)).BeginInit();
			this.page3.SuspendLayout();
			this.SuspendLayout();
			// 
			// page1
			// 
			this.page1.Controls.Add(this.lblPage1);
			this.page1.Controls.Add(this.label1);
			this.page1.Location = new System.Drawing.Point(16, 15);
			this.page1.Margin = new System.Windows.Forms.Padding(4);
			this.page1.Name = "page1";
			this.page1.Size = new System.Drawing.Size(773, 377);
			this.page1.TabIndex = 1;
			// 
			// lblPage1
			// 
			this.lblPage1.Location = new System.Drawing.Point(15, 47);
			this.lblPage1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblPage1.Name = "lblPage1";
			this.lblPage1.Size = new System.Drawing.Size(753, 316);
			this.lblPage1.TabIndex = 1;
			this.lblPage1.Text = resources.GetString("lblPage1.Text");
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 11);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Welcome!";
			// 
			// startBtn
			// 
			this.startBtn.Location = new System.Drawing.Point(689, 399);
			this.startBtn.Margin = new System.Windows.Forms.Padding(4);
			this.startBtn.Name = "startBtn";
			this.startBtn.Size = new System.Drawing.Size(100, 28);
			this.startBtn.TabIndex = 2;
			this.startBtn.Text = "Start";
			this.startBtn.UseVisualStyleBackColor = true;
			this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
			// 
			// cancelBtn
			// 
			this.cancelBtn.Location = new System.Drawing.Point(16, 399);
			this.cancelBtn.Margin = new System.Windows.Forms.Padding(4);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(100, 28);
			this.cancelBtn.TabIndex = 4;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
			// 
			// page2
			// 
			this.page2.Controls.Add(this.noHaveBtn);
			this.page2.Controls.Add(this.indicator);
			this.page2.Controls.Add(this.progress);
			this.page2.Controls.Add(this.label3);
			this.page2.Controls.Add(this.label2);
			this.page2.Controls.Add(this.top);
			this.page2.Controls.Add(this.front);
			this.page2.Location = new System.Drawing.Point(17, 16);
			this.page2.Margin = new System.Windows.Forms.Padding(4);
			this.page2.Name = "page2";
			this.page2.Size = new System.Drawing.Size(773, 375);
			this.page2.TabIndex = 2;
			// 
			// noHaveBtn
			// 
			this.noHaveBtn.Enabled = false;
			this.noHaveBtn.Location = new System.Drawing.Point(103, 214);
			this.noHaveBtn.Margin = new System.Windows.Forms.Padding(4);
			this.noHaveBtn.Name = "noHaveBtn";
			this.noHaveBtn.Size = new System.Drawing.Size(173, 28);
			this.noHaveBtn.TabIndex = 7;
			this.noHaveBtn.Text = "I don\'t have this button!";
			this.noHaveBtn.UseVisualStyleBackColor = true;
			this.noHaveBtn.Click += new System.EventHandler(this.noHaveBtn_Click);
			// 
			// indicator
			// 
			this.indicator.BackColor = System.Drawing.Color.Maroon;
			this.indicator.Location = new System.Drawing.Point(164, 73);
			this.indicator.Margin = new System.Windows.Forms.Padding(4);
			this.indicator.Name = "indicator";
			this.indicator.Size = new System.Drawing.Size(16, 15);
			this.indicator.TabIndex = 6;
			this.indicator.TabStop = false;
			this.indicator.Tag = "off";
			// 
			// progress
			// 
			this.progress.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.progress.Location = new System.Drawing.Point(399, 31);
			this.progress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.progress.Name = "progress";
			this.progress.Size = new System.Drawing.Size(368, 331);
			this.progress.TabIndex = 3;
			this.progress.Text = "Mapping:\r\n";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(13, 246);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(377, 116);
			this.label3.TabIndex = 2;
			this.label3.Text = resources.GetString("label3.Text");
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 11);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(116, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Let\'s map your buttons!";
			// 
			// top
			// 
			this.top.Image = ((System.Drawing.Image)(resources.GetObject("top.Image")));
			this.top.Location = new System.Drawing.Point(29, 76);
			this.top.Margin = new System.Windows.Forms.Padding(4);
			this.top.Name = "top";
			this.top.Size = new System.Drawing.Size(345, 133);
			this.top.TabIndex = 5;
			this.top.TabStop = false;
			// 
			// front
			// 
			this.front.Image = ((System.Drawing.Image)(resources.GetObject("front.Image")));
			this.front.Location = new System.Drawing.Point(27, 41);
			this.front.Margin = new System.Windows.Forms.Padding(4);
			this.front.Name = "front";
			this.front.Size = new System.Drawing.Size(345, 212);
			this.front.TabIndex = 4;
			this.front.TabStop = false;
			// 
			// blinker
			// 
			this.blinker.Enabled = true;
			this.blinker.Interval = 900;
			this.blinker.Tick += new System.EventHandler(this.blinker_Tick);
			// 
			// page3
			// 
			this.page3.Controls.Add(this.sendPermission);
			this.page3.Controls.Add(this.finishedLbl);
			this.page3.Controls.Add(this.label6);
			this.page3.Location = new System.Drawing.Point(17, 15);
			this.page3.Margin = new System.Windows.Forms.Padding(4);
			this.page3.Name = "page3";
			this.page3.Size = new System.Drawing.Size(773, 377);
			this.page3.TabIndex = 5;
			// 
			// sendPermission
			// 
			this.sendPermission.AutoSize = true;
			this.sendPermission.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sendPermission.Location = new System.Drawing.Point(117, 155);
			this.sendPermission.Margin = new System.Windows.Forms.Padding(4);
			this.sendPermission.Name = "sendPermission";
			this.sendPermission.Size = new System.Drawing.Size(259, 17);
			this.sendPermission.TabIndex = 2;
			this.sendPermission.Text = "Yes! I\'m glad to help my fellow % owners!";
			this.sendPermission.UseVisualStyleBackColor = true;
			// 
			// finishedLbl
			// 
			this.finishedLbl.Location = new System.Drawing.Point(12, 47);
			this.finishedLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.finishedLbl.Name = "finishedLbl";
			this.finishedLbl.Size = new System.Drawing.Size(755, 165);
			this.finishedLbl.TabIndex = 1;
			this.finishedLbl.Text = resources.GetString("finishedLbl.Text");
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(13, 11);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(36, 13);
			this.label6.TabIndex = 0;
			this.label6.Text = "Done!";
			// 
			// pbar
			// 
			this.pbar.Location = new System.Drawing.Point(120, 399);
			this.pbar.Margin = new System.Windows.Forms.Padding(4);
			this.pbar.Maximum = 20;
			this.pbar.Name = "pbar";
			this.pbar.Size = new System.Drawing.Size(561, 28);
			this.pbar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.pbar.TabIndex = 6;
			this.pbar.Visible = false;
			// 
			// MappingWizard
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(805, 433);
			this.Controls.Add(this.pbar);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.startBtn);
			this.Controls.Add(this.page2);
			this.Controls.Add(this.page3);
			this.Controls.Add(this.page1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MappingWizard";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Map your Gamepads";
			this.Load += new System.EventHandler(this.MappingWizard_Load);
			this.page1.ResumeLayout(false);
			this.page1.PerformLayout();
			this.page2.ResumeLayout(false);
			this.page2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.indicator)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.top)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.front)).EndInit();
			this.page3.ResumeLayout(false);
			this.page3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel page1;
		private System.Windows.Forms.Panel page2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button startBtn;
		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.Label progress;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox indicator;
		private System.Windows.Forms.PictureBox front;
		private System.Windows.Forms.PictureBox top;
		private System.Windows.Forms.Timer blinker;
		private System.Windows.Forms.Label lblPage1;
		private System.Windows.Forms.Panel page3;
		private System.Windows.Forms.CheckBox sendPermission;
		private System.Windows.Forms.Label finishedLbl;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button noHaveBtn;
		private System.Windows.Forms.ProgressBar pbar;

	}
}