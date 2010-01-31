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
 *  Original FileName :  CardPanel.cs
 *  Created           :  Tue Oct 03 2006
 *  Description       :  
 *************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using LibFlashcard.Model;
using FlashCardMaster.Painters;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;

namespace FlashCardMaster.Utilities
{
    /// <summary>
    /// Renders a Card object.
    /// </summary>
    public class CardPanel : Panel
    {
	   public CardPanel() {
		  this.Padding = new Padding(5);
		  this.Font = Utility.DEFAULT_FONT;
		  this.BackColor = SystemColors.Window;
		  this.ForeColor = SystemColors.WindowText;
		  base.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.Selectable, true);
		  this.SizeChanged += new EventHandler(CardPanel_SizeChanged);
		  this.Paint += new PaintEventHandler(CardPanel_Paint);
		  this.Card = null;
	   }

	   void CardPanel_SizeChanged(object sender, EventArgs e) {
		  InvalidatePainters();
	   }

	   void CardPanel_Paint(object sender, PaintEventArgs e) {
		  if ((this.suspendPaint) || (this.painters == null)) { return; }
		  using (Graphics g = e.Graphics) {
			 for (int i = 0; i < painters.Length; i++) {
				painters[i].Paint(g);
			 }
		  }
	   }

	   private void DisposePainters(){
		  if (this.painters != null) {
				for (int i = 0; i < this.painters.Length; i++) {
				    this.painters[i].Dispose();
				}
				this.painters = null;
			 }
	   }

	   public void InvalidatePainters() {
		  if (displayMode == DisplayMode.Card) {
			 
			 DisposePainters();

			 if (this.card != null) {
				this.painters = CardToPainters(this.card, side, this.PaddedRectangle, this.Font);
			 } else {
				if (this.noCardMessage != string.Empty) {
				    this.painters = new TextGroupPainter[]{
				    new TextGroupPainter(this.noCardMessage, SystemColors.Window, new BackgroundPainter(Utility.SetAlpha(SystemColors.WindowText, 150), BackgroundStyle.FilledCurved, new Padding(10, 2, 10, 2)), this.PaddedRectangle, 
								this.Font, CardElementPositions.Center)
				    };
				}
			 }

		  } else if (this.painters != null) {
			 // update any painters
			 for (int i = 0; i < this.painters.Length; i++) {
				this.painters[i].DestRectangle = this.PaddedRectangle;
			 }
		  }
	   }

	   enum DisplayMode { Card, Manual };

	   DisplayMode displayMode =  DisplayMode.Card;

	   bool suspendPaint = false;
	   Card card;
	   TextGroupPainter[] painters;
	   CardElementSides side = CardElementSides.Front;
	   string noCardMessage = "{empty}";

	   public void SetManualMode(bool manual) {
		  SetManualMode(manual, null);
	   }

	   public void SetManualMode(bool manual, TextGroupPainter[] painters) {
		  DisposePainters();
		  if (manual) {
			 this.displayMode = DisplayMode.Manual;
			 this.painters = painters;
		  } else {
			 this.painters = null;
			 this.displayMode = DisplayMode.Card;
		  }
		  InvalidatePainters();
		  Invalidate();
	   }

	   /// <summary>
	   /// The message to be displayed when Card property is null.
	   /// </summary>
	   public string NoCardMessage {
		  get { return noCardMessage; }
		  set { 
			 noCardMessage = value;
			 if (this.card == null) {
				InvalidatePainters();
				this.Invalidate();
			 }
		  }
	   }

	   /// <summary>
	   /// The ClientRectangle offset for Padding.
	   /// </summary>
	   [EditorBrowsable(EditorBrowsableState.Advanced)]
	   [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	   [Browsable(false)]
	   public Rectangle PaddedRectangle {
		  get {
			 return new Rectangle(Padding.Left, Padding.Top, this.ClientRectangle.Width - Padding.Horizontal, this.ClientRectangle.Height - Padding.Vertical);
		  }
	   }
	    
	   /// <summary>
	   /// The side of the card to paint.
	   /// </summary>
	   [EditorBrowsable(EditorBrowsableState.Advanced)]
	   [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	   [Browsable(false)]
	   public CardElementSides Side {
		  get { return side; }
		  set { side = value; InvalidatePainters(); }
	   }


	   [EditorBrowsable(EditorBrowsableState.Never)]
	   [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	   [Browsable(false)]
	   public TextGroupPainter[] Painters {
		  get { return painters; }
	   }

	   /// <summary>
	   /// The card that is to be painted.
	   /// </summary>
	   [EditorBrowsable(EditorBrowsableState.Never)]
	   [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	   [Browsable(false)]
	   public Card Card {
		  get { return card; }
		  set { card = value; InvalidatePainters(); this.Invalidate(); }
	   }

	   public static TextGroupPainter[] CardToPainters(Card card, CardElementSides side, Rectangle destRect, Font fnt) {
		  List<TextGroupPainter> result = new List<TextGroupPainter>();
		  Dictionary<CardElementPositions, List<CardElement>> group = card.GroupElementsByPosition(side);

		  foreach (KeyValuePair<CardElementPositions, List<CardElement>> pair in group) {
			 if (pair.Key == CardElementPositions.None) { continue; }

			 BackgroundPainter bgPainter = null;
#if DEBUG
			 foreach (CardElement elem in pair.Value) {
				Debug.Assert(elem.Style.Position == pair.Key);
//				Console.WriteLine("{0}: {1}", pair.Key, elem.Text);
				
			 }
#endif
			 if (pair.Value.Count > 0) {
				if (pair.Value[0].Style.BackColor != Color.Transparent) {
				    bgPainter = new BackgroundPainter(pair.Value[0].Style.BackColor, BackgroundStyle.FilledCurved, new Padding(10, 2, 10, 2));
				}
			 }

			 result.Add(new TextGroupPainter(pair.Value.ToArray(), bgPainter, destRect, fnt, pair.Key));
		  }

		  return result.ToArray();
	   }

	   /// <summary>
	   /// Halts painting of the Card.
	   /// </summary>
	   public bool SuspendPaint {
		  get { return suspendPaint; }
		  set {
			 suspendPaint = value;
			 if (value) { this.Invalidate(); }
		  }
	   }


    }
}
