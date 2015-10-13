using System;
using SQLite.Net.Attributes;

namespace EasyCheckOut
{
	public class User
	{
		[PrimaryKey, AutoIncrement]
		public int id{ get; set; }

		public int UserId { get; set; }
		[NotNull, MaxLength (128)]
		public string UserName{ get; set; }

		[NotNull, MaxLength (128)]
		public string UserPassword{ get; set; }

		[NotNull]
		public string MobileNumber{ get; set; }

		[NotNull]
		public string EmailAddress{ get; set; }

		public User ()
		{
		}

		public User (string username, string password, string mobile, string email){
			UserName = username;
			UserPassword = password;
			MobileNumber = mobile;
			EmailAddress = email;
		}
	}
}

