using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace EasyCheckOut.ViewModel
{
	public class CartPageViewModel : ViewModelBase
	{
		private IMyNavigationService navigationService;

		private ObservableCollection<CartItem> itemList{ get; set; }
		public ObservableCollection<CartItem> ItemList{
			get { return itemList; }
			set {
				itemList = value;
				RaisePropertyChanged (() => ItemList);
			}
		}

		public CartPageViewModel (IMyNavigationService navigationService)
		{
			this.navigationService = navigationService;
		}

		public void OnApperaing()
		{
			var database = new CartItemdatabase ();
			ItemList = new ObservableCollection<CartItem> (database.GetAll ());
		}
	}
}

