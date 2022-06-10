using System;
using Realms;

namespace XamarinRealmDelayedPropertyChange
{
	public class MyRealmObject : RealmObject
	{
		public string Value { get; set; }

		private string _transientValue;
		[Ignored]
		public string TransientValue
		{
			get => _transientValue;
			set
            {
				_transientValue = value;
				RaisePropertyChanged();
            }
		}
	}
}

