﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PadTie;

namespace PadTieApp {
	public partial class PadSettingsControl : UserControl {
		public PadSettingsControl()
		{
			InitializeComponent();
		}

		InputCore core;
		PadTieForm mainForm;
		Controller controller;
		int padNumber;

		private Rectangle ButtonMaskRelative(Rectangle r, bool top)
		{
			if (top)
				return new Rectangle(r.X - controllerTop.Left, r.Y - controllerTop.Top, r.Width, r.Height);
			else
				return new Rectangle(r.X - controllerFront.Left, r.Y - controllerFront.Top, r.Width, r.Height);
		}

		Dictionary<VirtualController.Button, Panel> buttonVisualMap =
			new Dictionary<VirtualController.Button, Panel>();

		public void ResetMappings()
		{
			foreach (KeyValuePair<string, TreeNode> kvp in buttonMapNodes) {
				if (kvp.Value.Tag is InputAction) {
					kvp.Value.Tag = null;
					kvp.Value.Text = kvp.Value.ToolTipText;
				}
			}
		}

		public static VirtualController.Axis AxisFromGesture(AxisGesture gesture)
		{
			switch (gesture) {
				case AxisGesture.LeftXNeg:
				case AxisGesture.LeftXPos:
					return VirtualController.Axis.LeftX;
				case AxisGesture.RightXNeg:
				case AxisGesture.RightXPos:
					return VirtualController.Axis.RightX;
				case AxisGesture.LeftYNeg:
				case AxisGesture.LeftYPos:
					return VirtualController.Axis.LeftY;
				case AxisGesture.RightYPos:
				case AxisGesture.RightYNeg:
					return VirtualController.Axis.RightY;
				case AxisGesture.DigitalXPos:
				case AxisGesture.DigitalXNeg:
					return VirtualController.Axis.DigitalX;
				case AxisGesture.DigitalYPos:
				case AxisGesture.DigitalYNeg:
					return VirtualController.Axis.DigitalY;
			}

			return VirtualController.Axis.LeftX;
		}

		public static bool PoleFromGesture(AxisGesture gesture)
		{
			switch (gesture) {
				case AxisGesture.LeftXNeg:
				case AxisGesture.RightXNeg:
				case AxisGesture.LeftYNeg:
				case AxisGesture.RightYNeg:
				case AxisGesture.DigitalXNeg:
				case AxisGesture.DigitalYNeg:
					return false;
				case AxisGesture.LeftYPos:
				case AxisGesture.RightXPos:
				case AxisGesture.LeftXPos:
				case AxisGesture.RightYPos:
				case AxisGesture.DigitalXPos:
				case AxisGesture.DigitalYPos:
					return true;
			}

			return false;
		}

		public void SetMapping(string id, string text, InputAction action)
		{
			var n = buttonMapNodes[id];
			if (n.ToolTipText == "")
				n.ToolTipText = n.Text;

			n.Text = n.ToolTipText + ": " + text;
			n.Tag = action;
		}

		private void ControllerClick(object sender, EventArgs e)
		{
			if ((sender as Control).Tag is VirtualController.Button) {
				var btn = (VirtualController.Button)(sender as Control).Tag;
				var node = buttonMapNodes[btn.ToString() + "/link"];
				currentMappings.SelectedNode = node;
				if (node != null)
					node.Expand();
			} else if ((sender as Control).Tag is AxisGesture) {
				var ag = (AxisGesture)(sender as Control).Tag;
				string id = Util.GetAxisGestureID(AxisFromGesture(ag), PoleFromGesture(ag) ? AxisActions.Gestures.Positive : AxisActions.Gestures.Negative);
				var node = buttonMapNodes[id];
				currentMappings.SelectedNode = node;
				if (node != null)
					node.Expand();
			}
		}

		private void SetupButton(VirtualController.Button button, Panel panel)
		{
			buttonVisualMap[button] = panel;
			panel.Tag = button;
			panel.BackColor = Color.FromArgb(0, panel.BackColor);

			string name = button.ToString();

			if (button == VirtualController.Button.Bl) name = "Left Bumper";
			if (button == VirtualController.Button.Br) name = "Right Bumper";
			if (button == VirtualController.Button.Tl) name = "Left Trigger";
			if (button == VirtualController.Button.Tr) name = "Right Trigger";

			TreeNode n;
			if (button == VirtualController.Button.LeftAnalog) {
				TreeNode root;
				if (axisPortNodes.ContainsKey(VirtualController.Axis.LeftX)) {
					root = axisPortNodes[VirtualController.Axis.LeftX];
				} else {
					root = axisPortNodes[VirtualController.Axis.LeftX] = 
						buttonMapNodes["left-analog"] = currentMappings.Nodes.Add("Left Analog");
				}

				buttonMapNodes["left-analog/button"] = n = root.Nodes.Add("Push");
			} else if (button == VirtualController.Button.RightAnalog) {
				TreeNode root;
				if (axisPortNodes.ContainsKey(VirtualController.Axis.RightX)) {
					root = axisPortNodes[VirtualController.Axis.RightX];
				} else {
					root = axisPortNodes[VirtualController.Axis.RightX] =
						buttonMapNodes["right-analog"] = currentMappings.Nodes.Add("Right Analog");
				}

				buttonMapNodes["right-analog/button"] = n = root.Nodes.Add("Push");
			} else {
				n = currentMappings.Nodes.Add(name);
			}

			buttonMapNodes[button.ToString()] = n;
			buttonMapNodes[button.ToString() + "/link"] = n.Nodes.Add("Link");
			buttonMapNodes[button.ToString() + "/tap"] = n.Nodes.Add("Tap");
			buttonMapNodes[button.ToString() + "/dtap"] = n.Nodes.Add("Double Tap");
			buttonMapNodes[button.ToString() + "/hold"] = n.Nodes.Add("Hold");
		}

		public enum AxisGesture {
			LeftXPos,
			LeftXNeg,
			LeftYPos,
			LeftYNeg,
			RightXPos,
			RightXNeg,
			RightYPos,
			RightYNeg,
			DigitalXPos,
			DigitalXNeg,
			DigitalYPos,
			DigitalYNeg
		}

		Dictionary<AxisGesture, Panel> axisVisualMap =
			new Dictionary<AxisGesture, Panel>();

		Dictionary<VirtualController.Axis, TreeNode> axisPortNodes =
			new Dictionary<VirtualController.Axis, TreeNode>();

		private void HoverEnter(object sender, EventArgs e)
		{
			var p = sender as Panel;
			p.BackColor = Color.FromArgb(128, p.BackColor);
		}

		private void HoverExit(object sender, EventArgs e)
		{
			var p = sender as Panel;
			p.BackColor = Color.FromArgb(0, p.BackColor);
		}

		private void SetupAxisGesture(AxisGesture ag, Panel panel)
		{
			string name = "";
			TreeNode root = null;
			VirtualController.Axis 
				stick = StickFromGesture(ag),
				axis = AxisFromGesture(ag);
			bool pos = PoleFromGesture(ag);
			AxisActions.Gestures axisGesture = pos ? AxisActions.Gestures.Positive : AxisActions.Gestures.Negative;
			axisVisualMap[ag] = panel;
			panel.BackColor = Color.FromArgb(0, panel.BackColor);
			panel.Tag = ag;

			EventHandler press = delegate(object sender, EventArgs e)
			{
				panel.BackColor = Color.FromArgb(128, panel.BackColor);
				if (autoSelectInput.Checked) {
					string idx = Util.GetAxisGestureID(axis, axisGesture);
					var node = buttonMapNodes[idx];
					currentMappings.SelectedNode = node;
					if (node != null)
						node.Expand();
				}
			};
			
			EventHandler release = delegate(object sender, EventArgs e) 
			{ 
				panel.BackColor = Color.FromArgb(0, panel.BackColor); 
			};

			switch (ag) {
				case AxisGesture.LeftXNeg:
					controller.Virtual.LeftXAxis.NegativePress += press;
					controller.Virtual.LeftXAxis.NegativeRelease += release;
					break;
				case AxisGesture.LeftXPos:
					controller.Virtual.LeftXAxis.PositivePress += press;
					controller.Virtual.LeftXAxis.PositiveRelease += release;
					break;
				case AxisGesture.LeftYNeg:
					controller.Virtual.LeftYAxis.NegativePress += press;
					controller.Virtual.LeftYAxis.NegativeRelease += release;
					break;
				case AxisGesture.LeftYPos:
					controller.Virtual.LeftYAxis.PositivePress += press;
					controller.Virtual.LeftYAxis.PositiveRelease += release;
					break;
				case AxisGesture.RightXNeg:
					controller.Virtual.RightXAxis.NegativePress += press;
					controller.Virtual.RightXAxis.NegativeRelease += release;
					break;
				case AxisGesture.RightXPos:
					controller.Virtual.RightXAxis.PositivePress += press;
					controller.Virtual.RightXAxis.PositiveRelease += release;
					break;
				case AxisGesture.RightYNeg:
					controller.Virtual.RightYAxis.NegativePress += press;
					controller.Virtual.RightYAxis.NegativeRelease += release;
					break;
				case AxisGesture.RightYPos:
					controller.Virtual.RightYAxis.PositivePress += press;
					controller.Virtual.RightYAxis.PositiveRelease += release;
					break;
				case AxisGesture.DigitalXNeg:
					controller.Virtual.DigitalXAxis.NegativePress += press;
					controller.Virtual.DigitalXAxis.NegativeRelease += release;
					break;
				case AxisGesture.DigitalXPos:
					controller.Virtual.DigitalXAxis.PositivePress += press;
					controller.Virtual.DigitalXAxis.PositiveRelease += release;
					break;
				case AxisGesture.DigitalYNeg:
					controller.Virtual.DigitalYAxis.NegativePress += press;
					controller.Virtual.DigitalYAxis.NegativeRelease += release;
					break;
				case AxisGesture.DigitalYPos:
					controller.Virtual.DigitalYAxis.PositivePress += press;
					controller.Virtual.DigitalYAxis.PositiveRelease += release;
					break;
			}

			if (stick == VirtualController.Axis.RightX) {
				if (axisPortNodes.ContainsKey(stick)) {
					root = axisPortNodes[stick];
				} else {
					root = axisPortNodes[stick] = buttonMapNodes["right-analog"] = currentMappings.Nodes.Add("Right Analog");
					buttonMapNodes["right-analog/analog"] = root.Nodes.Add("Analog");
				}
			} else if (stick == VirtualController.Axis.LeftX) {
				if (axisPortNodes.ContainsKey(stick)) {
					root = axisPortNodes[stick];
				} else {
					root = axisPortNodes[stick] = buttonMapNodes["left-analog"] = currentMappings.Nodes.Add("Left Analog");
					buttonMapNodes["left-analog/analog"] = root.Nodes.Add("Analog");
				}
			} else if (stick == VirtualController.Axis.DigitalX) {
				if (axisPortNodes.ContainsKey(stick)) {
					root = axisPortNodes[stick];
				} else {
					root = axisPortNodes[stick] = buttonMapNodes["digital"] = currentMappings.Nodes.Add("Digital Pad");
					buttonMapNodes["digital/analog"] = root.Nodes.Add("Raw"); // Hardee har!
				}
			}

			switch (ag) {
				case AxisGesture.LeftXNeg:
				case AxisGesture.RightXNeg:
				case AxisGesture.DigitalXNeg:
					name = "Left";
					break;
				case AxisGesture.LeftXPos:
				case AxisGesture.RightXPos:
				case AxisGesture.DigitalXPos:
					name = "Right";
					break;
				case AxisGesture.LeftYNeg:
				case AxisGesture.RightYNeg:
				case AxisGesture.DigitalYNeg:
					name = "Up";
					break;
				case AxisGesture.LeftYPos:
				case AxisGesture.RightYPos:
				case AxisGesture.DigitalYPos:
					name = "Down";
					break;
			}

			buttonMapNodes[Util.GetAxisGestureID(axis, axisGesture)] = root.Nodes.Add(name.ToString());
		}

		private VirtualController.Axis StickFromGesture(AxisGesture ag)
		{
			var axis = VirtualController.Axis.LeftX;

			switch (ag) {
				case AxisGesture.LeftXNeg:
				case AxisGesture.LeftXPos:
				case AxisGesture.LeftYNeg:
				case AxisGesture.LeftYPos:
					axis = VirtualController.Axis.LeftX;
					break;
				case AxisGesture.RightXNeg:
				case AxisGesture.RightXPos:
				case AxisGesture.RightYNeg:
				case AxisGesture.RightYPos:
					axis = VirtualController.Axis.RightX;
					break;
				case AxisGesture.DigitalXNeg:
				case AxisGesture.DigitalXPos:
				case AxisGesture.DigitalYNeg:
				case AxisGesture.DigitalYPos:
					axis = VirtualController.Axis.DigitalX;
					break;
			}

			return axis;
		}

		Dictionary<string, TreeNode> buttonMapNodes =
			new Dictionary<string, TreeNode>();

		private void Press(object sender, VirtualController.ButtonEventArgs e)
		{
			Panel p = buttonVisualMap[e.Button];
			//p.Show();
			p.BackColor = Color.FromArgb(128, p.BackColor);


			if (autoSelectInput.Checked) {
				var node = buttonMapNodes[e.Button.ToString() + "/link"];

				currentMappings.SelectedNode = node;
				//currentMappings_AfterSelect(this, EventArgs.Empty);

				if (node != null) {
					node.Expand();
				}
			}
		}

		private void Release(object sender, VirtualController.ButtonEventArgs e)
		{
			Panel p = buttonVisualMap[e.Button];
			//p.Hide();
			p.BackColor = Color.FromArgb(0, p.BackColor);
		}

		private void Active(object sender, VirtualController.ButtonEventArgs e)
		{
		}

		private void Analog(object sender, VirtualController.AxisEventArgs e)
		{
		}

		class DeviceMappingItem {
			public DeviceMappingItem(DeviceMapping dm)
			{
				Mapping = dm;
			}

			public DeviceMapping Mapping { get; private set; }

			public override string ToString()
			{
				if (Mapping.Source.StartsWith("button:")) {
					VirtualController.Button btn = (VirtualController.Button)Enum.Parse(typeof(VirtualController.Button),
						Mapping.Destination);
					string btnName = Util.GetButtonDisplayName(btn);
					string src = Mapping.Source.Substring("button:".Length);

					if (Mapping.Gesture != "Link" && Mapping.Gesture != "" && Mapping.Gesture != null)
						src += string.Format(" ({0})", (Mapping.Gesture == "DoubleTap" ? "Double Tap" : Mapping.Gesture));

					return string.Format("Button {0} -> {1}", src, btnName);
				} else {
					VirtualController.Axis axis = (VirtualController.Axis)Enum.Parse(typeof(VirtualController.Axis),
						Mapping.Destination);
					string axisName = Util.GetAxisDisplayName(axis);

					return string.Format("Axis {0} -> {1}", Mapping.Source.Substring("axis:".Length), axisName);
				}
			}
		}

		public void Initialize(PadTieForm form, InputCore core, Controller cc, int padNum)
		{
			mainForm = form;
			this.core = core;
			controller = cc;
			padNumber = padNum;

			deviceName.Text = cc.Device.Name;
			deviceGUID.Text = cc.Device.ProductGUID.ToUpper();
			deviceInstanceGUID.Text = cc.Device.InstanceGUID.ToUpper();
			deviceVendorID.Text = "0x" + cc.Device.VendorID.ToString("X4");
			deviceProductID.Text = "0x" + cc.Device.ProductID.ToString("X4");
			devicePadNum.Text = cc.Index.ToString();
			deviceButtons.Text = cc.Device.ButtonCount.ToString();
			deviceAxes.Text = (cc.Device.AxisCount - cc.Device.HatCount).ToString();
			deviceHats.Text = cc.Device.HatCount.ToString();

			cc.Virtual.AxisAnalogReceived += Analog;
			cc.Virtual.ButtonActiveReceived += Active;
			cc.Virtual.ButtonPressReceived += Press;
			cc.Virtual.ButtonReleaseReceived += Release;

			actionTree.ExpandAll();
			currentMappings.Nodes.Clear();

			SetupButton(VirtualController.Button.A, btnMaskA);
			SetupButton(VirtualController.Button.B, btnMaskB);
			SetupButton(VirtualController.Button.X, btnMaskX);
			SetupButton(VirtualController.Button.Y, btnMaskY);
			SetupButton(VirtualController.Button.Start, btnMaskStart);
			SetupButton(VirtualController.Button.Back, btnMaskBack);
			SetupButton(VirtualController.Button.System, btnMaskSystem);
			SetupButton(VirtualController.Button.Bl, btnMaskBl);
			SetupButton(VirtualController.Button.Br, btnMaskBr);
			SetupButton(VirtualController.Button.Tl, btnMaskTl);
			SetupButton(VirtualController.Button.Tr, btnMaskTr);
			SetupButton(VirtualController.Button.LeftAnalog, btnMaskLeftAnalog);
			SetupButton(VirtualController.Button.RightAnalog, btnMaskRightAnalog);
			SetupAxisGesture(AxisGesture.LeftXNeg, btnMaskLeftXNeg);
			SetupAxisGesture(AxisGesture.LeftXPos, btnMaskLeftXPos);
			SetupAxisGesture(AxisGesture.LeftYNeg, btnMaskLeftYNeg);
			SetupAxisGesture(AxisGesture.LeftYPos, btnMaskLeftYPos);
			SetupAxisGesture(AxisGesture.RightXNeg, btnMaskRightXNeg);
			SetupAxisGesture(AxisGesture.RightXPos, btnMaskRightXPos);
			SetupAxisGesture(AxisGesture.RightYNeg, btnMaskRightYNeg);
			SetupAxisGesture(AxisGesture.RightYPos, btnMaskRightYPos);
			SetupAxisGesture(AxisGesture.DigitalXNeg, btnMaskDigitalXNeg);
			SetupAxisGesture(AxisGesture.DigitalXPos, btnMaskDigitalXPos);
			SetupAxisGesture(AxisGesture.DigitalYNeg, btnMaskDigitalYNeg);
			SetupAxisGesture(AxisGesture.DigitalYPos, btnMaskDigitalYPos);

			currentMappings.ExpandAll();
			RefreshDeviceMappings();
		}

		public void RefreshDeviceMappings()
		{
			buttonMappings.Items.Clear();
			foreach (var dm in controller.DeviceConfig.Mappings)
				buttonMappings.Items.Add(new DeviceMappingItem(dm));
		}

		private void PadSettingsControl_Load(object sender, EventArgs e)
		{

		}

		private void mapButton_Click(object sender, EventArgs e)
		{
			if (actionTree.SelectedNode == null)
				return;

			if ((string)actionTree.SelectedNode.Tag == "keystroke")
				new MapKeystrokeForm(mainForm, controller.Virtual).ShowDialog(this);
			else if ((string)actionTree.SelectedNode.Tag == "pointer")
				new MapPointerForm(mainForm, controller.Virtual).ShowDialog(this);
			else if ((string)actionTree.SelectedNode.Tag == "mouse-button")
				new MapMouseButtonForm(mainForm, controller.Virtual).ShowDialog(this);
			else if ((string)actionTree.SelectedNode.Tag == "mouse-wheel")
				new MapMouseWheelForm(mainForm, controller.Virtual).ShowDialog(this);
		}

		private void actionTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			mapButton_Click(sender, e);
		}

		private void currentMappings_AfterSelect(object sender, TreeViewEventArgs e)
		{
			var n = currentMappings.SelectedNode;

			if (n.Tag == null) {
				activeMapping.Text = "Unassigned";
				unmapBtn.Enabled = false;
				editBtn.Enabled = false;
			} else {
				activeMapping.Text = n.Tag.ToString();
				unmapBtn.Enabled = true;
				editBtn.Enabled = true;
			}

		}

		private void editBtn_Click(object sender, EventArgs e)
		{
			if (currentMappings.SelectedNode == null)
				return;

			var action = currentMappings.SelectedNode.Tag as InputAction;

			if (action == null) {
				MessageBox.Show ("No input action is associated.");
				return;
			}

			var desc = action.SlotDescription;
			var cc = this.controller;

			if (action is KeyAction)
				new MapKeystrokeForm(mainForm, cc.Virtual, action as KeyAction).ShowDialog(this);
			else if (action is MouseButtonAction)
				new MapMouseButtonForm(mainForm, cc.Virtual, action as MouseButtonAction).ShowDialog(this);
			else if (action is MousePointerAction)
				new MapPointerForm(mainForm, cc.Virtual, action as MousePointerAction).ShowDialog(this);
			else if (action is MouseWheelAction)
				new MapMouseWheelForm(mainForm, cc.Virtual, action as MouseWheelAction).ShowDialog(this);
		}

		private void unmapBtn_Click(object sender, EventArgs e)
		{
			var action = currentMappings.SelectedNode.Tag as InputAction;

			if (action == null)
				return;

			MapUtil.Map(mainForm, controller.Virtual, action.SlotDescription, null);
			currentMappings_AfterSelect(sender, null);
		}

		private void changeBtn_Click(object sender, EventArgs e)
		{
			if (buttonMappings.SelectedItem == null)
				return;

			var item = buttonMappings.SelectedItem as DeviceMappingItem;
			var cmf = new ChangeMappingDialog(mainForm, item.Mapping.Pad, item.Mapping.Source, item.Mapping.Gesture, item.Mapping.Destination);
			cmf.ShowDialog(this);

			if (cmf.DialogResult == DialogResult.OK) {
				bool isButton = item.Mapping.Source.StartsWith("button:");

				item.Mapping.Destination = cmf.Destination;
				if (isButton) item.Mapping.Gesture = cmf.Gesture;
				else item.Mapping.Gesture = "";

				if (isButton) {
					int btn = int.Parse(item.Mapping.Source.Substring("button:".Length));
					VirtualController.Button b = (VirtualController.Button)Enum.Parse(typeof(VirtualController.Button), cmf.Destination);
					var ba = new VirtualController.ButtonAction(controller.Virtual, b);

					if (cmf.Gesture != "Link" && cmf.Gesture != "" && cmf.Gesture != null) {
						// We need to enable gesture support at the device level for this button
						controller.Device.Buttons[btn].EnableGestures = true;
					}

					switch (cmf.Gesture) {
						case "Link":
						case null:
						case "":
							controller.Device.Buttons[btn].Link = ba;
							break;
						case "Tap":
							controller.Device.Buttons[btn].Tap = ba;
							break;
						case "DoubleTap":
							controller.Device.Buttons[btn].DoubleTap = ba;
							break;
						case "Hold":
							controller.Device.Buttons[btn].Hold = ba;
							break;
					}
				} else {
					int axis = int.Parse(item.Mapping.Source.Substring("axis:".Length));
					VirtualController.Axis a = (VirtualController.Axis)Enum.Parse(typeof(VirtualController.Axis), cmf.Destination);
					controller.Device.Axes[axis].Analog = new VirtualController.AxisAction(controller.Virtual, a);
				}
				
				mainForm.GlobalConfig.Save();
				RefreshDeviceMappings();
			}
		}

		private void wizardBtn_Click(object sender, EventArgs e)
		{
			var wiz = new MappingWizard();
			wiz.MainForm = mainForm;
			wiz.Controller = controller;
			wiz.ShowDialog(this);
		}
	}
}
