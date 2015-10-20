using GalaSoft.MvvmLight;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace EasyCheckOut.ViewModel
{
	public class LoginPageViewModel : ViewModelBase
	{
		private IMyNavigationService navigationService;

		public ICommand GoToSignupPage { get; private set; }

		public ICommand Login { get; private set; }

		private bool loggedin;
		public bool LoggedIn{
			get { return loggedin; }
			set{ 
				loggedin = value;
				RaisePropertyChanged (() => LoggedIn);
			}
		}

		private String username;
		public String Username
		{
			get { return username; }
			set {
				username = value;
				RaisePropertyChanged (() => Username);
			}
		}

		private String password;
		public String Password
		{
			get { return password; }
			set {
				password = value;
				RaisePropertyChanged (() => Password);
			}
		}



		public LoginPageViewModel (IMyNavigationService navigationService)
		{
			this.navigationService = navigationService;

			LoggedIn = App.LoggedIn;

			GoToSignupPage = new Command (() => {
				this.navigationService.NavigateTo(ViewModelLocator.SignupPageKey);
			});

			Login = new Command ( async () => {
//				var database = new ECOdatabase();
				var database = new AzureDatabase ();

//				database1.GetUsers();

				int rowcount = await database.ValidateUser (Username, Password);
				if (rowcount == 0) {
					App.LoggedIn = false;
				} else {
					App.LoggedIn = true;
					//Navigate to homepage without back key
					this.navigationService.NavigateToModal (ViewModelLocator.HomePageKey);
				}

			});

		}

			

		public void OnAppearing()
		{
			LoggedIn = App.LoggedIn;
			Username = null;
			Password = null;			
		}
	}
}

