using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PadTieApp {
	public partial class ActionSelectDialog : Form, IFontifiable {
		public ActionSelectDialog()
		{
			InitializeComponent();
			DialogResult = System.Windows.Forms.DialogResult.Cancel;
		}

		public bool Fontified { get; set; }
		private void ActionSelectDialog_Load(object sender, EventArgs e)
		{
			Fontify.Go(this);
		}

		private void ActionSelect_Finished(object sender, EventArgs e)
		{
			DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}

		private void ActionSelect_Cancelled(object sender, EventArgs e)
		{
			DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}
	}
}
