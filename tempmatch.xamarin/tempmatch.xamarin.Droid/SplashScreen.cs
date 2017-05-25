﻿using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Views;
using MvvmCross.Forms.Droid;
using Xamarin.Forms;

namespace tempmatch.xamarin.Droid
{
	[Activity (
		Label = "tempmatch.xamarin"
		, MainLauncher = true
		, Icon = "@mipmap/ic_launcher"
		, Theme = "@style/Theme.Splash"
		, NoHistory = true
		, ScreenOrientation = ScreenOrientation.Portrait)]
	public class SplashScreen
		: MvxSplashScreenActivity
	{
		public SplashScreen ()
			: base (Resource.Layout.SplashScreen)
		{
		}

		bool isInitializationComplete = false;
		public override void InitializationComplete ()
		{
			if (!isInitializationComplete)
			{
				isInitializationComplete = true;
				StartActivity (typeof (MvxFormsApplicationActivity));
			}
		}

		protected override void OnCreate (Android.OS.Bundle bundle)
		{
			Forms.Init (this, bundle);
			// Leverage controls' StyleId attrib. to Xamarin.UITest
			Forms.ViewInitialized += (object sender, ViewInitializedEventArgs e) =>
			{
				if (!string.IsNullOrWhiteSpace (e.View.StyleId))
				{
					e.NativeView.ContentDescription = e.View.StyleId;
				}
			};

			base.OnCreate (bundle);
		}
	}
}
