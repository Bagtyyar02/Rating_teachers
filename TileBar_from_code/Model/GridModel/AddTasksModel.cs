using System;

namespace TileBar_from_code.Model.GridModel
{
    class AddTasksModel
    {
        public string task_name { get; internal set; }
        public string task_short_name { get; internal set; }
        public int task_id { get; internal set; }
        public decimal task_quantity { get;  set; }
        public decimal task_point { get; set; }
        public decimal max_point { get; internal set; }
        public decimal total_value { get; set; }
        public AddTasksModel()
        {
            string guid = Guid.NewGuid().ToString();
            task_point = 0;
        }
    }
}
