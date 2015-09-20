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
			SimpleIoc.Default.Register<HomePageViewModel> (() => {
				return new HomePageViewModel (
					SimpleIoc.Default.GetInstance<IMyNavigationService> ()
				);
			});
			SimpleIoc.Default.Register<LoginPageViewModel> (() => {
				return new LoginPageViewModel (
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

		public static void Cleanup ()
		{
			// TODO Clear the ViewModels
		}
	}
}