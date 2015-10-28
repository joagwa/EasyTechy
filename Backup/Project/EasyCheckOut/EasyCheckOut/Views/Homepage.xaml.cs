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
		ToolbarItem Login;

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

//			Logout = new ToolbarItem ("Logout", null, async() => 
//			{
//				ToolbarItems.Remove(Logout);
//					await Navigation.PushAsync(new Homepage());
//			});

//			<ToolbarItem x:Name="LoginToolBar" Name="Login" Order="Primary" Command="{Binding GoToLoginPage}" />



		}

		protected override void OnAppearing()
		{
			var vm = ServiceLocator.Current.GetInstance<HomePageViewModel> ();
			base.OnAppearing ();
			vm.OnAppearing ();
			ToolbarItems.Remove (LoginToolBar);
			ToolbarItems.Remove (LogOutToolBar);

//			if (App.LoginToolBarIsShow == false) {
				
				if (App.LoggedIn) {
					ToolbarItems.Remove (LoginToolBar);
					ToolbarItems.Add (LogOutToolBar);
				} else {
					ToolbarItems.Add (LoginToolBar);
					ToolbarItems.Remove (LogOutToolBar);
				}

//			}

		}

//		void OnTapGestureRecognizerTapped(object sender, EventArgs args) {
//			var vm = ServiceLocator.Current.GetInstance<HomePageViewModel> ();
//			vm.GoToLoginPage.Execute();
//		}

	
	}

}

