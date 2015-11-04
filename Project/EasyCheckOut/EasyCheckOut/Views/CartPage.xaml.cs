using System;
using System.Collections.Generic;
using Xamarin.Forms;
using EasyCheckOut.ViewModel;
using Microsoft.Practices.ServiceLocation;

namespace EasyCheckOut
{
	public partial class CartPage : BaseView
	{
		public CartPage ()
		{
			InitializeComponent ();
			base.Init ();
			BindingContext = App.Locator.CartPage;
		}

		protected override void OnAppearing(){
			base.OnAppearing ();
			var vm = ServiceLocator.Current.GetInstance<CartPageViewModel> ();
			vm.OnApperaing ();
		}

		async void Scanner(object sender, EventArgs args) {
			var data = await DependencyService.Get<IScanner> ().Scan ();

			if (data != null) {
				var database = new ECOdatabase ();
				List<WoolworthsItem> resultSet = database.SearchWoolWorthsItem (data);

				if(resultSet.Count == 1){
					CartItem scannedItem = new CartItem(resultSet[0].itemName, resultSet[0].itemPrice, resultSet[0].itemImage);
					database.InsertItemToCart(scannedItem);
//					Navigation.PushAsync (new CartPage());
					var vm = ServiceLocator.Current.GetInstance<CartPageViewModel> ();
					vm.OnApperaing ();
				} else {
					DisplayAlert ("Scanner", "No item found", "OK");
				}

			}
		}

	}
}

