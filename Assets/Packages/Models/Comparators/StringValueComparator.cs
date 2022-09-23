using System;

namespace Packages.Models.Comparators
{
    public class StringValueComparator : IDataModelComparator
    {
        public int Compare(DataModel x, DataModel y)
        {
            return string.Compare(x.StringValue, y.StringValue, StringComparison.Ordinal);
        }
    }
}