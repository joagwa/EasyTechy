using GalaSoft.MvvmLight;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing.Mobile;

namespace EasyCheckOut.ViewModel
{
	public class ScannerPageViewModel : ViewModelBase
	{
		private IMyNavigationService navigationService;

		public ICommand ScanItemToCart{ get; private set; }
		public ICommand OpenScanner{ get; private set; }

		public ScannerPageViewModel (IMyNavigationService navigationService)
		{
			this.navigationService = navigationService;

//			ScanItemToCart = new Command (() => {
//				var database = new ECOdatabase();
//
//				CartItem item1 = new CartItem ("Apple", 4.00);
//				database.InsertItemToCart(item1);
//
//			});
				
		}
			

		public void OnApperaing()
		{
			
		}
			
	}
}

