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
 *  Original FileName :  CsvDriver.cs
 *  Created           :  Thu Oct 05 2006
 *  Description       :  
 *************************************************************************/

using System;
using System.Drawing;
using System.IO;
using System.Text;
using LibFlashcard.Model;
using LibFlashcard.Utilities;
using LumenWorks.Framework.IO.Csv;

namespace LibFlashcard.Drivers
{
    /// <summary>
    /// Read and Writes CardDeck using CSV file format
    /// </summary>
    public class CsvDriver: AbstractDriver
    {
        /*
         * The CSV format is lossy. CardElementStyle information cannot be saved
         * to CSV. 
         */

        public static char CsvSeparator = ',';
        public static bool PreserveNewLinesInCsv = true;

        public CsvDriver(string path)
            : base(path) {
            this.canFullDeserialize = false;
        }

        public override LibFlashcard.Model.CardDeck DeSerialize(System.IO.Stream stream) {
            CardDeckBuilder builder = new CardDeckBuilder();

            using (CsvReader csv = new CsvReader(new StreamReader(stream), true, CsvSeparator)) {
                csv.SupportsMultiline = true;

                int fieldCount = csv.FieldCount;

                string[] headers = csv.GetFieldHeaders();
                for (int i = 0; i < headers.Length; i++) {
                    builder.AddStyle(new CardElementStyle(i, headers[i], SystemColors.ControlText, Color.Transparent, CardElementPositions.Center, CardElementSides.Front, CardElementType.Other));
                }

                builder.AutoCategorizeStyles();

                while (csv.ReadNextRecord()) {
                    builder.BeginCard(CardLearningStaus.NotLearned);
                    for (int i = 0; i < fieldCount; i++) {
                        builder.AddCardField(headers[i], csv[i]);
                    }
                    builder.EndCard();
                }
            }

            return builder.Build();
        }

        public override void Serialize(System.IO.Stream stream, LibFlashcard.Model.CardDeck deck) {
            StringBuilder sb = new StringBuilder();
            deck.GetCSVHeader(sb, CsvSeparator);
            sb.Append(Environment.NewLine);
            for (int i = 0; i < deck.Cards.Count; i++) {
                deck.Cards[i].ToCSVString(sb, CsvSeparator, PreserveNewLinesInCsv);
                sb.Append(Environment.NewLine);
            }
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
            stream.Write(bytes, 0, bytes.Length);
        }
    }
}
