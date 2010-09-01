namespace PadTieApp {
	partial class ControllerView {
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControllerView));
			this.controllerFront = new System.Windows.Forms.PictureBox();
			this.controllerTop = new System.Windows.Forms.PictureBox();
			this.autoSelectInput = new System.Windows.Forms.CheckBox();
			this.btnMaskLeftAnalog = new System.Windows.Forms.Panel();
			this.btnMaskA = new System.Windows.Forms.Panel();
			this.btnMaskB = new System.Windows.Forms.Panel();
			this.btnMaskRightAnalog = new System.Windows.Forms.Panel();
			this.btnMaskY = new System.Windows.Forms.Panel();
			this.btnMaskX = new System.Windows.Forms.Panel();
			this.btnMaskDigitalXPos = new System.Windows.Forms.Panel();
			this.btnMaskDigitalYNeg = new System.Windows.Forms.Panel();
			this.btnMaskDigitalXNeg = new System.Windows.Forms.Panel();
			this.btnMaskSystem = new System.Windows.Forms.Panel();
			this.btnMaskDigitalYPos = new System.Windows.Forms.Panel();
			this.btnMaskStart = new System.Windows.Forms.Panel();
			this.btnMaskLeftXPos = new System.Windows.Forms.Panel();
			this.btnMaskLeftXNeg = new System.Windows.Forms.Panel();
			this.btnMaskBack = new System.Windows.Forms.Panel();
			this.btnMaskLeftYNeg = new System.Windows.Forms.Panel();
			this.btnMaskRightXNeg = new System.Windows.Forms.Panel();
			this.btnMaskLeftYPos = new System.Windows.Forms.Panel();
			this.btnMaskRightXPos = new System.Windows.Forms.Panel();
			this.btnMaskRightYNeg = new System.Windows.Forms.Panel();
			this.btnMaskRightYPos = new System.Windows.Forms.Panel();
			this.btnMaskTr = new System.Windows.Forms.Panel();
			this.btnMaskTl = new System.Windows.Forms.Panel();
			this.btnMaskBl = new System.Windows.Forms.Panel();
			this.btnMaskBr = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.controllerFront)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.controllerTop)).BeginInit();
			this.SuspendLayout();
			// 
			// controllerFront
			// 
			this.controllerFront.Image = ((System.Drawing.Image)(resources.GetObject("controllerFront.Image")));
			this.controllerFront.Location = new System.Drawing.Point(0, 0);
			this.controllerFront.Margin = new System.Windows.Forms.Padding(4);
			this.controllerFront.Name = "controllerFront";
			this.controllerFront.Size = new System.Drawing.Size(341, 215);
			this.controllerFront.TabIndex = 83;
			this.controllerFront.TabStop = false;
			// 
			// controllerTop
			// 
			this.controllerTop.Image = ((System.Drawing.Image)(resources.GetObject("controllerTop.Image")));
			this.controllerTop.Location = new System.Drawing.Point(-3, 123);
			this.controllerTop.Margin = new System.Windows.Forms.Padding(4);
			this.controllerTop.Name = "controllerTop";
			this.controllerTop.Size = new System.Drawing.Size(341, 128);
			this.controllerTop.TabIndex = 84;
			this.controllerTop.TabStop = false;
			// 
			// autoSelectInput
			// 
			this.autoSelectInput.AutoSize = true;
			this.autoSelectInput.BackColor = System.Drawing.Color.Transparent;
			this.autoSelectInput.Checked = true;
			this.autoSelectInput.CheckState = System.Windows.Forms.CheckState.Checked;
			this.autoSelectInput.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.autoSelectInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.autoSelectInput.Location = new System.Drawing.Point(87, 189);
			this.autoSelectInput.Margin = new System.Windows.Forms.Padding(4);
			this.autoSelectInput.Name = "autoSelectInput";
			this.autoSelectInput.Size = new System.Drawing.Size(69, 16);
			this.autoSelectInput.TabIndex = 110;
			this.autoSelectInput.Text = "Auto select";
			this.autoSelectInput.UseVisualStyleBackColor = false;
			this.autoSelectInput.CheckedChanged += new System.EventHandler(this.autoSelectInput_CheckedChanged);
			// 
			// btnMaskLeftAnalog
			// 
			this.btnMaskLeftAnalog.BackColor = System.Drawing.Color.Black;
			this.btnMaskLeftAnalog.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMaskLeftAnalog.Location = new System.Drawing.Point(52, 38);
			this.btnMaskLeftAnalog.Margin = new System.Windows.Forms.Padding(4);
			this.btnMaskLeftAnalog.Name = "btnMaskLeftAnalog";
			this.btnMaskLeftAnalog.Size = new System.Drawing.Size(16, 15);
			this.btnMaskLeftAnalog.TabIndex = 101;
			this.btnMaskLeftAnalog.Tag = "Rounded";
			this.btnMaskLeftAnalog.Visible = false;
			// 
			// btnMaskA
			// 
			this.btnMaskA.BackColor = System.Drawing.Color.Chartreuse;
			this.btnMaskA.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMaskA.Location = new System.Drawing.Point(189, 58);
			this.btnMaskA.Margin = new System.Windows.Forms.Padding(4);
			this.btnMaskA.Name = "btnMaskA";
			this.btnMaskA.Size = new System.Drawing.Size(15, 15);
			this.btnMaskA.TabIndex = 89;
			this.btnMaskA.Tag = "Circle";
			this.btnMaskA.Visible = false;
			this.btnMaskA.Paint += new System.Windows.Forms.PaintEventHandler(this.btnMaskA_Paint);
			// 
			// btnMaskB
			// 
			this.btnMaskB.BackColor = System.Drawing.Color.Salmon;
			this.btnMaskB.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMaskB.Location = new System.Drawing.Point(207, 40);
			this.btnMaskB.Margin = new System.Windows.Forms.Padding(4);
			this.btnMaskB.Name = "btnMaskB";
			this.btnMaskB.Size = new System.Drawing.Size(15, 15);
			this.btnMaskB.TabIndex = 90;
			this.btnMaskB.Tag = "Circle";
			this.btnMaskB.Visible = false;
			this.btnMaskB.Paint += new System.Windows.Forms.PaintEventHandler(this.btnMaskB_Paint);
			// 
			// btnMaskRightAnalog
			// 
			this.btnMaskRightAnalog.BackColor = System.Drawing.Color.Black;
			this.btnMaskRightAnalog.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMaskRightAnalog.Location = new System.Drawing.Point(151, 81);
			this.btnMaskRightAnalog.Margin = new System.Windows.Forms.Padding(4);
			this.btnMaskRightAnalog.Name = "btnMaskRightAnalog";
			this.btnMaskRightAnalog.Size = new System.Drawing.Size(16, 15);
			this.btnMaskRightAnalog.TabIndex = 103;
			this.btnMaskRightAnalog.Tag = "Rounded";
			this.btnMaskRightAnalog.Visible = false;
			this.btnMaskRightAnalog.Paint += new System.Windows.Forms.PaintEventHandler(this.btnMaskRightAnalog_Paint);
			// 
			// btnMaskY
			// 
			this.btnMaskY.BackColor = System.Drawing.Color.Khaki;
			this.btnMaskY.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMaskY.Location = new System.Drawing.Point(189, 21);
			this.btnMaskY.Margin = new System.Windows.Forms.Padding(4);
			this.btnMaskY.Name = "btnMaskY";
			this.btnMaskY.Size = new System.Drawing.Size(15, 15);
			this.btnMaskY.TabIndex = 91;
			this.btnMaskY.Tag = "Circle";
			this.btnMaskY.Visible = false;
			this.btnMaskY.Paint += new System.Windows.Forms.PaintEventHandler(this.btnMaskY_Paint);
			// 
			// btnMaskX
			// 
			this.btnMaskX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(133)))), ((int)(((byte)(255)))));
			this.btnMaskX.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMaskX.Location = new System.Drawing.Point(170, 40);
			this.btnMaskX.Margin = new System.Windows.Forms.Padding(4);
			this.btnMaskX.Name = "btnMaskX";
			this.btnMaskX.Size = new System.Drawing.Size(15, 15);
			this.btnMaskX.TabIndex = 92;
			this.btnMaskX.Tag = "Circle";
			this.btnMaskX.Visible = false;
			this.btnMaskX.Paint += new System.Windows.Forms.PaintEventHandler(this.btnMaskX_Paint);
			// 
			// btnMaskDigitalXPos
			// 
			this.btnMaskDigitalXPos.BackColor = System.Drawing.Color.Black;
			this.btnMaskDigitalXPos.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMaskDigitalXPos.Location = new System.Drawing.Point(99, 81);
			this.btnMaskDigitalXPos.Margin = new System.Windows.Forms.Padding(4);
			this.btnMaskDigitalXPos.Name = "btnMaskDigitalXPos";
			this.btnMaskDigitalXPos.Size = new System.Drawing.Size(18, 14);
			this.btnMaskDigitalXPos.TabIndex = 94;
			this.btnMaskDigitalXPos.Tag = "Rounded";
			this.btnMaskDigitalXPos.Visible = false;
			// 
			// btnMaskDigitalYNeg
			// 
			this.btnMaskDigitalYNeg.BackColor = System.Drawing.Color.Black;
			this.btnMaskDigitalYNeg.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMaskDigitalYNeg.Location = new System.Drawing.Point(85, 64);
			this.btnMaskDigitalYNeg.Margin = new System.Windows.Forms.Padding(4);
			this.btnMaskDigitalYNeg.Name = "btnMaskDigitalYNeg";
			this.btnMaskDigitalYNeg.Size = new System.Drawing.Size(14, 17);
			this.btnMaskDigitalYNeg.TabIndex = 95;
			this.btnMaskDigitalYNeg.Tag = "Rounded";
			this.btnMaskDigitalYNeg.Visible = false;
			this.btnMaskDigitalYNeg.Paint += new System.Windows.Forms.PaintEventHandler(this.btnMaskDigitalYNeg_Paint);
			// 
			// btnMaskDigitalXNeg
			// 
			this.btnMaskDigitalXNeg.BackColor = System.Drawing.Color.Black;
			this.btnMaskDigitalXNeg.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMaskDigitalXNeg.Location = new System.Drawing.Point(66, 81);
			this.btnMaskDigitalXNeg.Margin = new System.Windows.Forms.Padding(4);
			this.btnMaskDigitalXNeg.Name = "btnMaskDigitalXNeg";
			this.btnMaskDigitalXNeg.Size = new System.Drawing.Size(18, 14);
			this.btnMaskDigitalXNeg.TabIndex = 98;
			this.btnMaskDigitalXNeg.Tag = "Rounded";
			this.btnMaskDigitalXNeg.Visible = false;
			this.btnMaskDigitalXNeg.Paint += new System.Windows.Forms.PaintEventHandler(this.btnMaskDigitalXNeg_Paint);
			// 
			// btnMaskSystem
			// 
			this.btnMaskSystem.BackColor = System.Drawing.Color.Chocolate;
			this.btnMaskSystem.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMaskSystem.Location = new System.Drawing.Point(117, 37);
			this.btnMaskSystem.Margin = new System.Windows.Forms.Padding(4);
			this.btnMaskSystem.Name = "btnMaskSystem";
			this.btnMaskSystem.Size = new System.Drawing.Size(22, 22);
			this.btnMaskSystem.TabIndex = 97;
			this.btnMaskSystem.Tag = "Circle";
			this.btnMaskSystem.Visible = false;
			this.btnMaskSystem.Paint += new System.Windows.Forms.PaintEventHandler(this.btnMaskSystem_Paint);
			// 
			// btnMaskDigitalYPos
			// 
			this.btnMaskDigitalYPos.BackColor = System.Drawing.Color.Black;
			this.btnMaskDigitalYPos.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMaskDigitalYPos.Location = new System.Drawing.Point(85, 93);
			this.btnMaskDigitalYPos.Margin = new System.Windows.Forms.Padding(4);
			this.btnMaskDigitalYPos.Name = "btnMaskDigitalYPos";
			this.btnMaskDigitalYPos.Size = new System.Drawing.Size(14, 17);
			this.btnMaskDigitalYPos.TabIndex = 99;
			this.btnMaskDigitalYPos.Tag = "Rounded";
			this.btnMaskDigitalYPos.Visible = false;
			this.btnMaskDigitalYPos.Paint += new System.Windows.Forms.PaintEventHandler(this.btnMaskDigitalYPos_Paint);
			// 
			// btnMaskStart
			// 
			this.btnMaskStart.BackColor = System.Drawing.Color.Black;
			this.btnMaskStart.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMaskStart.Location = new System.Drawing.Point(146, 43);
			this.btnMaskStart.Margin = new System.Windows.Forms.Padding(4);
			this.btnMaskStart.Name = "btnMaskStart";
			this.btnMaskStart.Size = new System.Drawing.Size(17, 12);
			this.btnMaskStart.TabIndex = 93;
			this.btnMaskStart.Tag = "Circle";
			this.btnMaskStart.Visible = false;
			this.btnMaskStart.Paint += new System.Windows.Forms.PaintEventHandler(this.btnMaskStart_Paint);
			// 
			// btnMaskLeftXPos
			// 
			this.btnMaskLeftXPos.BackColor = System.Drawing.Color.Black;
			this.btnMaskLeftXPos.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMaskLeftXPos.Location = new System.Drawing.Point(70, 36);
			this.btnMaskLeftXPos.Margin = new System.Windows.Forms.Padding(4);
			this.btnMaskLeftXPos.Name = "btnMaskLeftXPos";
			this.btnMaskLeftXPos.Size = new System.Drawing.Size(13, 20);
			this.btnMaskLeftXPos.TabIndex = 100;
			this.btnMaskLeftXPos.Tag = "Rounded";
			this.btnMaskLeftXPos.Visible = false;
			// 
			// btnMaskLeftXNeg
			// 
			this.btnMaskLeftXNeg.BackColor = System.Drawing.Color.Black;
			this.btnMaskLeftXNeg.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMaskLeftXNeg.Location = new System.Drawing.Point(36, 36);
			this.btnMaskLeftXNeg.Margin = new System.Windows.Forms.Padding(4);
			this.btnMaskLeftXNeg.Name = "btnMaskLeftXNeg";
			this.btnMaskLeftXNeg.Size = new System.Drawing.Size(13, 20);
			this.btnMaskLeftXNeg.TabIndex = 102;
			this.btnMaskLeftXNeg.Tag = "Rounded";
			this.btnMaskLeftXNeg.Visible = false;
			// 
			// btnMaskBack
			// 
			this.btnMaskBack.BackColor = System.Drawing.Color.Black;
			this.btnMaskBack.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMaskBack.Location = new System.Drawing.Point(92, 42);
			this.btnMaskBack.Margin = new System.Windows.Forms.Padding(4);
			this.btnMaskBack.Name = "btnMaskBack";
			this.btnMaskBack.Size = new System.Drawing.Size(17, 12);
			this.btnMaskBack.TabIndex = 96;
			this.btnMaskBack.Tag = "Circle";
			this.btnMaskBack.Visible = false;
			this.btnMaskBack.Paint += new System.Windows.Forms.PaintEventHandler(this.btnMaskBack_Paint);
			// 
			// btnMaskLeftYNeg
			// 
			this.btnMaskLeftYNeg.BackColor = System.Drawing.Color.Black;
			this.btnMaskLeftYNeg.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMaskLeftYNeg.Location = new System.Drawing.Point(49, 24);
			this.btnMaskLeftYNeg.Margin = new System.Windows.Forms.Padding(4);
			this.btnMaskLeftYNeg.Name = "btnMaskLeftYNeg";
			this.btnMaskLeftYNeg.Size = new System.Drawing.Size(21, 12);
			this.btnMaskLeftYNeg.TabIndex = 104;
			this.btnMaskLeftYNeg.Tag = "Rounded";
			this.btnMaskLeftYNeg.Visible = false;
			// 
			// btnMaskRightXNeg
			// 
			this.btnMaskRightXNeg.BackColor = System.Drawing.Color.Black;
			this.btnMaskRightXNeg.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMaskRightXNeg.Location = new System.Drawing.Point(135, 79);
			this.btnMaskRightXNeg.Margin = new System.Windows.Forms.Padding(4);
			this.btnMaskRightXNeg.Name = "btnMaskRightXNeg";
			this.btnMaskRightXNeg.Size = new System.Drawing.Size(13, 20);
			this.btnMaskRightXNeg.TabIndex = 109;
			this.btnMaskRightXNeg.Tag = "Rounded";
			this.btnMaskRightXNeg.Visible = false;
			this.btnMaskRightXNeg.Paint += new System.Windows.Forms.PaintEventHandler(this.btnMaskRightXNeg_Paint);
			// 
			// btnMaskLeftYPos
			// 
			this.btnMaskLeftYPos.BackColor = System.Drawing.Color.Black;
			this.btnMaskLeftYPos.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMaskLeftYPos.Location = new System.Drawing.Point(49, 55);
			this.btnMaskLeftYPos.Margin = new System.Windows.Forms.Padding(4);
			this.btnMaskLeftYPos.Name = "btnMaskLeftYPos";
			this.btnMaskLeftYPos.Size = new System.Drawing.Size(21, 12);
			this.btnMaskLeftYPos.TabIndex = 105;
			this.btnMaskLeftYPos.Tag = "Rounded";
			this.btnMaskLeftYPos.Visible = false;
			// 
			// btnMaskRightXPos
			// 
			this.btnMaskRightXPos.BackColor = System.Drawing.Color.Black;
			this.btnMaskRightXPos.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMaskRightXPos.Location = new System.Drawing.Point(170, 79);
			this.btnMaskRightXPos.Margin = new System.Windows.Forms.Padding(4);
			this.btnMaskRightXPos.Name = "btnMaskRightXPos";
			this.btnMaskRightXPos.Size = new System.Drawing.Size(13, 20);
			this.btnMaskRightXPos.TabIndex = 108;
			this.btnMaskRightXPos.Tag = "Rounded";
			this.btnMaskRightXPos.Visible = false;
			this.btnMaskRightXPos.Paint += new System.Windows.Forms.PaintEventHandler(this.btnMaskRightXPos_Paint);
			// 
			// btnMaskRightYNeg
			// 
			this.btnMaskRightYNeg.BackColor = System.Drawing.Color.Black;
			this.btnMaskRightYNeg.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMaskRightYNeg.Location = new System.Drawing.Point(149, 67);
			this.btnMaskRightYNeg.Margin = new System.Windows.Forms.Padding(4);
			this.btnMaskRightYNeg.Name = "btnMaskRightYNeg";
			this.btnMaskRightYNeg.Size = new System.Drawing.Size(21, 12);
			this.btnMaskRightYNeg.TabIndex = 106;
			this.btnMaskRightYNeg.Tag = "Rounded";
			this.btnMaskRightYNeg.Visible = false;
			this.btnMaskRightYNeg.Paint += new System.Windows.Forms.PaintEventHandler(this.btnMaskRightYNeg_Paint);
			// 
			// btnMaskRightYPos
			// 
			this.btnMaskRightYPos.BackColor = System.Drawing.Color.Black;
			this.btnMaskRightYPos.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMaskRightYPos.Location = new System.Drawing.Point(149, 98);
			this.btnMaskRightYPos.Margin = new System.Windows.Forms.Padding(4);
			this.btnMaskRightYPos.Name = "btnMaskRightYPos";
			this.btnMaskRightYPos.Size = new System.Drawing.Size(21, 12);
			this.btnMaskRightYPos.TabIndex = 107;
			this.btnMaskRightYPos.Tag = "Rounded";
			this.btnMaskRightYPos.Visible = false;
			this.btnMaskRightYPos.Paint += new System.Windows.Forms.PaintEventHandler(this.btnMaskRightYPos_Paint);
			// 
			// btnMaskTr
			// 
			this.btnMaskTr.BackColor = System.Drawing.Color.Black;
			this.btnMaskTr.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMaskTr.Location = new System.Drawing.Point(180, 140);
			this.btnMaskTr.Margin = new System.Windows.Forms.Padding(4);
			this.btnMaskTr.Name = "btnMaskTr";
			this.btnMaskTr.Size = new System.Drawing.Size(17, 38);
			this.btnMaskTr.TabIndex = 111;
			this.btnMaskTr.Visible = false;
			this.btnMaskTr.Paint += new System.Windows.Forms.PaintEventHandler(this.btnMaskTr_Paint);
			// 
			// btnMaskTl
			// 
			this.btnMaskTl.BackColor = System.Drawing.Color.Black;
			this.btnMaskTl.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMaskTl.Location = new System.Drawing.Point(51, 138);
			this.btnMaskTl.Margin = new System.Windows.Forms.Padding(4);
			this.btnMaskTl.Name = "btnMaskTl";
			this.btnMaskTl.Size = new System.Drawing.Size(17, 38);
			this.btnMaskTl.TabIndex = 112;
			this.btnMaskTl.Visible = false;
			this.btnMaskTl.Paint += new System.Windows.Forms.PaintEventHandler(this.btnMaskTl_Paint);
			// 
			// btnMaskBl
			// 
			this.btnMaskBl.BackColor = System.Drawing.Color.Black;
			this.btnMaskBl.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMaskBl.Location = new System.Drawing.Point(29, 182);
			this.btnMaskBl.Margin = new System.Windows.Forms.Padding(4);
			this.btnMaskBl.Name = "btnMaskBl";
			this.btnMaskBl.Size = new System.Drawing.Size(45, 14);
			this.btnMaskBl.TabIndex = 113;
			this.btnMaskBl.Visible = false;
			this.btnMaskBl.Paint += new System.Windows.Forms.PaintEventHandler(this.btnMaskBl_Paint);
			// 
			// btnMaskBr
			// 
			this.btnMaskBr.BackColor = System.Drawing.Color.Black;
			this.btnMaskBr.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMaskBr.Location = new System.Drawing.Point(174, 183);
			this.btnMaskBr.Margin = new System.Windows.Forms.Padding(4);
			this.btnMaskBr.Name = "btnMaskBr";
			this.btnMaskBr.Size = new System.Drawing.Size(45, 14);
			this.btnMaskBr.TabIndex = 114;
			this.btnMaskBr.Visible = false;
			this.btnMaskBr.Paint += new System.Windows.Forms.PaintEventHandler(this.btnMaskBr_Paint);
			// 
			// ControllerView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.autoSelectInput);
			this.Controls.Add(this.btnMaskDigitalYPos);
			this.Controls.Add(this.btnMaskRightYPos);
			this.Controls.Add(this.btnMaskTr);
			this.Controls.Add(this.btnMaskTl);
			this.Controls.Add(this.btnMaskBl);
			this.Controls.Add(this.btnMaskBr);
			this.Controls.Add(this.controllerTop);
			this.Controls.Add(this.btnMaskLeftAnalog);
			this.Controls.Add(this.btnMaskA);
			this.Controls.Add(this.btnMaskB);
			this.Controls.Add(this.btnMaskRightAnalog);
			this.Controls.Add(this.btnMaskY);
			this.Controls.Add(this.btnMaskX);
			this.Controls.Add(this.btnMaskDigitalXPos);
			this.Controls.Add(this.btnMaskDigitalYNeg);
			this.Controls.Add(this.btnMaskDigitalXNeg);
			this.Controls.Add(this.btnMaskSystem);
			this.Controls.Add(this.btnMaskStart);
			this.Controls.Add(this.btnMaskLeftXPos);
			this.Controls.Add(this.btnMaskLeftXNeg);
			this.Controls.Add(this.btnMaskBack);
			this.Controls.Add(this.btnMaskLeftYNeg);
			this.Controls.Add(this.btnMaskRightXNeg);
			this.Controls.Add(this.btnMaskLeftYPos);
			this.Controls.Add(this.btnMaskRightXPos);
			this.Controls.Add(this.btnMaskRightYNeg);
			this.Controls.Add(this.controllerFront);
			this.DoubleBuffered = true;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximumSize = new System.Drawing.Size(344, 255);
			this.MinimumSize = new System.Drawing.Size(344, 255);
			this.Name = "ControllerView";
			this.Size = new System.Drawing.Size(344, 255);
			this.Load += new System.EventHandler(this.ControllerView_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.ControllerView_Paint);
			this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ControllerView_MouseClick);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControllerView_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ControllerView_MouseMove);
			((System.ComponentModel.ISupportInitialize)(this.controllerFront)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.controllerTop)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox controllerFront;
		private System.Windows.Forms.PictureBox controllerTop;
		private System.Windows.Forms.CheckBox autoSelectInput;
		private System.Windows.Forms.Panel btnMaskLeftAnalog;
		private System.Windows.Forms.Panel btnMaskA;
		private System.Windows.Forms.Panel btnMaskB;
		private System.Windows.Forms.Panel btnMaskRightAnalog;
		private System.Windows.Forms.Panel btnMaskY;
		private System.Windows.Forms.Panel btnMaskX;
		private System.Windows.Forms.Panel btnMaskDigitalXPos;
		private System.Windows.Forms.Panel btnMaskDigitalYNeg;
		private System.Windows.Forms.Panel btnMaskDigitalXNeg;
		private System.Windows.Forms.Panel btnMaskSystem;
		private System.Windows.Forms.Panel btnMaskDigitalYPos;
		private System.Windows.Forms.Panel btnMaskStart;
		private System.Windows.Forms.Panel btnMaskLeftXPos;
		private System.Windows.Forms.Panel btnMaskLeftXNeg;
		private System.Windows.Forms.Panel btnMaskBack;
		private System.Windows.Forms.Panel btnMaskLeftYNeg;
		private System.Windows.Forms.Panel btnMaskRightXNeg;
		private System.Windows.Forms.Panel btnMaskLeftYPos;
		private System.Windows.Forms.Panel btnMaskRightXPos;
		private System.Windows.Forms.Panel btnMaskRightYNeg;
		private System.Windows.Forms.Panel btnMaskRightYPos;
		private System.Windows.Forms.Panel btnMaskTr;
		private System.Windows.Forms.Panel btnMaskTl;
		private System.Windows.Forms.Panel btnMaskBl;
		private System.Windows.Forms.Panel btnMaskBr;
	}
}
