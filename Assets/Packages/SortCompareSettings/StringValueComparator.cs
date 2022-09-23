using System;
using Packages.Models;

namespace Packages.SortCompareSettings
{
    public class StringValueComparator : IDataModelComparator
    {
        public int Compare(DataModel x, DataModel y)
        {
            return string.Compare(x.StringValue, y.StringValue, StringComparison.Ordinal);
        }
    }
}