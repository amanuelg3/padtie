using System;
using System.Collections.Generic;

using System.Text;

namespace PadTie {
	public enum AxisPole {
		None,
		Positive, Negative
	}

	public class AxisActions {
		public AxisActions(InputCore core, bool enableGestures)
		{
			if (core == null)
				throw new ArgumentNullException("core");

			Core = core;
			EnableGestures = enableGestures;
			Positive = new ButtonActions(core, enableGestures);
			Negative = new ButtonActions(core, enableGestures);
		}

		public AxisActions(InputCore core, bool enableGestures, object id) :
			this(core, enableGestures)
		{
			Identifier = id;
		}

		public AxisActions(InputCore core, bool enableGestures, bool enableDeadzone, object id) :
			this(core, enableGestures, id)
		{
			EnableDeadzone = enableDeadzone;
		}

		public AxisActions(InputCore core, bool enableGestures, AxisActions importMonitors):
			this (core, enableGestures)
		{
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

		public ButtonActions GetPole(AxisPole pole)
		{
			return GetPole(pole == AxisPole.Positive ? Gestures.Positive : Gestures.Negative);
		}

		public ButtonActions GetPole(Gestures gesture)
		{
			if (gesture == Gestures.Positive)
				return Positive;
			else if (gesture == Gestures.Negative)
				return Negative;
			else if (gesture == Gestures.Analog)
				throw new InvalidOperationException();

			return null;
		}

		/// <summary>
		/// Assign an action directly to the analog stick. The Press()/Release() methods
		/// will not be called. If the action's AcceptAnalog property is false, no input
		/// is sent to the action. Otherwise the Analog() method is called repeatedly with
		/// the new analog data.
		/// </summary>
		public InputAction Analog;
		public ButtonActions Negative;
		public ButtonActions Positive;

		public void Process(int raw)
		{
			if (Core == null)
				return;

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
			double poleSize = -1;

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

			int posValue = 0, negValue = 0;

			if (pole != LastPole) {
				if (LastPole != AxisPole.None) {
					if (LastPole == AxisPole.Positive) {
						posValue = 0;
						if (PositiveRelease != null)
							PositiveRelease(this, EventArgs.Empty);
					} else if (LastPole == AxisPole.Negative) {
						negValue = 0;
						if (NegativeRelease != null)
							NegativeRelease(this, EventArgs.Empty);
					}
				}

				if (pole == AxisPole.Positive) {
					posValue = 1;
					if (PositivePress != null)
						PositivePress(this, EventArgs.Empty);
				} else if (pole == AxisPole.Negative) {
					negValue = 1;
					if (NegativePress != null)
						NegativePress(this, EventArgs.Empty);
				}

				LastPole = pole;
			} else if (pole == AxisPole.Positive) {
				Positive.Intensity = intensity;
				posValue = 1;
			} else if (pole == AxisPole.Negative) {
				Negative.Intensity = intensity;
				negValue = 1;
			}

			if (Positive != null) Positive.Process(posValue);
			if (Negative != null) Negative.Process(negValue);
		}
	}
}
