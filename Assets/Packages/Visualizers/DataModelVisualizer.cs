using Packages.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Packages.Visualizers
{
    public class DataModelVisualizer : MonoBehaviour
    {
        [SerializeField] private Text intValueText;
        [SerializeField] private Text stringValueText;

        public DataModel CurrentDataModel { get; private set; }

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
    }
}