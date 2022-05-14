using DevExpress.Mvvm;
using TileBar_from_code.ViewModel;

namespace TileBar_from_code.Helper
{
    class Navigation : ViewModelBase
    {
        public INavigationService Service { get { return this.GetService<INavigationService>(); } }
        public string view1 { get; set; }
        public Navigation(string str)
        {
            MainViewModel mvvm = new MainViewModel();
            Service.Navigate(str, null, mvvm);

        }

    }
}
