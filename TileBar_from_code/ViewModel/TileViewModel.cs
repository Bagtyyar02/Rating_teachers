using DevExpress.Mvvm;

namespace TileBar_from_code.ViewModel
{
    public class TileViewModel : BindableBase
    {
        DelegateCommand cmd { get; set; }
        public TileViewModel()
        {
            cmd = new DelegateCommand(() => chart_cmd());
        }

        private void chart_cmd()
        {
            //XYDiagram2D diagram = chartControl.Diagram as XYDiagram2D;
            //if (diagram != null)
            //{
            //    string min = diagram.ActualAxisX.GetScaleValueFromInternal(0).ToString();
            //    string max = diagram.ActualAxisX.GetScaleValueFromInternal(4).ToString();
            //    diagram.ActualAxisX.ActualVisualRange.SetMinMaxValues(min, max);
            //}
        }
    }
}