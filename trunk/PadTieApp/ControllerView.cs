using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PadTie;
using System.Drawing.Drawing2D;

namespace PadTieApp {
	public partial class ControllerView : UserControl {
		public ControllerView()
		{
			InitializeComponent();
		}

		List<SlotOverlay> slotOverlays = new List<SlotOverlay>();

		public bool AutoSelectInput
		{
			get { return autoSelectInput.Checked; }
		}

		public void SetOverlay(VirtualController.Button b, bool visible)
		{
			var o = FindOverlay(b);
			if (o != null)
				o.Visible = visible;
			else
				Console.WriteLine("Error: could not find overlay for button " + b);
		
			Render();
		}

		public void SetOverlay(VirtualController.Axis a, bool isPos, bool visible)
		{
			var o = FindOverlay(a, isPos);
			if (o != null)
				o.Visible = visible;
			else
				Console.WriteLine("Error: could not find overlay for axis gesture " + a + "/" + (isPos ? "Pos" : "Neg"));

			Render();
		}

		public SlotOverlay FindOverlay(VirtualController.Button b)
		{
			foreach (var o in slotOverlays) {
				if (o.IsAxisGesture) continue;
				if (o.Button == b) return o;
			}

			return null;
		}

		public SlotOverlay FindOverlay(VirtualController.Axis a, bool isPos)
		{
			foreach (var o in slotOverlays) {
				if (!o.IsAxisGesture) continue;
				if (o.Axis == a && o.IsPositive == isPos) return o;
			}

			return null;
		}

		public void RegisterOverlay(VirtualController.Button b, Rectangle m, Color c, SlotShape shape)
		{
			slotOverlays.Add(new SlotOverlay(b, m, c, shape));
		}

		public void RegisterOverlay(VirtualController.Axis a, bool isPos, Rectangle m, Color c, SlotShape shape)
		{
			slotOverlays.Add(new SlotOverlay(a, isPos, m, c, shape));
		}

		private Rectangle ButtonMaskRelative(Rectangle r, bool top)
		{
			if (top)
				return new Rectangle(r.X - controllerFront.Left, r.Y - controllerFront.Top, r.Width, r.Height);
			else
				return new Rectangle(r.X - controllerFront.Left, r.Y - controllerFront.Top, r.Width, r.Height);
		}

		private void controllerFront_Paint(object sender, PaintEventArgs e)
		{
			foreach (var slot in slotOverlays) {
				if (slot.Visible && slot.IsAxisGesture || (slot.Button == VirtualController.Button.Br ||
					slot.Button == VirtualController.Button.Bl ||
					slot.Button == VirtualController.Button.Tl ||
					slot.Button == VirtualController.Button.Tr)) {

					DrawButton(slot, e.Graphics);
				}
			}
		}

		private void controllerTop_Paint(object sender, PaintEventArgs e)
		{
			foreach (var slot in slotOverlays) {
				if (slot.Visible && !slot.IsAxisGesture && (slot.Button != VirtualController.Button.Br &&
					slot.Button != VirtualController.Button.Bl &&
					slot.Button != VirtualController.Button.Tl &&
					slot.Button != VirtualController.Button.Tr)) {

					DrawButton(slot, e.Graphics);
				}
			}
		}

		public void Initialize()
		{
			controllerFront.Hide();
			controllerTop.Hide();
			SetupButton(VirtualController.Button.A, btnMaskA);
			SetupButton(VirtualController.Button.B, btnMaskB);
			SetupButton(VirtualController.Button.X, btnMaskX);
			SetupButton(VirtualController.Button.Y, btnMaskY);
			SetupButton(VirtualController.Button.Start, btnMaskStart);
			SetupButton(VirtualController.Button.Back, btnMaskBack);
			SetupButton(VirtualController.Button.System, btnMaskSystem);
			SetupButton(VirtualController.Button.Bl, btnMaskBl);
			SetupButton(VirtualController.Button.Br, btnMaskBr);
			SetupButton(VirtualController.Button.Tl, btnMaskTl);
			SetupButton(VirtualController.Button.Tr, btnMaskTr);
			SetupButton(VirtualController.Button.LeftAnalog, btnMaskLeftAnalog);
			SetupButton(VirtualController.Button.RightAnalog, btnMaskRightAnalog);
			SetupAxisGesture(AxisGesture.LeftXNeg, btnMaskLeftXNeg);
			SetupAxisGesture(AxisGesture.LeftXPos, btnMaskLeftXPos);
			SetupAxisGesture(AxisGesture.LeftYNeg, btnMaskLeftYNeg);
			SetupAxisGesture(AxisGesture.LeftYPos, btnMaskLeftYPos);
			SetupAxisGesture(AxisGesture.RightXNeg, btnMaskRightXNeg);
			SetupAxisGesture(AxisGesture.RightXPos, btnMaskRightXPos);
			SetupAxisGesture(AxisGesture.RightYNeg, btnMaskRightYNeg);
			SetupAxisGesture(AxisGesture.RightYPos, btnMaskRightYPos);
			SetupAxisGesture(AxisGesture.DigitalXNeg, btnMaskDigitalXNeg);
			SetupAxisGesture(AxisGesture.DigitalXPos, btnMaskDigitalXPos);
			SetupAxisGesture(AxisGesture.DigitalYNeg, btnMaskDigitalYNeg);
			SetupAxisGesture(AxisGesture.DigitalYPos, btnMaskDigitalYPos);
		}

		Bitmap backStore = null;
		public void Render ()
		{
			if (backStore == null || backStore.Size != this.Size) {
				if (backStore != null) backStore.Dispose();
				backStore = new Bitmap(Width, Height);
			}

			var g = Graphics.FromImage(backStore);
			g.Clear(this.BackColor);
			
			g.DrawImageUnscaled(controllerFront.Image, controllerFront.Location);
			g.DrawImageUnscaled(controllerTop.Image, controllerTop.Location);

			foreach (var slot in slotOverlays) {
				if (slot.Visible || Hovering == slot) {
					DrawButton(slot, g);
				}
			}

			this.CreateGraphics().DrawImageUnscaled(backStore, new Point(0, 0));
		}

		void DrawRoundRect(Graphics g, Brush b, RectangleF rect, float radius)
		{
			DrawRoundRect(g, null, b, rect, radius);
		}

		void DrawRoundRect(Graphics g, Pen p, Brush b, RectangleF rect, float radius)
		{
			GraphicsPath gp = new GraphicsPath();

			gp.AddLine(rect.X + radius, rect.Y, rect.X + rect.Width - (radius * 2), rect.Y); // Line
			gp.AddArc(rect.X + rect.Width - (radius * 2), rect.Y, radius * 2, radius * 2, 270, 90); // Corner
			gp.AddLine(rect.X + rect.Width, rect.Y + radius, rect.X + rect.Width, rect.Y + rect.Height - (radius * 2)); // Line
			gp.AddArc(rect.X + rect.Width - (radius * 2), rect.Y + rect.Height - (radius * 2), radius * 2, radius * 2, 0, 90); // Corner
			gp.AddLine(rect.X + rect.Width - (radius * 2), rect.Y + rect.Height, rect.X + radius, rect.Y + rect.Height); // Line
			gp.AddArc(rect.X, rect.Y + rect.Height - (radius * 2), radius * 2, radius * 2, 90, 90); // Corner
			gp.AddLine(rect.X, rect.Y + rect.Height - (radius * 2), rect.X, rect.Y + radius); // Line
			gp.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90); // Corner
			gp.CloseFigure();

			if (p != null) g.DrawPath(p, gp);
			if (b != null) g.FillPath(b, gp);
			gp.Dispose();
		}
		private void SetupAxisGesture(AxisGesture ag, Panel panel)
		{
			VirtualController.Axis
				stick = Util.StickFromGesture(ag),
				axis = Util.AxisFromGesture(ag);
			bool pos = Util.PoleFromGesture(ag);
			SlotShape shape = SlotShape.Rounded;

			if (panel.Tag is string) try {
					shape = (SlotShape)Enum.Parse(typeof(SlotShape), panel.Tag as string);
				} catch (FormatException) { }

			AxisActions.Gestures axisGesture = pos ? AxisActions.Gestures.Positive : AxisActions.Gestures.Negative;
			RegisterOverlay(axis, pos, panel.Bounds, panel.BackColor, shape);

			panel.Hide();
			panel.Tag = ag;
		}

		private void SetupButton(VirtualController.Button button, Panel panel)
		{
			string name = button.ToString();
			SlotShape shape = SlotShape.Rounded;

			if (panel.Tag is string) try {
				shape = (SlotShape)Enum.Parse(typeof(SlotShape), panel.Tag as string);
			} catch (FormatException) { }
			RegisterOverlay(button, panel.Bounds, panel.BackColor, shape);
			panel.Tag = button;
			panel.Hide();
		}

		private void DrawButton(SlotOverlay overlay, Graphics g)
		{
			Brush brush;

			if (Hovering == overlay) {
				brush = new SolidBrush(Color.FromArgb(170, overlay.Color));
			} else {
				brush = new SolidBrush(Color.FromArgb(200, overlay.Color));
			}

			switch (overlay.Shape) {
				case SlotShape.Rect:
					g.FillRectangle(brush, overlay.Metrics);
					break;
				case SlotShape.Rounded:
					DrawRoundRect(g, brush, overlay.Metrics, 4);
					break;
				case SlotShape.Circle:
					g.FillEllipse(brush, overlay.Metrics);
					break;
			}
		}

		private void ControllerView_Load(object sender, EventArgs e)
		{
			Initialize();
		}

		private void ControllerView_Paint(object sender, PaintEventArgs e)
		{
			if (backStore == null || backStore.Size != Size)
				Render();

			e.Graphics.DrawImage(backStore, e.ClipRectangle, e.ClipRectangle, GraphicsUnit.Pixel);
		}

		public SlotOverlay Hovering { get; private set; }

		private void ControllerView_MouseMove(object sender, MouseEventArgs e)
		{
			foreach (var o in slotOverlays) {
				if (o.Metrics.Contains(e.Location)) {
					this.Cursor = Cursors.Hand;
					if (Hovering != o) {
						Hovering = o;
						Render();
					}
					return;
				}
			}

			if (Hovering != null) {
				Hovering = null;
				Render();
			}

			this.Cursor = Cursors.Default;
		}

		public event EventHandler SelectedItemChanged;

		public SlotOverlay SelectedItem { get; set; }

		private void ControllerView_Click(object sender, EventArgs e)
		{
		}

		private void ControllerView_MouseClick(object sender, MouseEventArgs e)
		{
			if (previousSelectedItem != SelectedItem && SelectedItemChanged != null)
				SelectedItemChanged(this, EventArgs.Empty);
		}

		SlotOverlay previousSelectedItem;

		private void ControllerView_MouseDown(object sender, MouseEventArgs e)
		{
			previousSelectedItem = SelectedItem;

			foreach (var o in slotOverlays) {
				if (o.Metrics.Contains(e.Location)) {
					SelectedItem = o;
					return;
				}
			}

			SelectedItem = null;
		}

		private void autoSelectInput_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void btnMaskB_Paint(object sender, PaintEventArgs e)
		{

		}

		private void btnMaskRightAnalog_Paint(object sender, PaintEventArgs e)
		{

		}

		private void btnMaskY_Paint(object sender, PaintEventArgs e)
		{

		}

		private void btnMaskX_Paint(object sender, PaintEventArgs e)
		{

		}

		private void btnMaskDigitalYNeg_Paint(object sender, PaintEventArgs e)
		{

		}

		private void btnMaskDigitalXNeg_Paint(object sender, PaintEventArgs e)
		{

		}

		private void btnMaskSystem_Paint(object sender, PaintEventArgs e)
		{

		}

		private void btnMaskDigitalYPos_Paint(object sender, PaintEventArgs e)
		{

		}

		private void btnMaskStart_Paint(object sender, PaintEventArgs e)
		{

		}

		private void btnMaskBack_Paint(object sender, PaintEventArgs e)
		{

		}

		private void btnMaskRightXNeg_Paint(object sender, PaintEventArgs e)
		{

		}

		private void btnMaskA_Paint(object sender, PaintEventArgs e)
		{

		}

		private void btnMaskRightXPos_Paint(object sender, PaintEventArgs e)
		{

		}

		private void btnMaskRightYNeg_Paint(object sender, PaintEventArgs e)
		{

		}

		private void btnMaskRightYPos_Paint(object sender, PaintEventArgs e)
		{

		}

		private void btnMaskTr_Paint(object sender, PaintEventArgs e)
		{

		}

		private void btnMaskTl_Paint(object sender, PaintEventArgs e)
		{

		}

		private void btnMaskBl_Paint(object sender, PaintEventArgs e)
		{

		}

		private void btnMaskBr_Paint(object sender, PaintEventArgs e)
		{

		}
	}

	public enum SlotShape {
		Rect, Circle, Rounded
	}

	public class SlotOverlay : CapturedInput {
		public SlotOverlay(VirtualController.Button b, Rectangle m, Color c, SlotShape shape) :
			base(b)
		{
			Metrics = m;
			Color = c;
			Shape = shape;
		}

		public SlotOverlay(VirtualController.Axis a, bool isPos, Rectangle m, Color c, SlotShape shape) :
			base(a, isPos)
		{
			Metrics = m;
			Color = c;
			Shape = shape;
		}

		public bool Visible = false;
		public Rectangle Metrics;
		public Color Color;
		public SlotShape Shape;


		public ButtonActions GetSlot(Controller c)
		{
			return GetSlot(c.Virtual);
		}

		public ButtonActions GetSlot(VirtualController c)
		{
			if (IsAxisGesture)
				return c.GetAxis(Axis).GetPole(AxisGesture);
			else
				return c.GetButton(Button);
		}
	}

}
