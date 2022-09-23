using System;
using System.Collections.Generic;
using Packages.Models;
using Packages.Models.Comparators;
using UnityEngine;
using UnityEngine.UI;

namespace Packages.Visualizers
{
    public class ListDataModelVisualizer : MonoBehaviour
    {
        [Header("DataModel controls")]
        [SerializeField] private InputField listNameInputField;
        [SerializeField] private Text elementsCountText;
        [SerializeField] private Transform listVisualizerContainer;
        [SerializeField] private GameObject dataModelVisualizerPrefab;

        [Header("Service controls")] 
        [SerializeField] private Toggle intSortToggle;
        [SerializeField] private Toggle stringSortToggle;
        [SerializeField] private Dropdown sortTypeDropdown;
        
        
        private readonly List<GameObject> _currentDataModelVisualizers = new List<GameObject>();
        private IDataModelComparator _dataModelComparator;

        public ListDataModel CurrentListDataModel { get; private set; }


        private void Start()
        {
            intSortToggle.onValueChanged.AddListener(SetupIntSort);
            stringSortToggle.onValueChanged.AddListener(SetupStringSort);
        }

        private void SetupIntSort(bool status)
        {
            intSortToggle.isOn = status;
            stringSortToggle.isOn = !status;
            _dataModelComparator = new IntValueComparator();
        }
        
        private void SetupStringSort(bool status)
        {
            stringSortToggle.isOn = status;
            intSortToggle.isOn = !status;
            _dataModelComparator = new StringValueComparator();
        }
        
        public void SetupListDataModel(ListDataModel listDataModel)
        {
            if (listDataModel != null)
            {
                ClearPreviousVisualizers();

                CurrentListDataModel = listDataModel;
                UpdateView();
            }
        }

        private void ClearPreviousVisualizers()
        {
            foreach (var currentGameObject in _currentDataModelVisualizers)
                Destroy(currentGameObject);

            _currentDataModelVisualizers.Clear();
        }

        private void UpdateView()
        {
            listNameInputField.text = CurrentListDataModel.ListName;
            elementsCountText.text = $"Elements count: {CurrentListDataModel.DataModels.Count}";

            var a = CurrentListDataModel.DataModels.ToArray();
            CurrentListDataModel.DataModels.Sort(_dataModelComparator);

            foreach (var dataModel in CurrentListDataModel.DataModels)
            {
                var tempDataModelVisualizer = Instantiate(dataModelVisualizerPrefab.transform, listVisualizerContainer)
                    .GetComponent<DataModelVisualizer>();

                if (tempDataModelVisualizer != null)
                {
                    tempDataModelVisualizer.SetupDataModel(dataModel);
                    _currentDataModelVisualizers.Add(tempDataModelVisualizer.gameObject);
                }
            }
        }

        public string GetListName()
        {
            return listNameInputField.text;
        }
    }
}