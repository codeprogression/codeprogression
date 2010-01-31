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
 *  Original FileName :  QuizQuestion.cs
 *  Created           :  Tue Oct 03 2006
 *  Description       :  
 *************************************************************************/

using System;
using System.Collections.Generic;
using LibFlashcard.Utilities;

namespace LibFlashcard.Model
{
    public class QuizQuestion
    {
        private string question;
        private int answerIndex;
        private string[] choices;
        private int resposeIndex = -1;

        public int ResposeIndex {
            get { return resposeIndex; }
            set { resposeIndex = value; }
        }

        public string Question {
            get { return this.question; }
            set { this.question = value; }
        }

        public int AnswerIndex {
            get { return this.answerIndex; }
            set { this.answerIndex = value; }
        }

        public string[] Choices {
            get { return this.choices; }
            set { this.choices = value; }
        }

        public static QuizQuestion FromCard(Card card, List<Card> cards) {
            int[] indices = new int[3];

            if (cards.Count <= indices.Length) { throw new ArgumentException("There are not enough cards in the array. At least " + (indices.Length + 1).ToString() + " cards are necessary.", "cards"); }

            // Pick random cards
            for (int i = 0; i < indices.Length; i++) {
                do {
                    int index = Utility.Rnd.Next(0, cards.Count);
                    if (cards[index] != card) {
                        for (int j = i - 1; j >= 0; j--) {
                            if (indices[j] == index) {
                                // if index is a duplicate, do the while loop again
                                continue;
                            }
                        }
                        indices[i] = index;
                        break;
                    }
                } while (true);
            }

            QuizQuestion q = new QuizQuestion();
            q.Question = card.GetKey();
            q.Choices = new string[indices.Length + 1];
            q.answerIndex = Utility.Rnd.Next(0, q.choices.Length);
            q.choices[q.answerIndex] = card.GetAnswer();
            int indicesIndex = 0;
            for (int i = 0; i < q.choices.Length; i++) {
                if (i == q.answerIndex) { continue; }
                q.choices[i] = cards[indices[indicesIndex]].GetAnswer();
                indicesIndex++;
            }
            return q;
        }
    }
}
