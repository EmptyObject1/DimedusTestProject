using System.IO;
using UnityEditor;
using UnityEngine;

namespace Packages.Data
{
    public static class JsonManager
    {
        public static void SaveToJson(ListDataModel listDataModel, TextAsset fileForSave)
        {
            using (StreamWriter stream = new StreamWriter(GetFilePath(fileForSave)))
            {
                string json = JsonUtility.ToJson(listDataModel);
                stream.Write(json);
            }
        }

        public static ListDataModel LoadFromJson(TextAsset fileForLoad)
        {
            using (StreamReader stream = new StreamReader(GetFilePath(fileForLoad)))
            {
                var content = stream.ReadToEnd();
                ListDataModel result = new ListDataModel();
                result = JsonUtility.FromJson<ListDataModel>(content);

                return result ?? new ListDataModel();
            }
        }

        private static string GetFilePath(TextAsset file)
        {
            return AssetDatabase.GetAssetPath(file);
        }
      
    }
}