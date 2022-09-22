using System.Collections.Generic;
using Packages.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Packages.Visualizers
{
    public class ListDataModelVisualizer : MonoBehaviour
    {
        [SerializeField] private InputField listNameInputField;
        [SerializeField] private Transform listVisualizerContainer;
        [SerializeField] private GameObject dataModelVisualizerPrefab;

        private readonly List<GameObject> _currentDataModelVisualizers = new List<GameObject>();

        public ListDataModel CurrentListDataModel { get; private set; }

        public void SetupListDataModel(ListDataModel listDataModel)
        {
            if (listDataModel != null)
            {
                foreach (var currentGameObject in _currentDataModelVisualizers)
                    Destroy(currentGameObject);

                _currentDataModelVisualizers.Clear();

                CurrentListDataModel = listDataModel;
                UpdateView();
            }
        }

        private void UpdateView()
        {
            listNameInputField.text = CurrentListDataModel.ListName;

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