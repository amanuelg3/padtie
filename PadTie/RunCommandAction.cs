using System;
using System.Collections.Generic;

using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;

namespace PadTie {
	public class OpenFileAction : InputAction {
		public OpenFileAction(InputCore core, string file, bool onRelease, bool showErrors)
		{
			Core = core;
			FileName = file;
			OpenOnRelease = onRelease;
			ErrorDialog = showErrors;
		}

		public InputCore Core { get; set; }
		public string FileName;
		public bool OpenOnRelease = false;
		public bool ErrorDialog = false;

		public void Open()
		{
			var psi = new ProcessStartInfo(FileName, "");
			psi.UseShellExecute = true;
			psi.ErrorDialog = ErrorDialog;
			Process.Start(psi);
		}

		public static OpenFileAction Parse(InputCore core, string parseable)
		{
			string[] props = parseable.Split(',');
			
			if (props.Length < 3)
				throw new FormatException("Invalid property data for action 'Open File'");

			var a = new OpenFileAction(core, props[0], bool.Parse(props[1]), bool.Parse(props[2]));
			return a;
		}

		public override string ToParseable()
		{
			return string.Join(",", new string[] { FileName, OpenOnRelease + "", ErrorDialog + "" });
		}

		public override string ToString()
		{
			return string.Format("Open file '{0}'", Path.GetFileName(FileName));
		}

		public override void Press()
		{
			if (!OpenOnRelease)
				Open();
		}

		public override void Release()
		{
			if (OpenOnRelease)
				Open();
		}

	}

	public class RunCommandAction : InputAction {
		public RunCommandAction(InputCore core, string cmd, string args, bool onRelease)
		{
			Core = core;
			RunOnRelease = onRelease;
			Command = cmd;
			Arguments = args;
		}

		public InputCore Core { get; set; }
		public string Command { get; set; }
		public string Arguments { get; set; }
		public string WorkingDirectory { get; set; }
		public bool ErrorDialog { get; set; }
		public ProcessWindowStyle WindowStyle { get; set; }
		public bool RunOnRelease { get; set; }

		public void Run()
		{
			ProcessStartInfo psi = new ProcessStartInfo(Command, Arguments);

			psi.UseShellExecute = true;
			psi.WindowStyle = WindowStyle;
			psi.ErrorDialog = ErrorDialog;
			if (!string.IsNullOrEmpty(WorkingDirectory))
				psi.WorkingDirectory = WorkingDirectory;

			Process.Start(psi);
		}

		public override void Press()
		{
			if (!RunOnRelease)
				Run();
		}

		public override void Release()
		{
			if (RunOnRelease)
				Run();
		}

		public static RunCommandAction Parse(InputCore core, string parseable)
		{

			// Command,Arguments,WorkingDirectory,ErrorDialog,WindowStyle,RunOnRelease
			string[] props = parseable.Split(',');

			if (props.Length < 6)
				throw new FormatException("Invalid property data for action 'Run Command'");

			string cmd = props[0].Replace("%comma;", ",");
			string args = props[1].Replace("%comma;", ",");
			string wd = props[2].Replace("%comma;", ",");
			bool ed = bool.Parse(props[3]);
			ProcessWindowStyle pws = (ProcessWindowStyle)Enum.Parse(typeof(ProcessWindowStyle), props[4]);
			bool runOnRelease = bool.Parse(props[5]);

			var a = new RunCommandAction(core, cmd, args, runOnRelease);
			a.WorkingDirectory = wd;
			a.ErrorDialog = ed;
			a.WindowStyle = pws;
			a.RunOnRelease = runOnRelease;
			return a;
		}

		public override string ToParseable()
		{
			return string.Format("{0},{1},{2},{3},{4},{5}", 
				Command.Replace(",", "%comma;"), 
				Arguments.Replace(",", "%comma;"), 
				WorkingDirectory.Replace(",", "%comma;"), 
				ErrorDialog, WindowStyle, RunOnRelease);
		}

		public override string ToString()
		{
			string args = Arguments;

			if (args.Length > 50)
				args = args.Substring(0, 50) + "...";

			return string.Format("Run command '{0}' with arguments '{1}'",
				Path.GetFileName(Command), args);
		}
	}
}
