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


			var serverUrl = NSUserDefaults.StandardUserDefaults.DictionaryForKey ("com.apple.configuration.managed");

			AppData.KeyPairs = new ObservableCollection<SettingsData> ();

			AppData.KeyPairs.Add (new SettingsData("First", "Second"));

			if (serverUrl != null) {
				for (int i = 0; i < (int)serverUrl.Count; ++i) {
					AppData.KeyPairs.Add (new SettingsData(serverUrl.Keys [i].ToString (), serverUrl.Values [i].ToString ()));
				}
			}

			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
	}
}

