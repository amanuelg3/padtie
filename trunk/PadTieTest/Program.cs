using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PadTie;
using System.Threading;
using System.Windows.Forms;

namespace PadTieTest {
	class Program {
		[STAThread]
		static void Main(string[] args)
		{
			Console.WriteLine("Initializing PadTie...");
			var core = new InputCore(IntPtr.Zero);

			if (core.Controllers.Count == 0) {
				Console.WriteLine("No gamepads detected.");
			} else {
				var vc = new VirtualController(core);
				var pad = core.Controllers[0];

				pad.Axes[0].Analog = new VirtualController.AxisAction(vc, VirtualController.Axis.LeftX);
				pad.Axes[1].Analog = new VirtualController.AxisAction(vc, VirtualController.Axis.LeftX);
				pad.Axes[2].Analog = new VirtualController.AxisAction(vc, VirtualController.Axis.RightX);
				pad.Axes[3].Analog = new VirtualController.AxisAction(vc, VirtualController.Axis.RightY);

				// Face buttons
				pad.Buttons[0].Raw = new VirtualController.ButtonAction(vc, VirtualController.Button.X);
				pad.Buttons[1].Raw = new VirtualController.ButtonAction(vc, VirtualController.Button.A);
				pad.Buttons[2].Raw = new VirtualController.ButtonAction(vc, VirtualController.Button.B);
				pad.Buttons[3].Raw = new VirtualController.ButtonAction(vc, VirtualController.Button.Y);

				// Shoulder buttons 
				pad.Buttons[4].Raw = new VirtualController.ButtonAction(vc, VirtualController.Button.Bl);
				pad.Buttons[5].Raw = new VirtualController.ButtonAction(vc, VirtualController.Button.Br);
				pad.Buttons[6].Raw = new VirtualController.ButtonAction(vc, VirtualController.Button.Tl);
				pad.Buttons[7].Raw = new VirtualController.ButtonAction(vc, VirtualController.Button.Tr);
				pad.Buttons[8].Raw = new VirtualController.ButtonAction(vc, VirtualController.Button.Back);
				pad.Buttons[9].Raw = new VirtualController.ButtonAction(vc, VirtualController.Button.Start);
				pad.Buttons[10].Raw = new VirtualController.ButtonAction(vc, VirtualController.Button.LeftAnalog);
				pad.Buttons[11].Raw = new VirtualController.ButtonAction(vc, VirtualController.Button.RightAnalog);

				/// *************** Real mapping (to virtual controller) **************** ///
				
				vc.LeftXAxis.Positive.Link = new KeyAction(User32InputHook.VK.VK_RIGHT);
                vc.LeftXAxis.Negative.Link = new KeyAction(User32InputHook.VK.VK_LEFT);
                vc.LeftYAxis.Positive.Link = new KeyAction(User32InputHook.VK.VK_DOWN);
                vc.LeftYAxis.Negative.Link = new KeyAction(User32InputHook.VK.VK_UP);

                vc.LeftXAxis.Positive.Link = new KeyAction('d');
                vc.LeftXAxis.Negative.Link = new KeyAction('a');
                vc.LeftYAxis.Positive.Link = new KeyAction('s');
                vc.LeftYAxis.Negative.Link = new KeyAction('w');

				vc.RightXAxis.Positive.Link  = new MousePointerAction(core,  20,  0 );
                vc.RightXAxis.Negative.Link = new MousePointerAction(core, -20, 0);
                vc.RightYAxis.Positive.Link = new MousePointerAction(core, 0, 20);
                vc.RightYAxis.Negative.Link = new MousePointerAction(core, 0, -20);

				vc.Br.Link = new MouseButtonAction(core, MouseButtonAction.Buttons.Left);
				vc.Tr.Link = new MouseButtonAction(core, MouseButtonAction.Buttons.Right);
				vc.X.Link = new KeyAction(User32InputHook.VK.VK_SPACE);
				vc.A.Link = new KeyAction('e');
				vc.Bl.Link = new MouseWheelAction(core, 26, true);
				vc.Tl.Link = new MouseWheelAction(core, -26, true);
				vc.Start.Link = new KeyAction(User32InputHook.VK.VK_RETURN);
				vc.Back.Link = new KeyAction(User32InputHook.VK.VK_ESCAPE);
				vc.Back.Hold = new KeyAction(User32InputHook.VK.VK_TAB, User32InputHook.VK.VK_MENU);

				Console.WriteLine("Press keys...");
				while (true) {
					core.RunIteration();
					Thread.Sleep(0);
				}
			}
			Console.WriteLine("Press enter to exit.");
			Console.ReadLine();
		}
	}
}
