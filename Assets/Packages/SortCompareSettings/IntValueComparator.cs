using Packages.Models;

namespace Packages.SortCompareSettings
{
    public class IntValueComparator : IDataModelComparator
    {
        public int Compare(DataModel x, DataModel y)
        {
            return x.IntegerValue - y.IntegerValue;
        }
    }
}