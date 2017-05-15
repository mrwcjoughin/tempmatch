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
	public partial class StartPage : ContentPage //, INavigationPage
	{
		#region Fields

		//private INavigationItem _navigationItem;
		//private INavigationItem _previousNavigationItem = null;

		#endregion Fields

		#region Constructors

		public StartPage ()
		{
			this.Resources = SessionContext.Resources;

			InitializeComponent();

			this.BindingContext = new StartViewModel ();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			NavigationPage.SetHasNavigationBar (this, false);
		}

		#endregion Constructors

		#region Properties

		public StartViewModel StartViewModel
		{
			get
			{
				return (StartViewModel)this.BindingContext;
			}
			set
			{
				this.BindingContext = value;
			}
		}

		//public common.xamarin.Core.ViewModels.BaseViewModel BaseViewModel
		//{
		//	get
		//	{
		//		return (common.xamarin.Core.ViewModels.BaseViewModel)this.BindingContext;
		//	}
		//}

		#endregion Properties

		#region Methods

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