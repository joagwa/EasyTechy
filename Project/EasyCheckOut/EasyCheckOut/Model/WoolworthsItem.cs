using System;
using SQLite.Net.Attributes;

namespace EasyCheckOut
{
	public class WoolworthsItem
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		[NotNull, MaxLength(128)]
		public string itemBarCode { get; set; }

		[NotNull, MaxLength(128)]
		public string itemName{ get; set; }

		public double itemPrice{ get; set; }

		public string itemImage{ get; set; }

		public WoolworthsItem ()
		{
		}

		public WoolworthsItem(string itemBarCode, string itemName, double itemPrice, string itemImage){
			this.itemBarCode = itemBarCode;
			this.itemName = itemName;
			this.itemPrice = itemPrice;
			this.itemImage = itemImage;
		}
	}
}

