using System.Collections.Generic;
using System.Security.Cryptography;
using Packages.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Packages.Visualizers
{
    public class ListDataModelVisualizer : MonoBehaviour
    {
        [SerializeField] private Text listNameText;
        [SerializeField] private Transform listVisualizerContainer;
        [SerializeField] private GameObject dataModelVisualizerPrefab;

        public ListDataModel CurrentListDataModel { get; private set; }

        private List<GameObject> _currentDataModelVisualizers = new List<GameObject>();

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
            listNameText.text = CurrentListDataModel.ListName;
            
            foreach (var dataModel in CurrentListDataModel.DataModels)
            {
                var tempDataModelVisualizer = Instantiate(dataModelVisualizerPrefab.transform, listVisualizerContainer).
                    GetComponent<DataModelVisualizer>();

                if (tempDataModelVisualizer != null)
                {
                    tempDataModelVisualizer.SetupDataModel(dataModel);
                    _currentDataModelVisualizers.Add(tempDataModelVisualizer.gameObject);
                }
            }
        }
    }
}