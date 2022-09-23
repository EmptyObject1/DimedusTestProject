using System;
using System.Collections.Generic;
using Packages.Models;
using UnityEngine;

namespace Packages.Controllers
{
    public class DataController : MonoBehaviour
    {
        [SerializeField] private int listLengthValue;
        [SerializeField] private int countLettersValue;

        public ListDataModel FirstListDataModel;
        public ListDataModel SecondListDataModel;

        private void Start()
        {
            SetupDefaultNames();
        }

        private void SetupDefaultNames()
        {
            if(FirstListDataModel!=null)
                FirstListDataModel.ListName = "FirstList";
            else
                FirstListDataModel = new ListDataModel("First List");

            if (SecondListDataModel != null)
                SecondListDataModel.ListName = "SecondList";
            else
                SecondListDataModel = new ListDataModel("SecondList");


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

        public void FillRandomValues()
        {
            SetupDefaultNames();
            if (FirstListDataModel.DataModels.Count == 0) GenerateRandomValues(FirstListDataModel);
            if (SecondListDataModel.DataModels.Count == 0) GenerateRandomValues(SecondListDataModel);
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
            var result = Guid.NewGuid().ToString();
            result = result.Substring(0, countLettersValue % result.Length);
            return result;
        }
    }
}