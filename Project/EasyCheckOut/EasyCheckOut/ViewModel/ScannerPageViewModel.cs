using GalaSoft.MvvmLight;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace EasyCheckOut.ViewModel
{
	public class ScannerPageViewModel : ViewModelBase
	{
		private IMyNavigationService navigationService;

		public ScannerPageViewModel (IMyNavigationService navigationService)
		{
			this.navigationService = navigationService;
		}

		public void OnApperaing()
		{
			
		}
	}
}

