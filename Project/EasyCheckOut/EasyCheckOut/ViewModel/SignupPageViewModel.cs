using GalaSoft.MvvmLight;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace EasyCheckOut.ViewModel
{
	public class SignupPageViewModel : ViewModelBase
	{
		private IMyNavigationService navigationService;

		public SignupPageViewModel (IMyNavigationService navigationService)
		{
			this.navigationService = navigationService;
		}

		public void OnApperaing()
		{
			
		}
	}
}

