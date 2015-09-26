using System;
using System.Collections.Generic;
using Xamarin.Forms;
using EasyCheckOut.ViewModel;
using Microsoft.Practices.ServiceLocation;

using Xamarin.Forms;

namespace EasyCheckOut
{
	public partial class CartPage : BaseView
	{
		public CartPage ()
		{
			InitializeComponent ();
			base.Init ();
			BindingContext = App.Locator.CartPage;
		}

		protected override void OnAppearing(){
			base.OnAppearing ();
			var vm = ServiceLocator.Current.GetInstance<CartPageViewModel> ();
			vm.OnApperaing ();
		}

	}
}

