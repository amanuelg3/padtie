using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PadTieApp {
	public partial class WaitingForControllersForm : Form {
		public WaitingForControllersForm(PadTieForm form)
		{
			InitializeComponent();
			MainForm = form;
		}

		private void initTimer_Tick(object sender, EventArgs e)
		{
			if (MainForm.Init()) {
				initTimer.Enabled = false;
				this.Close();
			}
		}

		public PadTieForm MainForm { get; set; }

		private void WaitingForControllersForm_Load(object sender, EventArgs e)
		{

		}
	}
}
