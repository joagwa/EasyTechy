using System;
using System.Collections.Generic;
using EasyCheckOut.ViewModel;
using EasyCheckOut;
using Microsoft.Practices.ServiceLocation;
using Xamarin.Forms;


namespace EasyCheckOut
{
	public partial class BuylistPage : BaseView
	{
		public BuylistPage ()
		{
			InitializeComponent ();
			base.Init ();
			BindingContext = App.Locator.BuylistPage;
		}

		protected override void OnAppearing()
		{
			var vm = ServiceLocator.Current.GetInstance<BuylistPageViewModel> ();
			base.OnAppearing ();
			vm.OnApperaing ();
		}
	}
}

