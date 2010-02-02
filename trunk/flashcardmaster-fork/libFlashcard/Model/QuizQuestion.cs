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
using System.Linq;
using LibFlashcard.Utilities;

namespace LibFlashcard.Model
{
    public class QuizQuestion
    {
        public const int PossibleChoices = 4;
        public int ResposeIndex { get; set; }
        public string Question { get; private set; }
        public int AnswerIndex { get; private set; }
        public string[] Choices { get; private set; }
        public QuizQuestion()
        {
            ResposeIndex = -1;
            Choices = new string[PossibleChoices];
            AnswerIndex = Utility.Rnd.Next(0, PossibleChoices);
        }

        public QuizQuestion(Card card, IEnumerable<string> getIncorrectAnswers)
            : this()
        {
            Question = card.GetKey();
            Choices[AnswerIndex] = card.GetAnswer();
            AddIncorrectAnswers(getIncorrectAnswers);
        }

        private void AddIncorrectAnswers(IEnumerable<string> incorrectAnswers)
        {
            var i = 0;
            foreach (var incorrectAnswer in incorrectAnswers)
            {
                if (i==AnswerIndex) i++;
                Choices[i] = incorrectAnswer;
                i++;
            }
        }
        
    }
}