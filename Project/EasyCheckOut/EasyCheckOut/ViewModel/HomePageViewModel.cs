using GalaSoft.MvvmLight;
using System;
using System.Windows.Input;
using Xamarin.Forms;

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

		public ICommand GoToLoginPage { get; private set; }
		public string Param { get; set; }
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
		public HomePageViewModel(IMyNavigationService navigationService)
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

			GoToLoginPage = new Command (param => {
				var x = param as String;
				this.navigationService.NavigateTo (ViewModelLocator.LoginPageKey);
			});
		}

		public void OnAppearing()
		{
//			RaisePropertyChanged
		}
    }
}