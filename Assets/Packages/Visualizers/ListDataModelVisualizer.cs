using System;
using System.Collections.Generic;
using Packages.Models;
using Packages.SortCompareSettings;
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
        [SerializeField] private VerticalLayoutGroup verticalLayoutGroup;

        [Header("Service controls")] 
        [SerializeField] private Toggle intSortToggle;
        [SerializeField] private Toggle stringSortToggle;
        [SerializeField] private Dropdown sortTypeDropdown;

        public List<DataModelVisualizer> CurrentDataModelVisualizers = new List<DataModelVisualizer>();

        private IDataModelComparator _dataModelComparator;
        private RectTransformComparator _rectTransformComparator;
        private SortType _sortType;
        public ListDataModel CurrentListDataModel { get; private set; }

        private void Start()
        {
            AddListeners();
            _rectTransformComparator = new RectTransformComparator();
        }

        private void AddListeners()
        {
            intSortToggle.onValueChanged.AddListener(SetupIntSort);
            stringSortToggle.onValueChanged.AddListener(SetupStringSort);
            sortTypeDropdown.onValueChanged.AddListener(SetupSortType);
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

        private void SetupSortType(int selectedItem)
        {
            switch (selectedItem)
            {
                case 0:
                    _sortType = SortType.Asc;
                    break;
                case 1:
                    _sortType = SortType.Desc;
                    break;
                default:
                    throw new Exception("Unknown sort type detected");
            }
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

        public void ClearPreviousVisualizers()
        {
            foreach (var currentVisualizer in CurrentDataModelVisualizers)
                Destroy(currentVisualizer.gameObject);

            CurrentDataModelVisualizers.Clear();
            elementsCountText.text = string.Empty;
        }


        private void UpdateView()
        {
            listNameInputField.text = CurrentListDataModel.ListName;
            ShowElementsCount();
            SortList();

            foreach (var dataModel in CurrentListDataModel.DataModels)
            {
                var tempDataModelVisualizer = Instantiate(dataModelVisualizerPrefab.transform, listVisualizerContainer)
                    .GetComponent<DataModelVisualizer>();

                if (tempDataModelVisualizer != null)
                {
                    tempDataModelVisualizer.SetupDataModel(dataModel, this);
                    CurrentDataModelVisualizers.Add(tempDataModelVisualizer);
                    tempDataModelVisualizer.RewriteDefaultPositionX();
                }
            }
        }


        private void ShowElementsCount()
        {
            elementsCountText.text = $"Elements count: {CurrentListDataModel.DataModels.Count}";
        }

        private void SortList()
        {
            CurrentListDataModel.DataModels.Sort(_dataModelComparator);

            if (_sortType == SortType.Desc)
                CurrentListDataModel.DataModels.Reverse();
        }

        public void RebuildDataModels()
        {
            SetVerticalLayoutGroupStatus(false);
            for (var i = 0; i < CurrentListDataModel.DataModels.Count; i++)
            {
                CurrentDataModelVisualizers[i].transform.SetSiblingIndex(i);
                CurrentListDataModel.DataModels[i] = CurrentDataModelVisualizers[i].CurrentDataModel;
            }

            ShowElementsCount();

            SetVerticalLayoutGroupStatus(true);
            
            foreach (var visualizer in CurrentDataModelVisualizers) 
                visualizer.RewriteDefaultPositionX();
        }

        public void SortByAnchoredPositionY()
        {
            CurrentDataModelVisualizers.Sort(_rectTransformComparator);
        }

        public void SetVerticalLayoutGroupStatus(bool status)
        {
            verticalLayoutGroup.enabled = status;
        }

        public string GetListName()
        {
            return listNameInputField.text;
        }

        public Transform GetListVisualizerContainer()
        {
            return listVisualizerContainer;
        }
    }
}