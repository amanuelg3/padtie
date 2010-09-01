using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PadTie;
using System.IO;
using System.Net;

namespace PadTieApp {
	public partial class MappingWizard : Form, IFontifiable {
		public MappingWizard()
		{
			InitializeComponent();
		}

		public bool Fontified { get; set; }

		private void MappingWizard_Load(object sender, EventArgs e)
		{
			page1.BringToFront();
			Text = "Button Mapping Wizard for " + Controller.Device.ProductName;
			lblPage1.Text = lblPage1.Text.Replace("%", Controller.Device.ProductName);

			Fontify.Go(this);
		}

		private void blinker_Tick(object sender, EventArgs e)
		{
			if (indicator.Tag as string == "on")
				indicator.Visible = !indicator.Visible;
		}

		private void cancelBtn_Click(object sender, EventArgs e)
		{
			if (page != 1) {
				Controller.Virtual.Enabled = true;

				foreach (var btn in Controller.Device.Buttons)
					btn.PressReceived -= buttonPressed;

				foreach (var axis in Controller.Device.Axes) {
					axis.EnableGestures = false;
					axis.PositivePress -= axisPressed;
					axis.NegativePress -= axisPressed;
				}
			}
			this.Close();
		}

		int page = 1;
		public PadTieForm MainForm;
		public Controller Controller;
		List<ButtonSpot> remainingBtnSpots;
		List<AxisSpot> remainingAxisSpots;
		public List<DeviceMapping> mappings = new List<DeviceMapping>();

		private void buttonPressed(object sender, EventArgs e)
		{
			if (remainingBtnSpots.Count == 0)
				return;

			pbar.Value += 1;

			var spot = remainingBtnSpots[0];
			remainingBtnSpots.RemoveAt(0);

			if (sender != null) {
				var ba = sender as ButtonActions;
				int id = (int)ba.Identifier;

				var dm = new DeviceMapping();
				dm.Source = "button:" + (id - 1);
				dm.Gesture = "Link";
				dm.Destination = spot.Button.ToString();
				mappings.Add(dm);
				progress.Text += string.Format("- Mapped button {0} to {1}", id - 1, Util.GetButtonDisplayName(spot.Button)) + "\n";
			} else {
				progress.Text += string.Format("- Not mapping button {0}", Util.GetButtonDisplayName(spot.Button)) + "\n";
			}

			if (spot.Button == VirtualController.Button.Tr) {
				front.Show();
				top.Hide();
			}

			if (remainingBtnSpots.Count == 0) {
				var aspot = remainingAxisSpots[0];
				indicator.Location = new Point(front.Left + aspot.X - 8, front.Top + aspot.Y - 10);
				return;
			} else {
				int xadd = 0, yadd = 0;

				if (front.Visible) {
					xadd = -3;
					yadd = -3;
				}

				spot = remainingBtnSpots[0];
				indicator.Location = new Point(front.Left + spot.X + xadd, front.Top + spot.Y + yadd);
			}
		}

		private void axisPressed(object sender, EventArgs e)
		{
			if (remainingBtnSpots.Count > 0)
				return;
			if (remainingAxisSpots.Count == 0)
				return;

			pbar.Value += 1;

			var spot = remainingAxisSpots[0];
			remainingAxisSpots.RemoveAt(0);

			if (sender != null) {
				var aa = sender as AxisActions;
				int id = (int)aa.Identifier;

				var dm = new DeviceMapping();
				dm.Source = "axis:" + (id - 1);
				dm.Destination = spot.Axis.ToString();
				dm.Gesture = "";
				mappings.Add(dm);
				progress.Text += string.Format("- Mapped axis #{0} to {1}", id - 1, Util.GetAxisDisplayName(spot.Axis)) + "\n";
			} else {
				progress.Text += string.Format("- Not mapping axis {0}", Util.GetAxisDisplayName(spot.Axis)) + "\n";
			}

			if (remainingAxisSpots.Count == 0) {
				page3.BringToFront();
				startBtn.Enabled = true;
				noHaveBtn.Enabled = false;
				finishedLbl.Text = finishedLbl.Text.Replace("%", Controller.Device.ProductName);
				sendPermission.Text = sendPermission.Text.Replace("%", Controller.Device.ProductName);
				pbar.Hide();
			} else {
				spot = remainingAxisSpots[0];
				indicator.Location = new Point(front.Left + spot.X - 3, front.Top + spot.Y - 3);
			}
		}

		class ButtonSpot {
			public ButtonSpot(VirtualController.Button button, int x, int y)
			{
				Button = button;
				X = x;
				Y = y;
			}

			public int X;
			public int Y;
			public VirtualController.Button Button;
		}

		class AxisSpot {
			public AxisSpot(VirtualController.Axis axis, int x, int y)
			{
				Axis = axis;
				X = x;
				Y = y;
			}

			public int X;
			public int Y;
			public VirtualController.Axis Axis;
		}

		private void startBtn_Click(object sender, EventArgs e)
		{
			if (page == 1) {
				page = 2;
				page2.BringToFront();
				pbar.Visible = true;
				startBtn.Enabled = false;
				startBtn.Text = "Finish";
				ButtonSpot[] buttonSpots = new[] {
					new ButtonSpot(VirtualController.Button.Tl, 70, 91),
					new ButtonSpot(VirtualController.Button.Bl, 70, 119),
					new ButtonSpot(VirtualController.Button.Br, 199, 119),
					new ButtonSpot(VirtualController.Button.Tr, 199, 91),
					new ButtonSpot(VirtualController.Button.A, 204, 86),
					new ButtonSpot(VirtualController.Button.B, 222, 67),
					new ButtonSpot(VirtualController.Button.X, 185, 67),
					new ButtonSpot(VirtualController.Button.Y, 204, 49),
					new ButtonSpot(VirtualController.Button.Start, 160, 69),
					new ButtonSpot(VirtualController.Button.Back, 110, 69),
					new ButtonSpot(VirtualController.Button.System, 135, 69),
					new ButtonSpot(VirtualController.Button.LeftAnalog, 67, 67),
					new ButtonSpot(VirtualController.Button.RightAnalog, 167, 107),
				};
				
                AxisSpot[] axisSpots = new[] {
					new AxisSpot(VirtualController.Axis.LeftY, 67, 53),
					new AxisSpot(VirtualController.Axis.LeftX, 52, 65),
					new AxisSpot(VirtualController.Axis.DigitalY, 99, 94),
					new AxisSpot(VirtualController.Axis.DigitalX, 85, 108),
					new AxisSpot(VirtualController.Axis.RightY, 167, 94),
					new AxisSpot(VirtualController.Axis.RightX, 154, 107),
				};

				// Adjust by the design-time location of the image...
				var pos = new Point(13, 25);

				foreach (var spot in buttonSpots) {
					spot.X -= pos.X;
					spot.Y -= pos.Y;
				}

				foreach (var spot in axisSpots) {
					spot.X -= pos.X;
					spot.Y -= pos.Y;
				}

				front.Hide();
				remainingBtnSpots = new List<ButtonSpot>();
				remainingBtnSpots.AddRange(buttonSpots);
				remainingAxisSpots = new List<AxisSpot>();
				remainingAxisSpots.AddRange(axisSpots);

				foreach (var btn in Controller.Device.Buttons)
					btn.PressReceived += buttonPressed;

				foreach (var axis in Controller.Device.Axes) {
					axis.EnableGestures = true;
					axis.PositivePress += axisPressed;
					axis.NegativePress += axisPressed;
				}

				Controller.Virtual.Enabled = false;

				indicator.Tag = "on";
				indicator.Location = new Point(front.Left + remainingBtnSpots[0].X, front.Top + remainingBtnSpots[0].Y);

				progress.Text += " - Product: " + Controller.Device.ProductName + "\n";
				noHaveBtn.Enabled = true;
			} else {
				Controller.Virtual.Enabled = true;

				foreach (var btn in Controller.Device.Buttons)
					btn.PressReceived -= buttonPressed;

				foreach (var axis in Controller.Device.Axes) {
					axis.EnableGestures = false;
					axis.PositivePress -= axisPressed;
					axis.NegativePress -= axisPressed;
				}

				GamepadConfig gpc = new GamepadConfig();
				string deviceID = Controller.Device.VendorID.ToString("X4") + Controller.Device.ProductID.ToString("X4");
				gpc.DeviceID = "0x" + deviceID.ToLower();
				gpc.Mappings = mappings;
				gpc.Notes = "Created by Pad Tie's Mapping Wizard!";
				gpc.Product = Controller.Device.ProductName;
				gpc.Vendor = "";
				string fileName = Path.Combine(MainForm.GetDocs(), gpc.DeviceID + ".xml");

				if (!Directory.Exists(Path.GetDirectoryName(fileName)))
					Directory.CreateDirectory(Path.GetDirectoryName(fileName));

				if (File.Exists (fileName))
					fileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "gamepads", gpc.DeviceID + "-autogen.xml");

				try {
					gpc.Save(fileName);
				} catch (UnauthorizedAccessException e2) {
					MessageBox.Show("Failed to save mapping for later use. Your gamepad will still work. Message: " + e2.Message);
				}

				if (sendPermission.Checked) {
					// Thank you all!
					HttpWebRequest r = WebRequest.Create("http://stridetechnologies.net/padtie/submit-dmap.php") as HttpWebRequest;
					r.Method = "POST";
					r.ContentType = "application/x-www-form-urlencoded";
					string data;
					using (var sr = new StreamReader(fileName))
						data = string.Format("id={1}&config={0}", Uri.EscapeDataString(sr.ReadToEnd()).Replace("%20", "+"), 
							gpc.DeviceID);

					byte[] d = Encoding.ASCII.GetBytes(data);
					using (var st = r.GetRequestStream())
						st.Write(d, 0, d.Length);
					HttpWebResponse resp = null;

					try {
						resp = r.GetResponse() as HttpWebResponse;

						if (resp.StatusCode == HttpStatusCode.NoContent) {
							MessageBox.Show("Thank you for submitting the new mapping!");
						} else {
							string rs;
							using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
								rs = sr.ReadToEnd();

							MessageBox.Show("Could not contact upload server :-( : " + resp.StatusCode +
								Environment.NewLine + Environment.NewLine + rs);
						}
					} catch (WebException e2) {
						string rs;
						using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
							rs = sr.ReadToEnd();

						MessageBox.Show("An error occurred while sending the mapping :-( : " + e2.Message + Environment.NewLine + Environment.NewLine + rs);
					}

					
					Controller.DeviceConfig.Mappings = gpc.Mappings;
					Controller.Device.Reset();

					foreach (var dm in gpc.Mappings) {
						if (dm.Source.StartsWith("button:")) {
							int btn = int.Parse(dm.Source.Substring("button:".Length));
							VirtualController.Button b = (VirtualController.Button)Enum.Parse(typeof(VirtualController.Button), dm.Destination);
							var ba = new VirtualController.ButtonAction(Controller.Virtual, b);

							if (dm.Gesture != "Link" && dm.Gesture != "" && dm.Gesture != null) {
								// We need to enable gesture support at the device level for this button
								Controller.Device.Buttons[btn].EnableGestures = true;
							}

							switch (dm.Gesture) {
								case "Link":
								case null:
								case "":
									Controller.Device.Buttons[btn].Link = ba;
									break;
								case "Tap":
									Controller.Device.Buttons[btn].Tap = ba;
									break;
								case "DoubleTap":
									Controller.Device.Buttons[btn].DoubleTap = ba;
									break;
								case "Hold":
									Controller.Device.Buttons[btn].Hold = ba;
									break;
							}
						} else {
							int axis = int.Parse(dm.Source.Substring("axis:".Length));
							VirtualController.Axis a = (VirtualController.Axis)Enum.Parse(typeof(VirtualController.Axis), dm.Destination);
							Controller.Device.Axes[axis].Analog = new VirtualController.AxisAction(Controller.Virtual, a);
						}
					}

					MainForm.GlobalConfig.Save();
					if (resp != null) resp.Close();
				}

				this.Close();
			}
		}

		private void noHaveBtn_Click(object sender, EventArgs e)
		{
			if (remainingBtnSpots.Count > 0)
				buttonPressed(null, null);
			else
				axisPressed(null, null);
		}
	}
}
