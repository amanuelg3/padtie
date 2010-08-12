using System;
using System.Collections.Generic;

using System.Text;
using System.Runtime.InteropServices;

namespace PadTie {
	public static class User32InputHook {
		/// <summary>
		/// SendsInput using Win32 API Function
		/// </summary>
		/// <param name="nInputs">The number input structures in the array.</param>
		/// <param name="pInputs">The pointer to array of input structures.</param>
		/// <param name="cbSize">Size of the structure in the array.</param>
		/// <returns>The function returns the number of events that it successfully 
		/// inserted into the keyboard or mouse input stream. If the function returns zero, 
		/// the input was already blocked by another thread. To get extended error information, 
		/// call GetLastError.</returns>
		[DllImport("user32.dll", SetLastError = true)]
		public static extern uint SendInput(uint nInputs, ref INPUT pInputs, int cbSize);

		public static uint SendInput(INPUT i)
		{
			return User32InputHook.SendInput(1, ref i, Marshal.SizeOf(i));
		}

		/// <summary>
		/// The flags that a MouseInput.dwFlags can contain
		/// </summary>
		[Flags]
		public enum MouseEventFlags : uint {
			/// <summary>
			/// Movement occured
			/// </summary>
			MOUSEEVENTF_MOVE = 0x0001,
			/// <summary>
			/// button down (pair with an up to create a full click)
			/// </summary>
			MOUSEEVENTF_LEFTDOWN = 0x0002,
			/// <summary>
			/// button up (pair with a down to create a full click)
			/// </summary>
			MOUSEEVENTF_LEFTUP = 0x0004,
			/// <summary>
			/// button down (pair with an up to create a full click)
			/// </summary>
			MOUSEEVENTF_RIGHTDOWN = 0x0008,
			/// <summary>
			/// button up (pair with a down to create a full click)
			/// </summary>
			MOUSEEVENTF_RIGHTUP = 0x0010,
			/// <summary>
			/// button down (pair with an up to create a full click)
			/// </summary>
			MOUSEEVENTF_MIDDLEDOWN = 0x0020,
			/// <summary>
			/// button up (pair with a down to create a full click)
			/// </summary>
			MOUSEEVENTF_MIDDLEUP = 0x0040,
			/// <summary>
			/// button down (pair with an up to create a full click)
			/// </summary>
			MOUSEEVENTF_XDOWN = 0x0080,
			/// <summary>
			/// button up (pair with a down to create a full click)
			/// </summary>
			MOUSEEVENTF_XUP = 0x0100,
			/// <summary>
			/// Wheel was moved, the value of mouseData is the number of movement values
			/// </summary>
			MOUSEEVENTF_WHEEL = 0x0800,
			/// <summary>
			/// Map X,Y to entire desktop, must be used with MOUSEEVENT_ABSOLUTE
			/// </summary>
			MOUSEEVENTF_VIRTUALDESK = 0x4000,
			/// <summary>
			/// The X and Y members contain normalised Absolute Co-Ords. If not set X and Y are relative
			/// data to the last position (i.e. change in position from last event)
			/// </summary>
			MOUSEEVENTF_ABSOLUTE = 0x8000
		}

		/// <summary>
		/// The mouse data structure
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct MouseInputData {
			/// <summary>
			/// The x value, if ABSOLUTE is passed in the flag then this is an actual X and Y value
			/// otherwise it is a delta from the last position
			/// </summary>
			public int dx;
			/// <summary>
			/// The y value, if ABSOLUTE is passed in the flag then this is an actual X and Y value
			/// otherwise it is a delta from the last position
			/// </summary>
			public int dy;
			/// <summary>
			/// Wheel event data, X buttons
			/// </summary>
			public int mouseData;
			/// <summary>
			/// ORable field with the various flags about buttons and nature of event
			/// </summary>
			public MouseEventFlags dwFlags;
			/// <summary>
			/// The timestamp for the event, if zero then the system will provide
			/// </summary>
			public uint time;
			/// <summary>
			/// Additional data obtained by calling app via GetMessageExtraInfo
			/// </summary>
			public IntPtr dwExtraInfo;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct KEYBDINPUT {
			public ushort wVk;
			public ushort wScan;
			public uint dwFlags;
			public uint time;
			public IntPtr dwExtraInfo;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct HARDWAREINPUT {
			public int uMsg;
			public short wParamL;
			public short wParamH;
		}

		/// <summary>
		/// Captures the union of the three three structures.
		/// </summary>
		[StructLayout(LayoutKind.Explicit)]
		public struct MouseKeybdhardwareInputUnion {
			/// <summary>
			/// The Mouse Input Data
			/// </summary>
			[FieldOffset(0)]
			public MouseInputData mi;

			/// <summary>
			/// The Keyboard input data
			/// </summary>
			[FieldOffset(0)]
			public KEYBDINPUT ki;

			/// <summary>
			/// The hardware input data
			/// </summary>
			[FieldOffset(0)]
			public HARDWAREINPUT hi;
		}

		/// <summary>
		/// The Data passed to SendInput in an array.
		/// </summary>
		/// <remarks>Contains a union field type specifies what it contains </remarks>
		[StructLayout(LayoutKind.Sequential)]
		public struct INPUT {
			/// <summary>
			/// The actual data type contained in the union Field
			/// </summary>
			public SendInputEventType type;
			public MouseKeybdhardwareInputUnion data;
		}

		[DllImport("user32.dll")]
		public static extern IntPtr GetMessageExtraInfo();

		/// <summary>
		/// The event type contained in the union field
		/// </summary>
		public enum SendInputEventType : int {
			/// <summary>
			/// Contains Mouse event data
			/// </summary>
			InputMouse,
			/// <summary>
			/// Contains Keyboard event data
			/// </summary>
			InputKeyboard,
			/// <summary>
			/// Contains Hardware event data
			/// </summary>
			InputHardware
		}

		public const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
		public const uint KEYEVENTF_KEYUP = 0x0002;
		public const uint KEYEVENTF_UNICODE = 0x0004;
		public const uint KEYEVENTF_SCANCODE = 0x0008;

		/// <summary>
		/// Used in mouseData if XDOWN or XUP specified
		/// </summary>
		[Flags]
		public enum MouseDataFlags : uint {
			/// <summary>
			/// First button was pressed or released
			/// </summary>
			XBUTTON1 = 0x0001,
			/// <summary>
			/// Second button was pressed or released
			/// </summary>
			XBUTTON2 = 0x0002
		}

		public enum VK : ushort {
			//
			// Virtual Keys, Standard Set
			//
			VK_LBUTTON = 0x01,
			VK_RBUTTON = 0x02,
			VK_CANCEL = 0x03,
			VK_MBUTTON = 0x04,    // NOT contiguous with L & RBUTTON

			VK_XBUTTON1 = 0x05,    // NOT contiguous with L & RBUTTON
			VK_XBUTTON2 = 0x06,    // NOT contiguous with L & RBUTTON

			// 0x07 : unassigned

			VK_BACK = 0x08,
			VK_TAB = 0x09,

			// 0x0A - 0x0B : reserved

			VK_CLEAR = 0x0C,
			VK_RETURN = 0x0D,

			VK_SHIFT = 0x10,
			VK_CONTROL = 0x11,
			VK_MENU = 0x12,
			VK_PAUSE = 0x13,
			VK_CAPITAL = 0x14,

			VK_KANA = 0x15,
			VK_HANGEUL = 0x15,  // old name - should be here for compatibility
			VK_HANGUL = 0x15,
			VK_JUNJA = 0x17,
			VK_FINAL = 0x18,
			VK_HANJA = 0x19,
			VK_KANJI = 0x19,

			VK_ESCAPE = 0x1B,

			VK_CONVERT = 0x1C,
			VK_NONCONVERT = 0x1D,
			VK_ACCEPT = 0x1E,
			VK_MODECHANGE = 0x1F,

			VK_SPACE = 0x20,
			VK_PRIOR = 0x21,
			VK_NEXT = 0x22,
			VK_END = 0x23,
			VK_HOME = 0x24,
			VK_LEFT = 0x25,
			VK_UP = 0x26,
			VK_RIGHT = 0x27,
			VK_DOWN = 0x28,
			VK_SELECT = 0x29,
			VK_PRINT = 0x2A,
			VK_EXECUTE = 0x2B,
			VK_SNAPSHOT = 0x2C,
			VK_INSERT = 0x2D,
			VK_DELETE = 0x2E,
			VK_HELP = 0x2F,

			//
			// VK_0 - VK_9 are the same as ASCII '0' - '9' (0x30 - 0x39)
			// 0x40 : unassigned
			// VK_A - VK_Z are the same as ASCII 'A' - 'Z' (0x41 - 0x5A)
			//

			VK_LWIN = 0x5B,
			VK_RWIN = 0x5C,
			VK_APPS = 0x5D,

			//
			// 0x5E : reserved
			//

			VK_SLEEP = 0x5F,

			VK_NUMPAD0 = 0x60,
			VK_NUMPAD1 = 0x61,
			VK_NUMPAD2 = 0x62,
			VK_NUMPAD3 = 0x63,
			VK_NUMPAD4 = 0x64,
			VK_NUMPAD5 = 0x65,
			VK_NUMPAD6 = 0x66,
			VK_NUMPAD7 = 0x67,
			VK_NUMPAD8 = 0x68,
			VK_NUMPAD9 = 0x69,
			VK_MULTIPLY = 0x6A,
			VK_ADD = 0x6B,
			VK_SEPARATOR = 0x6C,
			VK_SUBTRACT = 0x6D,
			VK_DECIMAL = 0x6E,
			VK_DIVIDE = 0x6F,
			VK_F1 = 0x70,
			VK_F2 = 0x71,
			VK_F3 = 0x72,
			VK_F4 = 0x73,
			VK_F5 = 0x74,
			VK_F6 = 0x75,
			VK_F7 = 0x76,
			VK_F8 = 0x77,
			VK_F9 = 0x78,
			VK_F10 = 0x79,
			VK_F11 = 0x7A,
			VK_F12 = 0x7B,
			VK_F13 = 0x7C,
			VK_F14 = 0x7D,
			VK_F15 = 0x7E,
			VK_F16 = 0x7F,
			VK_F17 = 0x80,
			VK_F18 = 0x81,
			VK_F19 = 0x82,
			VK_F20 = 0x83,
			VK_F21 = 0x84,
			VK_F22 = 0x85,
			VK_F23 = 0x86,
			VK_F24 = 0x87,

			//
			// 0x88 - 0x8F : unassigned
			//

			VK_NUMLOCK = 0x90,
			VK_SCROLL = 0x91,

			//
			// VK_L* & VK_R* - left and right Alt, Ctrl and Shift virtual keys.
			// Used only as parameters to GetAsyncKeyState() and GetKeyState().
			// No other API or message will distinguish left and right keys in this way.
			//
			VK_LSHIFT = 0xA0,
			VK_RSHIFT = 0xA1,
			VK_LCONTROL = 0xA2,
			VK_RCONTROL = 0xA3,
			VK_LMENU = 0xA4,
			VK_RMENU = 0xA5,

			VK_BROWSER_BACK = 0xA6,
			VK_BROWSER_FORWARD = 0xA7,
			VK_BROWSER_REFRESH = 0xA8,
			VK_BROWSER_STOP = 0xA9,
			VK_BROWSER_SEARCH = 0xAA,
			VK_BROWSER_FAVORITES = 0xAB,
			VK_BROWSER_HOME = 0xAC,

			VK_VOLUME_MUTE = 0xAD,
			VK_VOLUME_DOWN = 0xAE,
			VK_VOLUME_UP = 0xAF,
			VK_MEDIA_NEXT_TRACK = 0xB0,
			VK_MEDIA_PREV_TRACK = 0xB1,
			VK_MEDIA_STOP = 0xB2,
			VK_MEDIA_PLAY_PAUSE = 0xB3,
			VK_LAUNCH_MAIL = 0xB4,
			VK_LAUNCH_MEDIA_SELECT = 0xB5,
			VK_LAUNCH_APP1 = 0xB6,
			VK_LAUNCH_APP2 = 0xB7,

			//
			// 0xB8 - 0xB9 : reserved
			//

			VK_OEM_1 = 0xBA,   // ';:' for US
			VK_OEM_PLUS = 0xBB,   // '+' any country
			VK_OEM_COMMA = 0xBC,   // ',' any country
			VK_OEM_MINUS = 0xBD,   // '-' any country
			VK_OEM_PERIOD = 0xBE,   // '.' any country
			VK_OEM_2 = 0xBF,   // '/?' for US
			VK_OEM_3 = 0xC0,   // '`~' for US

			//
			// 0xC1 - 0xD7 : reserved
			//

			//
			// 0xD8 - 0xDA : unassigned
			//

			VK_OEM_4 = 0xDB,  //  '[{' for US
			VK_OEM_5 = 0xDC,  //  '\|' for US
			VK_OEM_6 = 0xDD,  //  ']}' for US
			VK_OEM_7 = 0xDE,  //  ''"' for US
			VK_OEM_8 = 0xDF

			//
			// 0xE0 : reserved
			//
		}
	}
}
