using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using common.xamarin.Core;
using common.xamarin.Core.Helpers;
using tempmatch.xamarin.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tempmatch.xamarin.Core.Pages
{
	[XamlCompilation (XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage //, INavigationPage
	{
		#region Fields

		//private INavigationItem _navigationItem;
		//private INavigationItem _previousNavigationItem = null;

		#endregion Fields

		#region Constructors

		public LoginPage ()
		{
			this.Resources = SessionContext.Resources;

			InitializeComponent();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			//NavigationPage.SetHasNavigationBar (this, false);
		}

		#endregion Constructors

		#region Properties

		public LoginViewModel LoginViewModel
		{
			get
			{
				return (LoginViewModel)this.BindingContext;
			}
		}

		//public INavigationItem NavigationItem
		//{
		//	get
		//	{
		//		return _navigationItem;
		//	}
		//}

		//public INavigationItem PreviousNavigationItem
		//{
		//	get
		//	{
		//		return _previousNavigationItem;
		//	}
		//}

		//public common.xamarin.Core.ViewModels.BaseViewModel BaseViewModel
		//{
		//	get
		//	{
		//		return (common.xamarin.Core.ViewModels.BaseViewModel)this.BindingContext;
		//	}
		//}

		#endregion Properties

		#region Methods

		public bool Init(/*INavigationItem navigationItem*/)
		{
			bool result = false;

			//if (_navigationItem != null)
			//{
			//	_previousNavigationItem = _navigationItem;
			//}

			//_navigationItem = navigationItem;

			result = true;

			return result;
		}

		public async Task DisplayAlert(Alert alert)
		{
			Device.BeginInvokeOnMainThread(async () =>
			{
				await this.DisplayAlert(alert.Title, alert.Message, alert.OkButtonText);
			});
		}

		#endregion Methods
	}
}