using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PadTie;

namespace PadTieApp {
	public partial class ChooseSlotDialog : Form, IFontifiable {
		public ChooseSlotDialog(PadTieForm main, bool includeGestures)
		{
			InitializeComponent();
			mainForm = main;
			IncludeGestures = includeGestures;
		}

		public bool Fontified { get; set; }
		public bool IncludeGestures { get; set; }
		public bool ShowAllPads { get; set; }
		public int FocusedPad { get; set; }

		public TreeNode SelectedNode { get { return options.SelectedNode; } }

		PadTieForm mainForm;

		public class ButtonNodeTag { public Controller cc; public VirtualController.Button button; }
		public class StickNodeTag { public Controller cc; public VirtualController.Axis stick; }
		public class SlotNodeTag { public Controller cc; public CapturedInput slot; }
		public class GestureTag { public Controller cc; public CapturedInput slot; public ButtonActions.Gesture g; }

		void AddStickNodes(TreeNode root, Controller cc)
		{
			var n = root.Nodes.Add ("Left Analog");
			n.Tag = new StickNodeTag { cc = cc, stick = VirtualController.Axis.LeftX };
			AddStickDirections(n, cc, VirtualController.Axis.LeftX);

			n = root.Nodes.Add ("Right Analog");
			n.Tag = new StickNodeTag { cc = cc, stick = VirtualController.Axis.RightX };
			AddStickDirections(n, cc, VirtualController.Axis.RightX);

			n = root.Nodes.Add ("Digital");
			n.Tag = new StickNodeTag { cc = cc, stick = VirtualController.Axis.DigitalX };
			AddStickDirections(n, cc, VirtualController.Axis.DigitalX);
		}

		void AddDirectionNode(TreeNode root, Controller cc, VirtualController.Axis axis, bool pos, string name)
		{
			var cap = new CapturedInput(axis, false);
			var n = root.Nodes.Add(name);
			n.Tag = new SlotNodeTag { cc = cc, slot = cap };
			if (IncludeGestures) AddGestureNodes(n, cc, cap);

		}
		void AddStickDirections(TreeNode root, Controller cc, VirtualController.Axis stick)
		{
			string prefix = stick.ToString();
			prefix = prefix.Substring (0, prefix.Length - 1);
			var y = Util.ParseEnum<VirtualController.Axis>(prefix + "Y");
			var x = stick;

			AddDirectionNode(root, cc, x, false, "Left");
			AddDirectionNode(root, cc, x, true, "Right");
			AddDirectionNode(root, cc, y, false, "Up");
			AddDirectionNode(root, cc, y, true, "Down");
		}

		void AddGestureNodes(TreeNode root, Controller cc, CapturedInput slot)
		{
			var n = root.Nodes.Add("Link");
			n.Tag = new GestureTag { cc = cc, slot = slot, g = ButtonActions.Gesture.Link };

			n = root.Nodes.Add("Tap");
			n.Tag = new GestureTag { cc = cc, slot = slot, g = ButtonActions.Gesture.Tap };

			n = root.Nodes.Add("Double Tap");
			n.Tag = new GestureTag { cc = cc, slot = slot, g = ButtonActions.Gesture.DoubleTap };

			n = root.Nodes.Add("Hold");
			n.Tag = new GestureTag { cc = cc, slot = slot, g = ButtonActions.Gesture.Hold };
		}

		void AddPad(Controller cc)
		{
			var padNode = options.Nodes.Add("Pad #" + cc.Index);
			padNode.Tag = cc;
			foreach (var btn in VirtualController.ButtonList) {
				var btnNode = padNode.Nodes.Add(Util.GetButtonDisplayName(btn));
				var btnSlot = new CapturedInput(btn);
				btnNode.Tag = new SlotNodeTag { cc = cc, slot = btnSlot };
				if (IncludeGestures) AddGestureNodes(btnNode, cc, btnSlot);
			}

			AddStickNodes(padNode, cc);
		}

		private void ChooseSlotDialog_Load(object sender, EventArgs e)
		{
			if (ShowAllPads) {
				var ccs = mainForm.Controllers.Clone() as Controller[];
				Array.Sort(ccs, delegate(Controller a, Controller b)
				{
					return a.Index - b.Index;
				});

				foreach (var cc in ccs)
					AddPad(cc);
			} else {
				AddPad(mainForm.GetController (FocusedPad));
			}

			options.ExpandAll();
			options.SelectedNode = options.Nodes[0];

			Fontify.Go(this);
		}

		private void options_DoubleClick(object sender, EventArgs e)
		{
			this.AcceptButton.PerformClick();
		}

		private void options_AfterSelect(object sender, TreeViewEventArgs e)
		{
			okBtn.Enabled = (options.SelectedNode != null && options.SelectedNode.Tag is SlotNodeTag);
		}
	}
}
