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
	public partial class MapMouseWheelForm : Form, IMapDialog, IFontifiable {
		public MapMouseWheelForm(PadTieForm mainForm, Controller cc)
		{
			InitializeComponent();
			Controller = cc;
			MainForm = mainForm;
			slotCapture.Controller = cc;
			slotCapture.MainForm = mainForm;
		}

		public MapMouseWheelForm(PadTieForm mainForm, Controller cc, MouseWheelAction editing) :
			this(mainForm, cc)
		{
			this.editing = editing;
			motion.Text = editing.Value.ToString();
			continuous.Checked = editing.Continuous;
			useIntensity.Checked = editing.UseIntensity;
			slotCapture.SetInput(editing.SlotDescription, true);
		}

		MouseWheelAction editing;

		public Controller Controller { get; set; }
		public PadTieForm MainForm { get; set; }
		public bool Fontified { get; set; }

		public void SetInput(CapturedInput slot)
		{
			slotCapture.SetInput(slot);
		}

		private void oneClickUp_Click(object sender, EventArgs e)
		{
			motion.Text = "120";
			if (slotCapture.Value == null) slotCapture.BeginCapture();
		}

		private void oneClickDown_Click(object sender, EventArgs e)
		{
			motion.Text = "-120";
			if (slotCapture.Value == null) slotCapture.BeginCapture();
		}

		private void twoClicksDown_Click(object sender, EventArgs e)
		{
			motion.Text = "-240";
			if (slotCapture.Value == null) slotCapture.BeginCapture();
		}

		private void twoClicksUp_Click(object sender, EventArgs e)
		{
			motion.Text = "240";
			if (slotCapture.Value == null) slotCapture.BeginCapture();
		}

		private void okBtn_Click(object sender, EventArgs e)
		{

			short w;

			try {
				w = short.Parse(motion.Text);
			} catch (Exception) {
				MessageBox.Show("The wheel motion value must be a positive or negative whole number.");
				return;
			}

			if (slotCapture.Value == null) {
				MessageBox.Show("Please click Capture and press a button or axis direction on the gamepad.");
				return;
			}

			var input = slotCapture.Value;
			MouseWheelAction action;

			if (editing == null) {
				action = new MouseWheelAction(Controller.Core, w);
			} else {
				action = editing;
				action.Value = w;
				if (action.SlotDescription != input)
					MapUtil.Map(MainForm, Controller.Virtual, action.SlotDescription, null);

			}

			action.UseIntensity = useIntensity.Checked;
			action.Continuous = continuous.Checked;

			MapUtil.Map(MainForm, Controller.Virtual, input, action);

			DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}

		private void MapMouseWheelForm_Load(object sender, EventArgs e)
		{
			Fontify.Go(this);
		}

		private void cancelBtn_Click(object sender, EventArgs e)
		{
			DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}
	}
}