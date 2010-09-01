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

		public PadTieForm MainForm { get; set; }
		public Controller Controller { get; set; }
		public CapturedInput Value { get; set; }

		private void captureButton_Click(object sender, EventArgs e)
		{
			
			if (Controller == null) return;

			lblSlot.Font = new Font(lblSlot.Font, FontStyle.Bold);
			lblSlot.ForeColor = Color.DarkBlue;
			lblSlot.Text = "Slot: Waiting for input...";
			Controller.Virtual.CaptureNext(delegate(CapturedInput input)
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

		public void BeginCapture()
		{
			captureButton_Click(this, EventArgs.Empty);
		}

		public void SetInput(CapturedInput input)
		{
			SetInput(input, false);
		}

		CapturedInput previousMapping;

		public void SetInput (CapturedInput input, bool alreadyMapped)
		{
			Controller.Virtual.CancelCapture();

			if (input == null) {
				lblSlot.Text = "";
				Value = null;
				return;
			}

			if (alreadyMapped)
				previousMapping = input.Clone();

			input = input.Clone();
			bool error = false;

			if (input.IsAxisGesture) {
				string name = "Unknown Axis";
				string dir = "Unknown direction";
				var slot = Controller.Virtual.GetAxis(input.Axis).GetPole(input.AxisGesture).GetGesture(input.ButtonGesture);

				name = Util.GetStickDisplayName(input.Axis);
				dir = Util.GetAxisGestureName(input.Axis, input.IsPositive);
				
				lblSlot.Text = "Slot: " + name + " (" + dir + ")";
				
				if (slot != null && previousMapping != input) {
					lblSlot.Text += ", which is already assigned to " + Util.GetActionName(slot) + ". This action will be replaced.";
					error = true;
				}
			} else {
				string name = input.Button.ToString();

				if (input.Button == VirtualController.Button.Bl) name = "Left Bumper";
				if (input.Button == VirtualController.Button.Br) name = "Right Bumper";
				if (input.Button == VirtualController.Button.Tl) name = "Left Trigger";
				if (input.Button == VirtualController.Button.Tr) name = "Right Trigger";


				lblSlot.Text = "Slot: " + name;

			}

			if (error) {
				lblSlot.Font = new Font(lblSlot.Font, FontStyle.Regular);
				lblSlot.ForeColor = Color.Maroon;
			} else {
				lblSlot.Font = new Font(lblSlot.Font, FontStyle.Regular);
				lblSlot.ForeColor = Control.DefaultForeColor;
			}

			if ((int)input.ButtonGesture != this.gestureBox.SelectedIndex)
				this.gestureBox.SelectedIndex = (int)input.ButtonGesture;

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

		private void chooseBtn_Click(object sender, EventArgs e)
		{
			var d = new ChooseSlotDialog(MainForm, false);
			d.FocusedPad = Controller.Index;
			d.ShowAllPads = false;
			d.ShowDialog(this.ParentForm);

			if (d.DialogResult == DialogResult.OK) {
				if (d.SelectedNode == null) return;

				var tag = d.SelectedNode.Tag;

				if (tag is ChooseSlotDialog.SlotNodeTag) {
					var slot = (tag as ChooseSlotDialog.SlotNodeTag).slot.Clone();
					slot.ButtonGesture = ButtonGesture;
					SetInput(slot);
				}
			}
		}
	}
}
