using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Forms;

namespace PadTie {
	public static class WindowsKeyUtil {
		public static string ToDisplayString(this Keys key)
		{
			string name = key.ToString();

			if (key == Keys.ControlKey)
				name = "Control";
			else if (key == Keys.ShiftKey)
				name = "Shift";
			else if (key == Keys.PageUp)
				name = "Page Up";
			else if (key == Keys.PageDown)
				name = "Page Down";
			else if (key == Keys.Back)
				name = "Backspace";
			else if (key == Keys.OemBackslash)
				name = "Backslash";
			else if (key == Keys.Oemcomma)
				name = "Comma";
			else if (key == Keys.OemMinus)
				name = "Minus";
			else if (key == Keys.OemOpenBrackets)
				name = "Open Bracket";
			else if (key == Keys.OemPeriod)
				name = "Period";
			else if (key == Keys.OemPipe)
				name = "Pipe";
			else if (key == Keys.OemSemicolon)
				name = "Semicolon";
			else if (key == Keys.Oemtilde)
				name = "Backtick";
			else if (key == Keys.OemQuotes)
				name = "Quote";
			else if (key == Keys.Menu)
				name = "Alt";
			else if (key == Keys.RMenu)
				name = "Right Alt";
			else if (key == Keys.OemCloseBrackets)
				name = "Close Bracket";
			else if (name.Length == 2 && name[0] == 'D')
				name = name[1].ToString();

			return name;
		}

		public static User32InputHook.VK ToVK(this char ch)
		{
			if (char.IsLetter(ch) || char.IsNumber(ch))
				return (User32InputHook.VK)System.Text.Encoding.ASCII.GetBytes(new[] { char.ToUpper(ch) })[0];
			else
				throw new NotImplementedException();
		}

		public static Keys ToSWF(this char ch)
		{
			if (char.IsLetter(ch))
				return (Keys)Enum.Parse(typeof(Keys), char.ToUpper(ch).ToString());
			else if (char.IsDigit(ch))
				return (Keys)Enum.Parse(typeof(Keys), "D" + ch.ToString());
			else
				throw new NotImplementedException();
		}

		public static Keys ToSWF(this User32InputHook.VK key)
		{
			return (Keys)key;
		}

		public static User32InputHook.VK ToVK(this Keys key)
		{
			if (key == Keys.Control)
				return User32InputHook.VK.VK_CONTROL;

			return (User32InputHook.VK)key;
		}

		public static Keys[] ToSWF(this User32InputHook.VK[] a)
		{
			Keys[] ka = new Keys[a.Length];
			for (int x = 0, max = a.Length; x < max; ++x)
				ka[x] = a[x].ToSWF();

			return ka;
		}

		public static User32InputHook.VK[] ToVK(this Keys[] a)
		{
			User32InputHook.VK[] ka = new User32InputHook.VK[a.Length];
			for (int x = 0, max = a.Length; x < max; ++x)
				ka[x] = a[x].ToVK();

			return ka;
		}
	}

	public class KeyAction : InputAction {
		public KeyAction(User32InputHook.VK key, params User32InputHook.VK[] mods)
		{
			VKey = key;
			Key = key.ToSWF();
			Modifiers = mods.ToSWF();
			VModifiers = mods;
		}

		public KeyAction(char ch)
		{
			Key = ch.ToSWF();
			VKey = Key.ToVK();
			Modifiers = new Keys[0];
			VModifiers = new User32InputHook.VK[0];
		}

		public override string ToString()
		{
			return string.Format("Keystroke ({0})", ToDisplayString());
		}

		public KeyAction(char ch, params User32InputHook.VK[] mods)
		{
			Key = ch.ToSWF();
			VKey = Key.ToVK();
			Modifiers = mods.ToSWF();
			VModifiers = mods;
		}

		public KeyAction(char ch, params Keys[] mods)
		{
			Key = ch.ToSWF();
			VKey = Key.ToVK();
			Modifiers = mods;
			VModifiers = mods.ToVK();
		}

		public KeyAction(Keys key, params Keys[] mods)
		{
			ChangeBinding(key, mods);
		}

		public void ChangeBinding(Keys key, Keys[] mods)
		{
			Key = key;
			VKey = key.ToVK();
			Modifiers = mods;
			VModifiers = mods.ToVK();
		}

		public Keys Key { get; private set; }
		public User32InputHook.VK VKey { get; private set; }
		public Keys[] Modifiers { get; private set; }
		public User32InputHook.VK[] VModifiers { get; private set; }

		public string ToDisplayString()
		{
			StringBuilder sb = new StringBuilder();

			foreach (var k in Modifiers) {
				if (k == Keys.Control || k == Keys.ControlKey)
					sb.Append("Ctrl + ");
				else if (k == Keys.Shift || k == Keys.ShiftKey)
					sb.Append("Shift + ");
				else if (k == Keys.Alt || k == Keys.Menu)
					sb.Append("Alt + ");
			}

			sb.Append(Key.ToDisplayString());
			return sb.ToString();
		}

		public override void Press()
		{
			User32InputHook.INPUT i = new User32InputHook.INPUT();
			i.type = User32InputHook.SendInputEventType.InputKeyboard;
			i.data.ki.wScan = 0;
			i.data.ki.time = 0;
			i.data.ki.dwFlags = 0;
			i.data.ki.dwExtraInfo = IntPtr.Zero;

			// Press modifiers
			foreach (User32InputHook.VK mod in VModifiers) {
				i.data.ki.wVk = (ushort)mod;
				User32InputHook.SendInput(i);
			}

			i.data.ki.wVk = (ushort)VKey;
			if ((i.data.ki.wVk >= 33 && i.data.ki.wVk <= 46) || (i.data.ki.wVk >= 91 && i.data.ki.wVk <= 93))
				i.data.ki.dwFlags += User32InputHook.KEYEVENTF_EXTENDEDKEY;
			User32InputHook.SendInput(i);
		}

		public override void Release()
		{
			User32InputHook.INPUT i = new User32InputHook.INPUT();
			i.type = User32InputHook.SendInputEventType.InputKeyboard;
			i.data.ki.wScan = 0;
			i.data.ki.time = 0;
			i.data.ki.dwFlags = 2;
			i.data.ki.dwExtraInfo = IntPtr.Zero;
			i.data.ki.wVk = (ushort)VKey;
			if ((i.data.ki.wVk >= 33 && i.data.ki.wVk <= 46) || (i.data.ki.wVk >= 91 && i.data.ki.wVk <= 93))
				i.data.ki.dwFlags |= User32InputHook.KEYEVENTF_EXTENDEDKEY;
			User32InputHook.SendInput(i);

			i.data.ki.dwFlags = 2;
			// Release modifiers
			foreach (User32InputHook.VK mod in VModifiers) {
				i.data.ki.wVk = (ushort)mod;
				User32InputHook.SendInput(i);
			}
		}

		public static KeyAction Parse(InputCore core, string parseable)
		{
			string[] parts = parseable.Split(',');
			string[] modChunks = parts[1].Split('|');
			List<Keys> mods = new List<Keys> ();
			
			if (parts[1] != "") foreach (string modChunk in modChunks)
				mods.Add((Keys)Enum.Parse(typeof(Keys), modChunk));

			return new KeyAction((Keys)Enum.Parse(typeof(Keys), parts[0]), mods.ToArray());
		}

		public override string ToParseable()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(Key.ToString() + ",");
			List<string> mods = new List<string>();

			foreach (Keys mod in Modifiers)
				mods.Add(mod.ToString());

			sb.Append(string.Join("|", mods));

			return sb.ToString();
		}
	}
}
