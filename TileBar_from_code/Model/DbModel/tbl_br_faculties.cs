using DevExpress.Xpo;

namespace TileBar_from_code.Model.DbModel
{
    class tbl_br_faculties : XPCustomObject
    {
        #region properties
        int ffaculty_id;
        [Key(true)]
        public int faculty_id
        {
            get { return ffaculty_id; }
            set { SetPropertyValue<int>(nameof(faculty_id), ref ffaculty_id, value); }
        }
        string ffaculty_name;
        [Size(SizeAttribute.Unlimited)]
        public string faculty_name
        {
            get { return ffaculty_name; }
            set { SetPropertyValue<string>(nameof(faculty_name), ref ffaculty_name, value); }
        }
        string fspe_code1;
        [Size(SizeAttribute.Unlimited)]
        public string spe_code1
        {
            get { return fspe_code1; }
            set { SetPropertyValue<string>(nameof(spe_code1), ref fspe_code1, value); }
        }
        string fspe_code2;
        [Size(SizeAttribute.Unlimited)]
        public string spe_code2
        {
            get { return fspe_code2; }
            set { SetPropertyValue<string>(nameof(spe_code2), ref fspe_code2, value); }
        }
        string fspe_code3;
        [Size(SizeAttribute.Unlimited)]
        public string spe_code3
        {
            get { return fspe_code3; }
            set { SetPropertyValue<string>(nameof(spe_code3), ref fspe_code3, value); }
        }
        string fspe_code4;
        [Size(SizeAttribute.Unlimited)]
        public string spe_code4
        {
            get { return fspe_code4; }
            set { SetPropertyValue<string>(nameof(spe_code4), ref fspe_code4, value); }
        }
        #endregion

        #region procedures
        public tbl_br_faculties(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
        #endregion
    }
}
