using System;
using System.Collections.Generic;
using EasyCheckOut;
using EasyCheckOut.ViewModel;
using Microsoft.Practices.ServiceLocation;
using Xamarin.Forms;

namespace EasyCheckOut
{
	public partial class LoginPage : BaseView
	{
		public LoginPage ()
		{
			InitializeComponent ();
			base.Init ();
			BindingContext = App.Locator.LoginPage;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing ();
			var vm = ServiceLocator.Current.GetInstance<LoginPageViewModel> ();
			vm.OnAppearing ();
		}
	}
}

