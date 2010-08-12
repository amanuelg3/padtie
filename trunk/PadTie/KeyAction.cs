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

			switch (key) {
				case User32InputHook.VK.VK_LEFT: return Keys.Left;
				case User32InputHook.VK.VK_RIGHT: return Keys.Right;
				case User32InputHook.VK.VK_UP: return Keys.Up;
				case User32InputHook.VK.VK_DOWN: return Keys.Down;
				case User32InputHook.VK.VK_TAB: return Keys.Tab;
				case User32InputHook.VK.VK_ESCAPE: return Keys.Escape;
				case User32InputHook.VK.VK_SHIFT: return Keys.Shift;
				case User32InputHook.VK.VK_CONTROL: return Keys.Control;
				case User32InputHook.VK.VK_INSERT: return Keys.Insert;
				case User32InputHook.VK.VK_DELETE: return Keys.Delete;
				case User32InputHook.VK.VK_HOME: return Keys.Home;
				case User32InputHook.VK.VK_END: return Keys.End;
				case User32InputHook.VK.VK_PRIOR: return Keys.PageUp;
				case User32InputHook.VK.VK_NEXT: return Keys.PageDown;
				case User32InputHook.VK.VK_BACK: return Keys.Back;
				case User32InputHook.VK.VK_MENU: return Keys.Alt;
				case User32InputHook.VK.VK_RETURN: return Keys.Return;
				case User32InputHook.VK.VK_CAPITAL: return Keys.Capital;
				case User32InputHook.VK.VK_F1: return Keys.F1;
				case User32InputHook.VK.VK_F2: return Keys.F2;
				case User32InputHook.VK.VK_F3: return Keys.F3;
				case User32InputHook.VK.VK_F4: return Keys.F4;
				case User32InputHook.VK.VK_F5: return Keys.F5;
				case User32InputHook.VK.VK_F6: return Keys.F6;
				case User32InputHook.VK.VK_F7: return Keys.F7;
				case User32InputHook.VK.VK_F8: return Keys.F8;
				case User32InputHook.VK.VK_F9: return Keys.F9;
				case User32InputHook.VK.VK_F10: return Keys.F10;
				case User32InputHook.VK.VK_F11: return Keys.F11;
				case User32InputHook.VK.VK_F12: return Keys.F12;
				case User32InputHook.VK.VK_PRINT: return Keys.PrintScreen;
				case User32InputHook.VK.VK_SCROLL: return Keys.Scroll;
				case User32InputHook.VK.VK_PAUSE: return Keys.Pause;
				case (User32InputHook.VK)0xE2: 
				case User32InputHook.VK.VK_OEM_5:
					return Keys.OemBackslash; // VK_OEM_102 can be backslash or angle brackets....
				case User32InputHook.VK.VK_RSHIFT: return Keys.RShiftKey;
				case User32InputHook.VK.VK_RMENU: return Keys.RMenu;
				case User32InputHook.VK.VK_SPACE: return Keys.Space;
				case User32InputHook.VK.VK_OEM_1: return Keys.OemSemicolon;
				case User32InputHook.VK.VK_OEM_PLUS: return Keys.Oemplus;
				case User32InputHook.VK.VK_OEM_COMMA: return Keys.Oemcomma;
				case User32InputHook.VK.VK_OEM_MINUS: return Keys.OemMinus;
				case User32InputHook.VK.VK_OEM_PERIOD: return Keys.OemPeriod;
				case User32InputHook.VK.VK_OEM_2: return Keys.OemPeriod;
				case User32InputHook.VK.VK_OEM_4: return Keys.OemOpenBrackets;
				case User32InputHook.VK.VK_OEM_6: return Keys.OemCloseBrackets;
				case User32InputHook.VK.VK_OEM_7: return Keys.OemQuotes;
				case User32InputHook.VK.VK_BROWSER_STOP: return Keys.BrowserStop;
				case User32InputHook.VK.VK_BROWSER_REFRESH: return Keys.BrowserRefresh;
				case User32InputHook.VK.VK_BROWSER_SEARCH: return Keys.BrowserSearch;
				case User32InputHook.VK.VK_BROWSER_HOME: return Keys.BrowserHome;
				case User32InputHook.VK.VK_VOLUME_DOWN: return Keys.VolumeDown;
				case User32InputHook.VK.VK_VOLUME_UP: return Keys.VolumeUp;
				case User32InputHook.VK.VK_VOLUME_MUTE: return Keys.VolumeMute;
				default:
					if ((int)key >= (byte)'A' && (int)key <= (byte)'Z')
						return (Keys)((int)Keys.A + ((int)key - (byte)'A'));
					else if ((int)key == (byte)'~')
						return Keys.Oemtilde;
					else if ((int)key == (byte)'0')
						return Keys.D0;
					else if ((int)key >= (byte)'1' && (int)key <= (byte)'9')
						return (Keys)((int)Keys.D1 + ((int)key - (byte)'1'));
					break;
			}

			return Keys.None;
		}

		public static User32InputHook.VK ToVK(this Keys key)
		{
			return (User32InputHook.VK)key;

			switch (key) {
				case Keys.Left: return User32InputHook.VK.VK_LEFT;
				case Keys.Right: return User32InputHook.VK.VK_RIGHT;
				case Keys.Up: return User32InputHook.VK.VK_UP;
				case Keys.Space: return User32InputHook.VK.VK_SPACE;
				case Keys.OemPeriod: return User32InputHook.VK.VK_OEM_PERIOD;
				case Keys.Oemplus: return User32InputHook.VK.VK_OEM_PLUS;
				case Keys.Oemcomma: return User32InputHook.VK.VK_OEM_COMMA;
				case Keys.OemQuestion: 
					return User32InputHook.VK.VK_OEM_2;
				case Keys.OemPipe: return User32InputHook.VK.VK_OEM_5;
				case Keys.OemOpenBrackets: return User32InputHook.VK.VK_OEM_4;
				case Keys.OemCloseBrackets: return User32InputHook.VK.VK_OEM_6;
				case Keys.OemQuotes: return User32InputHook.VK.VK_OEM_7;
				case Keys.Oemtilde: return User32InputHook.VK.VK_OEM_3;
				case Keys.OemSemicolon: return User32InputHook.VK.VK_OEM_1;

				case Keys.Down: return User32InputHook.VK.VK_DOWN;
				case Keys.Tab: return User32InputHook.VK.VK_TAB;
				case Keys.Escape: return User32InputHook.VK.VK_ESCAPE;
				case Keys.Shift: return User32InputHook.VK.VK_SHIFT;
				case Keys.ShiftKey: return User32InputHook.VK.VK_SHIFT;
				case Keys.Menu: return User32InputHook.VK.VK_MENU;
				case Keys.RMenu: return User32InputHook.VK.VK_RMENU;
				case Keys.Control: return User32InputHook.VK.VK_CONTROL;
				case Keys.ControlKey: return User32InputHook.VK.VK_CONTROL;
				case Keys.Insert: return User32InputHook.VK.VK_INSERT;
				case Keys.Delete: return User32InputHook.VK.VK_DELETE;
				case Keys.Home: return User32InputHook.VK.VK_HOME;
				case Keys.End: return User32InputHook.VK.VK_END;
				case Keys.PageUp: return User32InputHook.VK.VK_PRIOR;
				case Keys.PageDown: return User32InputHook.VK.VK_NEXT;
				case Keys.Back: return User32InputHook.VK.VK_BACK;
				case Keys.Alt: return User32InputHook.VK.VK_MENU;
				case Keys.Return: return User32InputHook.VK.VK_RETURN;
				case Keys.F1: return User32InputHook.VK.VK_F1;
				case Keys.F2: return User32InputHook.VK.VK_F2;
				case Keys.F3: return User32InputHook.VK.VK_F3;
				case Keys.F4: return User32InputHook.VK.VK_F4;
				case Keys.F5: return User32InputHook.VK.VK_F5;
				case Keys.F6: return User32InputHook.VK.VK_F6;
				case Keys.F7: return User32InputHook.VK.VK_F7;
				case Keys.F8: return User32InputHook.VK.VK_F8;
				case Keys.F9: return User32InputHook.VK.VK_F9;
				case Keys.F10: return User32InputHook.VK.VK_F10;
				case Keys.F11: return User32InputHook.VK.VK_F11;
				case Keys.F12: return User32InputHook.VK.VK_F12;
				default:
					if (key >= Keys.A && key <= Keys.Z) {
						return (User32InputHook.VK)(Encoding.ASCII.GetBytes("A")[0] + ((int)key - (int)Keys.A));
					} else if (key == Keys.D0) {
						return (User32InputHook.VK)Encoding.ASCII.GetBytes("0")[0];
					} else if (key == Keys.Oemtilde) {
						return (User32InputHook.VK)((byte)'~');
					} else if (key >= Keys.D1 && key <= Keys.D9) {
						return (User32InputHook.VK)(Encoding.ASCII.GetBytes("1")[0] + ((int)key - (int)Keys.D1));
					} else {
						MessageBox.Show("Unsupported key " + key);
						return 0;
					}
			}
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

		public static KeyAction Parse(string parseable)
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
