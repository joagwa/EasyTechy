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
			if (database.TableMappings.All(t => t.MappedType.Name != typeof(CartItem).Name)) {
//			if (!TableExist("CartItem")){

				//Create cartitem table
				database.CreateTable<CartItem> ();
				database.Commit ();

			}

			if (database.TableMappings.All(t => t.MappedType.Name != typeof(User).Name)) {
				//Create user table
				database.CreateTable<User> ();
				database.Commit ();

			}

			if (database.TableMappings.All(t => t.MappedType.Name != typeof(BuyList).Name)) {
				//Create user table
				database.CreateTable<BuyList> ();
				database.Commit ();

				BuyList item1 = new BuyList(DateTime.Now, "test1");
				BuyList item2 = new BuyList(DateTime.Now, "test2");
				BuyList item3 = new BuyList(DateTime.Now, "test3");

//				InsertItemToBuyList (item1);
//				InsertItemToBuyList (item2);
//				InsertItemToBuyList (item3);

			}


		}

		//Function for cart item table
		public List<CartItem> GetCartItemAll(){
			var items = database.Table<CartItem> ().ToList<CartItem> ();
			return items;
		}
			
		public int InsertItemToCart(CartItem item){
			return database.Insert (item);
		}

		public int DeleteItemInCart(CartItem item){
			return database.Delete<CartItem>(item.itemID);
		}

		//Function for user table
		public int ValidateUser(string username, string password){
			var rowcount = database.Query<User> ("Select * from User where UserName = ? and UserPassword = ?", username, password);
			return rowcount.Count ();
		}

		public int InsertItemToUser(User user){
			return database.Insert (user);
		}

		//Buy list
		public List<BuyList> GetBuyListAll(){
			var items = database.Table<BuyList> ().ToList<BuyList> ();
			return items;
		}

		public int InsertItemToBuyList(BuyList item){
			return database.Insert (item);
		}
			
	}
}

