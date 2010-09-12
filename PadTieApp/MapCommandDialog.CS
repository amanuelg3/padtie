using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PadTie;
using System.Diagnostics;

namespace PadTieApp {
	public partial class MapCommandDialog : Form, IMapDialog, IFontifiable {
		public MapCommandDialog(PadTieForm mainForm, Controller cc)
		{
			if (mainForm == null)
				throw new ArgumentNullException("mainForm");
			if (cc == null)
				throw new ArgumentNullException("cc");

			InitializeComponent();
			MainForm = mainForm;
			Controller = cc;
			slotCapture.MainForm = mainForm;
			slotCapture.Controller = cc;
		}
		
		public MapCommandDialog(PadTieForm main, Controller cc, RunCommandAction editing):
			this (main, cc)
		{
			this.editing = editing;
			cmd.Text = editing.Command;
			args.Text = editing.Arguments;
			onRelease.Checked = editing.RunOnRelease;
			workDir.Text = editing.WorkingDirectory;
			if (editing.WindowStyle == ProcessWindowStyle.Normal)
				startAs.SelectedIndex = 0;
			else if (editing.WindowStyle == ProcessWindowStyle.Maximized)
				startAs.SelectedIndex = 1;
			else if (editing.WindowStyle == ProcessWindowStyle.Minimized)
				startAs.SelectedIndex = 2;
			else if (editing.WindowStyle == ProcessWindowStyle.Hidden)
				startAs.SelectedIndex = 3;
			showError.Checked = editing.ErrorDialog;

			slotCapture.SetInput(editing.SlotDescription);
		}

		public bool Fontified { get; set; }
		public PadTieForm MainForm { get; private set; }
		public Controller Controller { get; private set; }

		public void SetInput(CapturedInput slot)
		{
			slotCapture.SetInput(slot);
		}

		private void MapCommandDialog_Load(object sender, EventArgs e)
		{
			if (startAs.SelectedIndex < 0)
				startAs.SelectedIndex = 0;

			if (!onRelease.Checked && !onPress.Checked)
				onPress.Checked = true;

			Fontify.Go(this);
		}

		private void okBtn_Click(object sender, EventArgs e)
		{
			if (slotCapture.Value == null) {
				MessageBox.Show("Please click Capture and press a button or axis direction on the gamepad.");
				return;
			}

			var input = slotCapture.Value;
			RunCommandAction action;

			if (editing == null) {
				action = new RunCommandAction(Controller.Core, cmd.Text, args.Text, onRelease.Checked);
			} else {
				action = editing;
				action.Command = cmd.Text;
				action.Arguments = args.Text;
				action.RunOnRelease = onRelease.Checked;

				if (action.SlotDescription != input)
					MapUtil.Map(MainForm, Controller.Virtual, action.SlotDescription, null);

			}

			action.WorkingDirectory = workDir.Text;
			action.ErrorDialog = showError.Checked;

			try {
				action.WindowStyle = (ProcessWindowStyle)Enum.Parse(typeof(ProcessWindowStyle), startAs.Text);
			} catch (Exception) {
				action.WindowStyle = ProcessWindowStyle.Normal;
			}

			MapUtil.Map(MainForm, Controller.Virtual, input, action);

			DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}

		private void cancelBtn_Click(object sender, EventArgs e)
		{
			DialogResult = System.Windows.Forms.DialogResult.Cancel;
		}

		public RunCommandAction editing { get; set; }

		private void browseCmdBtn_Click(object sender, EventArgs e)
		{
			var ofd = new OpenFileDialog();
			ofd.Filter = "Executables, scripts, batch files|*.exe,*.vbs,*.bat|All Files (*.*)|*";
			ofd.RestoreDirectory = true;
			ofd.Multiselect = false;
			ofd.SupportMultiDottedExtensions = true;
			var r = ofd.ShowDialog();

			if (r == System.Windows.Forms.DialogResult.OK) {
				cmd.Text = ofd.FileName;
			}
		}

		private void browseWorkDirBtn_Click(object sender, EventArgs e)
		{
			var ofd = new FolderBrowserDialog();
			ofd.ShowNewFolderButton = true;
			var r = ofd.ShowDialog();

			if (r == System.Windows.Forms.DialogResult.OK) {
				cmd.Text = ofd.SelectedPath;
			}
		}
	}
}
