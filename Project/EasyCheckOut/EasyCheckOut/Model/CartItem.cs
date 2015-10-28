using System;
using SQLite.Net.Attributes;

namespace EasyCheckOut
{
	public class CartItem
	{	
		[PrimaryKey, AutoIncrement]
		public int itemID { get; set; }

		[NotNull, MaxLength(128)]
		public string itemName { get; set; }

		public double itemPrice { get; set; }

		public string itemImage { get; set; }

		public CartItem(){
		}

		public CartItem (string itemName, double itemPrice, string itemImage)
		{
			this.itemName = itemName;
			this.itemPrice = itemPrice;
			this.itemImage = itemImage;
		}
	}
}

