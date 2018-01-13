using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using MvvmCross.iOS.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Forms.iOS;

using Xamarin;
using Xamarin.Forms;
using tempmatch.xamarin.iOS.Providers;

namespace tempmatch.xamarin.iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : MvxFormsApplicationDelegate
	{
		public override UIWindow Window
		{
			get;
			set;
		}

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			Window = new UIWindow (UIScreen.MainScreen.Bounds);

			var setup = new Setup (this, Window);
			setup.Initialize ();

			var startup = Mvx.Resolve<IMvxAppStart> ();
			startup.Start ();

			Xamarin.IQKeyboardManager.SharedManager.Enable = true;
			Xamarin.IQKeyboardManager.SharedManager.EnableAutoToolbar = true;
			Xamarin.IQKeyboardManager.SharedManager.ShouldResignOnTouchOutside = true;
			Xamarin.IQKeyboardManager.SharedManager.ShouldShowTextFieldPlaceholder = true;
			Xamarin.IQKeyboardManager.SharedManager.ToolbarManageBehaviour = Xamarin.IQAutoToolbarManageBehaviour.Tag;

			DependencyService.Register<AWSCloudProvider>();
			
			Window.MakeKeyAndVisible ();

			return true;
		}
	}
}