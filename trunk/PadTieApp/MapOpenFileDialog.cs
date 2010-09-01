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
	public partial class MapOpenFileDialog : Form, IMapDialog, IFontifiable {
		public MapOpenFileDialog(PadTieForm form, Controller cc)
		{
			InitializeComponent();

			MainForm = form;
			Controller = cc;
			slotCapture.MainForm = form;
			slotCapture.Controller = cc;
		}

		public MapOpenFileDialog(PadTieForm form, Controller cc, OpenFileAction editing):
			this(form, cc)
		{
			this.editing = editing;
			cmd.Text = editing.FileName;
			onRelease.Checked = editing.OpenOnRelease;
			onPress.Checked = !editing.OpenOnRelease;
			showError.Checked = editing.ErrorDialog;
			slotCapture.SetInput(editing.SlotDescription, true);
		}

		OpenFileAction editing = null;

		public Controller Controller { get; private set; }
		public PadTieForm MainForm { get; private set; }
		public bool Fontified { get; set; }

		public void SetInput(CapturedInput slot)
		{
			slotCapture.SetInput(slot);
		}

		private void okBtn_Click(object sender, EventArgs e)
		{
			if (slotCapture.Value == null) {
				MessageBox.Show("Please click Capture and press a button or axis direction on the gamepad.");
				return;
			}

			var input = slotCapture.Value;
			OpenFileAction action;

			if (editing == null) {
				action = new OpenFileAction(Controller.Core, cmd.Text, onRelease.Checked, showError.Checked);
			} else {
				action = editing;
				action.FileName = cmd.Text;
				action.OpenOnRelease = onRelease.Checked;
				action.ErrorDialog = showError.Checked;

				if (action.SlotDescription != input)
					MapUtil.Map(MainForm, Controller.Virtual, action.SlotDescription, null);

			}

			MapUtil.Map(MainForm, Controller.Virtual, input, action);
			DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}

		private void MapOpenFileDialog_Load(object sender, EventArgs e)
		{
			if (!onRelease.Checked && !onPress.Checked)
				onPress.Checked = true;

			Fontify.Go(this);
		}

		private void browseCmdBtn_Click(object sender, EventArgs e)
		{
			var ofd = new OpenFileDialog();
			ofd.Filter = "All Files (*.*)|*";
			ofd.RestoreDirectory = true;
			ofd.Multiselect = false;
			ofd.SupportMultiDottedExtensions = true;
			var r = ofd.ShowDialog();

			if (r == System.Windows.Forms.DialogResult.OK) {
				cmd.Text = ofd.FileName;
			}
		}

		private void cancelBtn_Click(object sender, EventArgs e)
		{
			DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}
	}
}
