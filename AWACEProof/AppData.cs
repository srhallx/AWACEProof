using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;

namespace AWACEProof
{
	public class AppData 
	{
		public static ObservableCollection<KeyValuePair<string, string>> KeyPairs { get; set; }

		public AppData ()
		{
		}
	}
}

