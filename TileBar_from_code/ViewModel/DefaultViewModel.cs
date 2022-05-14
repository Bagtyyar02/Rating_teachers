using DevExpress.Mvvm;
using System;

namespace TileBar_from_code.ViewModel
{
    public class DefaultViewModel : ViewModelBase
    {
        public string path { get; set; }
        public DefaultViewModel()
        {
            path = AppDomain.CurrentDomain.BaseDirectory + "\\tituki.JPG";
        }
    }
}