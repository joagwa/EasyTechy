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

		public ICommand AddListToList{ get; private set; }

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

//			AddList = new Command (() => {
//				var database = new ECOdatabase();
//
//				BuyList list = new BuyList("11", "Sample");
//				database.InsertItemToBuyList(list);
//			
//			});

			AddListToList = new Command (() => {
				var database = new ECOdatabase();

				BuyList list = new BuyList (DateTime.Now, "Sample List");
				database.InsertItemToBuyList(list);

				BuyList = new ObservableCollection<BuyList> (database.GetBuyListAll ());
			});


		}

		public void OnApperaing ()
		{
			var database = new ECOdatabase ();
			BuyList = new ObservableCollection<BuyList> (database.GetBuyListAll ());
		}

			
	}
}

