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
 *  Original FileName :  CardDeckBuilder.cs
 *  Created           :  Thu Oct 05 2006
 *  Description       :  
 *************************************************************************/
using System.Collections.Generic;
using System.Diagnostics;
using LibFlashcard.Model;

namespace LibFlashcard.Utilities
{
    /// <summary>
    /// Allows deferred construction of CardDeck object.
    /// </summary>
    public class CardDeckBuilder
    {
        /* Using CardDeckBuilder
         *  Call BeginCard() to start building a card.
         *  Call AddCardField() for each field.
         *  [Optional] Call EndCard()
         *  Repeat until done.
         *  Call Build to create a CardDeck object.
         */

        private class CardPrototype
        {
            public CardLearningStaus learnStatus;
            public List<KeyValuePair<string, string>> fields = new List<KeyValuePair<string, string>>();
        }

        List<CardElementStyle> styles = new List<CardElementStyle>();

        public void AddStyle(CardElementStyle style) {
            this.styles.Add(style);
        }

        List<CardPrototype> cards = new List<CardPrototype>();
        CardPrototype current = null;

        public void BeginCard(CardLearningStaus learnStatus) {
            EndCard();
            this.current = new CardPrototype();
            this.current.learnStatus = learnStatus;
        }

        public void EndCard() {
            if (this.current != null) {
                cards.Add(current);
                this.current = null;
            }
        }

        public void AutoCategorizeStyles() {
            if (styles.Count > 2) {
                bool foundKey = false, foundAnswer = false;
                for (int i = 0; i < styles.Count; i++) {
                    if (ExtrapolateType(styles[i])) {
                        if (styles[i].Type == CardElementType.Key) { foundKey = true; }
                        if (styles[i].Type == CardElementType.Answer) { foundAnswer = true; }
                    }
                }
                if (!foundKey && !foundAnswer) {
                    // no key or answer
                    styles[0].Type = CardElementType.Key;
                    styles[0].Side = CardElementSides.Front;
                    styles[1].Type = CardElementType.Answer;
                    styles[1].Side = CardElementSides.Back;
                }
            } if (styles.Count == 2) {
                styles[0].Type = CardElementType.Key;
                styles[0].Side = CardElementSides.Front;
                styles[1].Type = CardElementType.Answer;
                styles[1].Side = CardElementSides.Back;
            } else {
                // = 1
                styles[0].Type = CardElementType.Key;
            }
        }

        private bool ExtrapolateType(CardElementStyle style) {
            if ((style.Name.IndexOf("Question") >= 0) || (style.Name.IndexOf("Key") >= 0)) {
                style.Type = CardElementType.Key;
                return false;
            } else if ((style.Name.IndexOf("Answer") >= 0) || (style.Name.IndexOf("Ans") >= 0)) {
                style.Type = CardElementType.Answer;
                return true;
            } else {
                style.Type = CardElementType.Other;
                return false;
            }

        }

        /// <exception cref="System.IndexOutOfRangeException">StyleIndex is out of range</exception>
        public void AddCardField(int styleIndex, string text) {
            this.current.fields.Add(new KeyValuePair<string, string>(this.styles[styleIndex].Name, text));
        }

        public void AddCardField(string styleName, string text) {
            this.current.fields.Add(new KeyValuePair<string, string>(styleName, text));
        }

        public CardDeck Build() {
            if (!ValidateStyleIndices()) {
                FixStyleIndices();
            }

            CardDeck deck = new CardDeck();
            Dictionary<string, CardElementStyle> styleTable = new Dictionary<string, CardElementStyle>();
            foreach (CardElementStyle style in this.styles) {
                deck.AddStyle(style, false);
                styleTable.Add(style.Name, style);
            }
            deck.SortStyles();

            foreach (CardPrototype pt in cards) {
                Card card = new Card(styles, false);
                card.LearnStatus = pt.learnStatus;
                foreach (KeyValuePair<string, string> pair in pt.fields) {
                    card[styleTable[pair.Key]].Text = pair.Value;
                }
                deck.AddCard(card, false);
            }

            return deck;
        }

        void FixStyleIndices() {
            for (int i = 0; i < this.styles.Count; i++) {
                CardElementStyle style = this.styles[i];
                style.Index = i;
            }
        }

        bool ValidateStyleIndices() {
            List<int> indices = new List<int>();

            for (int i = 0; i < this.styles.Count; i++) {
                CardElementStyle style = this.styles[i];
                if (indices.Contains(style.Index)) {
                    Debug.WriteLine("Indices are not valid, duplicate found");
                    return false;
                }
                indices.Add(style.Index);
            }

            return true;
        }
    }
}
