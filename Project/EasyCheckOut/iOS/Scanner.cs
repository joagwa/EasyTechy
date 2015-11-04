using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Scanner.iOS;
using EasyCheckOut;
//using Refractored.Xam.Vibrate.Abstractions;
using AudioToolbox;

[assembly: Xamarin.Forms.Dependency (typeof(Scanner.iOS.Scanner))]

namespace Scanner.iOS
{
	public class Scanner: IScanner
	{
		#region IScanner implementation

		async public Task<string> Scan ()
		{
			//NOTE: On Android you MUST pass a Context into the Constructor!
			var scanner = new ZXing.Mobile.MobileBarcodeScanner ();

//			scanner.ScanContinuously( HandleScanResult );

			var result = await scanner.Scan ();

			if (result != null) {
				Console.WriteLine ("Scanned Barcode: " + result.Text);
				SystemSound.Vibrate.PlaySystemSound ();
				return result.Text;
			} else {
				Console.WriteLine ("No barcode scanned");
//				SystemSound.Vibrate.PlaySystemSound ();
//				return "50375264";
				return null;
			}


			return null;
		}

		//		void HandleScanResult(ZXing.Result result)
		//		{
		//			string msg = "";
		//
		//			if (result != null && !string.IsNullOrEmpty (result.Text)) {
		//				msg = "Found Barcode: " + result.Text;
		//				Console.WriteLine (msg);
		//
		//			} else {
		//				msg = "Scanning Canceled!";
		//			}
				

		//			this.InvokeOnMainThread(() => {
		//				var av = new UIAlertView("Barcode Result", msg, null, "OK", null);
		//				av.Show();
		//			});
	}

	#endregion


}