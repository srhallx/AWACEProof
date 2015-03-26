using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace AWACEProof
{
	public partial class ListFormPage : ContentPage
	{
		ObservableCollection<SettingsData> Items = AppData.KeyPairs;

		public ListFormPage ()
		{
			InitializeComponent ();
			BindingContext = Items;
		}
	}
}

