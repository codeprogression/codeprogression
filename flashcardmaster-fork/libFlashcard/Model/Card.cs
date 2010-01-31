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
 *  Original FileName :  Card.cs
 *  Created           :  Tue Oct 03 2006
 *  Description       :  
 *************************************************************************/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using LibFlashcard.Utilities;

namespace LibFlashcard.Model
{
    [Serializable]
    public class Card: IEnumerable<CardElement>
    {

        public Card() { }

        public Card(IEnumerable<CardElementStyle> styles)
            : this(styles, true) { }

        public Card(IEnumerable<CardElementStyle> styles, bool fillValues) {
            foreach (CardElementStyle style in styles) {
                if (fillValues) {
                    this.Add(style, style.Name);
                } else {
                    this.Add(style, string.Empty);
                }
            }
        }

        public void Add(CardElementStyle style, params string[] elements) {
            for (int i = 0; i < elements.Length; i++) {
                this.elements.Add(new CardElement(elements[i], style));
            }
            Sort();
        }

        public void Remove(CardElementStyle style) {
            for (int i = this.elements.Count - 1; i >= 0; i--) {
                if (this.elements[i].Style == style) {
                    this.elements.RemoveAt(i);
                }
            }
            Sort();
        }

        public void Sort() {
            this.elements.Sort();
        }

        int index;
        List<CardElement> elements = new List<CardElement>();
        CardLearningStaus learnStatus = CardLearningStaus.NotLearned;

        public int Index {
            get { return index; }
            set { index = value; }
        }

        public int Count {
            get { return elements.Count; }
        }

        public CardLearningStaus LearnStatus {
            get { return learnStatus; }
            set { learnStatus = value; }
        }

        public bool Enabled {
            get {
                return ((learnStatus == CardLearningStaus.NotLearned) || (learnStatus == CardLearningStaus.MaybeLearned));
            }
            set {
                if (value) {
                    learnStatus = CardLearningStaus.NotLearned;
                } else {
                    learnStatus = CardLearningStaus.Learned;
                }
            }
        }

        public CardElement this[int index] {
            get { return elements[index]; }
        }

        public CardElement this[CardElementStyle style] {
            get {
                for (int i = 0; i < this.elements.Count; i++) {
                    if (this.elements[i].Style == style) {
                        return this.elements[i];
                    }
                }
                return null;
            }
        }

        public ReadOnlyCollection<CardElement> Elements {
            get { return elements.AsReadOnly(); }
        }

        /// <summary>
        /// Gets the Key field, if any, of this Card.
        /// </summary>
        /// <returns>The value of the Key field.</returns>
        public string GetKey() {
            return GetType(CardElementType.Key);
        }

        /// <summary>
        /// Gets the Answer field, if any, of this Card.
        /// </summary>
        /// <returns>The value of the Answer field.</returns>
        public string GetAnswer() {
            return GetType(CardElementType.Answer);
        }


        private string GetType(CardElementType type) {
            for (int i = 0; i < elements.Count; i++) {
                if (elements[i].Style.Type == type) {
                    return elements[i].Text;
                }
            }
            return string.Empty;
        }

        public override string ToString() {
            for (int i = 0; i < this.elements.Count; i++) {
                if (elements[i].Style.Type == CardElementType.Key) {
                    return elements[i].Text;
                }
            }
            return ToCSVString(',', false);
        }

        public string ToCSVString(char seperator, bool preserveLinesInCsv) {
            StringBuilder sb = new StringBuilder();
            ToCSVString(sb, seperator, preserveLinesInCsv);
            return sb.ToString();
        }

        public void ToCSVString(StringBuilder sb, char separator, bool preserveLinesInCsv) {
            for (int i = 0; i < this.elements.Count; i++) {
                string text = this.elements[i].Text;
                if (!preserveLinesInCsv) {
                    text = text.Replace(Environment.NewLine, string.Empty);
                }
                if (NeedQuote(text, separator)) {
                    sb.AppendFormat("\"{0}\"", text);
                } else {
                    sb.Append(text);
                }
                if (i != this.elements.Count - 1) {
                    sb.Append(separator);
                }
            }
        }

        private bool NeedQuote(string s, char separator) {
            if (s.IndexOf(separator) >= 0) {
                return true;
            } else if (s.IndexOf(Environment.NewLine) >= 0) {
                return true;
            }
            return false;
        }

        public Dictionary<CardElementPositions, List<CardElement>> GroupElementsByPosition(CardElementSides side) {
            Dictionary<CardElementPositions, List<CardElement>> result = new Dictionary<CardElementPositions, List<CardElement>>();

            for (int i = 0; i < this.elements.Count; i++) {
                List<CardElement> list;
                if (!result.TryGetValue(this.elements[i].Style.Position, out list)) {
                    // add key
                    list = new List<CardElement>();
                    result.Add(this.elements[i].Style.Position, list);
                }
                if ((this.Elements[i].Style.Side & side) == side) {
                    list.Add(this.elements[i]);
                }
            }

            return result;
        }



        #region IEnumerable<CardElement> Members

        public IEnumerator<CardElement> GetEnumerator() {
            return this.elements.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return this.elements.GetEnumerator();
        }

        #endregion
    }
}
