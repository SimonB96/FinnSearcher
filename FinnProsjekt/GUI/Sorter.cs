using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public class Sorter : IComparer
    {
        private int pointsColumnIndex;
        private SortOrder _sortOrder;

        public Sorter(SortOrder sortOrder, int index)
        {
            _sortOrder = sortOrder;
            pointsColumnIndex = index;
        }

        public int Compare(object x, object y)
        {
            string test = ((ListViewItem)x).SubItems[pointsColumnIndex].Text;
            string test2 = ((ListViewItem)y).SubItems[pointsColumnIndex].Text;
            int pointsX = Int32.Parse(new string(test.Where(Char.IsDigit).ToArray()));
            int pointsY = Int32.Parse(new string(test2.Where(Char.IsDigit).ToArray()));
            int comparisonResult = pointsX.CompareTo(pointsY);

            switch (_sortOrder)
            {
                case SortOrder.Ascending:
                    return comparisonResult;
                case SortOrder.Descending:
                    return (-1) * comparisonResult;
                default:
                    return 0;
            }
        }
    }
}
