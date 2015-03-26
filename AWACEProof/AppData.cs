using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;

namespace AWACEProof
{
	public class AppData 
	{

		public static ObservableCollection<SettingsData> KeyPairs { get; set; }

		public AppData ()
		{
		}
	}

	public class SettingsData
	{
		public string Key { get; set; }
		public string Value { get; set; }

		public SettingsData(string key, string value)
		{
			Key = key;
			Value = value;
		}
	}


}

