using System;
using Android.App;
using Android.Content;
using Android.OS;
using System.Collections.ObjectModel;

namespace AWACEProof.Droid
{

	public class RestrictionsChangedArgs : EventArgs
	{
		public SettingsData[] Settings { get; private set; }

		public RestrictionsChangedArgs(SettingsData[] settings)
		{
			Settings = settings;
		}
	}


	[BroadcastReceiver(Enabled = true)]
	[IntentFilter(new [] { Intent.ActionApplicationRestrictionsChanged })]
	public class RestrictionsChangedReceiver : BroadcastReceiver
	{
		public event RestrictionsChangedHandler RestrictionsChanged;
		public delegate void RestrictionsChangedHandler(object o, RestrictionsChangedArgs e);

		public override void OnReceive(Context context, Intent intent)
		{
			// Do stuff here when restrictions change
			if (RestrictionsChanged != null) {

				UserManager um = new UserManager ();
				Bundle b = um.GetApplicationRestrictions (Application.Context.ApplicationInfo.PackageName);

				Collection<string> a = b.KeySet ();

				int i = 0;
				SettingsData[] settings = new SettingsData[b.Size];

				foreach (string s in a) {
					settings [i++].Key = s;
				}

				RestrictionsChanged (this, new RestrictionsChangedArgs (settings));
			}
		}
	}
}

