using System;
using SQLite.Net.Attributes;


namespace EasyCheckOut
{
	public class BuyList
	{

		[PrimaryKey, AutoIncrement]
		public int BuyListID { get; set; }
		public DateTime TimeStamp{ get; set; }
		public string BuyListDetail { get; set;}

		public BuyList ()
		{
		}

		public BuyList(DateTime time, string detail){
			TimeStamp = time;
			BuyListDetail = detail;
		}
	}
}

