using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace EasyCheckOut.ViewModel
{
	public class BuylistPageViewModel : ViewModelBase
	{

		private ObservableCollection<BuyList> buyList;

		public ObservableCollection<BuyList> BuyList {
			get { return buyList; }
			set { 
				buyList = value;
				RaisePropertyChanged (() => BuyList);
			}
		}


		private IMyNavigationService navigationService;

		public BuylistPageViewModel (IMyNavigationService navigationService)
		{
			this.navigationService = navigationService;
		}

		public void OnApperaing ()
		{
			var database = new ECOdatabase ();
			BuyList = new ObservableCollection<BuyList> (database.GetBuyListAll ());
		}

		//		async void ItemSelected(object sender, SelectedItemChangedEventArgs e)
		//		{
		//			ListView BuyList = (ListView)sender;
		//			if (BuyList.SelectedItem == null)
		//			{
		//				return;
		//			}
				
		//			await this.navigationService.NavigateTo (ViewModelLocator.HomePageKey);
		//			this.navigationService.NavigateTo (ViewModelLocator.HomePageKey);

		//			await Navigation.PushAsync(new EmployeeDetailPage((Employee)e.SelectedItem));
		//			listView.SelectedItem = null;
		//		}


			
	}
}

