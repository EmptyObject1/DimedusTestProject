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
        
        private Canvas _canvas;
        private float _defaultPositionX;
        private ListDataModelVisualizer _parentVisualizer;
        private RectTransform _rectTransform;
        
        public DataModel CurrentDataModel { get; private set; }

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvas = GetComponent<Canvas>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _canvas.sortingOrder++;
            _defaultPositionX = _rectTransform.anchoredPosition.x;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _canvas.sortingOrder--;
            DragDropController.Instance.ResortDataModelVisualizers(this);
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

        public ListDataModelVisualizer GetParentVisualizer()
        {
            return _parentVisualizer;
        }

        public void SetParentVisualizer(ListDataModelVisualizer visualizer)
        {
            _parentVisualizer = visualizer;
        }

        public float GetDefaultPositionX()
        {
            return _defaultPositionX;
        }

        public void RewriteDefaultPositionX()
        {
            _defaultPositionX = _rectTransform.anchoredPosition.x;
        }
    }
}