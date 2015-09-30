using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace EasyCheckOut
{
	public partial class ScannerPage : BaseView
	{
		public ScannerPage ()
		{
			InitializeComponent ();
			base.Init ();
			BindingContext = App.Locator.ScannerPage;
		}

		protected override void OnAppearing(){
		
		}
	}
}

