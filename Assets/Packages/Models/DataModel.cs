using System;

namespace Packages.Models
{
    [Serializable]
    public class DataModel
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
    }
}