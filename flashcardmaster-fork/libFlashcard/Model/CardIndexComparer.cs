using System;
using System.Collections.Generic;
using System.Text;
using LibFlashcard.Utilities;

namespace LibFlashcard.Model
{
    public class CardIndexComparer: IComparer<Card>
    {
        public CardIndexComparer(SortOrder order) {
            this.sortOrder = order;
        }

        SortOrder sortOrder;

        #region IComparer<Card> Members

        public int Compare(Card x, Card y) {
            int index = 0;
            if (sortOrder == SortOrder.Ascending) {
                index = x.Index.CompareTo(y.Index);
            } else if (sortOrder == SortOrder.Descending) {
                index = x.Index.CompareTo(y.Index);
                index = -index;
            }
            return index;
        }

        #endregion

        public SortOrder SortOrder {
            get { return this.sortOrder; }
        }
    }
}
