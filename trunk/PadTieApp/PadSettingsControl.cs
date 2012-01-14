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
	public partial class PadSettingsControl : UserControl, IFontifiable {
		public PadSettingsControl()
		{
			InitializeComponent();
		}

		public bool Fontified { get; set; }

		InputCore core;
		PadTieForm mainForm;
		Controller controller;
		int padNumber;
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
			var o = padView.SelectedItem;

			if (o == null) return;

			if (!o.IsAxisGesture) {
				var btn = o.Button;
				var node = buttonMapNodes[btn.ToString() + "/link"];
				currentMappings.SelectedNode = node;
				if (node != null)
					node.Expand();
			} else {
				string id = Util.GetAxisGestureID(o.Axis, 
					o.IsPositive ? AxisActions.Gestures.Positive : AxisActions.Gestures.Negative);
				var node = buttonMapNodes[id];
				currentMappings.SelectedNode = node;
				if (node != null)
					node.Expand();
			}
		}

		private void SetupButton(VirtualController.Button button)
		{
			string name = button.ToString();

			if (button == VirtualController.Button.Bl) name = "Left Bumper";
			else if (button == VirtualController.Button.Br) name = "Right Bumper";
			else if (button == VirtualController.Button.Tl) name = "Left Trigger";
			else if (button == VirtualController.Button.Tr) name = "Right Trigger";

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

		private void SetupAxisGesture(AxisGesture ag)
		{
			string name = "";
			TreeNode root = null;
			VirtualController.Axis 
				stick = Util.StickFromGesture(ag),
				axis = Util.AxisFromGesture(ag);
			bool pos = Util.PoleFromGesture(ag);
			AxisActions.Gestures axisGesture = pos ? AxisActions.Gestures.Positive : AxisActions.Gestures.Negative;

			EventHandler press = delegate(object sender, EventArgs e)
			{
				padView.SetOverlay(axis, pos, true);

				if (padView.AutoSelectInput) {
					string idx = Util.GetAxisGestureID(axis, axisGesture);
					var node = buttonMapNodes[idx];
					currentMappings.SelectedNode = node;
					if (node != null)
						node.Expand();
				}
			};
			
			EventHandler release = delegate(object sender, EventArgs e)
			{
				padView.SetOverlay(axis, pos, false);
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
                case AxisGesture.TriggerNeg:
                    controller.Virtual.Trigger.NegativePress += press;
                    controller.Virtual.Trigger.NegativeRelease += release;
                    break;
                case AxisGesture.TriggerPos:
                    controller.Virtual.Trigger.PositivePress += press;
                    controller.Virtual.Trigger.PositiveRelease += release;
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
			} else if (stick == VirtualController.Axis.Trigger) {
				if (axisPortNodes.ContainsKey(stick)) {
					root = axisPortNodes[stick];
				} else {
					root = axisPortNodes[stick] = buttonMapNodes["trigger"] = currentMappings.Nodes.Add("Trigger");
					buttonMapNodes["trigger/analog"] = root.Nodes.Add("Analog");
				}
			}

			switch (ag) {
				case AxisGesture.LeftXNeg:
				case AxisGesture.RightXNeg:
				case AxisGesture.DigitalXNeg:
                case AxisGesture.TriggerPos:
					name = "Left";
					break;
				case AxisGesture.LeftXPos:
				case AxisGesture.RightXPos:
				case AxisGesture.DigitalXPos:
                case AxisGesture.TriggerNeg:
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
			var n = root.Nodes.Add(name.ToString());
			buttonMapNodes[Util.GetAxisGestureID(axis, axisGesture)] = n;
			buttonMapNodes[Util.GetAxisGestureID(axis, axisGesture) + "/link"] = n.Nodes.Add("Link");
			buttonMapNodes[Util.GetAxisGestureID(axis, axisGesture) + "/tap"] = n.Nodes.Add("Tap");
			buttonMapNodes[Util.GetAxisGestureID(axis, axisGesture) + "/dtap"] = n.Nodes.Add("Double Tap");
			buttonMapNodes[Util.GetAxisGestureID(axis, axisGesture) + "/hold"] = n.Nodes.Add("Hold");
		}

		Dictionary<string, TreeNode> buttonMapNodes =
			new Dictionary<string, TreeNode>();

		private void Press(object sender, VirtualController.ButtonEventArgs e)
		{
			padView.SetOverlay(e.Button, true);

			if (padView.AutoSelectInput) {
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
			padView.SetOverlay(e.Button, false);
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

			padView.SelectedItemChanged += ControllerClick;

			deviceName.Text = cc.Device.Name;
			deviceGUID.Text = cc.Device.ProductGUID.ToUpper();
			deviceInstanceGUID.Text = cc.Device.InstanceGUID.ToUpper();
			deviceVendorID.Text = "0x" + cc.Device.VendorID.ToString("X4");
			deviceProductID.Text = "0x" + cc.Device.ProductID.ToString("X4");

			UpdateDeviceInfo();

			deviceButtons.Text = string.Format("{0} buttons, {1} axes, {2} hats, force feedback: {3}",
				cc.Device.ButtonCount.ToString(),
				(cc.Device.AxisCount - cc.Device.HatCount).ToString(),
				cc.Device.HatCount.ToString(),
				cc.Device.ForceFeedback ? "yes" : "no");

			cc.Virtual.AxisAnalogReceived += Analog;
			cc.Virtual.ButtonActiveReceived += Active;
			cc.Virtual.ButtonPressReceived += Press;
			cc.Virtual.ButtonReleaseReceived += Release;

			actionTree.ExpandAll();
			currentMappings.Nodes.Clear();

			foreach (var b in VirtualController.ButtonList)
				SetupButton(b);

			SetupAxisGesture(AxisGesture.LeftXNeg);
			SetupAxisGesture(AxisGesture.LeftXPos);
			SetupAxisGesture(AxisGesture.LeftYNeg);
			SetupAxisGesture(AxisGesture.LeftYPos);
			SetupAxisGesture(AxisGesture.RightXNeg);
			SetupAxisGesture(AxisGesture.RightXPos);
			SetupAxisGesture(AxisGesture.RightYNeg);
			SetupAxisGesture(AxisGesture.RightYPos);
			SetupAxisGesture(AxisGesture.DigitalXNeg);
			SetupAxisGesture(AxisGesture.DigitalXPos);
			SetupAxisGesture(AxisGesture.DigitalYNeg);
			SetupAxisGesture(AxisGesture.DigitalYPos);
            SetupAxisGesture(AxisGesture.TriggerNeg);
            SetupAxisGesture(AxisGesture.TriggerPos);

			currentMappings.ExpandAll();
			RefreshDeviceMappings();
		}

		private void UpdateDeviceInfo()
		{
			string name = controller.Device.ProductName;

			if (controller.DeviceConfig.Label != "") {
				productName.Visible = true;
				deviceName.Text = controller.DeviceConfig.Label;
				productName.Text = controller.Device.ProductName;
			} else {
				productName.Visible = false;
				deviceName.Text = controller.Device.ProductName;
			}

			deviceLabel.Text = controller.DeviceConfig.Label;
			padNotes.Text = controller.DeviceConfig.Notes.Replace("\\n", "\r\n");
		}

		public void RefreshDeviceMappings()
		{
			buttonMappings.Items.Clear();
			foreach (var dm in controller.DeviceConfig.Mappings)
				buttonMappings.Items.Add(new DeviceMappingItem(dm));
		}
		
		private void PadSettingsControl_Load(object sender, EventArgs e)
		{
            padView.SendToBack();

			Fontify.Go(this);
		}

		private void FixTabLayout (TabPage tp, Panel panel)
		{
			tabs.SelectedTab = tp;
			Application.DoEvents();
			panel.SetBounds(0, 0, tp.Width, tp.Height);
			panel.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		}

		private void mapButton_Click(object sender, EventArgs e)
		{
			if (actionTree.SelectedNode == null)
				return;

			if ((string)actionTree.SelectedNode.Tag == "keystroke")
				new MapKeystrokeForm(mainForm, controller).ShowDialog(this);
			else if ((string)actionTree.SelectedNode.Tag == "pointer")
				new MapPointerForm(mainForm, controller).ShowDialog(this);
			else if ((string)actionTree.SelectedNode.Tag == "mouse-button")
				new MapMouseButtonForm(mainForm, controller).ShowDialog(this);
			else if ((string)actionTree.SelectedNode.Tag == "mouse-wheel")
				new MapMouseWheelForm(mainForm, controller).ShowDialog(this);
			else if ((string)actionTree.SelectedNode.Tag == "command")
				new MapCommandDialog(mainForm, controller).ShowDialog(this);
			else if ((string)actionTree.SelectedNode.Tag == "open-file")
				new MapOpenFileDialog(mainForm, controller).ShowDialog(this);
		}

		private void actionTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			mapButton_Click(sender, e);
		}

		private void currentMappings_AfterSelect(object sender, TreeViewEventArgs e)
		{
			var n = currentMappings.SelectedNode;

			if (n == null)
				return;

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

			EditAction(action);
		}

		public void EditAction (InputAction action)
		{
			if (action == null)
				return;

			var cc = this.controller;
			if (action is KeyAction)
				new MapKeystrokeForm(mainForm, cc, action as KeyAction).ShowDialog(this);
			else if (action is MouseButtonAction)
				new MapMouseButtonForm(mainForm, cc, action as MouseButtonAction).ShowDialog(this);
			else if (action is MousePointerAction)
				new MapPointerForm(mainForm, cc, action as MousePointerAction).ShowDialog(this);
			else if (action is MouseWheelAction)
				new MapMouseWheelForm(mainForm, cc, action as MouseWheelAction).ShowDialog(this);
			else if (action is RunCommandAction)
				new MapCommandDialog(mainForm, cc, action as RunCommandAction).ShowDialog(this);
			else if (action is OpenFileAction)
				new MapOpenFileDialog(mainForm, cc, action as OpenFileAction).ShowDialog(this);
			else
				MessageBox.Show("Error: This version of Pad Tie is not able to edit actions of type " + action.GetType().Name);
		}

		private void unmapBtn_Click(object sender, EventArgs e)
		{
			ClearAction(currentMappings.SelectedNode.Tag as InputAction);
		}

		public void ClearAction(InputAction action)
		{
			if (action == null) return;
			MapUtil.Map(mainForm, controller.Virtual, action.SlotDescription, null);
			currentMappings_AfterSelect(currentMappings, null);
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
            RefreshDeviceMappings();
		}

		private void currentMappings_DoubleClick(object sender, EventArgs e)
		{
			editBtn_Click(sender, e);
		}

		private void buttonMappings_DoubleClick(object sender, EventArgs e)
		{
			changeBtn_Click(sender, e);
		}

		void UpdateGestureMenu(bool assigned, ToolStripMenuItem root, ToolStripMenuItem edit, ToolStripMenuItem replace, ToolStripMenuItem clear)
		{
			if (assigned) {
				edit.Visible = true;
				replace.Text = "Replace...";
				clear.Visible = true;
				root.Font = new Font(root.Font, FontStyle.Bold);
			} else {
				edit.Visible = false;
				replace.Text = "Assign...";
				clear.Visible = false;
				root.Font = new Font(root.Font, FontStyle.Regular);
			}

			 var regolo = new Font(root.Font, FontStyle.Regular);
			foreach (ToolStripMenuItem item in root.DropDownItems) item.Font = regolo;
		}

		private void padView_MouseUp(object sender, MouseEventArgs e)
		{
		}

		private void actionTree_AfterSelect(object sender, TreeViewEventArgs e)
		{
			var node = actionTree.SelectedNode;
			string message = "";
			if (node != null && node.Tag is string) {
				if (node.Tag as string == "pointer")
					message = "Control the mouse pointer.";
				else if (node.Tag as string == "mouse-button")
					message = "Simulate mouse clicks.";
				else if (node.Tag as string == "mouse-wheel")
					message = "Simulate the mouse wheel.";
				else if (node.Tag as string == "keystroke")
					message = "Send a keystroke to the active application.";

				message += " Double click the action or click 'Add...' to map it to a gamepad button.";
			} else {
				message = "Click an action above for a short description here.";
			}

			actionTip.Text = message;
		}

		private void editLinkMenu_Click(object sender, EventArgs e)
		{
			EditAction(linkContextMenu.Tag as InputAction);
		}

		private void editTapMenu_Click(object sender, EventArgs e)
		{
			EditAction(tapContextMenu.Tag as InputAction);
		}

		private void editDTapMenu_Click(object sender, EventArgs e)
		{
			EditAction(dtapContextMenu.Tag as InputAction);
		}

		private void editHoldMenu_Click(object sender, EventArgs e)
		{
			EditAction(holdContextMenu.Tag as InputAction);
		}

		private void clearLinkMenu_Click(object sender, EventArgs e)
		{
			ClearAction(linkContextMenu.Tag as InputAction);
		}

		private void clearTapMenu_Click(object sender, EventArgs e)
		{
			ClearAction(tapContextMenu.Tag as InputAction);
		}

		private void clearDTapMenu_Click(object sender, EventArgs e)
		{
			ClearAction(dtapContextMenu.Tag as InputAction);
		}

		private void clearHoldMenu_Click(object sender, EventArgs e)
		{
			ClearAction(holdContextMenu.Tag as InputAction);
		}

		private void clearAllMenuItem_Click(object sender, EventArgs e)
		{
			var ba = clearAllMenuItem.Tag as ButtonActions;
			ClearAction(ba.Link);
			ClearAction(ba.Tap);
			ClearAction(ba.DoubleTap);
			ClearAction(ba.Hold);
		}

		void ReplaceGesture(ButtonActions.Gesture gesture)
		{
			var d = new ActionSelectDialog();
			var slot = (slotMenu.Tag as CapturedInput).Clone();

			slot.ButtonGesture = gesture;
			d.ActionSelect.MainForm = mainForm;
			d.ActionSelect.Controller = controller;
			d.ActionSelect.Slot = slot;

			d.ShowDialog(this.ParentForm);
		}

		private void replaceLinkMenu_Click(object sender, EventArgs e)
		{
			ReplaceGesture(ButtonActions.Gesture.Link);
		}

		private void replaceTapMenu_Click(object sender, EventArgs e)
		{
			ReplaceGesture(ButtonActions.Gesture.Tap);
		}

		private void replaceDoubleTapMenu_Click(object sender, EventArgs e)
		{
			ReplaceGesture(ButtonActions.Gesture.DoubleTap);
		}

		private void replaceHoldMenu_Click(object sendder, EventArgs e)
		{
			ReplaceGesture(ButtonActions.Gesture.Hold);
		}

		private void label15_Click(object sender, EventArgs e)
		{

		}

		private void tabPage4_Click(object sender, EventArgs e)
		{

		}

		private void remapPad_Click(object sender, EventArgs e)
		{
			var dlg = new RemapPadDialog(mainForm, controller.Index, controller.Device.ProductName);
			dlg.ShowDialog(this.ParentForm);

			if (dlg.DialogResult == DialogResult.OK) {
				controller.DeviceConfig.PadNumber = dlg.PadNumber;
				mainForm.GlobalConfig.Save();
				controller.Index = 0; // this way ReassignPadNumber will not consider the old index as in use

				// Attempt to associate the new pad number, or pick the lowest free one, and then reload the current
				// configuration so the mappings work correctly.

				mainForm.ReassignPadNumber(controller);
			}
		}

		internal void SetPadNumber(int padNumber)
		{
			//devicePadNum.Text = padNumber.ToString();
		}

		private void deviceLabel_TextChanged(object sender, EventArgs e)
		{
			controller.DeviceConfig.Label = deviceLabel.Text;
			UpdateDeviceInfo();
			string lbl = controller.Device.ProductName;

			if (deviceLabel.Text != "")
				lbl = deviceLabel.Text;

			if (controller.Tab != null)
				controller.Tab.Text = "Pad #" + controller.Index + " - " + lbl;
			labelHasChanged = true;
		}

		private void deviceLabel_Leave(object sender, EventArgs e)
		{
			if (labelHasChanged)
				mainForm.GlobalConfig.Save();
		}

		bool labelHasChanged = false;
		private void deviceLabel_Enter(object sender, EventArgs e)
		{
			labelHasChanged = false;
		}

		private void padNotes_Leave(object sender, EventArgs e)
		{
			controller.DeviceConfig.Notes = padNotes.Text.Replace("\r", "").Replace("\n", "\\n");
			mainForm.GlobalConfig.Save();
		}

		private void resetLabelBtn_Click(object sender, EventArgs e)
		{
			deviceLabel.Text = "";
		}

		bool fixedLayout = false;

		private void PadSettingsControl_VisibleChanged(object sender, EventArgs e)
		{
			if (Visible && !fixedLayout) {
				fixedLayout = true;
				FixTabLayout(tabInfo, infoTabPanel);
				FixTabLayout(tabButtons, buttonTabPanel);
				FixTabLayout(tabActions, actionsTabPanel);
				FixTabLayout(tabMappings, mappingsTabPanel);
				FixTabLayout(tabNotes, padTabPanel);
			}
		}

		private void padView_MouseDown(object sender, MouseEventArgs e)
		{

			var slot = padView.SelectedItem;
			ButtonActions bslot;

			if (slot == null) {
				padView.ContextMenuStrip = null;
				return;
			} else {
				padView.ContextMenuStrip = slotMenu;
			}

			bslot = slot.GetSlot(controller);
			slotMenu.Tag = slot;

			linkContextMenu.Text = "Link: " + Util.GetActionName(bslot.Link);
			tapContextMenu.Text = "Tap: " + Util.GetActionName(bslot.Tap);
			holdContextMenu.Text = "Hold: " + Util.GetActionName(bslot.Hold);
			dtapContextMenu.Text = "Double Tap: " + Util.GetActionName(bslot.DoubleTap);

			UpdateGestureMenu(bslot.Link != null, linkContextMenu, editLinkMenu, replaceLinkMenu, clearLinkMenu);
			UpdateGestureMenu(bslot.Tap != null, tapContextMenu, editTapMenu, replaceTapMenu, clearTapMenu);
			UpdateGestureMenu(bslot.DoubleTap != null, dtapContextMenu, editDTapMenu, replaceDoubleTapMenu, clearDTapMenu);
			UpdateGestureMenu(bslot.Hold != null, holdContextMenu, editHoldMenu, replaceHoldMenu, clearHoldMenu);

			linkContextMenu.Tag = bslot.Link;
			tapContextMenu.Tag = bslot.Tap;
			dtapContextMenu.Tag = bslot.DoubleTap;
			holdContextMenu.Tag = bslot.Hold;
			clearAllMenuItem.Tag = bslot;
		}
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
		DigitalYNeg,
        TriggerNeg,
        TriggerPos
	}
}
