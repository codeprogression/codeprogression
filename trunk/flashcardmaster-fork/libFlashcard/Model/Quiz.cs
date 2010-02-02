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
 *  Original FileName :  Quiz.cs
 *  Created           :  Tue Oct 03 2006
 *  Description       :  
 *************************************************************************/

using System.Collections;
using System.Collections.Generic;
using LibFlashcard.Utilities;

namespace LibFlashcard.Model
{
    public class Quiz : IEnumerable<QuizQuestion>
    {
        protected Quiz()
        {
            Questions = new List<QuizQuestion>();
        }
        public Quiz(IList<QuizQuestion> questions)
        {
            Questions = questions;
        }

        public IList<QuizQuestion> Questions { get; private set;}

        #region IEnumerable<QuizQuestion> Members

        public IEnumerator<QuizQuestion> GetEnumerator()
        {
            return GetEnumerator(EnumerationOrder.Normal);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(EnumerationOrder.Normal);
        }

        #endregion

        public BiDirectionalEnumerator<QuizQuestion> GetEnumerator(EnumerationOrder order)
        {
            return new BiDirectionalEnumerator<QuizQuestion>(new List<QuizQuestion>(Questions), order);
        }

        public static bool IsDeckValid(CardDeck deck)
        {
            bool hasKey = false, hasAnswer = false;

            foreach (var style in deck.Styles)
            {
                if (style.Type == CardElementType.Key)
                {
                    hasKey = true;
                }
                if (style.Type == CardElementType.Answer)
                {
                    hasAnswer = true;
                }
            }

            return hasKey && hasAnswer;
        }
    }

    public class MultipleChoiceQuiz : Quiz
    {
        public MultipleChoiceQuiz(List<Card> cards) 
        {
            cards.ForEach(card=> Questions.Add(card.CreateQuizQuestion(card, cards)));
        }
    }
}