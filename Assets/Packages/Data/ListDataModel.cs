using System.Collections.Generic;

namespace Packages.Data
{
    public class ListDataModel
    {
        public string ListName { get; set; }
        public List<DataModel> DataModelsList { get; set; }

        public ListDataModel()
        {
            ListName = string.Empty;
            DataModelsList = new List<DataModel>();
        }

        public ListDataModel(string listName, List<DataModel> dataModelsList)
        {
            ListName = listName;
            DataModelsList = dataModelsList;
        }
    }
}