using System;
using System.Collections.Generic;

using System.Text;
using System.Threading;

namespace PadTie {
	public abstract class InputAction {
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
		public abstract string ToParseable();

		public virtual void Analog(double value)
		{
		}

		public void Press(double intensity)
		{
			Intensity = intensity;
			Press();
		}

		public void Release(double intensity)
		{
			Intensity = intensity;
			Release();
		}

		public void Active(double intensity)
		{
			Intensity = intensity;
			Active();
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

		public void Activate(double intensity)
		{
			Intensity = intensity;
			Activate();
		}

		public virtual void Activate()
		{
			Press();
			Thread.Sleep(110);
			Release();
		}

		/// <summary>
		/// Describes the slot this action was last bound to. This can be supplied by the host application
		/// to simplify things... 
		/// </summary>
		public CapturedInput SlotDescription { get; set; }
	}
}
