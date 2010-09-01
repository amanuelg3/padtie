using System;
using System.Collections.Generic;

using System.Text;

namespace PadTie {
	/// <summary>
	/// An input action which forwards all data to another input action
	/// </summary>
	public class ForwardAction : InputAction {
		public ForwardAction(InputAction a)
		{
			Action = a;
		}

		public override bool AcceptAnalog
		{
			get { return Action.AcceptAnalog; }
			set { Action.AcceptAnalog = value; }
		}

		public override string ToParseable()
		{
			return "";
		}

		public InputAction Action { get; private set; }

		public override void Analog(double value)
		{
			Action.Analog(value);
		}

		public override void Press()
		{
			Action.Press();
		}

		public override void Release()
		{
			Action.Release();
		}

		public override void Active()
		{
			Action.Active();
		}
	}
}
