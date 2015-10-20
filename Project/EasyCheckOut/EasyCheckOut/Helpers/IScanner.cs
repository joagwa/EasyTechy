using System;
using System.Threading.Tasks;

namespace EasyCheckOut
{
	public interface IScanner
	{
		Task<string> Scan();
	}
}

