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

				//Create user table
				database.CreateTable<User> ();
				database.Commit ();

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
			
	}
}

