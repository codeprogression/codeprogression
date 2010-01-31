/*************************************************************************
 *  Flash Card Master
 *  Copyleft (C) 2006 Nithin Philips
 *
 *  This program is free software; you can redistribute it and/or
 *  modify it under the terms of the GNU General Public License
 *  as published by the Free Software Foundation; either version 2
 *  of the License, or (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program; if not, write to the Free Software
 *  Foundation,Inc.,59 Temple Place - Suite 330,Boston,MA 02111-1307, USA.
 *
 *  Author            :  Nithin Philips <spikiermonkey@users.sourceforge.net>
 *  Original FileName :  Utility.cs
 *  Created           :  Tue Oct 03 2006
 *  Description       :  
 *************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using FlashCardMaster.Painters;
using LibFlashcard.Model;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using FlashCardMaster.User;
using System.Security.Cryptography;

namespace FlashCardMaster.Utilities
{
    public static class Utility
    {
	   public static Random Rnd = new Random();

	   public static Font DEFAULT_FONT = new System.Drawing.Font(SystemFonts.DialogFont.Name, 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
	   public static string DEFAULT_SETTINGS_FILE = Path.Combine(Application.UserAppDataPath, "User.settings");
	   public static string WINDOW_SETTINGS_FILE = Path.Combine(Application.UserAppDataPath, "Window.settings");
	   public static string DEFAULT_XSLT_FILE = Path.Combine(Application.UserAppDataPath, "Style.xslt");

	   public static string GetBackupName(string file) {
		  MD5CryptoServiceProvider crypto = new MD5CryptoServiceProvider();
		  byte[] bs = System.Text.Encoding.UTF8.GetBytes(file);
		  bs = crypto.ComputeHash(bs);
		  System.Text.StringBuilder sb = new System.Text.StringBuilder();
		  foreach (byte b in bs) {
			 sb.Append(b.ToString("x2").ToLower());
		  }
		  string name = sb.ToString();
//		  string name = (string.IsNullOrEmpty(file)) ? "Untitled" : Path.GetFileName(file);
		  return Path.Combine(Application.UserAppDataPath, name + ".card");
	   }

	   public const int RECENT_ITEMS_COUNT = 10; // Must be > 1

	   public static void SetImage(Button control, Image image) {
		  if (control.Image != null) {
			 control.Image.Dispose();
			 control.Image = null;
		  }
		  control.Image = image;
	   }

	   public static void Serialize<T>(T instance, string fileName) where T : class {
		  string tempFile = Path.GetTempFileName();
		  using (System.IO.FileStream fs = new System.IO.FileStream(tempFile, System.IO.FileMode.Create, System.IO.FileAccess.Write)) {
			 System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(T));
			 xs.Serialize(fs, instance);
			 fs.Flush();
		  }
		  File.Copy(tempFile, fileName, true);
		  File.Delete(tempFile);
	   }

	   public static T DeSerialize<T>(string fileName) where T : class {
		  object up;
		  using (System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read)) {
			 System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(T));
			 up = xs.Deserialize(fs);
		  }
		  return up as T;
	   }

	   /// <summary>
	   /// Sets the size of System.Windows.Form object.
	   /// If a saved size is available it is used, otherwise size is calcualted relative to screen size.
	   /// </summary>
	   /// <param name="form">The form to set the size.</param>
	   /// <param name="widthPer">If size is calculated, the percentage width of the screen that the form will occupy.</param>
	   /// <param name="heightPer">If size is calculated, the percentage height of the screen that the form will occupy.</param>
	   public static void SetFormSize(Form form, float widthPer, float heightPer) {
		  Size windowSize = Settings.WinSettings.GetWindowSize(form.GetType().ToString());
		  if (windowSize != Size.Empty) {
			 form.Size = windowSize;
		  } else {
			 Screen scrn = Screen.FromControl(form);
			 form.Size = new Size((int)(scrn.WorkingArea.Width * widthPer), (int)(scrn.WorkingArea.Height * heightPer));
		  }
	   }

	   public static void SetIcon(Form form) {
		  form.Icon = Properties.Resources.App;
	   }

	   public static Color SetAlpha(Color color, int alpha) {
		  return Color.FromArgb(alpha, color.R, color.G, color.B);
	   }

	   // ShortenPath(...) methods from http://www.codinghorror.com/blog/archives/000650.html

	   [DllImport("shlwapi.dll", CharSet = CharSet.Auto)]
	   static extern bool PathCompactPathEx([Out]StringBuilder pszOut, string szPath, int cchMax, int dwFlags);

	   public static string ShortenPath(string path, int maxLength) {
		  StringBuilder sb = new StringBuilder();
		  PathCompactPathEx(sb, path, maxLength, 0);
		  return sb.ToString();
	   }

	   public static string ShortenPath(string path) {
		  const string pattern = @"^(\w+:|\\)(\\[^\\]+\\[^\\]+\\).*(\\[^\\]+\\[^\\]+)$";
		  const string replacement = "$1$2...$3";
		  if (Regex.IsMatch(path, pattern)) {
			 return Regex.Replace(path, pattern, replacement);
		  } else {
			 return path;
		  }
	   }

	   public static void CheckXsl() {
		  if (!File.Exists(Utility.DEFAULT_XSLT_FILE)) {
			 File.WriteAllText(Utility.DEFAULT_XSLT_FILE, Properties.Resources.Style, UTF8Encoding.UTF8);
		  }
	   }

	   public static string ColorToArgb(Color color) {		  
		  return string.Format("argb({0},{1},{2},{3})", color.A, color.R, color.G, color.B);
	   }

	   public static string ColorToRgb(Color color) {
		  return string.Format("rgb({0},{1},{2})", color.R, color.G, color.B);
	   }

	   // Parses a string in the format  (#=[0-255])
	   //	 rgb(#,#,#) 
	   // or	argb(#,#,#,#)
	   public static Color DeserializeColor(string color) {
		  byte a, r, g, b;

		  if (color.StartsWith("argb", StringComparison.InvariantCultureIgnoreCase)) {
			 string colorInfo = color.Substring(5, color.Length - (1 + 5));
			 string[] colors = colorInfo.Split(',');
			 a = byte.Parse(colors[0].Trim());
			 r = byte.Parse(colors[1].Trim());
			 g = byte.Parse(colors[2].Trim());
			 b = byte.Parse(colors[3].Trim());
		  } else if (color.StartsWith("rgb", StringComparison.InvariantCultureIgnoreCase)) {
			 string colorInfo = color.Substring(4, color.Length - (1 + 4));
			 string[] colors = colorInfo.Split(',');
			 a = 255;
			 r = byte.Parse(colors[0].Trim());
			 g = byte.Parse(colors[1].Trim());
			 b = byte.Parse(colors[2].Trim());
		  } else {
			 throw new ArgumentException("Unknown color format.");
		  }

		  return Color.FromArgb(a, r, g, b);
	   }

	   public static bool IsNullorDisposed(Control obj) {
		  return (obj == null) || (obj.IsDisposed);
	   }

	   // From http://www.codeproject.com/useritems/IdealTextColor.asp by John Simmons
	   /// <summary>
	   /// Calculates the ideal foreground color for a given background color.
	   /// </summary>
	   /// <param name="backgroundColor">The background color, for which to get forecolor.</param>
	   /// <returns>The ideal foreground color.</returns>
	   public static Color IdealTextColor(Color backgroundColor) {
		  int nThreshold = 105;
		  int bgDelta = Convert.ToInt32((backgroundColor.R * 0.299) + (backgroundColor.G * 0.587) + (backgroundColor.B * 0.114));
		  Color foreColor = (255 - bgDelta < nThreshold) ? Color.Black : Color.White;
		  return foreColor;
	   }
    }
}
