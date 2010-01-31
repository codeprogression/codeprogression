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
 *  Original FileName :  TextPainter.cs
 *  Created           :  Tue Oct 03 2006
 *  Description       :  
 *************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using LibFlashcard.WikiText;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace FlashCardMaster.Painters
{
    // This class paints each line
    public class TextPainter
    {

	   public TextPainter(TextElement[] textFragments, Color foreColor, Rectangle destRect, FontProvider fontProvider, TextFormatFlags flags, Point location) {
		  this.textFragments = textFragments;
		  this.foreColor = foreColor;
		  this.destRectangle = destRect;
		  this.fontProvider = fontProvider;
		  this.formatFlags = flags;
		  this.location = location;
	   }

	   Color foreColor;
	   Rectangle destRectangle = Rectangle.Empty;
	   FontProvider fontProvider;
	   TextFormatFlags formatFlags = TextFormatFlags.Default;
	   TextElement[] textFragments;
	   Point location = Point.Empty;
	   Padding padding = new Padding(0);

	   public Padding Padding {
		  get { return padding; }
		  set { padding = value; }
	   }

	   public System.Drawing.Color ForeColor {
		  get { return this.foreColor; }
		  set { this.foreColor = value; }
	   }

	   public System.Drawing.Rectangle DestRectangle {
		  get { return this.destRectangle; }
		  set { this.destRectangle = value; }
	   }

	   public FlashCardMaster.Painters.FontProvider FontProvider {
		  get { return this.fontProvider; }
		  set { this.fontProvider = value; }
	   }

	   public System.Windows.Forms.TextFormatFlags FormatFlags {
		  get { return this.formatFlags; }
		  set { this.formatFlags = value; }
	   }

	   public TextElement[] TextFragments {
		  get { return this.textFragments; }
		  set { this.textFragments = value; }
	   }

	   public System.Drawing.Point Location {
		  get { return this.location; }
		  set { this.location = value; }
	   }

	   #region IPainter Members

	   public struct Line
	   {
		  public Line(int start, int end, Size size) {
			 this.Start = start;
			 this.End = end;
			 this.Size = size;
		  }

		  public Size Size;
		  public int Start;
		  public int End;

		  public override string ToString() {
			 return string.Format("{{ {0}, {1}, {2} }}", Start, End, Size);
		  }
	   }

	   /// <summary>
	   /// Calcualates the total dimensions of this object.
	   /// </summary>
	   /// <remarks>This method causes cached values to be refreshed.</remarks>
	   /// <param name="g">A graphics object</param>
	   /// <returns>The size of this object.</returns>
	   public Size GetSize(Graphics g) {
		  // recalculate values
		  this.lines = GetLines(g, out totalSize);
		  return totalSize;
	   }

	   Line[] lines;   // line cache
	   Size totalSize; // size cache

	   // measures lines, explicit or implicit.
	   private Line[] GetLines(Graphics g, out Size total) {
		  List<Line> lineSizes = new List<Line>();
		  int index = 0;
		  int end;
		  int totalWidth = 0;	 // width is limited
		  int totalHeight = 0;	 // height is additive
		  while (index < textFragments.Length) {
			 Size size = GetLineSize(g, index, out end);
			 if (size.Width > totalWidth) { totalWidth = size.Width; }
			 totalHeight += size.Height;
			 lineSizes.Add(new Line(index, end, size));
			 index = end + 1;
		  }
		  total = new Size(totalWidth, totalHeight);
		  return lineSizes.ToArray();
	   }

	   // Measures strings from linestart to the next explicit or implicit linebreak.
	   private Size GetLineSize(Graphics g, int lineStart, out int lineend) {
		  int width = 0;
		  int height = 0;
		  int currentHeight;
		  if (fontProvider.Regular.Style == FontStyle.Regular) {
			 currentHeight = fontProvider.Regular.Height;
		  } else {
			 currentHeight = (int)(fontProvider.Regular.Size + 0.5f);
		  }
		  lineend = textFragments.Length - 1;

		  for (int i = lineStart; i < textFragments.Length; i++) {
			 if (textFragments[i].Style == TextStyle.LineBreak) {
				// The current character is line break
				lineend = i;
				break;
			 }

			 textFragments[i].Size = TextRenderer.MeasureText(g, this.textFragments[i].Text, fontProvider.GetFont(this.textFragments[i].Style), this.destRectangle.Size, this.formatFlags);
			 // grow width
			 width += textFragments[i].Size.Width;
			 
			 if (width > destRectangle.Width) { // '>=' will cause a infinite loop when the string is
									      // one-long line, because then (width==surface.width) 
									      // and there is to be done about that.
				// the line exceeds surface width; an implied line break; step-back and break line
				width -= textFragments[i].Size.Width;
				lineend = i - 1;
				break;
			 }

			 if (textFragments[i].Size.Height > currentHeight) { currentHeight = textFragments[i].Size.Height; }
		  }

		  if (height == 0) {
			 height = currentHeight;
		  }
		  if (width == 0) {
			 // width was probably reset at last index
			 width = destRectangle.Width;
		  }

		  return new Size(width, height); 
	   }


	   public virtual void Paint(System.Drawing.Graphics g) {
		  PaintGlyphs(g, this.textFragments, this.fontProvider, this.foreColor, this.location, this.formatFlags);
	   }


	   private void PaintGlyphs(Graphics g, TextElement[] elements, FontProvider fonts, Color forecolor, Point position, TextFormatFlags flags) {
		  g.SmoothingMode = SmoothingMode.HighQuality;
		  g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

		  if ((elements == null) || (elements.Length == 0)) { return; }

		  // WARNING: GetSize() Must be called by parent, otherwise values cannot be trusted
		  Size totalSize = this.totalSize;
		  Line[] lines = this.lines;

		  int x = 0;
		  int y = position.Y;

		  for (int i = 0; i < lines.Length; i++) {
			 x = position.X + ((totalSize.Width / 2) - (lines[i].Size.Width / 2)); // center the line

			 for (int j = lines[i].Start; j <= lines[i].End; j++) {
				// Todo: Set V alignment (for super & sub scripts)
				Rectangle rect;
				if (elements[j].Style == TextStyle.Sub) {
				    // This is a hack to simulate subscript
				    rect = new Rectangle(new Point(x, y + (lines[i].Size.Height - elements[j].Size.Height) + 3), elements[j].Size);
				} else {
				    rect = new Rectangle(new Point(x, y), elements[j].Size);
				}
				TextRenderer.DrawText(g, elements[j].Text, fontProvider.GetFont(elements[j].Style), rect, forecolor, flags | TextFormatFlags.NoPrefix);
#if GFX_DEBUG
				g.DrawRectangle(Pens.Blue, new Rectangle(new Point(x, y), elements[j].Size));
#endif
				x += elements[j].Size.Width;
			 }

			 y += lines[i].Size.Height;  // proceed to next line
		  } 
	   }

	   #endregion
    }
}
