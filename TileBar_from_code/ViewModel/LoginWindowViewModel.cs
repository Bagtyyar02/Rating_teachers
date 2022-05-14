using DevExpress.Data.Filtering;
using DevExpress.Mvvm;
using DevExpress.Utils;
using DevExpress.Xpf.Editors;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TileBar_from_code.Commands;
using TileBar_from_code.Helper;
using TileBar_from_code.Model.DbModel;

namespace TileBar_from_code.ViewModel
{
    class LoginWindowViewModel:ViewModelBase
    {
        public UnitOfWork uow;
        private string _pwd;
        public string pwd
        {
            get { return _pwd; }
            set { SetValue(ref _pwd, value); }
        }
        private string _u_name;
        public string u_name
        {
            get { return _u_name; }
            set { SetValue(ref _u_name, value); }
        }
       
        public MyDelegateCommand AdminLoginCommand { get; set; }
        public MyDelegateCommand UserLoginCommand { get; set; }
        protected ICurrentWindowService CurrentWindowService { get { return GetService<ICurrentWindowService>(); } }

        public LoginWindowViewModel()
        {
            uow = new UnitOfWork();
            AdminLoginCommand = new MyDelegateCommand(o => AdminLogin(o));

            UserLoginCommand = new MyDelegateCommand(o=>UserLogin(o));
        }

        private void UserLogin(object o)
        {
            object[] obj = o as object[];
            User.u_name = "";
            User.u_pass = "";
            User.u_status = "";
            User.IsAdmin = false;
            MainWindow wndMain = new MainWindow();
            wndMain.DataContext = new MainViewModel();
            wndMain.Show();
            ((Window)obj[0]).Close();
        }

        public void AdminLogin(object o)
        {
            object[] _obj = o as object[];
            u_name = _obj[0].ToString();
            PasswordBoxEdit _psswdBox = _obj[1] as PasswordBoxEdit;
            pwd = _psswdBox.Password;
           
            
            if (u_name != null && pwd!=null)
            {
                tbl_br_users user = uow.FindObject<tbl_br_users>(CriteriaOperator.Parse($"u_name='{u_name}' and u_pass='{pwd}'"));
                if (user!=null)
                {
                    User.u_name = u_name;
                    User.u_pass = pwd;
                    User.u_status= "admin";
                    User.IsAdmin = true;
                    MainWindow wndMain = new MainWindow();
                    wndMain.DataContext = new MainViewModel();
                    wndMain.Show();
                    ((Window)_obj[2]).Close();
                }
                else
                {
                        
                }
            }
        }
    }
    
}
