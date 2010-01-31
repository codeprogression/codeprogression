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
 *  Original FileName :  CardDeck.cs
 *  Created           :  Tue Oct 03 2006
 *  Description       :  
 *************************************************************************/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using LibFlashcard.Utilities;

namespace LibFlashcard.Model
{
    /// <summary>
    /// Represents a collection of <code>Card</code> objects.
    /// </summary>
    [Serializable]
    public class CardDeck
    {
        List<CardElementStyle> styles = new List<CardElementStyle>();
        List<Card> cards = new List<Card>();

        /// <summary>
        /// A list of cards.
        /// </summary>
        public List<Card> Cards {
            get { return cards; }
        }

        /// <summary>
        /// Adds some cards to the deck.
        /// </summary>
        /// <param name="cards">The cards to add.</param>
        /// <param name="normalize">If true, the Style attributes of the card will be reassigned to the Style of this deck.</param>
        public void AddCards(Card[] cards, bool normalize) {
            if (normalize) {
                for (int i = 0; i < cards.Length; i++) {
                    NormalizeCard(cards[i]);
                }
            }
            this.cards.AddRange(cards);
        }

        /// <summary>
        /// Adds a card to the deck.
        /// </summary>
        /// <param name="card">The card to add.</param>
        /// <param name="normalize">If true, the Style attributes of the card will be reassigned to the Style of this deck.</param>
        public void AddCard(Card card, bool normalize) {
            if (normalize) { NormalizeCard(card); }
            this.cards.Add(card);
        }

        /// <summary>
        /// Ensures that Style objects of the card refer to the style objects of this deck.
        /// </summary>
        /// <param name="card">The card to normalize.</param>
        public void NormalizeCard(Card card) {
            if (card.Elements.Count > styles.Count) { throw new DataException("The number of fields do not match."); }
            card.Index = this.cards.Count;
            for (int i = card.Elements.Count; i < styles.Count; i++) {
                // if card has less fields, fill them in
                card.Add(styles[i], string.Empty);
            }
            for (int i = 0; i < card.Elements.Count; i++) {
                card.Elements[i].Style = this.styles[i];
            }
        }

        public void ReIndexCards() {
            for (int i = 0; i < cards.Count; i++) {
                cards[i].Index = i;
            }
        }

        /// <summary>
        /// Gets a collection of Styles in this deck.
        /// </summary>
        public ReadOnlyCollection<CardElementStyle> Styles {
            get { return styles.AsReadOnly(); }
        }

        public CardElementStyle GetStyleByIndex(int index) {
            if ((index < styles.Count) && (styles[index].Index == index)) return styles[index]; // O(1)

            // O(n)
            for (int i = 0; i < styles.Count; i++) {
                if (styles[i].Index == index) return styles[i];
            }
            return null;
        }

        /// <summary>
        /// Adds a new style into the list.
        /// </summary>
        /// <param name="style">The Field to insert.</param>
        public void AddStyle(CardElementStyle style) {
            AddStyle(style, true);
        }

        /// <summary>
        /// Inserts a new style into the list.
        /// </summary>
        /// <param name="style">The Field to insert.</param>
        /// <param name="normalize">If true, the Index of the field will be reassigned.</param>
        public void AddStyle(CardElementStyle style, bool normalize) {
            int index = styles.Count;
            this.styles.Add(style);
            if (normalize) {
                // Normalize indices
                NormalizeIndices();
            }
            // Add the new field to existing cards
            for (int i = 0; i < this.cards.Count; i++) {
                this.cards[i].Add(style, string.Empty);
            }
        }

        /// <summary>
        /// Sets the Index of the Fields based on their order in the list.
        /// </summary>
        private void NormalizeIndices() {
            for (int i = 0; i < styles.Count; i++) {
                styles[i].Index = i;
            }
        }

        /// <summary>
        /// Sorts the columns of the deck based on the Index of the Field object.
        /// </summary>
        public void SortStyles() {
            this.styles.Sort(new CardElementStyleSorter());
            for (int i = 0; i < this.cards.Count; i++) {
                this.cards[i].Sort();
            }
        }

        /// <summary>
        /// Sorts all cards based on a column.
        /// </summary>
        /// <param name="fieldIndex">The Index of the column to sort by.</param>
        /// <param name="order">The sort order.</param>
        public void SortCards(int fieldIndex, SortOrder order) {
            this.cards.Sort(new CardComparer(order, fieldIndex));
        }

        /// <summary>
        /// Sorts all cards based on index.
        /// </summary>
        /// <param name="order">The sort order.</param>
        public void SortCardsByIndex(SortOrder order) {
            this.cards.Sort(new CardIndexComparer(order));
        }

        /// <summary>
        /// Removes a field from this deck and normalizes the cards.
        /// </summary>
        /// <param name="style">The style to remove.</param>
        /// <returns>true, if the operation succeeded. Otherwise, false.</returns>
        public bool RemoveStyle(CardElementStyle style) {
            if (this.styles.Contains(style)) {
                this.styles.Remove(style);
                NormalizeIndices();
                for (int i = 0; i < cards.Count; i++) {
                    cards[i].Remove(style);
                }
            }
            return false;
        }

        /// <summary>
        /// Checks whether the deck has a Key styled field or not.
        /// </summary>
        public bool HasKey() {
            foreach (CardElementStyle style in styles) {
                if (style.Type == CardElementType.Key) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks whether the deck has an Answer styled field or not.
        /// </summary>
        public bool HasAnswer() {
            foreach (CardElementStyle style in styles) {
                if (style.Type == CardElementType.Answer) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Create a new <code>CardDeck</code> with the fields of this instance, but without any cards.
        /// </summary>
        /// <returns>A new, empty, CardDeck</returns>
        public CardDeck GetTemplate() {
            CardDeck dummy = new CardDeck();
            dummy.styles.AddRange(this.styles);
            return dummy;
        }

        /// <summary>
        /// Generates a CSV header from the field style information.
        /// </summary>
        /// <param name="sb">A stringbuilder to write to.</param>
        /// <param name="seperator">The character used to separate fields.</param>
        public void GetCSVHeader(StringBuilder sb, char seperator) {
            for (int i = 0; i < this.styles.Count; i++) {
                if (this.styles[i].Name.IndexOf(seperator) >= 0) {
                    sb.AppendFormat("\"{0}\"", this.styles[i].Name);
                } else {
                    sb.Append(this.styles[i].Name);
                }
                if (i != this.styles.Count - 1) {
                    sb.Append(seperator);
                }
            }
        }
    }
}
