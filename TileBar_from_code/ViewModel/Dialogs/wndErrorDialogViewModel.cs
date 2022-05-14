using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TileBar_from_code.ViewModel.Dialogs
{
    class wndErrorDialogViewModel:BindableBase
    {
		#region Properties

		private string _exMessage;
		public string exMessage
		{
			get { return _exMessage; }
			set { SetValue(ref _exMessage, value); }
		}

		private bool _unhandled;
		public bool Unhandled
		{
			get { return _unhandled; }
			set { SetValue(ref _unhandled, value); }
		}

		private string _Handling;
		public string Handling
		{
			get { return _Handling; }
			set { SetValue(ref _Handling, value); }
		}


		private string _InnerExeption;
		public string StackTrace
		{
			get { return _InnerExeption; }
			set { SetValue(ref _InnerExeption, value); }
		}

		private Visibility _innerVisibility;
		public Visibility innerVisibility
		{
			get { return _innerVisibility; }
			set { SetValue(ref _innerVisibility, value); }
		}

		#endregion Properties

		#region Constructor

		public wndErrorDialogViewModel()
		{

		}

		public wndErrorDialogViewModel(Exception _ex)
		{
			exMessage = _ex.Message;
			if (Unhandled == true)
			{
				Handling = "Unhanled";
			}
			if (_ex.StackTrace.Length > 0)
			{
				innerVisibility = Visibility.Visible;
				StackTrace = _ex.StackTrace;
			}
			else
			{
				innerVisibility = Visibility.Collapsed;
			}
		}

		#endregion Constructor

		#region Procedures



		#endregion Procedures
	}
}
