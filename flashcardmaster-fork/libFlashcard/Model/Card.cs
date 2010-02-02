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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

namespace LibFlashcard.Model
{
    [Serializable]
    public class Card : IEnumerable<CardElement>
    {
        private readonly List<CardElement> _elements = new List<CardElement>();

        public Card()
        {
            LearnStatus = CardLearningStaus.NotLearned;
        }

        public Card(IEnumerable<CardElementStyle> styles)
            : this(styles, true)
        {
        }

        public Card(IEnumerable<CardElementStyle> styles, bool fillValues)
        {
            LearnStatus = CardLearningStaus.NotLearned;
            foreach (var style in styles)
                Add(style, fillValues ? style.Name : string.Empty);
        }

        public int Index { get; set; }
        public int Count { get { return _elements.Count; } }
        public CardLearningStaus LearnStatus { get; set; }

        public bool Enabled
        {
            get { return LearnStatus > 0; }
            set { LearnStatus = value ? CardLearningStaus.NotLearned : CardLearningStaus.Learned; }
        }

        public CardElement this[int index]
        {
            get { return _elements[index]; }
        }

        public CardElement this[CardElementStyle style]
        {
            get { return _elements.FirstOrDefault(element => element.Style == style); }
        }

        public ReadOnlyCollection<CardElement> Elements
        {
            get { return _elements.AsReadOnly(); }
        }

        #region IEnumerable<CardElement> Members

        public IEnumerator<CardElement> GetEnumerator()
        {
            return _elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _elements.GetEnumerator();
        }

        #endregion

        public void Add(CardElementStyle style, params string[] elements)
        {
            foreach (var element in elements)
                _elements.Add(new CardElement(element,style));
            Sort();
        }

        public void Remove(CardElementStyle style)
        {
            _elements.RemoveAll(x => x.Style == style);
            Sort();
        }

        public void Sort()
        {
            _elements.Sort();
        }

        /// <summary>
        /// Gets the Key field, if any, of this Card.
        /// </summary>
        /// <returns>The value of the Key field.</returns>
        public string GetKey()
        {
            return GetType(CardElementType.Key);
        }

        /// <summary>
        /// Gets the Answer field, if any, of this Card.
        /// </summary>
        /// <returns>The value of the Answer field.</returns>
        public string GetAnswer()
        {
            return GetType(CardElementType.Answer);
        }


        private string GetType(CardElementType type)
        {
            var element = _elements.FirstOrDefault(x => x.Style.Type == type);
            return element != null ? element.Text : string.Empty;
        }

        public override string ToString()
        {
            var element = _elements.SingleOrDefault(x => x.Style.Type == CardElementType.Key);
            return _elements != null ? element.Text : ToCSVString(',', false);
        }

        public string ToCSVString(char separator, bool preserveLinesInCsv)
        {
            var sb = new StringBuilder();
            ToCSVString(sb, separator, preserveLinesInCsv);
            return sb.ToString();
        }

        public void ToCSVString(StringBuilder sb, char separator, bool preserveLinesInCsv)
        {
            for (int i = 0; i < _elements.Count; i++)
            {
                string text = _elements[i].Text;
                if (!preserveLinesInCsv)
                {
                    text = text.Replace(Environment.NewLine, string.Empty);
                }
                if (NeedQuote(text, separator))
                {
                    sb.AppendFormat("\"{0}\"", text);
                }
                else
                {
                    sb.Append(text);
                }
                if (i != _elements.Count - 1)
                {
                    sb.Append(separator);
                }
            }
        }

        private bool NeedQuote(string s, char separator)
        {
            if (s.IndexOf(separator) >= 0)
                return true;
            return s.IndexOf(Environment.NewLine) >= 0;
        }

        public Dictionary<CardElementPositions, List<CardElement>> GroupElementsByPosition(CardElementSides side)
        {
            var result = new Dictionary<CardElementPositions, List<CardElement>>();

            _elements.ForEach(element =>
            {
                    List<CardElement> list;
                    if (!result.TryGetValue(element.Style.Position, out list))
                    {
                        list = new List<CardElement>();
                        result.Add(element.Style.Position, list);
                    }
                    if ((element.Style.Side & side) == side)
                    {
                        list.Add(element);
                    }
            });

            return result;
        }


        private Random _random;
        public QuizQuestion CreateQuizQuestion(Card card, List<Card> cards)
        {
            return new QuizQuestion(card, GetIncorrectAnswers(card.GetAnswer(), cards));
        }

        private IEnumerable<string> GetIncorrectAnswers(string answer, IEnumerable<Card> cards)
        {
            _random = new Random();
            var incorrectAnswers =
                   cards.Where(c => answer != c.GetAnswer())
                       .Select(x => x.GetAnswer())
                       .Distinct()
                       .ToList();

            var choices = QuizQuestion.PossibleChoices;
            if (incorrectAnswers.Count() < choices - 1)
                throw new ArgumentException(
                    string.Format(
                        "There are not enough cards in the array. " +
                        "At least {0} cards with unique answers are necessary.",
                        choices),
                    "cards");

            for (var i = 0; i < 3; i++)
            {
                var index = _random.Next(incorrectAnswers.Count);
                yield return incorrectAnswers[index];
                incorrectAnswers.RemoveAt(index);
            }
        }
    }
}