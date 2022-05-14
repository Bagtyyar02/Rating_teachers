using DevExpress.Xpo;

namespace TileBar_from_code.Model
{
    class tbl_br_teachers : XPCustomObject
    {
        #region properties
        int fteacher_id;
        [Key(true)]
        public int teacher_id
        {
            get { return fteacher_id; }
            set { SetPropertyValue<int>(nameof(teacher_id), ref fteacher_id, value); }
        }
        string fteacher_name;
        [Size(50)]
        public string teacher_name
        {
            get { return fteacher_name; }
            set { SetPropertyValue<string>(nameof(teacher_name), ref fteacher_name, value); }
        }
        string fteacher_surname;
        [Size(50)]
        public string teacher_surname
        {
            get { return fteacher_surname; }
            set { SetPropertyValue<string>(nameof(teacher_surname), ref fteacher_surname, value); }
        }
        string fteacher_code;
        [Size(50)]
        public string teacher_code
        {
            get { return fteacher_code; }
            set { SetPropertyValue<string>(nameof(teacher_code), ref fteacher_code, value); }
        }
        string fteacher_phone_number;
        [Size(50)]
        public string teacher_phone_number
        {
            get { return fteacher_phone_number; }
            set { SetPropertyValue<string>(nameof(teacher_phone_number), ref fteacher_phone_number, value); }
        }
        string fteacher_email;
        [Size(50)]
        public string teacher_email
        {
            get { return fteacher_email; }
            set { SetPropertyValue<string>(nameof(teacher_email), ref fteacher_email, value); }
        }
        string fteacher_faculty;
        [Size(50)]
        public string teacher_faculty
        {
            get { return fteacher_faculty; }
            set { SetPropertyValue<string>(nameof(teacher_faculty), ref fteacher_faculty, value); }
        }
        string fteacher_description;
        [Size(50)]
        public string teacher_description
        {
            get { return fteacher_description; }
            set { SetPropertyValue<string>(nameof(teacher_description), ref fteacher_description, value); }
        }
        string fteacher_state;
        [Size(50)]
        public string teacher_state
        {
            get { return fteacher_state; }
            set { SetPropertyValue<string>(nameof(teacher_state), ref fteacher_state, value); }
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
        #endregion

        #region procedures
        public tbl_br_teachers(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
        #endregion
    }
}
