using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace TileBar_from_code.Helper
{
    public static class User
    {
        public static string  u_name{ get; set; }
        public static string  u_pass{ get; set; }
        public static string u_status
        {
            get; set;
        }
        public static bool IsAdmin { get;  set; }
    }
}
