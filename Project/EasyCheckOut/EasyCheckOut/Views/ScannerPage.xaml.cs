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

//			Label label1 = new Label {Text = "Hello"};

//			var tapGestureRecognizer = new TapGestureRecognizer ();
//			tapGestureRecognizer.Tapped += (sender, e) => Console.WriteLine("Tapped");
//			label1.GestureRecognizers.Add(tapGestureRecognizer);

		}

		async void onScanClicked(object sender, EventArgs e)
		{
//			var data = await DependencyService.Get<IScanner> ().Scan ();
//
//			DisplayAlert ("Scanner", data, "cancel");
		}

		async protected override void OnAppearing(){
//			var data = await DependencyService.Get<IScanner> ().Scan ();
//			DisplayAlert ("Scanner", data, "cancel");
		}


	}
}

