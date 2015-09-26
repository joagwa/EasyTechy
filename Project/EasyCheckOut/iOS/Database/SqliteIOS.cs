using System;
using SQLite.Net;
using System.IO;
using Xamarin.Forms;
using EasyCheckOut.iOS;

[assembly: Dependency (typeof (SqliteIOS))]

namespace EasyCheckOut.iOS
{
	public class SqliteIOS : ISqlite
	{
		public SqliteIOS (){
		}
		#region ISqlite implementation

		public SQLiteConnection GetConnection()
		{
			const string sqliteFilename = "ECOdatabase.db3";
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
			var path = Path.Combine(documentsPath, sqliteFilename);
			var plat = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS ();
			// Create the connection
			var conn = new SQLiteConnection(plat,path);

			return conn;
		}

		#endregion
	}
}

