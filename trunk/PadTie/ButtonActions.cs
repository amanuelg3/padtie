using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PadTie {
	public class ButtonActions {
		public ButtonActions(InputCore core, bool enableGestures, object id):
			this (core, enableGestures)
		{
			Identifier = id;
		}

		public ButtonActions(InputCore core, bool enableGestures)
		{
			Core = core;
			EnableGestures = enableGestures;
			Intensity = 1;
		}

		public enum Gesture {
			Link, Tap, DoubleTap, Hold, Raw, None
		}

		public void Map(Gesture g, InputAction action)
		{
			switch (g) {
				case Gesture.Link:
					Link = action;
					break;
				case Gesture.Tap:
					Tap = action;
					break;
				case Gesture.DoubleTap:
					DoubleTap = action;
					break;
				case Gesture.Hold:
					Hold = action;
					break;
				default:
					throw new NotSupportedException("Unknown gesture '" + g + "'");
			}
		}

		public InputAction GetGesture(Gesture g)
		{
			switch (g) {
				case Gesture.Link:
					return Link;
				case Gesture.Tap:
					return Tap;
				case Gesture.DoubleTap:
					return DoubleTap;
				case Gesture.Hold:
					return Hold;
			}

			return null;
		}

		public InputCore Core { get; set; }

		/// <summary>
		/// If false, only the Press/Release actions are handled.
		/// This is used when forwarding input from an InputController
		/// to a VirtualController.
		/// </summary>
		public bool EnableGestures;
		public bool Pressed = false;
		public bool Held = false;
		public DateTime PressedStamp;
		public DateTime TapStamp;
		public bool TapQueued = false;
		public object Tag;
		public object Identifier;
		public event EventHandler PressReceived;
		public event EventHandler ReleaseReceived;

		public void Process(int raw)
		{
			if (TapQueued) Console.WriteLine("Tap queued at start...");

			bool wasPressed = Pressed;
			bool isPressed = (raw != 0);

			if (Raw != null && Raw.AcceptAnalog)
				Raw.Analog(raw);

			if (wasPressed != isPressed) {
				if (isPressed) {
					// Pressed
					if (PressReceived != null) PressReceived(this, EventArgs.Empty);
					if (Link != null) Link.Press(Intensity);
				} else {
					// Released
					Held = false;

					if (ReleaseReceived != null) ReleaseReceived(this, EventArgs.Empty);
					if (Link != null) Link.Release(Intensity);

					if (EnableGestures && PressedStamp + new TimeSpan(0, 0, 0, 0, Core.TapTimeout) > DateTime.Now) {
						// Tap

						if (DoubleTap != null) {
							if (TapQueued && TapStamp + new TimeSpan(0, 0, 0, 0, Core.DoubleTapTimeout) > DateTime.Now) {
								// Second tap
								Console.WriteLine("Double Tap!");
								DoubleTap.Activate(Intensity);
								TapStamp = DateTime.Now;
								TapQueued = false;
							} else if (!TapQueued) {
								// First tap
								TapStamp = DateTime.Now;
								TapQueued = true;
								Console.WriteLine("Tap! [queued]");
							}
						} else {
							Console.WriteLine("Tap!");
							if (Tap != null) Tap.Activate(Intensity);
						}
					}
				}

				Pressed = isPressed;
				PressedStamp = DateTime.Now;
			}

			if (TapQueued) Console.WriteLine("Tap queued in middle...");
			
			if (EnableGestures && TapQueued && TapStamp + new TimeSpan(0, 0, 0, 0, Core.DoubleTapTimeout) < DateTime.Now) {
				Console.WriteLine("Real Tap!");
				if (Tap != null) Tap.Activate(Intensity);
				TapQueued = false;
			}

			if (isPressed) {
				if (Link != null) Link.Active(Intensity);

				if (EnableGestures && !Held && PressedStamp + new TimeSpan(0, 0, 0, 0, Core.HoldTimeout) <= DateTime.Now) {
					Console.WriteLine("Hold!");
					if (Hold != null) Hold.Activate(Intensity);
					Held = true;
				}

			}
			
			if (TapQueued) Console.WriteLine("Tap queued at end...");
			
		}

		/// <summary>
		/// An action linked here will receive no Press/Release events. Instead, if AcceptAnalog is 
		/// set on the handler, the Analog() method will be called.
		/// </summary>
		public InputAction Raw { get; set; }

		/// <summary>
		/// An action linked here will receive press/release events from the button
		/// </summary>
		public InputAction Link { get; set; }

		/// <summary>
		/// An action linked here will be activated when the button is pressed and quickly
		/// released.
		/// </summary>
		public InputAction Tap { get; set; }

		/// <summary>
		///  An action linked here will be activated when the button is held down briefly
		/// </summary>
		public InputAction Hold { get; set; }

		/// <summary>
		/// An action linked here will be activated when the button is tapped twice in quick succession
		/// </summary>
		public InputAction DoubleTap { get; set; }

		public double Intensity { get; set; }
	}
}
