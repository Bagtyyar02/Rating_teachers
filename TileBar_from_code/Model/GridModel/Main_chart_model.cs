using System.Collections.ObjectModel;
using TileBar_from_code.Model.GridModel;

namespace TileBar_from_code.Model
{
    class Main_chart_model
    {
        #region properties
        public string teacher_name { get; set; }
        public string teacher_surname { get; set; }
        public decimal teacher_point { get; set; }
        public decimal teacher_total_point { get; set; }
        public ObservableCollection<Tasks_model> tasks { get; set; }
        public int teacher_id { get; internal set; }

        #endregion
        public Main_chart_model()
        {
            tasks = new ObservableCollection<Tasks_model>();
        }
    }
}
