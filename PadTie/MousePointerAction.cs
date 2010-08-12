using System;
using System.Collections.Generic;

using System.Text;

namespace PadTie {
	public class MousePointerAction : InputAction {
		public MousePointerAction(InputCore core, int x, int y)
		{
			Core = core;
			X = x;
			Y = y;
			UseIntensity = true;
			Continuous = true;
		}

		public InputCore Core { get; set; }
		public int X { get; set; }
		public int Y { get; set; }

		public static MousePointerAction Parse(InputCore core, string parseable)
		{
			string[] parts = parseable.Split(',');
			return new MousePointerAction(core, int.Parse(parts[0]), int.Parse(parts[1]));
		}

		public override string ToString()
		{
			string dir = "none";

			if (X == 0) {
				if (Y > 0) {
					dir = "down";
				} else if (Y < 0) {
					dir = "up";
				}
			} else if (Y == 0) {
				if (X > 0) {
					dir = "right";
				}  else if (X < 0) {
					dir = "left";
				}
			} else if (X == Y) {
				if (X > 0 && Y > 0)
					dir = "down/right";
				else if (X > 0 && Y < 0)
					dir = "up/right";
				else if (X < 0 && Y < 0)
					dir = "up/left";
				else if (X < 0 && Y > 0)
					dir = "down/left";
			}

			if (X == 0 && Y == 0)
				dir = "none";
			
			return string.Format("Pointer motion ({0}, [{1}, {2}])", dir, X, Y);
		}

		public override string ToParseable()
		{
			return string.Format("{0},{1}", X, Y);
		}

		public bool Continuous { get; set; }
		public bool UseIntensity { get; set; }
		int mouseIteration = 0;

		public override void Press()
		{
			if (!Continuous)
				Move();
		}

		public override void Active()
		{
			if (Continuous)
				Move();
		}

		private void Move()
		{
			if (Core.Mouse.Iteration == mouseIteration)
				return;
			mouseIteration = Core.Mouse.Iteration;

			double intensity = Intensity;

			if (intensity == 0) intensity = 0.001f;


			if (intensity > 0) {
				Core.Mouse.Move((int)(X * intensity), (int)(Y * intensity));
			} else {
				Core.Mouse.Move(X, Y);
			}
		}

		public static InputAction Parse(string parseable)
		{
			throw new NotImplementedException();
		}
	}
}
