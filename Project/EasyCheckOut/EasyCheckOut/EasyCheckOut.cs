using System;
using GalaSoft.MvvmLight.Ioc;
using EasyCheckOut.ViewModel;

using Xamarin.Forms;

namespace EasyCheckOut
{
	public class App : Application
	{
		public static bool LoggedIn { get; set; }

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
			LoggedIn = false;

			// The root page of your application
			MainPage = GetHomePage();
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

