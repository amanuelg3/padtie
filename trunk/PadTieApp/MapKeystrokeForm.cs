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
	public partial class MapKeystrokeForm : Form {
		public MapKeystrokeForm(PadTieForm main, VirtualController vc)
		{
			InitializeComponent();
			slotCapture.Controller = vc;
			Controller = vc;
			MainForm = main;
		}

		public VirtualController Controller { get; set; }
		public PadTieForm MainForm { get; set; }

		public MapKeystrokeForm(PadTieForm main, VirtualController vc, KeyAction editing):
			this (main, vc)
		{
			this.editing = editing;
			capturedKey = editing.Key;
			ctrl.Checked = shift.Checked = alt.Checked = false;

			foreach (Keys mod in editing.Modifiers) {
				if (mod == Keys.Control) ctrl.Checked = true;
				else if (mod == Keys.Shift) shift.Checked = true;
				else if (mod == Keys.Alt) alt.Checked = true;
			}

			keyBox.Text = Util.GetKeyName(editing.Key);
			slotCapture.SetInput(editing.SlotDescription);
		}

		KeyAction editing;

		private void MapKeystrokeForm_Load(object sender, EventArgs e)
		{

		}

		private void cancelBtn_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void okBtn_Click(object sender, EventArgs e)
		{
			if (slotCapture.Value == null) {
				MessageBox.Show("Please use the Capture button and press a button or analog direction first.");
				return;
			}

			var slot = slotCapture.Value;
			var key = Keys.None;
			List<Keys> mods = new List<Keys>();

			if (ctrl.Checked)
				mods.Add(Keys.Control);
			if (shift.Checked)
				mods.Add(Keys.Shift);
			if (alt.Checked)
				mods.Add(Keys.Menu);
			if (meta.Checked)
				mods.Add(Keys.LWin);

			key = capturedKey;

			this.Close();
			KeyAction action;

			if (editing != null) {
				action = editing;
				action.ChangeBinding(key, mods.ToArray());

				if (slot != action.SlotDescription)
					MapUtil.Map(MainForm, Controller, action.SlotDescription, null);
			} else {
				action = new KeyAction(key, mods.ToArray());
			}

			MapUtil.Map(MainForm, Controller, slot, action);
		}

		private void keyBox_Enter(object sender, EventArgs e)
		{
			keyBox.Text = "Waiting...";
			keyBox.BackColor = Color.Yellow;
		}

		private void keyBox_KeyPress(object sender, KeyPressEventArgs e)
		{
		}

		Keys capturedKey;

		private void keyBox_KeyUp(object sender, KeyEventArgs e)
		{
			alt.Checked = e.Alt;
			ctrl.Checked = e.Control;
			shift.Checked = e.Shift;
			capturedKey = e.KeyCode;
			keyBox.Text = Util.GetKeyName(e.KeyCode);
			keyBox.BackColor = Color.White;
			ctrl.Focus();

			e.Handled = true;
		}

		private void keyBox_KeyDown(object sender, KeyEventArgs e)
		{
			e.Handled = true;
		}
	}
}
