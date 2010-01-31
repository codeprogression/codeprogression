/*************************************************************************
 *  Flash Card Master
 *  Copyleft (C) 2007 Nithin Philips
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
 *  Original FileName :  LaTeXDriver.cs
 *  Created           :  Fri Dec 14 2007
 *  Description       :  
 *************************************************************************/

using System;
using System.IO;
using System.Text;
using LibFlashcard.Model;

namespace LibFlashcard.Drivers
{
    /// <summary>
    /// Writes CardDeck to LaTeX 2e. Output compiles with my MikTeX installation.
    /// </summary>
    public class LaTeXDriver: AbstractDriver
    {
        public static bool ConvertMarkup = true;

        public LaTeXDriver(string path)
            : base(path) {
            base.canDeSerialize = false;
            base.canFullDeserialize = false;
        }

        public override LibFlashcard.Model.CardDeck DeSerialize(Stream stream) {
            // This is not possible because the structure of LaTeX file is unpredictable.
            throw new NotSupportedException("LaTeX files cannot be deserialized.");
        }

        public override void Serialize(System.IO.Stream stream, LibFlashcard.Model.CardDeck deck) {
            // Maybe put this in an external file
            string template = @"\documentclass[12pt,letterpaper,oneside]{{article}}
\usepackage{{ulem}}

\title{{{0}}}
\author{{{1}}}
\date{{\today}}

\begin{{document}}
\maketitle{{}}

\begin{{description}}
	{2}
\end{{description}}

\end{{document}}";

            string title = "Flash Card List";
            string author = System.Environment.UserName;

            StringBuilder sBody = new StringBuilder();

            foreach (Card card in deck.Cards) {
                string otherItems = string.Empty;

                foreach (CardElement element in card.Elements) {
                    if (element.Style.Type == CardElementType.Other) {
                        string text = ConvertMarkup ? WikiText.WikiMarkupParser.WikiTextToLateX(element.Text) : WikiText.WikiMarkupParser.RemoveMarkup(element.Text);
                        otherItems += Environment.NewLine + Environment.NewLine + text;
                    }
                }

                string key = ConvertMarkup ? WikiText.WikiMarkupParser.WikiTextToLateX(card.GetKey()) : WikiText.WikiMarkupParser.RemoveMarkup(card.GetKey());
                string answer = ConvertMarkup ? WikiText.WikiMarkupParser.WikiTextToLateX(card.GetAnswer()) : WikiText.WikiMarkupParser.RemoveMarkup(card.GetAnswer());
                sBody.AppendFormat(@"\item[{0}] {1} {2}{3}", key, answer, otherItems, Environment.NewLine);
            }

            string final = string.Format(template, title, author, sBody.ToString());
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(final.ToString());
            stream.Write(bytes, 0, bytes.Length);

        }


    }
}
