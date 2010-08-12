using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PadTie;
using System.Threading;
using System.IO;

namespace PadTieApp {
	public partial class PadTieForm : Form {
		public PadTieForm()
		{
			InitializeComponent();
		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{

		}

		InputCore padTie;
		List<Controller> controllers = new List<Controller>();
		Config config;

		public Config Config { get { return config; } }
		public void RefreshConfigList()
		{
			configBox.Items.Clear();
			string dir = Path.GetDirectoryName(Application.ExecutablePath);
			ConfigItem current = null;

			foreach (string item in Directory.GetFiles(dir, "*.config.xml")) {
				var ci = new ConfigItem(item);
				if (ci.Title == "default") {
					ci.Title = "Default";
				}

				if (ci.FileName == config.FileName)
					current = ci;
				configBox.Items.Add(ci);
			}

			configBox.SelectedItem = current;
		}

		public class ConfigItem {
			public ConfigItem(string file)
			{
				// Just do it twice to get rid of the '.config'
				Title = Path.GetFileNameWithoutExtension(Path.GetFileNameWithoutExtension(file));
				FileName = file;
			}

			public string FileName;
			public string Title;

			public override string ToString()
			{
				return Title;
			}
		}

		public void LoadGlobalConfig()
		{
			// The global configuration deals with the mapping between physical devices
			// and their virtual controller counterparts. If no device entry exists for 
			// a given device, one is created according to the available device information
			// and it is assigned the first pad number which does not have any mappings 
			// associated with it.

			// Sort the device configs by pad number, so we can just assign as we go

			MapDeviceConfigs();
			ConfigureNewDevices();
		}

		int freePad = 1;

		public void ConfigureNewDevices()
		{			
			int newDeviceCount = 0;

			foreach (var ic in padTie.Controllers) {
				if (ic.ApplicationMapped) continue;

				// This controller does not have a configuration associated with it.
				// Try to find a mapping in the database and load that, assigning the 
				// controller to the next free virtual pad, and then advancing the free
				// pad indicator.

				string id = ("0x" + ic.VendorID.ToString("X4") + ic.ProductID.ToString("X4")).ToLower();
				string dir = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "gamepads");
				string configFile = Path.Combine(dir, id + ".xml");

				if (!File.Exists(configFile)) {
					configFile = Path.Combine(dir, "Generic.xml");

					if (!File.Exists (configFile))
						MessageBox.Show ("Error: Your gamepad does not have a pre-made configuration and Pad Tie could not find the generic one.");
					else
						MessageBox.Show ("Your '" + ic.ProductName + "' device does not have a pre-made configuration, you will likely have to fix your button mappings.");
				}
				
				var dc = new DeviceConfig();
				dc.InstanceGUID = ic.InstanceGUID;
				dc.DeviceID = "0x" + ic.VendorID.ToString("X4") + ic.ProductID.ToString("X4");
				dc.Present = false;
				dc.PadNumber = -1;

				if (File.Exists(configFile)) {
					var gpc = GamepadConfig.Load(Path.Combine(dir, id + ".xml"));

					// Copy the mappings so changes don't affect the original 
					foreach (var dm in gpc.Mappings) {
						var dm2 = dm.Clone();
						dm2.Pad = -1;
						dc.Mappings.Add(dm2);
					}
				}

				globalConfig.Devices.Add(dc);
				++newDeviceCount;
				Console.WriteLine("Loaded pre-made configuration for new device '{0}'", ic.ProductName);
			}

			// If we added devices, map their configs to VCs and the UI
			
			if (newDeviceCount > 0) {
				globalConfig.Save();
				MapDeviceConfigs();
			}
		}

		public void MapDeviceConfigs()
		{
			globalConfig.Devices.Sort(delegate(DeviceConfig a, DeviceConfig b)
			{
				int v = a.PadNumber;
				if (v < 0)
					v = 0xFFFFFF;
				return v - b.PadNumber;
			});

			foreach (var dc in globalConfig.Devices) {

				// If the device is marked Present, the config has already been
				// assigned to a device
				if (dc.Present) continue;

				// Find an unmapped device which fits the ID of the config

				foreach (var ic in padTie.Controllers) {
					if (ic.ApplicationMapped) continue;

					if ("0x" + ic.VendorID.ToString("X4") + ic.ProductID.ToString("X4") != dc.DeviceID)
						continue;

					if (dc.InstanceGUID != "" && dc.InstanceGUID != ic.InstanceGUID)
						continue;

					ic.ApplicationMapped = true;
					dc.Present = true;

					int padNumber;
					if (dc.PadNumber != -1 && dc.PadNumber >= freePad) {
						padNumber = dc.PadNumber;
						freePad = padNumber + 1;
					} else {
						padNumber = freePad++;
					}
					
					var cc = new Controller(padTie, ic, padNumber);
					controllers.Add(cc);

					cc.DeviceConfig = dc;
					cc.SettingsUI = new PadSettingsControl();
					cc.SettingsUI.Initialize(this, padTie, cc, padNumber);
					
					cc.Tab = new TabPage("Pad #" + padNumber);
					cc.Tab.Controls.Add(cc.SettingsUI);
					padTabs.TabPages.Add(cc.Tab);

					cc.SettingsUI.Left = 0;
					cc.SettingsUI.Top = 0;
					cc.SettingsUI.Width = cc.Tab.Width;
					cc.SettingsUI.Height = cc.Tab.Height;
					cc.SettingsUI.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

					// Set up the mappings according to the config

					foreach (var mapping in dc.Mappings) {
						int destPad = padNumber;
						if (mapping.Pad != -1)
							destPad = mapping.Pad;

						if (mapping.Source.StartsWith("button:")) {
							int buttonNumber = int.Parse(mapping.Source.Substring("button:".Length));
							VirtualController.Button buttonDest = (VirtualController.Button)Enum.Parse(
								typeof(VirtualController.Button),
								mapping.Destination);

							var ba = new VirtualController.ButtonAction(cc.Virtual, buttonDest);

							if (mapping.Gesture == "Hold")
								ic.Buttons[buttonNumber].Hold = ba;
							else if (mapping.Gesture == "Tap")
								ic.Buttons[buttonNumber].Tap = ba;
							else if (mapping.Gesture == "DoubleTap")
								ic.Buttons[buttonNumber].DoubleTap = ba;
							else
								ic.Buttons[buttonNumber].Link = ba;

						} else if (mapping.Source.StartsWith("axis:")) {
							int axisNumber = int.Parse(mapping.Source.Substring("axis:".Length));
							VirtualController.Axis axisDest = (VirtualController.Axis)Enum.Parse(
								typeof(VirtualController.Axis),
								mapping.Destination);
							ic.Axes[axisNumber].Analog = new VirtualController.AxisAction(cc.Virtual, axisDest);
						}
					}

					Console.WriteLine("Found and mapped configuration for device '{0}' to pad #{1}", ic.ProductName, padNumber);
					break;
				}
			}
		}

		public void LoadConfig()
		{
			string dir = Path.GetDirectoryName(Application.ExecutablePath);
			string configFile = Path.Combine(dir, "default.config.xml");
			string globalConfigFile = Path.Combine(dir, "globalconfig.xml");

			if (!File.Exists(globalConfigFile)) {
				globalConfig = new GlobalConfig();
				globalConfig.Save(globalConfigFile);
			} else {
				globalConfig = GlobalConfig.Load(globalConfigFile);
			}

			LoadGlobalConfig();

			if (globalConfig.Settings.DefaultConfigFile != "")
				configFile = globalConfig.Settings.DefaultConfigFile;

			if (!File.Exists(configFile)) {
				config = new Config();
				
				int index = 0;
				foreach (var cc in controllers) {
					var ccConfig = new PadConfig();
					ccConfig.Index = (index + 1);
					config.Pads.Add(ccConfig);
					++index;
				}

				config.Save(configFile);
			} else {
				config = Config.Load(configFile);
			}

			LoadConfig(config);
		}

		public void LoadConfig(Config config)
		{
			this.config = config;
			foreach (var pc in config.Pads) {
				var cc = GetController(pc.Index);
				if (cc == null) {
					MessageBox.Show(string.Format(
						"Ignoring configuration for pad #{0}, " +
							"connect more game pads or change device " + 
							"mappings and reload to use this pad.", 
						pc.Index));
					continue;
				}

				LoadPadConfig(cc, pc);
			}

			UpdateSettings();
		}

		void UpdateSettings()
		{
			this.padTie.GlobalDeadzone = config.Settings.DefaultDeadzone;
			this.padTie.AxisPoleSize = config.Settings.AxisPoleSize;
			this.padTie.DoubleTapTimeout = config.Settings.DoubleTapInterval;
			this.padTie.TapTimeout = config.Settings.TapInterval;
			this.padTie.HoldTimeout = config.Settings.HoldInterval;

			loadingSettings = true;
			deadzoneSetting.Value = (decimal)(Config.Settings.DefaultDeadzone * 100);
			axisPoleSizeSetting.Value = (decimal)(Config.Settings.AxisPoleSize * 100);
			doubleTapIntervalSetting.Value = config.Settings.DoubleTapInterval;
			tapIntervalSetting.Value = config.Settings.TapInterval;
			holdIntervalSetting.Value = config.Settings.HoldInterval;
			loadingSettings = false;
		}

		bool loadingSettings = false;

		public class AxisConfig {
			public AxisConfig(InputActionConfig neg, InputActionConfig pos)
			{
				Negative = neg;
				Positive = pos;
			}

			public InputActionConfig Negative, Positive;
		}

		public void LoadPadConfig(Controller cc, PadConfig pc)
		{
			cc.Config = pc;
			LoadButton(cc.Virtual, VirtualController.Button.A, pc.A);
			LoadButton(cc.Virtual, VirtualController.Button.B, pc.B);
			LoadButton(cc.Virtual, VirtualController.Button.X, pc.X);
			LoadButton(cc.Virtual, VirtualController.Button.Y, pc.Y);
			LoadButton(cc.Virtual, VirtualController.Button.Br, pc.Br);
			LoadButton(cc.Virtual, VirtualController.Button.Bl, pc.Bl);
			LoadButton(cc.Virtual, VirtualController.Button.Tr, pc.Tr);
			LoadButton(cc.Virtual, VirtualController.Button.Tl, pc.Tl);
			LoadButton(cc.Virtual, VirtualController.Button.Start, pc.Start);
			LoadButton(cc.Virtual, VirtualController.Button.Back, pc.Back);
			LoadButton(cc.Virtual, VirtualController.Button.LeftAnalog, pc.LeftAnalogButton);
			LoadButton(cc.Virtual, VirtualController.Button.RightAnalog, pc.RightAnalogButton);

			MapUtil.Map (this, cc.Virtual, new CapturedInput(VirtualController.Axis.LeftX, false), CreateActionFromConfig(pc.LeftAnalogLeft));
			MapUtil.Map (this, cc.Virtual, new CapturedInput(VirtualController.Axis.LeftX, true), CreateActionFromConfig(pc.LeftAnalogRight));
			MapUtil.Map(this, cc.Virtual, new CapturedInput(VirtualController.Axis.LeftY, false), CreateActionFromConfig(pc.LeftAnalogUp));
			MapUtil.Map(this, cc.Virtual, new CapturedInput(VirtualController.Axis.LeftY, true), CreateActionFromConfig(pc.LeftAnalogDown));
			
			MapUtil.Map(this, cc.Virtual, new CapturedInput(VirtualController.Axis.RightX, false), CreateActionFromConfig(pc.RightAnalogLeft));
			MapUtil.Map(this, cc.Virtual, new CapturedInput(VirtualController.Axis.RightX, true), CreateActionFromConfig(pc.RightAnalogRight));
			MapUtil.Map(this, cc.Virtual, new CapturedInput(VirtualController.Axis.RightY, false), CreateActionFromConfig(pc.RightAnalogUp));
			MapUtil.Map(this, cc.Virtual, new CapturedInput(VirtualController.Axis.RightY, true), CreateActionFromConfig(pc.RightAnalogDown));

			MapUtil.Map(this, cc.Virtual, new CapturedInput(VirtualController.Axis.DigitalX, false), CreateActionFromConfig(pc.DigitalLeft));
			MapUtil.Map(this, cc.Virtual, new CapturedInput(VirtualController.Axis.DigitalX, true), CreateActionFromConfig(pc.DigitalRight));
			MapUtil.Map(this, cc.Virtual, new CapturedInput(VirtualController.Axis.DigitalY, false), CreateActionFromConfig(pc.DigitalUp));
			MapUtil.Map(this, cc.Virtual, new CapturedInput(VirtualController.Axis.DigitalY, true), CreateActionFromConfig(pc.DigitalDown));

			cc.Virtual.LeftXAxis.Tag = new AxisConfig(pc.LeftAnalogLeft, pc.LeftAnalogRight);
			cc.Virtual.LeftYAxis.Tag = new AxisConfig(pc.LeftAnalogUp, pc.LeftAnalogDown);
			cc.Virtual.RightXAxis.Tag = new AxisConfig(pc.RightAnalogLeft, pc.RightAnalogRight);
			cc.Virtual.RightYAxis.Tag = new AxisConfig(pc.RightAnalogUp, pc.RightAnalogDown);
			cc.Virtual.DigitalXAxis.Tag = new AxisConfig(pc.DigitalLeft, pc.DigitalRight);
			cc.Virtual.DigitalYAxis.Tag = new AxisConfig(pc.DigitalUp, pc.DigitalDown);
		}

		public InputAction CreateActionFromConfig(InputActionConfig c)
		{
			if (c == null)
				return null;
			return CreateActionFromConfig(c.Type, c.Parseable);
		}

		public void LoadButton(VirtualController vc, VirtualController.Button button, ButtonActionsConfig ac)
		{
			vc.GetButton(button).Tag = ac;

			if (ac.Link.Type != "none")
				MapButton(vc, button, ButtonActions.Gesture.Link, CreateActionFromConfig(ac.Link.Type, ac.Link.Parseable), false);
			if (ac.Tap.Type != "none")
				MapButton(vc, button, ButtonActions.Gesture.Tap, CreateActionFromConfig(ac.Tap.Type, ac.Tap.Parseable), false);
			if (ac.DoubleTap.Type != "none")
				MapButton(vc, button, ButtonActions.Gesture.DoubleTap, CreateActionFromConfig(ac.DoubleTap.Type, ac.DoubleTap.Parseable), false);
			if (ac.Hold.Type != "none")
				MapButton(vc, button, ButtonActions.Gesture.Hold, CreateActionFromConfig(ac.Hold.Type, ac.Hold.Parseable), false);
		}

		public InputAction CreateActionFromConfig(string type, string parseable)
		{
			switch (type) {
				case "key":
					return KeyAction.Parse (parseable);
				case "pointer":
					return MousePointerAction.Parse (padTie, parseable);
				case "button":
					return MouseButtonAction.Parse (padTie, parseable);
				case "wheel":
					return MouseWheelAction.Parse(padTie, parseable);
				case "command":
					// TODO
					break;
				case "switch-config":
					// TODO
					break;
			}

			return null;
		}

		public void MapButtonToKey(VirtualController vc, VirtualController.Button button, ButtonActions.Gesture gesture,
			User32InputHook.VK key, User32InputHook.VK[] mods)
		{
			Controller c = null;

			foreach (Controller pc in controllers) {
				if (pc.Virtual == vc) {
					c = pc;
					break;
				}
			}

			if (c == null) return;

			var action = new KeyAction(key, mods);
			var gestureID = Util.GetButtonGestureID(gesture);

			c.SettingsUI.SetMapping(string.Format("{0}/{1}", button.ToString(), gestureID), Util.GetActionName(action), action);
			vc.GetButton(button).Map(gesture, action);
		}

		public void MapButton(VirtualController vc, VirtualController.Button button, ButtonActions.Gesture gesture, InputAction action)
		{
			MapButton(vc, button, gesture, action, true);
		}

		public string GetActionType(InputAction action)
		{
			if (action == null)
				return "none";

			if (action is KeyAction)
				return "key";
			else if (action is MousePointerAction)
				return "pointer";
			else if (action is MouseButtonAction)
				return "button";
			else if (action is MouseWheelAction)
				return "wheel";
			return null;
		}

		public Controller GetController(VirtualController vc)
		{
			Controller cc = null;

			foreach (Controller pc in controllers) {
				if (pc.Virtual == vc) {
					cc = pc;
					break;
				}
			}

			return cc;
		}

		public Controller GetController(int padNumber)
		{
			foreach (var cc in controllers) {
				if (cc.Index == padNumber)
					return cc;
			}
			return null;
		}

		public Controller GetController(InputController ic)
		{
			Controller cc = null;

			foreach (Controller pc in controllers) {
				if (pc.Device == ic) {
					cc = pc;
					break;
				}
			}

			return cc;
		}

		public void MapButton(VirtualController vc, VirtualController.Button button, ButtonActions.Gesture gesture, InputAction action, bool save)
		{
			if (action != null) action.SlotDescription = new CapturedInput(button, gesture);

			Controller cc = GetController(vc);
			if (cc == null) return;

			var gestureID = Util.GetButtonGestureID(gesture);
			cc.SettingsUI.SetMapping(string.Format("{0}/{1}", button.ToString(), gestureID), Util.GetActionName(action), action);
			var ba = vc.GetButton(button);
			ba.Map(gesture, action);

			if (save) {
				var config = ba.Tag as ButtonActionsConfig;
				var inputActionConfig = new InputActionConfig(GetActionType(action), (action == null ? "" : action.ToParseable()));
				switch (gesture) {
					case ButtonActions.Gesture.Link:
						config.Link = inputActionConfig;
						break;
					case ButtonActions.Gesture.Tap:
						config.Tap = inputActionConfig;
						break;
					case ButtonActions.Gesture.DoubleTap:
						config.DoubleTap = inputActionConfig;
						break;
					case ButtonActions.Gesture.Hold:
						config.Hold = inputActionConfig;
						break;
				}

				SaveConfig();
			}
		}

		public void MapAxisGesture(VirtualController vc, VirtualController.Axis axis, AxisActions.Gestures gesture, InputAction action)
		{
			MapAxisGesture(vc, axis, gesture, action, true);
		}

		public void MapAxisGesture(VirtualController vc, VirtualController.Axis axis, AxisActions.Gestures gesture, InputAction action, bool save)
		{
			if (action != null)
				action.SlotDescription = new CapturedInput(axis, gesture == AxisActions.Gestures.Positive);

			Controller cc = GetController(vc);
			if (cc == null) return;

			var gestureID = Util.GetAxisGestureID(axis, gesture);
			cc.SettingsUI.SetMapping(gestureID, Util.GetActionName(action), action);
			var aa = vc.GetAxis(axis);
			aa.Map(gesture, action);

			if (save) {
				var config = aa.Tag as AxisConfig;
				InputActionConfig inputActionConfig;

				if (config != null) {
					if (gesture == AxisActions.Gestures.Positive)
						inputActionConfig = config.Positive;
					else
						inputActionConfig = config.Negative;

					inputActionConfig.Type = GetActionType(action);
					inputActionConfig.Parseable = (action == null ? "" : action.ToParseable());
					
					SaveConfig();
				}
				
			}
		}

		private void PadTieForm_Load(object sender, EventArgs e)
		{
			Init();
			
			if (padTie.Controllers.Count == 0) {
				waitingForControllers = new WaitingForControllersForm(this);
				waitingForControllers.ShowDialog(this);
			}

			LoadConfig();
			RefreshConfigList();
			this.Show();
		}

		internal bool Init()
		{
			int index = 1;
			padTie = new InputCore();

			if (padTie.Controllers.Count == 0) {
				// padTie.Dispose();
				padTie = null;
				return false;
			}

			return true;
		}

		public WaitingForControllersForm waitingForControllers { get; set; }

		private void iterationTimer_Tick(object sender, EventArgs e)
		{
			if (padTie == null) return;
			padTie.RunIteration();
		}

		private void cloneBtn_Click(object sender, EventArgs e)
		{
			var sfd = new SaveFileDialog();
			sfd.AddExtension = true;
			sfd.SupportMultiDottedExtensions = true;
			sfd.DefaultExt = ".config.xml";
			sfd.Filter = "Pad Tie configuration file (*.config.xml)|*.config.xml|All files (*.*)|*";

			var result = sfd.ShowDialog(this);
			if (result == System.Windows.Forms.DialogResult.OK) {
				config.Save(sfd.FileName);
				RefreshConfigList();
			}
		}

		private void configBox_TextChanged(object sender, EventArgs e)
		{
			ConfigItem item = configBox.SelectedItem as ConfigItem;

			if (item == null) return;

			if (!File.Exists(item.FileName)) {
				MessageBox.Show("Could not locate configuration, it may have been deleted.");
				RefreshConfigList();
				return;
			}

			foreach (var cc in controllers)
				cc.Reset();
			
			LoadConfig(Config.Load (item.FileName));
		}

		public void SaveConfig()
		{
			config.Save();
		}

		private void tapIntervalSetting_ValueChanged(object sender, EventArgs e)
		{
			if (!loadingSettings) {
				padTie.TapTimeout = Config.Settings.TapInterval = (short)tapIntervalSetting.Value;
				SaveConfig();
			}
		}

		private void doubleTapIntervalSetting_ValueChanged(object sender, EventArgs e)
		{
			if (!loadingSettings) {
				padTie.DoubleTapTimeout = Config.Settings.DoubleTapInterval = (short)doubleTapIntervalSetting.Value;
				SaveConfig();
			}
		}

		private void holdIntervalSetting_ValueChanged(object sender, EventArgs e)
		{
			if (!loadingSettings) {
				padTie.HoldTimeout = config.Settings.HoldInterval = (short)holdIntervalSetting.Value;
				SaveConfig();
			}
		}

		private void deadzoneSetting_ValueChanged(object sender, EventArgs e)
		{
			if (!loadingSettings) {
				padTie.GlobalDeadzone = config.Settings.DefaultDeadzone = ((double)deadzoneSetting.Value / 100);
				SaveConfig();
			}
		}

		private void axisPoleSizeSetting_ValueChanged(object sender, EventArgs e)
		{
			if (!loadingSettings) {
				padTie.AxisPoleSize = config.Settings.AxisPoleSize = ((double)axisPoleSizeSetting.Value / 100);
				SaveConfig();
			}
		}

		GlobalConfig globalConfig { get; set; }

		public GlobalConfig GlobalConfig { get { return globalConfig; } }
	}

	public class Util {
		public static string GetButtonGestureID(ButtonActions.Gesture gesture)
		{
			var gestureID = "link";

			if (gesture == ButtonActions.Gesture.Tap) gestureID = "tap";
			if (gesture == ButtonActions.Gesture.DoubleTap) gestureID = "dtap";
			if (gesture == ButtonActions.Gesture.Hold) gestureID = "hold";

			return gestureID;
		}

		public static string GetActionName(InputAction action)
		{
			if (action == null) return "Unassigned";
			return action.ToString();
		}

		public static string GetButtonDisplayName(VirtualController.Button button)
		{
			string name = button.ToString();

			if (button == VirtualController.Button.Bl) name = "Left Bumper";
			if (button == VirtualController.Button.Br) name = "Right Bumper";
			if (button == VirtualController.Button.Tl) name = "Left Trigger";
			if (button == VirtualController.Button.Tr) name = "Right Trigger";

			return name;
		}

		public static string GetAxisDisplayName(VirtualController.Axis axis)
		{
			string name = axis.ToString();

			if (axis == VirtualController.Axis.LeftX)
				name = "Left Analog X";
			else if (axis == VirtualController.Axis.LeftY)
				name = "Left Analog Y";
			else if (axis == VirtualController.Axis.RightX)
				name = "Right Analog X";
			else if (axis == VirtualController.Axis.RightY)
				name = "Right Analog Y";
			else if (axis == VirtualController.Axis.DigitalX)
				name = "Digital X";
			else if (axis == VirtualController.Axis.DigitalY)
				name = "Digital Y";

			return name;
		}

		public static string GetStickDisplayName(VirtualController.Axis axis)
		{
			string name = axis.ToString();

			if (axis == VirtualController.Axis.LeftX || axis == VirtualController.Axis.LeftY)
				name = "Left Analog";
			else if (axis == VirtualController.Axis.RightX || axis == VirtualController.Axis.RightY)
				name = "Right Analog";
			else if (axis == VirtualController.Axis.DigitalX || axis == VirtualController.Axis.DigitalY)
				name = "Digital";

			return name;
		}

		public static string GetButtonGestureName(ButtonActions.Gesture gesture)
		{
			string name = gesture.ToString();

			if (gesture == ButtonActions.Gesture.DoubleTap)
				name = "Double Tap";

			return name;
		}

		public static string GetAxisGestureName(VirtualController.Axis axis, bool pos)
		{
			if (axis == VirtualController.Axis.RightX || axis == VirtualController.Axis.LeftX || axis == VirtualController.Axis.DigitalX) {
				if (pos) return "Right";
				else return "Left";
			} else {
				if (pos) return "Down";
				else return "Up";
			}
		}

		public static string GetAxisGestureID(VirtualController.Axis axis, AxisActions.Gestures gesture)
		{
			string id = "";

			if (axis == VirtualController.Axis.LeftX || axis == VirtualController.Axis.LeftY)
				id = "left-analog/";
			else if (axis == VirtualController.Axis.RightX || axis == VirtualController.Axis.RightY)
				id = "right-analog/";
			else if (axis == VirtualController.Axis.DigitalX || axis == VirtualController.Axis.DigitalY)
				id = "digital/";

			if (axis == VirtualController.Axis.LeftX || axis == VirtualController.Axis.RightX || axis == VirtualController.Axis.DigitalX)
				id += "x/";
			else
				id += "y/";

			if (gesture == AxisActions.Gestures.Positive)
				return id + "pos";
			else if (gesture == AxisActions.Gestures.Negative)
				return id + "neg";
			else if (gesture == AxisActions.Gestures.Analog)
				return id + "analog";

			return id + "unknown";
		}

		internal static string GetKeyName(Keys key)
		{
			string name = key.ToString();

			if (key == Keys.ControlKey)
				name = "Control";
			else if (key == Keys.ShiftKey)
				name = "Shift";
			else if (key == Keys.PageUp)
				name = "Page Up";
			else if (key == Keys.PageDown)
				name = "Page Down";
			else if (key == Keys.Back)
				name = "Backspace";
			else if (name.Length == 2 && name[0] == 'D')
				name = name[1].ToString();

			return name;
		}
	}

	public class Controller {
		public Controller(InputCore core, InputController ic, int index)
		{
			Core = core;
			Virtual = new VirtualController(core);
			Device = ic;
			Index = index;
		}

		public int Index { get; set; }
		public InputCore Core { get; set; }
		public VirtualController Virtual;
		public InputController Device;
		public PadSettingsControl SettingsUI;
		public PadConfig Config;
		public DeviceConfig DeviceConfig;

		public void Reset()
		{
			Virtual.Reset();
			SettingsUI.ResetMappings();
		}

		public TabPage Tab { get; set; }
	}
}
