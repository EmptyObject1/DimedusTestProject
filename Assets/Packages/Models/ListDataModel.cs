using System.Collections.Generic;

namespace Packages.Data
{
    public class ListDataModel
    {
        public string ListName { get; set; }
        public List<DataModel> DataModels { get; set; }

        public ListDataModel()
        {
            ListName = string.Empty;
            DataModels = new List<DataModel>();
        }

        public ListDataModel(string listName, List<DataModel> dataModels)
        {
            ListName = listName;
            DataModels = dataModels;
        }
    }
}