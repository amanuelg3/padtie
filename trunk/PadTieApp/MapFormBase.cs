using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PadTieApp;
using PadTie;

namespace PadTieApp {
	public static class MapUtil {
		public static void Map(PadTieForm form, VirtualController vc, CapturedInput slot, InputAction action)
		{
			if (slot.IsAxisGesture) {
				form.MapAxisGesture(vc,
					slot.Axis,
					slot.IsPositive ? AxisActions.Gestures.Positive : AxisActions.Gestures.Negative,
					action);
			} else {
				var gesture = slot.ButtonGesture;
				form.MapButton(vc, slot.Button, gesture, action);
			}
		}
	}
}
