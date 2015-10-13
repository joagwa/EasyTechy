using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

		public async Task<int> ValidateUser(string username, string password){
			var rowcount = await Azure.MobileService.GetTable<User>().Where(x => x.UserName == username && x.UserPassword == password).ToListAsync();
			return rowcount.Count;
		}
	}
}

