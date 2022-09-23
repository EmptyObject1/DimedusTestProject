using System;
using System.Collections;
using System.Collections.Generic;
using Packages.Models;
using Packages.Visualizers;
using UnityEngine;
using UnityEngine.UI;

namespace Packages.Controllers
{
    public class DragDropController : MonoBehaviour
    {
        [SerializeField] private DataController dataController;
        
        public static DragDropController Instance;

        private RectTransformComparator _comparer;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        private void Start()
        {
            _comparer = new RectTransformComparator();
        }

        public void ResortDataModelVisualizers(ListDataModelVisualizer parentVisualizer)
        {
            SortByAnchoredPositionY(parentVisualizer._currentDataModelVisualizers);



            for (int i = 0; i < parentVisualizer._currentDataModelVisualizers.Count; i++)
            {
                parentVisualizer._currentDataModelVisualizers[i].transform.SetSiblingIndex(i);
                parentVisualizer.CurrentListDataModel.DataModels[i] =
                    parentVisualizer._currentDataModelVisualizers[i].CurrentDataModel;
            }

            parentVisualizer.SetVerticalLayoutGroupStatus(true);
        }

        private void SortByAnchoredPositionY(List<DataModelVisualizer> dataModels)
        {
            dataModels.Sort(_comparer);
        }

        private class RectTransformComparator : IComparer<DataModelVisualizer>
        {
            public int Compare(DataModelVisualizer x, DataModelVisualizer y)
            {
                if (x.GetRectTransform().anchoredPosition.y < y.GetRectTransform().anchoredPosition.y)
                    return 1;
                if (x.GetRectTransform().anchoredPosition.y > y.GetRectTransform().anchoredPosition.y)
                    return -1;
               
                return 0;
            }
        }
    }
}