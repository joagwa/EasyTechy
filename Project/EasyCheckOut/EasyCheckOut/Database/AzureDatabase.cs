using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;


namespace EasyCheckOut
{
	public class AzureDatabase
	{

		public AzureDatabase ()
		{
		}

		public async Task<List<User>> GetUsers (){
			var users = Azure.MobileService.GetTable<User> ();

			var x = users.CreateQuery ();


			return await x.ToListAsync ();
		}

		public async void InsertUser(string username, string password, string mobile, string email){
			await Azure.MobileService.GetTable<User> ().InsertAsync (new User (username, password, mobile, email));
//			return rowaffected;
		}

		public async Task<int> ValidateUser(string username, string password){
			var rowcount = await Azure.MobileService.GetTable<User> ().ToListAsync ();
			var y = rowcount.Where(x => x.UserName == username && x.UserPassword == password);
			return y.Count();
		}
	}
}

