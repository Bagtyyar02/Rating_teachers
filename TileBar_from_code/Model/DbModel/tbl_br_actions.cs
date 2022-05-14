using DevExpress.Xpo;
using System;

namespace TileBar_from_code.Model
{
    class tbl_br_actions : XPCustomObject
    {
        #region Properties
        int faction_id;
        [Key(true)]
        public int action_id
        {
            get { return faction_id; }
            set { SetPropertyValue<int>(nameof(action_id), ref faction_id, value); }
        }
        int fteacher_id;
        public int teacher_id
        {
            get { return fteacher_id; }
            set { SetPropertyValue<int>(nameof(teacher_id), ref fteacher_id, value); }
        }
        int ftask_id;
        public int task_id
        {
            get { return ftask_id; }
            set { SetPropertyValue<int>(nameof(task_id), ref ftask_id, value); }
        }
        decimal ftask_point;
        public decimal task_point
        {
            get { return ftask_point; }
            set { SetPropertyValue<decimal>(nameof(task_point), ref ftask_point, value); }
        }
        DateTime fmodified_date;
        [ColumnDbDefaultValue("(getdate())")]
        public DateTime modified_date
        {
            get { return fmodified_date; }
            set { SetPropertyValue<DateTime>(nameof(modified_date), ref fmodified_date, value); }
        }
        string fspe_code1;
        [Size(50)]
        public string spe_code1
        {
            get { return fspe_code1; }
            set { SetPropertyValue<string>(nameof(spe_code1), ref fspe_code1, value); }
        }
        string fspe_code2;
        [Size(50)]
        public string spe_code2
        {
            get { return fspe_code2; }
            set { SetPropertyValue<string>(nameof(spe_code2), ref fspe_code2, value); }
        }
        string fspe_code3;
        [Size(50)]
        public string spe_code3
        {
            get { return fspe_code3; }
            set { SetPropertyValue<string>(nameof(spe_code3), ref fspe_code3, value); }
        }
        string fspe_code4;
        [Size(50)]
        public string spe_code4
        {
            get { return fspe_code4; }
            set { SetPropertyValue<string>(nameof(spe_code4), ref fspe_code4, value); }
        }
        string fspe_code5;
        [Size(50)]
        public string spe_code5
        {
            get { return fspe_code5; }
            set { SetPropertyValue<string>(nameof(spe_code5), ref fspe_code5, value); }
        }
        string ftask_code;
        [Size(50)]
        public string task_code
        {
            get { return ftask_code; }
            set { SetPropertyValue<string>(nameof(task_code), ref ftask_code, value); }
        }
        string fteacher_code;
        [Size(50)]
        public string teacher_code
        {
            get { return fteacher_code; }
            set { SetPropertyValue<string>(nameof(teacher_code), ref fteacher_code, value); }
        }
        #endregion

        #region procedures
        public tbl_br_actions(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
        #endregion
    }
}
