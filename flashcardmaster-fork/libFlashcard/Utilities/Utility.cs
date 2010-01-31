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
using System.Drawing;

namespace LibFlashcard.Utilities
{
    public sealed class Utility
    {
        private Utility() { }

        public static Random Rnd = new Random();

        public static Color SetAlpha(Color color, int alpha) {
            return Color.FromArgb(alpha, color.R, color.G, color.B);
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
    }
}
