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
 *  Original FileName :  CardElementStyle.cs
 *  Created           :  Tue Oct 03 2006
 *  Description       :  
 *************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;

namespace LibFlashcard.Model
{
    // These are designed by user
    [Serializable]
    public class CardElementStyle
    {
        Color foreColor = SystemColors.ControlText;
        Color backColor = Color.Transparent;
        CardElementPositions position = CardElementPositions.None;
        CardElementSides side = CardElementSides.Front;
        string name = string.Empty;
        CardElementType type = CardElementType.Other;
        int index;

        public CardElementStyle(int index, string name) {
            this.name = name;
            this.index = index;
        }

        public CardElementStyle(int index, string name, Color foreColor, CardElementPositions position, CardElementSides side, CardElementType type)
            : this(index, name, foreColor, Color.Transparent, position, side, type) { }

        public CardElementStyle(int index, string name, Color foreColor, Color backColor, CardElementPositions position, CardElementSides side, CardElementType type) {
            this.index = index;
            this.name = name;
            this.foreColor = foreColor;
            this.backColor = backColor;
            this.position = position;
            this.side = side;
            this.type = type;
        }

        /// <summary>
        /// Gets or Sets the Index of this Style.
        /// </summary>
        public int Index {
            get { return index; }
            set { this.index = value; }
        }

        /// <summary>
        /// Gets or Sets the type of this Style.
        /// </summary>
        public CardElementType Type {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// Gets or Sets the name of this Style. If this Style belongs to a deck, the value must be unique.
        /// </summary>
        public string Name {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Gets or Sets the foreground color of an Element.
        /// </summary>
        public Color ForeColor {
            get { return this.foreColor; }
            set { this.foreColor = value; }
        }

        /// <summary>
        /// Gets or Sets the background color of an Element.
        /// </summary>
        public Color BackColor {
            get { return this.backColor; }
            set { this.backColor = value; }
        }

        /// <summary>
        /// Gets or Sets relative position at which an Element will appear.
        /// </summary>
        public LibFlashcard.Model.CardElementPositions Position {
            get { return this.position; }
            set { this.position = value; }
        }

        /// <summary>
        /// Get or Sets the face of the card on which an Element will appear.
        /// </summary>
        public LibFlashcard.Model.CardElementSides Side {
            get { return this.side; }
            set { this.side = value; }
        }

        public override string ToString() {
            return this.name;
        }


    }

    public class CardElementStyleSorter: IComparer<CardElementStyle>
    {

        #region IComparer<CardElementStyle> Members

        public int Compare(CardElementStyle x, CardElementStyle y) {
            return x.Index.CompareTo(y.Index);
        }

        #endregion
    }


}
