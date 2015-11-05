using GalaSoft.MvvmLight;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.Generic;

namespace EasyCheckOut.ViewModel
{
	/// <summary>
	/// This class contains properties that the main View can data bind to.
	/// <para>
	/// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
	/// </para>
	/// <para>
	/// You can also use Blend to data bind with the tool's support.
	/// </para>
	/// <para>
	/// See http://www.galasoft.ch/mvvm
	/// </para>
	/// </summary>
	public class HomePageViewModel : ViewModelBase
	{
		private IMyNavigationService navigationService;

		public string Param { get; set; }

		public ICommand GoToLoginPage { get; private set; }

		public ICommand GoToBuylistPage { get; private set; }

		public ICommand GoToCartPage { get; private set; }

		public ICommand GoToConnectPage { get; private set; }

		public ICommand GoToReceivePage { get; private set; }

		public ICommand GoToMapPage { get; private set; }

		public ICommand GoToScannerPage { get; private set; }

		public ICommand LogOutFunction { get; private set; }

		/// <summary>
		/// Initializes a new instance of the MainViewModel class.
		/// </summary>
		public HomePageViewModel (IMyNavigationService navigationService)
		{
			this.navigationService = navigationService;
			////if (IsInDesignMode)
			////{
			////    // Code runs in Blend --> create design time data.
			////}
			////else
			////{
			////    // Code runs "for real"
			////}
			/// 

			LogOutFunction = new Command (() => {
				App.LoggedIn = false;

				var database = new ECOdatabase ();
				database.DeleteAllInBuyList ();

				this.navigationService.NavigateToModal (ViewModelLocator.HomePageKey);
			});

			GoToLoginPage = new Command (param => {
				var x = param as String;
				this.navigationService.NavigateTo (ViewModelLocator.LoginPageKey);
			});

			GoToBuylistPage = new Command (() => {
				this.navigationService.NavigateTo (ViewModelLocator.BuylistPageKey);
			});

			GoToCartPage = new Command (() => {
				this.navigationService.NavigateTo (ViewModelLocator.CartPageKey);	
			});

			GoToConnectPage = new Command (() => {
				this.navigationService.NavigateTo (ViewModelLocator.ConnectPageKey);	
			});

			GoToReceivePage = new Command (() => {
				this.navigationService.NavigateTo (ViewModelLocator.ReceivePageKey);
			});

			GoToMapPage = new Command (() => {
				this.navigationService.NavigateTo (ViewModelLocator.MapPageKey);
			});

			GoToScannerPage = new Command (() => {
				
			});
		}

		public void OnAppearing ()
		{
		}
	}
}