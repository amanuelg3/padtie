
using System;
using System.Collections.Generic;

using System.Text;
using System.Runtime.InteropServices;

namespace PadTie {
	public class MouseWheelAction : InputAction {
		public MouseWheelAction(InputCore core, int amount):
			this (core, amount, false)
		{
		}

		public MouseWheelAction(InputCore core, int amount, bool continuous)
		{
			Core = core;
			Amount = amount;
			Continuous = continuous;
		}

		public InputCore Core { get; set; }
		public int Amount { get; set; }

		/// <summary>
		/// Moves the mouse wheel constantly
		/// </summary>
		public bool Continuous { get; set; }
		
		DateTime lastIteration = DateTime.MinValue;

		public override void Active()
		{
			if (Continuous) {
				if (lastIteration + new TimeSpan(0, 0, 0, 0, Core.MouseUpdateInterval) > DateTime.Now)
					return;
				lastIteration = DateTime.Now;

				Move();
			}
		}

		private void Move()
		{
			Console.WriteLine("Mouse wheel " + Amount);
			User32InputHook.INPUT i = new User32InputHook.INPUT();
			i.type = User32InputHook.SendInputEventType.InputMouse;
			i.data.mi.dwFlags = User32InputHook.MouseEventFlags.MOUSEEVENTF_WHEEL;
			i.data.mi.mouseData = Amount;
			User32InputHook.SendInput(i);
		}

		public override void Press()
		{
			if (!Continuous) Move();
		}

		public override void Release()
		{
		}
	}
}