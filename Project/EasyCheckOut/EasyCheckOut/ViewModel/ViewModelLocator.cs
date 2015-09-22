/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:EasyCheckOut"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace EasyCheckOut.ViewModel
{
	/// <summary>
	/// This class contains static references to all the view models in the
	/// application and provides an entry point for the bindings.
	/// </summary>
	public class ViewModelLocator
	{
		//Pages key
		public const string HomePageKey = "HomePage";
		public const string LoginPageKey = "LoginPage";
		public const string SignupPageKey = "SignupPage";
		public const string BuylistPageKey = "BuylistPage";
		public const string CartPageKey = "CartPage";
		public const string ConnectPageKey = "ConnectPage";
		public const string ReceivePageKey = "ReceivePage";
		public const string MapPageKey = "MapPage";
		public const string ScannerPageKey = "ScannerPage";

		/// <summary>
		/// Initializes a new instance of the ViewModelLocator class.
		/// </summary>
		public ViewModelLocator ()
		{

			ServiceLocator.SetLocatorProvider (() => SimpleIoc.Default);

			////if (ViewModelBase.IsInDesignModeStatic)
			////{
			////    // Create design time view services and models
			////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
			////}
			////else
			////{
			////    // Create run time view services and models
			////    SimpleIoc.Default.Register<IDataService, DataService>();
			////}

			//Example
			//SimpleIoc.Default.Register<MainViewModel>();

			//Register every viewModel to the viewModel locator

			//Registor Homepage
			SimpleIoc.Default.Register<HomePageViewModel> (() => {
				return new HomePageViewModel (
					SimpleIoc.Default.GetInstance<IMyNavigationService> ()
				);
			});

			//Registor Login page
			SimpleIoc.Default.Register<LoginPageViewModel> (() => {
				return new LoginPageViewModel (
					SimpleIoc.Default.GetInstance<IMyNavigationService> ()
				);
			});

			//Registor Sign up Page
			SimpleIoc.Default.Register<SignupPageViewModel> (() => {
				return new SignupPageViewModel(
					SimpleIoc.Default.GetInstance<IMyNavigationService> ()
				);	
			});

			//Registor Buy list Page
			SimpleIoc.Default.Register<BuylistPageViewModel> (() => {
				return new BuylistPageViewModel(
					SimpleIoc.Default.GetInstance<IMyNavigationService> ()
				);	
			});

			//Registor Cart Page
			SimpleIoc.Default.Register<CartPageViewModel> (() => {
				return new CartPageViewModel(
					SimpleIoc.Default.GetInstance<IMyNavigationService> ()
				);	
			});

			//Registor Connect Page
			SimpleIoc.Default.Register<ConnectPageViewModel> (() => {
				return new ConnectPageViewModel(
					SimpleIoc.Default.GetInstance<IMyNavigationService> ()
				);	
			});

			//Registor Receive Page
			SimpleIoc.Default.Register<ReceivePageViewModel> (() => {
				return new ReceivePageViewModel(
					SimpleIoc.Default.GetInstance<IMyNavigationService> ()
				);	
			});

			//Registor Map Page
			SimpleIoc.Default.Register<MapPageViewModel> (() => {
				return new MapPageViewModel(
					SimpleIoc.Default.GetInstance<IMyNavigationService> ()
				);	
			});

			//Registor Scanner Page
			SimpleIoc.Default.Register<ScannerPageViewModel> (() => {
				return new ScannerPageViewModel(
					SimpleIoc.Default.GetInstance<IMyNavigationService> ()
				);	
			});
		}

		public HomePageViewModel HomePage {
			get {
				return ServiceLocator.Current.GetInstance<HomePageViewModel> ();
			}
		}

		public LoginPageViewModel LoginPage{
			get{ 
				return ServiceLocator.Current.GetInstance<LoginPageViewModel> ();
			}
		}

		public SignupPageViewModel SignupPage{
			get{ 
				return ServiceLocator.Current.GetInstance<SignupPageViewModel> ();
			}
		}

		public BuylistPageViewModel BuylistPage{
			get{ 
				return ServiceLocator.Current.GetInstance<BuylistPageViewModel> ();
			}
		}

		public CartPageViewModel CartPage{
			get{ 
				return ServiceLocator.Current.GetInstance<CartPageViewModel> ();
			}
		}

		public ConnectPageViewModel ConnectPage{
			get{ 
				return ServiceLocator.Current.GetInstance<ConnectPageViewModel> ();	
			}
		}

		public ReceivePageViewModel ReceivePage{
			get{ 
				return ServiceLocator.Current.GetInstance<ReceivePageViewModel> ();
			}
		}

		public MapPageViewModel MapPage{
			get{ 
				return ServiceLocator.Current.GetInstance<MapPageViewModel> ();
			}
		}

		public ScannerPageViewModel ScannerPage{
			get{ 
				return ServiceLocator.Current.GetInstance<ScannerPageViewModel> ();
			}
		}

		public static void Cleanup ()
		{
			// TODO Clear the ViewModels
		}
	}
}