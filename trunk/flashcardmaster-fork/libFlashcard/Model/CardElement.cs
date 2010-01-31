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
 *  Original FileName :  CardElement.cs
 *  Created           :  Tue Oct 03 2006
 *  Description       :  
 *************************************************************************/

using System;

namespace LibFlashcard.Model
{
    [Flags]
    public enum CardElementPositions
    {
        /// <summary>
        /// Won't render
        /// </summary>
        None = 0,
        Top = 1,
        Bottom = 2,
        Left = 4,
        Right = 8,
        VerticalCenter = 16,
        HorizontalCenter = 32,
        Center = VerticalCenter | HorizontalCenter
    }

    [Flags]
    public enum CardElementSides
    {
        Front = 1,
        Back = 2,
        Both = Front | Back
    }

    public enum CardElementType
    {
        Key,
        Answer,
        Other
    }

    [Serializable]
    public class CardElement: IComparable<CardElement>
    {

        public CardElement(string text, CardElementStyle style) {
            this.text = text;
            this.style = style;
        }

        string text = string.Empty;
        CardElementStyle style;

        /// <summary>
        /// The text value of this element.
        /// </summary>
        public string Text {
            get { return this.text; }
            set { this.text = value; }
        }

        /// <summary>
        /// The style of this element.
        /// </summary>
        public LibFlashcard.Model.CardElementStyle Style {
            get { return this.style; }
            set { this.style = value; }
        }

        #region IComparable<CardElement> Members

        public int CompareTo(CardElement other) {
            return this.style.Index.CompareTo(other.style.Index);
        }

        #endregion
    }


}
