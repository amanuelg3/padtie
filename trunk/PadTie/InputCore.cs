using System;
using System.Collections.Generic;

using System.Text;
using DI = SlimDX.DirectInput;
using System.Runtime.InteropServices;

namespace PadTie {
	public class InputCore {
		public InputCore(IntPtr diMainWindow)
		{
			DIMainWindow = diMainWindow;
			TapTimeout = 500;
			DoubleTapTimeout = 250;
			HoldTimeout = 700;
			MouseUpdateInterval = 16;
			GlobalDeadzone = 0.01;
			AxisPoleSize = 0.8;

			Mouse = new MouseController(this);
			Controllers = new List<InputController>();

			manager = new DI.DirectInput();

			SlimDX.Configuration.ThrowOnError = true;
			SlimDX.Configuration.AddResultWatch(SlimDX.DirectInput.ResultCode.InputLost, SlimDX.ResultWatchFlags.Throw);
			SlimDX.Configuration.AddResultWatch(SlimDX.DirectInput.ResultCode.Unplugged, SlimDX.ResultWatchFlags.Throw);
			SlimDX.Configuration.AddResultWatch(SlimDX.DirectInput.ResultCode.NotAcquired, SlimDX.ResultWatchFlags.Throw);

			Console.WriteLine("Enumerating devices...");
			ScanForControllers();
		}

		DI.DirectInput manager;

		public object Tag { get; set; }

		public bool ScanForControllers()
		{
			bool foundSome = false;
			var list = manager.GetDevices(DI.DeviceClass.GameController, DI.DeviceEnumerationFlags.AttachedOnly);

			foreach (DI.DeviceInstance d in list) {
				bool found = false;

				foreach (var cc in Controllers) {
					if (cc.Device.Information.InstanceGuid == d.InstanceGuid) {
						found = true;
						break;
					}
				}
				
				if (found) continue;

				Console.WriteLine("Found gamepad " + d.InstanceName + "...");
				Controllers.Add(new InputController(this, new DI.Joystick(manager, d.InstanceGuid), Controllers.Count));
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

		public IntPtr DIMainWindow { get; set; }
	}
}
