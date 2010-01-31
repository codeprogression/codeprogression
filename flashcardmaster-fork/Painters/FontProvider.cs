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
 *  Original FileName :  FontProvider.cs
 *  Created           :  Tue Oct 03 2006
 *  Description       :  
 *************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using LibFlashcard.WikiText;

namespace FlashCardMaster.Painters
{
    public class FontProvider : IDisposable
    {
	   public FontProvider(Font baseFont) {
		  this.baseFont = baseFont;
	   }

	   Font baseFont;
	   Font regular;
	   Font bold;
	   Font italic;
	   Font boldItalic;
	   Font underline;
	   Font monospace;
	   Font strikethrough;
	   Font superSub;

	   public Font BaseFont {
		  get { return baseFont; }
		  set { baseFont = value; }
	   }

	   public System.Drawing.Font Regular {
		  get {
			 if (this.regular == null) {
				try {
				    this.regular = new Font(baseFont, FontStyle.Regular);
				} catch {
				    this.regular = baseFont;
				}
			 }
			 return this.regular;
		  }
	   }

	   public System.Drawing.Font Bold {
		  get {
			 if (this.bold == null) { 
				try {
				    this.bold = new Font(baseFont, FontStyle.Bold); 
				} catch {
				    this.bold = baseFont;
				}
			 }
			 return this.bold;
		  }
	   }

	   public System.Drawing.Font Italic {
		  get {
			 if (this.italic == null) {
				try {
				    this.italic = new Font(baseFont, FontStyle.Italic);
				} catch {
				    this.italic = baseFont;
				} 
			 }
			 return this.italic;
		  }
	   }

	   public System.Drawing.Font BoldItalic {
		  get {
			 if (this.boldItalic == null) {
				try {
				    this.boldItalic = new Font(baseFont, FontStyle.Italic | FontStyle.Bold); 
				} catch {
				    this.boldItalic = baseFont;
				} 
			 }
			 return this.boldItalic;
		  }
	   }

	   public System.Drawing.Font Underline {
		  get {
			 if (this.underline == null) {
				try {
				    this.underline = new Font(baseFont, FontStyle.Underline); 
				} catch {
				    this.underline = baseFont;
				} 
			 }
			 return this.underline;
		  }
	   }

	   public System.Drawing.Font Monospace {
		  get {
			 if (this.monospace == null) { 
				this.monospace = new Font("Courier New", baseFont.Size, baseFont.Style, baseFont.Unit); 
			 }
			 return this.monospace;
		  }
	   }

	   public System.Drawing.Font Strikethrough {
		  get {
			 if (this.strikethrough == null) {
				try {
				    this.strikethrough = new Font(baseFont, FontStyle.Strikeout); 
				} catch {
				    this.strikethrough = baseFont;
				} 
			 }
			 return this.strikethrough;
		  }
	   }

	   public System.Drawing.Font SuperSub {
		  get {
			 if(superSub == null){ 
				superSub = new Font(baseFont.Name, baseFont.Size - 3, baseFont.Style, baseFont.Unit); 
			 }
			 return superSub;
		  }
	   }

	   public Font GetFont(TextStyle style) {
		  switch (style) {
			 case TextStyle.Regular:
				return this.Regular;
			 case TextStyle.Italic:
				return this.Italic;
			 case TextStyle.Bold:
				return this.Bold;
			 case TextStyle.BoldItalic:
				return this.BoldItalic;
			 case TextStyle.Underline:
				return this.Underline;
			 case TextStyle.Monospace:
				return this.Monospace;
			 case TextStyle.Strikethru:
				return this.Strikethrough;
			 case TextStyle.Super:
				return this.SuperSub;
			 case TextStyle.Sub:
				return this.SuperSub;
			 default:
				return BaseFont;
		  }
	   }

	   #region IDisposable Members

	   public void Dispose() {
//		  if (this.baseFont != null) { baseFont.Dispose(); }
		  if (this.regular != null) { regular.Dispose(); }
		  if (this.bold != null) { bold.Dispose(); }
		  if (this.italic != null) { italic.Dispose(); }
		  if (this.boldItalic != null) { boldItalic.Dispose(); }
		  if (this.underline != null) { underline.Dispose(); }
		  if (this.monospace != null) { monospace.Dispose(); }
		  if (this.strikethrough != null) { strikethrough.Dispose(); }
		  if (this.superSub!= null) { superSub.Dispose(); }
	   }

	   #endregion
    }
}
