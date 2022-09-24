using System;
using System.Collections.Generic;

namespace Packages.Models
{
    [Serializable]
    public class ListDataModel
    {
        public string ListName;
        public List<DataModel> DataModels;

        public ListDataModel()
        {
            ListName = string.Empty;
            DataModels = new List<DataModel>();
        }

        public ListDataModel(string listName)
        {
            ListName = listName;
            DataModels = new List<DataModel>();
        }

        public ListDataModel(string listName, List<DataModel> dataModels)
        {
            ListName = listName;
            DataModels = dataModels;
        }
    }
}