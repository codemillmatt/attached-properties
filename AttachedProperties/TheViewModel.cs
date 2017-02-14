using System;
using System.ComponentModel;
using Xamarin.Forms;
namespace AttachedProperties
{
	public class TheViewModel : INotifyPropertyChanged
	{
		public TheViewModel()
		{
		}

		public event PropertyChangedEventHandler PropertyChanged;

		string _status = "ready";
		public string Status
		{
			get
			{
				return _status;
			}
			set
			{
				_status = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Status)));
			}
		}

		public Command FinishEditing => new Command(() => { Status = "Commanded!"; });
	}
}
