namespace Packages.Data
{
    public class DataModel
    {
        public int IntegerValue { get; set; }
        public string StringValue { get; set; }

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