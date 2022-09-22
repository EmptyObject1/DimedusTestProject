﻿using Packages.Visualizers;
using UnityEngine;
using UnityEngine.UI;

namespace Packages.Data
{
    public class LoadSaveManager : MonoBehaviour
    {
        [Header("LoadSave controls")] 
        [SerializeField] private Button loadDataButton;
        [SerializeField] private Button saveDataButton;
        [SerializeField] private Toggle autoGenerateDataToggle;
        [SerializeField] private TextAsset firstListFile;
        [SerializeField] private TextAsset secondListFile;

        [Header("DataModel controls")] 
        [SerializeField] private DataManager dataManager;
        [SerializeField] private ListDataModelVisualizer firstListVisualizer;
        [SerializeField] private ListDataModelVisualizer secondListVisualizer;
        [SerializeField] private DataModelVisualizer dataModelVisualizerPrefab;

        private void Start()
        {
            loadDataButton.onClick.AddListener(LoadData);
            saveDataButton.onClick.AddListener(SaveData);
        }

        private void LoadData()
        {
            dataManager.FirstListDataModel = JsonManager.LoadFromJson(firstListFile);
            dataManager.SecondListDataModel = JsonManager.LoadFromJson(secondListFile);

            if (autoGenerateDataToggle.isOn)
                dataManager.FillRandomValues();

            InstantiateVisualizers(dataManager.FirstListDataModel, firstListVisualizer);
            InstantiateVisualizers(dataManager.SecondListDataModel, secondListVisualizer);
        }

        private void SaveData()
        {
            dataManager.FirstListDataModel.ListName = firstListVisualizer.GetListName();
            dataManager.SecondListDataModel.ListName = secondListVisualizer.GetListName();
            
            JsonManager.SaveToJson(dataManager.FirstListDataModel, firstListFile);
            JsonManager.SaveToJson(dataManager.SecondListDataModel, secondListFile);
        }


        private void InstantiateVisualizers(ListDataModel listDataModel,
            ListDataModelVisualizer listDataModelVisualizer)
        {
            listDataModelVisualizer.SetupListDataModel(listDataModel);
        }
    }
}