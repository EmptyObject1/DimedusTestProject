﻿using Packages.Models;
using Packages.Visualizers;
using UnityEngine;
using UnityEngine.UI;

namespace Packages.Controllers
{
    public class LoadSaveController : MonoBehaviour
    {
        [Header("LoadSave controls")] 
        [SerializeField] private Button loadDataButton;
        [SerializeField] private Button saveDataButton;
        [SerializeField] private Toggle autoGenerateDataToggle;
        [SerializeField] private TextAsset firstListFile;
        [SerializeField] private TextAsset secondListFile;

        [Header("DataModel controls")] 
        [SerializeField] private DataController dataController;
        [SerializeField] private ListDataModelVisualizer firstListVisualizer;
        [SerializeField] private ListDataModelVisualizer secondListVisualizer;
       
        private void Start()
        {
            loadDataButton.onClick.AddListener(LoadData);
            saveDataButton.onClick.AddListener(SaveData);
        }

        private void LoadData()
        {
            dataController.FirstListDataModel = JsonController.LoadFromJson(firstListFile);
            dataController.SecondListDataModel = JsonController.LoadFromJson(secondListFile);

            if (autoGenerateDataToggle.isOn)
                dataController.FillRandomValues();

            InstantiateVisualizers(dataController.FirstListDataModel, firstListVisualizer);
            InstantiateVisualizers(dataController.SecondListDataModel, secondListVisualizer);
        }

        private void SaveData()
        {
            dataController.FirstListDataModel.ListName = firstListVisualizer.GetListName();
            dataController.SecondListDataModel.ListName = secondListVisualizer.GetListName();
            
            JsonController.SaveToJson(dataController.FirstListDataModel, firstListFile);
            JsonController.SaveToJson(dataController.SecondListDataModel, secondListFile);
        }


        private void InstantiateVisualizers(ListDataModel listDataModel,
            ListDataModelVisualizer listDataModelVisualizer)
        {
            listDataModelVisualizer.SetupListDataModel(listDataModel);
        }

        public ListDataModelVisualizer GetFirstDataModelVisualizer()
        {
            return firstListVisualizer;
        }
        public ListDataModelVisualizer GetSecondDataModelVisualizer()
        {
            return secondListVisualizer;
        }
        
    }
}