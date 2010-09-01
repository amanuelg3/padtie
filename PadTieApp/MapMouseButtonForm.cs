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
	public partial class MapMouseButtonForm : Form, IMapDialog, IFontifiable {
		private MouseButtonAction editing;
		public MapMouseButtonForm(PadTieForm form, Controller cc)
		{
			InitializeComponent();
			Controller = cc;
			MainForm = form;
			slotCapture.Controller = cc;
			slotCapture.MainForm = form;
		}
		
		public MapMouseButtonForm(PadTieForm main, Controller cc, MouseButtonAction editing):
			this (main, cc)
		{
			this.editing = editing;

			mouseButton.SelectedIndex = (int)editing.Button;
			slotCapture.SetInput(editing.SlotDescription, true);
		}

		public Controller Controller { get; private set; }
		public PadTieForm MainForm { get; private set; }
		public bool Fontified { get; set; }

		public void SetInput(CapturedInput slot)
		{
			slotCapture.SetInput(slot);
		}

		private void cancelBtn_Click(object sender, EventArgs e)
		{
			DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}

		private void okBtn_Click(object sender, EventArgs e)
		{
			MouseButtonAction.Buttons b = MouseButtonAction.Buttons.Left;

			if (mouseButton.Text == "Left")
				b = MouseButtonAction.Buttons.Left;
			else if (mouseButton.Text == "Middle")
				b = MouseButtonAction.Buttons.Middle;
			else if (mouseButton.Text == "Right")
				b = MouseButtonAction.Buttons.Right;
			else if (mouseButton.Text.StartsWith("Extra 1"))
				b = MouseButtonAction.Buttons.Back;
			else if (mouseButton.Text.StartsWith("Extra 2"))
				b = MouseButtonAction.Buttons.Forward;

			if (slotCapture.Value == null) {
				MessageBox.Show("Please click Capture and press a button or axis direction on the gamepad.");
				return;
			}

			var input = slotCapture.Value;
			InputAction action;

			if (editing != null) {
				editing.Button = b;

				if (input != editing.SlotDescription)
					MapUtil.Map(MainForm, Controller.Virtual, input, null);
				action = editing;
			} else {
				action = new MouseButtonAction(Controller.Core, b);
			}
			MapUtil.Map(MainForm, Controller.Virtual, input, action);

			DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}

		private void MapMouseButtonForm_Load(object sender, EventArgs e)
		{
			if (mouseButton.SelectedIndex == -1) mouseButton.SelectedIndex = 0;

			Fontify.Go(this);
		}

		private void MapMouseButtonForm_KeyPress(object sender, KeyPressEventArgs e)
		{
		}

		private void mouseButton_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (slotCapture.Value == null)
				slotCapture.BeginCapture();
		}
	}
}
