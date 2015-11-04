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

		public bool LoggedIn {
			get { return loggedin; }
			set { 
				loggedin = value;
				RaisePropertyChanged (() => LoggedIn);
			}
		}

		private bool loginfailed;

		public bool LoginFailed {
			get { return loginfailed; }
			set { 
				loginfailed = value;
				RaisePropertyChanged (() => LoginFailed);
			}
		}

		private String username;

		public String Username {
			get { return username; }
			set {
				username = value;
				RaisePropertyChanged (() => Username);
			}
		}

		private String password;

		public String Password {
			get { return password; }
			set {
				password = value;
				RaisePropertyChanged (() => Password);
			}
		}

		private bool isRunning;

		public bool IsRunning {
			get{ return isRunning; }
			set { 
				isRunning = value;
				RaisePropertyChanged (() => IsRunning);
			}
		}

		private bool enableBtn;

		public bool EnableBtn {
			get { return enableBtn; }
			set { 
				enableBtn = value;
				RaisePropertyChanged (() => EnableBtn);
			}
		}



		public LoginPageViewModel (IMyNavigationService navigationService)
		{
			this.navigationService = navigationService;

			LoggedIn = App.LoggedIn;
			IsRunning = false;
			LoginFailed = false;

			GoToSignupPage = new Command (() => {
				this.navigationService.NavigateTo (ViewModelLocator.SignupPageKey);
			});

			Login = new Command (async () => {

				IsRunning = true;
				EnableBtn = false;
//				var database = new ECOdatabase();
				var database = new AzureDatabase ();

//				database1.GetUsers();

				int rowcount = await database.ValidateUser (Username, Password);
				if (rowcount == 0) {
					App.LoggedIn = false;
					IsRunning = false;
					LoginFailed = true;
					EnableBtn = true;
				} else {
					App.LoggedIn = true;
					//Navigate to homepage without back key
					IsRunning = false;
					EnableBtn = true;
					this.navigationService.NavigateToModal (ViewModelLocator.HomePageKey);
				}

			});

		}

			

		public void OnAppearing ()
		{
			EnableBtn = true;
			LoginFailed = false;
			LoggedIn = App.LoggedIn;
			Username = null;
			Password = null;			
		}
	}
}

