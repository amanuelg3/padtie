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
			GlobalDeadzone = 0.01;
			AxisPoleSize = 0.8;

			Mouse = new MouseController(this);

			Controllers = new List<InputController>();
			int index = 0;

			Console.WriteLine("Enumerating devices...");
			ScanForControllers();
		}

		public bool ScanForControllers()
		{
			bool foundSome = false;

			foreach (DI.DeviceInstance d in DI.Manager.Devices) {
				bool found = false;
				
				if (d.DeviceType != DI.DeviceType.Joystick) continue;

				foreach (var cc in Controllers) {
					if (cc.Device.DeviceInformation.InstanceGuid == d.InstanceGuid) {
						found = true;
						break;
					}
				}
				
				if (found) continue;

				Console.WriteLine("Found gamepad " + d.InstanceName + "...");
				Controllers.Add(new InputController(this, new DI.Device(d.InstanceGuid), Controllers.Count));
				foundSome = true;
			}

			return foundSome;
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
