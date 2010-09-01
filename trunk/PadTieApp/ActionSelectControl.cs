using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PadTie;

namespace PadTieApp {
	public partial class ActionSelectControl : UserControl {
		public ActionSelectControl()
		{
			InitializeComponent();
		}

		public Controller Controller { get; set; }
		public PadTieForm MainForm { get; set; }
		public CapturedInput Slot { get; set; }

		private void mapButton_Click(object sender, EventArgs e)
		{
			if (actionTree.SelectedNode == null)
				return;

			IMapDialog dialog;

			if ((string)actionTree.SelectedNode.Tag == "keystroke")
				dialog = new MapKeystrokeForm(MainForm, Controller);
			else if ((string)actionTree.SelectedNode.Tag == "pointer")
				dialog = new MapPointerForm(MainForm, Controller);
			else if ((string)actionTree.SelectedNode.Tag == "mouse-button")
				dialog = new MapMouseButtonForm(MainForm, Controller);
			else if ((string)actionTree.SelectedNode.Tag == "mouse-wheel")
				dialog = new MapMouseWheelForm(MainForm, Controller);
			else if ((string)actionTree.SelectedNode.Tag == "command")
				dialog = new MapCommandDialog(MainForm, Controller);
			else if ((string)actionTree.SelectedNode.Tag == "open-file")
				dialog = new MapOpenFileDialog(MainForm, Controller);
			else
				return;

			if (Slot != null)
				dialog.SetInput(Slot);

			var form = dialog as Form;
			
			form.ShowDialog(this.ParentForm);
			if (form.DialogResult == DialogResult.OK) {
				if (Finished != null) Finished(this, EventArgs.Empty);
			}
		}

		public event EventHandler Finished;
		public event EventHandler Cancelled;

		/// <summary>
		/// Whether or not the cancel button is shown (use Cancelled event to catch)
		/// </summary>
		public bool ShowCancel
		{
			get
			{
				return cancelBtn.Visible;
			}
			set
			{
				cancelBtn.Visible = value;
			}
		}

		private void cancelBtn_Click(object sender, EventArgs e)
		{
			if (Cancelled != null)
				Cancelled(this, EventArgs.Empty);
		}

		private void ActionSelectControl_Load(object sender, EventArgs e)
		{
			actionTree.ExpandAll();
		}

		private void actionTree_DoubleClick(object sender, EventArgs e)
		{
			mapButton.PerformClick();
		}

	}
}
