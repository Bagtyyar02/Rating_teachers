namespace TileBar_from_code.Model.GridModel
{
    class Tasks_model
    {
        public int task_id { get; set; }
        public decimal quantity { get; set; }
        public string task_name { get; set; }
        public string task_code { get; set; }
        public decimal task_point { get;  set; }
        public decimal task_max_point { get; set; }
        public decimal percentage { get; set; }

        // public string task_point { get; set; }
    }
}
