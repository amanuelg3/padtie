using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PadTie;

namespace PadTieApp {
	public partial class MapPointerForm : Form, IMapDialog, IFontifiable {
		public MapPointerForm(PadTieForm form, Controller c)
		{
			InitializeComponent();

			MainForm = form;
			Controller = c;
			slotCapture.Controller = c;
			slotCapture.MainForm = form;
		}

		public bool Fontified { get; set; }

		public void SetInput(CapturedInput slot)
		{
			slotCapture.SetInput(slot);
		}
		
		public MousePointerAction editing;
		
		public MapPointerForm(PadTieForm main, Controller cc, MousePointerAction editing):
			this (main, cc)
		{
			this.editing = editing;
			motionX.Text = editing.X.ToString();
			motionY.Text = editing.Y.ToString();
			continuous.Checked = editing.Continuous;
			useIntensity.Checked = editing.UseIntensity;

			slotCapture.SetInput(editing.SlotDescription, true);
		}

		public PadTieForm MainForm { get; private set; }
		public Controller Controller { get; private set; }

		private void cBtn_Click(object sender, EventArgs e)
		{
			motionX.Text = "0";
			motionY.Text = "0";
		}

		private void Apply(sbyte x, sbyte y)
		{
			int speed;

			try {
				speed = int.Parse(autoSpeed.Text);
			} catch (Exception) {
				MessageBox.Show("Speed must be a whole number.");
				return;
			}

			motionX.Text = (x * speed).ToString();
			motionY.Text = (y * speed).ToString();

			if (slotCapture.Value == null) slotCapture.BeginCapture();
		}

		private void nBtn_Click(object sender, EventArgs e)
		{
			Apply(0, -1);
		}

		private void neBtn_Click(object sender, EventArgs e)
		{
			Apply(1, -1);
		}

		private void eBtn_Click(object sender, EventArgs e)
		{
			Apply(1, 0);
		}

		private void seBtn_Click(object sender, EventArgs e)
		{
			Apply(1, 1);
		}

		private void sBtn_Click(object sender, EventArgs e)
		{
			Apply(0, 1);
		}

		private void swBtn_Click(object sender, EventArgs e)
		{
			Apply(-1, -1);
		}

		private void wBtn_Click(object sender, EventArgs e)
		{
			Apply(-1, 0);
		}

		private void nwBtn_Click(object sender, EventArgs e)
		{
			Apply(-1, -1);
		}

		private void cancelBtn_Click(object sender, EventArgs e)
		{
			DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}

		private void okBtn_Click(object sender, EventArgs e)
		{
			int x, y;

			try {
				x = int.Parse(motionX.Text);
				y = int.Parse(motionY.Text);
			} catch (Exception) {
				MessageBox.Show("The X/Y coordinates must be positive or negative whole numbers.");
				return;
			}

			if (slotCapture.Value == null) {
				MessageBox.Show("Please click Capture and press a button or axis direction on the gamepad.");
				return;
			}

			var input = slotCapture.Value;
			MousePointerAction action;
			
			if (editing == null) {
				action = new MousePointerAction(Controller.Core, x, y);
			} else {
				action = editing;
				action.X = x;
				action.Y = y;
				if (action.SlotDescription != input)
					MapUtil.Map(MainForm, Controller.Virtual, action.SlotDescription, null);
			}

			action.Continuous = continuous.Checked;
			action.UseIntensity = useIntensity.Checked;

			MapUtil.Map(MainForm, Controller.Virtual, input, action);

			DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}

		private void MapPointerForm_Load(object sender, EventArgs e)
		{
			Fontify.Go(this);
		}

		private void MapPointerForm_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				okBtn_Click(sender, EventArgs.Empty);
			else if (e.KeyCode == Keys.Escape)
				cancelBtn_Click(sender, EventArgs.Empty);
		}

		private void slotCapture_Enter(object sender, EventArgs e)
		{

		}
	}
}
