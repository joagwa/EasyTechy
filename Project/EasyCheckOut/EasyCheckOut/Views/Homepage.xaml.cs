using System;
using System.Collections.Generic;
using EasyCheckOut.ViewModel;
using EasyCheckOut;
using Microsoft.Practices.ServiceLocation;
using Xamarin.Forms;

namespace EasyCheckOut
{
	public partial class Homepage : BaseView
	{
		public Homepage ()
		{
			InitializeComponent ();
			base.Init ();
			BindingContext = App.Locator.HomePage;

			//Button clicked event for navigating to login page
//			Button1.Clicked += (sender, args) => {
//				Navigation.PushAsync (new LoginPage ());
//			};
//
//			LoginButton.Clicked += (sender, args) => {
//				Navigation.PushAsync (new LoginPage ());
//			};
		}

		protected override void OnAppearing()
		{
			base.OnAppearing ();
			var vm = ServiceLocator.Current.GetInstance<HomePageViewModel> ();
			vm.OnAppearing ();
		}
	}
}

