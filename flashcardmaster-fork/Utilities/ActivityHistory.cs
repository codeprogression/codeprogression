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
 *  Original FileName :  ActivityHistory.cs
 *  Created           :  Tue Oct 03 2006
 *  Description       :  
 *************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCardMaster.Utilities
{
    [Serializable]
    public class ActivityHistory : IEnumerable<string>
    {
	   List<string> items;
	   int maxSize = 0;

	   public string[] Items {
		  get { return items.ToArray(); }
	   }

	   public int Count {
		  get { return items.Count; }
	   }

	   public int MaxSize {
		  get { return maxSize; }
	   }

	   public ActivityHistory() 
		  :this(10){}

	   public ActivityHistory(int maxSize) {
		  this.maxSize = maxSize;
		  items = new List<string>(maxSize);
	   }

	   public string this[int index] {
		  get { return items[index]; }
	   }

	   public ActivityHistory(string[] items) {
		  this.maxSize = items.Length;
		  this.items = new List<string>(maxSize);
		  this.items.AddRange(items);
	   }

	   public void Add(string item) {
		  if (items.Count == maxSize) {
			 // trim oldest
			 items.RemoveAt(0);
		  }

		  for (int i = 0; i < items.Count; i++) {
			 if (string.Compare(items[i], item, true) == 0) {
				// dupe
				MoveToBottom(i);
				return;
			 }
		  }

		  items.Add(item);
	   }

	   public void Remove(string item) {
		  for (int i = 0; i < items.Count; i++) {
			 if (string.Compare(items[i], item, true) == 0) {
				// dupe
				items.RemoveAt(i);
				return;
			 }
		  }
	   }

	   private void MoveToBottom(int index) {
		  for (int i = index; i < items.Count - 1; i++) {
			 // swap
			 string temp = items[i];
		      items[i] = items[i + 1];
			 items[i + 1] = temp;
		  }
	   }

	   public static void Swap<T>(ref T x, ref T y) {
		  T temp = x;
		  x = y;
		  y = temp;
	   }

	   public void Clear() {
		  items.Clear();
	   }

	   #region IEnumerable<string> Members

	   public IEnumerator<string> GetEnumerator() {
		  return items.GetEnumerator();
	   }

	   #endregion

	   #region IEnumerable Members

	   System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
		  return GetEnumerator();
	   }

	   #endregion
    }
}
