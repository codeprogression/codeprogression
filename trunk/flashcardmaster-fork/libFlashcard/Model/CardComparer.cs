using System;
using System.Collections.Generic;
using System.Text;
using LibFlashcard.Utilities;

namespace LibFlashcard.Model
{
    public class CardComparer: IComparer<Card>
    {
        public CardComparer(SortOrder order, int fieldIndex) {
            this.sortOrder = order;
            this.fieldIndex = fieldIndex;
        }

        int fieldIndex;
        SortOrder sortOrder;
        StringComparer strComparer = StringComparer.CurrentCulture;

        #region IComparer<Card> Members

        public int Compare(Card x, Card y) {
            int index = 0;
            if (sortOrder == SortOrder.Ascending) {
                index = strComparer.Compare(x[fieldIndex].Text, y[fieldIndex].Text);
            } else if (sortOrder == SortOrder.Descending) {
                index = strComparer.Compare(x[fieldIndex].Text, y[fieldIndex].Text);
                index = -index;
            }
            return index;
        }

        #endregion

        public int FieldIndex {
            get { return this.fieldIndex; }
        }

        public SortOrder SortOrder {
            get { return this.sortOrder; }
        }
    }
}
