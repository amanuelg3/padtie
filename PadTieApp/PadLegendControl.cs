using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PadTieApp {
	public enum LegendMode {
		None, Overview, Link, Tap, DoubleTap, Hold 
	}

	public partial class PadLegendControl : UserControl {
		public PadLegendControl()
		{
			InitializeComponent();
		}

		PadTieForm mainForm;
		List<Label> labels = new List<Label>();
		LegendMode mode;

		public LegendMode SelectedMode {
			get
			{
				return mode;
			}
			set
			{
				mode = value;
				if (SelectedModeChanged != null) SelectedModeChanged(this, EventArgs.Empty);
			}
		}

		public event EventHandler SelectedModeChanged;
		public void InitLabel(string id, Label label)
		{
			label.Tag = id;
			label.Text = "";
			label.Click += label_Clicked;
			labels.Add(label);
		}

		void label_Clicked(object sender, EventArgs e)
		{
			if (editable) {
				var lbl = (sender as Label);

				editor.Location = lbl.Location;
				editor.Visible = true;
				editor.Text = lbl.Text;
				editor.Tag = lbl.Tag;
				editor.Width = lbl.Width + 8;
				editor.Focus();
				editor.SelectAll();
			}
		}

		public void SetAll(string text)
		{
			foreach (var lbl in labels) {
				lbl.Text = text;
				if (editable)
					lbl.Cursor = Cursors.Hand;
				else
					lbl.Cursor = Cursors.Default;

				if (layout != null)
					layout[lbl.Tag as string] = text;
			}
		}

		public void ClearAll()
		{
			this.layout = null;
			SetAll("");
		}

		int pad = 1;

		public event EventHandler PadChanged;

		public int Pad
		{
			get
			{
				return pad;
			}
			set
			{
				pad = value;
				if (PadChanged != null) PadChanged(this, EventArgs.Empty);
			}
		}

		public Label GetLabel(string id)
		{
			foreach (var lbl in labels) {
				if (lbl.Tag as string == id)
					return lbl;
			}

			return null;
		}

		Dictionary<string, string> layout;
		bool editable = false;

		public void ApplyLayout(Dictionary<string, string> layout, bool editable)
		{
			this.layout = null;
			this.editable = editable;

			if (this.editor.Visible) {
				this.editor.Visible = false;
			}

			if (editable) {
				SetAll("Edit");
			} else {
				SetAll("Unassigned");
			}
			
			this.layout = layout;

			foreach (var kvp in layout) {
				var lbl = GetLabel(kvp.Key);
				lbl.Text = kvp.Value;
				if (editable)
					lbl.Cursor = Cursors.Hand;
				else
					lbl.Cursor = Cursors.Default;
			}
		}

		public Dictionary<string,string> GetLayout()
		{
			return layout;
		}

		public void Init(PadTieForm form)
		{
			mainForm = form;

			InitLabel("X", legendX);
			InitLabel("Y", legendY);
			InitLabel("A", legendA);
			InitLabel("B", legendB);
			InitLabel("Start", legendStart);
			InitLabel("Back", legendBack);
			InitLabel("System", legendSystem);
			InitLabel("Br", legendBr);
			InitLabel("Bl", legendBl);
			InitLabel("Tr", legendTr);
			InitLabel("Tl", legendTl);
			InitLabel("LeftAnalog", legendLeftAnalogClick);
			InitLabel("RightAnalog", legendRightAnalogClick);

			InitLabel("LeftX/Neg", legendLeftAnalogLeft);
			InitLabel("LeftX/Pos", legendLeftAnalogRight);
			InitLabel("LeftY/Neg", legendLeftAnalogUp);
			InitLabel("LeftY/Pos", legendLeftAnalogDown);

			InitLabel("RightX/Neg", legendRightAnalogLeft);
			InitLabel("RightX/Pos", legendRightAnalogRight);
			InitLabel("RightY/Neg", legendRightAnalogUp);
			InitLabel("RightY/Pos", legendRightAnalogDown);
			
			InitLabel("DigitalX/Neg", legendDigitalLeft);
			InitLabel("DigitalX/Pos", legendDigitalRight);
			InitLabel("DigitalY/Neg", legendDigitalUp);
			InitLabel("DigitalY/Pos", legendDigitalDown);

			overviewItem.Tag = LegendMode.Overview;
			linkItem.Tag = LegendMode.Link;
			tapItem.Tag = LegendMode.Tap;
			doubleTapItem.Tag = LegendMode.DoubleTap;
			holdItem.Tag = LegendMode.Hold;

			overviewItem.Click += modeItem_Clicked;
			linkItem.Click += modeItem_Clicked;
			tapItem.Click += modeItem_Clicked;
			doubleTapItem.Click += modeItem_Clicked;
			holdItem.Click += modeItem_Clicked;

			RefreshPads();
		}

		void modeItem_Clicked(object sender, EventArgs e)
		{
			SelectedMode = (LegendMode)(sender as ToolStripItem).Tag;
			viewBtn.Text = (sender as ToolStripItem).Text;
		}

		public void RefreshPads()
		{
			padNumBtn.DropDownItems.Clear();

			foreach (var cc in mainForm.Controllers) {
				var item = new ToolStripMenuItem("Pad #" + cc.Index);
				item.Tag = cc.Index;
				item.Click += delegate(object sender, EventArgs e) {
					Pad = (int)(sender as ToolStripMenuItem).Tag;
				};
				padNumBtn.DropDownItems.Add(item);
			}

		}

		private void PadLegendControl_Load(object sender, EventArgs e)
		{
		}

		private void toolStripContainer2_ContentPanel_Click(object sender, EventArgs e)
		{
			if (editor.Visible)
				editor_KeyUp(editor, new KeyEventArgs(Keys.Enter));
		}

		private void editor_KeyPress(object sender, KeyPressEventArgs e)
		{
		}

		public event EventHandler LayoutChanged;

		private void editor_KeyUp(object sender, KeyEventArgs e)
		{
			if (editor.Visible == false)
				return;

			if (e.KeyCode == Keys.Enter) {
				e.Handled = true;
				var id = (sender as TextBox).Tag as string;
				var lbl = GetLabel(id);

				if (lbl == null) {
					MessageBox.Show("Error: could not locate slot " + id);
					return;
				}

				layout[id] = editor.Text;
				lbl.Text = editor.Text;

				if (LayoutChanged != null)
					LayoutChanged(this, EventArgs.Empty);

				editor.Hide();
			}
		}
	}
}
