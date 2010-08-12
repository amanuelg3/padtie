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
	public partial class MapMouseButtonForm : Form {
		private MouseButtonAction editing;
		public MapMouseButtonForm(PadTieForm form, VirtualController vc)
		{
			InitializeComponent();
			Controller = vc;
			MainForm = form;
			slotCapture.Controller = vc;
		}
		
		public MapMouseButtonForm(PadTieForm main, VirtualController vc, MouseButtonAction editing):
			this (main, vc)
		{
			this.editing = editing;

			mouseButton.SelectedIndex = (int)editing.Button;
			slotCapture.SetInput(editing.SlotDescription);
		}

		public VirtualController Controller { get; private set; }
		public PadTieForm MainForm { get; private set; }

		private void cancelBtn_Click(object sender, EventArgs e)
		{
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
					MapUtil.Map(MainForm, Controller, input, null);
				action = editing;
			} else {
				action = new MouseButtonAction(Controller.Core, b);
			}
			MapUtil.Map(MainForm, Controller, input, action);

			this.Close();
		}

		private void MapMouseButtonForm_Load(object sender, EventArgs e)
		{
			if (mouseButton.SelectedIndex == -1) mouseButton.SelectedIndex = 0;
		}

		private void MapMouseButtonForm_KeyPress(object sender, KeyPressEventArgs e)
		{
		}

		private void MapMouseButtonForm_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
				cancelBtn_Click(sender, EventArgs.Empty);
			if (e.KeyCode == Keys.Enter)
				okBtn_Click(sender, EventArgs.Empty);
		}
	}
}
