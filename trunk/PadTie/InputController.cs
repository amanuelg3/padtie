using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DI = Microsoft.DirectX.DirectInput;

namespace PadTie {
	public class InputController {
		public InputController(InputCore core, DI.Device dev, int index)
		{
			Core = core;
			Device = dev;
			Device.Acquire();
			ID = index;
			Buttons = new ButtonActions[ButtonCount];
			Axes = new AxisActions[AxisCount];

			for (int i = 0, max = Buttons.Length; i < max; ++i) Buttons[i] = new ButtonActions(Core, false);
			for (int i = 0, max = Axes.Length; i < max; ++i) Axes[i] = new AxisActions(Core, false);
		}

		public InputCore Core { get; private set; }
		public int ID { get; private set; }
		public DI.Device Device { get; private set; }
		public int ButtonCount { get { return Device.Caps.NumberButtons; } }
		public int AxisCount { get { return Device.Caps.NumberAxes + Device.Caps.NumberPointOfViews * 2; } }

		public ButtonActions[] Buttons { get; private set; }
		public AxisActions[] Axes { get; private set; }

		public void Check()
		{
			byte[] buttonData = Device.CurrentJoystickState.GetButtons();

			Axes[0].Process(Device.CurrentJoystickState.X);
			Axes[1].Process(Device.CurrentJoystickState.Y);
			Axes[2].Process(Device.CurrentJoystickState.Z);
			Axes[3].Process(Device.CurrentJoystickState.Rz);

			// Map a POV hat to a pair of X/Y axes using trig makes for super simple!!

			int[] hats = Device.CurrentJoystickState.GetPointOfView();
			int axisIndex = 4;
			foreach (int hat in hats) {
				if (axisIndex - 4 >= Device.Caps.NumberPointOfViews)
					break;

				var xAxis = Axes[axisIndex];
				var yAxis = Axes[axisIndex+1];

				if (hat == -1) {
					xAxis.Process(ushort.MaxValue / 2);
					yAxis.Process(ushort.MaxValue / 2);
				} else {
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

			//Axes[3].Process(Device.CurrentJoystickState.Rx);

			int[] uv = Device.CurrentJoystickState.GetSlider();
			//if (Axes.Length > 3) Axes[3].Process(uv[0]);
			//if (Axes.Length > 4) Axes[4].Process(uv[1]);

			for (int x = 0, max = ButtonCount; x < max; ++x) {
				Buttons[x].Process(buttonData[x]);
			}
		}

		public string Name { get { return Device.DeviceInformation.InstanceName; } }
		public string ProductName { get { return Device.DeviceInformation.ProductName; } }
		public string ProductGUID { get { return Device.DeviceInformation.ProductGuid.ToString(); } }
		public string InstanceGUID { get { return Device.DeviceInformation.InstanceGuid.ToString(); } }
		public int ProductID { get { return Device.Properties.VendorIdentityProductId & 0xFFFF; } }
		public int VendorID { get { return (Device.Properties.VendorIdentityProductId >> 16) & 0xFFFF; } }
		public int HatCount { get { return Device.Caps.NumberPointOfViews; } }
	}
}
