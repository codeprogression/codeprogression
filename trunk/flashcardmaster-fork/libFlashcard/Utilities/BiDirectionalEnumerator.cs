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
 *  Original FileName :  BiDirectionalEnumerator.cs
 *  Created           :  Tue Oct 03 2006
 *  Description       :  
 *************************************************************************/

using System.Collections.Generic;

namespace LibFlashcard.Utilities
{
    public enum EnumerationOrder { Normal, Random };

    public class BiDirectionalEnumerator<T>: IEnumerator<T>
    {
        T[] array;

        public BiDirectionalEnumerator(List<T> list, EnumerationOrder order) {
            if (order == EnumerationOrder.Random) {
                this.array = list.ToArray();

                // This is the Knuth-Fisher-Yates shuffle algorithm.
                for (int i = array.Length - 1; i > 0; i--) {
                    int n = Utilities.Utility.Rnd.Next(i + 1);
                    Swap(ref array[i], ref array[n]);
                }

            } else {
                this.array = list.ToArray();
            }
            Reset();
        }

        private void Swap(ref T x, ref T y) {
            T tmp = x;
            x = y;
            y = tmp;
        }

        int currentIndex;

        #region IEnumerator<T> Members

        public T Current {
            get { if (!InRange(currentIndex)) { return default(T); } else { return array[currentIndex]; } }
        }

        #endregion

        #region IDisposable Members

        public void Dispose() {

        }

        #endregion

        #region IEnumerator Members

        object System.Collections.IEnumerator.Current {
            get { if (!InRange(currentIndex)) { return null; } else { return array[currentIndex]; } }
        }

        public bool MoveNext() {
            currentIndex++;
            if (!InRange(currentIndex)) {
                currentIndex--;
                return false;
            }
            return true;
        }

        public bool CanMoveNext() {
            return InRange(currentIndex + 1);
        }

        public bool MovePrevious() {
            currentIndex--;
            if (!InRange(currentIndex)) {
                currentIndex++;
                return false;
            }
            return true;
        }

        public bool CanMovePrevious() {
            return InRange(currentIndex - 1);
        }

        private bool InRange(int index) {
            return (index >= 0) && (index < array.Length);
        }

        public void Reset() {
            this.currentIndex = -1;
        }

        public void ResetLast() {
            this.currentIndex = array.Length;
        }

        public int Count {
            get { return array.Length; }
        }

        public int CurrentIndex {
            get { return currentIndex; }
        }

        #endregion
    }
}
