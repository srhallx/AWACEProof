using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace AWACEProof.Droid
{
	[Activity (Label = "AWACEProof.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		RestrictionsChangedReceiver appRestrictionsChangedReceiver;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);


			appRestrictionsChangedReceiver = new RestrictionsChangedReceiver ();

			appRestrictionsChangedReceiver.RestrictionsChanged += (object o, RestrictionsChangedArgs e) => {
				//Restrictions changed, do something.
				if (e.Settings != null) {
					for (int i = 0; i < e.Settings.Length; ++i ) {
						Console.WriteLine(e.Settings[i].Key + " " + e.Settings[i].Value);
					}
				} else
					Console.WriteLine("App Restrictions settings were null.");
			};

			global::Xamarin.Forms.Forms.Init (this, bundle);

			LoadApplication (new App ());

		}
	}
}

