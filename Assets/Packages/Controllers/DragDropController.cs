using Packages.Visualizers;
using UnityEngine;

namespace Packages.Controllers
{
    public class DragDropController : MonoBehaviour
    {
        [SerializeField] private DataController dataController;
        
        public static DragDropController Instance;
      
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        public void ResortDataModelVisualizers(ListDataModelVisualizer parentVisualizer)
        {
            parentVisualizer.SortByAnchoredPositionY();
            parentVisualizer.RebuildDataModels();
        }

    }
}