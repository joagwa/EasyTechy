using GalaSoft.MvvmLight;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace EasyCheckOut.ViewModel
{
	public class ReceivePageViewModel : ViewModelBase
	{
		private IMyNavigationService navigationService;

		public ReceivePageViewModel (IMyNavigationService navigationService)
		{
			this.navigationService = navigationService;
		}

		public void OnApperaing()
		{
			
		}
	}
}

