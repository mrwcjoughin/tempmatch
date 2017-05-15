using System;
using System.Collections.Generic;
using common.xamarin.Core;
using tempmatch.xamarin.Core.ViewModels;
using Xamarin.Forms;

namespace tempmatch.xamarin.Core
{
	public partial class SignUpPage : ContentPage
	{
		public SignUpPage ()
		{
			this.Resources = SessionContext.Resources;

			InitializeComponent();

			this.BindingContext = new SignUpViewModel ();
		}
	}
}