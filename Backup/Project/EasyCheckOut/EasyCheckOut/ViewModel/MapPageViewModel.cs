using GalaSoft.MvvmLight;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace EasyCheckOut.ViewModel
{
	public class MapPageViewModel : ViewModelBase
	{
		private IMyNavigationService navigationService;

		public MapPageViewModel (IMyNavigationService navigationService)
		{
			this.navigationService = navigationService;
		}

		public void OnApperaing()
		{
			
		}
	}
}

