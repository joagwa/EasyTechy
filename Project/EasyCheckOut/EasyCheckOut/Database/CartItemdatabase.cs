using System;
using SQLite.Net;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Ioc;
using EasyCheckOut;

namespace EasyCheckOut
{
	public class CartItemdatabase
	{
		SQLiteConnection database;

		public CartItemdatabase ()
		{
			database = DependencyService.Get<ISqlite> ().GetConnection ();

//			database.DeleteAll<CartItem> ();
			//Create a CartItem table if there is no such table
			if (database.TableMappings.All(t => t.MappedType.Name != typeof(CartItem).Name)) {
//			if (!TableExist("CartItem")){
				database.CreateTable<CartItem> ();
				database.Commit ();

				CartItem item1 = new CartItem ("Apple", 4.00);
				CartItem item2 = new CartItem ("Orange", 3.50);
				CartItem item3 = new CartItem ("Banana", 5.00);
				CartItem item4 = new CartItem ("Grape", 9.00);
				CartItem item5 = new CartItem ("Water", 2.00);

				InsertItem (item1);
				InsertItem (item2);
				InsertItem (item3);
				InsertItem (item4);
				InsertItem (item5);
			}
		}

		public List<CartItem> GetAll(){
			var items = database.Table<CartItem> ().ToList<CartItem> ();
			return items;
		}

		public int InsertItem(CartItem item){
			return database.Insert (item);
		}

		public int DeleteItem(CartItem item){
			return database.Delete<CartItem>(item.itemID);
		}
			
	}
}

