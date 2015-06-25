using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using Foundation;
using UIKit;

namespace AWACEProof.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			//Load Defaults
			AppData.KeyPairs = UserDefaultsHelper.RetrieveUserDefaults ();

			//Start application
			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
	}
}

