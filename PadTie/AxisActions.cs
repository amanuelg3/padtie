using System;
using System.Collections.Generic;

using System.Text;

namespace PadTie {
	public enum AxisPole {
		None,
		Positive, Negative
	}

	public class AxisActions {
		public AxisActions(InputCore core, bool enableGestures) :
			this(core, enableGestures, null)
		{
		}

		public AxisActions(InputCore core, bool enableGestures, object id) :
			this(core, enableGestures)
		{
			Identifier = id;
		}

		public AxisActions(InputCore core, bool enableGestures, bool enableDeadzone, object id) :
			this(core, enableGestures)
		{
			EnableDeadzone = enableDeadzone;
			Identifier = id;
		}

		public AxisActions(InputCore core, bool enableGestures, AxisActions importMonitors)
		{
			Core = core;
			EnableGestures = enableGestures;
			Deadzone = -1;
			PoleSize = -1;
			if (importMonitors != null) {
				NegativePress += importMonitors.NegativePress;
				NegativeRelease += importMonitors.NegativeRelease;
				PositivePress += importMonitors.PositivePress;
				PositiveRelease += importMonitors.PositiveRelease;
				Identifier = importMonitors.Identifier;
			}
		}

		public AxisActions(InputCore core, bool enableGestures, AxisActions importMonitors, object id):
			this (core, enableGestures, importMonitors)
		{
			Identifier = id;
		}

		public bool EnableDeadzone = false;
		public InputCore Core { get; private set; }
		public InputController Controller { get; private set; }
		public double Deadzone { get; set; }
		public double PoleSize { get; set; }
		public AxisPole LastPole = AxisPole.None;
		public bool EnableGestures = true;
		public object Tag;
		public object Identifier;
		
		public event EventHandler PositivePress;
		public event EventHandler PositiveRelease;
		public event EventHandler NegativePress;
		public event EventHandler NegativeRelease;

		public enum Gestures : byte {
			Negative = 0,
			Up = 0,
			Left = 0,
			Positive = 1,
			Right = 1,
			Down = 1,

			Analog = 2,
		}

		public void Map(Gestures gesture, InputAction action)
		{
			if (gesture == Gestures.Positive)
				Positive = action;
			else if (gesture == Gestures.Negative)
				Negative = action;
			else if (gesture == Gestures.Analog)
				Analog = action;
		}

		public InputAction GetGesture(Gestures gesture)
		{
			if (gesture == Gestures.Positive)
				return Positive;
			else if (gesture == Gestures.Negative)
				return Negative;
			else if (gesture == Gestures.Analog)
				return Analog;

			return null;
		}

		/// <summary>
		/// Assign an action directly to the analog stick. The Press()/Release() methods
		/// will not be called. If the action's AcceptAnalog property is false, no input
		/// is sent to the action. Otherwise the Analog() method is called repeatedly with
		/// the new analog data.
		/// </summary>
		public InputAction Analog;
		public InputAction Negative;
		public InputAction Positive;

		public void Process(int raw)
		{
			double value = raw / (double)UInt16.MaxValue * 2 - 1;

			if (EnableDeadzone) {
				double deadzone = Deadzone;

				if (deadzone < 0)
					deadzone = Core.GlobalDeadzone;

				if (value >= -deadzone && value <= deadzone) {
					value = 0;
				}
			}

			AxisPole pole = AxisPole.None;
			double intensity = -1;
			double poleSize = PoleSize;

			if (poleSize < 0)
				poleSize = Core.AxisPoleSize;

			if (value >= 1.0 - poleSize) {
				pole = AxisPole.Positive;
				intensity = (value - 1.0 + poleSize) / poleSize;
			} else if (value <= -1.0 + poleSize) {
				pole = AxisPole.Negative;
				intensity = (Math.Abs(value) - 1.0 + poleSize) / poleSize;
			}

			if (Analog != null && Analog.AcceptAnalog) {
				Analog.Analog(value);
			}

			if (pole != LastPole) {
				if (LastPole != AxisPole.None) {
					if (LastPole == AxisPole.Positive) {
						if (Positive != null) Positive.Release();
						if (PositiveRelease != null) {
							PositiveRelease(this, EventArgs.Empty);
						}
					} else if (LastPole == AxisPole.Negative) {
						if (Negative != null) Negative.Release();
						if (NegativeRelease != null)
							NegativeRelease(this, EventArgs.Empty);
					}
				}

				if (pole == AxisPole.Positive) {
					if (Positive != null) Positive.Press();
					if (PositivePress != null) {
						PositivePress(this, EventArgs.Empty);
					}
				} else if (pole == AxisPole.Negative) {
					if (Negative != null) Negative.Press();
					if (NegativePress != null)
						NegativePress(this, EventArgs.Empty);
				}

				LastPole = pole;
			} else if (pole == AxisPole.Positive && Positive != null) {
				Positive.Intensity = intensity;
				Positive.Active();
			} else if (pole == AxisPole.Negative && Negative != null) {
				Negative.Intensity = intensity;
				Negative.Active();
			}
		}
	}
}
