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

			GoToSignupPage = new Command (() => {
				this.navigationService.NavigateTo(ViewModelLocator.SignupPageKey);
			});

		}


		public void OnAppearing()
		{
			username = null;
			password = null;
			RaisePropertyChanged (() => Username);
			RaisePropertyChanged (() => Password);
			
		}
	}
}

