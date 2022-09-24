using Packages.Visualizers;
using UnityEngine;

namespace Packages.Controllers
{
    public class DragDropController : MonoBehaviour
    {
        public static DragDropController Instance;
       
        [SerializeField] private LoadSaveController loadSaveController;

        private ListDataModelVisualizer _firstListVisualizer;
        private ListDataModelVisualizer _secondListVisualizer;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        private void Start()
        {
            _firstListVisualizer = loadSaveController.GetFirstDataModelVisualizer();
            _secondListVisualizer = loadSaveController.GetSecondDataModelVisualizer();
        }

        public void ResortDataModelVisualizers(DataModelVisualizer dataModelVisualizer)
        {
            _firstListVisualizer.SetVerticalLayoutGroupStatus(false);
            _secondListVisualizer.SetVerticalLayoutGroupStatus(false);

            if (IsVisualizerMovedToSecondList(dataModelVisualizer))
                MoveVisualizerToOtherList(dataModelVisualizer, _firstListVisualizer, _secondListVisualizer);

            else if (IsVisualizerMovedToFirstList(dataModelVisualizer))
                MoveVisualizerToOtherList(dataModelVisualizer, _secondListVisualizer, _firstListVisualizer);

            RebuildListVisualizers();
        }

        private void MoveVisualizerToOtherList(DataModelVisualizer dataModelVisualizer,
            ListDataModelVisualizer fromListVisualizer, ListDataModelVisualizer toListVisualizer)
        {
            toListVisualizer.CurrentDataModelVisualizers.Add(dataModelVisualizer);
            fromListVisualizer.CurrentDataModelVisualizers.Remove(dataModelVisualizer);

            toListVisualizer.CurrentListDataModel.DataModels.Add(dataModelVisualizer.CurrentDataModel);
            fromListVisualizer.CurrentListDataModel.DataModels.Remove(dataModelVisualizer.CurrentDataModel);

            dataModelVisualizer.transform.SetParent(toListVisualizer.GetListVisualizerContainer());
            dataModelVisualizer.SetParentVisualizer(toListVisualizer);
        }

        private bool IsVisualizerMovedToFirstList(DataModelVisualizer visualizer)
        {
            if (_secondListVisualizer.Equals(visualizer.GetParentVisualizer()))
                if (visualizer.GetRectTransform().anchoredPosition.x <= 0)
                    return true;


            return false;
        }

        private bool IsVisualizerMovedToSecondList(DataModelVisualizer visualizer)
        {
            if (_firstListVisualizer.Equals(visualizer.GetParentVisualizer()))
                if (visualizer.GetRectTransform().anchoredPosition.x >=
                    visualizer.GetDefaultPositionX() * 2)
                    return true;


            return false;
        }

        private void RebuildListVisualizers()
        {
            RebuildVisualizer(_firstListVisualizer);
            RebuildVisualizer(_secondListVisualizer);
        }

        private void RebuildVisualizer(ListDataModelVisualizer visualizer)
        {
            visualizer.SortByAnchoredPositionY();
            visualizer.RebuildDataModels();
        }
    }
}