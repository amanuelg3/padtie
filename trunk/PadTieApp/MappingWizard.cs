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
	public partial class MappingWizard : Form {
		public MappingWizard()
		{
			InitializeComponent();
		}

		private void MappingWizard_Load(object sender, EventArgs e)
		{
			page1.BringToFront();
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
				indicator.Location = new Point(aspot.X, aspot.Y);
				return;
			} else {
				spot = remainingBtnSpots[0];
				indicator.Location = new Point(spot.X, spot.Y);
			}
		}

		private void axisPressed(object sender, EventArgs e)
		{
			if (remainingBtnSpots.Count > 0)
				return;
			if (remainingAxisSpots.Count == 0)
				return;

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
			} else {
				spot = remainingAxisSpots[0];
				indicator.Location = new Point(spot.X, spot.Y);
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
				indicator.Location = new Point(remainingBtnSpots[0].X, remainingBtnSpots[0].Y);

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
				gpc.DeviceID = "0x" + deviceID;
				gpc.Mappings = mappings;
				gpc.Notes = "Created by Pad Tie's Mapping Wizard!";
				gpc.Product = Controller.Device.ProductName;
				gpc.Vendor = "";
				string fileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "gamepads", deviceID + ".xml");

				if (File.Exists (fileName))
					fileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "gamepads", deviceID + "-autogen.xml");

				gpc.Save(fileName);

				if (sendPermission.Checked) {
					// Thank you all!
					HttpWebRequest r = WebRequest.Create("http://stridetechnologies.net/padtie/submit-dmap.php") as HttpWebRequest;
					r.Method = "POST";
					r.ContentType = "application/x-www-form-urlencoded";
					string data;
					using (var sr = new StreamReader(fileName))
						data = string.Format("config={0}", Uri.EscapeDataString(sr.ReadToEnd()).Replace("%20", "+"));

					byte[] d = Encoding.ASCII.GetBytes(data);
					using (var st = r.GetRequestStream())
						st.Write(d, 0, d.Length);
					HttpWebResponse resp = null;

					try {
						resp = r.GetResponse() as HttpWebResponse;

						if (resp.StatusCode == HttpStatusCode.NoContent) {
							MessageBox.Show("Thank you for submitting the new mapping!");
						} else {
							MessageBox.Show("Could not contact upload server :-(");
						}
					} catch (WebException) {
						MessageBox.Show("An error occurred while sending the mapping :-(");
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
