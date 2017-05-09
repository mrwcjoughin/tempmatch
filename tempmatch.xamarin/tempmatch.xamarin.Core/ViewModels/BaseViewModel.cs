using System;
using MvvmCross.Core.ViewModels;

namespace tempmatch.xamarin.Core.ViewModels
{
	public class BaseViewModel : MvxViewModel
	{
		public BaseViewModel ()
		{
		}

		public bool IsLoading
		{
			get;
			set;
		}
	}
}