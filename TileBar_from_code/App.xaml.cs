using DevExpress.Mvvm;
using DevExpress.Xpf.Core;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.DB.Exceptions;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using TileBar_from_code.ConnectionHelper;
using TileBar_from_code.SplashScreens;

namespace TileBar_from_code
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region db_prop
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
        #endregion

        #region constructor
        public App()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
            var splashScreenViewModel = new DXSplashScreenViewModel() { Title = "Tituki" };
            //DXDesignTimeHelper.SetBackground(Des, "#FF0073FF");
            SplashScreenManager.Create(() => new DxSplashScreen(), splashScreenViewModel).ShowOnStartup();
            // View.AppLoginWindow _wndLogin = new View.AppLoginWindow();
            read_file();
            Connect();
            //_wndLogin.DataContext = new ViewModel.LoginViewModel();
            //_wndLogin.ShowDialog();

        }

        private void Current_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            View.Dialogs.wndErrorDialog _wndError = new View.Dialogs.wndErrorDialog();
            _wndError.DataContext = new ViewModel.Dialogs.wndErrorDialogViewModel(e.Exception);
            _wndError.ShowDialog();
            e.Handled = true;
        }

        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            View.Dialogs.wndErrorDialog _wndError = new View.Dialogs.wndErrorDialog();
            _wndError.DataContext = new ViewModel.Dialogs.wndErrorDialogViewModel(e.Exception);
            _wndError.ShowDialog();
            e.SetObserved();
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            View.Dialogs.wndErrorDialog _wndError = new View.Dialogs.wndErrorDialog();
            _wndError.DataContext = new ViewModel.Dialogs.wndErrorDialogViewModel((Exception)e.ExceptionObject) { Unhandled = true };
            _wndError.ShowDialog();
        }
        #endregion

        #region procedures
        private static void read_file()
        {
            if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\config.sys"))
            {
                try
                {
                    using (StreamReader _reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\config.sys"))
                    {
                        string _jsonFile = _reader.ReadToEnd();
                        config_file _dk_globalConf = JsonConvert.DeserializeObject<config_file>(_jsonFile);
                        MSSQLServerName = _dk_globalConf.MSSQLServerName;
                        MSSQLServerUserName = _dk_globalConf.MSSQLServerUserName;
                        MSSQLServerPassword = _dk_globalConf.MSSQLServerPassword;
                        MSSQLServerDbName = _dk_globalConf.MSSQLServerDbName;

                    }
                }
                catch //(Exception ex)
                {

                }
            }
            else
            {
                MessageBox.Show("Sazlama faýly tapylmady");
            }
        }
        private static void Connect()
        {

            string _connStr = $"XpoProvider=MSSqlServer;Data Source={MSSQLServerName};User ID={MSSQLServerUserName};Password={MSSQLServerPassword};Initial Catalog={MSSQLServerDbName};Persist Security Info=true";
            //_connStrDapper = "Data Source=" + _ServerName + ";Initial Catalog=" + _dbName + ";Persist Security Info=True;User ID=" + _UserName + ";Password=" + _password;
            //dbConn = new SqlConnection(_connStrDapper);
            try
            {
                //DevExpress.Xpo.Session.DefaultSession.ConnectionString = _connStr;
                XpoDefault.DataLayer = XpoDefault.GetDataLayer(_connStr, AutoCreateOption.DatabaseAndSchema);
                XpoDefault.Session.UpdateSchema();
                //  Helpers.dkCommon._connStr = _connStr;
                //Helpers.dkCommon.Connected = true;
                XpoDefault.Session = null;
                //MessageBox.Show("Cennection successful");
            }
            catch (UnableToOpenDatabaseException)
            {
                try
                {
                    XpoDefault.DataLayer = XpoDefault.GetDataLayer(_connStr, AutoCreateOption.DatabaseAndSchema);
                    XpoDefault.Session.UpdateSchema();
                }
                catch (Exception _ex)
                {
                    MessageBox.Show("Maglumatlar bazasyna baglanylmady. Indiki ýalňyşlylar ýüze çykdy " + _ex.Message);
                    //  Application.Exit();
                }
            }



        }
        #endregion
    }
}
