using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileBar_from_code.Model.DbModel
{
     class tbl_br_users : XPCustomObject
    {
        decimal fu_id;
        [Key]
        public decimal u_id
        {
            get { return fu_id; }
            set { SetPropertyValue<decimal>(nameof(u_id), ref fu_id, value); }
        }
        string fu_name;
        [Size(SizeAttribute.Unlimited)]
        public string u_name
        {
            get { return fu_name; }
            set { SetPropertyValue<string>(nameof(u_name), ref fu_name, value); }
        }
        string fu_pass;
        [Size(SizeAttribute.Unlimited)]
        public string u_pass
        {
            get { return fu_pass; }
            set { SetPropertyValue<string>(nameof(u_pass), ref fu_pass, value); }
        }
        DateTime flast_login;
        [ColumnDbDefaultValue("(getdate())")]
        public DateTime last_login
        {
            get { return flast_login; }
            set { SetPropertyValue<DateTime>(nameof(last_login), ref flast_login, value); }
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

        public tbl_br_users(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
