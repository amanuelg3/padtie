using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PadTieApp {
	public partial class RemapPadDialog : Form, IFontifiable {
		public RemapPadDialog(PadTieForm mainForm, int oldNumber, string deviceName)
		{
			InitializeComponent();
			MainForm = mainForm;
			originalNumber = oldNumber;
			if (oldNumber > 0) {
				padNumber.Value = oldNumber;
				staticAssign.Checked = true;
			} else {
				padNumber.Value = 1;
				freeAssign.Checked = true;
			}

			lbl.Text = lbl.Text.Replace("%", deviceName);
		}

		public bool Fontified { get; set; }
		public PadTieForm MainForm { get; private set; }

		private void staticAssign_CheckedChanged(object sender, EventArgs e)
		{
			padNumber.Enabled = staticAssign.Checked;
		}

		public int PadNumber
		{
			get
			{
				if (staticAssign.Checked)
					return (int)padNumber.Value;
				else
					return -1;
			}
		}

		int originalNumber = -1;

		private void okBtn_Click(object sender, EventArgs e)
		{

		}

		private void padNumber_ValueChanged(object sender, EventArgs e)
		{
			if (!staticAssign.Checked) return;

			bool found = false;
			
			if (padNumber.Value != originalNumber) foreach (var dev in MainForm.GlobalConfig.Devices) {
				if (dev.PadNumber <= 0) continue;
				if (dev.PadNumber == padNumber.Value) {
					warning.Visible = found = true;
					var cc = MainForm.FindControllerForConfig(dev);

					if (cc != null)
						warning.Text = (warning.Tag as string).Replace("%", string.Format("'{0}'", cc.Device.ProductName));
					else
						warning.Text = (warning.Tag as string).Replace("%", "a gamepad which is not present (" + dev.DeviceID + ")");
					break;
				}
			}

			if (!found)
				warning.Visible = false;
		}

		private void RemapPadDialog_Load(object sender, EventArgs e)
		{
			warning.Tag = warning.Text;

			Fontify.Go(this);
		}
	}
}
