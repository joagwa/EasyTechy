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

			ScanItemToCart = new Command (() => {
				var database = new ECOdatabase();

				CartItem item1 = new CartItem ("Apple", 4.00);
				database.InsertItemToCart(item1);

			});
				
		}
			

		public void OnApperaing()
		{
//			var data = await DependencyService.Get<IScanner> ().Scan ();

//			DisplayAlert ("Scanner", data, "cancel");
			
		}

		//				CartItem item1 = new CartItem ("Apple", 4.00);
		//				CartItem item2 = new CartItem ("Orange", 3.50);
		//				CartItem item3 = new CartItem ("Banana", 5.00);
		//				CartItem item4 = new CartItem ("Grape", 9.00);
		//				CartItem item5 = new CartItem ("Water", 2.00);
		//
		//				InsertItem (item1);
		//				InsertItem (item2);
		//				InsertItem (item3);
		//				InsertItem (item4);
		//				InsertItem (item5);
	}
}

