using DevExpress.Xpo;
using System;

namespace TileBar_from_code.Model
{
    class tbl_br_tasks : XPCustomObject
    {
        #region properties
        [Persistent]
        int ftask_id;
        [Key(true)]
        public int task_id
        {
            get { return ftask_id; }
            set { SetPropertyValue<int>(nameof(task_id), ref ftask_id, value); }
        }
        string ftask_name;
        [Size(50)]
        public string task_name
        {
            get { return ftask_name; }
            set { SetPropertyValue<string>(nameof(task_name), ref ftask_name, value); }
        }
        string ftask_code;
        [Size(50)]
        public string task_code
        {
            get { return ftask_code; }
            set { SetPropertyValue<string>(nameof(task_code), ref ftask_code, value); }
        }
        string ftask_shortname;
        [Size(10)]
        public string task_shortname
        {
            get { return ftask_shortname; }
            set { SetPropertyValue<string>(nameof(task_shortname), ref ftask_shortname, value); }
        }
        decimal ftask_max_point;
        [ColumnDbDefaultValue("((0))")]
        public decimal task_max_point
        {
            get { return ftask_max_point; }
            set { SetPropertyValue<decimal>(nameof(task_max_point), ref ftask_max_point, value); }
        }
        DateTime ftask_start_date;
        [ColumnDbDefaultValue("(getdate())")]
        public DateTime task_start_date
        {
            get { return ftask_start_date; }
            set { SetPropertyValue<DateTime>(nameof(task_start_date), ref ftask_start_date, value); }
        }
        DateTime ftask_end_date;
        [ColumnDbDefaultValue("(getdate())")]
        public DateTime task_end_date
        {
            get { return ftask_end_date; }
            set { SetPropertyValue<DateTime>(nameof(task_end_date), ref ftask_end_date, value); }
        }
        string ftask_description;
        [Size(50)]
        public string task_description
        {
            get { return ftask_description; }
            set { SetPropertyValue<string>(nameof(task_description), ref ftask_description, value); }
        }
        string fspe_code1;
        [Size(10)]
        public string spe_code1
        {
            get { return fspe_code1; }
            set { SetPropertyValue<string>(nameof(spe_code1), ref fspe_code1, value); }
        }
        string fspe_code2;
        [Size(10)]
        public string spe_code2
        {
            get { return fspe_code2; }
            set { SetPropertyValue<string>(nameof(spe_code2), ref fspe_code2, value); }
        }
        #endregion

        #region procedures
        public tbl_br_tasks() : base() { }

        public tbl_br_tasks(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
        #endregion
    }
}
