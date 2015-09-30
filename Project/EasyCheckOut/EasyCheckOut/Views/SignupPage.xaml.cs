using System;
using System.Collections.Generic;
using EasyCheckOut;
using EasyCheckOut.ViewModel;
using Microsoft.Practices.ServiceLocation;
using Xamarin.Forms;

namespace EasyCheckOut
{
	public partial class SignupPage : BaseView
	{
		public SignupPage ()
		{
			InitializeComponent ();
			base.Init ();
			BindingContext = App.Locator.SignupPage;
		}

		protected override void OnAppearing(){
			base.OnAppearing ();
			var vm = ServiceLocator.Current.GetInstance<SignupPageViewModel> ();
			vm.OnApperaing ();
		}
	}
}

