using System;
using System.Collections.ObjectModel;
using Foundation;
using System.Collections.Generic;
using UIKit;

namespace AWACEProof.iOS
{
	public class UserDefaultsHelper
	{

		private const string CONFIGURATION_KEY = "com.apple.configuration.managed";
		private const string NOTIFICATION_EVENT = "NSUserDefaultsDidChangeNotification";

		public UserDefaultsHelper ()
		{

		}

		public static string ValueForUserDefaultDefaultKey(string key)
		{
			var defaults = NSUserDefaults.StandardUserDefaults.DictionaryForKey (CONFIGURATION_KEY);

			if (defaults != null)
				return defaults.ObjectForKey (NSObject.FromObject (key)).ToString();
			else
				return null;
		}

		public static ObservableCollection<KeyValuePair<string, string>> RetrieveUserDefaults()
		{

			var defaults = NSUserDefaults.StandardUserDefaults.DictionaryForKey (CONFIGURATION_KEY);

			var keypairs = new ObservableCollection<KeyValuePair<string,string>> ();
			if (defaults != null && defaults.Count > 0) {

				for (int i = 0; i < (int)defaults.Count; ++i) {
					keypairs.Add (new KeyValuePair<string, string> (defaults.Keys[i].ToString (), defaults.Values[i].ToString ()));
				}
			}
			return keypairs;
		}

		/// <summary>
		/// Adds the defaults observer.
		/// 
		/// defaultsChangedAction method has parameter of NSNotification
		/// 
		/// ex: private void DefaultsChanged(NSNotification obj) { ... }
		/// </summary>
		/// <param name="defaultsChangedAction">Defaults changed action method.</param>
		public static void AddDefaultsObserver(Action<NSNotification> defaultsChangedAction)
		{
			NSNotificationCenter.DefaultCenter.AddObserver ((NSString)NOTIFICATION_EVENT, defaultsChangedAction);
		}

		public static void RemoveDefaultsObserver()
		{
			NSNotificationCenter.DefaultCenter.RemoveObserver ((NSString)NOTIFICATION_EVENT);
		}
			

		//
		// Sample code for clearing clipboard
		//
		public static void ClearPasteboard() {

			string[] pbtypes = UIPasteboard.General.Types;

			if (pbtypes.Length > 0) {
				foreach (string p in pbtypes) {
					UIPasteboard.General.SetValue (NSString.Empty, p);
				}
			}
		}

	}
}

