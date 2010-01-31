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
 *  Original FileName :  XfsDriver.cs
 *  Created           :  Fri Dec 14 2007
 *  Description       :  
 *************************************************************************/

using System;
using System.Drawing;
using System.IO;
using System.Text;
using LibFlashcard.Model;
using LibFlashcard.Utilities;
using LibFlashcard.WikiText;

namespace LibFlashcard.Drivers
{
    /// <summary>
    /// Reads and Writes to XFS data format, used by an app called FlashCard Pro.
    /// Only Key and Value items are supported in this format. All other data will be lost.
    /// </summary>
    public class XfsDriver : AbstractDriver
    {
	   const string XFS_SEPARATOR = " -=- ";

	   public XfsDriver(string path)
		  : base(path) {
		  base.canDeSerialize = true;
		  base.canFullDeserialize = false;
	   }


	   public override LibFlashcard.Model.CardDeck DeSerialize(System.IO.Stream stream) {
		  CardDeckBuilder builder = new CardDeckBuilder();

		  builder.AddStyle(new CardElementStyle(0, "Key", SystemColors.ControlText, Color.Transparent, CardElementPositions.Center, CardElementSides.Front, CardElementType.Key));
		  builder.AddStyle(new CardElementStyle(1, "Answer", SystemColors.ControlText, Color.Transparent, CardElementPositions.Center, CardElementSides.Back, CardElementType.Answer));

		  string[] splitters = new string[] { XFS_SEPARATOR };

		  StreamReader sr = new StreamReader(stream, true);
		  
		  while (sr.Peek() >= 0) {
			 string[] kvPair = sr.ReadLine().Split(splitters, StringSplitOptions.RemoveEmptyEntries);
			 if (kvPair.Length == 2) {
				builder.BeginCard(CardLearningStaus.NotLearned);
				builder.AddCardField(0, kvPair[0]);
				builder.AddCardField(1, kvPair[1]);
				builder.EndCard();
			 }
		  }

		  return builder.Build();
	   }

	   public override void Serialize(System.IO.Stream stream, LibFlashcard.Model.CardDeck deck) {
		  StreamWriter sw = new StreamWriter(stream, Encoding.UTF8);
		  for (int i = 0; i < deck.Cards.Count; i++) {
			 sw.WriteLine("{0}{1}{2}", WikiMarkupParser.RemoveMarkup(deck.Cards[i].GetKey()),
								    XFS_SEPARATOR,
								    WikiMarkupParser.RemoveMarkup(deck.Cards[i].GetAnswer()));
		  }
		  sw.Flush();
	   }
    }
}
