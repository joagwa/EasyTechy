using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Scanner.iOS;
using EasyCheckOut;

[assembly: Xamarin.Forms.Dependency (typeof (Scanner.iOS.Scanner))]

namespace Scanner.iOS
{
	public class Scanner: IScanner
	{
		#region IScanner implementation

		async public Task<string> Scan ()
		{
			//NOTE: On Android you MUST pass a Context into the Constructor!
			var scanner = new ZXing.Mobile.MobileBarcodeScanner();
			var result = await scanner.Scan();

			if (result != null)
			Console.WriteLine("Scanned Barcode: " + result.Text);

			return result.Text;
//			return "We need to link to a real iphone to test";
		}

		#endregion


	}
}