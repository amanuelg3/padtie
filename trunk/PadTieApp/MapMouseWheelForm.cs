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
	public partial class MapMouseWheelForm : Form {
		public MapMouseWheelForm(PadTieForm mainForm, VirtualController vc)
		{
			InitializeComponent();
			slotCapture.Controller = vc;
			Controller = vc;
			MainForm = mainForm;
		}

		MouseWheelAction editing;

		public VirtualController Controller { get; set; }
		public PadTieForm MainForm { get; set; }

		public MapMouseWheelForm(PadTieForm mainForm, VirtualController vc, MouseWheelAction editing):
			this (mainForm, vc)
		{
			this.editing = editing;
			motion.Text = editing.Value.ToString();
			continuous.Checked = editing.Continuous;
			useIntensity.Checked = editing.UseIntensity;
			slotCapture.SetInput(editing.SlotDescription);
		}

		private void oneClickUp_Click(object sender, EventArgs e)
		{
			motion.Text = "120";
		}

		private void oneClickDown_Click(object sender, EventArgs e)
		{
			motion.Text = "-120";
		}

		private void twoClicksDown_Click(object sender, EventArgs e)
		{
			motion.Text = "-240";
		}

		private void twoClicksUp_Click(object sender, EventArgs e)
		{
			motion.Text = "240";
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
					MapUtil.Map(MainForm, Controller, action.SlotDescription, null);

			}

			action.UseIntensity = useIntensity.Checked;
			action.Continuous = continuous.Checked;

			MapUtil.Map(MainForm, Controller, input, action);

			this.Close();
		}

		private void MapMouseWheelForm_Load(object sender, EventArgs e)
		{

		}
	}
}