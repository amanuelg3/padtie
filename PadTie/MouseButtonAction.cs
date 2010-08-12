using System;
using System.Collections.Generic;

using System.Text;
using System.Runtime.InteropServices;

namespace PadTie {
	public class MouseButtonAction : InputAction {
		public MouseButtonAction(InputCore core, Buttons button)
		{
			Core = core;
			Button = button;
		}

		public enum Buttons {
			Left = 0, Middle = 1, Right = 2, Back = 3, Forward = 4
		}

		public InputCore Core { get; set; }
		public Buttons Button { get; set; }

		public override void Press()
		{
			User32InputHook.INPUT i = new User32InputHook.INPUT();
			i.type = User32InputHook.SendInputEventType.InputMouse;

			if (Button == Buttons.Left)
				i.data.mi.dwFlags = User32InputHook.MouseEventFlags.MOUSEEVENTF_LEFTDOWN;
			else if (Button == Buttons.Right)
				i.data.mi.dwFlags = User32InputHook.MouseEventFlags.MOUSEEVENTF_RIGHTDOWN;
			else if (Button == Buttons.Middle)
				i.data.mi.dwFlags = User32InputHook.MouseEventFlags.MOUSEEVENTF_MIDDLEDOWN;

			User32InputHook.SendInput(i);
		}

		public override void Release()
		{
			User32InputHook.INPUT i = new User32InputHook.INPUT();
			i.type = User32InputHook.SendInputEventType.InputMouse;

			if (Button == Buttons.Left)
				i.data.mi.dwFlags = User32InputHook.MouseEventFlags.MOUSEEVENTF_LEFTUP;
			else if (Button == Buttons.Right)
				i.data.mi.dwFlags = User32InputHook.MouseEventFlags.MOUSEEVENTF_RIGHTUP;
			else if (Button == Buttons.Middle)
				i.data.mi.dwFlags = User32InputHook.MouseEventFlags.MOUSEEVENTF_MIDDLEUP;
			

			User32InputHook.SendInput(i);
		}

		public static MouseButtonAction Parse(InputCore core, string parseable)
		{
			Buttons b = (Buttons)Enum.Parse(typeof (Buttons), parseable);
			return new MouseButtonAction(core, b);
		}

		public override string ToParseable()
		{
			return string.Format("{0}", Button);
		}

		public override string ToString()
		{
			if (Button == Buttons.Left || Button == Buttons.Middle || Button == Buttons.Right)
				return Button.ToString() + " mouse button";
			else if (Button == Buttons.Back)
				return "Extra mouse button 1 (Back)";
			else if (Button == Buttons.Forward)
				return "Extra mouse button 2 (Forward)";

			return "Unknown mouse button (" + Button.ToString() + ")";
		}
	}
}
