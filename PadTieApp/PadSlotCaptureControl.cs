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
	public partial class PadSlotCaptureControl : UserControl {
		public PadSlotCaptureControl()
		{
			InitializeComponent();
		}

		public VirtualController Controller { get; set; }
		public CapturedInput Value { get; set; }

		private void captureButton_Click(object sender, EventArgs e)
		{
			if (Controller == null) return;

			lblSlot.Text = "Slot: Waiting for input...";
			Controller.CaptureNext(delegate(CapturedInput input)
			{
				input.ButtonGesture = this.ButtonGesture;
				SetInput(input);
			});
		}

		public ButtonActions.Gesture ButtonGesture
		{
			get
			{
				if (gestureBox.Text == null || gestureBox.Text == "Link")
					return ButtonActions.Gesture.Link;
				else if (gestureBox.Text == "Tap")
					return ButtonActions.Gesture.Tap;
				else if (gestureBox.Text == "Double Tap")
					return ButtonActions.Gesture.DoubleTap;
				else if (gestureBox.Text == "Hold")
					return ButtonActions.Gesture.Hold;

				return ButtonActions.Gesture.Link;
			}
		}

		public void SetInput (CapturedInput input)
		{
			input = input.Clone();

			if (input.IsAxisGesture) {
				string name = "Unknown Axis";
				string dir = "Unknown direction";

				name = Util.GetStickDisplayName(input.Axis);
				dir = Util.GetAxisGestureName(input.Axis, input.IsPositive);

				lblSlot.Text = "Slot: " + name + " (" + dir + ")";
				lblGesture.Visible = false;
				gestureBox.Visible = false;
			} else {
				string name = input.Button.ToString();

				if (input.Button == VirtualController.Button.Bl) name = "Left Bumper";
				if (input.Button == VirtualController.Button.Br) name = "Right Bumper";
				if (input.Button == VirtualController.Button.Tl) name = "Left Trigger";
				if (input.Button == VirtualController.Button.Tr) name = "Right Trigger";


				lblSlot.Text = "Slot: " + name;
				lblGesture.Visible = true;
				gestureBox.Visible = true;

				if ((int)input.ButtonGesture != this.gestureBox.SelectedIndex)
					this.gestureBox.SelectedIndex = (int)input.ButtonGesture;
			}

			Value = input;
		}

		private void PadSlotCaptureControl_Load(object sender, EventArgs e)
		{
			if (gestureBox.SelectedIndex == -1) gestureBox.SelectedIndex = 0;
		}

		private void gestureBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Value != null)
				Value.ButtonGesture = this.ButtonGesture;
		}
	}
}
