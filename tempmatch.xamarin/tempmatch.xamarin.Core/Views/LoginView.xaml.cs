using System;
using System.Collections.Generic;
using common.xamarin.Core;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tempmatch.xamarin.Core.Views
{
	[XamlCompilation (XamlCompilationOptions.Compile)]
	public partial class LoginView : ContentView
	{
		public LoginView ()
		{
			this.Resources = SessionContext.Resources;

			InitializeComponent ();
		}
	}
}