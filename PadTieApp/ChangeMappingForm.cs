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
	public partial class ChangeMappingDialog : Form, IFontifiable {
		public ChangeMappingDialog(PadTieForm form, int pad, string source, string gesture, string dest)
		{
			InitializeComponent();

			if (pad == -1)
				sendDefault.Checked = true;
			else {
				sendToOther.Checked = true;
				padSelector.Value = pad;
			}

			if (source.StartsWith("button:")) {
				lblSource.Text = "Button: " + source.Substring("button:".Length);
				isAxis = false;

				options.Items.Clear();
				options.Items.Add(new ButtonOptionItem(VirtualController.Button.A));
				options.Items.Add(new ButtonOptionItem(VirtualController.Button.B));
				options.Items.Add(new ButtonOptionItem(VirtualController.Button.X));
				options.Items.Add(new ButtonOptionItem(VirtualController.Button.Y));
				options.Items.Add(new ButtonOptionItem(VirtualController.Button.Bl));
				options.Items.Add(new ButtonOptionItem(VirtualController.Button.Br));
				options.Items.Add(new ButtonOptionItem(VirtualController.Button.Tl));
				options.Items.Add(new ButtonOptionItem(VirtualController.Button.Tr));
				options.Items.Add(new ButtonOptionItem(VirtualController.Button.Back));
				options.Items.Add(new ButtonOptionItem(VirtualController.Button.Start));
				options.Items.Add(new ButtonOptionItem(VirtualController.Button.System));
				options.Items.Add(new ButtonOptionItem(VirtualController.Button.LeftAnalog));
				options.Items.Add(new ButtonOptionItem(VirtualController.Button.RightAnalog));

				VirtualController.Button b = (VirtualController.Button)Enum.Parse(typeof(VirtualController.Button), dest);
				foreach (var o in options.Items) {
					if ((o as ButtonOptionItem).Button == b) {
						options.SelectedItem = o;
						break;
					}
				}

				gestureOptions.Show();
				lblGesture.Show();

				int gestureID = -1;

				if (gesture == "" || gesture == null || gesture == "Link")
					gestureID = 0;
				else if (gesture == "Tap")
					gestureID = 1;
				else if (gesture == "DoubleTap")
					gestureID = 2;
				else if (gesture == "Hold")
					gestureID = 3;

				gestureOptions.SelectedIndex = gestureID;
			} else {
				lblSource.Text = "Axis: " + source.Substring("axis:".Length);
				isAxis = true;

				options.Items.Add(new AxisOptionItem(VirtualController.Axis.LeftX));
				options.Items.Add(new AxisOptionItem(VirtualController.Axis.LeftY));
				options.Items.Add(new AxisOptionItem(VirtualController.Axis.RightX));
				options.Items.Add(new AxisOptionItem(VirtualController.Axis.RightY));
				options.Items.Add(new AxisOptionItem(VirtualController.Axis.DigitalX));
				options.Items.Add(new AxisOptionItem(VirtualController.Axis.DigitalY));

				VirtualController.Axis a = (VirtualController.Axis)Enum.Parse(typeof(VirtualController.Axis), dest);
				foreach (var o in options.Items) {
					if ((o as AxisOptionItem).Axis == a) {
						options.SelectedItem = o;
						break;
					}
				}
				gestureOptions.Hide();
				lblGesture.Hide();
			}
		}

		bool isAxis = false;

		public bool Fontified { get; set; }

		public string Destination
		{
			get
			{
				if (options.SelectedItem == null)
					return null;

				if (isAxis)
					return (options.SelectedItem as AxisOptionItem).Axis.ToString();
				else
					return (options.SelectedItem as ButtonOptionItem).Button.ToString();
			}
		}

		public string Gesture
		{
			get
			{
				if (gestureOptions.SelectedIndex < 0)
					return null;

				switch (gestureOptions.SelectedIndex) {
					case 0:
						return "Link";
					case 1:
						return "Tap";
					case 2:
						return "DoubleTap";
					case 3:
						return "Hold";
				}

				return "";
			}
		}

		class ButtonOptionItem {
			public ButtonOptionItem(VirtualController.Button b)
			{
				Button = b;
				Name = Util.GetButtonDisplayName(b);
			}

			public VirtualController.Button Button;
			public string Name;

			public override string ToString() { return Name; }
		}

		class AxisOptionItem {
			public AxisOptionItem(VirtualController.Axis a)
			{
				Axis = a;
				Name = Util.GetAxisDisplayName(a);
			}

			public VirtualController.Axis Axis;
			public string Name;

			public override string ToString() { return Name; }
		}

		private void cancelBtn_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void sendToOther_CheckedChanged(object sender, EventArgs e)
		{
			padSelector.Enabled = sendToOther.Checked;
		}

		private void okBtn_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void ChangeMappingDialog_Load(object sender, EventArgs e)
		{
			Fontify.Go(this);
		}
	}
}
