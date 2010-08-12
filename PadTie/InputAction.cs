using System;
using System.Collections.Generic;

using System.Text;

namespace PadTie {
	public class InputAction {
		public InputAction()
		{
		}

		public virtual bool AcceptAnalog { get; set; }

		/// <summary>
		/// Intensity provided in the input data. If negative, intensity is not 
		/// available. Otherwise ranges from zero (softest touch) to one (full).
		/// </summary>
		public double Intensity = -1;
		public object Tag { get; set; }
		public virtual string ToParseable() { return ""; }

		public virtual void Analog(double value)
		{
		}

		/// <summary>
		/// Run per iteration while pressed
		/// </summary>
		public virtual void Active()
		{
		}

		public virtual void Press()
		{
		}

		public virtual void Release()
		{
		}

		internal void Activate()
		{
			Press();
			Release();
		}

		/// <summary>
		/// Describes the slot this action was last bound to. This can be supplied by the host application
		/// to simplify things... 
		/// </summary>
		public CapturedInput SlotDescription { get; set; }
	}
}
