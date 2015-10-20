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
		ToolbarItem Logout;

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

			var bkcolor = new Color (0, 0, 0, 0.5);

			Logout = new ToolbarItem ("Logout", null, async() => 
			{
				ToolbarItems.Remove(Logout);
					await Navigation.PushAsync(new Homepage());
			}
			
			);
		}

		protected override void OnAppearing()
		{
			var vm = ServiceLocator.Current.GetInstance<HomePageViewModel> ();
			base.OnAppearing ();
			vm.OnAppearing ();


			if (App.LoggedIn) {
				ToolbarItems.Remove (LoginToolBar);
//				ToolbarItems.Add (Logout);
			}

//			Navigation.
		}

//		void OnTapGestureRecognizerTapped(object sender, EventArgs args) {
//			var vm = ServiceLocator.Current.GetInstance<HomePageViewModel> ();
//			vm.GoToLoginPage.Execute();
//		}

	
	}

}

