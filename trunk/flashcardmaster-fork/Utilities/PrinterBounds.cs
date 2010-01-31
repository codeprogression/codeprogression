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
 *  Original FileName :  PrinterBounds.cs
 *  Created           :  Tue Oct 03 2006
 *  Description       :  
 *************************************************************************/

using System.Runtime.InteropServices;
using System.Drawing.Printing;
using System.Drawing;
using System;

public class PrinterBounds
{
    [DllImport("gdi32.dll")]
    private static extern Int32 GetDeviceCaps(IntPtr hdc, Int32 capindex);

    private const int PHYSICALOFFSETX = 112;
    private const int PHYSICALOFFSETY = 113;

    public readonly Rectangle Bounds;
    public readonly int HardMarginLeft;
    public readonly int HardMarginTop;

    public PrinterBounds(PrintPageEventArgs e) {
	   IntPtr hDC = e.Graphics.GetHdc();

	   HardMarginLeft = GetDeviceCaps(hDC, PHYSICALOFFSETX);
	   HardMarginTop = GetDeviceCaps(hDC, PHYSICALOFFSETY);

	   e.Graphics.ReleaseHdc(hDC);

	   HardMarginLeft = (int)(HardMarginLeft * 100.0 / e.Graphics.DpiX);
	   HardMarginTop = (int)(HardMarginTop * 100.0 / e.Graphics.DpiY);

	   Bounds = e.MarginBounds;

	   Bounds.Offset(-HardMarginLeft, -HardMarginTop);
    }
}