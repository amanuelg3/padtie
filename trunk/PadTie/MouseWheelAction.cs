using System;
using System.Collections.Generic;

using System.Text;
using System.Runtime.InteropServices;

namespace PadTie {
	public class MouseWheelAction : InputAction {
		public MouseWheelAction(InputCore core, short value)
		{
			Core = core;
			Value = value;
		}

		public InputCore Core { get; set; }
		public short Value { get; set; }
		public bool Continuous { get; set; }
		public bool UseIntensity { get; set; }

		public override void Active()
		{
			if (Continuous) {
				Move();
			}
		}

		int mouseIteration;

		private void Move()
		{
			if (mouseIteration == Core.Mouse.Iteration)
				return;
			mouseIteration = Core.Mouse.Iteration;

			if (UseIntensity)
				Core.Mouse.Wheel((int)(Value * Intensity));
			else
				Core.Mouse.Wheel(Value);

		}

		public override void Press()
		{
			if (!Continuous)
				Move();
		}

		public static MouseWheelAction Parse(InputCore core, string parseable)
		{
			return new MouseWheelAction(core, short.Parse(parseable));
		}

		public override string ToParseable()
		{
			return string.Format("{0}", Value);
		}

		public override string ToString()
		{
			if (Value < 0)
				return "Mouse wheel down (" + Math.Abs(Value) + ")";
			else
				return "Mouse wheel up (" + Value + ")";
		}
	}
}
