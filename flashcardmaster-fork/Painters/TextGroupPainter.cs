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
 *  Original FileName :  TextGroupPainter.cs
 *  Created           :  Tue Oct 03 2006
 *  Description       :  
 *************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using LibFlashcard.WikiText;
using System.Windows.Forms;
using LibFlashcard.Model;

namespace FlashCardMaster.Painters
{
    public enum DisplayDeviceType { Screen, Printer };

    public class TextGroupPainter : IDisposable
    {
	   Color foreColor;

	   public Color ForeColor {
		  get { return foreColor; }
		  set { foreColor = value;
			 for (int i = 0; i < painters.Length; i++) {
				painters[i].ForeColor = value;
			 }
		  }
	   }

	   public Rectangle DestRectangle {
		  get { return destRectangle; }
		  set {
			 destRectangle = value;
			 for (int i = 0; i < painters.Length; i++) {
				painters[i].DestRectangle = value;
			 }
		  }
	   }

	   public DisplayDeviceType DisplayDevice {
		  get { return displayDevice; }
		  set { displayDevice = value; }
	   }

	   DisplayDeviceType displayDevice = DisplayDeviceType.Screen;
	   TextPainter[] painters;
	   BackgroundPainter backgroundPainter;
	   Rectangle destRectangle;
	   FontProvider fontProvider;
	   TextFormatFlags formatFlags = TextFormatFlags.WordEllipsis | TextFormatFlags.WordBreak |
							   TextFormatFlags.NoClipping | TextFormatFlags.NoPadding;

	   public FontProvider FontProvider {
		  get { return fontProvider; }
		  set { fontProvider = value; }
	   }

	   public TextFormatFlags FormatFlags {
		  get { return formatFlags; }
		  set { formatFlags = value; }
	   }

	   public BackgroundPainter BackgroundPainter {
		  get { return backgroundPainter; }
		  set { backgroundPainter = value; }
	   }

	   public TextPainter[] Painters {
		  get { return painters; }
	   }

	   CardElementPositions position;

	   public CardElementPositions Position {
		  get { return position; }
		  set { position = value; }
	   }

	   Rectangle paintedRectangle;

	   public Rectangle PaintedRectangle {
		  get { return paintedRectangle; }
	   }

	   public TextGroupPainter(CardElement[] elements, BackgroundPainter backgroundPainter, Rectangle destRectangle, Font font, CardElementPositions position) {
		  this.fontProvider = new FontProvider(font);
		  // Conform format flags
		  this.formatFlags |= PositionToFlags(position);
		  this.position = position;
		  this.destRectangle = destRectangle;
		  this.backgroundPainter = backgroundPainter;

		  List<TextPainter> lPainters = new List<TextPainter>(elements.Length);
		  for (int i = 0; i < elements.Length; i++) {
			 if (string.IsNullOrEmpty(elements[i].Text)) { continue; }
			 TextPainter painter = new TextPainter(WikiMarkupParser.Parse(elements[i].Text, User.Settings.AppInstance.RenderingBreakWords), elements[i].Style.ForeColor, destRectangle, fontProvider, formatFlags, Point.Empty);
			 lPainters.Add(painter);
		  }
		  this.painters = lPainters.ToArray();
	   }

	   public TextGroupPainter(string wikiText, Color foreColor, BackgroundPainter backgroundPainter, Rectangle destRectangle, Font baseFont, CardElementPositions position) {
		  TextElement[] elements = WikiMarkupParser.Parse(wikiText);
		  this.foreColor = foreColor;
		  this.backgroundPainter = backgroundPainter;
		  this.destRectangle = destRectangle;
		  this.fontProvider = new FontProvider(baseFont);
		  this.position = position;

		  // Conform format flags
		  this.formatFlags |= PositionToFlags(position);

		  // Painters is an array because, in the future multiple elements that are at the same CardElementPosition
		  // can be laidout properly.
		  if (!string.IsNullOrEmpty(wikiText)) {
			 painters = new TextPainter[] { 
				new TextPainter(elements, this.foreColor, this.destRectangle, this.fontProvider, this.formatFlags, Point.Empty) 
			 };
		  } else {
			 painters = new TextPainter[] { };
		  }
	   }

	   public void Paint(Graphics g) {
		  g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
		  g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

		  int maxHeight = 0;
		  int maxWidth = 0;
		  Size[] sizes = new Size[this.painters.Length];
		  for (int i = 0; i < this.painters.Length; i++) {
			 Size lineSize = painters[i].GetSize(g);
			 sizes[i] = lineSize;
			 maxHeight += lineSize.Height;
			 maxWidth += lineSize.Width;
		  }

		  int y = 0;
		  int x = 0;

		  if ((position & CardElementPositions.Top) == CardElementPositions.Top) {
			 y = 0;
		  } else if ((position & CardElementPositions.Bottom) == CardElementPositions.Bottom) {
			 y = (int)(destRectangle.Height - (float)maxHeight);
		  } else if ((position & CardElementPositions.VerticalCenter) == CardElementPositions.VerticalCenter) {
			 y = (int)((destRectangle.Height / 2f) - (maxHeight / 2f));
		  }

		  // offset
		  y += destRectangle.Y;

		  for (int i = 0; i < this.painters.Length; i++) {

			 if ((position & CardElementPositions.Left) == CardElementPositions.Left) {
				x = 0;
			 } else if ((position & CardElementPositions.Right) == CardElementPositions.Right) {
				x = (int)(destRectangle.Width - (float)maxWidth);
			 } else if ((position & CardElementPositions.HorizontalCenter) == CardElementPositions.HorizontalCenter) {
				x = (int)((destRectangle.Width / 2f) - (sizes[i].Width / 2f));
			 }

			 // offset
			 x += destRectangle.X;
			 Point location = new Point(x, y);
			 this.painters[i].Location = location;
			 Rectangle bgRect = new Rectangle(location, sizes[i]);

			 if ((g.DpiX != 96f) && (g.DpiY != 96f)) {
				// This is a hack; this may not work on other systems.
				// Problem is only text need to be scaled, but as of now everything is scaled
				bgRect = FlashCardMaster.Utilities.CardDeckPrinter.UnScaleRectangle(g, bgRect);
			 }

			 if (this.BackgroundPainter != null) {
				this.backgroundPainter.Rectangle = bgRect;
				this.BackgroundPainter.Paint(g);
				this.paintedRectangle = backgroundPainter.PaddedRectangle; 
//				Console.WriteLine("{2} {1} BG: {0}", this.backgroundPainter.PaddedRectangle, i, g.DpiX);
			 }else{
				this.paintedRectangle = bgRect;
			 }

#if GFX_DEBUG 
			 FlashCardMaster.Painters.BackgroundPainter bpD = new BackgroundPainter(bgRect, Color.Red, BackgroundStyle.NonFilled, new Padding(1));
			 bpD.Paint(g);
			 g.DrawString(sizes[i].ToString(), fontProvider.Regular, Brushes.Red, x, y - 19);
#endif

			 this.painters[i].Paint(g);
			 y += sizes[i].Height;
		  }
	   }

	   private static TextFormatFlags PositionToFlags(CardElementPositions position) {
		  TextFormatFlags flag = 0;

		  if ((position & CardElementPositions.HorizontalCenter) == CardElementPositions.HorizontalCenter) {
			 flag |= TextFormatFlags.HorizontalCenter;
		  }
		  if ((position & CardElementPositions.VerticalCenter) == CardElementPositions.VerticalCenter) {
			 flag |= TextFormatFlags.VerticalCenter;
		  }

		  if ((position & CardElementPositions.Top) == CardElementPositions.Top) {
			 flag |= TextFormatFlags.Top;
		  }

		  if ((position & CardElementPositions.Bottom) == CardElementPositions.Bottom) {
			 flag |= TextFormatFlags.Bottom;
		  }

		  if ((position & CardElementPositions.Left) == CardElementPositions.Left) {
			 flag |= TextFormatFlags.Left;
		  }

		  if ((position & CardElementPositions.Right) == CardElementPositions.Right) {
			 flag |= TextFormatFlags.Right;
		  }

		  return flag;
	   }

	   #region IDisposable Members

	   public void Dispose() {
		  if (this.fontProvider != null) {
			 this.fontProvider.Dispose();
		  }
	   }

	   #endregion
    }
}
