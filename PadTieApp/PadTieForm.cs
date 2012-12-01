using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PadTie;
using System.Threading;
using System.IO;
using System.Globalization;
using System.Reflection;

namespace PadTieApp
{
    public partial class PadTieForm : Form, IFontifiable
    {
        public const string ProfilesFolderName = "Profiles";
        public const string GamepadsFolderName = "Gamepads";
        public const string AppFolderName = "Pad Tie";

        public PadTieForm()
        {
            AppPath = Path.GetDirectoryName(Application.ExecutablePath);
            UserStorePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), AppFolderName);

            BuiltinProfilesPath = Path.Combine(AppPath, ProfilesFolderName);
            BuiltinGamepadsPath = Path.Combine(AppPath, GamepadsFolderName);
            UserProfilesPath = Path.Combine(UserStorePath, ProfilesFolderName);
            UserGamepadsPath = Path.Combine(UserStorePath, GamepadsFolderName);

            // Create the directories if needed
            if (!Directory.Exists(UserStorePath)) try { Directory.CreateDirectory(UserStorePath); } catch (Exception) { }
            if (!Directory.Exists(UserProfilesPath)) try { Directory.CreateDirectory(UserProfilesPath); } catch (Exception) { }
            if (!Directory.Exists(UserGamepadsPath)) try { Directory.CreateDirectory(UserGamepadsPath); } catch (Exception) { }
            if (!Directory.Exists(BuiltinProfilesPath)) try { Directory.CreateDirectory(BuiltinProfilesPath); } catch (Exception) { }
            if (!Directory.Exists(BuiltinGamepadsPath)) try { Directory.CreateDirectory(BuiltinGamepadsPath); } catch (Exception) { }

            InitializeComponent();
        }

        public bool Fontified { get; set; }

        public class SwitchConfigAction : InputAction
        {
            public SwitchConfigAction(InputCore core, ConfigItem item, bool onRelease) :
                this(core, item.FileName, item.IsBuiltIn, onRelease)
            {
            }

            public SwitchConfigAction(InputCore core, string file, bool isBuiltIn, bool onRelease)
            {
                Core = core;
                MainForm = core.Tag as PadTieForm;
                FileName = file;
                IsBuiltIn = isBuiltIn;
                SwitchOnRelease = onRelease;
            }

            public InputCore Core;
            public string FileName;
            public bool IsBuiltIn;
            public bool SwitchOnRelease;
            public PadTieForm MainForm;

            public override string ToString()
            {
                ConfigItem i = new ConfigItem(FileName, IsBuiltIn);
                return string.Format("Switch configuration to '{0}' ({1})", i.Title, IsBuiltIn ? "Built in" : "Custom");
            }

            public override string ToParseable()
            {
                return string.Join(",", new string[] { FileName, IsBuiltIn + "", SwitchOnRelease + "" });
            }

            public static SwitchConfigAction Parse(InputCore core, string parseable)
            {
                string[] props = parseable.Split(',');

                if (props.Length < 3)
                    throw new FormatException("Invalid property data for action 'Switch Configuration'");

                return new SwitchConfigAction(core, props[0], bool.Parse(props[1]), bool.Parse(props[2]));
            }

            public void Switch()
            {
                MainForm.ChangeConfig(new ConfigItem(FileName, IsBuiltIn));
            }

            public override void Press()
            {
                if (!SwitchOnRelease)
                    Switch();
            }

            public override void Release()
            {
                if (SwitchOnRelease)
                    Switch();
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        InputCore padTie;
        List<Controller> controllers = new List<Controller>();
        Config config;

        public Controller[] Controllers { get { return controllers.ToArray(); } }
        public InputCore PadTie { get { return padTie; } }

        public Controller FindControllerForConfig(DeviceConfig config)
        {
            foreach (var cc in controllers) {
                if (cc.DeviceConfig.DeviceID == config.DeviceID)
                    return cc;
            }

            return null;
        }

        public string FindConfigFile(string file)
        {
            if (File.Exists(file))
                return file;

            if (!Directory.Exists(UserProfilesPath))
                Directory.CreateDirectory(UserProfilesPath);

            if (File.Exists(Path.Combine(UserProfilesPath, file)))
                return Path.Combine(UserProfilesPath, file);

            if (File.Exists(Path.Combine(BuiltinProfilesPath, file)))
                return Path.Combine(BuiltinProfilesPath, file);

            return file;
        }

        FileSystemWatcher wConfigDir = null;
        bool wChanged = false;

        public Config Config { get { return config; } }
        public void RefreshConfigList()
        {
            RefreshConfigList(false);
        }

        public void RefreshConfigList(bool force)
        {
            Directory.GetLastWriteTime(Application.ExecutablePath);
            string appDir = BuiltinProfilesPath;
            string cfgDir = UserProfilesPath;

            if (wConfigDir == null) {
                wConfigDir = new FileSystemWatcher(cfgDir);
                wConfigDir.Filter = "*.config.xml";
                wConfigDir.Changed += delegate(object sender, FileSystemEventArgs e)
                {
                    wChanged = true;
                };
                wConfigDir.EnableRaisingEvents = true;
                wChanged = false;
            } else if (!wChanged && !force) {
                return;
            }

            wChanged = false;
            refreshingConfigs = true;

            try {
                configBox.Items.Clear();
                switchConfigMenu.DropDownItems.Clear();

                ConfigItem current = null;
                List<string> items = new List<string>();

                if (Directory.Exists(cfgDir)) foreach (string item in Directory.GetFiles(cfgDir, "*.config.xml"))
                        items.Add(item);

                if (Directory.Exists(appDir)) foreach (string item in Directory.GetFiles(appDir, "*.config.xml"))
                        items.Add(item);

                items.Sort(delegate(string a, string b)
                {
                    return StringComparer.Create(CultureInfo.InvariantCulture, true).Compare(
                        Path.GetFileName(a), Path.GetFileName(b));
                });

                foreach (string item in items) {
                    var ci = new ConfigItem(item);

                    if (appDir == Path.GetDirectoryName(item))
                        ci.IsBuiltIn = true;

                    if (ci.Title == "default") {
                        ci.Title = "Blank";
                    }

                    if (Path.GetFileName(ci.FileName) == config.FileName)
                        current = ci;

                    switchConfigMenu.DropDownItems.Add(new ToolStripMenuItem(ci.ToString(), null,
                        delegate(object sender, EventArgs e)
                        {
                            ChangeConfig(ci);
                            RefreshConfigList(true);
                        }
                    ));
                    configBox.Items.Add(ci);
                }

                configBox.SelectedItem = current;
            } finally {
                refreshingConfigs = false;
            }
        }

        bool refreshingConfigs = false;
        public class ConfigItem
        {
            public ConfigItem(string file)
            {
                // Just do it twice to get rid of the '.config'
                Title = Path.GetFileNameWithoutExtension(Path.GetFileNameWithoutExtension(file));
                FileName = file;
            }

            public ConfigItem(string file, bool isBuiltIn) :
                this(file)
            {
                IsBuiltIn = isBuiltIn;
            }

            public string FileName;
            public string Title;

            public override string ToString()
            {
                if (IsBuiltIn)
                    return Title + " [Built-in]";

                return Title + " [Custom]";
            }

            public bool IsBuiltIn { get; set; }
        }

        private void MoveOverwrite(string from, string to)
        {
            try {
                if (File.Exists(to))
                    File.Delete(to);
                File.Move(from, to);
            } catch (Exception) { }
        }

        public void LoadGlobalConfig(string configFile)
        {
            // The global configuration deals with the mapping between physical devices
            // and their virtual controller counterparts. If no device entry exists for 
            // a given device, one is created according to the available device information
            // and it is assigned the first pad number which does not have any mappings 
            // associated with it.

            if (!File.Exists(configFile)) {
                try {
                    globalConfig = new GlobalConfig();
                    globalConfig.Save(configFile);
                } catch (Exception e) {
                    MessageBox.Show("An error occurred while creating a new configuration file. Pad Tie will now close. Error: " + e.Message);
                }
            } else {
                try {
                    globalConfig = GlobalConfig.Load(configFile);
                } catch (Exception e) {
                    string backupFile = Path.Combine(Path.GetDirectoryName(configFile), Path.GetFileNameWithoutExtension(configFile) + ".backup.xml");

                    if (File.Exists(backupFile)) {
                        try {
                            string broken = Path.Combine(Path.GetDirectoryName(configFile), Path.GetFileNameWithoutExtension(configFile) + ".broken.xml");

                            MoveOverwrite(configFile, broken);
                            File.Move(backupFile, configFile);

                            globalConfig = GlobalConfig.Load(configFile);

                            notifyIcon.ShowBalloonTip(40000, "An error occurred while opening Pad Tie's configuration file.",
                                "An older version of your settings has been recovered. Click for details.", ToolTipIcon.Error);
                            BalloonHandler = delegate()
                            {
                                MessageBox.Show("Failed to load configuration: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            };

                        } catch (Exception e2) {
                            MessageBox.Show("An error occurred while opening Pad Tie's configuration (" + e.Message + "). " +
                                "A backup was found but could not be loaded (" + e2.Message + "). Your global settings have been lost.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            File.Delete(configFile);
                        }
                    } else {
                        MessageBox.Show("An error occurred while trying to open Pad Tie's configuration file. " +
                            "Your global settings have been lost. Error: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        File.Delete(configFile);
                    }
                }

                if (globalConfig == null) {
                    globalConfig = new GlobalConfig();
                    globalConfig.Save(configFile);
                }
            }
            UpdateSettings();
            MapDeviceConfigs();
            ConfigureNewDevices();
        }

        int freePad = 1;

        public string FindFile(string name, string[] paths, string defaultFile)
        {
            foreach (string path in paths) {
                if (File.Exists(Path.Combine(path, name)))
                    return Path.Combine(path, name);
            }

            return defaultFile;
        }

        public GamepadConfig FindGamepadConfig(int vendorID, int productID)
        {
            string[] path = new[] { UserGamepadsPath, BuiltinGamepadsPath };
            string id = string.Format("0x{0}{1}", vendorID.ToString("x4"), productID.ToString("x4"));
            string configFile = FindFile(id + ".xml", path, null);

            bool noConfig = string.IsNullOrEmpty(configFile) || !File.Exists(configFile);
            bool generic = false;

            if (noConfig && File.Exists(configFile)) {
                configFile = Path.Combine(BuiltinGamepadsPath, "Generic.xml");
                noConfig = false;
                generic = true;
            }

            if (!noConfig) {
                var gpc = GamepadConfig.Load(configFile);
                gpc.IsGeneric = generic;
                return gpc;
            }

            return null;
        }

        public void ConfigureNewDevices()
        {
            int newDeviceCount = 0;

            foreach (var ic in padTie.Controllers) {
                if (ic.ApplicationMapped) continue;

                // This controller does not have a configuration associated with it.
                // Try to find a mapping in the database and load that, assigning the 
                // controller to the next free virtual pad, and then advancing the free
                // pad indicator.

                var gpc = FindGamepadConfig(ic.VendorID, ic.ProductID);

                var dc = new DeviceConfig();
                dc.InstanceGUID = ic.InstanceGUID;
                dc.DeviceID = "0x" + ic.VendorID.ToString("X4") + ic.ProductID.ToString("X4");
                dc.Present = false;
                dc.PadNumber = -1;

                if (gpc != null) {
                    dc.IsGeneric = gpc.IsGeneric;
                    // Copy the mappings so changes don't affect the original 
                    foreach (var dm in gpc.Mappings) {
                        var dm2 = dm.Clone();
                        dm2.Pad = -1;
                        dc.Mappings.Add(dm2);
                    }
                }

                globalConfig.Devices.Add(dc);
                ++newDeviceCount;
                Console.WriteLine("Loaded pre-made configuration for new device '{0}'", ic.ProductName);
            }

            // If we added devices, map their configs to VCs and the UI

            if (newDeviceCount > 0) {
                globalConfig.Save();
                MapDeviceConfigs();
            }
        }

        public void ReassignPadNumber(Controller cc)
        {
            var dc = cc.DeviceConfig;

            int padNumber;
            if (dc.PadNumber != -1 && dc.PadNumber >= freePad) {
                padNumber = dc.PadNumber;
                freePad = padNumber + 1;
            } else {
                List<int> inUse = new List<int>();
                foreach (var c in controllers)
                    inUse.Add(c.Index);

                int p = 1;
                while (inUse.Contains(p)) ++p;
                padNumber = p;
            }

            cc.Index = padNumber;

            ReapplyConfig();
            cc.Tab.Text = "Pad #" + padNumber;
            cc.Tab.Tag = padNumber;
            cc.SettingsUI.SetPadNumber(padNumber);
        }

        public void MapDeviceConfigs()
        {
            globalConfig.Devices.Sort(delegate(DeviceConfig a, DeviceConfig b)
            {
                int v = a.PadNumber;
                if (v < 0)
                    v = 0xFFFFFF;
                return v - b.PadNumber;
            });

            foreach (var dc in globalConfig.Devices) {

                // If the device is marked Present, the config has already been
                // assigned to a device
                if (dc.Present) continue;

                // Find an unmapped device which fits the ID of the config

                foreach (var ic in padTie.Controllers) {
                    if (ic.ApplicationMapped) continue;

                    if ("0x" + ic.VendorID.ToString("X4") + ic.ProductID.ToString("X4") != dc.DeviceID)
                        continue;

                    if (dc.InstanceGUID != "" && dc.InstanceGUID != ic.InstanceGUID)
                        continue;

                    ic.ApplicationMapped = true;
                    dc.Present = true;

                    var gpc = FindGamepadConfig(ic.VendorID, ic.ProductID);
                    if (gpc != null)
                        dc.Mappings = gpc.Mappings;

                    int padNumber;
                    if (dc.PadNumber != -1 && dc.PadNumber >= freePad) {
                        padNumber = dc.PadNumber;
                        freePad = padNumber + 1;
                    } else {
                        List<int> inUse = new List<int>();
                        foreach (var c in controllers)
                            inUse.Add(c.Index);

                        int p = 1;
                        while (inUse.Contains(p)) ++p;
                        padNumber = p;
                    }

                    var cc = new Controller(padTie, ic, padNumber);
                    controllers.Add(cc);


                    cc.DeviceConfig = dc;
                    cc.SettingsUI = new PadSettingsControl();
                    cc.SettingsUI.Initialize(this, padTie, cc, padNumber);

                    string name = cc.Device.ProductName;

                    if (cc.DeviceConfig.Label != "")
                        name = cc.DeviceConfig.Label;

                    cc.Tab = new TabPage("Pad #" + padNumber + " - " + name);
                    cc.Tab.Controls.Add(cc.SettingsUI);
                    cc.Tab.Tag = padNumber;
                    padTabs.TabPages.Add(cc.Tab);

                    SortTabs();

                    cc.SettingsUI.SetBounds(0, 0, cc.Tab.Width, cc.Tab.Height);
                    cc.SettingsUI.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

                    // Set up the mappings according to the config

                    foreach (var mapping in dc.Mappings) {
                        int destPad = padNumber;
                        if (mapping.Pad != -1)
                            destPad = mapping.Pad;

                        if (mapping.Source.StartsWith("button:")) {
                            int buttonNumber = int.Parse(mapping.Source.Substring("button:".Length));
                            VirtualController.Button buttonDest = (VirtualController.Button)Enum.Parse(
                                typeof(VirtualController.Button),
                                mapping.Destination);

                            var ba = new VirtualController.ButtonAction(cc.Virtual, buttonDest);

                            if (mapping.Gesture == "Hold")
                                ic.Buttons[buttonNumber].Hold = ba;
                            else if (mapping.Gesture == "Tap")
                                ic.Buttons[buttonNumber].Tap = ba;
                            else if (mapping.Gesture == "DoubleTap")
                                ic.Buttons[buttonNumber].DoubleTap = ba;
                            else if (mapping.Gesture == "Link")
                                ic.Buttons[buttonNumber].Link = ba;
                            else
                                ic.Buttons[buttonNumber].Raw = ba;

                        } else if (mapping.Source.StartsWith("axis:")) {
                            int axisNumber = int.Parse(mapping.Source.Substring("axis:".Length));
                            VirtualController.Axis axisDest = (VirtualController.Axis)Enum.Parse(
                                typeof(VirtualController.Axis),
                                mapping.Destination);
                            ic.Axes[axisNumber].Analog = new VirtualController.AxisAction(cc.Virtual, axisDest);
                        }
                    }

                    Console.WriteLine("Found and mapped configuration for device '{0}' to pad #{1}", ic.ProductName, padNumber);
                    cc.IsGeneric = dc.IsGeneric;
                    padLegend.RefreshPads();
                    break;
                }
            }
        }

        private void SortTabs()
        {
            TabPage[] pages = new TabPage[padTabs.TabCount];
            for (int j = 0, max = padTabs.TabCount; j < max; ++j) pages[j] = padTabs.TabPages[j];
            Array.Sort<TabPage>(pages, delegate(TabPage a, TabPage b)
            {
                int aNumber = 0, bNumber = 0;

                if (a.Tag == null) aNumber = 0;
                else if (a.Tag as string == "first") aNumber = -1;
                else if (a.Tag as string == "last") aNumber = int.MaxValue - 2;
                else if (a.Tag as string == "end") aNumber = int.MaxValue - 1;
                else if (a.Tag is int) aNumber = (int)a.Tag;

                if (b.Tag == null) bNumber = 0;
                else if (b.Tag as string == "first") bNumber = -1;
                else if (b.Tag as string == "last") bNumber = int.MaxValue - 2;
                else if (b.Tag as string == "end") bNumber = int.MaxValue - 1;
                else if (b.Tag is int) bNumber = (int)b.Tag;

                return aNumber - bNumber;
            });
            padTabs.TabPages.Clear();
            padTabs.TabPages.AddRange(pages);
        }

        /// <summary>
        /// Reloads the configuration from disk- changes previously written to the config will now be applied.
        /// </summary>
        public void ReloadConfig()
        {
            LoadConfig(Config.Load(Config.FileName));
        }

        /// <summary>
        /// Reapplies the settings of a configuration, without reloading it from disk.
        /// </summary>
        public void ReapplyConfig()
        {
            if (Config != null)
                ChangeConfig(new ConfigItem(Config.FileName, Config.Builtin));
        }

        public void LoadConfig()
        {
            string appDir = Path.GetDirectoryName(Application.ExecutablePath);
            string configFile = FindConfigFile("default.config.xml");
            string globalConfigFile = Path.Combine(UserStorePath, "globalconfig.xml");

            // Check if it's wise to write our global config next to the application (portability)
            if (!appDir.StartsWith(Environment.ExpandEnvironmentVariables("%programfiles%"))) {
                bool safe = true;

                try {
                    using (var sw = new StreamWriter(Path.Combine(appDir, "PadTie.tmp"))) sw.Write('.');
                } catch {
                    safe = false;
                }

                try { File.Delete(Path.Combine(appDir, "PadTie.tmp")); } catch { }

                if (safe) {
                    var user = globalConfigFile;
                    var local = Path.Combine(appDir, "globalconfig.xml");

                    if (File.Exists(local))
                        globalConfigFile = local;
                    else if (File.Exists(user))
                        globalConfigFile = user;
                }
            }

            LoadGlobalConfig(globalConfigFile);

            if (globalConfig.Settings.DefaultConfigFile != "")
                configFile = FindConfigFile(Path.GetFileName(globalConfig.Settings.DefaultConfigFile));

            if (!File.Exists(configFile)) {
                config = new Config();

                int index = 0;
                foreach (var cc in controllers) {
                    var ccConfig = new PadConfig();
                    ccConfig.Index = (index + 1);
                    config.Pads.Add(ccConfig);
                    ++index;
                }
                config.FileName = configFile;
                SaveConfig();
            } else {
                config = Config.Load(configFile);
            }

            LoadConfig(config);
        }

        public void LoadConfig(Config config)
        {
            this.config = config;
            this.config.UpdatedForCompatibility = false;
            this.config.CompatibilityUpdates.Clear();
            bool valid = false;

            infobox.Text = this.config.Info.Replace("\\n", "\r\n");
            layoutName.Text = this.config.Label;
            layoutNameTemplate = false;
            infoTemplate = false;
            infobox.Font = new Font(infobox.Font, FontStyle.Regular);
            layoutName.Font = new Font(layoutName.Font, FontStyle.Regular);

            if (infobox.Text == "") {
                infobox.Text = "Click to enter description.";
                infobox.Font = new Font(infobox.Font, FontStyle.Italic);
                infoTemplate = true;
            }

            if (layoutName.Text == "") {
                layoutName.Text = "Click to set title for layout";
                layoutName.Font = new Font(layoutName.Font, FontStyle.Italic);
                layoutNameTemplate = true;
            }

            List<Controller> configured = new List<Controller>();

            foreach (var pc in config.Pads) {
                var cc = GetController(pc.Index);
                if (cc == null) {
                    //MessageBox.Show(string.Format(
                    //    "Ignoring configuration for pad #{0}, " +
                    //        "connect more game pads or change device " + 
                    //        "mappings and reload to use this pad.", 
                    //    pc.Index));
                    continue;
                }

                LoadPadConfig(cc, pc);
                configured.Add(cc);
                valid = true;
            }

            foreach (var cc in controllers) {
                if (!configured.Contains(cc)) {
                    var pc = new PadConfig();
                    pc.Index = cc.Index;
                    config.Pads.Add(pc);

                    LoadPadConfig(cc, pc);
                }
            }

            UpdateLegend();

            this.config.NoPadsConfigured = !valid;

            if (this.config.NoPadsConfigured && this.controllers.Count > 0) {
                List<string> li = new List<string>();
                List<string> cli = new List<string>();

                foreach (var pad in this.config.Pads)
                    li.Add("#" + pad.Index);

                foreach (var cc in controllers)
                    cli.Add(string.Format("{0} (#{1})", cc.Device.ProductName, cc.Index));

                if (li.Count > 1)
                    li[li.Count - 1] = " or " + li[li.Count - 1];

                if (cli.Count > 1)
                    cli[cli.Count - 1] = " and " + cli[cli.Count - 1];

                string liJoiner = ", ", cliJoiner = ", ";

                if (li.Count == 2)
                    liJoiner = "";

                if (cli.Count == 2)
                    cliJoiner = "";

                string gamepads = "gamepads";
                if (li.Count == 1) gamepads = "gamepad";

                ShowBalloonTip(
                    "No layouts have been applied to your gamepads",
                    "The layout you have selected does not include settings for the gamepads you have connected. " +
                        "Connect the " + gamepads + " assigned as " +
                        string.Join(liJoiner, li.ToArray()) + " or remap your current pads via their Device tabs.\n\n" +
                        "The following gamepad(s) are connected: " +
                            string.Join(cliJoiner, cli.ToArray()),
                    ToolTipIcon.Warning);
            }

            if (this.config.UpdatedForCompatibility) {
                if (!this.config.Builtin) {
                    string changes = " - " + string.Join("\n - ", this.config.CompatibilityUpdates.ToArray());
                    BalloonHandler = delegate()
                    {
                        MessageBox.Show("The following changes were made to your custom configuration: \n" + changes,
                            "Configuration update details", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    };
                    ShowBalloonTip(
                        "Layout has been updated for Pad Tie 0.1b and later",
                        "The layout file has been updated for use in the " +
                            "current version of Pad Tie. Click for details.", ToolTipIcon.Info);
                    //SaveConfig();
                }
            }
        }

        public void ShowBalloonTip(string title, string message, ToolTipIcon icon)
        {
            if (!globalConfig.Settings.ShowBalloonTips)
                return;
            notifyIcon.ShowBalloonTip(globalConfig.Settings.BalloonTipTimeout * 1000, title, message, icon);
        }

        void UpdateSettings()
        {
            this.padTie.GlobalDeadzone = globalConfig.Settings.DefaultDeadzone;
            this.padTie.AxisPoleSize = globalConfig.Settings.AxisPoleSize;
            this.padTie.DoubleTapTimeout = globalConfig.Settings.DoubleTapInterval;
            this.padTie.TapTimeout = globalConfig.Settings.TapInterval;
            this.padTie.HoldTimeout = globalConfig.Settings.HoldInterval;

            loadingSettings = true;
            showBalloonSetting.Checked = globalConfig.Settings.ShowBalloonTips;
            balloonTimeoutSetting.Value = globalConfig.Settings.BalloonTipTimeout;
            showCompatBalloonSetting.Checked = globalConfig.Settings.ShowCompatibilityNotices;
            noGamepadsConfiguredSetting.Checked = globalConfig.Settings.ShowNoGamepadConfigured;
            deadzoneSetting.Value = (decimal)(globalConfig.Settings.DefaultDeadzone * 100);
            axisPoleSizeSetting.Value = (decimal)(globalConfig.Settings.AxisPoleSize * 100);
            doubleTapIntervalSetting.Value = globalConfig.Settings.DoubleTapInterval;
            tapIntervalSetting.Value = globalConfig.Settings.TapInterval;
            holdIntervalSetting.Value = globalConfig.Settings.HoldInterval;
            loadingSettings = false;
        }

        bool loadingSettings = false;

        public class AxisConfig
        {
            public AxisConfig(AxisActionsConfig neg, AxisActionsConfig pos)
            {
                Negative = neg;
                Positive = pos;
            }

            public AxisActionsConfig Negative, Positive;
        }

        public void LoadAxisGesture(Controller cc, VirtualController.Axis axis, bool isPos, AxisActionsConfig cfg)
        {
            UpdateAlphaActionType(cfg.Link);
            UpdateAlphaActionType(cfg.Tap);
            UpdateAlphaActionType(cfg.DoubleTap);
            UpdateAlphaActionType(cfg.Hold);

            if ((cfg.Link.Type == "none" || string.IsNullOrEmpty(cfg.Link.Type)) && cfg.CompatType != "none" && !string.IsNullOrEmpty(cfg.CompatType)) {
                MapUtil.Map(this, cc.Virtual, new CapturedInput(axis, isPos, ButtonActions.Gesture.Link), CreateActionFromConfig(new InputActionConfig(cfg.CompatType, cfg.CompatParseable)));

                config.UpdatedForCompatibility = true;
                config.CompatibilityUpdates.Add("Updated axis '" + Util.GetAxisDisplayName(axis) + "' to use 0.1b format.");

                cfg.Link.Type = cfg.CompatType;
                cfg.Link.Parseable = cfg.CompatParseable;
            } else {
                MapUtil.Map(this, cc.Virtual, new CapturedInput(axis, isPos, ButtonActions.Gesture.Link), CreateActionFromConfig(cfg.Link));

                cfg.CompatType = cfg.Link.Type;
                cfg.CompatParseable = cfg.Link.Parseable;
            }

            MapUtil.Map(this, cc.Virtual, new CapturedInput(axis, isPos, ButtonActions.Gesture.Tap), CreateActionFromConfig(cfg.Tap));
            MapUtil.Map(this, cc.Virtual, new CapturedInput(axis, isPos, ButtonActions.Gesture.DoubleTap), CreateActionFromConfig(cfg.DoubleTap));
            MapUtil.Map(this, cc.Virtual, new CapturedInput(axis, isPos, ButtonActions.Gesture.Hold), CreateActionFromConfig(cfg.Hold));
        }

        public void LoadPadConfig(Controller cc, PadConfig pc)
        {
            cc.Config = pc;
            LoadButton(cc, VirtualController.Button.A, pc.A);
            LoadButton(cc, VirtualController.Button.B, pc.B);
            LoadButton(cc, VirtualController.Button.X, pc.X);
            LoadButton(cc, VirtualController.Button.Y, pc.Y);
            LoadButton(cc, VirtualController.Button.Br, pc.Br);
            LoadButton(cc, VirtualController.Button.Bl, pc.Bl);
            LoadButton(cc, VirtualController.Button.Tr, pc.Tr);
            LoadButton(cc, VirtualController.Button.Tl, pc.Tl);
            LoadButton(cc, VirtualController.Button.Start, pc.Start);
            LoadButton(cc, VirtualController.Button.System, pc.System);
            LoadButton(cc, VirtualController.Button.Back, pc.Back);
            LoadButton(cc, VirtualController.Button.LeftAnalog, pc.LeftAnalogButton);
            LoadButton(cc, VirtualController.Button.RightAnalog, pc.RightAnalogButton);

            LoadAxisGesture(cc, VirtualController.Axis.LeftX, false, pc.LeftAnalogLeft);
            LoadAxisGesture(cc, VirtualController.Axis.LeftX, true, pc.LeftAnalogRight);
            LoadAxisGesture(cc, VirtualController.Axis.LeftY, false, pc.LeftAnalogUp);
            LoadAxisGesture(cc, VirtualController.Axis.LeftY, true, pc.LeftAnalogDown);

            LoadAxisGesture(cc, VirtualController.Axis.RightX, false, pc.RightAnalogLeft);
            LoadAxisGesture(cc, VirtualController.Axis.RightX, true, pc.RightAnalogRight);
            LoadAxisGesture(cc, VirtualController.Axis.RightY, false, pc.RightAnalogUp);
            LoadAxisGesture(cc, VirtualController.Axis.RightY, true, pc.RightAnalogDown);

            LoadAxisGesture(cc, VirtualController.Axis.DigitalX, false, pc.DigitalLeft);
            LoadAxisGesture(cc, VirtualController.Axis.DigitalX, true, pc.DigitalRight);
            LoadAxisGesture(cc, VirtualController.Axis.DigitalY, false, pc.DigitalUp);
            LoadAxisGesture(cc, VirtualController.Axis.DigitalY, true, pc.DigitalDown);

            LoadAxisGesture(cc, VirtualController.Axis.Trigger, false, pc.TriggerLeft);
            LoadAxisGesture(cc, VirtualController.Axis.Trigger, true, pc.TriggerRight);

            cc.Virtual.LeftXAxis.Tag = new AxisConfig(pc.LeftAnalogLeft, pc.LeftAnalogRight);
            cc.Virtual.LeftYAxis.Tag = new AxisConfig(pc.LeftAnalogUp, pc.LeftAnalogDown);
            cc.Virtual.RightXAxis.Tag = new AxisConfig(pc.RightAnalogLeft, pc.RightAnalogRight);
            cc.Virtual.RightYAxis.Tag = new AxisConfig(pc.RightAnalogUp, pc.RightAnalogDown);
            cc.Virtual.DigitalXAxis.Tag = new AxisConfig(pc.DigitalLeft, pc.DigitalRight);
            cc.Virtual.DigitalYAxis.Tag = new AxisConfig(pc.DigitalUp, pc.DigitalDown);
            cc.Virtual.Trigger.Tag = new AxisConfig(pc.TriggerLeft, pc.TriggerRight);
        }

        public InputAction CreateActionFromConfig(InputActionConfig c)
        {
            if (c == null)
                return null;
            return CreateActionFromConfig(c.Type, c.Parseable);
        }

        /// <summary>
        /// Updates input action configs made by Pad Tie 0.1a to use the new type model
        /// </summary>
        /// <param name="c"></param>
        public void UpdateAlphaActionType(InputActionConfig c)
        {
            if (IsAlphaActionType(c.Type)) {
                var action = CreateActionFromConfig(c);
                c.Type = GetActionType(action);
                config.UpdatedForCompatibility = true;
                config.CompatibilityUpdates.Add("Updated action '" + action + "' to use 0.1b format");
            }

        }

        public void LoadButton(Controller cc, VirtualController.Button button, ButtonActionsConfig ac)
        {
            var vc = cc.Virtual;
            vc.GetButton(button).Tag = ac;

            UpdateAlphaActionType(ac.Link);
            UpdateAlphaActionType(ac.Tap);
            UpdateAlphaActionType(ac.DoubleTap);
            UpdateAlphaActionType(ac.Hold);

            if (ac.Link.Type != "none")
                MapButton(vc, button, ButtonActions.Gesture.Link, CreateActionFromConfig(ac.Link.Type, ac.Link.Parseable), false);
            if (ac.Tap.Type != "none")
                MapButton(vc, button, ButtonActions.Gesture.Tap, CreateActionFromConfig(ac.Tap.Type, ac.Tap.Parseable), false);
            if (ac.DoubleTap.Type != "none")
                MapButton(vc, button, ButtonActions.Gesture.DoubleTap, CreateActionFromConfig(ac.DoubleTap.Type, ac.DoubleTap.Parseable), false);
            if (ac.Hold.Type != "none")
                MapButton(vc, button, ButtonActions.Gesture.Hold, CreateActionFromConfig(ac.Hold.Type, ac.Hold.Parseable), false);
        }

        public InputAction CreateActionFromConfig(string type, string parseable)
        {
            if (type == null)
                return null;

            switch (type) {
                case "key":
                    return KeyAction.Parse(padTie, parseable);
                case "pointer":
                    return MousePointerAction.Parse(padTie, parseable);
                case "button":
                    return MouseButtonAction.Parse(padTie, parseable);
                case "wheel":
                    return MouseWheelAction.Parse(padTie, parseable);
                case "command":
                    return RunCommandAction.Parse(padTie, parseable);
                case "open-file":
                    return OpenFileAction.Parse(padTie, parseable);
                case "switch-config":
                    return SwitchConfigAction.Parse(padTie, parseable);
                default:
                    // The *new* way of doing things: load the action via reflection by it's AQN

                    Type t = Type.GetType(type, false);

                    if (t == null)
                        t = typeof(PadTieForm).Assembly.GetType(type, false);

                    if (t == null)
                        t = typeof(InputCore).Assembly.GetType(type, false);

                    if (t != null && t.IsSubclassOf(typeof(InputAction))) {
                        var m = t.GetMethod("Parse", new[] { typeof(InputCore), typeof(string) }, null);

                        if (m != null) {
                            var ret = m.Invoke(null, new object[] { padTie, parseable });

                            if (ret != null && ret is InputAction) {
                                return ret as InputAction;
                            }
                        }
                    }
                    break;
            }

            return null;
        }

        public void MapButtonToKey(VirtualController vc, VirtualController.Button button, ButtonActions.Gesture gesture,
            User32InputHook.VK key, User32InputHook.VK[] mods)
        {
            Controller c = null;

            foreach (Controller pc in controllers) {
                if (pc.Virtual == vc) {
                    c = pc;
                    break;
                }
            }

            if (c == null) return;

            var action = new KeyAction(key, mods);
            var gestureID = Util.GetButtonGestureID(gesture);

            c.SettingsUI.SetMapping(string.Format("{0}/{1}", button.ToString(), gestureID), Util.GetActionName(action), action);
            vc.GetButton(button).Map(gesture, action);
        }

        public void MapButton(VirtualController vc, VirtualController.Button button, ButtonActions.Gesture gesture, InputAction action)
        {
            MapButton(vc, button, gesture, action, true);
        }

        public bool IsAlphaActionType(string type)
        {
            if (type == "key" || type == "pointer" || type == "button" || type == "wheel" ||
                type == "command" || type == "open-file" || type == "switch-config")
                return true;
            return false;
        }

        public string GetActionType(InputAction action)
        {
            if (action == null)
                return "none";

            var type = action.GetType();
            var an = type.Assembly.GetName();
            var anPadTie = typeof(InputCore).Assembly.GetName();
            var anPadTieApp = typeof(PadTieForm).Assembly.GetName();

            if (an.Name == anPadTie.Name || an.Name == anPadTieApp.Name)
                return type.FullName;
            else
                return action.GetType().AssemblyQualifiedName;

            /*
            if (action is KeyAction)
                return "key";
            else if (action is MousePointerAction)
                return "pointer";
            else if (action is MouseButtonAction)
                return "button";
            else if (action is MouseWheelAction)
                return "wheel";
            else if (action is RunCommandAction)
                return "command";
            else if (action is OpenFileAction)
                return "open-file";
            else if (action is SwitchConfigAction)
                return "switch-config";
            return null; 
            */
        }

        public Controller GetController(VirtualController vc)
        {
            Controller cc = null;

            foreach (Controller pc in controllers) {
                if (pc.Virtual == vc) {
                    cc = pc;
                    break;
                }
            }

            return cc;
        }

        public Controller GetController(int padNumber)
        {
            foreach (var cc in controllers) {
                if (cc.Index == padNumber)
                    return cc;
            }
            return null;
        }

        public Controller GetController(InputController ic)
        {
            Controller cc = null;

            foreach (Controller pc in controllers) {
                if (pc.Device == ic) {
                    cc = pc;
                    break;
                }
            }

            return cc;
        }

        public void MapButton(VirtualController vc, VirtualController.Button button, ButtonActions.Gesture gesture, InputAction action, bool save)
        {
            if (action != null) action.SlotDescription = new CapturedInput(button, gesture);

            Controller cc = GetController(vc);
            if (cc == null) return;

            var gestureID = Util.GetButtonGestureID(gesture);
            cc.SettingsUI.SetMapping(string.Format("{0}/{1}", button.ToString(), gestureID), Util.GetActionName(action), action);
            var ba = vc.GetButton(button);
            ba.Map(gesture, action);

            if (save) {
                var config = ba.Tag as ButtonActionsConfig;
                var inputActionConfig = new InputActionConfig(GetActionType(action), (action == null ? "" : action.ToParseable()));
                switch (gesture) {
                    case ButtonActions.Gesture.Link:
                        config.Link = inputActionConfig;
                        break;
                    case ButtonActions.Gesture.Tap:
                        config.Tap = inputActionConfig;
                        break;
                    case ButtonActions.Gesture.DoubleTap:
                        config.DoubleTap = inputActionConfig;
                        break;
                    case ButtonActions.Gesture.Hold:
                        config.Hold = inputActionConfig;
                        break;
                }

                SaveConfig();
            }
        }

        public void MapAxisGesture(VirtualController vc, VirtualController.Axis axis, AxisActions.Gestures gesture,
            ButtonActions.Gesture poleGesture, InputAction action)
        {
            MapAxisGesture(vc, axis, gesture, poleGesture, action, true);
        }

        public void MapAxisGesture(VirtualController vc, VirtualController.Axis axis, AxisActions.Gestures gesture,
            ButtonActions.Gesture poleGesture, InputAction action, bool save)
        {
            var slot = new CapturedInput(axis, gesture == AxisActions.Gestures.Positive, poleGesture);

            if (action != null) {
                // Attempt to unset the action's previous slot
                if (action.SlotDescription != null && slot != action.SlotDescription)
                    MapUtil.Map(this, vc, action.SlotDescription, null);
                action.SlotDescription = slot;
            }

            Controller cc = GetController(vc);
            if (cc == null) return;

            var gestureID = Util.GetAxisGestureID(axis, gesture, poleGesture);
            cc.SettingsUI.SetMapping(gestureID, Util.GetActionName(action), action);
            var aa = vc.GetAxis(axis);

            if (poleGesture == ButtonActions.Gesture.Link)
                aa.GetPole(gesture).Link = action;
            else if (poleGesture == ButtonActions.Gesture.Tap)
                aa.GetPole(gesture).Tap = action;
            else if (poleGesture == ButtonActions.Gesture.DoubleTap)
                aa.GetPole(gesture).DoubleTap = action;
            else if (poleGesture == ButtonActions.Gesture.Hold)
                aa.GetPole(gesture).Hold = action;

            if (save) {
                var config = aa.Tag as AxisConfig;
                InputActionConfig inputActionConfig;

                if (config != null) {
                    if (gesture == AxisActions.Gestures.Positive) {
                        inputActionConfig = config.Positive.GetGesture(poleGesture);
                        if (poleGesture == ButtonActions.Gesture.Link) {
                            // Bugfix for 0.1b2: Unsetting or moving actions from Link gesture of
                            // axes does not persist. Pad Tie was loading the stale compatibility 
                            // action info since the <link> gesture was 'none'
                            config.Positive.CompatType = GetActionType(action);
                            config.Positive.CompatParseable = (action == null ? "" : action.ToParseable());
                        }
                    } else {
                        inputActionConfig = config.Negative.GetGesture(poleGesture);

                        if (poleGesture == ButtonActions.Gesture.Link) {
                            // Bugfix for 0.1b2: Unsetting or moving actions from Link gesture of
                            // axes does not persist. Pad Tie was loading the stale compatibility 
                            // action info since the <link> gesture was 'none'
                            config.Negative.CompatType = GetActionType(action);
                            config.Negative.CompatParseable = (action == null ? "" : action.ToParseable());
                        }
                    }

                    inputActionConfig.Type = GetActionType(action);
                    inputActionConfig.Parseable = (action == null ? "" : action.ToParseable());

                    SaveConfig();
                }
            }
        }

        private void PadTieForm_Load(object sender, EventArgs e)
        {
            Init();
            padLegend.Init(this);

            LoadConfig();
            RefreshConfigList();

            Fontify.Go(this);

            if (globalConfig.Settings.RememberWindowSize && globalConfig.Settings.WindowWidth > 0) {
                this.SetBounds(globalConfig.Settings.WindowX, globalConfig.Settings.WindowY, globalConfig.Settings.WindowWidth,
                    globalConfig.Settings.WindowHeight);

                if (globalConfig.Settings.WindowMaximized)
                    this.WindowState = FormWindowState.Maximized;
            }

            Application.DoEvents();
            this.Show();

        }

        internal void Init()
        {
            padTie = new InputCore(this.Handle);
            padTie.DIMainWindow = this.Handle;
            padTie.Tag = this;
        }

        private void iterationTimer_Tick(object sender, EventArgs e)
        {
            if (padTie == null) return;
            padTie.RunIteration();

            if (lastDeviceScan + deviceScanInterval < DateTime.Now) {
                if (padTie.ScanForControllers()) {
                    Console.WriteLine("PadTie library reported new devices!");
                    ConfigureNewDevices();
                    ReloadConfig();
                }
                lastDeviceScan = DateTime.Now;
            }

            List<Controller> removed = new List<Controller>();

            foreach (var cc in controllers) {
                if (cc.Device.Removed) {
                    padTabs.TabPages.Remove(cc.Tab);
                    removed.Add(cc);
                }

                if (cc.IsGeneric) {
                    cc.IsGeneric = false;

                    var wiz = new MappingWizard();
                    wiz.Controller = cc;
                    wiz.MainForm = this;
                    wiz.ShowDialog(this);
                }
            }

            foreach (var cc in removed) {
                controllers.Remove(cc);
                padTie.Controllers.Remove(cc.Device);
            }

            freePad = 0;
            foreach (var cc in controllers)
                if (freePad <= cc.Index) freePad = cc.Index + 1;

        }

        DateTime lastDeviceScan = DateTime.Now;
        TimeSpan deviceScanInterval = new TimeSpan(0, 0, 5);

        private void cloneBtn_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.AddExtension = true;
            sfd.SupportMultiDottedExtensions = true;
            sfd.DefaultExt = ".config.xml";
            sfd.Filter = "Pad Tie configuration file (*.config.xml)|*.config.xml|All files (*.*)|*";
            sfd.RestoreDirectory = true;
            sfd.InitialDirectory = UserStorePath;
            var result = sfd.ShowDialog(this);
            if (result == System.Windows.Forms.DialogResult.OK) {
                config.Save(sfd.FileName);
                RefreshConfigList();
            }
        }

        public void ChangeConfig(ConfigItem item)
        {
            if (refreshingConfigs) return;

            if (!File.Exists(item.FileName)) {
                MessageBox.Show("Could not locate configuration, it may have been deleted.");
                RefreshConfigList();
                return;
            }

            foreach (var cc in controllers)
                cc.Reset();
            var cfg = Config.Load(item.FileName);
            cfg.Builtin = item.IsBuiltIn;
            LoadConfig(cfg);
        }

        public void UpdateLegend()
        {
            Dictionary<string, string> layout = new Dictionary<string, string>();
            Controller cc = GetController(padLegend.Pad);
            bool editable = false;

            if (cc == null) return;

            if (padLegend.SelectedMode == LegendMode.Overview) {
                editable = true;

                if (config != null) {
                    if (config.Pads.Count <= cc.Index - 1) {
                        layout["LeftY/Neg"] = "No layout available for pad #" + cc.Index;
                    } else {
                        var pc = cc.Config;

                        foreach (var btn in VirtualController.ButtonList) {
                            var bc = pc.GetButton(btn);
                            if (bc == null) continue;

                            if (!string.IsNullOrEmpty(bc.Overview))
                                layout[btn.ToString()] = bc.Overview;
                        }

                        foreach (var axis in VirtualController.AxisList) {
                            var pos = pc.GetAxisGesture(axis, true);
                            var neg = pc.GetAxisGesture(axis, false);

                            if (pos != null && !string.IsNullOrEmpty(pos.Overview))
                                layout[axis.ToString() + "/Pos"] = pos.Overview;
                            if (neg != null && !string.IsNullOrEmpty(neg.Overview))
                                layout[axis.ToString() + "/Neg"] = neg.Overview;
                        }
                    }
                }
            } else {
                ButtonActions.Gesture gesture = ButtonActions.Gesture.Link;

                if (padLegend.SelectedMode == LegendMode.Link)
                    gesture = ButtonActions.Gesture.Link;
                else if (padLegend.SelectedMode == LegendMode.Tap)
                    gesture = ButtonActions.Gesture.Tap;
                else if (padLegend.SelectedMode == LegendMode.DoubleTap)
                    gesture = ButtonActions.Gesture.DoubleTap;
                else if (padLegend.SelectedMode == LegendMode.Hold)
                    gesture = ButtonActions.Gesture.Hold;

                foreach (var btn in VirtualController.ButtonList) {
                    var ba = cc.Virtual.GetButton(btn);

                    if (ba == null) continue;

                    var action = ba.GetGesture(gesture);

                    if (action == null)
                        layout[btn.ToString()] = "Unassigned";
                    else
                        layout[btn.ToString()] = action.ToString();
                }

                foreach (var axis in VirtualController.AxisList) {
                    var ccAxis = cc.Virtual.GetAxis(axis);

                    if (ccAxis == null) continue;

                    var pos = ccAxis.Positive.GetGesture(gesture);
                    var neg = ccAxis.Negative.GetGesture(gesture);

                    layout[axis.ToString() + "/Pos"] = (pos != null ? pos.ToString() : "Unassigned");
                    layout[axis.ToString() + "/Neg"] = (neg != null ? neg.ToString() : "Unassigned");
                }
            }

            padLegend.ApplyLayout(layout, editable);
        }

        public string UserStorePath { get; private set; }
        public string AppPath { get; private set; }

        public string BuiltinProfilesPath { get; private set; }
        public string BuiltinGamepadsPath { get; private set; }
        public string UserProfilesPath { get; private set; }
        public string UserGamepadsPath { get; private set; }

        public void SaveConfig()
        {
            if (!Directory.Exists(UserStorePath))
                Directory.CreateDirectory(UserStorePath);

            // Pad Tie 0.1b2: First try to save in whatever location we loaded from. If this fails, look for
            // unauthorized access and the builtin flag then do the customary builtin layout -> custom layout file copy.
            // Bonus points for real exception protection.

            try {
                config.Save();
            } catch (UnauthorizedAccessException) {
                if (config.Builtin) {
                    string userConfig = Path.Combine(UserStorePath, Path.GetFileName(config.FileName));
                    if (File.Exists(userConfig)) {
                        var r = MessageBox.Show("A custom layout named '" + Path.GetFileName(config.FileName) + "' already exists. Overwrite it?",
                            "Custom layout exists", MessageBoxButtons.YesNo);

                        if (r != DialogResult.Yes)
                            return;

                        File.Delete(userConfig);
                    }

                    File.Copy(config.FileName, userConfig);
                    try {
                        config.Save(userConfig);
                    } catch (Exception e) {
                        MessageBox.Show("An error occurred while trying to save your new custom layout: " + e.Message,
                            "Could not save new custom layout");
                    }

                    Thread.Sleep(400);
                    Application.DoEvents();
                    RefreshConfigList(true);
                }
            } catch (Exception e) {
                MessageBox.Show("An error occurred while trying to save your modifications: " + e.Message, "Could not save layout");
            }
        }

        private void tapIntervalSetting_ValueChanged(object sender, EventArgs e)
        {
            if (!loadingSettings) {
                padTie.TapTimeout = globalConfig.Settings.TapInterval = (short)tapIntervalSetting.Value;
                SaveConfig();
            }
        }

        private void doubleTapIntervalSetting_ValueChanged(object sender, EventArgs e)
        {
            if (!loadingSettings) {
                padTie.DoubleTapTimeout = globalConfig.Settings.DoubleTapInterval = (short)doubleTapIntervalSetting.Value;
                SaveConfig();
            }
        }

        private void holdIntervalSetting_ValueChanged(object sender, EventArgs e)
        {
            if (!loadingSettings) {
                padTie.HoldTimeout = globalConfig.Settings.HoldInterval = (short)holdIntervalSetting.Value;
                SaveConfig();
            }
        }

        private void deadzoneSetting_ValueChanged(object sender, EventArgs e)
        {
            if (!loadingSettings) {
                padTie.GlobalDeadzone = globalConfig.Settings.DefaultDeadzone = ((double)deadzoneSetting.Value / 100);
                SaveConfig();
            }
        }

        private void axisPoleSizeSetting_ValueChanged(object sender, EventArgs e)
        {
            if (!loadingSettings) {
                padTie.AxisPoleSize = globalConfig.Settings.AxisPoleSize = ((double)axisPoleSizeSetting.Value / 100);
                SaveConfig();
            }
        }

        GlobalConfig globalConfig { get; set; }

        public GlobalConfig GlobalConfig { get { return globalConfig; } }

        private void PadTieForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                this.Hide();
            } else {
                // do shutdown stuff i guess... later all!
                notifyIcon.Visible = false;
            }
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.Visible) Show();
            this.Activate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (!this.Visible) Show();
            this.Activate();
        }

        private void refreshConfigListTimer_Tick(object sender, EventArgs e)
        {
            RefreshConfigList();
        }

        internal Block BalloonHandler;

        private void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            if (BalloonHandler != null) BalloonHandler();
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void configBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigItem item = configBox.SelectedItem as ConfigItem;
            if (item == null) return;
            ChangeConfig(item);
        }

        bool updatingMenu = false;

        private void layoutToolBtn_MouseDown(object sender, MouseEventArgs e)
        {
            updatingMenu = true;
            try {
                bool b = (globalConfig.Settings.DefaultConfigFile == config.FileName);
                defaultMenuItem.Checked = b;
                defaultMenuItem.Enabled = !b;
            } finally {
                updatingMenu = false;
            }
        }

        private void defaultMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (updatingMenu || !defaultMenuItem.Checked) return;
            globalConfig.Settings.DefaultConfigFile = config.FileName;
            globalConfig.Save();
            defaultMenuItem.Enabled = false;
        }

        private void showBalloonSetting_CheckedChanged(object sender, EventArgs e)
        {
            globalConfig.Settings.ShowBalloonTips = showBalloonSetting.Checked;
            globalConfig.Save();
        }

        private void showCompatBalloonSetting_CheckedChanged(object sender, EventArgs e)
        {
            globalConfig.Settings.ShowCompatibilityNotices = showCompatBalloonSetting.Checked;
            globalConfig.Save();
        }

        private void noGamepadsConfiguredSetting_CheckedChanged(object sender, EventArgs e)
        {
            globalConfig.Settings.ShowNoGamepadConfigured = noGamepadsConfiguredSetting.Checked;
            globalConfig.Save();
        }

        private void balloonTimeoutSetting_ValueChanged(object sender, EventArgs e)
        {
            globalConfig.Settings.BalloonTipTimeout = (int)balloonTimeoutSetting.Value;
            globalConfig.Save();
        }

        bool layoutNameTemplate = false;

        private void layoutName_Enter(object sender, EventArgs e)
        {
            layoutName.BorderStyle = BorderStyle.Fixed3D;
            layoutName.BackColor = Color.FromKnownColor(KnownColor.Window);

            if (layoutNameTemplate) {
                layoutName.Text = "";
                layoutName.Font = new Font(layoutName.Font, FontStyle.Regular);
                layoutNameTemplate = false;
            }
        }

        private void layoutName_Leave(object sender, EventArgs e)
        {
            layoutName.BorderStyle = BorderStyle.None;
            layoutName.BackColor = Color.FromKnownColor(KnownColor.Control);

            if (config.Label != layoutName.Text) {
                config.Label = layoutName.Text;
                SaveConfig();
            }

            if (layoutName.Text == "") {
                layoutName.Text = "Click to set title for layout";
                layoutName.Font = new Font(layoutName.Font, FontStyle.Italic);
                layoutNameTemplate = true;
            }
        }

        private void infobox_Enter(object sender, EventArgs e)
        {
            infobox.BorderStyle = BorderStyle.Fixed3D;
            infobox.BackColor = Color.FromKnownColor(KnownColor.Window);

            if (infoTemplate) {
                infobox.Text = "";
                infobox.Font = new Font(infobox.Font, FontStyle.Regular);
                infoTemplate = false;
            }
        }

        private void infobox_Leave(object sender, EventArgs e)
        {
            infobox.BorderStyle = BorderStyle.None;
            infobox.BackColor = Color.FromKnownColor(KnownColor.Control);

            string pinfo = infobox.Text.Replace("\r", "").Replace("\n", "\\n");
            if (config.Info != pinfo) {
                config.Info = pinfo;
                SaveConfig();
            }
        }

        bool infoTemplate = false;

        private void PadTieForm_ResizeEnd(object sender, EventArgs e)
        {
            if (globalConfig != null && globalConfig.Settings.RememberWindowSize) {
                Console.WriteLine("Changed window size to {0}x{1}", Width, Height);
                globalConfig.Settings.WindowWidth = Width;
                globalConfig.Settings.WindowHeight = Height;
                globalConfig.Save();
            }
        }

        System.Windows.Forms.Timer moveTimeout = null;

        private void PadTieForm_Move(object sender, EventArgs e)
        {
            if (globalConfig != null && globalConfig.Settings.RememberWindowSize) {
                // Disabled since ResizeEnd seems to be called after a move operation finishes as well

                /*
                if (moveTimeout == null) {
					
                    moveTimeout = new System.Windows.Forms.Timer();
                    moveTimeout.Interval = 4000;
                    moveTimeout.Tick += delegate(object sender2, EventArgs e2) {
                        Console.WriteLine("Saving global config after window move timeout elapsed");
                        globalConfig.Save();
                        moveTimeout.Stop();
                    };
                }
                moveTimeout.Stop();
                moveTimeout.Start();
                */

                globalConfig.Settings.WindowX = Left;
                globalConfig.Settings.WindowY = Top;
            }
        }

        FormWindowState oldState = FormWindowState.Normal;

        private void PadTieForm_Resize(object sender, EventArgs e)
        {
            if (globalConfig != null && globalConfig.Settings.RememberWindowSize) {
                if (oldState != WindowState) {
                    if (WindowState == FormWindowState.Maximized) {
                        globalConfig.Settings.WindowMaximized = true;
                        globalConfig.Save();
                    } else if (WindowState == FormWindowState.Normal) {
                        globalConfig.Settings.WindowMaximized = false;
                        globalConfig.Save();
                    } else if (WindowState == FormWindowState.Minimized) {
                        Console.WriteLine("Form minimized");
                    }

                    oldState = WindowState;
                }
            }
        }

        private void padLegend_PadChanged(object sender, EventArgs e)
        {
            UpdateLegend();
        }

        private void padLegend_SelectedModeChanged(object sender, EventArgs e)
        {
            UpdateLegend();
        }

        private void padLegend_LayoutChanged(object sender, EventArgs e)
        {
            var cc = GetController(padLegend.Pad);

            if (cc == null) return;
            var layout = padLegend.GetLayout();

            foreach (var btn in VirtualController.ButtonList) {
                var ba = cc.Config.GetButton(btn);
                if (ba == null)
                    continue;
                if (layout.ContainsKey(btn.ToString()))
                    ba.Overview = layout[btn.ToString()];
            }

            foreach (var axis in VirtualController.AxisList) {
                var pos = cc.Config.GetAxisGesture(axis, true);
                var neg = cc.Config.GetAxisGesture(axis, false);
                var posID = axis.ToString() + "/Pos";
                var negID = axis.ToString() + "/Neg";

                if (pos != null && layout.ContainsKey(posID))
                    pos.Overview = layout[posID];
                if (neg != null && layout.ContainsKey(negID))
                    neg.Overview = layout[negID];
            }

            SaveConfig();
        }
    }

    public delegate void Block();

    public class Util
    {
        public static EnumT ParseEnum<EnumT>(string value)
        {
            return (EnumT)Enum.Parse(typeof(EnumT), value);
        }

        public static VirtualController.Axis AxisFromGesture(AxisGesture gesture)
        {
            switch (gesture) {
                case AxisGesture.LeftXNeg:
                case AxisGesture.LeftXPos:
                    return VirtualController.Axis.LeftX;
                case AxisGesture.RightXNeg:
                case AxisGesture.RightXPos:
                    return VirtualController.Axis.RightX;
                case AxisGesture.LeftYNeg:
                case AxisGesture.LeftYPos:
                    return VirtualController.Axis.LeftY;
                case AxisGesture.RightYPos:
                case AxisGesture.RightYNeg:
                    return VirtualController.Axis.RightY;
                case AxisGesture.DigitalXPos:
                case AxisGesture.DigitalXNeg:
                    return VirtualController.Axis.DigitalX;
                case AxisGesture.DigitalYPos:
                case AxisGesture.DigitalYNeg:
                    return VirtualController.Axis.DigitalY;
                case AxisGesture.TriggerNeg:
                case AxisGesture.TriggerPos:
                    return VirtualController.Axis.Trigger;
            }

            return VirtualController.Axis.LeftX;
        }

        public static bool PoleFromGesture(AxisGesture gesture)
        {
            switch (gesture) {
                case AxisGesture.LeftXNeg:
                case AxisGesture.RightXNeg:
                case AxisGesture.LeftYNeg:
                case AxisGesture.RightYNeg:
                case AxisGesture.DigitalXNeg:
                case AxisGesture.DigitalYNeg:
                case AxisGesture.TriggerNeg:
                    return false;
                case AxisGesture.LeftYPos:
                case AxisGesture.RightXPos:
                case AxisGesture.LeftXPos:
                case AxisGesture.RightYPos:
                case AxisGesture.DigitalXPos:
                case AxisGesture.DigitalYPos:
                case AxisGesture.TriggerPos:
                    return true;
            }

            return false;
        }

        public static VirtualController.Axis StickFromGesture(AxisGesture ag)
        {
            var axis = VirtualController.Axis.LeftX;

            switch (ag) {
                case AxisGesture.LeftXNeg:
                case AxisGesture.LeftXPos:
                case AxisGesture.LeftYNeg:
                case AxisGesture.LeftYPos:
                    axis = VirtualController.Axis.LeftX;
                    break;
                case AxisGesture.RightXNeg:
                case AxisGesture.RightXPos:
                case AxisGesture.RightYNeg:
                case AxisGesture.RightYPos:
                    axis = VirtualController.Axis.RightX;
                    break;
                case AxisGesture.DigitalXNeg:
                case AxisGesture.DigitalXPos:
                case AxisGesture.DigitalYNeg:
                case AxisGesture.DigitalYPos:
                    axis = VirtualController.Axis.DigitalX;
                    break;
                case AxisGesture.TriggerNeg:
                case AxisGesture.TriggerPos:
                    axis = VirtualController.Axis.Trigger;
                    break;
            }

            return axis;
        }

        public static string GetButtonGestureID(ButtonActions.Gesture gesture)
        {
            var gestureID = "link";

            if (gesture == ButtonActions.Gesture.Tap) gestureID = "tap";
            if (gesture == ButtonActions.Gesture.DoubleTap) gestureID = "dtap";
            if (gesture == ButtonActions.Gesture.Hold) gestureID = "hold";

            return gestureID;
        }

        public static string GetActionName(InputAction action)
        {
            if (action == null) return "Unassigned";
            return action.ToString();
        }

        public static string GetButtonDisplayName(VirtualController.Button button)
        {
            string name = button.ToString();

            if (button == VirtualController.Button.Bl) name = "Left Bumper";
            if (button == VirtualController.Button.Br) name = "Right Bumper";
            if (button == VirtualController.Button.Tl) name = "Left Trigger";
            if (button == VirtualController.Button.Tr) name = "Right Trigger";

            return name;
        }

        public static string GetAxisDisplayName(VirtualController.Axis axis)
        {
            string name = axis.ToString();

            if (axis == VirtualController.Axis.LeftX)
                name = "Left Analog X";
            else if (axis == VirtualController.Axis.LeftY)
                name = "Left Analog Y";
            else if (axis == VirtualController.Axis.RightX)
                name = "Right Analog X";
            else if (axis == VirtualController.Axis.RightY)
                name = "Right Analog Y";
            else if (axis == VirtualController.Axis.DigitalX)
                name = "Digital X";
            else if (axis == VirtualController.Axis.DigitalY)
                name = "Digital Y";
            else if (axis == VirtualController.Axis.Trigger)
                name = "Trigger";

            return name;
        }

        public static string GetStickDisplayName(VirtualController.Axis axis)
        {
            string name = axis.ToString();

            if (axis == VirtualController.Axis.LeftX || axis == VirtualController.Axis.LeftY)
                name = "Left Analog";
            else if (axis == VirtualController.Axis.RightX || axis == VirtualController.Axis.RightY)
                name = "Right Analog";
            else if (axis == VirtualController.Axis.DigitalX || axis == VirtualController.Axis.DigitalY)
                name = "Digital";
            else if (axis == VirtualController.Axis.Trigger)
                name = "Trigger";

            return name;
        }

        public static string GetButtonGestureName(ButtonActions.Gesture gesture)
        {
            string name = gesture.ToString();

            if (gesture == ButtonActions.Gesture.DoubleTap)
                name = "Double Tap";

            return name;
        }

        public static string GetAxisGestureName(VirtualController.Axis axis, bool pos)
        {
            if (axis == VirtualController.Axis.Trigger)
                pos = !pos;

            if (axis == VirtualController.Axis.RightX || axis == VirtualController.Axis.LeftX ||
                axis == VirtualController.Axis.DigitalX || axis == VirtualController.Axis.Trigger) {
                if (pos) return "Right";
                else return "Left";
            } else {
                if (pos) return "Down";
                else return "Up";
            }
        }

        public static string GetAxisGestureID(VirtualController.Axis axis, AxisActions.Gestures gesture, ButtonActions.Gesture poleGesture)
        {
            return GetAxisGestureID(axis, gesture) + "/" + GetButtonGestureID(poleGesture);
        }

        public static string GetAxisGestureID(VirtualController.Axis axis, AxisActions.Gestures gesture)
        {
            string id = "";

            if (axis == VirtualController.Axis.LeftX || axis == VirtualController.Axis.LeftY)
                id = "left-analog/";
            else if (axis == VirtualController.Axis.RightX || axis == VirtualController.Axis.RightY)
                id = "right-analog/";
            else if (axis == VirtualController.Axis.DigitalX || axis == VirtualController.Axis.DigitalY)
                id = "digital/";
            else if (axis == VirtualController.Axis.Trigger)
                id = "trigger/";

            if (axis == VirtualController.Axis.LeftX || axis == VirtualController.Axis.RightX ||
                axis == VirtualController.Axis.DigitalX || axis == VirtualController.Axis.Trigger)
                id += "x/";
            else
                id += "y/";

            if (gesture == AxisActions.Gestures.Positive)
                return id + "pos";
            else if (gesture == AxisActions.Gestures.Negative)
                return id + "neg";
            else if (gesture == AxisActions.Gestures.Analog)
                return id + "analog";

            return id + "unknown";
        }

        internal static string GetKeyName(Keys key)
        {
            string name = key.ToString();

            if (key == Keys.ControlKey)
                name = "Control";
            else if (key == Keys.ShiftKey)
                name = "Shift";
            else if (key == Keys.PageUp)
                name = "Page Up";
            else if (key == Keys.PageDown)
                name = "Page Down";
            else if (key == Keys.Back)
                name = "Backspace";
            else if (name.Length == 2 && name[0] == 'D')
                name = name[1].ToString();

            return name;
        }
    }

    public class Controller
    {
        public Controller(InputCore core, InputController ic, int index)
        {
            if (core == null)
                throw new ArgumentNullException("core");
            if (ic == null)
                throw new ArgumentNullException("ic");

            Core = core;
            Virtual = new VirtualController(core);
            Device = ic;
            Index = index;
        }

        public int Index { get; set; }
        public InputCore Core { get; set; }
        public VirtualController Virtual;
        public InputController Device;
        public PadSettingsControl SettingsUI;
        public PadConfig Config;
        public DeviceConfig DeviceConfig;

        public void Reset()
        {
            Virtual.Reset();
            SettingsUI.ResetMappings();
        }

        public TabPage Tab { get; set; }

        public bool IsGeneric { get; set; }
    }
}
