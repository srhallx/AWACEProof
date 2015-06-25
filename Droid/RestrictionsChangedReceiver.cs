using System;
using Android.App;
using Android.Content;
using Android.OS;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace AWACEProof.Droid
{

	public class RestrictionsChangedArgs : EventArgs
	{
		public Dictionary<string, string>[] Settings { get; private set; }

		public RestrictionsChangedArgs(Dictionary<string, string>[] settings)
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
				Dictionary<string, string>[] settings = new Dictionary<string, string> (b.Size);

				//
				// Fire event that restrictions have changed
				//
				RestrictionsChanged (this, new RestrictionsChangedArgs (settings));
			}
		}
	}
}

