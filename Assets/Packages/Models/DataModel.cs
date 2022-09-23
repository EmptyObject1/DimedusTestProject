using System;
using Packages.Models.Comparators;
using UnityEngine;

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

        public int CompareTo(object obj)
        {
            return 0;
        }
    }
}