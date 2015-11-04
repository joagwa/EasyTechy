﻿using System;
using GalaSoft.MvvmLight.Ioc;
using EasyCheckOut.ViewModel;

using Xamarin.Forms;

namespace EasyCheckOut
{
	public class App : Application
	{
		public static bool LoggedIn { get; set; }
		public static bool LoginToolBarIsShow { get; set; }
		public static bool LoginFailed { get; set; }

		private static ViewModelLocator _locator;
		private static NavigationService nav;
		public static ViewModelLocator Locator
		{
			get
			{ 
				return _locator ?? (_locator = new ViewModelLocator ());
			}
		}

		public App ()
		{
			Initialize();


			// The root page of your application
			MainPage = GetHomePage();
		}

		private void Initialize(){
			LoggedIn = false;
			LoginToolBarIsShow = false;


			//reset
			var database = new ECOdatabase ();
			database.DeleteAllInBuyList ();
			database.DeleteAllInCart ();
			database.DeleteAllInWoolworthsItem ();

			string prefix = Device.OnPlatform("", "", "Images/");

//			database.DeleteAllInWoolworthsItem ();
			if (database.GetWoolWorthsItemAll ().Count == 0) {
				WoolworthsItem item1 = new WoolworthsItem ("50375264", "Kleenex Tissues", 2.50, prefix + "tissue.png");
				WoolworthsItem item2 = new WoolworthsItem ("4001686301562", "Haribo Goldbears", 1.35, prefix + "Haribo-Gold-Bears.png");
				WoolworthsItem item3 = new WoolworthsItem ("4947678649536", "Body Sheet", 2.80, prefix + "bodysheet.png");
				database.InsertItemToWoolWorthsItem (item1);
				database.InsertItemToWoolWorthsItem (item2);
				database.InsertItemToWoolWorthsItem (item3);
			}
		}

		public Page GetHomePage ()
		{
			nav = new NavigationService ();


			nav.Configure (ViewModelLocator.HomePageKey, typeof(Homepage));
			nav.Configure (ViewModelLocator.LoginPageKey, typeof(LoginPage));
			nav.Configure (ViewModelLocator.SignupPageKey, typeof(SignupPage));
			nav.Configure (ViewModelLocator.BuylistPageKey, typeof(BuylistPage));
			nav.Configure (ViewModelLocator.CartPageKey, typeof(CartPage));
			nav.Configure (ViewModelLocator.ConnectPageKey, typeof(ConnectPage));
			nav.Configure (ViewModelLocator.MapPageKey, typeof(MapPage));
			nav.Configure (ViewModelLocator.ReceivePageKey, typeof(ReceivePage));
			nav.Configure (ViewModelLocator.ScannerPageKey, typeof(ScannerPage));

			SimpleIoc.Default.Register<IMyNavigationService> (() => nav, true);
			var navPage = new NavigationPage (new Homepage ());
			nav.Initialize (navPage);
			return navPage;
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

