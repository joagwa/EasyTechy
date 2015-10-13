using System;
using Microsoft.WindowsAzure.MobileServices;

namespace EasyCheckOut
{
	public static class Azure
	{
			public static MobileServiceClient MobileService = new MobileServiceClient(
			"https://ecodb.azure-mobile.net/",
			"KSiQBnmNdtMKpiAYiKkdMpifWUqXla54"
		);
	}
}

