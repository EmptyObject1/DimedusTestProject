using System;

namespace Packages.Models
{
    [Serializable]
    public class DataModel : IComparable
    {
        public int IntegerValue;
        public string StringValue;

        public DataModel()
        {
            IntegerValue = 0;
            StringValue = string.Empty;
        }

        public DataModel(int integerValue, string stringValue)
        {
            IntegerValue = integerValue;
            StringValue = stringValue;
        }

        //Not worked, because IComparer<T> has high priority, but implementation need for using other Comparator.
        public int CompareTo(object obj)
        {
            return 0;
        }
    }
}