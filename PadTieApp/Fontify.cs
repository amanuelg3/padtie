using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace PadTieApp {
	interface IFontifiable {
		bool Fontified { get; set; }
	}

	class Fontify {
		static Font defaultFont = null;
		static Font defaultLightFont = null;

		static FontFamily TryCreateFamily (string name)
		{
			try {
				return new FontFamily (name);
			} catch (ArgumentException) { return null; }
		}

		public static int LightMinimumSize = 16;

		static Font GetDefaultFont()
		{
			if (defaultFont != null)
				return defaultFont;

			var ff = TryCreateFamily("Segoe UI");

			if (ff == null) ff = new FontFamily("Tahoma");
			if (ff == null) ff = new FontFamily("Helvetica");
			if (ff == null) ff = FontFamily.GenericSansSerif;

			var lff = TryCreateFamily("Segoe UI Light");

			if (lff == null) lff = ff;

			defaultLightFont = new Font (lff, 8);
			return defaultFont = new Font(ff, 8);
		}

		public static void Go(Control c)
		{
			if (c is IFontifiable) {
				var fontifiable = c as IFontifiable;
				if (fontifiable.Fontified)
					return;
				else
					fontifiable.Fontified = true;
			}

			var dFont = GetDefaultFont();
			
			if (c.Font.Size > LightMinimumSize)
				dFont = defaultLightFont;

			bool ignoreSize = false;

			if (c.Tag is string && (c.Tag as string).StartsWith("PixelFont:")) {
				dFont = new Font(dFont.FontFamily, 96 * int.Parse((c.Tag as string).Substring("PixelFont:".Length)) / 72, GraphicsUnit.Pixel);
				ignoreSize = true;
			}

			if (c.Font != dFont) {
				bool sameSize = ignoreSize || c.Font.Size == dFont.Size; 
				bool sameStyle = c.Font.Style == dFont.Style;
				if (sameSize && sameStyle)
					c.Font = dFont;
				else if (sameSize)
					c.Font = new Font(dFont, c.Font.Style);
				else
					c.Font = new Font(new Font(dFont.FontFamily, c.Font.Size), c.Font.Style);
			}

			foreach (Control child in c.Controls)
				Go(child);
		}
	}
}
