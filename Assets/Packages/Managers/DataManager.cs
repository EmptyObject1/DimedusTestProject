using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Packages.Data
{
    public class DataManager : MonoBehaviour
    {
        [SerializeField] private int listLengthValue;
        [SerializeField] private int countLettersValue;

        public ListDataModel FirstListDataModel;
        public ListDataModel SecondListDataModel;

        private void Start()
        {
            FirstListDataModel = new ListDataModel
            {
                ListName = "First List"
            };

            SecondListDataModel = new ListDataModel
            {
                ListName = "Second List"
            };
        }
        
        #if UNITY_EDITOR
        private void OnValidate()
        {
            if (!gameObject.activeInHierarchy) return;

            if (listLengthValue < 1 || listLengthValue > 100)
                listLengthValue = 1;

            if (countLettersValue < 1 || countLettersValue > 100)
                countLettersValue = 1;
        }
        #endif

        public void FillDefaultValues()
        {
            GenerateRandomValues(FirstListDataModel);
            GenerateRandomValues(SecondListDataModel);
        }

        private void GenerateRandomValues(ListDataModel inputListDataModel)
        {
            DataModel tempDataModel;
            var inputList = new List<DataModel>();

            for (var i = 0; i < listLengthValue; i++)
            {
                tempDataModel = new DataModel(i, GetRandomString());
                inputList.Add(tempDataModel);
            }
            inputListDataModel.DataModels = inputList;
        }


        private string GetRandomString()
        {
            string result = System.Guid.NewGuid().ToString();
            result = result.Substring(0, countLettersValue % result.Length);
            return result;
        }
    }
}