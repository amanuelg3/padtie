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
		}

		public enum Gesture {
			Link, Tap, DoubleTap, Hold
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

		public void Process(byte raw)
		{
			bool wasPressed = Pressed;
			bool isPressed = (raw != 0);


			if (wasPressed != isPressed) {
				if (isPressed) {
					// Pressed
					if (PressReceived != null) PressReceived(this, EventArgs.Empty);
					if (Link != null) Link.Press();
				} else {
					// Released
					Held = false;

					if (ReleaseReceived != null) ReleaseReceived(this, EventArgs.Empty);
					if (Link != null) Link.Release();

					if (EnableGestures && PressedStamp + new TimeSpan(0, 0, 0, 0, Core.TapTimeout) > DateTime.Now) {

						if (DoubleTap != null) {
							if (TapQueued && TapStamp + new TimeSpan(0, 0, 0, 0, Core.DoubleTapTimeout) > DateTime.Now) {
								// Second tap
								Console.WriteLine("Double Tap!");
								DoubleTap.Activate();
								TapStamp = DateTime.Now;
								TapQueued = false;
							} else {
								// First tap
								Console.WriteLine("Tap!");
								TapStamp = DateTime.Now;
								TapQueued = true;
							}
						} else {
							Console.WriteLine("Tap!");
							if (Tap != null) Tap.Activate();
						}
					}
				}

				Pressed = isPressed;
				PressedStamp = DateTime.Now;
			}

			if (EnableGestures && TapQueued && TapStamp + new TimeSpan(0, 0, 0, 0, Core.DoubleTapTimeout) < DateTime.Now) {
				Console.WriteLine("Tap!");
				if (Tap != null) Tap.Activate();
				TapQueued = false;
			}

			if (isPressed) {
				if (Link != null) Link.Active();

				if (EnableGestures && !Held && PressedStamp + new TimeSpan(0, 0, 0, 0, Core.HoldTimeout) <= DateTime.Now) {
					Console.WriteLine("Hold!");
					if (Hold != null) Hold.Activate();
					Held = true;
				}
			}
		}

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
	}
}
