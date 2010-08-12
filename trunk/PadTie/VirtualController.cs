using System;
using System.Collections.Generic;

using System.Text;

namespace PadTie {
	public class CapturedInput {
		public CapturedInput(VirtualController.Button button)
		{
			Button = button;
		}

		public CapturedInput(VirtualController.Button button, ButtonActions.Gesture gesture)
		{
			Button = button;
			ButtonGesture = gesture;
		}

		public CapturedInput(VirtualController.Axis axis, bool isPos)
		{
			IsAxisGesture = true;
			Axis = axis;
			IsPositive = isPos;
		}

		public static bool operator ==(CapturedInput a, CapturedInput b)
		{
			if ((object)a == (object)b)
				return true;
			
			if ((object)a == null || (object)b == null)
				return false;

			if (a.IsAxisGesture != b.IsAxisGesture)
				return false;

			if (a.IsAxisGesture) {
				if (a.Axis != b.Axis || a.IsPositive != b.IsPositive)
					return false;
				return true;
			} else {
				if (a.Button != b.Button || a.ButtonGesture != b.ButtonGesture)
					return false;
				return true;
			}
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;

			if (!(obj is CapturedInput))
				return false;

			return this == (obj as CapturedInput);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public static bool operator !=(CapturedInput a, CapturedInput b)
		{
			return !(a == b);
		}

		public CapturedInput Clone()
		{
			var ci = new CapturedInput(Button);
			ci.IsAxisGesture = IsAxisGesture;
			ci.Axis = Axis;
			ci.IsPositive = IsPositive;
			ci.ButtonGesture = this.ButtonGesture;
			return ci;
		}

		public bool IsAxisGesture = false;
		public VirtualController.Button Button;
		public VirtualController.Axis Axis;
		public bool IsPositive = false;
		public ButtonActions.Gesture ButtonGesture = ButtonActions.Gesture.Link;
	}

	public class VirtualController {
		public VirtualController(InputCore core)
		{
			Core = core;
			Reset();
		}

		public InputCore Core { get; set; }

		public void Reset()
		{
			A = new ButtonActions(Core, true, VirtualController.Button.A);
			B = new ButtonActions(Core, true, VirtualController.Button.B);
			X = new ButtonActions(Core, true, VirtualController.Button.X);
			Y = new ButtonActions(Core, true, VirtualController.Button.Y);
			Br = new ButtonActions(Core, true, VirtualController.Button.Br);
			Bl = new ButtonActions(Core, true, VirtualController.Button.Bl);
			Tl = new ButtonActions(Core, true, VirtualController.Button.Tl);
			Tr = new ButtonActions(Core, true, VirtualController.Button.Tr);
			Back = new ButtonActions(Core, true, VirtualController.Button.Back);
			Start = new ButtonActions(Core, true, VirtualController.Button.Start);
			System = new ButtonActions(Core, true, VirtualController.Button.System);
			LeftAnalogButton = new ButtonActions(Core, true, VirtualController.Button.LeftAnalog);
			RightAnalogButton = new ButtonActions(Core, true, VirtualController.Button.RightAnalog);

			bool needsCapture = (LeftXAxis == null);

			LeftXAxis = new AxisActions(Core, true, LeftXAxis, VirtualController.Axis.LeftX);
			LeftYAxis = new AxisActions(Core, true, LeftYAxis, VirtualController.Axis.LeftY);
			RightXAxis = new AxisActions(Core, true, RightXAxis, VirtualController.Axis.RightX);
			RightYAxis = new AxisActions(Core, true, RightYAxis, VirtualController.Axis.RightY);
			DigitalXAxis = new AxisActions(Core, true, DigitalXAxis, VirtualController.Axis.DigitalX);
			DigitalYAxis = new AxisActions(Core, true, DigitalYAxis, VirtualController.Axis.DigitalY);

			if (needsCapture) {
				LeftXAxis.PositiveRelease += delegate(object sender, EventArgs e)
				{
					if (capture != null) {
						capture(new CapturedInput(Axis.LeftX, true));
						capture = null;
					}
				};
				LeftXAxis.NegativeRelease += delegate(object sender, EventArgs e)
				{
					if (capture != null) {
						capture(new CapturedInput(Axis.LeftX, false));
						capture = null;
					}
				};
				LeftYAxis.PositiveRelease += delegate(object sender, EventArgs e)
				{
					if (capture != null) {
						capture(new CapturedInput(Axis.LeftY, true));
						capture = null;
					}
				};
				LeftYAxis.NegativeRelease += delegate(object sender, EventArgs e)
				{
					if (capture != null) {
						capture(new CapturedInput(Axis.LeftY, false));
						capture = null;
					}
				};
				RightXAxis.PositiveRelease += delegate(object sender, EventArgs e)
				{
					if (capture != null) {
						capture(new CapturedInput(Axis.RightX, true));
						capture = null;
					}
				};
				RightXAxis.NegativeRelease += delegate(object sender, EventArgs e)
				{
					if (capture != null) {
						capture(new CapturedInput(Axis.RightX, false));
						capture = null;
					}
				};
				RightYAxis.PositiveRelease += delegate(object sender, EventArgs e)
				{
					if (capture != null) {
						capture(new CapturedInput(Axis.RightY, true));
						capture = null;
					}
				};
				RightYAxis.NegativeRelease += delegate(object sender, EventArgs e)
				{
					if (capture != null) {
						capture(new CapturedInput(Axis.RightY, false));
						capture = null;
					}
				};

				DigitalXAxis.PositiveRelease += delegate(object sender, EventArgs e)
				{
					if (capture != null) {
						capture(new CapturedInput(Axis.DigitalX, true));
						capture = null;
					}
				};
				DigitalXAxis.NegativeRelease += delegate(object sender, EventArgs e)
				{
					if (capture != null) {
						capture(new CapturedInput(Axis.DigitalX, false));
						capture = null;
					}
				};
				DigitalYAxis.PositiveRelease += delegate(object sender, EventArgs e)
				{
					if (capture != null) {
						capture(new CapturedInput(Axis.DigitalY, true));
						capture = null;
					}
				};
				DigitalYAxis.NegativeRelease += delegate(object sender, EventArgs e)
				{
					if (capture != null) {
						capture(new CapturedInput(Axis.DigitalY, false));
						capture = null;
					}
				};
			}
		}

		public bool Enabled = true;

		public ButtonActions A;
		public ButtonActions B;
		public ButtonActions X;
		public ButtonActions Y;
		public ButtonActions Br;
		public ButtonActions Bl;
		public ButtonActions Tl;
		public ButtonActions Tr;
		public ButtonActions Back;
		public ButtonActions Start;
		public ButtonActions System;
		public ButtonActions LeftAnalogButton;
		public ButtonActions RightAnalogButton;

		public AxisActions LeftXAxis;
		public AxisActions RightXAxis;
		public AxisActions LeftYAxis;
		public AxisActions RightYAxis;
		public AxisActions DigitalXAxis;
		public AxisActions DigitalYAxis;

		public ButtonActions GetButton(Button button)
		{
			switch (button) {
				case VirtualController.Button.A: return this.A;
				case VirtualController.Button.B: return this.B;
				case VirtualController.Button.X: return this.X;
				case VirtualController.Button.Y: return this.Y;
				case VirtualController.Button.Bl: return this.Bl;
				case VirtualController.Button.Br: return this.Br;
				case VirtualController.Button.Tl: return this.Tl;
				case VirtualController.Button.Tr: return this.Tr;
				case VirtualController.Button.Start: return this.Start;
				case VirtualController.Button.Back: return this.Back;
				case VirtualController.Button.LeftAnalog: return this.LeftAnalogButton;
				case VirtualController.Button.RightAnalog: return this.RightAnalogButton;
			}

			return null;
		}

		public AxisActions GetAxis(Axis axis)
		{
			switch (axis) {
				case VirtualController.Axis.LeftX: return LeftXAxis;
				case VirtualController.Axis.LeftY: return LeftYAxis;
				case VirtualController.Axis.RightX: return RightXAxis;
				case VirtualController.Axis.RightY: return RightYAxis;
				case VirtualController.Axis.DigitalX: return DigitalXAxis;
				case VirtualController.Axis.DigitalY: return DigitalYAxis;
			}

			return null;
		}

		#region Monitoring

		public event ButtonEventHandler ButtonPressReceived;
		public event ButtonEventHandler ButtonReleaseReceived;
		public event ButtonEventHandler ButtonActiveReceived;
		public event AxisEventHandler AxisAnalogReceived;

		public void AxisAnalog(Axis axis, double value)
		{
			if (AxisAnalogReceived != null)
				AxisAnalogReceived(this, new AxisEventArgs(axis, value));
		}

		public void ButtonActive(Button button)
		{
			if (ButtonActiveReceived != null)
				ButtonActiveReceived(this, new ButtonEventArgs(button, true));
		}

		public void ButtonPressed(Button button)
		{
			if (ButtonPressReceived != null)
				ButtonPressReceived(this, new ButtonEventArgs(button, true));
		}

		public void ButtonReleased(Button button)
		{
			if (ButtonReleaseReceived != null)
				ButtonReleaseReceived(this, new ButtonEventArgs(button, false));
		}

		#endregion

		public delegate void AxisEventHandler(object sender, AxisEventArgs e);

		public class AxisEventArgs : EventArgs {
			public AxisEventArgs(Axis axis, double value)
			{
				Axis = axis;
				Value = value;
			}

			public Axis Axis { get; set; }
			public double Value { get; set; }
		}

		public delegate void ButtonEventHandler(object sender, ButtonEventArgs e);

		CaptureCallback capture = null;

		public delegate void CaptureCallback(CapturedInput input);

		public void CaptureNext(CaptureCallback c)
		{
			capture = c;
		}

		public class ButtonEventArgs : EventArgs {
			public ButtonEventArgs(Button button, bool pressed)
			{
				Button = button;
				Pressed = pressed;
			}

			public Button Button { get; set; }
			public bool Pressed { get; set; }
		}

		public enum Button {
			A, B, X, Y, Br, Bl, Tl, Tr, Back, Start, System, LeftAnalog, RightAnalog
		}

		public enum Axis {
			LeftX, LeftY, RightX, RightY,
			DigitalX, DigitalY
		}

		public class ButtonAction : InputAction {
			public ButtonAction(VirtualController vc, Button b)
			{
				Controller = vc;
				Button = b;
			}

			public VirtualController Controller { get; private set; }
			public Button Button { get; private set; }

			public override void Active()
			{
				Controller.ButtonActive(Button);

				if (!Controller.Enabled) return;

				switch (Button) {
					case Button.A:
						Controller.A.Process(1);
						break;
					case Button.B:
						Controller.B.Process(1);
						break;
					case Button.X:
						Controller.X.Process(1);
						break;
					case Button.Y:
						Controller.Y.Process(1);
						break;
					case Button.Br:
						Controller.Br.Process(1);
						break;
					case Button.Bl:
						Controller.Bl.Process(1);
						break;
					case Button.Tr:
						Controller.Tr.Process(1);
						break;
					case Button.Tl:
						Controller.Tl.Process(1);
						break;
					case Button.Back:
						Controller.Back.Process(1);
						break;
					case Button.Start:
						Controller.Start.Process(1);
						break;
					case Button.System:
						Controller.System.Process(1);
						break;
					case Button.LeftAnalog:
						Controller.LeftAnalogButton.Process(1);
						break;
					case Button.RightAnalog:
						Controller.RightAnalogButton.Process(1);
						break;
					default:
						Console.WriteLine("VC.ButtonAction (active) Unknown virtual button " + Button);
						break;
				}
			}

			public override void Press()
			{
				if (Controller.capture != null) {
					Controller.capture(new CapturedInput(Button));
					Controller.capture = null;
				}

				Controller.ButtonPressed(Button);

				if (!Controller.Enabled) return;

				switch (Button) {
					case Button.A:
						Controller.A.Process(1);
						break;
					case Button.B:
						Controller.B.Process(1);
						break;
					case Button.X:
						Controller.X.Process(1);
						break;
					case Button.Y:
						Controller.Y.Process(1);
						break;
					case Button.Br:
						Controller.Br.Process(1);
						break;
					case Button.Bl:
						Controller.Bl.Process(1);
						break;
					case Button.Tr:
						Controller.Tr.Process(1);
						break;
					case Button.Tl:
						Controller.Tl.Process(1);
						break;
					case Button.Back:
						Controller.Back.Process(1);
						break;
					case Button.Start:
						Controller.Start.Process(1);
						break;
					case Button.System:
						Controller.System.Process(1);
						break;
					case Button.LeftAnalog:
						Controller.LeftAnalogButton.Process(1);
						break;
					case Button.RightAnalog:
						Controller.RightAnalogButton.Process(1);
						break;
					default:
						Console.WriteLine("VC.ButtonAction (release) Unknown virtual button " + Button);
						break;
				}
			}

			public override void Release()
			{
				Controller.ButtonReleased(Button);

				if (!Controller.Enabled) return;

				switch (Button) {
					case Button.A:
						Controller.A.Process(0);
						break;
					case Button.B:
						Controller.B.Process(0);
						break;
					case Button.X:
						Controller.X.Process(0);
						break;
					case Button.Y:
						Controller.Y.Process(0);
						break;
					case Button.Br:
						Controller.Br.Process(0);
						break;
					case Button.Bl:
						Controller.Bl.Process(0);
						break;
					case Button.Tr:
						Controller.Tr.Process(0);
						break;
					case Button.Tl:
						Controller.Tl.Process(0);
						break;
					case Button.Back:
						Controller.Back.Process(0);
						break;
					case Button.Start:
						Controller.Start.Process(0);
						break;
					case Button.System:
						Controller.System.Process(0);
						break;
					case Button.LeftAnalog:
						Controller.LeftAnalogButton.Process(0);
						break;
					case Button.RightAnalog:
						Controller.RightAnalogButton.Process(0);
						break;
					default:
						Console.WriteLine("VC.ButtonAction (release) Unknown virtual button " + Button);
						break;
				}
			}
		}


		public class AxisAction : InputAction {
			public AxisAction(VirtualController vc, Axis a)
			{
				Controller = vc;
				Axis = a;
				AcceptAnalog = true;
			}

			public VirtualController Controller { get; private set; }
			public Axis Axis { get; private set; }

			public override void Analog(double value)
			{
				Controller.AxisAnalog(Axis, value);

				uint raw = (uint)(((value + 1) / 2.0) * ushort.MaxValue);

				if (!Controller.Enabled) return;

				if (Axis == Axis.LeftX) Controller.LeftXAxis.Process((int)raw);
				else if (Axis == Axis.LeftY) Controller.LeftYAxis.Process((int)raw);
				else if (Axis == Axis.RightX) Controller.RightXAxis.Process((int)raw);
				else if (Axis == Axis.RightY) Controller.RightYAxis.Process((int)raw);
				else if (Axis == Axis.DigitalX) Controller.DigitalXAxis.Process((int)raw);
				else if (Axis == Axis.DigitalY) Controller.DigitalYAxis.Process((int)raw);
			}
		}
	}
}
