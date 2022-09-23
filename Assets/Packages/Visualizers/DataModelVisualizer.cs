using System;
using Packages.Controllers;
using Packages.Models;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Packages.Visualizers
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(Canvas))]
    public class DataModelVisualizer : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        [SerializeField] private Text intValueText;
        [SerializeField] private Text stringValueText;
        public DataModel CurrentDataModel { get; private set; }
        
        private RectTransform _rectTransform;
        private Canvas _canvas;
        private ListDataModelVisualizer _parentVisualizer;

        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvas = GetComponent<Canvas>();
        }

        public RectTransform GetRectTransform()
        {
            return _rectTransform;
        }

        public void SetupDataModel(DataModel dataModel, ListDataModelVisualizer parentVisualizer)
        {
            CurrentDataModel = dataModel;
            _parentVisualizer = parentVisualizer;
            UpdateView();
        }

        private void UpdateView()
        {
            intValueText.text = CurrentDataModel.IntegerValue.ToString();
            stringValueText.text = CurrentDataModel.StringValue;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _canvas.sortingOrder++;
            _parentVisualizer.SetVerticalLayoutGroupStatus(false);
        }

        public void OnEndDrag(PointerEventData eventData)
        { 
            _canvas.sortingOrder--;
            DragDropController.Instance.ResortDataModelVisualizers(_parentVisualizer);
        }
    }
}