using System.IO;
using Packages.Models;
using UnityEditor;
using UnityEngine;

namespace Packages.Controllers
{
    public static class JsonController
    {
        public static void SaveToJson(ListDataModel listDataModel, TextAsset fileForSave)
        {
            using (var stream = new StreamWriter(GetFilePath(fileForSave)))
            {
                var json = JsonUtility.ToJson(listDataModel);
                stream.Write(json);
            }
        }

        public static ListDataModel LoadFromJson(TextAsset fileForLoad)
        {
            using (var stream = new StreamReader(GetFilePath(fileForLoad)))
            {
                var content = stream.ReadToEnd();
                var result = JsonUtility.FromJson<ListDataModel>(content);

                return result ?? new ListDataModel();
            }
        }

        private static string GetFilePath(TextAsset file)
        {
            return AssetDatabase.GetAssetPath(file);
        }
    }
}