using System;
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

//			MainPage = new NavigationPage (new iBeaconPage ());
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
				WoolworthsItem item4 = new WoolworthsItem ("9310055101432", "Crunchy Nut", 7.60, prefix + "crunchy_nut.jpg");
				WoolworthsItem item5 = new WoolworthsItem ("9310055537286", "Kellogg's Original", 8.20, prefix + "Kelloggs-Original.png");
				WoolworthsItem item6 = new WoolworthsItem ("9300675011037", "Coke Cola Diet", 3.20, prefix + "cocacola-diet.png");
				database.InsertItemToWoolWorthsItem (item1);
				database.InsertItemToWoolWorthsItem (item2);
				database.InsertItemToWoolWorthsItem (item3);
				database.InsertItemToWoolWorthsItem (item4);
				database.InsertItemToWoolWorthsItem (item5);
				database.InsertItemToWoolWorthsItem (item6);
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
			nav.Configure (ViewModelLocator.ConnectPageKey, typeof(iBeaconPage));
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

