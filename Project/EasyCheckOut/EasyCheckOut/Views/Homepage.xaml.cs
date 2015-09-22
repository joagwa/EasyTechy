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

//			ServiceLocator.Current.GetInstance<HomePageViewModel> ().Param = param;
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
			var vm = ServiceLocator.Current.GetInstance<HomePageViewModel> ();
			base.OnAppearing ();
			vm.OnAppearing ();
		}

//		void OnTapGestureRecognizerTapped(object sender, EventArgs args) {
//			var vm = ServiceLocator.Current.GetInstance<HomePageViewModel> ();
//			vm.GoToLoginPage.Execute();
//		}

	
	}

}

