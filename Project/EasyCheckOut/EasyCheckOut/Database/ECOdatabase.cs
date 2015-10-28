using System;
using SQLite.Net;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Ioc;
using EasyCheckOut;

namespace EasyCheckOut
{
	public class ECOdatabase
	{
		SQLiteConnection database;

		public ECOdatabase ()
		{
			database = DependencyService.Get<ISqlite> ().GetConnection ();
//			database.DeleteAll<CartItem> ();

			//Create a CartItem table if there is no such table
			if (database.TableMappings.All (t => t.MappedType.Name != typeof(CartItem).Name)) {
				database.CreateTable<CartItem> ();
				database.Commit ();
			}

			if (database.TableMappings.All (t => t.MappedType.Name != typeof(BuyList).Name)) {
				//Create user table
				database.CreateTable<BuyList> ();
				database.Commit ();
			}

			if (database.TableMappings.All (t => t.MappedType.Name != typeof(WoolworthsItem).Name)) {
				//Create cartitem table
				database.CreateTable<WoolworthsItem> ();
				database.Commit ();
			}
				
		}

		//Function for cart item table
		public List<CartItem> GetCartItemAll ()
		{
			var items = database.Table<CartItem> ().ToList<CartItem> ();
			return items;
		}

		public int InsertItemToCart (CartItem item)
		{
			return database.Insert (item);
		}

		public int DeleteItemInCart (CartItem item)
		{
			return database.Delete<CartItem> (item.itemID);
		}

		public int DeleteAllInCart ()
		{
			return database.DeleteAll<CartItem> ();
		}

		//Function for user table
		//		public int ValidateUser(string username, string password){
		//			var rowcount = database.Query<User> ("Select * from User where UserName = ? and UserPassword = ?", username, password);
		//			return rowcount.Count ();
		//		}
		//
		//		public int InsertItemToUser(User user){
		//			return database.Insert (user);
		//		}

		//Buy list
		public List<BuyList> GetBuyListAll ()
		{
			var items = database.Table<BuyList> ().ToList<BuyList> ();
			return items;
		}

		public int InsertItemToBuyList (BuyList item)
		{
			return database.Insert (item);
		}

		public int DeleteAllInBuyList ()
		{
			return database.DeleteAll<BuyList> ();
		}

		//Woolworths items
		public List<WoolworthsItem> GetWoolWorthsItemAll ()
		{
			var items = database.Table<WoolworthsItem> ().ToList<WoolworthsItem> ();
			return items;
		}

		public int InsertItemToWoolWorthsItem (WoolworthsItem item)
		{
			return database.Insert (item);

		}

		public List<WoolworthsItem> SearchWoolWorthsItem (string searchTerm)
		{
			//return database.Table<WoolworthsItem> ().Where (x => x.itemBarCode.Contains (searchTerm)).ToList ();

			var valueList = 
				from item in database.Table<WoolworthsItem> ()
				    where item.itemBarCode.Contains (searchTerm)
				    select item;
			var value = valueList.ToList ();
			return value;
		}

		public int DeleteAllInWoolworthsItem ()
		{
			return database.DeleteAll<WoolworthsItem> ();
		}
			
	}
}

