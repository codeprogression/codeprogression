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
 *  Original FileName :  CardDriver.cs
 *  Created           :  Fri Oct 06 2006
 *  Description       :  
 *************************************************************************/

using System.Runtime.Serialization.Formatters.Binary;
using LibFlashcard.Model;

namespace LibFlashcard.Drivers
{
    /// <summary>
    /// Read and Writes CardDeck using System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
    /// </summary>
    public class CardDriver: AbstractDriver
    {
        public CardDriver(string path)
            : base(path) { }

        public override LibFlashcard.Model.CardDeck DeSerialize(System.IO.Stream stream) {
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stream) as CardDeck;
        }

        public override void Serialize(System.IO.Stream stream, LibFlashcard.Model.CardDeck deck) {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, deck);
        }
    }
}
