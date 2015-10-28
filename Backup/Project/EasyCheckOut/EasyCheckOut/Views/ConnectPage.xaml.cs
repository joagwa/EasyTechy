using System;
using System.Collections.Generic;
using EasyCheckOut.ViewModel;
using EasyCheckOut;
using Microsoft.Practices.ServiceLocation;
using Xamarin.Forms;

namespace EasyCheckOut
{
	public partial class ConnectPage : BaseView
	{
		public ConnectPage ()
		{
			InitializeComponent ();
			base.Init ();
			BindingContext = App.Locator.ConnectPage;
		}

		protected override void OnAppearing()
		{
			var vm = ServiceLocator.Current.GetInstance<ConnectPageViewModel> ();
			base.OnAppearing ();
			vm.OnApperaing ();
		}
	}
}

