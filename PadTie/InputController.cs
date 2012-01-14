using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DI = SlimDX.DirectInput;
using SlimDX.DirectInput;

namespace PadTie {
	public class InputController {
		public InputController(InputCore core, DI.Joystick dev, int index)
		{
			if (core == null)
				throw new ArgumentNullException("core");
			if (dev == null)
				throw new ArgumentNullException("dev");
			if (index < 0)
				throw new ArgumentOutOfRangeException("index", "assertion failed: index >= 0");

			Core = core;
			Device = dev;

			ApplyExclusivity();
			Device.Acquire();
                    
			ID = index;
			Buttons = new ButtonActions[ButtonCount];
			Axes = new AxisActions[AxisCount];

			for (int i = 0, max = Buttons.Length; i < max; ++i) Buttons[i] = new ButtonActions(Core, false, i + 1);
			for (int i = 0, max = Axes.Length; i < max; ++i) Axes[i] = new AxisActions(Core, false, true, i + 1);
		}

		public bool ExclusiveLock = false;

		/// <summary>
		/// This flag can be used by the application to mark the input controller as mapped to a 
		/// virtual controller configuration. It is not used by the Pad Tie library.
		/// </summary>
		public bool ApplicationMapped { get; set; }

		public InputCore Core { get; private set; }
		public int ID { get; private set; }
		public DI.Joystick Device { get; private set; }
		public int ButtonCount { get { return Device.Capabilities.ButtonCount; } }
		public int AxisCount { get { return Device.Capabilities.AxesCount + Device.Capabilities.PovCount * 2; } }
		
		public bool Removed = false;
		public ButtonActions[] Buttons { get; private set; }
		public AxisActions[] Axes { get; private set; }

		public void Check()
		{
			if (Removed) return;

			bool[] buttonData;
			int[] hats, uv;

			DI.JoystickState state;
			// Buttons 

			SlimDX.Result r;
			
			// SlimDX has some serious issues with actually getting 
			// exceptions thrown when you want.
			
			try {

				if ((r = Device.Acquire()).IsFailure)
					throw new DirectInputException(r);

				if ((Device.Capabilities.Flags & DeviceFlags.PolledDevice) != 0) {
					if ((r = Device.Poll()).IsFailure)
						throw new DirectInputException(r);
				}

				state = Device.GetCurrentState();

				if (SlimDX.Result.Last.IsFailure)
					throw new DirectInputException(SlimDX.Result.Last);
			
				buttonData = state.GetButtons();
				hats = state.GetPointOfViewControllers();
				uv = state.GetForceSliders();
			} catch (DI.DirectInputException e) {
				if (e.ResultCode == DI.ResultCode.InputLost ||
					e.ResultCode == DI.ResultCode.NotAcquired) {
					Console.WriteLine("Input lost: trying to reacquire...");

					Device.Unacquire();
					try {
						ApplyExclusivity();
					} catch (DI.DirectInputException e2) { }

					try {
						r = Device.Acquire();
					} catch (DI.DirectInputException e2) {
						r = e2.ResultCode;
						ExclusiveLock = false;
					}

					if (r == SlimDX.DirectInput.ResultCode.Unplugged) {
						Console.WriteLine("Gamepad disconnected...");
						Removed = true;
					} else if (r.IsFailure) {
						Console.WriteLine("Failure while acquiring device: " + r.Description);
					} else {
						Console.WriteLine("Reacquired successfully.");
					}
				} else if (e.ResultCode == DI.ResultCode.Unplugged) {
					Removed = true;
				} else {
					Console.WriteLine("DirectInput exception: " + e.ResultCode + ": \n" + e);
				}

				return;
			}

			for (int x = 0, max = ButtonCount; x < max; ++x)
				Buttons[x].Process((byte)(buttonData[x] ? 1 : 0));

			// Axes
            var axisData = new[] { state.X, state.Y, state.RotationX, state.RotationY };
            for (int x = 0; x < Math.Min(AxisCount, axisData.Length); ++x)
                Axes[x].Process(axisData[x]);

			int axisIndex = 4;
			foreach (int hat in hats) {
				if (axisIndex - 4 >= Device.Capabilities.PovCount)
					break;

				var xAxis = Axes[axisIndex];
				var yAxis = Axes[axisIndex+1];

				if (hat == -1) {
					xAxis.Process(ushort.MaxValue / 2);
					yAxis.Process(ushort.MaxValue / 2);
				} else {
					// Map a POV hat to a pair of X/Y axes using trig makes for super simple!!
					double x = Math.Cos(Math.PI / 2 - hat / 100.0 * (Math.PI / 180));
					double y = Math.Sin(Math.PI / 2 - hat / 100.0 * (Math.PI / 180));

					int xr = (int)((x + 1) / 2.0 * ushort.MaxValue);
					int yr = (int)((-y + 1) / 2.0 * ushort.MaxValue);
					Console.WriteLine("v: {2}, x: {0}, y: {1}", xr, yr, hat);
					xAxis.Process(xr);
					yAxis.Process(yr);
				}

				axisIndex += 2;
			}
            if(Axes.Length > axisIndex)
                Axes[axisIndex].Process(state.Z);
			//Axes[3].Process(Device.CurrentJoystickState.Rx);
			//if (Axes.Length > 3) Axes[3].Process(uv[0]);
			//if (Axes.Length > 4) Axes[4].Process(uv[1]);
		}

		private void ApplyExclusivity()
		{
			if (Core.DIMainWindow != null) {
				if (ExclusiveLock)
					Device.SetCooperativeLevel(Core.DIMainWindow, CooperativeLevel.Exclusive | CooperativeLevel.Background);
				else
					Device.SetCooperativeLevel(Core.DIMainWindow, CooperativeLevel.Nonexclusive | CooperativeLevel.Background);
			}
		}

		public string Name { get { return Device.Information.InstanceName; } }
		public string ProductName { get { return Device.Information.ProductName; } }
		public string ProductGUID { get { return Device.Information.ProductGuid.ToString(); } }
		public string InstanceGUID { get { return Device.Information.InstanceGuid.ToString(); } }
		public int VendorID { get { return Device.Properties.VendorId; } }
		public int ProductID { get { return Device.Properties.ProductId; } }
		public int HatCount { get { return Device.Capabilities.PovCount; } }
		public bool ForceFeedback { get { return (Device.Capabilities.Flags & DeviceFlags.ForceFeedback) != 0; } }

		public void Reset()
		{
			foreach (var btn in Buttons) {
				btn.Link = null;
				btn.Hold = null;
				btn.Tap = null;
				btn.DoubleTap = null;
			}

			foreach (var axis in Axes) {
				axis.Analog = null;
				axis.Positive = null;
				axis.Negative = null;
			}
		}
	}
}
