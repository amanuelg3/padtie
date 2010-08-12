using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PadTie {
	public class MouseController {
		public MouseController(InputCore core)
		{
			this.core = core;
		}

		InputCore core;
		int motionX, motionY;
		int wheel;
		DateTime lastIteration = DateTime.MinValue;
		int iteration = 0;

		public int Iteration { get { return iteration; } }

		public void Move(int x, int y)
		{
			motionX += x;
			motionY += y;
		}

		public void Wheel(int w)
		{
			wheel += w;
		}

		public void RunIteration()
		{
			if (lastIteration + new TimeSpan(0, 0, 0, 0, core.MouseUpdateInterval) > DateTime.Now)
				return;

			lastIteration = DateTime.Now;

			if (motionX != 0 || motionY != 0) {
				User32InputHook.INPUT i = new User32InputHook.INPUT();
				i.type = User32InputHook.SendInputEventType.InputMouse;
				i.data.mi.dx = motionX;
				i.data.mi.dy = motionY;
				i.data.mi.dwFlags = User32InputHook.MouseEventFlags.MOUSEEVENTF_MOVE;

				User32InputHook.SendInput(i);
				motionX = motionY = 0;
			}

			if (wheel != 0) {
				User32InputHook.INPUT i = new User32InputHook.INPUT();
				i.type = User32InputHook.SendInputEventType.InputMouse;

				i.data.mi.dwFlags = User32InputHook.MouseEventFlags.MOUSEEVENTF_WHEEL;
				i.data.mi.mouseData = wheel;

				User32InputHook.SendInput(i);

				wheel = 0;
			}

			++iteration;
		}
	}
}
