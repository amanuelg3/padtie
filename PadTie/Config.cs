using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.ComponentModel;

namespace PadTie {
	public class InputActionConfig {
		public InputActionConfig()
		{
		}

		public InputActionConfig(string type, string parseable)
		{
			Type = type;
			Parseable = parseable;
		}

		[XmlAttribute("type")]
		public string Type;

		[XmlText]
		public string Parseable;

		public static InputActionConfig Null {
			get {
				var i = new InputActionConfig();
				i.Type = "none";
				i.Parseable = "";
				return i;
			}
		}
	}

	[Serializable]
	public class ButtonActionsConfig {
		[XmlElement("link")] public InputActionConfig Link = InputActionConfig.Null;
		[XmlElement("tap")]  public InputActionConfig Tap = InputActionConfig.Null;
		[XmlElement("dtap")] public InputActionConfig DoubleTap = InputActionConfig.Null;
		[XmlElement("hold")] public InputActionConfig Hold = InputActionConfig.Null;

		[XmlElement("overview"), DefaultValue("")]
		public string Overview = "";

		public InputActionConfig GetGesture(ButtonActions.Gesture g)
		{
			switch (g) {
				case ButtonActions.Gesture.Link: return Link;
				case ButtonActions.Gesture.Tap: return Tap;
				case ButtonActions.Gesture.DoubleTap: return DoubleTap;
				case ButtonActions.Gesture.Hold: return Hold;
			}
			return null;
		}
	}

	public class AxisActionsConfig : ButtonActionsConfig {
		[XmlAttribute("type")]
		public string CompatType = null;

		[XmlText]
		public string CompatParseable = null;
	}

	[Serializable]
	public class PadConfig {

		[XmlAttribute("index")]
		public int Index = 0;

		public ButtonActionsConfig GetButton(VirtualController.Button button)
		{	
			switch (button) {
				case VirtualController.Button.A: return this.A;
				case VirtualController.Button.B: return this.B;
				case VirtualController.Button.X: return this.X;
				case VirtualController.Button.Y: return this.Y;
				case VirtualController.Button.Bl: return this.Bl;
				case VirtualController.Button.Br: return this.Br;
				case VirtualController.Button.Tl: return this.Tl;
				case VirtualController.Button.Tr: return this.Tr;
				case VirtualController.Button.Start: return this.Start;
				case VirtualController.Button.Back: return this.Back;
				case VirtualController.Button.System: return this.System;
				case VirtualController.Button.LeftAnalog: return this.LeftAnalogButton;
				case VirtualController.Button.RightAnalog: return this.RightAnalogButton;

			}
			
			return null;
		}

		public AxisActionsConfig GetAxisGesture(VirtualController.Axis axis, bool pos)
		{
			switch (axis) {
				case VirtualController.Axis.LeftX:
					if (pos)
						return LeftAnalogRight;
					else
						return LeftAnalogLeft;
				case VirtualController.Axis.LeftY:
					if (pos)
						return LeftAnalogDown;
					else
						return LeftAnalogUp;
				case VirtualController.Axis.RightX:
					if (pos)
						return RightAnalogRight;
					else
						return RightAnalogLeft;
				case VirtualController.Axis.RightY:
					if (pos)
						return RightAnalogDown;
					else
						return RightAnalogUp;
				case VirtualController.Axis.DigitalX:
					if (pos)
						return DigitalRight;
					else
						return DigitalLeft;
				case VirtualController.Axis.DigitalY:
					if (pos)
						return DigitalDown;
					else
						return DigitalUp;
                case VirtualController.Axis.Trigger:
                    if (pos)
                        return LeftAnalogRight;
                    else
                        return LeftAnalogLeft; 
			}

			return null;
		}

		[XmlElement("a")]
		public ButtonActionsConfig A = new ButtonActionsConfig();
		[XmlElement("b")]
		public ButtonActionsConfig B = new ButtonActionsConfig();
		[XmlElement("x")]
		public ButtonActionsConfig X = new ButtonActionsConfig();
		[XmlElement("y")]
		public ButtonActionsConfig Y = new ButtonActionsConfig();
		[XmlElement("back")]
		public ButtonActionsConfig Back = new ButtonActionsConfig();
		[XmlElement("start")]
		public ButtonActionsConfig Start = new ButtonActionsConfig();
		[XmlElement("system")]
		public ButtonActionsConfig System = new ButtonActionsConfig();
		[XmlElement("bl")]
		public ButtonActionsConfig Bl = new ButtonActionsConfig();
		[XmlElement("br")]
		public ButtonActionsConfig Br = new ButtonActionsConfig();
		[XmlElement("tl")]
		public ButtonActionsConfig Tl = new ButtonActionsConfig();
		[XmlElement("tr")]
		public ButtonActionsConfig Tr = new ButtonActionsConfig();
		[XmlElement("la")]
		public ButtonActionsConfig LeftAnalogButton = new ButtonActionsConfig();
		[XmlElement("ra")]
		public ButtonActionsConfig RightAnalogButton = new ButtonActionsConfig();

		[XmlElement("la-up")]
		public AxisActionsConfig LeftAnalogUp = new AxisActionsConfig();
		[XmlElement("la-down")]
		public AxisActionsConfig LeftAnalogDown = new AxisActionsConfig();
		[XmlElement("la-left")]
		public AxisActionsConfig LeftAnalogLeft = new AxisActionsConfig();
		[XmlElement("la-right")]
		public AxisActionsConfig LeftAnalogRight = new AxisActionsConfig();

        [XmlElement("trigger-left")]
        public AxisActionsConfig TriggerLeft = new AxisActionsConfig();
        [XmlElement("trigger-right")]
        public AxisActionsConfig TriggerRight = new AxisActionsConfig();

		[XmlElement("ra-up")]
		public AxisActionsConfig RightAnalogUp = new AxisActionsConfig();
		[XmlElement("ra-down")]
		public AxisActionsConfig RightAnalogDown = new AxisActionsConfig();
		[XmlElement("ra-left")]
		public AxisActionsConfig RightAnalogLeft = new AxisActionsConfig();
		[XmlElement("ra-right")]
		public AxisActionsConfig RightAnalogRight = new AxisActionsConfig();

		[XmlElement("dig-up")]
		public AxisActionsConfig DigitalUp = new AxisActionsConfig();
		[XmlElement("dig-down")]
		public AxisActionsConfig DigitalDown = new AxisActionsConfig();
		[XmlElement("dig-left")]
		public AxisActionsConfig DigitalLeft = new AxisActionsConfig();
		[XmlElement("dig-right")]
		public AxisActionsConfig DigitalRight = new AxisActionsConfig();
	}

	[Serializable, XmlRoot("config")]
	public class Config {
		[XmlIgnore]
		public bool Builtin = false;

		public static Config Load(string filename)
		{
			XmlSerializer s = new XmlSerializer (typeof (Config));
			Config cfg;
			
			using (var stream = File.Open (filename, FileMode.Open, FileAccess.Read))
				cfg = s.Deserialize (stream) as Config;

			cfg.FileName = filename;
			return cfg;
		}

		[XmlElement("pad")]
		public List<PadConfig> Pads = new List<PadConfig>();

		[XmlIgnore]
		public string FileName;

		[XmlAttribute("label"), DefaultValue("")]
		public string Label = "";

		[XmlElement("info"), DefaultValue("")]
		public string Info = "";

		public void Save()
		{
			if (FileName == null) throw new InvalidOperationException("You must choose a filename");
			Save(FileName);
		}


		public void Save(string configFile)
		{
			lock (this) {
				FileName = configFile;
				XmlSerializer s = new XmlSerializer(typeof(Config));
				using (var stream = File.Open(FileName, FileMode.Create)) {
					s.Serialize(stream, this);
					stream.Close();
				}
			}
		}

		[XmlIgnore]
		public bool UpdatedForCompatibility { get; set; }

		[XmlIgnore]
		public List<string> CompatibilityUpdates = new List<string>();

		[XmlIgnore]
		public bool NoPadsConfigured { get; set; }
	}

	public class DeviceMapping {
		public DeviceMapping()
		{
		}

		public DeviceMapping Clone()
		{
			var dm = new DeviceMapping();
			dm.Pad = Pad;
			dm.Source = Source;
			dm.Gesture = Gesture;
			dm.Destination = Destination;
			return dm;
		}

		[XmlAttribute("pad"), DefaultValue(-1)]
		public int Pad = -1;

		[XmlAttribute("src")]
		public string Source;

		[XmlAttribute("gesture"), DefaultValue("Raw")]
		public string Gesture = null;

		[XmlAttribute("dest")]
		public string Destination;
	}

	[Serializable]
	public class DeviceConfig {
		[XmlIgnore]
		public bool Present = false;

		[XmlAttribute("deviceID")]
		public string DeviceID;

		/// <summary>
		/// When positive, specifies the pad number to map the device to. Otherwise we map
		/// to the first free pad number.
		/// </summary>
		[XmlAttribute("pad"), DefaultValue(-1)]
		public int PadNumber { get; set; }

		[XmlAttribute("exclusive-lock"), DefaultValue(true)]
		public bool ExclusiveLock = true;

		[XmlIgnore]
		public bool IsGeneric = false;

		/// <summary>
		/// If empty, only the deviceID is matched. Otherwise, the
		/// device must match the given instance GUID (this allows
		/// multiple identical controllers to be mapped the same way
		/// no matter which order they are plugged).
		/// </summary>
		[XmlAttribute("instanceGUID")]
		public string InstanceGUID = "";

		/// <summary>
		/// If non-empty, the controller will be referred to by this label.
		/// If empty, Pad Tie falls back on the DirectInput display-friendly
		/// name, and if that is blank, falls back to the product name string.
		/// </summary>
		[XmlAttribute("label"), DefaultValue("")]
		public string Label = "";

		[XmlElement("notes"), DefaultValue("")]
		public string Notes = "";

		[XmlElement("mapping")]
		public List<DeviceMapping> Mappings =
			new List<DeviceMapping>();
	}

	public class GlobalSettingsConfig {
		public GlobalSettingsConfig()
		{
		}

		[XmlElement("default-config"), DefaultValue("")]
		public string DefaultConfigFile = "";

		[XmlElement("tap-interval"), DefaultValue(500)]
		public short TapInterval = 500;

		[XmlElement("double-tap-interval"), DefaultValue(250)]
		public short DoubleTapInterval = 250;

		[XmlElement("hold-interval"), DefaultValue(700)]
		public short HoldInterval = 700;
		
		[XmlElement("default-deadzone"), DefaultValue(0.01)]
		public double DefaultDeadzone = 0.01;
		
		[XmlElement("axis-pole-size"), DefaultValue(0.8)]
		public double AxisPoleSize = 0.8;

		[XmlElement("show-balloon-tips"), DefaultValue(true)]
		public bool ShowBalloonTips = true;

		[XmlElement("balloon-tip-timeout"), DefaultValue(60)]
		public int BalloonTipTimeout = 60;

		[XmlElement("show-compat-notices"), DefaultValue(true)]
		public bool ShowCompatibilityNotices = true;

		[XmlElement("show-no-gamepad-notices"), DefaultValue(true)]
		public bool ShowNoGamepadConfigured = true;

		[XmlElement("remember-window-size"), DefaultValue(true)]
		public bool RememberWindowSize = true;

		[XmlElement("window-x"), DefaultValue(-1)]
		public int WindowX = -1;
		
		[XmlElement("window-y"), DefaultValue(-1)]
		public int WindowY = -1;
		
		[XmlElement("window-w"), DefaultValue(-1)]
		public int WindowWidth = -1;
		
		[XmlElement("window-h"), DefaultValue(-1)]
		public int WindowHeight = -1;

		[XmlElement("window-max"), DefaultValue(false)]
		public bool WindowMaximized = false;

	}

	[Serializable, XmlRoot("padtie-config")]
	public class GlobalConfig {
		public static GlobalConfig Load(string filename)
		{
			XmlSerializer s = new XmlSerializer(typeof(GlobalConfig));
			GlobalConfig cfg;

			using (var stream = File.Open(filename, FileMode.Open, FileAccess.Read))
				cfg = s.Deserialize(stream) as GlobalConfig;

			cfg.FileName = filename;
			return cfg;
		}

		[XmlElement("device")]
		public List<DeviceConfig> Devices = new List<DeviceConfig>();

		[XmlElement("settings")]
		public GlobalSettingsConfig Settings = new GlobalSettingsConfig();

		[XmlIgnore]
		public string FileName;

		public void Save()
		{
			if (FileName == null) throw new InvalidOperationException("You must choose a filename");
			Save(FileName);
		}


		public void Save(string configFile)
		{
			lock (this) {
				FileName = configFile;

				if (File.Exists(FileName)) {
					// Back it up so if we fail to load the new file 
					// we at least have the old settings.
					string backupFile = Path.Combine(Path.GetDirectoryName(FileName), Path.GetFileNameWithoutExtension(FileName) + ".backup.xml");
					try {
						if (File.Exists(backupFile))
							File.Delete(backupFile);
						File.Move(FileName, backupFile);
					} catch (Exception) { }
				}

				XmlSerializer s = new XmlSerializer(typeof(GlobalConfig));
				using (var stream = File.Open(FileName, FileMode.Create)) {
					s.Serialize(stream, this);
					stream.Close();
				}
			}
		}
	}

	[Serializable, XmlRoot("gamepad")]
	public class GamepadConfig {
		public static GamepadConfig Load(string filename)
		{
			XmlSerializer s = new XmlSerializer(typeof(GamepadConfig));
			GamepadConfig cfg;

			using (var stream = File.Open(filename, FileMode.Open, FileAccess.Read))
				cfg = s.Deserialize(stream) as GamepadConfig;

			cfg.FileName = filename;
			return cfg;
		}

		[XmlAttribute("deviceID")]
		public string DeviceID;

		[XmlAttribute("vendor")]
		public string Vendor;

		[XmlAttribute("product")]
		public string Product;

		[XmlAttribute("exclusive-lock")]
		public bool ExclusiveLock;

		[XmlElement("notes")]
		public string Notes;

		[XmlElement("mapping")]
		public List<DeviceMapping> Mappings =
			new List<DeviceMapping>();

		[XmlIgnore]
		public string FileName;

		public void Save()
		{
			if (FileName == null) throw new InvalidOperationException("You must choose a filename");
			Save(FileName);
		}


		public void Save(string configFile)
		{
			lock (this) {
				FileName = configFile;
				XmlSerializer s = new XmlSerializer(typeof(GamepadConfig));
				using (var stream = File.Open(FileName, FileMode.Create)) {
					s.Serialize(stream, this);
					stream.Close();
				}
			}
		}

		[XmlIgnore]
		public bool IsGeneric { get; set; }
	}
}
