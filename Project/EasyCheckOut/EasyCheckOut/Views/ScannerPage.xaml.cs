using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace EasyCheckOut
{
	public partial class ScannerPage : BaseView
	{
		public ScannerPage ()
		{
			InitializeComponent ();
			base.Init ();
			BindingContext = App.Locator.ScannerPage;

		}

		async void onScanClicked(object sender, EventArgs e)
		{
//			var data = await DependencyService.Get<IScanner> ().Scan ();
//			DisplayAlert ("Scanner", data, "cancel");
		}

		async protected override void OnAppearing(){

//			var data = await DependencyService.Get<IScanner> ().Scan ();
//			if (data != null) {
//				var database = new ECOdatabase ();
//				List<WoolworthsItem> resultSet = database.SearchWoolWorthsItem (data);
//
//				if(resultSet.Count == 1){
//					CartItem scannedItem = new CartItem(resultSet[0].itemName, resultSet[0].itemPrice, resultSet[0].itemImage);
//					database.InsertItemToCart(scannedItem);
//				} else {
//					DisplayAlert ("Scanner", "No item found", "OK");
//				}
//			}
		}


	}
}

