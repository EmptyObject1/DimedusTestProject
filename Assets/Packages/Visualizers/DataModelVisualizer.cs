using System;
using Packages.Models;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Packages.Visualizers
{
    [RequireComponent(typeof(RectTransform))]
    public class DataModelVisualizer : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        [SerializeField] private Text intValueText;
        [SerializeField] private Text stringValueText;

        private RectTransform _rectTransform;
        public DataModel CurrentDataModel { get; private set; }

        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        public void SetupDataModel(DataModel dataModel)
        {
            CurrentDataModel = dataModel;
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
            _rectTransform.SetAsLastSibling();
        }

        public void OnEndDrag(PointerEventData eventData)
        {
           
        }
    }
}