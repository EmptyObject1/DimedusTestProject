using System.Collections.Generic;
using Packages.Visualizers;

namespace Packages.SortCompareSettings
{
    public class RectTransformComparator : IComparer<DataModelVisualizer>
    {
        public int Compare(DataModelVisualizer x, DataModelVisualizer y)
        {
            if (x.GetRectTransform().anchoredPosition.y < y.GetRectTransform().anchoredPosition.y)
                return 1;
            if (x.GetRectTransform().anchoredPosition.y > y.GetRectTransform().anchoredPosition.y)
                return -1;

            return 0;
        }
    }
}