﻿using System;
using SQLite.Net;
using System.IO;
using Xamarin.Forms;
using EasyCheckOut.Droid;

[assembly: Dependency (typeof (SqliteDroid))]

namespace EasyCheckOut.Droid
{
	public class SqliteDroid : ISqlite
	{
		public SqliteDroid ()
		{
		}

		#region ISqlite implementation

		public SQLiteConnection GetConnection(){
		
			const string sqliteFilename = "ECOdatabase.db3";
			var documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			var path = Path.Combine (documentsPath, sqliteFilename);
			var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
			//Create the connection
			var conn = new SQLiteConnection(plat,path);

			return conn;
		}

		#endregion
	}
}

