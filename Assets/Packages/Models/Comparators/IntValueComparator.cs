using System;

namespace Packages.Models.Comparators
{
    public class IntValueComparator : IDataModelComparator
    {
        public int Compare(DataModel x, DataModel y)
        {
            return x.IntegerValue - y.IntegerValue;
        }
    }
}