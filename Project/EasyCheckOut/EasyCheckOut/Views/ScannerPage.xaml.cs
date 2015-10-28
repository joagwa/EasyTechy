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

		protected override void OnAppearing(){
		}


	}
}

