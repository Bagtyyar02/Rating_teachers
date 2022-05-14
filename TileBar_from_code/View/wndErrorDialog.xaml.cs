using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AkHasap2SaphasapSync.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for wndErrorDialog.xaml
    /// </summary>
    public partial class wndErrorDialog : Window
    {
        public wndErrorDialog()
        {
            InitializeComponent();
            
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
