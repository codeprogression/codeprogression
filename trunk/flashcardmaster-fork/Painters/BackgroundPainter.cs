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
 *  Original FileName :  BackgroundPainter.cs
 *  Created           :  Tue Oct 03 2006
 *  Description       :  
 *************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FlashCardMaster.Painters
{
    public enum BackgroundStyle { NonFilled, Filled, FilledCurved };

    public class BackgroundPainter
    {
	   Rectangle rectangle;
	   Rectangle paddedRectangle;
	   Color color;
	   BackgroundStyle style;
	   Padding padding = new Padding(0);

	   public BackgroundPainter(Color color, BackgroundStyle style)
		  : this(System.Drawing.Rectangle.Empty, color, style, Padding.Empty) { }

	   public BackgroundPainter(Color color, BackgroundStyle style, Padding padding) 
		  :this(System.Drawing.Rectangle.Empty, color, style, padding){}

	   public BackgroundPainter(Rectangle rectangle, Color color, BackgroundStyle style, Padding padding) {
		  this.rectangle = rectangle;
		  this.color = color;
		  this.style = style;
		  this.padding = padding;
		  this.paddedRectangle = PaddRectangleGrow(rectangle, padding);
	   }

	   public Padding Padding {
		  get { return padding; }
		  set { 
			 padding = value;
			 this.paddedRectangle = PaddRectangleGrow(rectangle, padding);
		  }
	   }

	   public System.Drawing.Rectangle Rectangle {
		  get { return this.rectangle; }
		  set { 
			 this.rectangle = value;
			 this.paddedRectangle = PaddRectangleGrow(rectangle, padding);
		  }
	   }

	   public System.Drawing.Rectangle PaddedRectangle {
		  get { return this.paddedRectangle; }
	   }

	   public System.Drawing.Color Color {
		  get { return this.color; }
		  set { this.color = value; }
	   }

	   public FlashCardMaster.Painters.BackgroundStyle Style {
		  get { return this.style; }
		  set { this.style = value; }
	   }

	   public void Paint(Graphics g) {
		  switch (style) {
			 case BackgroundStyle.NonFilled:
				PaintNormal(g, paddedRectangle, color);
				break;
			 case BackgroundStyle.Filled:
				PaintFilled(g, paddedRectangle, color);
				break;
			 case BackgroundStyle.FilledCurved:
				PaintFilledCurved(g, paddedRectangle, color);
				break;
			 default:
				break;
		  }
	   }

	   private static Rectangle PaddRectangleGrow(Rectangle rect, Padding padding) {
		  return new Rectangle(rect.X - padding.Left, rect.Y - padding.Top, rect.Width + padding.Horizontal, rect.Height + padding.Vertical);
	   }

	   public static void PaintNormal(Graphics g, Rectangle rectangle, Color color) {
		  using(Pen pen = new Pen(color, 1)){
			 g.DrawRectangle(pen, rectangle);
		  }
	   }

	   public static void PaintFilled(Graphics g, Rectangle rectangle, Color color) {
		  using (Brush brush = new SolidBrush(color)) {
			 g.FillRectangle(brush, rectangle);
		  }
	   }

	   public static void PaintFilledCurved(Graphics g, Rectangle rectangle, Color color) {
		  //			 Color color = Color.FromArgb(75, background.R, background.G, background.B);
		  using (Brush backgroundBrush = new SolidBrush(color)) {

			 Size CornerSize = new Size(10, 10);
			 int x = rectangle.X;
			 int y = rectangle.Y; // -((int)font.SizeInPoints + 1);
			 int w = rectangle.Width;
			 int h = rectangle.Height;
			 int xr = (x + w) - CornerSize.Width;
			 int yb = (y + h) - CornerSize.Height;
			 int iw = w - xr;
			 int ih = h - yb;
			 int sweepAngle = 90;

			 // Create 4 rectangles for our arcs to fit in. tl=topleft, br=bottomright
			 Rectangle tl = new Rectangle(x, y, CornerSize.Width, CornerSize.Height);
			 Rectangle tr = new Rectangle(xr, y, CornerSize.Width, CornerSize.Height);
			 Rectangle bl = new Rectangle(x, yb, CornerSize.Width, CornerSize.Height);
			 Rectangle br = new Rectangle(xr, yb, CornerSize.Width, CornerSize.Height);

			 // Create an inner rectangle to fill the middle
			 Rectangle innerRect = new Rectangle(x, y + (CornerSize.Height / 2), w, h - CornerSize.Height);

			 using (GraphicsPath graphPath = new GraphicsPath()) {
				graphPath.AddArc(tl, 180, sweepAngle);
				graphPath.AddArc(tr, 270, sweepAngle);
				graphPath.AddRectangle(innerRect);
				graphPath.AddArc(bl, 90, sweepAngle);
				graphPath.AddArc(br, 360, sweepAngle);

				g.FillPath(backgroundBrush, graphPath);
			 }
		  }
	   }
    }
}
