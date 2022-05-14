using DevExpress.Mvvm;

namespace TileBar_from_code.ViewModel
{

    class TasksViewModel : ViewModelBase
    {
        // public static UnitOfWork uow;

        DelegateCommand NewCommand { get; set; }
        public INavigationService Service { get { return this.GetService<INavigationService>(); } }

        public TasksViewModel()
        {
            //MessageBox.Show("Hello");
            //  NewCommand = new DelegateCommand(()=>AddTask());
        }


    }
}