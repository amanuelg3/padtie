using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

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
				case VirtualController.Button.LeftAnalog: return this.LeftAnalogButton;
				case VirtualController.Button.RightAnalog: return this.RightAnalogButton;

			}
			
			return null;
		}

		public InputActionConfig GetAxisGesture(VirtualController.Axis axis, bool pos)
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
		public InputActionConfig LeftAnalogUp = InputActionConfig.Null;
		[XmlElement("la-down")]
		public InputActionConfig LeftAnalogDown = InputActionConfig.Null;
		[XmlElement("la-left")]
		public InputActionConfig LeftAnalogLeft = InputActionConfig.Null;
		[XmlElement("la-right")]
		public InputActionConfig LeftAnalogRight = InputActionConfig.Null;

		[XmlElement("ra-up")]
		public InputActionConfig RightAnalogUp = InputActionConfig.Null;
		[XmlElement("ra-down")]
		public InputActionConfig RightAnalogDown = InputActionConfig.Null;
		[XmlElement("ra-left")]
		public InputActionConfig RightAnalogLeft = InputActionConfig.Null;
		[XmlElement("ra-right")]
		public InputActionConfig RightAnalogRight = InputActionConfig.Null;

		[XmlElement("dig-up")]
		public InputActionConfig DigitalUp = InputActionConfig.Null;
		[XmlElement("dig-down")]
		public InputActionConfig DigitalDown = InputActionConfig.Null;
		[XmlElement("dig-left")]
		public InputActionConfig DigitalLeft = InputActionConfig.Null;
		[XmlElement("dig-right")]
		public InputActionConfig DigitalRight = InputActionConfig.Null;
	}

	[Serializable]
	public class SettingsConfig {
		public short TapInterval = 500;
		public short DoubleTapInterval = 250;
		public short HoldInterval = 700;
		public double DefaultDeadzone = 0;
		public double AxisPoleSize = 0.7;
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

		[XmlElement("settings")]
		public SettingsConfig Settings = new SettingsConfig();

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
				XmlSerializer s = new XmlSerializer(typeof(Config));
				using (var stream = File.Open(FileName, FileMode.Create)) {
					s.Serialize(stream, this);
					stream.Close();
				}
			}
		}
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

		[XmlAttribute("pad")]
		public int Pad = -1;

		[XmlAttribute("src")]
		public string Source;

		[XmlAttribute("gesture")]
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
		[XmlAttribute("pad")]
		public int PadNumber { get; set; }

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
		[XmlAttribute("label")]
		public string Label = "";

		[XmlElement("mapping")]
		public List<DeviceMapping> Mappings =
			new List<DeviceMapping>();
	}

	public class GlobalSettingsConfig {
		[XmlAttribute("default-config")]
		public string DefaultConfigFile = "";
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
	}
}
