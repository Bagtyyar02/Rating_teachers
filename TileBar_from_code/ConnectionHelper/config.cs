namespace TileBar_from_code.ConnectionHelper
{
    class config
    {
        private static string MSSQL_server_name;
        public static string MSSQLServerName
        {
            get { return MSSQL_server_name; }
            set { MSSQL_server_name = value; }
        }

        private static string _MSSQLserverUserName;
        public static string MSSQLServerUserName
        {
            get { return _MSSQLserverUserName; }
            set { _MSSQLserverUserName = value; }
        }

        private static string _MSSQLserverPassword;
        public static string MSSQLServerPassword
        {
            get { return _MSSQLserverPassword; }
            set { _MSSQLserverPassword = value; }
        }

        private static string _MSSQLserverDbName;
        public static string MSSQLServerDbName
        {
            get { return _MSSQLserverDbName; }
            set { _MSSQLserverDbName = value; }
        }
    }
}
