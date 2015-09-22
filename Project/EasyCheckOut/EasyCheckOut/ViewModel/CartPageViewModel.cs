using GalaSoft.MvvmLight;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace EasyCheckOut.ViewModel
{
	public class CartPageViewModel : ViewModelBase
	{
		private IMyNavigationService navigationService;

		public CartPageViewModel (IMyNavigationService navigationService)
		{
			this.navigationService = navigationService;
		}

		public void OnApperaing()
		{
			
		}
	}
}

