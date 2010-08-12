using System;
using System.Collections.Generic;

using System.Text;
using DI = Microsoft.DirectX.DirectInput;
using System.Runtime.InteropServices;

namespace PadTie {
	public class InputCore {
		public InputCore()
		{
			TapTimeout = 500;
			DoubleTapTimeout = 250;
			HoldTimeout = 700;
			MouseUpdateInterval = 16;
			GlobalDeadzone = 0;
			AxisPoleSize = 0.7f;
			Mouse = new MouseController(this);

			Controllers = new List<InputController>();
			int index = 0;

			Console.WriteLine("Enumerating devices...");
			foreach (DI.DeviceInstance d in DI.Manager.Devices) {
				if (d.DeviceType == DI.DeviceType.Joystick) {
					Console.WriteLine("Found gamepad " + d.InstanceName + "...");
					Controllers.Add(new InputController(this, new DI.Device(d.InstanceGuid), index++));
				}
			}
		}

		public short TapTimeout { get; set; }
		public short DoubleTapTimeout { get; set; }
		public short HoldTimeout  { get; set; }
		public short MouseUpdateInterval { get; set; }
		public double GlobalDeadzone { get; set; }
		public double AxisPoleSize { get; set; }
		public List<InputController> Controllers { get; set; }
		public MouseController Mouse { get; set; }

		public void RunIteration()
		{
			foreach (var c in Controllers)
				c.Check();
			Mouse.RunIteration();
		}
	}
}
