using System;
using SQLite.Net;

namespace EasyCheckOut
{
	public interface ISqlite
	{
		SQLiteConnection GetConnection();
	}
}

