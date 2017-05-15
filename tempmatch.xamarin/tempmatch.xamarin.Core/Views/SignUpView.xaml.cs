using System;
using System.Collections.Generic;
using common.xamarin.Core;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tempmatch.xamarin.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignUpView : ContentView
	{
		public SignUpView ()
		{
			this.Resources = SessionContext.Resources;

			InitializeComponent ();
		}
	}
}