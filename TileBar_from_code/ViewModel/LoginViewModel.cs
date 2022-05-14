using DevExpress.Mvvm;
using System.Windows;

namespace TileBar_from_code.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public DelegateCommand cmdLogin { get; set; }
        public DelegateCommand cmdClose { get; set; }
        public LoginViewModel()
        {
            cmdLogin = new DelegateCommand(() => Login());
            cmdClose = new DelegateCommand(() => Close());
        }

        private void Close()
        {
            Application.Current.Shutdown();
        }

        private void Login()
        {
            //MessageBox.Show(Password);
            ViewModel.MainViewModel mainViewModel = new MainViewModel();
            MainWindow main = new MainWindow()
            {
                DataContext = mainViewModel
            };
            Application.Current.MainWindow = main;
            main.Show();
        }

    }
}