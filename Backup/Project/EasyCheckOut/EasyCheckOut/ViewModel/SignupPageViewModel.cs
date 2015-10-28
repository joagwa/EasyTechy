using GalaSoft.MvvmLight;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace EasyCheckOut.ViewModel
{
	public class SignupPageViewModel : ViewModelBase
	{
		private IMyNavigationService navigationService;

		public ICommand CreateAccount{ get; private set; }

		private bool cannotSignUp;
		public bool CanNotSignUp
		{
			get {return cannotSignUp; }
			set{ 
				cannotSignUp = value;
				RaisePropertyChanged (() => CanNotSignUp);
			}

		}

		private string username;
		public string Username
		{
			get { return username;}
			set{
				username = value;
				RaisePropertyChanged(()=>Username);
			}
		}

		private string password;
		public string Password{
			get{ return password; }
			set{ 
				password = value;
				RaisePropertyChanged (() => Password);
			}
		}

		private string confirmPassword;
		public string ConfirmPassword{
			get { return confirmPassword; }
			set { 
				confirmPassword = value;
				RaisePropertyChanged (() => ConfirmPassword);
			}
		}

		private string email;
		public string Email{
			get { return email; }
			set{ 
				email = value;
				RaisePropertyChanged (() => Email);
			}
		}

		private string mobile;
		public string Mobile{
			get { return mobile; }
			set{ 
				mobile = value;
				RaisePropertyChanged (() => Mobile);
			}
		}


		public SignupPageViewModel (IMyNavigationService navigationService)
		{
			this.navigationService = navigationService;

			CreateAccount = new Command (() => {
				if(SignupValidate()){
					// create account
//					User newUser = new User(Username, Password, Mobile, Email);

//					var database = new ECOdatabase();
//					database.InsertItemToUser(newUser);

					var database = new AzureDatabase();

					database.InsertUser(Username, Password, Mobile, Email);

					this.navigationService.NavigateToModal(ViewModelLocator.HomePageKey);
				}
			});
			Azure.MobileService.GetTable<User> ();
		}

		public bool SignupValidate (){
			if (username == null || mobile == null || email == null || password == null || confirmPassword == null) {
				CanNotSignUp = true;
				return false;
			}
			//validate data successfully
			CanNotSignUp = false;
			return true;
		}

		public void OnApperaing()
		{
			CanNotSignUp = false;
			Username = null;
			Mobile = null;
			Email = null;
			Password = null;
			ConfirmPassword = null;
		}
	}
}

